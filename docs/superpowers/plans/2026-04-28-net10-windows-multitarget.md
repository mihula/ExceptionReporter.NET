# net10-windows Multi-Target Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Add `net10.0-windows` as a second TFM alongside `net48` in all three projects (library, tests, demo), including one conditional-compilation fix in `ReportGenerator.cs`.

**Architecture:** Change `<TargetFramework>` to `<TargetFrameworks>` in all three csproj files, guard net48-only framework references behind MSBuild conditions, add `System.Management` NuGet for the net10 build pass, and wrap the removed `System.Deployment.Application` API in `#if NETFRAMEWORK`.

**Tech Stack:** .NET SDK 10, MSBuild multi-targeting, C# preprocessor directives (`#if NETFRAMEWORK`)

---

## Files Modified

| File | What changes |
|---|---|
| `src/ExceptionReporter.csproj` | TFM, conditional references, System.Management NuGet |
| `src/ReportGenerator.cs` | `#if NETFRAMEWORK` around ClickOnce API |
| `test/ExceptionReporter.Tests.csproj` | TFM, conditional references |
| `demo/ExceptionReporter.Demo.csproj` | TFM, conditional references |

---

## Task 1: Create the net10 branch

**Files:** none

- [ ] **Step 1: Create and switch to branch**

```bash
git checkout -b net10
```

Expected: `Switched to a new branch 'net10'`

---

## Task 2: Update `src/ExceptionReporter.csproj`

**Files:**
- Modify: `src/ExceptionReporter.csproj`

- [ ] **Step 1: Replace the entire file with the multi-target version**

Replace the full contents of `src/ExceptionReporter.csproj` with:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net48;net10.0-windows</TargetFrameworks>
    <UseWindowsForms>true</UseWindowsForms>
    <RootNamespace>ExceptionReporting</RootNamespace>
    <AssemblyName>ProExceptionReporter</AssemblyName>
    <PackageId>ProExceptionReporter</PackageId>
    <Version>6.0.0</Version>
    <FileVersion>6.0.0.0</FileVersion>
    <Authors>Provys</Authors>
    <Description>WinForms dialog for detailed .NET exception reporting</Description>
    <PackageLicenseFile>LICENSE.txt</PackageLicenseFile>
    <RepositoryUrl>https://github.com/mihula/ProExceptionReporter</RepositoryUrl>
    <PackageTags>exception;error;reporting;winforms</PackageTags>
    <GeneratePackageOnBuild>false</GeneratePackageOnBuild>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
    <GenerateResourceUsePreserializedResources>true</GenerateResourceUsePreserializedResources>
  </PropertyGroup>

  <PropertyGroup Condition="'$(TargetFramework)' == 'net48'">
    <ImportWindowsDesktopTargets>true</ImportWindowsDesktopTargets>
  </PropertyGroup>

  <ItemGroup>
    <None Include="..\LICENSE.txt" Pack="true" PackagePath="" />
  </ItemGroup>

  <ItemGroup>
    <Compile Update="Properties\Resources.Designer.cs">
      <DependentUpon>Resources.resx</DependentUpon>
      <DesignTime>True</DesignTime>
      <AutoGen>True</AutoGen>
    </Compile>
  </ItemGroup>

  <ItemGroup>
    <EmbeddedResource Update="Properties\Resources.resx">
      <SubType>Designer</SubType>
      <LastGenOutput>Resources.Designer.cs</LastGenOutput>
      <Generator>ResXFileCodeGenerator</Generator>
    </EmbeddedResource>
  </ItemGroup>

  <ItemGroup>
    <EmbeddedResource Include="Templates\*.text" />
    <EmbeddedResource Include="Templates\*.html" />
    <EmbeddedResource Include="Templates\*.markdown" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Handlebars.Net" Version="2.1.6" />
    <PackageReference Include="Simple-MAPI.NET" Version="1.2.1" />
    <PackageReference Include="System.Resources.Extensions" Version="9.0.4"
                      Condition="'$(TargetFramework)' == 'net48'" />
  </ItemGroup>

  <ItemGroup Condition="'$(TargetFramework)' == 'net48'">
    <Reference Include="System.Configuration" />
    <Reference Include="System.IO.Compression" />
    <Reference Include="System.IO.Compression.FileSystem" />
    <Reference Include="System.Deployment" />
    <Reference Include="System.Drawing" />
    <Reference Include="System.Management" />
    <Reference Include="System.Windows.Forms" />
  </ItemGroup>

  <ItemGroup Condition="'$(TargetFramework)' == 'net10.0-windows'">
    <PackageReference Include="System.Management" Version="10.0.0" />
  </ItemGroup>
</Project>
```

- [ ] **Step 2: Attempt a library-only build (expect failure — ReportGenerator.cs still uses removed API)**

```bash
dotnet build src/ExceptionReporter.csproj -f net10.0-windows
```

Expected: Build error referencing `ApplicationDeployment` — confirms the csproj change is active and the code fix is needed next.

---

## Task 3: Fix `src/ReportGenerator.cs` — guard removed ClickOnce API

**Files:**
- Modify: `src/ReportGenerator.cs:7` (using directive) and `src/ReportGenerator.cs:47-50` (GetAppVersion method)

- [ ] **Step 1: Wrap the `using System.Deployment.Application` directive**

Change line 7 of `src/ReportGenerator.cs` from:

```csharp
using System.Deployment.Application;
```

to:

```csharp
#if NETFRAMEWORK
using System.Deployment.Application;
#endif
```

- [ ] **Step 2: Wrap the GetAppVersion method body**

Change the `GetAppVersion` method body (currently lines 48–50) from:

```csharp
		private string GetAppVersion()
		{
			return ApplicationDeployment.IsNetworkDeployed ? 
				ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : _info.AppAssembly.GetName().Version.ToString();
		}
