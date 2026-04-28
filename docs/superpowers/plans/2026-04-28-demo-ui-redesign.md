# Demo App UI Redesign Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Replace the current minimal 3-link-label demo form with a rich split-panel UI exposing all `ExceptionReportInfo` config properties, 5 named presets, and two action buttons (Show Default / Show with Settings).

**Architecture:** Two-file full replacement — `demo/DemoAppView.designer.cs` (50+ controls, SplitContainer layout, scrollable left panel with 5 GroupBoxes, right panel with presets + actions) and `demo/DemoApp.cs` (constructor, `UpdateSendMethodFields`, 5 preset methods, `ShowDefault`, `ShowWithSettings`). No changes to `src/` or `test/`.

**Tech Stack:** C# / WinForms, net48 + net10.0-windows, `System.Net.Mail.MailPriority`, `System.Drawing.ColorTranslator`, ExceptionReporting (ProjectReference)

---

### Task 1: Write new `DemoAppView.designer.cs`

> ⚠️ After this task alone the build is temporarily broken — the old `DemoApp.cs` still references removed fields. Build is verified in Task 3, after Task 2 replaces `DemoApp.cs`.

**Files:**
- Modify: `demo/DemoAppView.designer.cs` (full replacement)

- [ ] **Step 1: Replace entire contents of `demo/DemoAppView.designer.cs`**

