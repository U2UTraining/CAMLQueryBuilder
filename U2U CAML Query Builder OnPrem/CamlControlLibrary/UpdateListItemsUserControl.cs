using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using U2U.SharePoint.CAML;
using U2U.SharePoint.CAML.Enumerations;

namespace U2U.CamlControlLibrary
{
    /// <summary>
    /// Summary description for UpdateListItemsUserControl.
    /// </summary>
    public class UpdateListItemsUserControl : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.TabPage batchTabPage;
        private System.Windows.Forms.TabPage methodTabPage;
        private System.Windows.Forms.CheckBox onErrorCheckBox;
        private System.Windows.Forms.ComboBox onErrorComboBox;
        private System.Windows.Forms.CheckBox versionCheckBox;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.CheckBox viewCheckBox;
        private System.Windows.Forms.ComboBox viewComboBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Label commandLabel;
        private System.Windows.Forms.ComboBox commandComboBox;
        private System.Windows.Forms.ListBox fieldsListBox;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.TabControl updateListItemsTabControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView methodTreeview;
        private System.Windows.Forms.Button addFieldButton;
        private System.Windows.Forms.ComboBox valueComboBox;
        private TextBox RootFolderTextBox;
        private CheckBox RootFolderCheckBox;
        private TabPage foldersTabPage;
        private Button clearQueryButton;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private QueryInfo query;

        public Builder Builder { get; set; }

