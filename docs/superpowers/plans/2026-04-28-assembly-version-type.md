# Configurable Assembly Version Type Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Allow callers to configure which assembly version type (`AssemblyVersion`, `FileVersion`, `InformationalVersion`) is extracted from the main application assembly and displayed as `App.Version` in the exception report.

**Architecture:** A new `AssemblyVersionType` enum is added to `src/` alongside the existing `ReportSendMethod` enum. `ExceptionReportInfo` gets an `AppVersionType` property (default `AssemblyVersion`). `ReportGenerator.GetAppVersion()` branches on this property; ClickOnce handling (net48) is preserved exclusively for the default.

**Tech Stack:** C# 10+, .NET 4.8 / net10.0-windows, NUnit 4, `System.Diagnostics.FileVersionInfo`, `System.Reflection.AssemblyInformationalVersionAttribute`

---

### Task 1: Add `AssemblyVersionType` enum

**Files:**
- Create: `src/AssemblyVersionType.cs`

- [ ] **Step 1: Create the file**

```csharp
namespace ExceptionReporting
{
    public enum AssemblyVersionType
    {
        AssemblyVersion,
        FileVersion,
        InformationalVersion
    }
}
```

- [ ] **Step 2: Build to confirm no errors**

```bash
dotnet build test/ExceptionReporter.Tests.csproj
```

Expected: `Build succeeded.`

- [ ] **Step 3: Commit**

```bash
git add src/AssemblyVersionType.cs
git commit -m "feat: add AssemblyVersionType enum"
```

---

### Task 2: Add `AppVersionType` property to `ExceptionReportInfo`

**Files:**
- Modify: `src/ExceptionReportInfo.cs`

- [ ] **Step 1: Add property after the `AppVersion` property (around line 104)**

Add this block immediately after the `AppVersion` property:

```csharp
/// <summary>
/// Which version type to extract from the application assembly for <see cref="AppVersion"/>.
/// Defaults to <see cref="AssemblyVersionType.AssemblyVersion"/> (existing behavior).
/// </summary>
public AssemblyVersionType AppVersionType { get; set; } = AssemblyVersionType.AssemblyVersion;
```

- [ ] **Step 2: Build**

```bash
dotnet build test/ExceptionReporter.Tests.csproj
```

Expected: `Build succeeded.`

- [ ] **Step 3: Commit**

```bash
git add src/ExceptionReportInfo.cs
git commit -m "feat: add AppVersionType property to ExceptionReportInfo"
```

---

### Task 3: Write failing tests

**Files:**
- Create: `test/ReportGenerator_AppVersion_Tests.cs`

- [ ] **Step 1: Create the test file**

```csharp
using System;
using System.Diagnostics;
using System.Reflection;
using ExceptionReporting;
using NUnit.Framework;

namespace Tests.ExceptionReporting
{
    public class ReportGenerator_AppVersion_Tests
    {
        private static Assembly TestAssembly => Assembly.GetExecutingAssembly();

        private static ExceptionReportInfo InfoWith(AssemblyVersionType type)
        {
            return new ExceptionReportInfo
            {
                MainException = new Exception(),
                AppAssembly = TestAssembly,
                AppVersionType = type
            };
        }

        [Test]
        public void Default_returns_assembly_version()
        {
            var info = new ExceptionReportInfo
            {
                MainException = new Exception(),
                AppAssembly = TestAssembly
                // AppVersionType defaults to AssemblyVersion
            };
            new ReportGenerator(info);

            Assert.That(info.AppVersion, Is.EqualTo(TestAssembly.GetName().Version.ToString()));
        }

        [Test]
        public void FileVersion_returns_file_version()
        {
            var info = InfoWith(AssemblyVersionType.FileVersion);
            new ReportGenerator(info);

            var expected = FileVersionInfo.GetVersionInfo(TestAssembly.Location).FileVersion ?? string.Empty;
            Assert.That(info.AppVersion, Is.EqualTo(expected));
        }

        [Test]
        public void InformationalVersion_returns_informational_version()
        {
            var info = InfoWith(AssemblyVersionType.InformationalVersion);
            new ReportGenerator(info);

            var expected = TestAssembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?.InformationalVersion ?? string.Empty;
            Assert.That(info.AppVersion, Is.EqualTo(expected));
        }

        [Test]
        public void Pre_set_AppVersion_is_not_overwritten()
        {
            var info = new ExceptionReportInfo
            {
                MainException = new Exception(),
                AppAssembly = TestAssembly,
                AppVersion = "custom-1.2.3",
                AppVersionType = AssemblyVersionType.FileVersion
            };
            new ReportGenerator(info);

            Assert.That(info.AppVersion, Is.EqualTo("custom-1.2.3"));
        }
    }
}
```

