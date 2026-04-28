# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
dotnet build                                                          # build all projects
dotnet test                                                           # run all tests
dotnet test --filter "FullyQualifiedName~TemplateRenderer"           # run single test class
dotnet pack src/ExceptionReporter.csproj -c Release --output ./artifacts  # create NuGet
```

## Architecture

### Solution Structure

```
src/   — ProExceptionReporter.dll (NuGet library, net48)
test/  — NUnit + Moq tests
demo/  — WinForms demo app (WinExe)
```

### Entry Points and Flow

**`ExceptionReporter`** (public) → **`ExceptionReporterBase`** (protected base)

Two usage modes:
- `er.Show(exception)` — shows WinForms dialog, driven by MVP pattern
- `er.Send(exception)` — silent async send, no dialog

**`ExceptionReportInfo`** is the central config/data bag passed through the whole system. Users configure it via `er.Config.*` before calling Show/Send.

### MVP Pattern (WinForms dialog)

```
ExceptionReporter.Show()
  → DefaultWinFormsViewmaker.Create()
  → ExceptionReportView  (IExceptionReportView)
  → ExceptionReportPresenter
  → ReportGenerator → TemplateRenderer
```

`IExceptionReportView` and `IViewMaker` (in `Core/`) are the seams that allow custom view implementations.

### Report Generation

`ReportGenerator` produces a `ReportPacket` (string content + optional zip attachment).

Templates live in `Templates/` as embedded resources (`.text`, `.html`, `.markdown`). `TemplateRenderer` loads them by manifest resource name `ExceptionReporting.Templates.<name>.<format>` and renders via Handlebars.NET. If you add a new template file, add it to the csproj `<EmbeddedResource>` glob — it is not auto-included.

### Network / Sending

`SenderFactory` picks an `IReportSender` based on `ExceptionReportInfo.SendMethod` (enum: `SimpleMAPI`, `SMTP`, `WebService`). Concrete senders are in `Network/Senders/` and are `internal`.

### Internal Visibility

Most implementation types (`IAttach`, `IFileService`, `IZipper`, senders, `SysInfoRetriever`, etc.) are `internal`. Tests access them via:
- `InternalsVisibleTo.cs` → `ExceptionReporter.Tests`
- `ExceptionReporterBase.cs` → `DynamicProxyGenAssembly2` (Moq)

### csproj Notes

The library csproj requires `<GenerateResourceUsePreserializedResources>true</GenerateResourceUsePreserializedResources>` and `System.Resources.Extensions` NuGet package because the WinForms `.resx` files contain binary (non-string) resources and the project builds with .NET SDK 10 targeting net48.
