namespace U2U.CamlControlLibrary
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using U2U.SharePoint.CAML;

    public delegate void ConnectEventHandler();

    /// <summary>
    /// Summary description for OpenSiteUserControl.
    /// </summary>
    public class OpenSiteUserControl : System.Windows.Forms.UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public OpenSiteUserControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            InitializeControl();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uriLabel = new System.Windows.Forms.Label();
            this.uriTextBox = new System.Windows.Forms.TextBox();
            this.connectionGroupBox = new System.Windows.Forms.GroupBox();
            this.isOnPremRadio = new System.Windows.Forms.RadioButton();
            this.isO365radio = new System.Windows.Forms.RadioButton();
            this.logonGroupBox = new System.Windows.Forms.GroupBox();
            this.credentialsGroupBox = new System.Windows.Forms.GroupBox();
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.domainLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.customCredentialsRadioButton = new System.Windows.Forms.RadioButton();
            this.credentialsCurrentUserRadioButton = new System.Windows.Forms.RadioButton();
            this.connectionGroupBox.SuspendLayout();
            this.logonGroupBox.SuspendLayout();
            this.credentialsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // uriLabel
            // 
            this.uriLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uriLabel.Location = new System.Drawing.Point(8, 9);
            this.uriLabel.Name = "uriLabel";
            this.uriLabel.Size = new System.Drawing.Size(393, 20);
            this.uriLabel.TabIndex = 0;
            this.uriLabel.Text = "Enter the URL to your SharePoint site:";
            this.uriLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uriTextBox
            // 
            this.uriTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uriTextBox.Location = new System.Drawing.Point(11, 32);
            this.uriTextBox.Name = "uriTextBox";
            this.uriTextBox.Size = new System.Drawing.Size(351, 20);
            this.uriTextBox.TabIndex = 1;
            // 
            // connectionGroupBox
            // 
            this.connectionGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionGroupBox.Controls.Add(this.isOnPremRadio);
            this.connectionGroupBox.Controls.Add(this.isO365radio);
            this.connectionGroupBox.Location = new System.Drawing.Point(11, 60);
            this.connectionGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.connectionGroupBox.Name = "connectionGroupBox";
            this.connectionGroupBox.Size = new System.Drawing.Size(373, 82);
            this.connectionGroupBox.TabIndex = 2;
            this.connectionGroupBox.TabStop = false;
            // 
            // isOnPremRadio
            // 
            this.isOnPremRadio.AutoSize = true;
            this.isOnPremRadio.Location = new System.Drawing.Point(8, 51);
            this.isOnPremRadio.Name = "isOnPremRadio";
            this.isOnPremRadio.Size = new System.Drawing.Size(194, 17);
            this.isOnPremRadio.TabIndex = 1;
            this.isOnPremRadio.Text = "Connect to SharePoint On Premises";
            this.isOnPremRadio.UseVisualStyleBackColor = true;
            // 
            // isO365radio
            // 
            this.isO365radio.AutoSize = true;
            this.isO365radio.Location = new System.Drawing.Point(8, 19);
            this.isO365radio.Name = "isO365radio";
            this.isO365radio.Size = new System.Drawing.Size(165, 17);
            this.isO365radio.TabIndex = 0;
            this.isO365radio.Text = "Connect to SharePoint Online";
            this.isO365radio.UseVisualStyleBackColor = true;
            this.isO365radio.CheckedChanged += new System.EventHandler(this.chkO365_CheckedChanged);
            // 
            // logonGroupBox
            // 
            this.logonGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logonGroupBox.Controls.Add(this.credentialsGroupBox);
            this.logonGroupBox.Controls.Add(this.customCredentialsRadioButton);
            this.logonGroupBox.Controls.Add(this.credentialsCurrentUserRadioButton);
            this.logonGroupBox.Location = new System.Drawing.Point(11, 142);
            this.logonGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.logonGroupBox.Name = "logonGroupBox";
            this.logonGroupBox.Size = new System.Drawing.Size(373, 213);
            this.logonGroupBox.TabIndex = 3;
            this.logonGroupBox.TabStop = false;
            // 
            // credentialsGroupBox
            // 
            this.credentialsGroupBox.Controls.Add(this.domainTextBox);
            this.credentialsGroupBox.Controls.Add(this.passwordTextBox);
            this.credentialsGroupBox.Controls.Add(this.usernameTextBox);
            this.credentialsGroupBox.Controls.Add(this.domainLabel);
            this.credentialsGroupBox.Controls.Add(this.passwordLabel);
            this.credentialsGroupBox.Controls.Add(this.userNameLabel);
            this.credentialsGroupBox.Enabled = false;
            this.credentialsGroupBox.Location = new System.Drawing.Point(8, 79);
            this.credentialsGroupBox.Margin = new System.Windows.Forms.Padding(0);
            this.credentialsGroupBox.Name = "credentialsGroupBox";
            this.credentialsGroupBox.Size = new System.Drawing.Size(358, 125);
            this.credentialsGroupBox.TabIndex = 2;
            this.credentialsGroupBox.TabStop = false;
            this.credentialsGroupBox.Text = "Specify credentials";
            // 
            // domainTextBox
            // 
            this.domainTextBox.Location = new System.Drawing.Point(113, 87);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.Size = new System.Drawing.Size(230, 20);
            this.domainTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(113, 61);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(230, 20);
            this.passwordTextBox.TabIndex = 3;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(113, 35);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(230, 20);
            this.usernameTextBox.TabIndex = 1;
            // 
            // domainLabel
            // 
            this.domainLabel.Location = new System.Drawing.Point(16, 90);
            this.domainLabel.Name = "domainLabel";
            this.domainLabel.Size = new System.Drawing.Size(78, 20);
            this.domainLabel.TabIndex = 4;
            this.domainLabel.Text = "Domain:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.Location = new System.Drawing.Point(16, 64);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(78, 18);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password:";
            // 
            // userNameLabel
            // 
            this.userNameLabel.Location = new System.Drawing.Point(16, 38);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(78, 20);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "Username:";
            // 
            // customCredentialsRadioButton
            // 
            this.customCredentialsRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customCredentialsRadioButton.Location = new System.Drawing.Point(8, 45);
            this.customCredentialsRadioButton.Name = "customCredentialsRadioButton";
            this.customCredentialsRadioButton.Size = new System.Drawing.Size(350, 28);
            this.customCredentialsRadioButton.TabIndex = 1;
            this.customCredentialsRadioButton.Text = "Custom credentials";
            this.customCredentialsRadioButton.CheckedChanged += new System.EventHandler(this.customCredentialsRadioButton_CheckedChanged);
            // 
            // credentialsCurrentUserRadioButton
            // 
            this.credentialsCurrentUserRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.credentialsCurrentUserRadioButton.Checked = true;
            this.credentialsCurrentUserRadioButton.Location = new System.Drawing.Point(8, 11);
            this.credentialsCurrentUserRadioButton.Name = "credentialsCurrentUserRadioButton";
            this.credentialsCurrentUserRadioButton.Size = new System.Drawing.Size(350, 28);
            this.credentialsCurrentUserRadioButton.TabIndex = 0;
            this.credentialsCurrentUserRadioButton.TabStop = true;
            this.credentialsCurrentUserRadioButton.Text = "Credentials of the current user";
            this.credentialsCurrentUserRadioButton.CheckedChanged += new System.EventHandler(this.credentialsCurrentUserRadioButton_CheckedChanged);
            // 
            // OpenSiteUserControl
            // 
            this.Controls.Add(this.uriTextBox);
            this.Controls.Add(this.uriLabel);
            this.Controls.Add(this.connectionGroupBox);
            this.Controls.Add(this.logonGroupBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(410, 380);
            this.Name = "OpenSiteUserControl";
            this.Size = new System.Drawing.Size(410, 380);
            this.connectionGroupBox.ResumeLayout(false);
            this.connectionGroupBox.PerformLayout();
            this.logonGroupBox.ResumeLayout(false);
            this.credentialsGroupBox.ResumeLayout(false);
            this.credentialsGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private string oldUri = null;
        private bool isO365Connection = false;
 
        private Label uriLabel;
        private TextBox uriTextBox;
        private GroupBox connectionGroupBox;
        private GroupBox logonGroupBox;
        private GroupBox credentialsGroupBox;
        private TextBox domainTextBox;
        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private Label domainLabel;
        private Label passwordLabel;
        private Label userNameLabel;
        private RadioButton customCredentialsRadioButton;
        private RadioButton credentialsCurrentUserRadioButton;
        private bool hasCustomCredentials = false;
        private RadioButton isO365radio;
        private RadioButton isOnPremRadio;

        private QueryInfo siteInfo;

        public QueryInfo SiteInfo
        {
            get
            {
                return siteInfo;
            }
            set
            {
                siteInfo = value;
                if (siteInfo != null)
                {
                    SharePointUri = siteInfo.SharePointUri;
                    IsCustomCredentials = siteInfo.IsCustomCredentials;
                    IsO365Connection = siteInfo.IsO365Connection;
                    UserName = siteInfo.UserName;
                    Password = siteInfo.Password;
                    Domain = siteInfo.Domain;
                    HasCustomCredentials = siteInfo.HasCustomCredentials;
                }
            }
        }

        private string SharePointUri
        {
            get { return uriTextBox.Text; }
            set { uriTextBox.Text = value; }
        }

        private bool IsCustomCredentials
        {
            get { return customCredentialsRadioButton.Checked; }
            set { customCredentialsRadioButton.Checked = value; }
        }

        private string UserName
        {
            get { return usernameTextBox.Text; }
            set { usernameTextBox.Text = value; }
        }

        private string Password
        {
            get { return passwordTextBox.Text; }
            set { passwordTextBox.Text = value; }
        }

        private string Domain
        {
            get { return domainTextBox.Text; }
            set { domainTextBox.Text = value; }
        }

        private bool IsO365Connection
        {
            get { return isO365Connection; }
            set
            {
                isO365Connection = value;
                isO365radio.Checked = isO365Connection;
                isOnPremRadio.Checked = !isO365Connection;
            }
        }

        private bool HasCustomCredentials
        {
            get { return hasCustomCredentials; }
            set { hasCustomCredentials = value; }
        }

        private void InitializeControl()
        {
            string configDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\" +
                U2U.Constants.CamlBuilder.APP_CONFIG_DIR + @"\" + Constants.CamlBuilder.APP_CONFIG_FILE;

            // check if file with settings exists
            if (uriTextBox.Text == string.Empty && File.Exists(configDir))
            {
                TextReader streamReader = new StreamReader(configDir);
                oldUri = streamReader.ReadLine();
                uriTextBox.Text = oldUri;
                streamReader.Close();
            }
        }

        public void Connect()
        {
            if (customCredentialsRadioButton.Checked && usernameTextBox.Text == string.Empty)
            {
                usernameTextBox.Focus();
                MessageBox.Show("Please, fill out your credentials", "Open Site", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SiteInfo.HasCustomCredentials = HasCustomCredentials;
                SiteInfo.Domain = Domain;
                SiteInfo.IsO365Connection = IsO365Connection;
                SiteInfo.IsCustomCredentials = IsCustomCredentials;
                SiteInfo.Password = Password;
                SiteInfo.SharePointUri = SharePointUri;
                SiteInfo.UserName = UserName;
            }
        }

        private void customCredentialsRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (customCredentialsRadioButton.Checked)
            {
                hasCustomCredentials = true;
                credentialsGroupBox.Enabled = true;
            }
        }

        private void credentialsCurrentUserRadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            if (credentialsCurrentUserRadioButton.Checked)
            {
                hasCustomCredentials = false;
                usernameTextBox.Text = string.Empty;
                passwordTextBox.Text = string.Empty;
                domainTextBox.Text = string.Empty;
                credentialsGroupBox.Enabled = false;
            }
        }

        private void chkO365_CheckedChanged(object sender, EventArgs e)
        {
            IsO365Connection = isO365radio.Checked;
            isOnPremRadio.Checked = !isO365radio.Checked;

            domainLabel.Enabled = !IsO365Connection;
            domainTextBox.Enabled = !IsO365Connection;
        }

        

    }
}
