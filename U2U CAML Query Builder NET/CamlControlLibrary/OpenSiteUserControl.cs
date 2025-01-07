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
            this.SuspendLayout();
            // 
            // uriLabel
            // 
            this.uriLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uriLabel.Location = new System.Drawing.Point(14, 20);
            this.uriLabel.Name = "uriLabel";
            this.uriLabel.Size = new System.Drawing.Size(393, 34);
            this.uriLabel.TabIndex = 0;
            this.uriLabel.Text = "Enter the URL to your SharePoint site:";
            this.uriLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uriTextBox
            // 
            this.uriTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uriTextBox.Location = new System.Drawing.Point(14, 66);
            this.uriTextBox.Name = "uriTextBox";
            this.uriTextBox.Size = new System.Drawing.Size(351, 38);
            this.uriTextBox.TabIndex = 1;
            // 
            // OpenSiteUserControl
            // 
            this.Controls.Add(this.uriTextBox);
            this.Controls.Add(this.uriLabel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MinimumSize = new System.Drawing.Size(410, 380);
            this.Name = "OpenSiteUserControl";
            this.Size = new System.Drawing.Size(410, 380);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private string oldUri = null;
        //private bool isO365Connection = false;

        private Label uriLabel;
        private TextBox uriTextBox;

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
                }
            }
        }

        private string SharePointUri
        {
            get { return uriTextBox.Text; }
            set { uriTextBox.Text = value; }
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
            SiteInfo.SharePointUri = SharePointUri;
        }
    }
}