```

to:

```csharp
		private string GetAppVersion()
		{
#if NETFRAMEWORK
			return ApplicationDeployment.IsNetworkDeployed ? 
				ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : _info.AppAssembly.GetName().Version.ToString();
#else
			return _info.AppAssembly.GetName().Version.ToString();
#endif
		}
```

- [ ] **Step 3: Build the library for both TFMs**

```bash
dotnet build src/ExceptionReporter.csproj
```

Expected: Build succeeded. Both `net48` and `net10.0-windows` output folders appear under `src/bin/Debug/`.

- [ ] **Step 4: Commit**

```bash
git add src/ExceptionReporter.csproj src/ReportGenerator.cs
git commit -m "feat: add net10.0-windows target to library"
```

---

## Task 4: Update `test/ExceptionReporter.Tests.csproj`

**Files:**
- Modify: `test/ExceptionReporter.Tests.csproj`

- [ ] **Step 1: Replace the entire file with the multi-target version**

Replace the full contents of `test/ExceptionReporter.Tests.csproj` with:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net48;net10.0-windows</TargetFrameworks>
    <UseWindowsForms>true</UseWindowsForms>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <PropertyGroup Condition="'$(TargetFramework)' == 'net48'">
    <ImportWindowsDesktopTargets>true</ImportWindowsDesktopTargets>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="AutoMoq" Version="2.0.0" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.12.0" />
    <PackageReference Include="Moq" Version="4.20.72" />
    <PackageReference Include="NUnit" Version="4.2.2" />
    <PackageReference Include="NUnit3TestAdapter" Version="4.6.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\src\ExceptionReporter.csproj" />
  </ItemGroup>

  <ItemGroup Condition="'$(TargetFramework)' == 'net48'">
    <Reference Include="System.Deployment" />
    <Reference Include="System.Management" />
  </ItemGroup>
</Project>
```

- [ ] **Step 2: Build tests for both TFMs**

```bash
dotnet build test/ExceptionReporter.Tests.csproj
```

Expected: Build succeeded for both `net48` and `net10.0-windows`.

- [ ] **Step 3: Run tests for both TFMs**

```bash
dotnet test test/ExceptionReporter.Tests.csproj
```

Expected: All tests pass. Output shows two test runs — one for `net48` and one for `net10.0-windows`.

- [ ] **Step 4: Commit**

```bash
git add test/ExceptionReporter.Tests.csproj
git commit -m "feat: add net10.0-windows target to tests"
```

---

## Task 5: Update `demo/ExceptionReporter.Demo.csproj`

**Files:**
- Modify: `demo/ExceptionReporter.Demo.csproj`

- [ ] **Step 1: Replace the entire file with the multi-target version**

Replace the full contents of `demo/ExceptionReporter.Demo.csproj` with:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFrameworks>net48;net10.0-windows</TargetFrameworks>
    <OutputType>WinExe</OutputType>
    <UseWindowsForms>true</UseWindowsForms>
    <RootNamespace>Demo.WinForms</RootNamespace>
    <GenerateResourceUsePreserializedResources>true</GenerateResourceUsePreserializedResources>
  </PropertyGroup>

  <PropertyGroup Condition="'$(TargetFramework)' == 'net48'">
    <ImportWindowsDesktopTargets>true</ImportWindowsDesktopTargets>
  </PropertyGroup>

  <ItemGroup>
    <EmbeddedResource Update="DemoAppView.resx">
      <SubType>Designer</SubType>
      <LastGenOutput>DemoAppView.Designer.cs</LastGenOutput>
      <Generator>ResXFileCodeGenerator</Generator>
    </EmbeddedResource>
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\src\ExceptionReporter.csproj" />
  </ItemGroup>

  <ItemGroup Condition="'$(TargetFramework)' == 'net48'">
    <Reference Include="System.Configuration" />
    <Reference Include="System.Management" />
  </ItemGroup>
</Project>
```

- [ ] **Step 2: Build demo for both TFMs**

```bash
dotnet build demo/ExceptionReporter.Demo.csproj
```

Expected: Build succeeded for both `net48` and `net10.0-windows`.

- [ ] **Step 3: Commit**

```bash
git add demo/ExceptionReporter.Demo.csproj
git commit -m "feat: add net10.0-windows target to demo"
```

---

## Task 6: Final verification

**Files:** none

- [ ] **Step 1: Full solution build (all projects, both TFMs)**

```bash
dotnet build
```

Expected: Build succeeded, 0 errors, 0 warnings about missing references.

- [ ] **Step 2: Full test run (both TFMs)**

```bash
dotnet test
```

Expected: All tests pass for both `net48` and `net10.0-windows`.

- [ ] **Step 3: Verify NuGet pack includes both TFMs**

```bash
dotnet pack src/ExceptionReporter.csproj -c Release --output ./artifacts
```

Then inspect the produced `.nupkg`:

```bash
# List the lib/ folder inside the nupkg (it's a zip)
dotnet tool run --tool-manifest dotnet-nuget-explorer 2>/dev/null || \
  unzip -l artifacts/ProExceptionReporter.*.nupkg | grep "^.*lib/"
```

Expected: Two `lib/` folders — `lib/net48/ProExceptionReporter.dll` and `lib/net10.0-windows/ProExceptionReporter.dll`.

> If the unzip command is unavailable on Windows, rename the `.nupkg` to `.zip` and open in Explorer, or use `Expand-Archive` in PowerShell.