```csharp
namespace Demo.WinForms
{
    partial class DemoApp
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.lblTitleText = new System.Windows.Forms.Label();
            this.txtTitleText = new System.Windows.Forms.TextBox();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblAppName = new System.Windows.Forms.Label();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblCustomMessage = new System.Windows.Forms.Label();
            this.txtCustomMessage = new System.Windows.Forms.TextBox();
            this.lblUserExplanationLabel = new System.Windows.Forms.Label();
            this.txtUserExplanationLabel = new System.Windows.Forms.TextBox();
            this.lblExceptionDateKind = new System.Windows.Forms.Label();
            this.cboExceptionDateKind = new System.Windows.Forms.ComboBox();
            this.grpAppearance = new System.Windows.Forms.GroupBox();
            this.lblBackgroundColor = new System.Windows.Forms.Label();
            this.txtBackgroundColor = new System.Windows.Forms.TextBox();
            this.pnlColorPreview = new System.Windows.Forms.Panel();
            this.lblUserExplanationFontSize = new System.Windows.Forms.Label();
            this.nudUserExplanationFontSize = new System.Windows.Forms.NumericUpDown();
            this.chkShowFlatButtons = new System.Windows.Forms.CheckBox();
            this.chkShowButtonIcons = new System.Windows.Forms.CheckBox();
            this.chkShowLessDetailButton = new System.Windows.Forms.CheckBox();
            this.chkShowFullDetail = new System.Windows.Forms.CheckBox();
            this.chkTopMost = new System.Windows.Forms.CheckBox();
            this.grpTabs = new System.Windows.Forms.GroupBox();
            this.chkShowGeneralTab = new System.Windows.Forms.CheckBox();
            this.chkShowExceptionsTab = new System.Windows.Forms.CheckBox();
            this.chkShowSysInfoTab = new System.Windows.Forms.CheckBox();
            this.chkShowAssembliesTab = new System.Windows.Forms.CheckBox();
            this.chkShowEmailButton = new System.Windows.Forms.CheckBox();
            this.grpReport = new System.Windows.Forms.GroupBox();
            this.lblReportTemplateFormat = new System.Windows.Forms.Label();
            this.cboReportTemplateFormat = new System.Windows.Forms.ComboBox();
            this.lblAttachmentFilename = new System.Windows.Forms.Label();
            this.txtAttachmentFilename = new System.Windows.Forms.TextBox();
            this.chkTakeScreenshot = new System.Windows.Forms.CheckBox();
            this.grpSendEmail = new System.Windows.Forms.GroupBox();
            this.lblSendMethod = new System.Windows.Forms.Label();
            this.cboSendMethod = new System.Windows.Forms.ComboBox();
            this.lblEmailReportAddress = new System.Windows.Forms.Label();
            this.txtEmailReportAddress = new System.Windows.Forms.TextBox();
            this.lblEmailReportSubject = new System.Windows.Forms.Label();
            this.txtEmailReportSubject = new System.Windows.Forms.TextBox();
            this.lblWebServiceUrl = new System.Windows.Forms.Label();
            this.txtWebServiceUrl = new System.Windows.Forms.TextBox();
            this.lblSmtpServer = new System.Windows.Forms.Label();
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.lblSmtpPort = new System.Windows.Forms.Label();
            this.nudSmtpPort = new System.Windows.Forms.NumericUpDown();
            this.lblSmtpFromAddress = new System.Windows.Forms.Label();
            this.txtSmtpFromAddress = new System.Windows.Forms.TextBox();
            this.lblSmtpUsername = new System.Windows.Forms.Label();
            this.txtSmtpUsername = new System.Windows.Forms.TextBox();
            this.lblSmtpPassword = new System.Windows.Forms.Label();
            this.txtSmtpPassword = new System.Windows.Forms.TextBox();
            this.chkSmtpUseSsl = new System.Windows.Forms.CheckBox();
            this.chkSmtpUseDefaultCredentials = new System.Windows.Forms.CheckBox();
            this.lblSmtpMailPriority = new System.Windows.Forms.Label();
            this.cboSmtpMailPriority = new System.Windows.Forms.ComboBox();
            this.lblWebServiceTimeout = new System.Windows.Forms.Label();
            this.nudWebServiceTimeout = new System.Windows.Forms.NumericUpDown();
            this.grpPresets = new System.Windows.Forms.GroupBox();
            this.btnPresetDefault = new System.Windows.Forms.Button();
            this.btnPresetEmailSMTP = new System.Windows.Forms.Button();
            this.btnPresetWebService = new System.Windows.Forms.Button();
            this.btnPresetMinimalUI = new System.Windows.Forms.Button();
            this.btnPresetFullDetail = new System.Windows.Forms.Button();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnShowDefault = new System.Windows.Forms.Button();
            this.lblShowDefaultHint = new System.Windows.Forms.Label();
            this.btnShowWithSettings = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.nudUserExplanationFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWebServiceTimeout)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.scrollPanel.SuspendLayout();
            this.grpGeneral.SuspendLayout();
            this.grpAppearance.SuspendLayout();
            this.grpTabs.SuspendLayout();
            this.grpReport.SuspendLayout();
            this.grpSendEmail.SuspendLayout();
            this.grpPresets.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();

            // splitContainer
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new System.Drawing.Size(950, 652);
            this.splitContainer.SplitterDistance = 580;
            this.splitContainer.TabIndex = 0;
            this.splitContainer.Panel1.Controls.Add(this.scrollPanel);
            this.splitContainer.Panel2.Controls.Add(this.grpActions);
            this.splitContainer.Panel2.Controls.Add(this.grpPresets);

            // scrollPanel
            this.scrollPanel.AutoScroll = true;
            this.scrollPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollPanel.Name = "scrollPanel";
            this.scrollPanel.Controls.Add(this.grpSendEmail);
            this.scrollPanel.Controls.Add(this.grpReport);
            this.scrollPanel.Controls.Add(this.grpTabs);
            this.scrollPanel.Controls.Add(this.grpAppearance);
            this.scrollPanel.Controls.Add(this.grpGeneral);

            // grpGeneral
            this.grpGeneral.Controls.Add(this.cboExceptionDateKind);
            this.grpGeneral.Controls.Add(this.lblExceptionDateKind);
            this.grpGeneral.Controls.Add(this.txtUserExplanationLabel);
            this.grpGeneral.Controls.Add(this.lblUserExplanationLabel);
            this.grpGeneral.Controls.Add(this.txtCustomMessage);
            this.grpGeneral.Controls.Add(this.lblCustomMessage);
            this.grpGeneral.Controls.Add(this.txtUserName);
            this.grpGeneral.Controls.Add(this.lblUserName);
            this.grpGeneral.Controls.Add(this.txtAppName);
            this.grpGeneral.Controls.Add(this.lblAppName);
            this.grpGeneral.Controls.Add(this.txtCompanyName);
            this.grpGeneral.Controls.Add(this.lblCompanyName);
            this.grpGeneral.Controls.Add(this.txtTitleText);
            this.grpGeneral.Controls.Add(this.lblTitleText);
            this.grpGeneral.Location = new System.Drawing.Point(5, 5);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Size = new System.Drawing.Size(550, 230);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.Text = "General";

            this.lblTitleText.AutoSize = true;
            this.lblTitleText.Location = new System.Drawing.Point(10, 24);
            this.lblTitleText.Name = "lblTitleText";
            this.lblTitleText.Text = "TitleText:";

            this.txtTitleText.Location = new System.Drawing.Point(160, 21);
            this.txtTitleText.Name = "txtTitleText";
            this.txtTitleText.Size = new System.Drawing.Size(375, 22);
            this.txtTitleText.TabIndex = 1;

            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(10, 50);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Text = "CompanyName:";

            this.txtCompanyName.Location = new System.Drawing.Point(160, 47);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(375, 22);
            this.txtCompanyName.TabIndex = 2;

            this.lblAppName.AutoSize = true;
            this.lblAppName.Location = new System.Drawing.Point(10, 76);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Text = "AppName:";

            this.txtAppName.Location = new System.Drawing.Point(160, 73);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(375, 22);
            this.txtAppName.TabIndex = 3;

            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(10, 102);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Text = "UserName:";

            this.txtUserName.Location = new System.Drawing.Point(160, 99);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(375, 22);
            this.txtUserName.TabIndex = 4;

            this.lblCustomMessage.AutoSize = true;
            this.lblCustomMessage.Location = new System.Drawing.Point(10, 128);
            this.lblCustomMessage.Name = "lblCustomMessage";
            this.lblCustomMessage.Text = "CustomMessage:";

            this.txtCustomMessage.Location = new System.Drawing.Point(160, 125);
            this.txtCustomMessage.Name = "txtCustomMessage";
            this.txtCustomMessage.Size = new System.Drawing.Size(375, 22);
            this.txtCustomMessage.TabIndex = 5;

            this.lblUserExplanationLabel.AutoSize = true;
            this.lblUserExplanationLabel.Location = new System.Drawing.Point(10, 154);
            this.lblUserExplanationLabel.Name = "lblUserExplanationLabel";
            this.lblUserExplanationLabel.Text = "UserExplanationLabel:";

            this.txtUserExplanationLabel.Location = new System.Drawing.Point(160, 151);
            this.txtUserExplanationLabel.Name = "txtUserExplanationLabel";
            this.txtUserExplanationLabel.Size = new System.Drawing.Size(375, 22);
            this.txtUserExplanationLabel.TabIndex = 6;

            this.lblExceptionDateKind.AutoSize = true;
            this.lblExceptionDateKind.Location = new System.Drawing.Point(10, 180);
            this.lblExceptionDateKind.Name = "lblExceptionDateKind";
            this.lblExceptionDateKind.Text = "ExceptionDateKind:";

            this.cboExceptionDateKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExceptionDateKind.Items.AddRange(new object[] { "Local", "Utc" });
            this.cboExceptionDateKind.Location = new System.Drawing.Point(160, 177);
            this.cboExceptionDateKind.Name = "cboExceptionDateKind";
            this.cboExceptionDateKind.Size = new System.Drawing.Size(150, 22);
            this.cboExceptionDateKind.TabIndex = 7;

            // grpAppearance
            this.grpAppearance.Controls.Add(this.chkTopMost);
            this.grpAppearance.Controls.Add(this.chkShowFullDetail);
            this.grpAppearance.Controls.Add(this.chkShowLessDetailButton);
            this.grpAppearance.Controls.Add(this.chkShowButtonIcons);
            this.grpAppearance.Controls.Add(this.chkShowFlatButtons);
            this.grpAppearance.Controls.Add(this.nudUserExplanationFontSize);
            this.grpAppearance.Controls.Add(this.lblUserExplanationFontSize);
            this.grpAppearance.Controls.Add(this.pnlColorPreview);
            this.grpAppearance.Controls.Add(this.txtBackgroundColor);
            this.grpAppearance.Controls.Add(this.lblBackgroundColor);
            this.grpAppearance.Location = new System.Drawing.Point(5, 245);
            this.grpAppearance.Name = "grpAppearance";
            this.grpAppearance.Size = new System.Drawing.Size(550, 210);
            this.grpAppearance.TabIndex = 1;
            this.grpAppearance.Text = "Appearance";

            this.lblBackgroundColor.AutoSize = true;
            this.lblBackgroundColor.Location = new System.Drawing.Point(10, 24);
            this.lblBackgroundColor.Name = "lblBackgroundColor";
            this.lblBackgroundColor.Text = "BackgroundColor:";

            this.txtBackgroundColor.Location = new System.Drawing.Point(160, 21);
            this.txtBackgroundColor.Name = "txtBackgroundColor";
            this.txtBackgroundColor.Size = new System.Drawing.Size(120, 22);
            this.txtBackgroundColor.TabIndex = 1;

            this.pnlColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColorPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlColorPreview.Location = new System.Drawing.Point(286, 21);
            this.pnlColorPreview.Name = "pnlColorPreview";
            this.pnlColorPreview.Size = new System.Drawing.Size(28, 22);

            this.lblUserExplanationFontSize.AutoSize = true;
            this.lblUserExplanationFontSize.Location = new System.Drawing.Point(10, 52);
            this.lblUserExplanationFontSize.Name = "lblUserExplanationFontSize";
            this.lblUserExplanationFontSize.Text = "UserExplanationFontSize:";

            this.nudUserExplanationFontSize.Location = new System.Drawing.Point(160, 49);
            this.nudUserExplanationFontSize.Minimum = new decimal(new int[] { 6, 0, 0, 0 });
            this.nudUserExplanationFontSize.Maximum = new decimal(new int[] { 72, 0, 0, 0 });
            this.nudUserExplanationFontSize.Name = "nudUserExplanationFontSize";
            this.nudUserExplanationFontSize.Size = new System.Drawing.Size(70, 22);
            this.nudUserExplanationFontSize.TabIndex = 2;
            this.nudUserExplanationFontSize.Value = new decimal(new int[] { 12, 0, 0, 0 });

            this.chkShowFlatButtons.AutoSize = true;
            this.chkShowFlatButtons.Location = new System.Drawing.Point(10, 78);
            this.chkShowFlatButtons.Name = "chkShowFlatButtons";
            this.chkShowFlatButtons.Size = new System.Drawing.Size(120, 17);
            this.chkShowFlatButtons.TabIndex = 3;
            this.chkShowFlatButtons.Text = "ShowFlatButtons";

            this.chkShowButtonIcons.AutoSize = true;
            this.chkShowButtonIcons.Location = new System.Drawing.Point(10, 102);
            this.chkShowButtonIcons.Name = "chkShowButtonIcons";
            this.chkShowButtonIcons.Size = new System.Drawing.Size(120, 17);
            this.chkShowButtonIcons.TabIndex = 4;
            this.chkShowButtonIcons.Text = "ShowButtonIcons";

            this.chkShowLessDetailButton.AutoSize = true;
            this.chkShowLessDetailButton.Location = new System.Drawing.Point(10, 126);
            this.chkShowLessDetailButton.Name = "chkShowLessDetailButton";
            this.chkShowLessDetailButton.Size = new System.Drawing.Size(150, 17);
            this.chkShowLessDetailButton.TabIndex = 5;
            this.chkShowLessDetailButton.Text = "ShowLessDetailButton";

            this.chkShowFullDetail.AutoSize = true;
            this.chkShowFullDetail.Location = new System.Drawing.Point(10, 150);
            this.chkShowFullDetail.Name = "chkShowFullDetail";
            this.chkShowFullDetail.Size = new System.Drawing.Size(100, 17);
            this.chkShowFullDetail.TabIndex = 6;
            this.chkShowFullDetail.Text = "ShowFullDetail";

            this.chkTopMost.AutoSize = true;
            this.chkTopMost.Location = new System.Drawing.Point(10, 174);
            this.chkTopMost.Name = "chkTopMost";
            this.chkTopMost.Size = new System.Drawing.Size(75, 17);
            this.chkTopMost.TabIndex = 7;
            this.chkTopMost.Text = "TopMost";

            // grpTabs
            this.grpTabs.Controls.Add(this.chkShowEmailButton);
            this.grpTabs.Controls.Add(this.chkShowAssembliesTab);
            this.grpTabs.Controls.Add(this.chkShowSysInfoTab);
            this.grpTabs.Controls.Add(this.chkShowExceptionsTab);
            this.grpTabs.Controls.Add(this.chkShowGeneralTab);
            this.grpTabs.Location = new System.Drawing.Point(5, 465);
            this.grpTabs.Name = "grpTabs";
            this.grpTabs.Size = new System.Drawing.Size(550, 160);
            this.grpTabs.TabIndex = 2;
            this.grpTabs.Text = "Tabs";

            this.chkShowGeneralTab.AutoSize = true;
            this.chkShowGeneralTab.Location = new System.Drawing.Point(10, 22);
            this.chkShowGeneralTab.Name = "chkShowGeneralTab";
            this.chkShowGeneralTab.TabIndex = 1;
            this.chkShowGeneralTab.Text = "ShowGeneralTab";

            this.chkShowExceptionsTab.AutoSize = true;
            this.chkShowExceptionsTab.Location = new System.Drawing.Point(10, 46);
            this.chkShowExceptionsTab.Name = "chkShowExceptionsTab";
            this.chkShowExceptionsTab.TabIndex = 2;
            this.chkShowExceptionsTab.Text = "ShowExceptionsTab";

            this.chkShowSysInfoTab.AutoSize = true;
            this.chkShowSysInfoTab.Location = new System.Drawing.Point(10, 70);
            this.chkShowSysInfoTab.Name = "chkShowSysInfoTab";
            this.chkShowSysInfoTab.TabIndex = 3;
            this.chkShowSysInfoTab.Text = "ShowSysInfoTab";

            this.chkShowAssembliesTab.AutoSize = true;
            this.chkShowAssembliesTab.Location = new System.Drawing.Point(10, 94);
            this.chkShowAssembliesTab.Name = "chkShowAssembliesTab";
            this.chkShowAssembliesTab.TabIndex = 4;
            this.chkShowAssembliesTab.Text = "ShowAssembliesTab";

            this.chkShowEmailButton.AutoSize = true;
            this.chkShowEmailButton.Location = new System.Drawing.Point(10, 118);
            this.chkShowEmailButton.Name = "chkShowEmailButton";
            this.chkShowEmailButton.TabIndex = 5;
            this.chkShowEmailButton.Text = "ShowEmailButton";

            // grpReport
            this.grpReport.Controls.Add(this.chkTakeScreenshot);
            this.grpReport.Controls.Add(this.txtAttachmentFilename);
            this.grpReport.Controls.Add(this.lblAttachmentFilename);
            this.grpReport.Controls.Add(this.cboReportTemplateFormat);
            this.grpReport.Controls.Add(this.lblReportTemplateFormat);
            this.grpReport.Location = new System.Drawing.Point(5, 635);
            this.grpReport.Name = "grpReport";
            this.grpReport.Size = new System.Drawing.Size(550, 115);
            this.grpReport.TabIndex = 3;
            this.grpReport.Text = "Report";

            this.lblReportTemplateFormat.AutoSize = true;
            this.lblReportTemplateFormat.Location = new System.Drawing.Point(10, 24);
            this.lblReportTemplateFormat.Name = "lblReportTemplateFormat";
            this.lblReportTemplateFormat.Text = "ReportTemplateFormat:";

            this.cboReportTemplateFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportTemplateFormat.Items.AddRange(new object[] { "Text", "Html", "Markdown" });
            this.cboReportTemplateFormat.Location = new System.Drawing.Point(160, 21);
            this.cboReportTemplateFormat.Name = "cboReportTemplateFormat";
            this.cboReportTemplateFormat.Size = new System.Drawing.Size(150, 22);
            this.cboReportTemplateFormat.TabIndex = 1;

            this.lblAttachmentFilename.AutoSize = true;
            this.lblAttachmentFilename.Location = new System.Drawing.Point(10, 52);
            this.lblAttachmentFilename.Name = "lblAttachmentFilename";
            this.lblAttachmentFilename.Text = "AttachmentFilename:";

            this.txtAttachmentFilename.Location = new System.Drawing.Point(160, 49);
            this.txtAttachmentFilename.Name = "txtAttachmentFilename";
            this.txtAttachmentFilename.Size = new System.Drawing.Size(375, 22);
            this.txtAttachmentFilename.TabIndex = 2;

            this.chkTakeScreenshot.AutoSize = true;
            this.chkTakeScreenshot.Location = new System.Drawing.Point(10, 78);
            this.chkTakeScreenshot.Name = "chkTakeScreenshot";
            this.chkTakeScreenshot.TabIndex = 3;
            this.chkTakeScreenshot.Text = "TakeScreenshot";

            // grpSendEmail
            this.grpSendEmail.Controls.Add(this.nudWebServiceTimeout);
            this.grpSendEmail.Controls.Add(this.lblWebServiceTimeout);
            this.grpSendEmail.Controls.Add(this.cboSmtpMailPriority);
            this.grpSendEmail.Controls.Add(this.lblSmtpMailPriority);
            this.grpSendEmail.Controls.Add(this.chkSmtpUseDefaultCredentials);
            this.grpSendEmail.Controls.Add(this.chkSmtpUseSsl);
            this.grpSendEmail.Controls.Add(this.txtSmtpPassword);
            this.grpSendEmail.Controls.Add(this.lblSmtpPassword);
            this.grpSendEmail.Controls.Add(this.txtSmtpUsername);
            this.grpSendEmail.Controls.Add(this.lblSmtpUsername);
            this.grpSendEmail.Controls.Add(this.txtSmtpFromAddress);
            this.grpSendEmail.Controls.Add(this.lblSmtpFromAddress);
            this.grpSendEmail.Controls.Add(this.nudSmtpPort);
            this.grpSendEmail.Controls.Add(this.lblSmtpPort);
            this.grpSendEmail.Controls.Add(this.txtSmtpServer);
            this.grpSendEmail.Controls.Add(this.lblSmtpServer);
            this.grpSendEmail.Controls.Add(this.txtWebServiceUrl);
            this.grpSendEmail.Controls.Add(this.lblWebServiceUrl);
            this.grpSendEmail.Controls.Add(this.txtEmailReportSubject);
            this.grpSendEmail.Controls.Add(this.lblEmailReportSubject);
            this.grpSendEmail.Controls.Add(this.txtEmailReportAddress);
            this.grpSendEmail.Controls.Add(this.lblEmailReportAddress);
            this.grpSendEmail.Controls.Add(this.cboSendMethod);
            this.grpSendEmail.Controls.Add(this.lblSendMethod);
            this.grpSendEmail.Location = new System.Drawing.Point(5, 760);
            this.grpSendEmail.Name = "grpSendEmail";
            this.grpSendEmail.Size = new System.Drawing.Size(550, 375);
            this.grpSendEmail.TabIndex = 4;
            this.grpSendEmail.Text = "Send / Email";

            this.lblSendMethod.AutoSize = true;
            this.lblSendMethod.Location = new System.Drawing.Point(10, 24);
            this.lblSendMethod.Name = "lblSendMethod";
            this.lblSendMethod.Text = "SendMethod:";

            this.cboSendMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSendMethod.Items.AddRange(new object[] { "None", "SimpleMAPI", "SMTP", "WebService" });
            this.cboSendMethod.Location = new System.Drawing.Point(160, 21);
            this.cboSendMethod.Name = "cboSendMethod";
            this.cboSendMethod.Size = new System.Drawing.Size(150, 22);
            this.cboSendMethod.TabIndex = 1;

            this.lblEmailReportAddress.AutoSize = true;
            this.lblEmailReportAddress.Location = new System.Drawing.Point(10, 52);
            this.lblEmailReportAddress.Name = "lblEmailReportAddress";
            this.lblEmailReportAddress.Text = "EmailReportAddress:";

            this.txtEmailReportAddress.Location = new System.Drawing.Point(160, 49);
            this.txtEmailReportAddress.Name = "txtEmailReportAddress";
            this.txtEmailReportAddress.Size = new System.Drawing.Size(375, 22);
            this.txtEmailReportAddress.TabIndex = 2;

            this.lblEmailReportSubject.AutoSize = true;
            this.lblEmailReportSubject.Location = new System.Drawing.Point(10, 80);
            this.lblEmailReportSubject.Name = "lblEmailReportSubject";
            this.lblEmailReportSubject.Text = "EmailReportSubject:";

            this.txtEmailReportSubject.Location = new System.Drawing.Point(160, 77);
            this.txtEmailReportSubject.Name = "txtEmailReportSubject";
            this.txtEmailReportSubject.Size = new System.Drawing.Size(375, 22);
            this.txtEmailReportSubject.TabIndex = 3;

            this.lblWebServiceUrl.AutoSize = true;
            this.lblWebServiceUrl.Location = new System.Drawing.Point(10, 108);
            this.lblWebServiceUrl.Name = "lblWebServiceUrl";
            this.lblWebServiceUrl.Text = "WebServiceUrl:";

            this.txtWebServiceUrl.Location = new System.Drawing.Point(160, 105);
            this.txtWebServiceUrl.Name = "txtWebServiceUrl";
            this.txtWebServiceUrl.Size = new System.Drawing.Size(375, 22);
            this.txtWebServiceUrl.TabIndex = 4;

            this.lblSmtpServer.AutoSize = true;
            this.lblSmtpServer.Location = new System.Drawing.Point(10, 136);
            this.lblSmtpServer.Name = "lblSmtpServer";
            this.lblSmtpServer.Text = "SmtpServer:";

            this.txtSmtpServer.Location = new System.Drawing.Point(160, 133);
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.Size = new System.Drawing.Size(375, 22);
            this.txtSmtpServer.TabIndex = 5;

            this.lblSmtpPort.AutoSize = true;
            this.lblSmtpPort.Location = new System.Drawing.Point(10, 164);
            this.lblSmtpPort.Name = "lblSmtpPort";
            this.lblSmtpPort.Text = "SmtpPort:";

            this.nudSmtpPort.Location = new System.Drawing.Point(160, 161);
            this.nudSmtpPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSmtpPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.nudSmtpPort.Name = "nudSmtpPort";
            this.nudSmtpPort.Size = new System.Drawing.Size(80, 22);
            this.nudSmtpPort.TabIndex = 6;
            this.nudSmtpPort.Value = new decimal(new int[] { 25, 0, 0, 0 });

            this.lblSmtpFromAddress.AutoSize = true;
            this.lblSmtpFromAddress.Location = new System.Drawing.Point(10, 192);
            this.lblSmtpFromAddress.Name = "lblSmtpFromAddress";
            this.lblSmtpFromAddress.Text = "SmtpFromAddress:";

            this.txtSmtpFromAddress.Location = new System.Drawing.Point(160, 189);
            this.txtSmtpFromAddress.Name = "txtSmtpFromAddress";
            this.txtSmtpFromAddress.Size = new System.Drawing.Size(375, 22);
            this.txtSmtpFromAddress.TabIndex = 7;

            this.lblSmtpUsername.AutoSize = true;
            this.lblSmtpUsername.Location = new System.Drawing.Point(10, 220);
            this.lblSmtpUsername.Name = "lblSmtpUsername";
            this.lblSmtpUsername.Text = "SmtpUsername:";

            this.txtSmtpUsername.Location = new System.Drawing.Point(160, 217);
            this.txtSmtpUsername.Name = "txtSmtpUsername";
            this.txtSmtpUsername.Size = new System.Drawing.Size(375, 22);
            this.txtSmtpUsername.TabIndex = 8;

            this.lblSmtpPassword.AutoSize = true;
            this.lblSmtpPassword.Location = new System.Drawing.Point(10, 248);
            this.lblSmtpPassword.Name = "lblSmtpPassword";
            this.lblSmtpPassword.Text = "SmtpPassword:";

            this.txtSmtpPassword.Location = new System.Drawing.Point(160, 245);
            this.txtSmtpPassword.Name = "txtSmtpPassword";
            this.txtSmtpPassword.PasswordChar = '●';
            this.txtSmtpPassword.Size = new System.Drawing.Size(375, 22);
            this.txtSmtpPassword.TabIndex = 9;

            this.chkSmtpUseSsl.AutoSize = true;
            this.chkSmtpUseSsl.Location = new System.Drawing.Point(10, 274);
            this.chkSmtpUseSsl.Name = "chkSmtpUseSsl";
            this.chkSmtpUseSsl.TabIndex = 10;
            this.chkSmtpUseSsl.Text = "SmtpUseSsl";

            this.chkSmtpUseDefaultCredentials.AutoSize = true;
            this.chkSmtpUseDefaultCredentials.Location = new System.Drawing.Point(10, 298);
            this.chkSmtpUseDefaultCredentials.Name = "chkSmtpUseDefaultCredentials";
            this.chkSmtpUseDefaultCredentials.TabIndex = 11;
            this.chkSmtpUseDefaultCredentials.Text = "SmtpUseDefaultCredentials";

            this.lblSmtpMailPriority.AutoSize = true;
            this.lblSmtpMailPriority.Location = new System.Drawing.Point(10, 324);
            this.lblSmtpMailPriority.Name = "lblSmtpMailPriority";
            this.lblSmtpMailPriority.Text = "SmtpMailPriority:";

            this.cboSmtpMailPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSmtpMailPriority.Items.AddRange(new object[] { "Normal", "Low", "High" });
            this.cboSmtpMailPriority.Location = new System.Drawing.Point(160, 321);
            this.cboSmtpMailPriority.Name = "cboSmtpMailPriority";
            this.cboSmtpMailPriority.Size = new System.Drawing.Size(150, 22);
            this.cboSmtpMailPriority.TabIndex = 12;

            this.lblWebServiceTimeout.AutoSize = true;
            this.lblWebServiceTimeout.Location = new System.Drawing.Point(10, 352);
            this.lblWebServiceTimeout.Name = "lblWebServiceTimeout";
            this.lblWebServiceTimeout.Text = "WebServiceTimeout (s):";

            this.nudWebServiceTimeout.Location = new System.Drawing.Point(160, 349);
            this.nudWebServiceTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudWebServiceTimeout.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            this.nudWebServiceTimeout.Name = "nudWebServiceTimeout";
            this.nudWebServiceTimeout.Size = new System.Drawing.Size(80, 22);
            this.nudWebServiceTimeout.TabIndex = 13;
            this.nudWebServiceTimeout.Value = new decimal(new int[] { 15, 0, 0, 0 });

            // grpPresets
            this.grpPresets.Controls.Add(this.btnPresetFullDetail);
            this.grpPresets.Controls.Add(this.btnPresetMinimalUI);
            this.grpPresets.Controls.Add(this.btnPresetWebService);
            this.grpPresets.Controls.Add(this.btnPresetEmailSMTP);
            this.grpPresets.Controls.Add(this.btnPresetDefault);
            this.grpPresets.Location = new System.Drawing.Point(5, 5);
            this.grpPresets.Name = "grpPresets";
            this.grpPresets.Size = new System.Drawing.Size(355, 215);
            this.grpPresets.TabIndex = 0;
            this.grpPresets.Text = "Presets";

            this.btnPresetDefault.Location = new System.Drawing.Point(10, 25);
            this.btnPresetDefault.Name = "btnPresetDefault";
            this.btnPresetDefault.Size = new System.Drawing.Size(330, 28);
            this.btnPresetDefault.TabIndex = 1;
            this.btnPresetDefault.Text = "Default";

            this.btnPresetEmailSMTP.Location = new System.Drawing.Point(10, 60);
            this.btnPresetEmailSMTP.Name = "btnPresetEmailSMTP";
            this.btnPresetEmailSMTP.Size = new System.Drawing.Size(330, 28);
            this.btnPresetEmailSMTP.TabIndex = 2;
            this.btnPresetEmailSMTP.Text = "Email via SMTP";

            this.btnPresetWebService.Location = new System.Drawing.Point(10, 95);
            this.btnPresetWebService.Name = "btnPresetWebService";
            this.btnPresetWebService.Size = new System.Drawing.Size(330, 28);
            this.btnPresetWebService.TabIndex = 3;
            this.btnPresetWebService.Text = "Send via WebService";

            this.btnPresetMinimalUI.Location = new System.Drawing.Point(10, 130);
            this.btnPresetMinimalUI.Name = "btnPresetMinimalUI";
            this.btnPresetMinimalUI.Size = new System.Drawing.Size(330, 28);
            this.btnPresetMinimalUI.TabIndex = 4;
            this.btnPresetMinimalUI.Text = "Minimal UI";

            this.btnPresetFullDetail.Location = new System.Drawing.Point(10, 165);
            this.btnPresetFullDetail.Name = "btnPresetFullDetail";
            this.btnPresetFullDetail.Size = new System.Drawing.Size(330, 28);
            this.btnPresetFullDetail.TabIndex = 5;
            this.btnPresetFullDetail.Text = "Full Detail";

            // grpActions
            this.grpActions.Controls.Add(this.btnShowWithSettings);
            this.grpActions.Controls.Add(this.lblShowDefaultHint);
            this.grpActions.Controls.Add(this.btnShowDefault);
            this.grpActions.Location = new System.Drawing.Point(5, 230);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(355, 200);
            this.grpActions.TabIndex = 1;
            this.grpActions.Text = "Actions";

            this.btnShowDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnShowDefault.Location = new System.Drawing.Point(10, 25);
            this.btnShowDefault.Name = "btnShowDefault";
            this.btnShowDefault.Size = new System.Drawing.Size(330, 50);
            this.btnShowDefault.TabIndex = 1;
            this.btnShowDefault.Text = "Show Default";

            this.lblShowDefaultHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblShowDefaultHint.Location = new System.Drawing.Point(10, 80);
            this.lblShowDefaultHint.Name = "lblShowDefaultHint";
            this.lblShowDefaultHint.Size = new System.Drawing.Size(330, 35);
            this.lblShowDefaultHint.Text = "Ignores all settings above — shows out-of-the-box defaults";

            this.btnShowWithSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnShowWithSettings.Location = new System.Drawing.Point(10, 125);
            this.btnShowWithSettings.Name = "btnShowWithSettings";
            this.btnShowWithSettings.Size = new System.Drawing.Size(330, 50);
            this.btnShowWithSettings.TabIndex = 2;
            this.btnShowWithSettings.Text = "Show with Settings";

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 652);
            this.Controls.Add(this.splitContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DemoApp";
            this.Text = "Exception Reporter Demo";

            ((System.ComponentModel.ISupportInitialize)(this.nudUserExplanationFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmtpPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWebServiceTimeout)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.scrollPanel.ResumeLayout(false);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.grpAppearance.ResumeLayout(false);
            this.grpAppearance.PerformLayout();
            this.grpTabs.ResumeLayout(false);
            this.grpTabs.PerformLayout();
            this.grpReport.ResumeLayout(false);
            this.grpReport.PerformLayout();
            this.grpSendEmail.ResumeLayout(false);
            this.grpSendEmail.PerformLayout();
            this.grpPresets.ResumeLayout(false);
            this.grpActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel scrollPanel;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Label lblTitleText;
        private System.Windows.Forms.TextBox txtTitleText;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblCustomMessage;
        private System.Windows.Forms.TextBox txtCustomMessage;
        private System.Windows.Forms.Label lblUserExplanationLabel;
        private System.Windows.Forms.TextBox txtUserExplanationLabel;
        private System.Windows.Forms.Label lblExceptionDateKind;
        private System.Windows.Forms.ComboBox cboExceptionDateKind;
        private System.Windows.Forms.GroupBox grpAppearance;
        private System.Windows.Forms.Label lblBackgroundColor;
        private System.Windows.Forms.TextBox txtBackgroundColor;
        private System.Windows.Forms.Panel pnlColorPreview;
        private System.Windows.Forms.Label lblUserExplanationFontSize;
        private System.Windows.Forms.NumericUpDown nudUserExplanationFontSize;
        private System.Windows.Forms.CheckBox chkShowFlatButtons;
        private System.Windows.Forms.CheckBox chkShowButtonIcons;
        private System.Windows.Forms.CheckBox chkShowLessDetailButton;
        private System.Windows.Forms.CheckBox chkShowFullDetail;
        private System.Windows.Forms.CheckBox chkTopMost;
        private System.Windows.Forms.GroupBox grpTabs;
        private System.Windows.Forms.CheckBox chkShowGeneralTab;
        private System.Windows.Forms.CheckBox chkShowExceptionsTab;
        private System.Windows.Forms.CheckBox chkShowSysInfoTab;
        private System.Windows.Forms.CheckBox chkShowAssembliesTab;
        private System.Windows.Forms.CheckBox chkShowEmailButton;
        private System.Windows.Forms.GroupBox grpReport;
        private System.Windows.Forms.Label lblReportTemplateFormat;
        private System.Windows.Forms.ComboBox cboReportTemplateFormat;
        private System.Windows.Forms.Label lblAttachmentFilename;
        private System.Windows.Forms.TextBox txtAttachmentFilename;
        private System.Windows.Forms.CheckBox chkTakeScreenshot;
        private System.Windows.Forms.GroupBox grpSendEmail;
        private System.Windows.Forms.Label lblSendMethod;
        private System.Windows.Forms.ComboBox cboSendMethod;
        private System.Windows.Forms.Label lblEmailReportAddress;
        private System.Windows.Forms.TextBox txtEmailReportAddress;
        private System.Windows.Forms.Label lblEmailReportSubject;
        private System.Windows.Forms.TextBox txtEmailReportSubject;
        private System.Windows.Forms.Label lblWebServiceUrl;
        private System.Windows.Forms.TextBox txtWebServiceUrl;
        private System.Windows.Forms.Label lblSmtpServer;
        private System.Windows.Forms.TextBox txtSmtpServer;
        private System.Windows.Forms.Label lblSmtpPort;
        private System.Windows.Forms.NumericUpDown nudSmtpPort;
        private System.Windows.Forms.Label lblSmtpFromAddress;
        private System.Windows.Forms.TextBox txtSmtpFromAddress;
        private System.Windows.Forms.Label lblSmtpUsername;
        private System.Windows.Forms.TextBox txtSmtpUsername;
        private System.Windows.Forms.Label lblSmtpPassword;
        private System.Windows.Forms.TextBox txtSmtpPassword;
        private System.Windows.Forms.CheckBox chkSmtpUseSsl;
        private System.Windows.Forms.CheckBox chkSmtpUseDefaultCredentials;
        private System.Windows.Forms.Label lblSmtpMailPriority;
        private System.Windows.Forms.ComboBox cboSmtpMailPriority;
        private System.Windows.Forms.Label lblWebServiceTimeout;
        private System.Windows.Forms.NumericUpDown nudWebServiceTimeout;
        private System.Windows.Forms.GroupBox grpPresets;
        private System.Windows.Forms.Button btnPresetDefault;
        private System.Windows.Forms.Button btnPresetEmailSMTP;
        private System.Windows.Forms.Button btnPresetWebService;
        private System.Windows.Forms.Button btnPresetMinimalUI;
        private System.Windows.Forms.Button btnPresetFullDetail;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnShowDefault;
        private System.Windows.Forms.Label lblShowDefaultHint;
        private System.Windows.Forms.Button btnShowWithSettings;
    }
}
```

