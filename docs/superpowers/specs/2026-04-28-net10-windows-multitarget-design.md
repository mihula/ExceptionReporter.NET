# net10-windows Multi-Target Design

**Date:** 2026-04-28  
**Branch:** net10  
**Goal:** Add `net10.0-windows` as a second target alongside `net48` so the NuGet package serves both .NET Framework and .NET 10 consumers.

---

## Scope

All three projects are updated:

| Project | Change |
|---|---|
| `src/ExceptionReporter.csproj` | Library — primary target of this work |
| `test/ExceptionReporter.Tests.csproj` | Tests run against both TFMs |
| `demo/ExceptionReporter.Demo.csproj` | Demo app builds for both TFMs |

---

## TFM Change

All three projects change from:

```xml
<TargetFramework>net48</TargetFramework>
```

to:

```xml
<TargetFrameworks>net48;net10.0-windows</TargetFrameworks>
```

---

## csproj Reference Cleanup

### `ImportWindowsDesktopTargets`

Required for `net48` SDK-style projects using WinForms. Not needed (and potentially harmful) on `net10.0-windows` where the `-windows` TFM suffix handles WinForms automatically.

```xml
<PropertyGroup Condition="'$(TargetFramework)' == 'net48'">
  <ImportWindowsDesktopTargets>true</ImportWindowsDesktopTargets>
</PropertyGroup>
```

### Framework `<Reference>` items (net48 only)

These assemblies are built into .NET 10 and must not be explicitly referenced there. All existing `<Reference>` items are wrapped with `Condition="'$(TargetFramework)' == 'net48'"`.

Affected in `src`: `System.Configuration`, `System.IO.Compression`, `System.IO.Compression.FileSystem`, `System.Deployment`, `System.Drawing`, `System.Management`, `System.Windows.Forms`

Affected in `test`: `System.Deployment`, `System.Management`

Affected in `demo`: `System.Configuration`, `System.Management`

### `System.Management` NuGet (net10.0-windows only)

WMI (`System.Management`) is a framework built-in on `net48` but must be added as a NuGet package on .NET 10 (Windows-only):

```xml
<ItemGroup Condition="'$(TargetFramework)' == 'net10.0-windows'">
  <PackageReference Include="System.Management" Version="10.0.0" />
</ItemGroup>
```

### `System.Resources.Extensions` NuGet (net48 only)

Needed only when the .NET SDK builds `net48` targets that have binary `.resx` resources. Not needed for `net10.0-windows` where binary resources are natively supported. Move to:

```xml
<PackageReference Include="System.Resources.Extensions" Version="9.0.4"
                  Condition="'$(TargetFramework)' == 'net48'" />
```

---

## Code Change: `ReportGenerator.cs`

`System.Deployment.Application` was removed in .NET 5+. The one usage is in `GetAppVersion()`:

```csharp
// Before
private string GetAppVersion()
{
    return ApplicationDeployment.IsNetworkDeployed
        ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
        : _info.AppAssembly.GetName().Version.ToString();
}
```

```csharp
// After
private string GetAppVersion()
{
#if NETFRAMEWORK
    return ApplicationDeployment.IsNetworkDeployed
        ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
        : _info.AppAssembly.GetName().Version.ToString();
#else
    return _info.AppAssembly.GetName().Version.ToString();
#endif
}
```

The `using System.Deployment.Application;` directive is also wrapped with `#if NETFRAMEWORK`.

**Trade-off:** ClickOnce version detection is unavailable on .NET 10. Assembly version is used instead. This is acceptable — ClickOnce on .NET 10 is rare and the fallback was already the same value for non-ClickOnce deployments.

---

## Build Verification

After changes, the following must pass cleanly:

```bash
dotnet build          # both TFMs, no warnings about missing references
dotnet test           # tests run for net48 and net10.0-windows
```

---

## Out of Scope

- No API surface changes
- No new features
- No NuGet version bump (that is a separate decision)
- `Simple-MAPI.NET` is Windows-only but compatible with net10.0-windows — no change needed
- `Handlebars.Net` is cross-platform — no change needed
