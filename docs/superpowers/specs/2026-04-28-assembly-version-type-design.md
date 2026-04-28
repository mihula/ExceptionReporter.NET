# Design: Configurable Assembly Version Type for App.Version

**Date:** 2026-04-28  
**Branch:** versions

## Problem

`ReportGenerator.GetAppVersion()` always extracts `AssemblyVersion` (`assembly.GetName().Version.ToString()`). Some projects set meaningful version info only in `FileVersion` or `InformationalVersion` (e.g. SemVer with git hash via `<InformationalVersion>`), making the report show an unhelpful "1.0.0.0" instead.

## Scope

Only `App.Version` (the main application version shown in the report header). `AssemblyDigger` (referenced assemblies list) is **not** affected — it operates on `AssemblyName` objects which only carry `AssemblyVersion`.

## Design

### 1. New enum `AssemblyVersionType`

New file: `src/AssemblyVersionType.cs`

```csharp
namespace ExceptionReporting
{
    public enum AssemblyVersionType
    {
        AssemblyVersion,       // default — existing behavior
        FileVersion,
        InformationalVersion
    }
}
```

### 2. New property on `ExceptionReportInfo`

```csharp
/// <summary>
/// Which version type to extract from the application assembly for display in the report.
/// Defaults to AssemblyVersion (existing behavior).
/// </summary>
public AssemblyVersionType AppVersionType { get; set; } = AssemblyVersionType.AssemblyVersion;
```

### 3. Modified `ReportGenerator.GetAppVersion()`

ClickOnce (net48 only) is preserved exclusively for the `AssemblyVersion` default. Explicit non-default settings skip ClickOnce.

```csharp
private string GetAppVersion()
{
#if NETFRAMEWORK
    if (_info.AppVersionType == AssemblyVersionType.AssemblyVersion
        && ApplicationDeployment.IsNetworkDeployed)
        return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
#endif
    return _info.AppVersionType switch
    {
        AssemblyVersionType.FileVersion =>
            FileVersionInfo.GetVersionInfo(_info.AppAssembly.Location).FileVersion
            ?? string.Empty,
        AssemblyVersionType.InformationalVersion =>
            _info.AppAssembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion ?? string.Empty,
        _ => _info.AppAssembly.GetName().Version.ToString()
    };
}
```

If the requested attribute is absent (`null`), returns `string.Empty` — no silent fallback to AssemblyVersion, so misconfiguration is visible.

### 4. Tests

New test class (or additions to existing `ReportGenerator` tests):

| Test | Assembly | Setting | Expected |
|------|----------|---------|---------|
| Default returns AssemblyVersion | executing assembly | `AssemblyVersion` | `assembly.GetName().Version.ToString()` |
| Returns FileVersion | executing assembly | `FileVersion` | `FileVersionInfo` value |
| Returns InformationalVersion | executing assembly | `InformationalVersion` | attribute value |
| Missing InformationalVersion returns empty | assembly without attribute | `InformationalVersion` | `string.Empty` |

Test assembly: `Assembly.GetExecutingAssembly()` (test project has all three version attributes set in its csproj).

## Files Changed

| File | Change |
|------|--------|
| `src/AssemblyVersionType.cs` | new |
| `src/ExceptionReportInfo.cs` | add `AppVersionType` property |
| `src/ReportGenerator.cs` | refactor `GetAppVersion()` |
| `test/ReportGenerator_AppVersion_Tests.cs` | new test class |

## Non-Goals

- Configurable version type for referenced assemblies in `AssemblyDigger`
- Fallback chain between version types
- Custom `Func<Assembly, string>` extractor
