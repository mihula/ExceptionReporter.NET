# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
dotnet build test/ExceptionReporter.Tests.csproj                          # build library + tests (both TFMs)
dotnet test test/ExceptionReporter.Tests.csproj                           # run all tests (net48 + net10.0-windows)
dotnet test --filter "FullyQualifiedName~TemplateRenderer"                # run single test class
dotnet pack src/ExceptionReporter.csproj -c Release --output ./artifacts  # create NuGet
```

> No `.sln` file — use explicit project paths. Building `test/ExceptionReporter.Tests.csproj` also builds the library via `ProjectReference`.

## Architecture

### Solution Structure

```
src/   — ProExceptionReporter.dll (NuGet library, net48 + net10.0-windows)
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

The library csproj requires `<GenerateResourceUsePreserializedResources>true</GenerateResourceUsePreserializedResources>` because the WinForms `.resx` files contain binary (non-string) resources. `System.Resources.Extensions` NuGet package is referenced only for the `net48` target (binary `.resx` deserialization at runtime); it is not needed for `net10.0-windows`.

`System.Management` (WMI) is a built-in framework assembly on `net48` and a NuGet package (`System.Management` v10.0.0) on `net10.0-windows`. All other WinForms framework references (`System.Drawing`, `System.Windows.Forms`, etc.) are net48-only — they are built into the net10.0-windows TFM.

## Releasing

CI/CD is defined in `.github/workflows/ci.yml` (GitHub Actions, `windows-latest`):

- **CI**: runs on every push to `main`/`master` and every PR — builds and tests both TFMs
- **Publish**: triggered by a `v*` tag — packs and pushes to NuGet.org and GitHub Packages

```bash
git tag v6.1.0
git push origin v6.1.0
```

Required secret: `NUGET_API_KEY` in repo Settings → Secrets → Actions (NuGet.org API key scoped to `ProExceptionReporter`). `GITHUB_TOKEN` is injected automatically.
