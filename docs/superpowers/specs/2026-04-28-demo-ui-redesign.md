# Demo App UI Redesign — Spec

**Date:** 2026-04-28  
**Branch:** demo  
**Scope:** `demo/` project only — library (`src/`) and tests (`test/`) are untouched.

---

## Goal

Replace the current minimal 3-link-label demo form with a rich interactive UI that exposes every `ExceptionReportInfo` configuration property via controls, ships with 5 named presets, and provides two distinct action buttons: one that fires the reporter with zero configuration (defaults) and one that applies all UI settings before firing.

---

## Layout

**Form size:** ~950 × 680 px, not resizable.  
**Layout:** `SplitContainer` — fixed splitter, not user-moveable.

| Panel | Width | Content |
|-------|-------|---------|
| Left  | ~580px | Scrollable `Panel` containing 5 `GroupBox` sections stacked vertically |
| Right | ~370px | Presets group (top) + action buttons (bottom) |

---

## Left Panel — Settings Groups

### 1. General
| Control | Property | Type |
|---------|----------|------|
| TitleText | `TitleText` | TextBox |
| CompanyName | `CompanyName` | TextBox |
| AppName | `AppName` | TextBox |
| UserName | `UserName` | TextBox |
| CustomMessage | `CustomMessage` | TextBox |
| UserExplanationLabel | `UserExplanationLabel` | TextBox |
| ExceptionDateKind | `ExceptionDateKind` | ComboBox (Local / Utc) |

### 2. Appearance
| Control | Property | Type |
|---------|----------|------|
| BackgroundColor | `BackgroundColor` | TextBox + small color preview Panel (click → `ColorDialog`) |
| UserExplanationFontSize | `UserExplanationFontSize` | NumericUpDown (6–72, decimal) |
| ShowFlatButtons | `ShowFlatButtons` | CheckBox |
| ShowButtonIcons | `ShowButtonIcons` | CheckBox |
| ShowLessDetailButton | `ShowLessDetailButton` | CheckBox |
| ShowFullDetail | `ShowFullDetail` | CheckBox |
| TopMost | `TopMost` | CheckBox |

### 3. Tabs
| Control | Property | Type |
|---------|----------|------|
| ShowGeneralTab | `ShowGeneralTab` | CheckBox |
| ShowExceptionsTab | `ShowExceptionsTab` | CheckBox |
| ShowSysInfoTab | `ShowSysInfoTab` | CheckBox |
| ShowAssembliesTab | `ShowAssembliesTab` | CheckBox |
| ShowEmailButton | `ShowEmailButton` | CheckBox |

### 4. Report
| Control | Property | Type |
|---------|----------|------|
| ReportTemplateFormat | `ReportTemplateFormat` | ComboBox (Text / Html / Markdown) |
| AttachmentFilename | `AttachmentFilename` | TextBox |
| TakeScreenshot | `TakeScreenshot` | CheckBox |

### 5. Send / Email
| Control | Property | Type |
|---------|----------|------|
| SendMethod | `SendMethod` | ComboBox (None / SimpleMAPI / SMTP / WebService) |
| EmailReportAddress | `EmailReportAddress` | TextBox |
| EmailReportSubject | `EmailReportSubject` | TextBox |
| WebServiceUrl | `WebServiceUrl` | TextBox — enabled only when SendMethod = WebService |
| SmtpServer | `SmtpServer` | TextBox — enabled only when SendMethod = SMTP |
| SmtpPort | `SmtpPort` | NumericUpDown (1–65535) — enabled only when SendMethod = SMTP |
| SmtpFromAddress | `SmtpFromAddress` | TextBox — enabled only when SendMethod = SMTP |
| SmtpUsername | `SmtpUsername` | TextBox — enabled only when SendMethod = SMTP |
| SmtpPassword | `SmtpPassword` | TextBox (PasswordChar = '●') — enabled only when SendMethod = SMTP |
| SmtpUseSsl | `SmtpUseSsl` | CheckBox — enabled only when SendMethod = SMTP |
| SmtpUseDefaultCredentials | `SmtpUseDefaultCredentials` | CheckBox — enabled only when SendMethod = SMTP |
| SmtpMailPriority | `SmtpMailPriority` | ComboBox (Normal / Low / High) — enabled only when SendMethod = SMTP |
| WebServiceTimeout | `WebServiceTimeout` | NumericUpDown (1–120, seconds) — enabled only when SendMethod = WebService |