- [ ] **Step 2: Commit**

```bash
git add demo/DemoAppView.designer.cs
git commit -m "feat: redesign demo — new designer with SplitContainer + 50 controls"
```

---

### Task 2: Write new `DemoApp.cs`

**Files:**
- Modify: `demo/ExceptionReporter.Demo.csproj` (add LangVersion)
- Modify: `demo/DemoApp.cs` (full replacement)

- [ ] **Step 1: Add `<LangVersion>latest</LangVersion>` to `demo/ExceptionReporter.Demo.csproj`**

Open `demo/ExceptionReporter.Demo.csproj`. Find the first `<PropertyGroup>` (the one without a `Condition`). Add the LangVersion line so it reads:

```xml
<PropertyGroup>
  <OutputType>WinExe</OutputType>
  <TargetFrameworks>net48;net10.0-windows</TargetFrameworks>
  <RootNamespace>Demo.WinForms</RootNamespace>
  <LangVersion>latest</LangVersion>
</PropertyGroup>
```

(Preserve any other existing entries in that PropertyGroup; only add `<LangVersion>latest</LangVersion>`.)

- [ ] **Step 2: Replace entire contents of `demo/DemoApp.cs`**

```csharp
using System;
using System.Drawing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using ExceptionReporting;

namespace Demo.WinForms
{
    public partial class DemoApp : Form
    {
        public DemoApp()
        {
            InitializeComponent();

            btnPresetDefault.Click += (s, e) => ApplyPreset_Default();
            btnPresetEmailSMTP.Click += (s, e) => ApplyPreset_EmailSMTP();
            btnPresetWebService.Click += (s, e) => ApplyPreset_WebService();
            btnPresetMinimalUI.Click += (s, e) => ApplyPreset_MinimalUI();
            btnPresetFullDetail.Click += (s, e) => ApplyPreset_FullDetail();

            btnShowDefault.Click += (s, e) => ShowDefault();
            btnShowWithSettings.Click += (s, e) => ShowWithSettings();

            cboSendMethod.SelectedIndexChanged += (s, e) => UpdateSendMethodFields();
            pnlColorPreview.Click += (s, e) => PickBackgroundColor();
            txtBackgroundColor.TextChanged += (s, e) => SyncColorPreview();

            ApplyPreset_Default();
        }

        private void UpdateSendMethodFields()
        {
            var isSmtp = cboSendMethod.SelectedItem?.ToString() == "SMTP";
            var isWeb = cboSendMethod.SelectedItem?.ToString() == "WebService";

            foreach (var c in new System.Windows.Forms.Control[] {
                lblSmtpServer, txtSmtpServer,
                lblSmtpPort, nudSmtpPort,
                lblSmtpFromAddress, txtSmtpFromAddress,
                lblSmtpUsername, txtSmtpUsername,
                lblSmtpPassword, txtSmtpPassword,
                chkSmtpUseSsl, chkSmtpUseDefaultCredentials,
                lblSmtpMailPriority, cboSmtpMailPriority })
                c.Enabled = isSmtp;

            foreach (var c in new System.Windows.Forms.Control[] {
                lblWebServiceUrl, txtWebServiceUrl,
                lblWebServiceTimeout, nudWebServiceTimeout })
                c.Enabled = isWeb;
        }

        private void PickBackgroundColor()
        {
            using (var dlg = new ColorDialog())
            {
                try { dlg.Color = ColorTranslator.FromHtml(txtBackgroundColor.Text); } catch { }
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtBackgroundColor.Text = ColorTranslator.ToHtml(dlg.Color);
                    pnlColorPreview.BackColor = dlg.Color;
                }
            }
        }

        private void SyncColorPreview()
        {
            try { pnlColorPreview.BackColor = ColorTranslator.FromHtml(txtBackgroundColor.Text); }
            catch { pnlColorPreview.BackColor = SystemColors.Control; }
        }

        private void ApplyPreset_Default()
        {
            cboSendMethod.SelectedItem = "None";
            cboReportTemplateFormat.SelectedItem = "Text";
            cboExceptionDateKind.SelectedItem = "Utc";
            chkShowGeneralTab.Checked = true;
            chkShowExceptionsTab.Checked = true;
            chkShowSysInfoTab.Checked = true;
            chkShowAssembliesTab.Checked = true;
            chkShowEmailButton.Checked = true;
            chkShowFlatButtons.Checked = true;
            chkShowLessDetailButton.Checked = false;
            chkShowFullDetail.Checked = false;
            chkShowButtonIcons.Checked = false;
            chkTakeScreenshot.Checked = false;
            chkTopMost.Checked = false;
            chkSmtpUseSsl.Checked = false;
            chkSmtpUseDefaultCredentials.Checked = false;
            cboSmtpMailPriority.SelectedItem = "Normal";
            nudUserExplanationFontSize.Value = 12;
            nudWebServiceTimeout.Value = 15;
            nudSmtpPort.Value = 25;
            txtTitleText.Text = "";
            txtCompanyName.Text = "";
            txtAppName.Text = "";
            txtUserName.Text = "";
            txtCustomMessage.Text = "";
            txtUserExplanationLabel.Text = "";
            txtBackgroundColor.Text = "";
            txtAttachmentFilename.Text = "";
            txtEmailReportAddress.Text = "";
            txtEmailReportSubject.Text = "";
            txtWebServiceUrl.Text = "";
            txtSmtpServer.Text = "";
            txtSmtpFromAddress.Text = "";
            txtSmtpUsername.Text = "";
            txtSmtpPassword.Text = "";
            UpdateSendMethodFields();
        }

        private void ApplyPreset_EmailSMTP()
        {
            cboSendMethod.SelectedItem = "SMTP";
            txtSmtpServer.Text = "127.0.0.1";
            nudSmtpPort.Value = 2500;
            txtSmtpFromAddress.Text = "test@test.com";
            txtEmailReportAddress.Text = "support@support.com";
            chkSmtpUseSsl.Checked = false;
            UpdateSendMethodFields();
        }

        private void ApplyPreset_WebService()
        {
            cboSendMethod.SelectedItem = "WebService";
            txtWebServiceUrl.Text = "http://localhost:24513/api/er";
            UpdateSendMethodFields();
        }

        private void ApplyPreset_MinimalUI()
        {
            chkShowGeneralTab.Checked = false;
            chkShowSysInfoTab.Checked = false;
            chkShowAssembliesTab.Checked = false;
            chkShowEmailButton.Checked = false;
            chkShowLessDetailButton.Checked = false;
            chkShowFullDetail.Checked = false;
            chkShowButtonIcons.Checked = false;
        }

        private void ApplyPreset_FullDetail()
        {
            chkShowFullDetail.Checked = true;
            chkShowLessDetailButton.Checked = true;
            chkShowButtonIcons.Checked = true;
            chkShowGeneralTab.Checked = true;
            chkShowExceptionsTab.Checked = true;
            chkShowSysInfoTab.Checked = true;
            chkShowAssembliesTab.Checked = true;
            txtTitleText.Text = "Acme Error Report";
            txtCompanyName.Text = "Acme";
            cboSendMethod.SelectedItem = "SimpleMAPI";
            txtEmailReportAddress.Text = "support@acme.com";
            UpdateSendMethodFields();
        }

        private void ShowDefault()
        {
            try { SomeMethodThatThrows(); }
            catch (Exception ex)
            {
                new ExceptionReporter().Show(ex);
            }
        }

        private void ShowWithSettings()
        {
            try { SomeMethodThatThrows(); }
            catch (Exception ex)
            {
                var er = new ExceptionReporter();

                er.Config.TitleText = txtTitleText.Text;
                er.Config.CompanyName = txtCompanyName.Text;
                er.Config.AppName = txtAppName.Text;
                er.Config.UserName = txtUserName.Text;
                er.Config.CustomMessage = txtCustomMessage.Text;
                er.Config.UserExplanationLabel = txtUserExplanationLabel.Text;
                er.Config.ExceptionDateKind = cboExceptionDateKind.SelectedItem?.ToString() == "Local"
                    ? DateTimeKind.Local : DateTimeKind.Utc;

                if (!string.IsNullOrEmpty(txtBackgroundColor.Text))
                    er.Config.BackgroundColor = txtBackgroundColor.Text;
                er.Config.UserExplanationFontSize = (float)nudUserExplanationFontSize.Value;
                er.Config.ShowFlatButtons = chkShowFlatButtons.Checked;
                er.Config.ShowButtonIcons = chkShowButtonIcons.Checked;
                er.Config.ShowLessDetailButton = chkShowLessDetailButton.Checked;
                er.Config.ShowFullDetail = chkShowFullDetail.Checked;
                er.Config.TopMost = chkTopMost.Checked;

                er.Config.ShowGeneralTab = chkShowGeneralTab.Checked;
                er.Config.ShowExceptionsTab = chkShowExceptionsTab.Checked;
                er.Config.ShowSysInfoTab = chkShowSysInfoTab.Checked;
                er.Config.ShowAssembliesTab = chkShowAssembliesTab.Checked;
                er.Config.ShowEmailButton = chkShowEmailButton.Checked;

                er.Config.ReportTemplateFormat = cboReportTemplateFormat.SelectedItem?.ToString() switch
                {
                    "Html" => TemplateFormat.Html,
                    "Markdown" => TemplateFormat.Markdown,
                    _ => TemplateFormat.Text
                };
                er.Config.AttachmentFilename = txtAttachmentFilename.Text;
                er.Config.TakeScreenshot = chkTakeScreenshot.Checked;

                er.Config.SendMethod = cboSendMethod.SelectedItem?.ToString() switch
                {
                    "SimpleMAPI" => ReportSendMethod.SimpleMAPI,
                    "SMTP" => ReportSendMethod.SMTP,
                    "WebService" => ReportSendMethod.WebService,
                    _ => ReportSendMethod.None
                };
                er.Config.EmailReportAddress = txtEmailReportAddress.Text;
                er.Config.EmailReportSubject = txtEmailReportSubject.Text;
                er.Config.WebServiceUrl = txtWebServiceUrl.Text;
                er.Config.SmtpServer = txtSmtpServer.Text;
                er.Config.SmtpPort = (int)nudSmtpPort.Value;
                er.Config.SmtpFromAddress = txtSmtpFromAddress.Text;
                er.Config.SmtpUsername = txtSmtpUsername.Text;
                er.Config.SmtpPassword = txtSmtpPassword.Text;
                er.Config.SmtpUseSsl = chkSmtpUseSsl.Checked;
                er.Config.SmtpUseDefaultCredentials = chkSmtpUseDefaultCredentials.Checked;
                er.Config.SmtpMailPriority = cboSmtpMailPriority.SelectedItem?.ToString() switch
                {
                    "Low" => MailPriority.Low,
                    "High" => MailPriority.High,
                    _ => MailPriority.Normal
                };
                er.Config.WebServiceTimeout = (int)nudWebServiceTimeout.Value;

                er.Show(ex);
            }
        }

        static void SomeMethodThatThrows() => CallAnotherMethod();
        static void CallAnotherMethod() => AndAnotherOne();
        static void AndAnotherOne()
        {
            throw new IOException(
                "Unable to establish a connection with the Fizz photo service",
                new Exception("This is an Inner Exception message - with a message that is not too small"));
        }

        private void UseCustomReportView()
        {
            try { SomeMethodThatThrows(); }
            catch (Exception ex)
            {
                var er = new ExceptionReporter { ViewMaker = new YourCustomViewMaker() };
                er.Show(ex);
            }
        }
    }
}
```