- [ ] **Step 2: Run tests to confirm they fail (FileVersion and InformationalVersion tests fail because GetAppVersion still uses AssemblyVersion)**

```bash
dotnet test test/ExceptionReporter.Tests.csproj --filter "FullyQualifiedName~ReportGenerator_AppVersion"
```

Expected: `FileVersion_returns_file_version` and `InformationalVersion_returns_informational_version` FAIL. `Default_returns_assembly_version` and `Pre_set_AppVersion_is_not_overwritten` PASS.

- [ ] **Step 3: Commit failing tests**

```bash
git add test/ReportGenerator_AppVersion_Tests.cs
git commit -m "test: add failing tests for AppVersionType feature"
```

---

### Task 4: Implement `GetAppVersion()` in `ReportGenerator`

**Files:**
- Modify: `src/ReportGenerator.cs`

- [ ] **Step 1: Add missing `using` directives at the top of `ReportGenerator.cs`**

Add after the existing usings:

```csharp
using System.Diagnostics;
```

(`System.Reflection` is already present.)

- [ ] **Step 2: Replace `GetAppVersion()` method (currently lines 49–57)**

Replace the entire `GetAppVersion()` method with:

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

- [ ] **Step 3: Build**

```bash
dotnet build test/ExceptionReporter.Tests.csproj
```

Expected: `Build succeeded.`

- [ ] **Step 4: Run the new tests — all should pass**

```bash
dotnet test test/ExceptionReporter.Tests.csproj --filter "FullyQualifiedName~ReportGenerator_AppVersion"
```

Expected: 4 tests PASS.

- [ ] **Step 5: Run full test suite to check for regressions**

```bash
dotnet test test/ExceptionReporter.Tests.csproj
```

Expected: All tests PASS (both TFMs).

- [ ] **Step 6: Commit**

```bash
git add src/ReportGenerator.cs
git commit -m "feat: implement configurable AppVersionType in GetAppVersion"
```

---

### Task 5: Bump version to v6.1.0

**Files:**
- Modify: `src/ExceptionReporter.csproj`

- [ ] **Step 1: Update `<Version>` and `<FileVersion>` in `src/ExceptionReporter.csproj`**

Change:
```xml
<Version>6.0.0</Version>
<FileVersion>6.0.0.0</FileVersion>
```

To:
```xml
<Version>6.1.0</Version>
<FileVersion>6.1.0.0</FileVersion>
```

- [ ] **Step 2: Build and test**

```bash
dotnet test test/ExceptionReporter.Tests.csproj
```

Expected: All tests PASS.

- [ ] **Step 3: Commit**

```bash
git add src/ExceptionReporter.csproj
git commit -m "chore: bump version to 6.1.0"
```

---

### Task 6: Update README

**Files:**
- Modify: `README.md`

- [ ] **Step 1: Add `AppVersionType` to the configuration section**

In the "Interface Configuration" section (around line 24–31), after the existing list of config properties, add a new subsection before the `## How to use it` heading:

```markdown
#### App Version Type

By default the report shows the **Assembly Version** (`AssemblyVersion` attribute). If your project uses `FileVersion` or `InformationalVersion` (e.g. SemVer with a git hash via `<InformationalVersion>`), configure it before calling `Show`/`Send`:

```csharp
er.Config.AppVersionType = AssemblyVersionType.FileVersion;
// or
er.Config.AppVersionType = AssemblyVersionType.InformationalVersion;
```

If the requested attribute is absent the field will be empty (no silent fallback).
```

- [ ] **Step 2: Commit**

```bash
git add README.md
git commit -m "docs: document AppVersionType config option in README"
```
