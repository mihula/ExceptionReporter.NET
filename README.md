# ProExceptionReporter

> Fork of [PandaWood/ExceptionReporter.NET](https://github.com/PandaWood/ExceptionReporter.NET) — this fork removes WPF support (WinForms only), removes pt-BR/ru localisations (English only), and replaces ProDotNetZip with the built-in `System.IO.Compression`. NuGet package is published as `ProExceptionReporter`; migrating from the original `ExceptionReporter` package requires only a package reference swap — namespaces remain `ExceptionReporting.*`.

[![NuGet Badge](https://buildstats.info/nuget/ProExceptionReporter)](https://www.nuget.org/packages/ProExceptionReporter/)
[![CI](https://github.com/mihula/ProExceptionReporter/actions/workflows/ci.yml/badge.svg)](https://github.com/mihula/ProExceptionReporter/actions/workflows/ci.yml)

```
PM> Install-Package ProExceptionReporter
```

## How it Looks

When showing a dialog to the user (can also be sent silently) there are
 2 presentation *modes* - *Less Scary* and *More Detail*

#### **Less Scary**
![Compact Mode](images/er2-less-detail.png)

#### **More Detail**
![More Detail Mode](images/er-customized.png)

### Interface Configuration
You don't have to modify the code to achieve a basic level of customization as many changes can be made with *configuration*. 

The screenshot above is configured to not show icons on the buttons 
(`ShowButtonIcons`) and the window title is customised (`TitleText`)

There are various other options available such hiding the email button (`ShowEmailButton`), changing
 the label text (`UserExplanationLabel`), the background color (`BackgroundColor`) 
 etc - see the property  `Config` on the main `ExceptionReporter` class.

## How to use it

The Exception Reporter can be invoked manually or by setting up a Windows 
Exception event - 
see [Sample Code Usage](https://github.com/PandaWood/Exception-Reporter/wiki/Sample-Usage)

The ultimate goal is the developer receiving a formatted exception report - see
[Sending a Report](https://github.com/PandaWood/Exception-Reporter/wiki/Sending-a-Report)

You can even format your own report using [Report Templates](https://github.com/PandaWood/Exception-Reporter/wiki/Report-Templates)

## Why use it
### Some Important Features

- Option to send a report silently and asynchronously - ie without showing a dialog
- Send a report using various methods:
  - RESTful API/WebService
  - to Email address via SMTP 
  - to Email address via installed client (SimpleMAPI)
 - Emailing includes support for automatically attaching files and compressing 
 into a single zip file - useful for including log files and configuration files to help with troubleshooting
- The report sent to the developer can be in various formats:
  - Plain Text 
  - HTML
  - Markdown
  - Custom - write your own Handlebars/Mustache template to create the report
- The report includes various useful information such as:
  - **Full Stack Trace** (including inner exceptions and multiple exceptions)
  - **System Information** (using WMI) such as OS Version, Memory, Language, TimeZone etc. 
  - A list of **Referenced Assemblies** (with versions) being used by the current executable
  - **Details of your App** such as name/version/date/time etc

### Demos, Design and Testing
- The solution includes a WinForms demo app (`demo/`) for testing the dialog
- The source code has over 70 unit tests covering most of the important code
- ExceptionReporter is designed using the [MVP or Model-View-Presenter](https://medium.com/@prajvalprabhakar/mvp-vs-mvvm-93657494106b) pattern and the classes and concerns are liberally separated using [SOLID](https://stackify.com/solid-design-principles/) design principles

## Sample Reports

### Markdown
![Markdown](images/er-markdown.png)

### Plain Text
```text
========================================
Acme Error Report

Application: ExceptionReporter Demo App
Version:     4.0
Region:      English (Australia)
Date: 25/08/2018
Time: 2:40 PM
User Explanation: "I just pressed Connect and this error showed immediately"

Error Message: Unable to establish a connection with the Foo bank account service
 
[Stack Traces]
Top-level Exception
Type:        System.IO.IOException
Message:     Unable to establish a connection with the Foo bank account service. The error number is #FFF474678.
Source:      WinFormsDemoApp
Stack Trace: at WinFormsDemoApp.DemoAppView.AndAnotherOne() in Z:\MyProjects\ExceptionReporter\src\WinFormsDemoApp\DemoAppView.cs:line 110
    at WinFormsDemoApp.DemoAppView.CallAnotherMethod() in Z:\MyProjects\ExceptionReporter\src\WinFormsDemoApp\DemoAppView.cs:line 101
    at WinFormsDemoApp.DemoAppView.SomeMethod() in Z:\MyProjects\ExceptionReporter\src\WinFormsDemoApp\DemoAppView.cs:line 96
    at WinFormsDemoApp.DemoAppView.ShowExceptionReporter(Boolean useConfig) in Z:\MyProjects\ExceptionReporter\src\WinFormsDemoApp\DemoAppView.cs:line 81

Inner Exception 1
Type:        System.Exception
Message:     This is an Inner Exception message - with a message that is not too small but perhaps it should be smaller

[Assembly References] 
mscorlib, Version=2.0.0.0
System.Windows.Forms, Version=2.0.0.0
System, Version=2.0.0.0
ProExceptionReporter, Version=6.0.0.0
System.Drawing, Version=2.0.0.0

[System Info]
Operating System
-Microsoft Windows 7 Enterprise
--CodeSet = 1252
--CSDVersion =
--CurrentTimeZone = 600
--FreePhysicalMemory = 1947848
--OSArchitecture = 32-bit
--OSLanguage = 1033
--ServicePackMajorVersion = 0
--ServicePackMinorVersion = 0
--Version = 6.1.7600

[Machine]
--Manufacturer = Gigabyte Technology Co., Ltd.
--Model = P35-DS3L
--TotalPhysicalMemory = 3756515328

========================================
```

## Build

Requires .NET SDK 10. Targets `net48` and `net10.0-windows` (Windows only).

```bash
dotnet build test/ExceptionReporter.Tests.csproj
dotnet test test/ExceptionReporter.Tests.csproj
dotnet pack src/ExceptionReporter.csproj -c Release --output ./artifacts
```

### Solution Structure

```
src/   — ProExceptionReporter library (NuGet, net48 + net10.0-windows)
test/  — unit tests (NUnit + Moq)
demo/  — WinForms demo application
```

Unit tests use [Moq](https://github.com/Moq/moq4/wiki/Quickstart) and [NUnit](https://nunit.org/) — see `test/`.

## Releasing

Releases are published automatically via GitHub Actions when a `v*` tag is pushed to `main`:

```bash
git tag v6.1.0
git push origin v6.1.0
```

The pipeline builds, tests, and publishes to [NuGet.org](https://www.nuget.org/packages/ProExceptionReporter/) and GitHub Packages. CI runs on every push to `main` and every PR.

Requires `NUGET_API_KEY` secret configured in repo Settings → Secrets → Actions.