- [ ] **Step 3: Commit**

```bash
git add demo/DemoApp.cs demo/ExceptionReporter.Demo.csproj
git commit -m "feat: redesign demo — new code-behind with presets and settings action"
```

---

### Task 3: Build verification

**Files:** (read-only verification)

- [ ] **Step 1: Build the demo project**

```bash
dotnet build demo/ExceptionReporter.Demo.csproj
```

Expected output: `Build succeeded.` for both `net48` and `net10.0-windows` target frameworks with 0 errors.

If the build fails, read the error messages carefully:
- **"does not contain a definition for X"** — a control name in `DemoApp.cs` does not match the field name declared in `DemoAppView.designer.cs`. Fix the mismatch.
- **"switch expression"** — target is net48 which requires C# 8+. The `ExceptionReporter.Demo.csproj` should already have `<LangVersion>latest</LangVersion>` or similar; if not, check `demo/ExceptionReporter.Demo.csproj` and add `<LangVersion>latest</LangVersion>` inside the `<PropertyGroup>`.
- **"`?.ToString()` not available"** — same LangVersion fix.

- [ ] **Step 2: Confirm both TFMs built**

Look for lines like:
```
ExceptionReporter.Demo -> demo\bin\Debug\net48\ExceptionReporter.Demo.exe
ExceptionReporter.Demo -> demo\bin\Debug\net10.0-windows\ExceptionReporter.Demo.exe
```

Both lines must be present.

- [ ] **Step 3: Commit if any fixes were needed, then tag complete**

```bash
# Only if fixes were needed in step 1:
git add demo/DemoApp.cs demo/DemoAppView.designer.cs demo/ExceptionReporter.Demo.csproj
git commit -m "fix: resolve build errors in demo UI redesign"
```
