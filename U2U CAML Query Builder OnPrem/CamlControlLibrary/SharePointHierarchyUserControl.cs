namespace U2U.CamlControlLibrary
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Forms;
    using System.Xml;
    using U2U.SharePoint.CAML;
    using U2U.SharePoint.CAML.Enumerations;
    using U2U.Constants;

    /// <summary>
    /// Summary description for SharePointHierarchyUserControl.
    /// </summary>
    public class SharePointHierarchyUserControl : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenu clientContextMenu;
        private System.Windows.Forms.MenuItem updateListItemsMenuItem;
        private System.Windows.Forms.ContextMenu serverContextMenu;
        private System.Windows.Forms.MenuItem getListItemsMenuItem;
        private System.Windows.Forms.MenuItem queryMenuItem;
        private System.Windows.Forms.MenuItem clientQueryMenuItem;
        private MenuItem getListItemChangesMenuItem;
        private MenuItem getListItemChangesSinceTokenMenuItem;
        private TreeView sharePointHierarchyTreeview;
        private System.ComponentModel.IContainer components;

        public SharePointHierarchyUserControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call
            BindContextMenu();
            sharePointHierarchyTreeview.Sorted = true;
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharePointHierarchyUserControl));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.clientContextMenu = new System.Windows.Forms.ContextMenu();
            this.clientQueryMenuItem = new System.Windows.Forms.MenuItem();
            this.getListItemsMenuItem = new System.Windows.Forms.MenuItem();
            this.getListItemChangesMenuItem = new System.Windows.Forms.MenuItem();
            this.getListItemChangesSinceTokenMenuItem = new System.Windows.Forms.MenuItem();
            this.updateListItemsMenuItem = new System.Windows.Forms.MenuItem();
            this.serverContextMenu = new System.Windows.Forms.ContextMenu();
            this.queryMenuItem = new System.Windows.Forms.MenuItem();
            this.sharePointHierarchyTreeview = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "Web.png");
            this.imageList1.Images.SetKeyName(15, "");
            // 
            // clientContextMenu
            // 
            this.clientContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.clientQueryMenuItem,
            this.getListItemsMenuItem,
            this.getListItemChangesMenuItem,
            this.getListItemChangesSinceTokenMenuItem,
            this.updateListItemsMenuItem});
            // 
            // clientQueryMenuItem
            // 
            this.clientQueryMenuItem.Index = 0;
            this.clientQueryMenuItem.Text = "new Query ...";
            this.clientQueryMenuItem.Click += new System.EventHandler(this.clientQueryMenuItem_Click);
            // 
            // getListItemsMenuItem
            // 
            this.getListItemsMenuItem.Index = 1;
            this.getListItemsMenuItem.Text = "GetListItems";
            this.getListItemsMenuItem.Click += new System.EventHandler(this.getListItemsMenuItem_Click);
            // 
            // getListItemChangesMenuItem
            // 
            this.getListItemChangesMenuItem.Index = 2;
            this.getListItemChangesMenuItem.Text = "GetListItemChanges";
            this.getListItemChangesMenuItem.Click += new System.EventHandler(this.getListItemChangesMenuItem_Click);
            // 
            // getListItemChangesSinceTokenMenuItem
            // 
            this.getListItemChangesSinceTokenMenuItem.Index = 3;
            this.getListItemChangesSinceTokenMenuItem.Text = "GetListItemChangesSinceToken";
            this.getListItemChangesSinceTokenMenuItem.Click += new System.EventHandler(this.getListItemChangesSinceTokenMenuItem_Click);
            // 
            // updateListItemsMenuItem
            // 
            this.updateListItemsMenuItem.Index = 4;
            this.updateListItemsMenuItem.Text = "UpdateListItems";
            this.updateListItemsMenuItem.Click += new System.EventHandler(this.updateListItemsMenuItem_Click);
            // 
            // serverContextMenu
            // 
            this.serverContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.queryMenuItem});
            // 
            // queryMenuItem
            // 
            this.queryMenuItem.Index = 0;
            this.queryMenuItem.Text = "New Query ...";
            this.queryMenuItem.Click += new System.EventHandler(this.queryMenuItem_Click);
            // 
            // sharePointHierarchyTreeview
            // 
            this.sharePointHierarchyTreeview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sharePointHierarchyTreeview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sharePointHierarchyTreeview.HideSelection = false;
            this.sharePointHierarchyTreeview.ImageIndex = 0;
            this.sharePointHierarchyTreeview.ImageList = this.imageList1;
            this.sharePointHierarchyTreeview.Location = new System.Drawing.Point(0, 0);
            this.sharePointHierarchyTreeview.Name = "sharePointHierarchyTreeview";
            this.sharePointHierarchyTreeview.SelectedImageIndex = 0;
            this.sharePointHierarchyTreeview.Size = new System.Drawing.Size(296, 527);
            this.sharePointHierarchyTreeview.TabIndex = 14;
            this.sharePointHierarchyTreeview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.sharePointHierarchyTreeview_AfterSelect);
            this.sharePointHierarchyTreeview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeviewMouseDown);
            // 
            // SharePointHierarchyUserControl
            // 
            this.Controls.Add(this.sharePointHierarchyTreeview);
            this.Name = "SharePointHierarchyUserControl";
            this.Size = new System.Drawing.Size(296, 527);
            this.ResumeLayout(false);

        }

        #endregion

        public event EventHandler<SelectedEventArgs> TreeviewClickEvent;

        private TreeNode _selectedTreeNode = null;

        public QueryInfo SelectedSiteInfo { get; set; }

        public CamlTypes SelectedQueryType { get; set; }

        public ListInfo SelectedList { get; set; }

        public ISite SelectedSite { get; set; }

        public void Connect(QueryInfo queryInfo)
        {
            foreach (TreeNode node in sharePointHierarchyTreeview.Nodes)
            {
                QueryInfo siteInfo = node.Tag as QueryInfo;
                if (siteInfo != null && siteInfo.Equals(queryInfo))
                {
                    sharePointHierarchyTreeview.SelectedNode = node;
                    return;
                }
            }

            sharePointHierarchyTreeview.Nodes.Add(AddWebHierarchy(queryInfo));
        }

        public void Disconnect()
        {
            if (SelectedSiteInfo != null)
            {
                foreach (TreeNode node in sharePointHierarchyTreeview.Nodes)
                {
                    QueryInfo siteInfo = node.Tag as QueryInfo;
                    if (siteInfo != null && siteInfo == SelectedSiteInfo)
                    {
                        node.Remove();
                        SelectedList = null;
                        SelectedSite = null;
                        SelectedSiteInfo = null;
                        _selectedTreeNode = null;
                        break;
                    }
                }
            }
        }

        private void BindContextMenu()
        {
            sharePointHierarchyTreeview.ContextMenu = clientContextMenu;
        }

        private TreeNode AddWebHierarchy(QueryInfo queryInfo)
        {
            TreeNode siteNode = new TreeNode(queryInfo.Site.Title)
            {
                Tag = queryInfo,
                ImageIndex = (int)ListImages.WEBGIF,
                SelectedImageIndex = (int)ListImages.WEBGIF,
            };

            TreeNode listTitleNode = new TreeNode(Constants.UserControls.SharePointHierarchy.Nodes.Lists)
            {
                ImageIndex = (int)ListImages.LISTGIF,
                SelectedImageIndex = (int)ListImages.LISTGIF
            };
            listTitleNode.Expand();

            siteNode.Nodes.Add(listTitleNode);
            siteNode.Expand();

            // add lists with there fields and views
            GetListNodes(queryInfo, listTitleNode);
            GetSubWebs(queryInfo, siteNode);

            siteNode.Expand();

            return siteNode;
        }

        private void GetSubWebs(QueryInfo queryInfo, TreeNode siteNode)
        {
            TreeNode webTitleNode = null;
            Collection<QueryInfo> sites = queryInfo.Site.GetSites();
            if (sites.Count > 0)
            {
                webTitleNode = new TreeNode(Constants.UserControls.SharePointHierarchy.Nodes.SubWebs);
                siteNode.Nodes.Add(webTitleNode);
                foreach (var site in sites)
                {
                    webTitleNode.Nodes.Add(new TreeNode(site.Title + " (" + site.SharePointUri + ")")
                    {
                        Tag = site,
                        ImageIndex = (int)ListImages.WEBGIF,
                        SelectedImageIndex = (int)ListImages.WEBGIF
                    });
                }
            }
        }

        private static int GetImageIndex(string imageUrl)
        {
            int startIndex = imageUrl.LastIndexOf("/") + 1;
            int endIndex = imageUrl.IndexOf(".");
            if (endIndex != -1 && startIndex != -1 && endIndex > startIndex)
            {
                string imageName = imageUrl.Substring(startIndex, endIndex - startIndex);
                Type t = typeof(ListImages);
                foreach (System.Reflection.FieldInfo fi in t.GetFields())
                {
                    if (fi.Name.Equals(imageName, StringComparison.OrdinalIgnoreCase))
                    {
                        return (int)(ListImages)fi.GetValue(null);
                    }
                }
            }

            return 0;
        }

        //private TreeNode GetFieldNodes(string listName, XmlDocument doc, XmlNamespaceManager nsMgr)
        //{
        //    TreeNode fieldTitleNode = new TreeNode(U2U.Constants.UserControls.SharePointHierarchy.Nodes.Fields);
        //    try
        //    {
        //        //XmlNode fieldsXmlNode = ListsWSS.GetList(listName);
        //        XmlNodeList fieldNodeList = doc.SelectNodes("//def:List/def:Fields/def:Field", nsMgr);
        //        foreach (XmlNode fieldXmlNode in fieldNodeList)
        //        {
        //            XmlAttribute att = (XmlAttribute)fieldXmlNode.Attributes.GetNamedItem("Hidden");
        //            if (att == null || att.Value == "FALSE")
        //            {
        //                // add the field to the list
        //                att = (XmlAttribute)fieldXmlNode.Attributes.GetNamedItem("DisplayName");
        //                TreeNode fieldNode = new TreeNode(att.Value);
        //                att = (XmlAttribute)fieldXmlNode.Attributes.GetNamedItem("Name");
        //                fieldNode.Tag = att.Value;
        //                fieldTitleNode.Nodes.Add(fieldNode);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    return fieldTitleNode;
        //}

        //private TreeNode GetViewNodes(string listName, XmlDocument doc, XmlNamespaceManager nsMgr)
        //{
        //    TreeNode viewTitleNode = new TreeNode(U2U.Constants.UserControls.SharePointHierarchy.Nodes.Views);

        //    XmlNodeList viewNodeList = doc.SelectNodes("//def:View", nsMgr);
        //    foreach (XmlNode viewXmlNode in viewNodeList)
        //    {
        //        XmlAttribute nameAttribute = (XmlAttribute)viewXmlNode.Attributes.GetNamedItem("Name");
        //        XmlAttribute displayNameAttribute = (XmlAttribute)viewXmlNode.Attributes.GetNamedItem("DisplayName");
        //        if (nameAttribute != null && displayNameAttribute != null)
        //        {
        //            TreeNode viewNode = new TreeNode(displayNameAttribute.Value);
        //            viewNode.Tag = nameAttribute.Value;
        //            viewTitleNode.Nodes.Add(viewNode);
        //        }
        //    }

        //    return viewTitleNode;
        //}

        #region "SharePoint object model methods"

        private void GetListNodes(QueryInfo queryInfo, TreeNode listTitleNode)
        {
            foreach (var list in queryInfo.Site.GetLists())
            {
                TreeNode listNode = new TreeNode();
                listNode.Text = list.Name;
                listNode.Tag = list;

                int imageIndex = GetImageIndex(list.ImageUrl);
                listNode.ImageIndex = imageIndex;
                listNode.SelectedImageIndex = imageIndex;

                listTitleNode.Nodes.Add(listNode);
            }
        }

        #endregion

        #region Menu items

        private void queryMenuItem_Click(object sender, System.EventArgs e)
        {
            SelectedQueryType = CamlTypes.Query;
            RaiseListEvent();
        }

        private void clientQueryMenuItem_Click(object sender, System.EventArgs e)
        {
            SelectedQueryType = CamlTypes.Query;
            RaiseListEvent();
        }

        private void updateListItemsMenuItem_Click(object sender, System.EventArgs e)
        {
            SelectedQueryType = CamlTypes.UpdateListItems;
            RaiseListEvent();
        }

        private void getListItemsMenuItem_Click(object sender, System.EventArgs e)
        {
            SelectedQueryType = CamlTypes.GetListItems;
            RaiseListEvent();
        }

        private void getListItemChangesMenuItem_Click(object sender, EventArgs e)
        {
            SelectedQueryType = CamlTypes.GetListItemChanges;
            RaiseListEvent();
        }

        private void getListItemChangesSinceTokenMenuItem_Click(object sender, EventArgs e)
        {
            SelectedQueryType = CamlTypes.GetListItemChangesSinceToken;
            RaiseListEvent();
        }

        private void RaiseListEvent()
        {
            EvaluateSelection();
            if (TreeviewClickEvent != null)
            {
                TreeviewClickEvent(this, new SelectedEventArgs(SelectedSiteInfo, SelectedSite, SelectedList, SelectedQueryType));
            }
        }

        private void EvaluateSelection()
        {
            if (_selectedTreeNode != null)
            {
                SelectedList = _selectedTreeNode.Tag as ListInfo;
                GetSelectedSiteInfo();
            }
            else
            {
                SelectedList = null;
                SelectedSiteInfo = null;
                SelectedSiteInfo = null;
            }
        }

        private void GetSelectedSiteInfo()
        {
            SelectedSiteInfo = null;
            SelectedSite = null;
            if (_selectedTreeNode != null)
            {
                SelectedSiteInfo = _selectedTreeNode.Tag as QueryInfo;
                if (SelectedSiteInfo != null)
                {
                    SelectedSite = SelectedSiteInfo.Site;
                }
                else
                {
                    TreeNode node = _selectedTreeNode.Parent;
                    while (node != null && SelectedSiteInfo == null)
                    {
                        SelectedSiteInfo = node.Tag as QueryInfo;
                        node = node.Parent;
                    }
                }
            }
        }

        #endregion

        private void TreeviewMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _selectedTreeNode = sharePointHierarchyTreeview.GetNodeAt(e.X, e.Y);
                EvaluateSelection();
                clientQueryMenuItem.Visible = (SelectedList != null);
                queryMenuItem.Visible = (SelectedList != null);
                getListItemsMenuItem.Visible = (SelectedList != null) && SelectedSiteInfo.IsO365Connection;
                getListItemChangesMenuItem.Visible = (SelectedList != null) && SelectedSiteInfo.IsO365Connection;
                getListItemChangesSinceTokenMenuItem.Visible = (SelectedList != null) && SelectedSiteInfo.IsO365Connection;
                updateListItemsMenuItem.Visible = (SelectedList != null) && SelectedSiteInfo.IsO365Connection;
            }
        }

        private void sharePointHierarchyTreeview_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            _selectedTreeNode = e.Node;
            EvaluateSelection();
            OnSelected();
        }

        public event EventHandler<SelectedEventArgs> Selected;

        private void OnSelected()
        {
            if (Selected != null)
            {
                Selected(this, new SelectedEventArgs(SelectedSiteInfo, SelectedSite, SelectedList, SelectedQueryType));
            }
        }
    }

    public class SelectedEventArgs : EventArgs
    {
        public SelectedEventArgs()
            : base()
        {
        }

        public SelectedEventArgs(QueryInfo siteInfo, ISite site, ListInfo list, CamlTypes queryType)
            : base()
        {
            Site = site;
            SiteInfo = siteInfo;
            List = list;
            QueryType = queryType;
        }

        public ISite Site { get; set; }

        public ListInfo List { get; set; }

        public CamlTypes QueryType { get; set; }

        public QueryInfo SiteInfo { get; set; }
    }
}
