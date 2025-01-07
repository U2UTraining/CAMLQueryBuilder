namespace U2U.CamlControlLibrary
{
    using System;
    using System.Windows.Forms;
    using U2U.SharePoint.CAML;

    public partial class Connect : Form
    {
        public Connect(QueryInfo siteInfo)
        {
            InitializeComponent();
            connectToSiteControl.SiteInfo = siteInfo;
            SiteInfo = siteInfo;
        }

        public QueryInfo SiteInfo { get; set; }

        private void connectButton_Click(object sender, EventArgs e)
        {
            connectToSiteControl.Connect();
            SiteInfo = connectToSiteControl.SiteInfo;
        }

        private void connectToSiteControl_ConnectEvent()
        {

        }

        private void connectToSiteControl_Load(object sender, EventArgs e)
        {

        }
    }
}