        public UpdateListItemsUserControl(QueryInfo queryInfo)
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            _initializing = true;
            try
            {
                query = queryInfo;
                Builder = new Builder(CamlTypes.UpdateListItems);

                // To create/upate/delete folderds
                // http://msdn2.microsoft.com/en-us/library/lists.lists.updatelistitems.aspx?PHPSESSID=tn8k5p1s508cop8gr43e1f34d2

                // fill the view combo box
                InitializeControl();
            }
            finally
            {
                _initializing = false;
            }
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
            this.updateListItemsTabControl = new System.Windows.Forms.TabControl();
            this.batchTabPage = new System.Windows.Forms.TabPage();
            this.clearQueryButton = new System.Windows.Forms.Button();
            this.RootFolderTextBox = new System.Windows.Forms.TextBox();
            this.RootFolderCheckBox = new System.Windows.Forms.CheckBox();
            this.viewComboBox = new System.Windows.Forms.ComboBox();
            this.viewCheckBox = new System.Windows.Forms.CheckBox();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.versionCheckBox = new System.Windows.Forms.CheckBox();
            this.onErrorComboBox = new System.Windows.Forms.ComboBox();
            this.onErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.methodTabPage = new System.Windows.Forms.TabPage();
            this.valueComboBox = new System.Windows.Forms.ComboBox();
            this.addFieldButton = new System.Windows.Forms.Button();
            this.methodTreeview = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this.fieldsListBox = new System.Windows.Forms.ListBox();
            this.commandComboBox = new System.Windows.Forms.ComboBox();
            this.commandLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.foldersTabPage = new System.Windows.Forms.TabPage();
            this.updateListItemsTabControl.SuspendLayout();
            this.batchTabPage.SuspendLayout();
            this.methodTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateListItemsTabControl
            // 
            this.updateListItemsTabControl.Controls.Add(this.batchTabPage);
            this.updateListItemsTabControl.Controls.Add(this.methodTabPage);
            this.updateListItemsTabControl.Controls.Add(this.foldersTabPage);
            this.updateListItemsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateListItemsTabControl.Location = new System.Drawing.Point(0, 0);
            this.updateListItemsTabControl.Name = "updateListItemsTabControl";
            this.updateListItemsTabControl.SelectedIndex = 0;
            this.updateListItemsTabControl.Size = new System.Drawing.Size(728, 232);
            this.updateListItemsTabControl.TabIndex = 0;
            // 
            // batchTabPage
            // 
            this.batchTabPage.Controls.Add(this.clearQueryButton);
            this.batchTabPage.Controls.Add(this.RootFolderTextBox);
            this.batchTabPage.Controls.Add(this.RootFolderCheckBox);
            this.batchTabPage.Controls.Add(this.viewComboBox);
            this.batchTabPage.Controls.Add(this.viewCheckBox);
            this.batchTabPage.Controls.Add(this.versionTextBox);
            this.batchTabPage.Controls.Add(this.versionCheckBox);
            this.batchTabPage.Controls.Add(this.onErrorComboBox);
            this.batchTabPage.Controls.Add(this.onErrorCheckBox);
            this.batchTabPage.Location = new System.Drawing.Point(4, 22);
            this.batchTabPage.Name = "batchTabPage";
            this.batchTabPage.Size = new System.Drawing.Size(720, 206);
            this.batchTabPage.TabIndex = 0;
            this.batchTabPage.Text = "Batch";
            this.batchTabPage.UseVisualStyleBackColor = true;
            // 
            // clearQueryButton
            // 
            this.clearQueryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearQueryButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clearQueryButton.Location = new System.Drawing.Point(633, 171);
            this.clearQueryButton.Name = "clearQueryButton";
            this.clearQueryButton.Size = new System.Drawing.Size(75, 23);
            this.clearQueryButton.TabIndex = 8;
            this.clearQueryButton.Text = "Clear";
            this.clearQueryButton.Click += new System.EventHandler(this.ClearQueryButtonClick);
            // 
            // RootFolderTextBox
            // 
            this.RootFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.RootFolderTextBox.Location = new System.Drawing.Point(103, 41);
            this.RootFolderTextBox.Name = "RootFolderTextBox";
            this.RootFolderTextBox.Size = new System.Drawing.Size(384, 20);
            this.RootFolderTextBox.TabIndex = 7;
            this.RootFolderTextBox.Validated += new System.EventHandler(this.RootFolderTextBox_Validated);
            // 
            // RootFolderCheckBox
            // 
            this.RootFolderCheckBox.Location = new System.Drawing.Point(10, 41);
            this.RootFolderCheckBox.Name = "RootFolderCheckBox";
            this.RootFolderCheckBox.Size = new System.Drawing.Size(88, 21);
            this.RootFolderCheckBox.TabIndex = 6;
            this.RootFolderCheckBox.Text = "Root Folder";
            this.RootFolderCheckBox.CheckedChanged += new System.EventHandler(this.RootFolderCheckBox_CheckedChanged);
            // 
            // viewComboBox
            // 
            this.viewComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.viewComboBox.Location = new System.Drawing.Point(103, 100);
            this.viewComboBox.Name = "viewComboBox";
            this.viewComboBox.Size = new System.Drawing.Size(384, 21);
            this.viewComboBox.TabIndex = 5;
            this.viewComboBox.SelectedIndexChanged += new System.EventHandler(this.viewComboBox_SelectedIndexChanged);
            // 
            // viewCheckBox
            // 
            this.viewCheckBox.Location = new System.Drawing.Point(10, 98);
            this.viewCheckBox.Name = "viewCheckBox";
            this.viewCheckBox.Size = new System.Drawing.Size(88, 24);
            this.viewCheckBox.TabIndex = 4;
            this.viewCheckBox.Text = "View Name";
            this.viewCheckBox.CheckedChanged += new System.EventHandler(this.viewCheckBox_CheckedChanged);
            // 
            // versionTextBox
            // 
            this.versionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.versionTextBox.Location = new System.Drawing.Point(103, 70);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(120, 20);
            this.versionTextBox.TabIndex = 3;
            this.versionTextBox.Validated += new System.EventHandler(this.versionTextBox_Validated);
            this.versionTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.versionTextBox_Validating);
            // 
            // versionCheckBox
            // 
            this.versionCheckBox.Location = new System.Drawing.Point(10, 68);
            this.versionCheckBox.Name = "versionCheckBox";
            this.versionCheckBox.Size = new System.Drawing.Size(88, 24);
            this.versionCheckBox.TabIndex = 2;
            this.versionCheckBox.Text = "List Version";
            this.versionCheckBox.CheckedChanged += new System.EventHandler(this.versionCheckBox_CheckedChanged);
            // 
            // onErrorComboBox
            // 
            this.onErrorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.onErrorComboBox.Items.AddRange(new object[] {
            "Continue",
            "Return"});
            this.onErrorComboBox.Location = new System.Drawing.Point(103, 14);
            this.onErrorComboBox.Name = "onErrorComboBox";
            this.onErrorComboBox.Size = new System.Drawing.Size(121, 21);
            this.onErrorComboBox.TabIndex = 1;
            this.onErrorComboBox.SelectedIndexChanged += new System.EventHandler(this.onErrorComboBox_SelectedIndexChanged);
            // 
            // onErrorCheckBox
            // 
            this.onErrorCheckBox.Location = new System.Drawing.Point(10, 14);
            this.onErrorCheckBox.Name = "onErrorCheckBox";
            this.onErrorCheckBox.Size = new System.Drawing.Size(72, 21);
            this.onErrorCheckBox.TabIndex = 0;
            this.onErrorCheckBox.Text = "On Error";
            this.onErrorCheckBox.CheckedChanged += new System.EventHandler(this.onErrorCheckBox_CheckedChanged);
            // 
            // methodTabPage
            // 
            this.methodTabPage.Controls.Add(this.valueComboBox);
            this.methodTabPage.Controls.Add(this.addFieldButton);
            this.methodTabPage.Controls.Add(this.methodTreeview);
            this.methodTabPage.Controls.Add(this.label1);
            this.methodTabPage.Controls.Add(this.valueTextBox);
            this.methodTabPage.Controls.Add(this.valueLabel);
            this.methodTabPage.Controls.Add(this.fieldsListBox);
            this.methodTabPage.Controls.Add(this.commandComboBox);
            this.methodTabPage.Controls.Add(this.commandLabel);
            this.methodTabPage.Controls.Add(this.removeButton);
            this.methodTabPage.Controls.Add(this.addButton);
            this.methodTabPage.Location = new System.Drawing.Point(4, 22);
            this.methodTabPage.Name = "methodTabPage";
            this.methodTabPage.Size = new System.Drawing.Size(720, 206);
            this.methodTabPage.TabIndex = 1;
            this.methodTabPage.Text = "Update List Items";
            this.methodTabPage.UseVisualStyleBackColor = true;
            // 
            // valueComboBox
            // 
            this.valueComboBox.Location = new System.Drawing.Point(474, 32);
            this.valueComboBox.Name = "valueComboBox";
            this.valueComboBox.Size = new System.Drawing.Size(136, 21);
            this.valueComboBox.TabIndex = 26;
            this.valueComboBox.Visible = false;
            // 
            // addFieldButton
            // 
            this.addFieldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFieldButton.Location = new System.Drawing.Point(618, 33);
            this.addFieldButton.Name = "addFieldButton";
            this.addFieldButton.Size = new System.Drawing.Size(24, 23);
            this.addFieldButton.TabIndex = 10;
            this.addFieldButton.Text = ">";
            this.addFieldButton.Click += new System.EventHandler(this.addFieldButton_Click);
            // 
            // methodTreeview
            // 
            this.methodTreeview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.methodTreeview.Location = new System.Drawing.Point(8, 8);
            this.methodTreeview.Name = "methodTreeview";
            this.methodTreeview.Size = new System.Drawing.Size(152, 160);
            this.methodTreeview.TabIndex = 9;
            this.methodTreeview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.methodTreeview_AfterSelect);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(297, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select the necessary fields from the list and set a value:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(474, 33);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(136, 20);
            this.valueTextBox.TabIndex = 7;
            // 
            // valueLabel
            // 
            this.valueLabel.Location = new System.Drawing.Point(426, 32);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(40, 23);
            this.valueLabel.TabIndex = 6;
            this.valueLabel.Text = "Value:";
            this.valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fieldsListBox
            // 
            this.fieldsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fieldsListBox.Location = new System.Drawing.Point(300, 32);
            this.fieldsListBox.Name = "fieldsListBox";
            this.fieldsListBox.Size = new System.Drawing.Size(120, 134);
            this.fieldsListBox.TabIndex = 5;
            this.fieldsListBox.SelectedIndexChanged += new System.EventHandler(this.fieldsListBox_SelectedIndexChanged);
            // 
            // commandComboBox
            // 
            this.commandComboBox.Items.AddRange(new object[] {
            "Update",
            "New",
            "Delete"});
            this.commandComboBox.Location = new System.Drawing.Point(166, 32);
            this.commandComboBox.Name = "commandComboBox";
            this.commandComboBox.Size = new System.Drawing.Size(121, 21);
            this.commandComboBox.TabIndex = 4;
            this.commandComboBox.SelectedIndexChanged += new System.EventHandler(this.commandComboBox_SelectedIndexChanged);
            // 
            // commandLabel
            // 
            this.commandLabel.Location = new System.Drawing.Point(166, 8);
            this.commandLabel.Name = "commandLabel";
            this.commandLabel.Size = new System.Drawing.Size(128, 24);
            this.commandLabel.TabIndex = 3;
            this.commandLabel.Text = "Select a command:";
            this.commandLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Location = new System.Drawing.Point(85, 174);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(8, 174);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(71, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // foldersTabPage
            // 
            this.foldersTabPage.Location = new System.Drawing.Point(4, 22);
            this.foldersTabPage.Name = "foldersTabPage";
            this.foldersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.foldersTabPage.Size = new System.Drawing.Size(720, 206);
            this.foldersTabPage.TabIndex = 2;
            this.foldersTabPage.Text = "Update Folders";
            this.foldersTabPage.UseVisualStyleBackColor = true;
            // 
            // UpdateListItemsUserControl
            // 
            this.Controls.Add(this.updateListItemsTabControl);
            this.Name = "UpdateListItemsUserControl";
            this.Size = new System.Drawing.Size(728, 232);
            this.updateListItemsTabControl.ResumeLayout(false);
            this.batchTabPage.ResumeLayout(false);
            this.batchTabPage.PerformLayout();
            this.methodTabPage.ResumeLayout(false);
            this.methodTabPage.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private bool _initializing = false;
        private int methodCounter = 0;
        private MethodObject methodObject = null;
        private FieldObject fieldObject = null;
        private TreeNode methodNode = null;

        #region Public Properties
        //public U2U.SharePoint.CAML.Client.SharePointSite SharepointSite
        //{
        //    get { return _sharepointSite; }
        //    set
        //    {
        //        if (_sharepointSite.SiteUrl != value.SiteUrl)
        //            _sharepointSite = value;
        //    }
        //}

        //public string ListName
        //{
        //    get { return listName; }
        //    set
        //    {
        //        listName = value;
        //        if (_sharepointSite != null)
        //            InitializeControl();
        //    }
        //}

        //public XmlDocument CamlDocument
        //{
        //    get { return builder.CamlDocument; }
        //    set
        //    {
        //        builder = new U2U.SharePoint.CAML.Builder(value);
        //        FillUserControl();
        //        CAMLEvent(listName, builder.CamlDocument);
        //    }
        //}
        #endregion

        #region Initialize Control
        private void InitializeControl()
        {
            viewComboBox.Items.Clear();
            foreach (var view in query.Site.GetViews(query.List.Name))
            {
                viewComboBox.Items.Add(view);
            }

            // initialize the Batch tab
            this.onErrorComboBox.SelectedIndex = 0;
            if (this.viewComboBox.Items.Count > 0)
                this.viewComboBox.SelectedIndex = 0;

            // uncheck the checkboxes
            onErrorCheckBox.Checked = false;
            versionCheckBox.Checked = false;
            RootFolderCheckBox.Checked = false;
            viewCheckBox.Checked = false;

            // disable the comboboxes
            this.onErrorComboBox.Enabled = false;
            this.versionTextBox.Enabled = false;
            this.RootFolderTextBox.Enabled = false;
            this.viewComboBox.Enabled = false;

            // initialize the Method tab
            this.methodTreeview.Nodes.Clear();
            this.commandComboBox.SelectedIndex = 0;
            this.commandComboBox.Enabled = false;
            this.valueComboBox.Items.Clear();

            UtilityFunctions.FillFields(fieldsListBox, query);
            this.fieldsListBox.Enabled = false;
            this.updateListItemsTabControl.SelectedTab = this.updateListItemsTabControl.TabPages[U2U.Constants.UserControls.UpdateListItemsControl.TabControl.BatchTab];
        }

        #endregion

        #region FillUserControl
        private void FillUserControl()
        {
            _initializing = true;
            XmlNode node = Builder.CamlDocument.SelectSingleNode("//" + Caml.Constants.Batch.Tag);

            // fill out the batch tab
            XmlAttribute att = (XmlAttribute)node.Attributes.GetNamedItem(Caml.Constants.Batch.OnError);
            if (att != null)
            {
                onErrorCheckBox.Checked = true;
                for (int i = 0; i < onErrorComboBox.Items.Count; i++)
                {
                    if (onErrorComboBox.Items[i].ToString() == att.Value)
                    {
                        onErrorComboBox.Enabled = true;
                        onErrorComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            att = (XmlAttribute)node.Attributes.GetNamedItem(Caml.Constants.Batch.ViewName);
            if (att != null)
            {
                viewCheckBox.Checked = true;
                for (int i = 0; i < viewComboBox.Items.Count; i++)
                {
                    if (viewComboBox.Items[i].ToString() == att.Value)
                    {
                        viewComboBox.Enabled = true;
                        viewComboBox.SelectedIndex = i;
                        break;
                    }
                }
            }

            att = (XmlAttribute)node.Attributes.GetNamedItem(Caml.Constants.Batch.ListVersion);
            if (att != null)
            {
                versionCheckBox.Checked = true;
                versionTextBox.Enabled = true;
                versionTextBox.Text = att.Value;
            }

            att = (XmlAttribute)node.Attributes.GetNamedItem(Caml.Constants.Batch.RootFolder);
            if (att != null)
            {
                RootFolderCheckBox.Checked = true;
                RootFolderTextBox.Enabled = true;
                RootFolderTextBox.Text = att.Value;
            }

            // fill out the method tab
            methodTreeview.Nodes.Clear();
            XmlNodeList nodelist = Builder.CamlDocument.SelectNodes("//" + Caml.Constants.Batch.Method.Tag);
            if (nodelist.Count > 0)
            {
                methodTreeview.Enabled = true;
                commandComboBox.Enabled = true;
                fieldsListBox.Enabled = true;
                valueTextBox.Enabled = true;
                addFieldButton.Enabled = true;
                valueComboBox.Visible = false;
            }

            foreach (XmlNode mnode in nodelist)
            {
                TreeNode tnode = null;
                att = (XmlAttribute)mnode.Attributes.GetNamedItem(Caml.Constants.Batch.Method.ID);
                if (att != null)
                {
                    XmlAttribute cmdatt = (XmlAttribute)mnode.Attributes.GetNamedItem(Caml.Constants.Batch.Method.Command.Tag);
                    if (cmdatt != null)
                    {
                        for (int i = 0; i < commandComboBox.Items.Count; i++)
                        {
                            if (commandComboBox.Items[i].ToString() == cmdatt.Value)
                                commandComboBox.SelectedIndex = i;
                        }
                    }
                    methodObject = new MethodObject(att.Value, commandComboBox.SelectedItem.ToString());
                    tnode = new TreeNode(methodObject.ToString());
                    tnode.Tag = methodObject;
                }
                else
                    tnode = new TreeNode(mnode.InnerText);
                methodTreeview.Nodes.Add(tnode);

                foreach (XmlNode child in mnode.ChildNodes)
                {
                    XmlAttribute nameatt = (XmlAttribute)child.Attributes.GetNamedItem(Caml.Constants.Batch.Method.Field.Name);
                    if (nameatt != null)
                    {
                        for (int i = 0; i < fieldsListBox.Items.Count; i++)
                        {
                            FieldObject item = (FieldObject)fieldsListBox.Items[i];
                            if (item.InternalName == nameatt.Value)
                            {
                                fieldsListBox.SelectedIndex = i;
                                break;
                            }
                        }
                        valueTextBox.Text = child.InnerText;

                        FieldObject fo = new FieldObject(((FieldObject)fieldsListBox.SelectedItem).DisplayName,
                            ((FieldObject)fieldsListBox.SelectedItem).ID,
                            ((FieldObject)fieldsListBox.SelectedItem).InternalName,
                            ((FieldObject)fieldsListBox.SelectedItem).TypeAsString,
                            valueTextBox.Text);

                        methodObject.AddFieldObject(fo);
                        // add the node to the method list box
                        TreeNode cnode = new TreeNode(((FieldObject)fieldsListBox.SelectedItem).DisplayName);
                        cnode.Tag = fo;
                        tnode.Nodes.Add(cnode);
                    }
                }
            }

            this.methodTreeview.ExpandAll();
            _initializing = true;
        }
        #endregion

        #region CheckBox events
        private void onErrorCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (_initializing) return;
            if (onErrorCheckBox.Checked)
            {
                onErrorComboBox.Enabled = true;
                Builder.UpdateBatchNode(Caml.Constants.Batch.OnError, onErrorComboBox.SelectedItem.ToString());
            }
            else
            {
                onErrorComboBox.Enabled = false;
                Builder.RemoveBatchNode(Caml.Constants.Batch.OnError);
            }
            OnQueryExpressionChanged();
        }

        private void RootFolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_initializing) return;
            if (RootFolderCheckBox.Checked)
            {
                RootFolderTextBox.Enabled = true;
                Builder.UpdateBatchNode(Caml.Constants.Batch.RootFolder, RootFolderTextBox.Text);
            }
            else
            {
                RootFolderTextBox.Enabled = false;
                Builder.RemoveBatchNode(Caml.Constants.Batch.RootFolder);
            }
            OnQueryExpressionChanged();
        }

        private void versionCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (_initializing) return;
            if (versionCheckBox.Checked)
            {
                versionTextBox.Enabled = true;
                Builder.UpdateBatchNode(Caml.Constants.Batch.ListVersion, versionTextBox.Text);
            }
            else
            {
                versionTextBox.Enabled = false;
                Builder.RemoveBatchNode(Caml.Constants.Batch.ListVersion);
            }
            OnQueryExpressionChanged();
        }

        private void viewCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            if (_initializing) return;
            if (viewCheckBox.Checked)
            {
                viewComboBox.Enabled = true;
                Builder.UpdateBatchNode(Caml.Constants.Batch.ViewName, viewComboBox.SelectedItem.ToString());
            }
            else
            {
                viewComboBox.Enabled = false;
                Builder.RemoveBatchNode(Caml.Constants.Batch.ViewName);
            }
            OnQueryExpressionChanged();
        }
        #endregion

        public event EventHandler QueryExpressionChanged;

        protected void OnQueryExpressionChanged()
        {
            if (QueryExpressionChanged != null)
            {
                QueryExpressionChanged(this, new EventArgs());
            }
        }


        #region "Combobox events"
        private void fieldsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_initializing) return;
            if (fieldsListBox.SelectedIndex > -1)
            {
                // empty the value text box
                valueTextBox.Text = string.Empty;
                valueComboBox.Text = string.Empty;
                valueComboBox.Items.Clear();

                FieldObject fo = (FieldObject)fieldsListBox.SelectedItem;
                if (fo.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Lookup.ToString())
                {
                    this.valueTextBox.Visible = false;
                    this.valueComboBox.Visible = true;
                    UtilityFunctions.FillLookupComboBox(valueComboBox, query.Site, fo);
                }
                else if (fo.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Choice.ToString()
                    || fo.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.MultiChoice.ToString())
                {
                    this.valueTextBox.Visible = false;
                    this.valueComboBox.Visible = true;
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(fo.ChoiceList);
                    XmlNodeList list = xmlDoc.SelectNodes("//CHOICE");
                    foreach (XmlNode node in list)
                        valueComboBox.Items.Add(node.InnerText);
                    if (fo.DefaultChoice != string.Empty)
                        valueComboBox.Text = fo.DefaultChoice;
                }
                else
                {
                    this.valueTextBox.Visible = true;
                    this.valueComboBox.Visible = false;
                }
            }
        }
        #endregion

        #region "Add/Remove button events"
        private void addButton_Click(object sender, System.EventArgs e)
        {
            // enable the controls
            if (!commandComboBox.Enabled)
            {
                commandComboBox.Enabled = true;
                fieldsListBox.Enabled = true;
                valueTextBox.Enabled = true;
                valueTextBox.Text = string.Empty;
                valueComboBox.Text = string.Empty;
                valueComboBox.Visible = false;
            }
            methodCounter += 1;
            Builder.AddMethodNode(methodCounter, commandComboBox.SelectedItem.ToString());
            methodObject = new MethodObject(methodCounter.ToString(), commandComboBox.SelectedItem.ToString());
            methodNode = new TreeNode(methodObject.ToString());
            methodNode.Tag = methodObject;
            methodTreeview.Nodes.Add(methodNode);
            OnQueryExpressionChanged();
        }

        private void removeButton_Click(object sender, System.EventArgs e)
        {
            if (methodTreeview.SelectedNode == null)
            {
                return;
            }

            if (methodTreeview.SelectedNode.Tag is MethodObject)
            {
                methodObject = methodTreeview.SelectedNode.Tag as MethodObject;
                // remove the method from CAML
                Builder.RemoveMethodNode(Convert.ToInt32(methodObject.Id));
                methodObject = null;
            }
            else if (methodTreeview.SelectedNode.Tag is FieldObject)
            {
                fieldObject = methodTreeview.SelectedNode.Tag as FieldObject;
                // remove the field from CAML en the method object
                Builder.RemoveFieldNode(Convert.ToInt32(methodObject.Id), fieldObject.InternalName);
                methodObject.RemoveFieldObject(fieldObject);
                fieldObject = null;
            }
            valueTextBox.Text = string.Empty;
            methodTreeview.SelectedNode.Remove();
            OnQueryExpressionChanged();
        }
        #endregion

        private void versionTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // TODO: validate the entry in the textbox		
            bool isValid = true;
            if (versionTextBox.Text.Length != 10)
                isValid = false;
            if (isValid && versionTextBox.Text.Substring(1, 1) != "." && versionTextBox.Text.Substring(3, 1) != "." && versionTextBox.Text.Substring(5, 1) != ".")
                isValid = false;
            if (!isValid)
                throw new ApplicationException("A version number should have the format N.N.N.NNNN");
        }

        private void versionTextBox_Validated(object sender, System.EventArgs e)
        {
            if (_initializing || inTreeviewSelect) return;
            // Add the version to the caml
            Builder.UpdateBatchNode(Caml.Constants.Batch.ListVersion, versionTextBox.Text);
            OnQueryExpressionChanged();
        }

        private void RootFolderTextBox_Validated(object sender, EventArgs e)
        {
            if (_initializing || inTreeviewSelect) return;
            // Add the root folder to the caml
            Builder.UpdateBatchNode(Caml.Constants.Batch.RootFolder, RootFolderTextBox.Text);
            OnQueryExpressionChanged();
        }

        private void onErrorComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_initializing || inTreeviewSelect) return;
            Builder.UpdateBatchNode(Caml.Constants.Batch.OnError, onErrorComboBox.SelectedItem.ToString());
            OnQueryExpressionChanged();
        }

        private void viewComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_initializing || inTreeviewSelect) return;
            Builder.UpdateBatchNode(Caml.Constants.Batch.ViewName, viewComboBox.SelectedItem.ToString());
            OnQueryExpressionChanged();
        }

        private void commandComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (_initializing || inTreeviewSelect) return;
            Builder.UpdateMethodNode(methodCounter, commandComboBox.SelectedItem.ToString());
            methodObject.Command = commandComboBox.SelectedItem.ToString();
            OnQueryExpressionChanged();
        }

        private bool inTreeviewSelect;

        private void methodTreeview_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            inTreeviewSelect = true;
            try
            {
                if (e.Node.Tag is MethodObject)
                {
                    methodObject = e.Node.Tag as MethodObject;
                    methodNode = e.Node;
                }
                else
                {
                    fieldObject = e.Node.Tag as FieldObject;
                    methodObject = e.Node.Parent.Tag as MethodObject;
                    methodNode = e.Node.Parent;
                    for (int i = 0; i < fieldsListBox.Items.Count; i++)
                    {
                        if (fieldObject.InternalName == ((FieldObject)fieldsListBox.Items[i]).InternalName)
                        {
                            fieldsListBox.SelectedIndex = i;
                        }
                    }
                    if (fieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Lookup.ToString()
                        || fieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Choice.ToString()
                        || fieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.MultiChoice.ToString())
                    {
                        valueTextBox.Visible = false;
                        valueComboBox.Visible = true;
                        valueComboBox.Text = fieldObject.FieldValue;
                    }
                    else
                    {
                        valueComboBox.Visible = false;
                        valueTextBox.Visible = true;
                        valueTextBox.Text = fieldObject.FieldValue;
                    }
                }
                commandComboBox.Text = methodObject.Command;
            }
            finally
            {
                inTreeviewSelect = false;
            }
        }

        private void addFieldButton_Click(object sender, System.EventArgs e)
        {
            string fieldValue = string.Empty;
            if (valueTextBox.Visible)
                fieldValue = valueTextBox.Text;
            else if (valueComboBox.Visible)
                fieldValue = valueComboBox.Text;

            if (fieldsListBox.SelectedIndex > -1 && fieldValue != string.Empty)
            {
                // create the CAML node
                Builder.AddFieldNode(Convert.ToInt32(methodObject.Id), ((FieldObject)fieldsListBox.SelectedItem).InternalName, fieldValue);
                // check if this field isn't already added to the current method
                bool isFound = false;
                if (methodObject.FieldObjects != null)
                {
                    foreach (FieldObject fo in methodObject.FieldObjects)
                    {
                        if (fo.InternalName == ((FieldObject)fieldsListBox.SelectedItem).InternalName)
                        {
                            isFound = true;
                            fieldObject = fo;
                            fo.FieldValue = fieldValue;
                        }
                    }
                }
                // if this field is new for this method object, add the field to the Method object
                if (!isFound)
                {
                    FieldObject fo = new FieldObject(((FieldObject)fieldsListBox.SelectedItem).DisplayName,
                        ((FieldObject)fieldsListBox.SelectedItem).ID,
                        ((FieldObject)fieldsListBox.SelectedItem).InternalName,
                        ((FieldObject)fieldsListBox.SelectedItem).TypeAsString, fieldValue);
                    methodObject.AddFieldObject(fo);
                    // add the node to the method list box
                    TreeNode node = new TreeNode(((FieldObject)fieldsListBox.SelectedItem).DisplayName);
                    node.Tag = fo;
                    methodNode.Nodes.Add(node);
                    methodTreeview.ExpandAll();
                }
                OnQueryExpressionChanged();
            }
        }

        private void ClearQueryButtonClick(object sender, EventArgs e)
        {
            // clear the controls
            InitializeControl();

            // clear the variables
            methodCounter = 0;
            methodObject = null;
            fieldObject = null;
            methodNode = null;
            if (Builder != null)
            {
                // empty the caml xml document
                Builder.Clear();
                OnQueryExpressionChanged();
            }
        }

        public XmlNode BuildQueryExpression(Builder builder)
        {
            return builder.BatchNode;
        }
    }
}
