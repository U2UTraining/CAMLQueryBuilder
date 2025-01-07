namespace U2U.CamlBuilder
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using U2U.CamlControlLibrary;
    using U2U.SharePoint.CAML;
    using U2U.SharePoint.CAML.Enumerations;

    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class MainForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.MenuStrip mainMenu1;
        private System.Windows.Forms.ToolStripMenuItem menuItem1;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem9;
        private System.Windows.Forms.ContextMenuStrip treeviewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openSiteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeSiteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem4;
        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private SharePointHierarchyUserControl sitesTreeview;
        private TabControl QueriesTabControl;
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStrip2;
        private ToolStripButton connectButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton openFileButton;
        private ToolStripButton saveFileButton;
        private ToolStripMenuItem menuItem3;
        private ToolStripMenuItem executeMenuItem;
        private ToolStripMenuItem copyToClipboardMenuItem;
        private ToolStripButton disconnectButton;
        private ToolStripMenuItem newQueryMenuItem;
        private ToolStripMenuItem menuItem6;
        private ToolStripSplitButton newQueryButton;
        private ToolStripMenuItem queryButton;
        private ToolStripMenuItem getListItemsButton;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem getListItemChangesButton;
        private ToolStripMenuItem getListItemChangesSinceButton;
        private ToolStripMenuItem updateListItemsButton;
        private ToolStripButton copyToClipboardButton;
        private ToolStripButton executeButton;
        private ToolStripButton closeQueryButton;
        private ToolStripContainer toolStripContainer2;
        private IContainer components;

        public MainForm()
        {
            Application.EnableVisualStyles();
            Application.DoEvents();

            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            InitializeForm();
            this.CenterToScreen();
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu1 = new System.Windows.Forms.MenuStrip();
            this.menuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openSiteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeSiteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.newQueryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.executeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeviewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.sitesTreeview = new U2U.CamlControlLibrary.SharePointHierarchyUserControl();
            this.QueriesTabControl = new System.Windows.Forms.TabControl();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.connectButton = new System.Windows.Forms.ToolStripButton();
            this.disconnectButton = new System.Windows.Forms.ToolStripButton();
            this.newQueryButton = new System.Windows.Forms.ToolStripSplitButton();
            this.queryButton = new System.Windows.Forms.ToolStripMenuItem();
            this.getListItemsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileButton = new System.Windows.Forms.ToolStripButton();
            this.saveFileButton = new System.Windows.Forms.ToolStripButton();
            this.copyToClipboardButton = new System.Windows.Forms.ToolStripButton();
            this.executeButton = new System.Windows.Forms.ToolStripButton();
            this.closeQueryButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.getListItemChangesButton = new System.Windows.Forms.ToolStripMenuItem();
            this.getListItemChangesSinceButton = new System.Windows.Forms.ToolStripMenuItem();
            this.updateListItemsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.mainMenu1.SuspendLayout();
            this.treeviewContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.Dock = System.Windows.Forms.DockStyle.None;
            this.mainMenu1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.mainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem1,
            this.menuItem3,
            this.menuItem9});
            this.mainMenu1.Location = new System.Drawing.Point(0, 0);
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size(987, 52);
            this.mainMenu1.TabIndex = 0;
            // 
            // menuItem1
            // 
            this.menuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openSiteMenuItem,
            this.closeSiteMenuItem,
            this.menuItem2,
            this.openMenuItem,
            this.saveMenuItem,
            this.menuItem4,
            this.exitMenuItem});
            this.menuItem1.MergeIndex = 0;
            this.menuItem1.Name = "menuItem1";
            this.menuItem1.Size = new System.Drawing.Size(87, 48);
            this.menuItem1.Text = "File";
            // 
            // openSiteMenuItem
            // 
            this.openSiteMenuItem.MergeIndex = 0;
            this.openSiteMenuItem.Name = "openSiteMenuItem";
            this.openSiteMenuItem.Size = new System.Drawing.Size(437, 54);
            this.openSiteMenuItem.Text = "Connect to a site ...";
            this.openSiteMenuItem.Click += new System.EventHandler(this.OpenSiteMenuItemClick);
            // 
            // closeSiteMenuItem
            // 
            this.closeSiteMenuItem.Enabled = false;
            this.closeSiteMenuItem.MergeIndex = 1;
            this.closeSiteMenuItem.Name = "closeSiteMenuItem";
            this.closeSiteMenuItem.Size = new System.Drawing.Size(437, 54);
            this.closeSiteMenuItem.Text = "Disconnect";
            this.closeSiteMenuItem.Click += new System.EventHandler(this.CloseSiteMenuItemClick);
            // 
            // menuItem2
            // 
            this.menuItem2.MergeIndex = 2;
            this.menuItem2.Name = "menuItem2";
            this.menuItem2.Size = new System.Drawing.Size(437, 54);
            this.menuItem2.Text = "-";
            // 
            // openMenuItem
            // 
            this.openMenuItem.MergeIndex = 3;
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(437, 54);
            this.openMenuItem.Text = "Open File";
            this.openMenuItem.Click += new System.EventHandler(this.OpenMenuItemClick);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Enabled = false;
            this.saveMenuItem.MergeIndex = 4;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.Size = new System.Drawing.Size(437, 54);
            this.saveMenuItem.Text = "Save File";
            this.saveMenuItem.Click += new System.EventHandler(this.SaveMenuItemClick);
            // 
            // menuItem4
            // 
            this.menuItem4.MergeIndex = 5;
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(437, 54);
            this.menuItem4.Text = "-";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.MergeIndex = 6;
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(437, 54);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newQueryMenuItem,
            this.menuItem6,
            this.executeMenuItem,
            this.copyToClipboardMenuItem});
            this.menuItem3.MergeIndex = 1;
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(123, 48);
            this.menuItem3.Text = "Query";
            this.menuItem3.DropDownOpening += new System.EventHandler(this.QueryMenuItemPopup);
            // 
            // newQueryMenuItem
            // 
            this.newQueryMenuItem.Enabled = false;
            this.newQueryMenuItem.MergeIndex = 0;
            this.newQueryMenuItem.Name = "newQueryMenuItem";
            this.newQueryMenuItem.Size = new System.Drawing.Size(448, 54);
            this.newQueryMenuItem.Text = "New Query";
            this.newQueryMenuItem.Click += new System.EventHandler(this.NewQueryButtonClick);
            // 
            // menuItem6
            // 
            this.menuItem6.MergeIndex = 1;
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Size = new System.Drawing.Size(448, 54);
            this.menuItem6.Text = "-";
            // 
            // executeMenuItem
            // 
            this.executeMenuItem.Enabled = false;
            this.executeMenuItem.MergeIndex = 2;
            this.executeMenuItem.Name = "executeMenuItem";
            this.executeMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.executeMenuItem.Size = new System.Drawing.Size(448, 54);
            this.executeMenuItem.Text = "&Execute";
            this.executeMenuItem.Click += new System.EventHandler(this.ExecuteButtonClick);
            // 
            // copyToClipboardMenuItem
            // 
            this.copyToClipboardMenuItem.Enabled = false;
            this.copyToClipboardMenuItem.MergeIndex = 3;
            this.copyToClipboardMenuItem.Name = "copyToClipboardMenuItem";
            this.copyToClipboardMenuItem.Size = new System.Drawing.Size(448, 54);
            this.copyToClipboardMenuItem.Text = "Copy query";
            this.copyToClipboardMenuItem.Click += new System.EventHandler(this.CopyButtonClick);
            // 
            // menuItem9
            // 
            this.menuItem9.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutMenuItem});
            this.menuItem9.MergeIndex = 2;
            this.menuItem9.Name = "menuItem9";
            this.menuItem9.Size = new System.Drawing.Size(104, 48);
            this.menuItem9.Text = "Help";
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.MergeIndex = 0;
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(266, 54);
            this.aboutMenuItem.Text = "About";
            this.aboutMenuItem.Click += new System.EventHandler(this.aboutMenuItem_Click);
            // 
            // treeviewContextMenu
            // 
            this.treeviewContextMenu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.treeviewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeMenuItem});
            this.treeviewContextMenu.Name = "treeviewContextMenu";
            this.treeviewContextMenu.Size = new System.Drawing.Size(204, 52);
            // 
            // removeMenuItem
            // 
            this.removeMenuItem.MergeIndex = 0;
            this.removeMenuItem.Name = "removeMenuItem";
            this.removeMenuItem.Size = new System.Drawing.Size(203, 48);
            this.removeMenuItem.Text = "Remove";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(987, 22);
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.sitesTreeview);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.QueriesTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(987, 178);
            this.splitContainer1.SplitterDistance = 202;
            this.splitContainer1.TabIndex = 21;
            // 
            // sitesTreeview
            // 
            this.sitesTreeview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sitesTreeview.Location = new System.Drawing.Point(0, 0);
            this.sitesTreeview.Name = "sitesTreeview";
            this.sitesTreeview.SelectedList = null;
            this.sitesTreeview.SelectedQueryType = U2U.SharePoint.CAML.Enumerations.CamlTypes.Query;
            this.sitesTreeview.SelectedSite = null;
            this.sitesTreeview.SelectedSiteInfo = null;
            this.sitesTreeview.Size = new System.Drawing.Size(202, 178);
            this.sitesTreeview.TabIndex = 2;
            // 
            // QueriesTabControl
            // 
            this.QueriesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueriesTabControl.Location = new System.Drawing.Point(0, 0);
            this.QueriesTabControl.Name = "QueriesTabControl";
            this.QueriesTabControl.SelectedIndex = 0;
            this.QueriesTabControl.Size = new System.Drawing.Size(781, 178);
            this.QueriesTabControl.TabIndex = 21;
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(987, 178);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(987, 255);
            this.toolStripContainer1.TabIndex = 22;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectButton,
            this.disconnectButton,
            this.newQueryButton,
            this.toolStripSeparator2,
            this.openFileButton,
            this.saveFileButton,
            this.copyToClipboardButton,
            this.executeButton,
            this.closeQueryButton,
            this.toolStripSeparator3});
            this.toolStrip2.Location = new System.Drawing.Point(8, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(979, 55);
            this.toolStrip2.TabIndex = 20;
            // 
            // connectButton
            // 
            this.connectButton.Image = global::U2U.CamlBuilder.Properties.Resources.Web;
            this.connectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.connectButton.Name = "connectButton";
            this.connectButton.Padding = new System.Windows.Forms.Padding(2);
            this.connectButton.Size = new System.Drawing.Size(184, 48);
            this.connectButton.Text = "&Connect ...";
            this.connectButton.Click += new System.EventHandler(this.OpenSiteMenuItemClick);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Image = global::U2U.CamlBuilder.Properties.Resources.disconnect;
            this.disconnectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(184, 48);
            this.disconnectButton.Text = "Disconnect";
            this.disconnectButton.Click += new System.EventHandler(this.CloseSiteMenuItemClick);
            // 
            // newQueryButton
            // 
            this.newQueryButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.queryButton,
            this.getListItemsButton});
            this.newQueryButton.Enabled = false;
            this.newQueryButton.Image = global::U2U.CamlBuilder.Properties.Resources.AddTableHS;
            this.newQueryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newQueryButton.Name = "newQueryButton";
            this.newQueryButton.Size = new System.Drawing.Size(209, 48);
            this.newQueryButton.Text = "New query";
            this.newQueryButton.ButtonClick += new System.EventHandler(this.NewQueryButtonClick);
            this.newQueryButton.DropDownOpening += new System.EventHandler(this.NewQueryButtonDropDownOpening);
            // 
            // queryButton
            // 
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(429, 54);
            this.queryButton.Text = "Simple Query";
            this.queryButton.Click += new System.EventHandler(this.NewQueryButtonClick);
            // 
            // getListItemsButton
            // 
            this.getListItemsButton.Name = "getListItemsButton";
            this.getListItemsButton.Size = new System.Drawing.Size(429, 54);
            this.getListItemsButton.Text = "Query with ViewFields";
            this.getListItemsButton.Click += new System.EventHandler(this.NewQueryButtonClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // openFileButton
            // 
            this.openFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFileButton.Image = ((System.Drawing.Image)(resources.GetObject("openFileButton.Image")));
            this.openFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(58, 48);
            this.openFileButton.Text = "&Open";
            this.openFileButton.Click += new System.EventHandler(this.OpenMenuItemClick);
            // 
            // saveFileButton
            // 
            this.saveFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveFileButton.Image = ((System.Drawing.Image)(resources.GetObject("saveFileButton.Image")));
            this.saveFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(58, 48);
            this.saveFileButton.Text = "&Save";
            this.saveFileButton.Click += new System.EventHandler(this.SaveMenuItemClick);
            // 
            // copyToClipboardButton
            // 
            this.copyToClipboardButton.Enabled = false;
            this.copyToClipboardButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToClipboardButton.Image")));
            this.copyToClipboardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToClipboardButton.Name = "copyToClipboardButton";
            this.copyToClipboardButton.Padding = new System.Windows.Forms.Padding(2);
            this.copyToClipboardButton.Size = new System.Drawing.Size(192, 48);
            this.copyToClipboardButton.Text = "Copy query";
            this.copyToClipboardButton.Click += new System.EventHandler(this.CopyButtonClick);
            // 
            // executeButton
            // 
            this.executeButton.Enabled = false;
            this.executeButton.Image = global::U2U.CamlBuilder.Properties.Resources.Run;
            this.executeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.executeButton.Name = "executeButton";
            this.executeButton.Padding = new System.Windows.Forms.Padding(2);
            this.executeButton.Size = new System.Drawing.Size(223, 48);
            this.executeButton.Text = "Execute query";
            this.executeButton.Click += new System.EventHandler(this.ExecuteButtonClick);
            // 
            // closeQueryButton
            // 
            this.closeQueryButton.Image = global::U2U.CamlBuilder.Properties.Resources.DeleteFolderHS;
            this.closeQueryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeQueryButton.Name = "closeQueryButton";
            this.closeQueryButton.Size = new System.Drawing.Size(194, 48);
            this.closeQueryButton.Text = "Close query";
            this.closeQueryButton.Click += new System.EventHandler(this.CloseQueryButtonClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // getListItemChangesButton
            // 
            this.getListItemChangesButton.Name = "getListItemChangesButton";
            this.getListItemChangesButton.Size = new System.Drawing.Size(155, 22);
            // 
            // getListItemChangesSinceButton
            // 
            this.getListItemChangesSinceButton.Name = "getListItemChangesSinceButton";
            this.getListItemChangesSinceButton.Size = new System.Drawing.Size(155, 22);
            // 
            // updateListItemsButton
            // 
            this.updateListItemsButton.Name = "updateListItemsButton";
            this.updateListItemsButton.Size = new System.Drawing.Size(155, 22);
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.AutoScroll = true;
            this.toolStripContainer2.ContentPanel.Controls.Add(this.toolStripContainer1);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(987, 255);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(987, 307);
            this.toolStripContainer2.TabIndex = 23;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.mainMenu1);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(987, 307);
            this.Controls.Add(this.toolStripContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu1;
            this.Name = "MainForm";
            this.Text = "U2U CAML Query Builder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainFormShown);
            this.mainMenu1.ResumeLayout(false);
            this.mainMenu1.PerformLayout();
            this.treeviewContextMenu.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var services = new ServiceCollection();
         

            Application.Run(new MainForm());
        }

        private QueryInfo queryInfo;

        #region "Initialization code"

        private void InitializeForm()
        {
            queryInfo = new QueryInfo
            {
                IsO365Connection = true
            };

            sitesTreeview.TreeviewClickEvent += new EventHandler<SelectedEventArgs>(OnSharePointTreeviewEvent);
            sitesTreeview.Selected += (sender, e) => RefreshToolbar();

            QueriesTabControl.Selected += (s, e) => RefreshToolbar();

            LoadPaths();
        }

        private async Task ShowConnectToSiteDialog()
        {
            using (Connect connectDialog = new Connect(queryInfo))
            {
                if (connectDialog.ShowDialog() == DialogResult.OK)
                {
                    queryInfo = connectDialog.SiteInfo;
                    await OpenSite();
                }
            }
        }

        #endregion

        #region "About menu item methods"

        private void aboutMenuItem_Click(object sender, System.EventArgs e)
        {
            using (AboutForm about = new AboutForm())
            {
                about.ShowDialog();
            }
        }

        #endregion

        #region "Exit menu item methods"

        private void exitMenuItem_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void SavePaths()
        {
            string configDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), U2U.Constants.CamlBuilder.APP_CONFIG_DIR);
            DirectoryInfo dir = new DirectoryInfo(configDir);
            if (!dir.Exists)
            {
                dir.Create();
            }

            using (TextWriter streamWriter = new StreamWriter(Path.Combine(configDir, U2U.Constants.CamlBuilder.APP_CONFIG_FILE), false))
            {
                if (queryInfo.SharePointUri != null)
                {
                    streamWriter.WriteLine(queryInfo.SharePointUri);
                }
                else
                {
                    streamWriter.WriteLine("");
                }
            }
        }

        private void LoadPaths()
        {
            string configDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), U2U.Constants.CamlBuilder.APP_CONFIG_DIR);
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(configDir);
            if (dir.Exists)
            {
                using (TextReader streamReader = new StreamReader(Path.Combine(configDir, U2U.Constants.CamlBuilder.APP_CONFIG_FILE)))
                {
                    queryInfo.SharePointUri = streamReader.ReadLine();
                }
            }
        }

        #endregion

        #region "Open menu item methods"

        private void OpenMenuItemClick(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.DefaultExt = "caml";
                    openFileDialog.Filter = "caml files (*.caml)|*.caml";
                    if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName.Length > 0)
                    {
                        QueryInfo query = new QueryInfo();
                        query.Load(openFileDialog.FileName);
                        LoadQueryTab(query);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private static CamlTypes GetQueryTypeFromXml(XmlDocument camlDocument)
        {
            CamlTypes queryType = CamlTypes.Query; // (Enumerations.QueryTypes)camlDocument.FirstChild.Name;
            Type t = typeof(CamlTypes);
            foreach (System.Reflection.FieldInfo fi in t.GetFields())
            {
                if (fi.Name.Equals(camlDocument.FirstChild.Name))
                {
                    queryType = (CamlTypes)fi.GetValue(null);
                }
            }

            return queryType;
        }

        #endregion

        #region "Save menu item methods"

        private void SaveMenuItemClick(object sender, System.EventArgs e)
        {
            if (QueriesTabControl.SelectedTab.Controls[0] is QueryDesigner queryDesigner)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "caml files (*.caml)|*.caml";
                        saveFileDialog.RestoreDirectory = true;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.FileName.Length > 0)
                        {
                            queryDesigner.QueryInfo.Save(saveFileDialog.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        #endregion

        private void CloseSiteMenuItemClick(object sender, System.EventArgs e)
        {
            CloseSite();
        }

        private async void OpenSiteMenuItemClick(object sender, System.EventArgs e)
        {
            await ShowConnectToSiteDialog();
        }

        private async Task OpenSite()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                if (queryInfo == null || string.IsNullOrEmpty(queryInfo.SharePointUri))
                {
                    MessageBox.Show("Please, fill out a url to your SharePoint site.");
                }
                else
                {
                    QueryInfo siteInfo = queryInfo.Clone() as QueryInfo;
                    siteInfo.Site = SiteFactory.Create(siteInfo);
                    await sitesTreeview.Connect(siteInfo);
                    RefreshToolbar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void CloseSite()
        {
            sitesTreeview.Disconnect();
            RefreshToolbar();
        }

        private void OnSharePointTreeviewEvent(object sender, SelectedEventArgs e)
        {
            QueryInfo query = e.SiteInfo.Clone() as QueryInfo;
            query.List = e.List.Clone() as ListInfo;
            query.QueryType = e.QueryType;
            LoadQueryTab(query);
        }

        private void LoadQueryTab(QueryInfo query)
        {
            string key = GetUniqueTabId(query.List.Id);
            string name = GetUniqueTabName(string.Format("{0} - {1}", query.List.Name, query.QueryType));

            QueriesTabControl.TabPages.Add(key, name);
            TabPage page = QueriesTabControl.TabPages[key];
            QueryDesigner designer = new QueryDesigner(query) { Visible = true, Dock = DockStyle.Fill };
            designer.QueryRebuilt += new EventHandler(DesignerQueryRebuilt);
            page.Controls.Add(designer);

            QueriesTabControl.SelectedTab = QueriesTabControl.TabPages[key];
            RefreshToolbar();
        }



        private string GetUniqueTabId(string tabKey)
        {
            string key = tabKey;
            int num = 0;
            while (QueriesTabControl.TabPages.ContainsKey(key))
            {
                key = string.Format("{0}-{1}", tabKey, ++num);
            }

            return key;
        }

        private string GetUniqueTabName(string tabName)
        {
            string name = tabName;
            int index = 0;
            bool nameExists;
            do
            {
                nameExists = false;
                foreach (TabPage tabPage in QueriesTabControl.TabPages)
                {
                    if (tabPage.Text.Equals(name))
                    {
                        nameExists = true;
                        name = string.Format("{0} ({1})", tabName, ++index);
                        break;
                    }
                }
            } while (nameExists);

            return name;
        }

        void DesignerQueryRebuilt(object sender, EventArgs e)
        {
            RefreshToolbar();
        }

        private void MainFormClosing(object sender, FormClosingEventArgs e)
        {
            SavePaths();
        }

        private async void ConnectButtonClick(object sender, EventArgs e)
        {
            await ShowConnectToSiteDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void ExecuteButtonClick(object sender, EventArgs e)
        {
            if (QueriesTabControl.SelectedTab.Controls[0] is QueryDesigner queryDesigner)
            {
                queryDesigner.Execute();
            }
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            if (QueriesTabControl.SelectedTab.Controls[0] is QueryDesigner queryDesigner)
            {
                queryDesigner.AddExpression();
            }
        }

        private void CopyButtonClick(object sender, EventArgs e)
        {
            if (QueriesTabControl.SelectedTab.Controls[0] is QueryDesigner queryDesigner)
            {
                queryDesigner.CopyToClipboard();
            }
        }

        private void RefreshToolbar()
        {
            executeButton.Enabled = false;
            copyToClipboardButton.Enabled = false;
            closeQueryButton.Enabled = QueriesTabControl.TabPages.Count > 0 && QueriesTabControl.SelectedTab != null;
            if (QueriesTabControl.TabPages.Count > 0 && QueriesTabControl.SelectedTab != null)
            {
                if (QueriesTabControl.SelectedTab.Controls[0] is QueryDesigner queryDesigner)
                {
                    executeButton.Enabled = queryDesigner.CanExecute;
                    copyToClipboardButton.Enabled = queryDesigner.CanCopyToClipboard;
                }
            }
            executeMenuItem.Enabled = executeButton.Enabled;
            copyToClipboardMenuItem.Enabled = copyToClipboardButton.Enabled;
            saveFileButton.Enabled = executeButton.Enabled;
            saveMenuItem.Enabled = executeButton.Enabled;

            disconnectButton.Enabled = sitesTreeview.SelectedSite != null;
            closeSiteMenuItem.Enabled = disconnectButton.Enabled;

            newQueryButton.Enabled = sitesTreeview.SelectedList != null;
            newQueryMenuItem.Enabled = newQueryButton.Enabled;
        }

        private void QueryMenuItemPopup(object sender, EventArgs e)
        {
            RefreshToolbar();
        }

        private void NewQueryButtonClick(object sender, EventArgs e)
        {
            if (sitesTreeview.SelectedSiteInfo != null)
            {
                if (sitesTreeview.SelectedSiteInfo.Clone() is QueryInfo query)
                {
                    query.QueryType = CamlTypes.Query;
                    if (sender is ToolStripMenuItem item)
                    {
                        if (item == getListItemsButton)
                        {
                            query.QueryType = CamlTypes.GetListItems;
                        }
                        else if (item == getListItemChangesButton)
                        {
                            query.QueryType = CamlTypes.GetListItemChanges;
                        }
                        else if (item == getListItemChangesSinceButton)
                        {
                            query.QueryType = CamlTypes.GetListItemChangesSinceToken;
                        }
                        else if (item == updateListItemsButton)
                        {
                            query.QueryType = CamlTypes.UpdateListItems;
                        }
                    }
                    query.List = new ListInfo() { Id = sitesTreeview.SelectedList.Id, Name = sitesTreeview.SelectedList.Name };
                    LoadQueryTab(query);
                }
            }
        }

        private void CloseQueryButtonClick(object sender, EventArgs e)
        {
            if (QueriesTabControl.SelectedTab != null)
            {
                QueriesTabControl.TabPages.Remove(QueriesTabControl.SelectedTab);
                RefreshToolbar();
            }
        }

        private void NewQueryButtonDropDownOpening(object sender, EventArgs e)
        {
            bool isVisible = sitesTreeview.SelectedList != null; //&& sitesTreeview.SelectedSiteInfo.IsO365Connection;
            queryButton.Visible = sitesTreeview.SelectedList != null;
            getListItemsButton.Visible = isVisible;
            //getListItemChangesButton.Visible = isVisible;
            //getListItemChangesSinceButton.Visible = isVisible;
            //updateListItemsButton.Visible = isVisible;
        }

        private async void MainFormShown(object sender, EventArgs e)
        {
            await ShowConnectToSiteDialog();
        }
    }
}