`SendMethod` ComboBox `SelectedIndexChanged` triggers a helper `UpdateSendMethodFields()` that enables/disables the WebService and SMTP fields accordingly.

---

## Right Panel

### Presets (top group box)

Five buttons, each calls an `ApplyPreset_X()` method that sets control values directly. Presets do **not** trigger the reporter.

| Button | What it sets |
|--------|-------------|
| **Default** | Resets all controls to `ExceptionReportInfo` defaults: SendMethod=None, ReportTemplateFormat=Text, ExceptionDateKind=Utc, ShowGeneralTab=true, ShowExceptionsTab=true, ShowSysInfoTab=true, ShowAssembliesTab=true, ShowEmailButton=true, ShowFlatButtons=true, ShowLessDetailButton=false, ShowFullDetail=false, ShowButtonIcons=false, TakeScreenshot=false, TopMost=false, SmtpUseSsl=false, SmtpUseDefaultCredentials=false, SmtpMailPriority=Normal, UserExplanationFontSize=12, WebServiceTimeout=15, SmtpPort=25, all text fields cleared |
| **Email via SMTP** | SendMethod=SMTP, SmtpServer=`127.0.0.1`, SmtpPort=2500, SmtpFromAddress=`test@test.com`, EmailReportAddress=`support@support.com`, SmtpUseSsl=false |
| **Send via WebService** | SendMethod=WebService, WebServiceUrl=`http://localhost:24513/api/er` |
| **Minimal UI** | ShowGeneralTab=false, ShowSysInfoTab=false, ShowAssembliesTab=false, ShowEmailButton=false, ShowLessDetailButton=false, ShowFullDetail=false, ShowButtonIcons=false |
| **Full Detail** | ShowFullDetail=true, ShowLessDetailButton=true, ShowButtonIcons=true, all tabs=true, TitleText=`"Acme Error Report"`, CompanyName=`"Acme"`, SendMethod=SimpleMAPI, EmailReportAddress=`support@acme.com` |

### Action Buttons (bottom, large)

**"Show Default"**
- Creates `new ExceptionReporter()` with no config applied.
- Calls `er.Show(exception)`.
- A small italic label below reads: *"Ignores all settings above — shows out-of-the-box defaults"*

**"Show with Settings"**
- Creates `new ExceptionReporter()`.
- Reads every UI control and maps to `er.Config.*`.
- Calls `er.Show(exception)`.

Both buttons reuse the existing `SomeMethodThatThrows()` → `CallAnotherMethod()` → `AndAnotherOne()` chain to produce the exception.

---

## File Changes

| File | Change |
|------|--------|
| `demo/DemoApp.cs` | Full replacement — new split-panel form, same class name |
| `demo/DemoAppView.designer.cs` | Full replacement — new designer output |
| `demo/DemoAppView.resx` | No change |
| `demo/YourCustomReporterView.cs` | No change |
| `demo/YourCustomViewMaker.cs` | No change |
| `demo/Program.cs` | No change |

No new files. `UseCustomReportView()` is kept as a private, unwired method.

---

## Out of Scope

- `FilesToAttach` — not exposed in UI (requires file picker, adds complexity not central to the demo).
- `AppAssembly` — set automatically by `ReportGenerator`; not useful to override in a demo.
- `AppVersion` / `AppVersionType` / `RegionInfo` / `ExceptionDate` / `UserExplanation` — auto-populated at runtime; no value in exposing them as demo controls.
- Sending the silent report (the old "Send Report (no dialog show)" link) — removed; out of scope for this settings-focused demo.
- `ReportCustomTemplate` — advanced use; omitted to keep the UI focused.
- Library (`src/`) and tests (`test/`) — no changes.
