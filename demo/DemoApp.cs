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

            foreach (var c in new Control[] {
                lblSmtpServer, txtSmtpServer,
                lblSmtpPort, nudSmtpPort,
                lblSmtpFromAddress, txtSmtpFromAddress,
                lblSmtpUsername, txtSmtpUsername,
                lblSmtpPassword, txtSmtpPassword,
                chkSmtpUseSsl, chkSmtpUseDefaultCredentials,
                lblSmtpMailPriority, cboSmtpMailPriority })
                c.Enabled = isSmtp;

            foreach (var c in new Control[] {
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
                er.Config.ShowEmailButton = chkShowEmailButton.Checked;
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
