﻿namespace ExceptionReporting.Views
{
	partial class ExceptionReportView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionReportView));
			this.lstAssemblies = new System.Windows.Forms.ListView();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.lblExplanation = new System.Windows.Forms.Label();
			this.txtExplanation = new System.Windows.Forms.TextBox();
			this.lblRegion = new System.Windows.Forms.Label();
			this.txtRegion = new System.Windows.Forms.TextBox();
			this.picGeneral = new System.Windows.Forms.PictureBox();
			this.lblDate = new System.Windows.Forms.Label();
			this.txtDate = new System.Windows.Forms.TextBox();
			this.lblGeneral = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.txtTime = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblApplication = new System.Windows.Forms.Label();
			this.txtApplication = new System.Windows.Forms.TextBox();
			this.lblVersion = new System.Windows.Forms.Label();
			this.txtVersion = new System.Windows.Forms.TextBox();
			this.tabExceptions = new System.Windows.Forms.TabPage();
			this.listviewExceptions = new System.Windows.Forms.ListView();
			this.grbMessage = new System.Windows.Forms.GroupBox();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.grbStackTrace = new System.Windows.Forms.GroupBox();
			this.txtStackTrace = new System.Windows.Forms.TextBox();
			this.tabAssemblies = new System.Windows.Forms.TabPage();
			this.tabSettings = new System.Windows.Forms.TabPage();
			this.treeSettings = new System.Windows.Forms.TreeView();
			this.tabEnvironment = new System.Windows.Forms.TabPage();
			this.lblMachine = new System.Windows.Forms.Label();
			this.txtMachine = new System.Windows.Forms.TextBox();
			this.lblUsername = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.treeEnvironment = new System.Windows.Forms.TreeView();
			this.tabContact = new System.Windows.Forms.TabPage();
			this.lblContactMessageTop = new System.Windows.Forms.Label();
			this.txtFax = new System.Windows.Forms.TextBox();
			this.lblFax = new System.Windows.Forms.Label();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.lblPhone = new System.Windows.Forms.Label();
			this.lblWebSite = new System.Windows.Forms.Label();
			this.lnkWeb = new System.Windows.Forms.LinkLabel();
			this.lblEmail = new System.Windows.Forms.Label();
			this.lnkEmail = new System.Windows.Forms.LinkLabel();
			this.lblContactMessageBottom = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.btnEmail = new System.Windows.Forms.Button();
			this.btnPrint = new System.Windows.Forms.Button();
			this.lblProgress = new System.Windows.Forms.Label();
			this.btnCopy = new System.Windows.Forms.Button();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picGeneral)).BeginInit();
			this.tabExceptions.SuspendLayout();
			this.grbMessage.SuspendLayout();
			this.grbStackTrace.SuspendLayout();
			this.tabAssemblies.SuspendLayout();
			this.tabSettings.SuspendLayout();
			this.tabEnvironment.SuspendLayout();
			this.tabContact.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstAssemblies
			// 
			this.lstAssemblies.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.lstAssemblies.FullRowSelect = true;
			this.lstAssemblies.HotTracking = true;
			this.lstAssemblies.HoverSelection = true;
			this.lstAssemblies.Location = new System.Drawing.Point(8, 8);
			this.lstAssemblies.Name = "lstAssemblies";
			this.lstAssemblies.Size = new System.Drawing.Size(472, 320);
			this.lstAssemblies.TabIndex = 21;
			this.lstAssemblies.UseCompatibleStateImageBehavior = false;
			this.lstAssemblies.View = System.Windows.Forms.View.Details;
			// 
			// tabControl
			// 
			this.tabControl.Controls.Add(this.tabGeneral);
			this.tabControl.Controls.Add(this.tabExceptions);
			this.tabControl.Controls.Add(this.tabAssemblies);
			this.tabControl.Controls.Add(this.tabSettings);
			this.tabControl.Controls.Add(this.tabEnvironment);
			this.tabControl.Controls.Add(this.tabContact);
			this.tabControl.HotTrack = true;
			this.tabControl.Location = new System.Drawing.Point(12, 12);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.ShowToolTips = true;
			this.tabControl.Size = new System.Drawing.Size(496, 360);
			this.tabControl.TabIndex = 51;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.label1);
			this.tabGeneral.Controls.Add(this.lblExplanation);
			this.tabGeneral.Controls.Add(this.txtExplanation);
			this.tabGeneral.Controls.Add(this.lblRegion);
			this.tabGeneral.Controls.Add(this.txtRegion);
			this.tabGeneral.Controls.Add(this.picGeneral);
			this.tabGeneral.Controls.Add(this.lblDate);
			this.tabGeneral.Controls.Add(this.txtDate);
			this.tabGeneral.Controls.Add(this.lblGeneral);
			this.tabGeneral.Controls.Add(this.lblTime);
			this.tabGeneral.Controls.Add(this.txtTime);
			this.tabGeneral.Controls.Add(this.groupBox2);
			this.tabGeneral.Controls.Add(this.lblApplication);
			this.tabGeneral.Controls.Add(this.txtApplication);
			this.tabGeneral.Controls.Add(this.lblVersion);
			this.tabGeneral.Controls.Add(this.txtVersion);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Size = new System.Drawing.Size(488, 334);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "General";
			this.tabGeneral.UseVisualStyleBackColor = true;
			// 
			// lblExplanation
			// 
			this.lblExplanation.AutoSize = true;
			this.lblExplanation.Location = new System.Drawing.Point(5, 247);
			this.lblExplanation.Name = "lblExplanation";
			this.lblExplanation.Size = new System.Drawing.Size(334, 13);
			this.lblExplanation.TabIndex = 14;
			this.lblExplanation.Text = "Please enter a brief explanation of events leading up to this exception";
			// 
			// txtExplanation
			// 
			this.txtExplanation.Location = new System.Drawing.Point(8, 273);
			this.txtExplanation.Multiline = true;
			this.txtExplanation.Name = "txtExplanation";
			this.txtExplanation.Size = new System.Drawing.Size(472, 55);
			this.txtExplanation.TabIndex = 15;
			// 
			// lblRegion
			// 
			this.lblRegion.AutoSize = true;
			this.lblRegion.Location = new System.Drawing.Point(252, 138);
			this.lblRegion.Name = "lblRegion";
			this.lblRegion.Size = new System.Drawing.Size(41, 13);
			this.lblRegion.TabIndex = 7;
			this.lblRegion.Text = "Region";
			// 
			// txtRegion
			// 
			this.txtRegion.BackColor = System.Drawing.SystemColors.Control;
			this.txtRegion.Location = new System.Drawing.Point(308, 134);
			this.txtRegion.Name = "txtRegion";
			this.txtRegion.ReadOnly = true;
			this.txtRegion.Size = new System.Drawing.Size(168, 20);
			this.txtRegion.TabIndex = 8;
			// 
			// picGeneral
			// 
			this.picGeneral.Image = ((System.Drawing.Image)(resources.GetObject("picGeneral.Image")));
			this.picGeneral.Location = new System.Drawing.Point(3, 3);
			this.picGeneral.Name = "picGeneral";
			this.picGeneral.Size = new System.Drawing.Size(87, 83);
			this.picGeneral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picGeneral.TabIndex = 22;
			this.picGeneral.TabStop = false;
			// 
			// lblDate
			// 
			this.lblDate.AutoSize = true;
			this.lblDate.Location = new System.Drawing.Point(12, 166);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(30, 13);
			this.lblDate.TabIndex = 9;
			this.lblDate.Text = "Date";
			// 
			// txtDate
			// 
			this.txtDate.BackColor = System.Drawing.SystemColors.Control;
			this.txtDate.Location = new System.Drawing.Point(76, 166);
			this.txtDate.Name = "txtDate";
			this.txtDate.ReadOnly = true;
			this.txtDate.Size = new System.Drawing.Size(152, 20);
			this.txtDate.TabIndex = 10;
			// 
			// lblGeneral
			// 
			this.lblGeneral.AutoSize = true;
			this.lblGeneral.Location = new System.Drawing.Point(99, 16);
			this.lblGeneral.Name = "lblGeneral";
			this.lblGeneral.Size = new System.Drawing.Size(218, 13);
			this.lblGeneral.TabIndex = 1;
			this.lblGeneral.Text = "An exception has occured in this application.";
			// 
			// lblTime
			// 
			this.lblTime.AutoSize = true;
			this.lblTime.Location = new System.Drawing.Point(252, 169);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(30, 13);
			this.lblTime.TabIndex = 11;
			this.lblTime.Text = "Time";
			// 
			// txtTime
			// 
			this.txtTime.BackColor = System.Drawing.SystemColors.Control;
			this.txtTime.Location = new System.Drawing.Point(308, 166);
			this.txtTime.Name = "txtTime";
			this.txtTime.ReadOnly = true;
			this.txtTime.Size = new System.Drawing.Size(168, 20);
			this.txtTime.TabIndex = 12;
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(8, 229);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(472, 8);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			// 
			// lblApplication
			// 
			this.lblApplication.AutoSize = true;
			this.lblApplication.Location = new System.Drawing.Point(12, 104);
			this.lblApplication.Name = "lblApplication";
			this.lblApplication.Size = new System.Drawing.Size(59, 13);
			this.lblApplication.TabIndex = 3;
			this.lblApplication.Text = "Application";
			// 
			// txtApplication
			// 
			this.txtApplication.BackColor = System.Drawing.SystemColors.Control;
			this.txtApplication.Location = new System.Drawing.Point(76, 102);
			this.txtApplication.Name = "txtApplication";
			this.txtApplication.ReadOnly = true;
			this.txtApplication.Size = new System.Drawing.Size(400, 20);
			this.txtApplication.TabIndex = 4;
			// 
			// lblVersion
			// 
			this.lblVersion.Location = new System.Drawing.Point(12, 138);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(48, 16);
			this.lblVersion.TabIndex = 5;
			this.lblVersion.Text = "Version";
			// 
			// txtVersion
			// 
			this.txtVersion.BackColor = System.Drawing.SystemColors.Control;
			this.txtVersion.Location = new System.Drawing.Point(76, 134);
			this.txtVersion.Name = "txtVersion";
			this.txtVersion.ReadOnly = true;
			this.txtVersion.Size = new System.Drawing.Size(152, 20);
			this.txtVersion.TabIndex = 6;
			// 
			// tabExceptions
			// 
			this.tabExceptions.Controls.Add(this.listviewExceptions);
			this.tabExceptions.Controls.Add(this.grbMessage);
			this.tabExceptions.Controls.Add(this.grbStackTrace);
			this.tabExceptions.Location = new System.Drawing.Point(4, 22);
			this.tabExceptions.Name = "tabExceptions";
			this.tabExceptions.Size = new System.Drawing.Size(488, 334);
			this.tabExceptions.TabIndex = 1;
			this.tabExceptions.Text = "Exceptions";
			this.tabExceptions.UseVisualStyleBackColor = true;
			// 
			// listviewExceptions
			// 
			this.listviewExceptions.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listviewExceptions.FullRowSelect = true;
			this.listviewExceptions.HotTracking = true;
			this.listviewExceptions.HoverSelection = true;
			this.listviewExceptions.Location = new System.Drawing.Point(8, 8);
			this.listviewExceptions.Name = "listviewExceptions";
			this.listviewExceptions.Size = new System.Drawing.Size(472, 120);
			this.listviewExceptions.TabIndex = 22;
			this.listviewExceptions.UseCompatibleStateImageBehavior = false;
			this.listviewExceptions.View = System.Windows.Forms.View.Details;
			// 
			// grbMessage
			// 
			this.grbMessage.Controls.Add(this.txtMessage);
			this.grbMessage.Location = new System.Drawing.Point(8, 136);
			this.grbMessage.Name = "grbMessage";
			this.grbMessage.Size = new System.Drawing.Size(472, 88);
			this.grbMessage.TabIndex = 23;
			this.grbMessage.TabStop = false;
			this.grbMessage.Text = "Message";
			// 
			// txtMessage
			// 
			this.txtMessage.BackColor = System.Drawing.SystemColors.Window;
			this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtMessage.Location = new System.Drawing.Point(3, 16);
			this.txtMessage.Multiline = true;
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ReadOnly = true;
			this.txtMessage.Size = new System.Drawing.Size(466, 69);
			this.txtMessage.TabIndex = 24;
			// 
			// grbStackTrace
			// 
			this.grbStackTrace.Controls.Add(this.txtStackTrace);
			this.grbStackTrace.Location = new System.Drawing.Point(8, 224);
			this.grbStackTrace.Name = "grbStackTrace";
			this.grbStackTrace.Size = new System.Drawing.Size(472, 104);
			this.grbStackTrace.TabIndex = 25;
			this.grbStackTrace.TabStop = false;
			this.grbStackTrace.Text = "Stack Trace";
			// 
			// txtStackTrace
			// 
			this.txtStackTrace.BackColor = System.Drawing.SystemColors.Window;
			this.txtStackTrace.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtStackTrace.Location = new System.Drawing.Point(3, 16);
			this.txtStackTrace.Multiline = true;
			this.txtStackTrace.Name = "txtStackTrace";
			this.txtStackTrace.ReadOnly = true;
			this.txtStackTrace.Size = new System.Drawing.Size(466, 85);
			this.txtStackTrace.TabIndex = 26;
			// 
			// tabAssemblies
			// 
			this.tabAssemblies.Controls.Add(this.lstAssemblies);
			this.tabAssemblies.Location = new System.Drawing.Point(4, 22);
			this.tabAssemblies.Name = "tabAssemblies";
			this.tabAssemblies.Size = new System.Drawing.Size(488, 334);
			this.tabAssemblies.TabIndex = 6;
			this.tabAssemblies.Text = "Assemblies";
			this.tabAssemblies.UseVisualStyleBackColor = true;
			// 
			// tabSettings
			// 
			this.tabSettings.Controls.Add(this.treeSettings);
			this.tabSettings.Location = new System.Drawing.Point(4, 22);
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.Size = new System.Drawing.Size(488, 334);
			this.tabSettings.TabIndex = 5;
			this.tabSettings.Text = "Settings";
			this.tabSettings.UseVisualStyleBackColor = true;
			// 
			// treeSettings
			// 
			this.treeSettings.HotTracking = true;
			this.treeSettings.Location = new System.Drawing.Point(8, 8);
			this.treeSettings.Name = "treeSettings";
			this.treeSettings.Size = new System.Drawing.Size(472, 320);
			this.treeSettings.TabIndex = 20;
			// 
			// tabEnvironment
			// 
			this.tabEnvironment.Controls.Add(this.lblMachine);
			this.tabEnvironment.Controls.Add(this.txtMachine);
			this.tabEnvironment.Controls.Add(this.lblUsername);
			this.tabEnvironment.Controls.Add(this.txtUserName);
			this.tabEnvironment.Controls.Add(this.treeEnvironment);
			this.tabEnvironment.Location = new System.Drawing.Point(4, 22);
			this.tabEnvironment.Name = "tabEnvironment";
			this.tabEnvironment.Size = new System.Drawing.Size(488, 334);
			this.tabEnvironment.TabIndex = 3;
			this.tabEnvironment.Text = "Environment";
			this.tabEnvironment.UseVisualStyleBackColor = true;
			// 
			// lblMachine
			// 
			this.lblMachine.AutoSize = true;
			this.lblMachine.Location = new System.Drawing.Point(5, 15);
			this.lblMachine.Name = "lblMachine";
			this.lblMachine.Size = new System.Drawing.Size(48, 13);
			this.lblMachine.TabIndex = 16;
			this.lblMachine.Text = "Machine";
			// 
			// txtMachine
			// 
			this.txtMachine.BackColor = System.Drawing.SystemColors.Control;
			this.txtMachine.Location = new System.Drawing.Point(59, 12);
			this.txtMachine.Name = "txtMachine";
			this.txtMachine.ReadOnly = true;
			this.txtMachine.Size = new System.Drawing.Size(169, 20);
			this.txtMachine.TabIndex = 17;
			// 
			// lblUsername
			// 
			this.lblUsername.AutoSize = true;
			this.lblUsername.Location = new System.Drawing.Point(250, 15);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(55, 13);
			this.lblUsername.TabIndex = 18;
			this.lblUsername.Text = "Username";
			// 
			// txtUserName
			// 
			this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUserName.BackColor = System.Drawing.SystemColors.Control;
			this.txtUserName.Location = new System.Drawing.Point(311, 12);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.ReadOnly = true;
			this.txtUserName.Size = new System.Drawing.Size(169, 20);
			this.txtUserName.TabIndex = 19;
			// 
			// treeEnvironment
			// 
			this.treeEnvironment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.treeEnvironment.HotTracking = true;
			this.treeEnvironment.Location = new System.Drawing.Point(8, 40);
			this.treeEnvironment.Name = "treeEnvironment";
			this.treeEnvironment.Size = new System.Drawing.Size(472, 288);
			this.treeEnvironment.TabIndex = 24;
			// 
			// tabContact
			// 
			this.tabContact.Controls.Add(this.lblContactMessageTop);
			this.tabContact.Controls.Add(this.txtFax);
			this.tabContact.Controls.Add(this.lblFax);
			this.tabContact.Controls.Add(this.txtPhone);
			this.tabContact.Controls.Add(this.lblPhone);
			this.tabContact.Controls.Add(this.lblWebSite);
			this.tabContact.Controls.Add(this.lnkWeb);
			this.tabContact.Controls.Add(this.lblEmail);
			this.tabContact.Controls.Add(this.lnkEmail);
			this.tabContact.Controls.Add(this.lblContactMessageBottom);
			this.tabContact.Location = new System.Drawing.Point(4, 22);
			this.tabContact.Name = "tabContact";
			this.tabContact.Size = new System.Drawing.Size(488, 334);
			this.tabContact.TabIndex = 4;
			this.tabContact.Text = "Contact";
			this.tabContact.UseVisualStyleBackColor = true;
			// 
			// lblContactMessageTop
			// 
			this.lblContactMessageTop.Location = new System.Drawing.Point(8, 24);
			this.lblContactMessageTop.Name = "lblContactMessageTop";
			this.lblContactMessageTop.Size = new System.Drawing.Size(432, 24);
			this.lblContactMessageTop.TabIndex = 27;
			this.lblContactMessageTop.Text = "The following details can be used to obtain support for this application....";
			// 
			// txtFax
			// 
			this.txtFax.BackColor = System.Drawing.SystemColors.Control;
			this.txtFax.Location = new System.Drawing.Point(72, 168);
			this.txtFax.Name = "txtFax";
			this.txtFax.Size = new System.Drawing.Size(240, 20);
			this.txtFax.TabIndex = 35;
			// 
			// lblFax
			// 
			this.lblFax.AutoSize = true;
			this.lblFax.Location = new System.Drawing.Point(18, 168);
			this.lblFax.Name = "lblFax";
			this.lblFax.Size = new System.Drawing.Size(24, 13);
			this.lblFax.TabIndex = 34;
			this.lblFax.Text = "Fax";
			// 
			// txtPhone
			// 
			this.txtPhone.BackColor = System.Drawing.SystemColors.Control;
			this.txtPhone.Location = new System.Drawing.Point(72, 142);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(240, 20);
			this.txtPhone.TabIndex = 33;
			// 
			// lblPhone
			// 
			this.lblPhone.AutoSize = true;
			this.lblPhone.Location = new System.Drawing.Point(16, 144);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(38, 13);
			this.lblPhone.TabIndex = 32;
			this.lblPhone.Text = "Phone";
			// 
			// lblWebSite
			// 
			this.lblWebSite.AutoSize = true;
			this.lblWebSite.Location = new System.Drawing.Point(16, 80);
			this.lblWebSite.Name = "lblWebSite";
			this.lblWebSite.Size = new System.Drawing.Size(30, 13);
			this.lblWebSite.TabIndex = 30;
			this.lblWebSite.Text = "Web";
			// 
			// lnkWeb
			// 
			this.lnkWeb.Location = new System.Drawing.Point(69, 80);
			this.lnkWeb.Name = "lnkWeb";
			this.lnkWeb.Size = new System.Drawing.Size(400, 59);
			this.lnkWeb.TabIndex = 31;
			// 
			// lblEmail
			// 
			this.lblEmail.AutoSize = true;
			this.lblEmail.Location = new System.Drawing.Point(16, 56);
			this.lblEmail.Name = "lblEmail";
			this.lblEmail.Size = new System.Drawing.Size(32, 13);
			this.lblEmail.TabIndex = 28;
			this.lblEmail.Text = "Email";
			// 
			// lnkEmail
			// 
			this.lnkEmail.Location = new System.Drawing.Point(69, 56);
			this.lnkEmail.Name = "lnkEmail";
			this.lnkEmail.Size = new System.Drawing.Size(400, 16);
			this.lnkEmail.TabIndex = 29;
			// 
			// lblContactMessageBottom
			// 
			this.lblContactMessageBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lblContactMessageBottom.Location = new System.Drawing.Point(11, 238);
			this.lblContactMessageBottom.Name = "lblContactMessageBottom";
			this.lblContactMessageBottom.Size = new System.Drawing.Size(458, 96);
			this.lblContactMessageBottom.TabIndex = 36;
			this.lblContactMessageBottom.Text = "The information on this form describing the error and envrionment settings will b" +
				"e of use when contacting support.";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
			this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.Location = new System.Drawing.Point(358, 380);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(72, 32);
			this.btnSave.TabIndex = 56;
			this.btnSave.Text = "Save";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.progressBar.Location = new System.Drawing.Point(12, 396);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(128, 16);
			this.progressBar.TabIndex = 53;
			// 
			// btnEmail
			// 
			this.btnEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnEmail.Image")));
			this.btnEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEmail.Location = new System.Drawing.Point(436, 380);
			this.btnEmail.Name = "btnEmail";
			this.btnEmail.Size = new System.Drawing.Size(72, 32);
			this.btnEmail.TabIndex = 57;
			this.btnEmail.Text = "Email";
			this.btnEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnPrint
			// 
			this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPrint.Location = new System.Drawing.Point(202, 380);
			this.btnPrint.Name = "btnPrint";
			this.btnPrint.Size = new System.Drawing.Size(72, 32);
			this.btnPrint.TabIndex = 54;
			this.btnPrint.Text = "Print";
			this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnPrint.Visible = false;
			// 
			// lblProgress
			// 
			this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblProgress.Location = new System.Drawing.Point(12, 377);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(128, 16);
			this.lblProgress.TabIndex = 52;
			this.lblProgress.Text = "Loading System Info...";
			// 
			// btnCopy
			// 
			this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
			this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCopy.Location = new System.Drawing.Point(280, 380);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(72, 32);
			this.btnCopy.TabIndex = 55;
			this.btnCopy.Text = "Copy";
			this.btnCopy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Location = new System.Drawing.Point(99, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(377, 38);
			this.label1.TabIndex = 23;
			this.label1.Text = "Please notify IT support of this exception by using the Save/Copy or Email button" +
				"s below";
			// 
			// ExceptionReportView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(517, 419);
			this.Controls.Add(this.tabControl);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.btnEmail);
			this.Controls.Add(this.btnPrint);
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.btnCopy);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "ExceptionReportView";
			this.Text = "Exception Report";
			this.tabControl.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabGeneral.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picGeneral)).EndInit();
			this.tabExceptions.ResumeLayout(false);
			this.grbMessage.ResumeLayout(false);
			this.grbMessage.PerformLayout();
			this.grbStackTrace.ResumeLayout(false);
			this.grbStackTrace.PerformLayout();
			this.tabAssemblies.ResumeLayout(false);
			this.tabSettings.ResumeLayout(false);
			this.tabEnvironment.ResumeLayout(false);
			this.tabEnvironment.PerformLayout();
			this.tabContact.ResumeLayout(false);
			this.tabContact.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lstAssemblies;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.Label lblExplanation;
		private System.Windows.Forms.TextBox txtExplanation;
		private System.Windows.Forms.Label lblRegion;
		private System.Windows.Forms.TextBox txtRegion;
		private System.Windows.Forms.PictureBox picGeneral;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.TextBox txtDate;
		private System.Windows.Forms.Label lblGeneral;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.TextBox txtTime;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lblApplication;
		private System.Windows.Forms.TextBox txtApplication;
		private System.Windows.Forms.Label lblVersion;
		private System.Windows.Forms.TextBox txtVersion;
		private System.Windows.Forms.TabPage tabExceptions;
		private System.Windows.Forms.ListView listviewExceptions;
		private System.Windows.Forms.GroupBox grbMessage;
		private System.Windows.Forms.TextBox txtMessage;
		private System.Windows.Forms.GroupBox grbStackTrace;
		private System.Windows.Forms.TextBox txtStackTrace;
		private System.Windows.Forms.TabPage tabAssemblies;
		private System.Windows.Forms.TabPage tabSettings;
		private System.Windows.Forms.TreeView treeSettings;
		private System.Windows.Forms.TabPage tabEnvironment;
		private System.Windows.Forms.Label lblMachine;
		private System.Windows.Forms.TextBox txtMachine;
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TreeView treeEnvironment;
		private System.Windows.Forms.TabPage tabContact;
		private System.Windows.Forms.Label lblContactMessageTop;
		private System.Windows.Forms.TextBox txtFax;
		private System.Windows.Forms.Label lblFax;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.Label lblPhone;
		private System.Windows.Forms.Label lblWebSite;
		private System.Windows.Forms.LinkLabel lnkWeb;
		private System.Windows.Forms.Label lblEmail;
		private System.Windows.Forms.LinkLabel lnkEmail;
		private System.Windows.Forms.Label lblContactMessageBottom;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Windows.Forms.Button btnEmail;
		private System.Windows.Forms.Button btnPrint;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.Button btnCopy;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.Label label1;
	}
}