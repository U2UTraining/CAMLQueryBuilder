using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using U2U.SharePoint.CAML;
//using Microsoft.SharePoint;
using U2U.SharePoint.CAML.Enumerations;

namespace U2U.CamlControlLibrary
{
    /// <summary>
    /// Summary description for QueryUserControl.
    /// </summary>
    public class QueryUserControl : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.GroupBox queryGroupBox;
        private System.Windows.Forms.Button addOrderByButton;
        private System.Windows.Forms.Button addFieldButton;
        private System.Windows.Forms.ComboBox combinerComboBox;
        private System.Windows.Forms.ComboBox operatorComboBox;
        private System.Windows.Forms.Label valueLabel;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.ComboBox orderByComboBox;
        private System.Windows.Forms.CheckBox whereCheckBox;
        private System.Windows.Forms.CheckBox orderByCheckBox;
        private System.Windows.Forms.TreeView queryTreeview;
        private System.Windows.Forms.ContextMenuStrip treeviewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeMenuItem;
        private System.Windows.Forms.Button QueryOptionsButton;
        private System.Windows.Forms.Button QueryButton;
        private System.Windows.Forms.Button ViewFieldsButton;
        private System.Windows.Forms.ListBox fieldsListBox;
        private System.Windows.Forms.GroupBox viewFieldsGroupBox;
        private System.Windows.Forms.ListBox fieldsToListBox;
        private System.Windows.Forms.ListBox fieldsFromListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button removeAllButton;
        private System.Windows.Forms.Button addAllButton;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.CheckBox DateInUtcCheckBox;
        private System.Windows.Forms.CheckBox IncludeMandatoryColumnsCheckBox;
        private System.Windows.Forms.TextBox PagingTextBox;
        private System.Windows.Forms.Label pagingLabel;
        private System.Windows.Forms.TextBox dataTypeTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox valueComboBox;
        private System.Windows.Forms.DateTimePicker valueDateTimePicker;
        private System.Windows.Forms.GroupBox dateTimeGroupBox;
        private CheckBox FolderCheckBox;
        private CheckBox RecursiveCheckBox;
        private Button ContainsButton;
        private Button SinceButton;
        private GroupBox SinceGroupBox;
        private CheckBox SinceCheckBox;
        private GroupBox SinceDateGroupBox;
        private NumericUpDown SecondsUpDown;
        private Label TimeSeparator2Label;
        private NumericUpDown MinutesUpDown;
        private Label TimeSeparator1Label;
        private NumericUpDown HourUpDown;
        private Label TimeLabel;
        private DateTimePicker SinceDateTimePicker;
        private GroupBox ContainsGroupBox;
        private GroupBox ContainsDateTimeGroupBox;
        private DateTimePicker ContainsValueDateTimePicker;
        private ComboBox ContainsValueComboBox;
        private Label label3;
        private Label label4;
        private TextBox ContainsDataTypeTextBox;
        private Button AddContainsFieldButton;
        private Label ContainsValueLabel;
        private TextBox ContainsValueTextBox;
        private ListBox ContainsFieldsListBox;
        private CheckBox ExpandUserFieldCheckBox;
        private CheckBox IncludePermissionsCheckBox;
        private CheckBox IncludeAttachmentUrlsCheckBox;
        private CheckBox IncludeAttachmentVersionCheckBox;
        private Label ExtraIdLabel;
        private TextBox ExtraIdsTextBox;
        private ComboBox OptimizeForComboBox;
        private Label OptimizeForLabel;
        private Button ChangeTokenButton;
        private GroupBox ChangeTokenGroupBox;
        private TextBox ChangeTokenTextBox;
        private CheckBox ChangeTokenCheckBox;
        private Button ClearButton;
        private Label QueryLabel;
        private RadioButton QueryByIdRadioButton;
        private RadioButton QueryByNameRadioButton;
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public QueryUserControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // TODO: Add any initialization after the InitializeComponent call

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
            this.queryGroupBox = new System.Windows.Forms.GroupBox();
            this.valueComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataTypeTextBox = new System.Windows.Forms.TextBox();
            this.fieldsListBox = new System.Windows.Forms.ListBox();
            this.addOrderByButton = new System.Windows.Forms.Button();
            this.addFieldButton = new System.Windows.Forms.Button();
            this.combinerComboBox = new System.Windows.Forms.ComboBox();
            this.operatorComboBox = new System.Windows.Forms.ComboBox();
            this.valueLabel = new System.Windows.Forms.Label();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.orderByComboBox = new System.Windows.Forms.ComboBox();
            this.whereCheckBox = new System.Windows.Forms.CheckBox();
            this.orderByCheckBox = new System.Windows.Forms.CheckBox();
            this.queryTreeview = new System.Windows.Forms.TreeView();
            this.treeviewContextMenu = new System.Windows.Forms.ContextMenuStrip();
            this.removeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimeGroupBox = new System.Windows.Forms.GroupBox();
            this.valueDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.OptimizeForComboBox = new System.Windows.Forms.ComboBox();
            this.OptimizeForLabel = new System.Windows.Forms.Label();
            this.ExtraIdsTextBox = new System.Windows.Forms.TextBox();
            this.ExtraIdLabel = new System.Windows.Forms.Label();
            this.IncludeAttachmentVersionCheckBox = new System.Windows.Forms.CheckBox();
            this.IncludeAttachmentUrlsCheckBox = new System.Windows.Forms.CheckBox();
            this.IncludePermissionsCheckBox = new System.Windows.Forms.CheckBox();
            this.ExpandUserFieldCheckBox = new System.Windows.Forms.CheckBox();
            this.FolderCheckBox = new System.Windows.Forms.CheckBox();
            this.RecursiveCheckBox = new System.Windows.Forms.CheckBox();
            this.PagingTextBox = new System.Windows.Forms.TextBox();
            this.pagingLabel = new System.Windows.Forms.Label();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.DateInUtcCheckBox = new System.Windows.Forms.CheckBox();
            this.IncludeMandatoryColumnsCheckBox = new System.Windows.Forms.CheckBox();
            this.viewFieldsGroupBox = new System.Windows.Forms.GroupBox();
            this.fieldsToListBox = new System.Windows.Forms.ListBox();
            this.fieldsFromListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.removeAllButton = new System.Windows.Forms.Button();
            this.addAllButton = new System.Windows.Forms.Button();
            this.QueryOptionsButton = new System.Windows.Forms.Button();
            this.QueryButton = new System.Windows.Forms.Button();
            this.ViewFieldsButton = new System.Windows.Forms.Button();
            this.ContainsButton = new System.Windows.Forms.Button();
            this.SinceButton = new System.Windows.Forms.Button();
            this.SinceGroupBox = new System.Windows.Forms.GroupBox();
            this.SinceCheckBox = new System.Windows.Forms.CheckBox();
            this.SinceDateGroupBox = new System.Windows.Forms.GroupBox();
            this.SecondsUpDown = new System.Windows.Forms.NumericUpDown();
            this.TimeSeparator2Label = new System.Windows.Forms.Label();
            this.MinutesUpDown = new System.Windows.Forms.NumericUpDown();
            this.TimeSeparator1Label = new System.Windows.Forms.Label();
            this.HourUpDown = new System.Windows.Forms.NumericUpDown();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.SinceDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ContainsGroupBox = new System.Windows.Forms.GroupBox();
            this.ContainsDateTimeGroupBox = new System.Windows.Forms.GroupBox();
            this.ContainsValueDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ContainsValueComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ContainsDataTypeTextBox = new System.Windows.Forms.TextBox();
            this.AddContainsFieldButton = new System.Windows.Forms.Button();
            this.ContainsValueLabel = new System.Windows.Forms.Label();
            this.ContainsValueTextBox = new System.Windows.Forms.TextBox();
            this.ContainsFieldsListBox = new System.Windows.Forms.ListBox();
            this.ChangeTokenButton = new System.Windows.Forms.Button();
            this.ChangeTokenGroupBox = new System.Windows.Forms.GroupBox();
            this.ChangeTokenTextBox = new System.Windows.Forms.TextBox();
            this.ChangeTokenCheckBox = new System.Windows.Forms.CheckBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.QueryLabel = new System.Windows.Forms.Label();
            this.QueryByIdRadioButton = new System.Windows.Forms.RadioButton();
            this.QueryByNameRadioButton = new System.Windows.Forms.RadioButton();
            this.queryGroupBox.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.viewFieldsGroupBox.SuspendLayout();
            this.SinceGroupBox.SuspendLayout();
            this.SinceDateGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HourUpDown)).BeginInit();
            this.ContainsGroupBox.SuspendLayout();
            this.ChangeTokenGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryGroupBox
            // 
            this.queryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.queryGroupBox.Controls.Add(this.valueComboBox);
            this.queryGroupBox.Controls.Add(this.label2);
            this.queryGroupBox.Controls.Add(this.label1);
            this.queryGroupBox.Controls.Add(this.dataTypeTextBox);
            this.queryGroupBox.Controls.Add(this.fieldsListBox);
            this.queryGroupBox.Controls.Add(this.addOrderByButton);
            this.queryGroupBox.Controls.Add(this.addFieldButton);
            this.queryGroupBox.Controls.Add(this.combinerComboBox);
            this.queryGroupBox.Controls.Add(this.operatorComboBox);
            this.queryGroupBox.Controls.Add(this.valueLabel);
            this.queryGroupBox.Controls.Add(this.valueTextBox);
            this.queryGroupBox.Controls.Add(this.orderByComboBox);
            this.queryGroupBox.Controls.Add(this.whereCheckBox);
            this.queryGroupBox.Controls.Add(this.orderByCheckBox);
            this.queryGroupBox.Controls.Add(this.queryTreeview);
            this.queryGroupBox.Controls.Add(this.dateTimeGroupBox);
            this.queryGroupBox.Controls.Add(this.valueDateTimePicker);
            this.queryGroupBox.Location = new System.Drawing.Point(0, 18);
            this.queryGroupBox.Name = "queryGroupBox";
            this.queryGroupBox.Size = new System.Drawing.Size(1038, 244);
            this.queryGroupBox.TabIndex = 1;
            this.queryGroupBox.TabStop = false;
            // 
            // valueComboBox
            // 
            this.valueComboBox.Location = new System.Drawing.Point(328, 80);
            this.valueComboBox.Name = "valueComboBox";
            this.valueComboBox.Size = new System.Drawing.Size(168, 21);
            this.valueComboBox.TabIndex = 25;
            this.valueComboBox.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(814, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(8, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = ")";
            this.label2.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(750, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(8, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "(";
            this.label1.Visible = false;
            // 
            // dataTypeTextBox
            // 
            this.dataTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTypeTextBox.Enabled = false;
            this.dataTypeTextBox.Location = new System.Drawing.Point(758, 80);
            this.dataTypeTextBox.Name = "dataTypeTextBox";
            this.dataTypeTextBox.Size = new System.Drawing.Size(56, 20);
            this.dataTypeTextBox.TabIndex = 22;
            this.dataTypeTextBox.Visible = false;
            // 
            // fieldsListBox
            // 
            this.fieldsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fieldsListBox.Location = new System.Drawing.Point(6, 11);
            this.fieldsListBox.Name = "fieldsListBox";
            this.fieldsListBox.Size = new System.Drawing.Size(144, 212);
            this.fieldsListBox.TabIndex = 21;
            this.fieldsListBox.SelectedIndexChanged += new System.EventHandler(this.fieldsListBox_SelectedIndexChanged);
            // 
            // addOrderByButton
            // 
            this.addOrderByButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addOrderByButton.Location = new System.Drawing.Point(504, 16);
            this.addOrderByButton.Name = "addOrderByButton";
            this.addOrderByButton.Size = new System.Drawing.Size(24, 23);
            this.addOrderByButton.TabIndex = 17;
            this.addOrderByButton.Text = ">";
            this.addOrderByButton.Visible = false;
            // 
            // addFieldButton
            // 
            this.addFieldButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addFieldButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.addFieldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFieldButton.Location = new System.Drawing.Point(822, 80);
            this.addFieldButton.Name = "addFieldButton";
            this.addFieldButton.Size = new System.Drawing.Size(24, 23);
            this.addFieldButton.TabIndex = 14;
            this.addFieldButton.Text = ">";
            this.addFieldButton.Visible = false;
            this.addFieldButton.Click += new System.EventHandler(this.addFieldButton_Click);
            // 
            // combinerComboBox
            // 
            this.combinerComboBox.Items.AddRange(new object[] {
            "Eq"});
            this.combinerComboBox.Location = new System.Drawing.Point(240, 48);
            this.combinerComboBox.Name = "combinerComboBox";
            this.combinerComboBox.Size = new System.Drawing.Size(56, 21);
            this.combinerComboBox.TabIndex = 13;
            this.combinerComboBox.Visible = false;
            // 
            // operatorComboBox
            // 
            this.operatorComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.operatorComboBox.Location = new System.Drawing.Point(160, 80);
            this.operatorComboBox.Name = "operatorComboBox";
            this.operatorComboBox.Size = new System.Drawing.Size(438, 21);
            this.operatorComboBox.TabIndex = 12;
            this.operatorComboBox.Visible = false;
            // 
            // valueLabel
            // 
            this.valueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valueLabel.Location = new System.Drawing.Point(598, 80);
            this.valueLabel.Name = "valueLabel";
            this.valueLabel.Size = new System.Drawing.Size(40, 24);
            this.valueLabel.TabIndex = 11;
            this.valueLabel.Text = "Value:";
            this.valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.valueLabel.Visible = false;
            // 
            // valueTextBox
            // 
            this.valueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.valueTextBox.Location = new System.Drawing.Point(328, 80);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(414, 20);
            this.valueTextBox.TabIndex = 10;
            this.valueTextBox.Visible = false;
            // 
            // orderByComboBox
            // 
            this.orderByComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.orderByComboBox.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.orderByComboBox.Location = new System.Drawing.Point(240, 16);
            this.orderByComboBox.Name = "orderByComboBox";
            this.orderByComboBox.Size = new System.Drawing.Size(414, 21);
            this.orderByComboBox.TabIndex = 9;
            this.orderByComboBox.Visible = false;
            this.orderByComboBox.SelectedIndexChanged += new System.EventHandler(this.orderByComboBox_SelectedIndexChanged);
            // 
            // whereCheckBox
            // 
            this.whereCheckBox.Location = new System.Drawing.Point(160, 48);
            this.whereCheckBox.Name = "whereCheckBox";
            this.whereCheckBox.Size = new System.Drawing.Size(73, 24);
            this.whereCheckBox.TabIndex = 8;
            this.whereCheckBox.Text = "Where";
            this.whereCheckBox.CheckedChanged += new System.EventHandler(this.whereCheckBox_CheckedChanged);
            // 
            // orderByCheckBox
            // 
            this.orderByCheckBox.Location = new System.Drawing.Point(160, 16);
            this.orderByCheckBox.Name = "orderByCheckBox";
            this.orderByCheckBox.Size = new System.Drawing.Size(80, 24);
            this.orderByCheckBox.TabIndex = 7;
            this.orderByCheckBox.Text = "Order By";
            this.orderByCheckBox.CheckedChanged += new System.EventHandler(this.orderByCheckBox_CheckedChanged);
            // 
            // queryTreeview
            // 
            this.queryTreeview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.queryTreeview.ContextMenuStrip = this.treeviewContextMenu;
            this.queryTreeview.Location = new System.Drawing.Point(854, 11);
            this.queryTreeview.Name = "queryTreeview";
            this.queryTreeview.Size = new System.Drawing.Size(176, 193);
            this.queryTreeview.TabIndex = 5;
            this.queryTreeview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.queryTreeview_MouseUp);
            this.queryTreeview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.queryTreeview_AfterSelect);
            // 
            // treeviewContextMenu
            // 
            this.treeviewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
            this.removeMenuItem});
            // 
            // removeMenuItem
            // 
            this.removeMenuItem.MergeIndex = 0;
            this.removeMenuItem.Text = "Remove";
            this.removeMenuItem.Click += new System.EventHandler(this.removeMenuItem_Click);
            // 
            // dateTimeGroupBox
            // 
            this.dateTimeGroupBox.Location = new System.Drawing.Point(160, 104);
            this.dateTimeGroupBox.Name = "dateTimeGroupBox";
            this.dateTimeGroupBox.Size = new System.Drawing.Size(368, 136);
            this.dateTimeGroupBox.TabIndex = 27;
            this.dateTimeGroupBox.TabStop = false;
            this.dateTimeGroupBox.Visible = false;
            // 
            // valueDateTimePicker
            // 
            this.valueDateTimePicker.Location = new System.Drawing.Point(328, 80);
            this.valueDateTimePicker.Name = "valueDateTimePicker";
            this.valueDateTimePicker.Size = new System.Drawing.Size(176, 20);
            this.valueDateTimePicker.TabIndex = 26;
            this.valueDateTimePicker.Visible = false;
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsGroupBox.Controls.Add(this.OptimizeForComboBox);
            this.optionsGroupBox.Controls.Add(this.OptimizeForLabel);
            this.optionsGroupBox.Controls.Add(this.ExtraIdsTextBox);
            this.optionsGroupBox.Controls.Add(this.ExtraIdLabel);
            this.optionsGroupBox.Controls.Add(this.IncludeAttachmentVersionCheckBox);
            this.optionsGroupBox.Controls.Add(this.IncludeAttachmentUrlsCheckBox);
            this.optionsGroupBox.Controls.Add(this.IncludePermissionsCheckBox);
            this.optionsGroupBox.Controls.Add(this.ExpandUserFieldCheckBox);
            this.optionsGroupBox.Controls.Add(this.FolderCheckBox);
            this.optionsGroupBox.Controls.Add(this.RecursiveCheckBox);
            this.optionsGroupBox.Controls.Add(this.PagingTextBox);
            this.optionsGroupBox.Controls.Add(this.pagingLabel);
            this.optionsGroupBox.Controls.Add(this.folderTextBox);
            this.optionsGroupBox.Controls.Add(this.DateInUtcCheckBox);
            this.optionsGroupBox.Controls.Add(this.IncludeMandatoryColumnsCheckBox);
            this.optionsGroupBox.Location = new System.Drawing.Point(398, 502);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(682, 233);
            this.optionsGroupBox.TabIndex = 25;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Query options";
            this.optionsGroupBox.Visible = false;
            // 
            // OptimizeForComboBox
            // 
            this.OptimizeForComboBox.FormattingEnabled = true;
            this.OptimizeForComboBox.Items.AddRange(new object[] {
            "ItemIds",
            "FolderUrls"});
            this.OptimizeForComboBox.Location = new System.Drawing.Point(84, 205);
            this.OptimizeForComboBox.Name = "OptimizeForComboBox";
            this.OptimizeForComboBox.Size = new System.Drawing.Size(163, 21);
            this.OptimizeForComboBox.TabIndex = 19;
            this.OptimizeForComboBox.SelectedIndexChanged += new System.EventHandler(this.OptimizeForComboBox_SelectedIndexChanged);
            // 
            // OptimizeForLabel
            // 
            this.OptimizeForLabel.Location = new System.Drawing.Point(16, 204);
            this.OptimizeForLabel.Name = "OptimizeForLabel";
            this.OptimizeForLabel.Size = new System.Drawing.Size(74, 21);
            this.OptimizeForLabel.TabIndex = 18;
            this.OptimizeForLabel.Text = "Optimize for:";
            this.OptimizeForLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExtraIdsTextBox
            // 
            this.ExtraIdsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ExtraIdsTextBox.Location = new System.Drawing.Point(83, 174);
            this.ExtraIdsTextBox.Name = "ExtraIdsTextBox";
            this.ExtraIdsTextBox.Size = new System.Drawing.Size(481, 20);
            this.ExtraIdsTextBox.TabIndex = 17;
            this.ExtraIdsTextBox.Visible = false;
            this.ExtraIdsTextBox.Leave += new System.EventHandler(this.ExtraIdsTextBox_Leave);
            // 
            // ExtraIdLabel
            // 
            this.ExtraIdLabel.Location = new System.Drawing.Point(16, 173);
            this.ExtraIdLabel.Name = "ExtraIdLabel";
            this.ExtraIdLabel.Size = new System.Drawing.Size(61, 21);
            this.ExtraIdLabel.TabIndex = 16;
            this.ExtraIdLabel.Text = "Extra Ids:";
            this.ExtraIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExtraIdLabel.Visible = false;
            // 
            // IncludeAttachmentVersionCheckBox
            // 
            this.IncludeAttachmentVersionCheckBox.Enabled = false;
            this.IncludeAttachmentVersionCheckBox.Location = new System.Drawing.Point(201, 94);
            this.IncludeAttachmentVersionCheckBox.Name = "IncludeAttachmentVersionCheckBox";
            this.IncludeAttachmentVersionCheckBox.Size = new System.Drawing.Size(155, 24);
            this.IncludeAttachmentVersionCheckBox.TabIndex = 15;
            this.IncludeAttachmentVersionCheckBox.Text = "Include attachment version";
            this.IncludeAttachmentVersionCheckBox.CheckedChanged += new System.EventHandler(this.IncludeAttachmentVersionCheckBox_CheckedChanged);
            // 
            // IncludeAttachmentUrlsCheckBox
            // 
            this.IncludeAttachmentUrlsCheckBox.Location = new System.Drawing.Point(201, 68);
            this.IncludeAttachmentUrlsCheckBox.Name = "IncludeAttachmentUrlsCheckBox";
            this.IncludeAttachmentUrlsCheckBox.Size = new System.Drawing.Size(146, 24);
            this.IncludeAttachmentUrlsCheckBox.TabIndex = 14;
            this.IncludeAttachmentUrlsCheckBox.Text = "Include attachment urls";
            this.IncludeAttachmentUrlsCheckBox.CheckedChanged += new System.EventHandler(this.IncludeAttachmentUrlsCheckBox_CheckedChanged);
            // 
            // IncludePermissionsCheckBox
            // 
            this.IncludePermissionsCheckBox.Location = new System.Drawing.Point(201, 42);
            this.IncludePermissionsCheckBox.Name = "IncludePermissionsCheckBox";
            this.IncludePermissionsCheckBox.Size = new System.Drawing.Size(146, 24);
            this.IncludePermissionsCheckBox.TabIndex = 13;
            this.IncludePermissionsCheckBox.Text = "Include permissions";
            this.IncludePermissionsCheckBox.CheckedChanged += new System.EventHandler(this.IncludePermissionsCheckBox_CheckedChanged);
            // 
            // ExpandUserFieldCheckBox
            // 
            this.ExpandUserFieldCheckBox.Location = new System.Drawing.Point(201, 18);
            this.ExpandUserFieldCheckBox.Name = "ExpandUserFieldCheckBox";
            this.ExpandUserFieldCheckBox.Size = new System.Drawing.Size(146, 24);
            this.ExpandUserFieldCheckBox.TabIndex = 12;
            this.ExpandUserFieldCheckBox.Text = "Expand user field";
            this.ExpandUserFieldCheckBox.CheckedChanged += new System.EventHandler(this.ExpandUserFieldCheckBox_CheckedChanged);
            // 
            // FolderCheckBox
            // 
            this.FolderCheckBox.Location = new System.Drawing.Point(16, 94);
            this.FolderCheckBox.Name = "FolderCheckBox";
            this.FolderCheckBox.Size = new System.Drawing.Size(104, 24);
            this.FolderCheckBox.TabIndex = 11;
            this.FolderCheckBox.Text = "Query subfolder ";
            this.FolderCheckBox.CheckedChanged += new System.EventHandler(this.FolderCheckBox_CheckedChanged);
            // 
            // RecursiveCheckBox
            // 
            this.RecursiveCheckBox.Location = new System.Drawing.Point(16, 68);
            this.RecursiveCheckBox.Name = "RecursiveCheckBox";
            this.RecursiveCheckBox.Size = new System.Drawing.Size(331, 24);
            this.RecursiveCheckBox.TabIndex = 10;
            this.RecursiveCheckBox.Text = "Query all folders and sub folders";
            this.RecursiveCheckBox.CheckedChanged += new System.EventHandler(this.RecursiveCheckBox_CheckedChanged);
            // 
            // PagingTextBox
            // 
            this.PagingTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PagingTextBox.Location = new System.Drawing.Point(83, 145);
            this.PagingTextBox.Name = "PagingTextBox";
            this.PagingTextBox.Size = new System.Drawing.Size(481, 20);
            this.PagingTextBox.TabIndex = 9;
            this.PagingTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.pagingTextBox_Validating);
            // 
            // pagingLabel
            // 
            this.pagingLabel.Location = new System.Drawing.Point(16, 144);
            this.pagingLabel.Name = "pagingLabel";
            this.pagingLabel.Size = new System.Drawing.Size(48, 21);
            this.pagingLabel.TabIndex = 8;
            this.pagingLabel.Text = "Paging:";
            this.pagingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // folderTextBox
            // 
            this.folderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.folderTextBox.Location = new System.Drawing.Point(30, 119);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(468, 20);
            this.folderTextBox.TabIndex = 5;
            this.folderTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.folderTextBox_Validating);
            // 
            // DateInUtcCheckBox
            // 
            this.DateInUtcCheckBox.Location = new System.Drawing.Point(16, 42);
            this.DateInUtcCheckBox.Name = "DateInUtcCheckBox";
            this.DateInUtcCheckBox.Size = new System.Drawing.Size(168, 24);
            this.DateInUtcCheckBox.TabIndex = 3;
            this.DateInUtcCheckBox.Text = "Date in UTC";
            this.DateInUtcCheckBox.CheckedChanged += new System.EventHandler(this.dateInUtcCheckBox_CheckedChanged);
            // 
            // IncludeMandatoryColumnsCheckBox
            // 
            this.IncludeMandatoryColumnsCheckBox.Location = new System.Drawing.Point(16, 18);
            this.IncludeMandatoryColumnsCheckBox.Name = "IncludeMandatoryColumnsCheckBox";
            this.IncludeMandatoryColumnsCheckBox.Size = new System.Drawing.Size(168, 24);
            this.IncludeMandatoryColumnsCheckBox.TabIndex = 2;
            this.IncludeMandatoryColumnsCheckBox.Text = "Include mandatory columns";
            this.IncludeMandatoryColumnsCheckBox.CheckedChanged += new System.EventHandler(this.includeMandatoryColumnsCheckBox_CheckedChanged);
            // 
            // viewFieldsGroupBox
            // 
            this.viewFieldsGroupBox.Controls.Add(this.fieldsToListBox);
            this.viewFieldsGroupBox.Controls.Add(this.fieldsFromListBox);
            this.viewFieldsGroupBox.Controls.Add(this.addButton);
            this.viewFieldsGroupBox.Controls.Add(this.removeButton);
            this.viewFieldsGroupBox.Controls.Add(this.removeAllButton);
            this.viewFieldsGroupBox.Controls.Add(this.addAllButton);
            this.viewFieldsGroupBox.Location = new System.Drawing.Point(23, 502);
            this.viewFieldsGroupBox.Name = "viewFieldsGroupBox";
            this.viewFieldsGroupBox.Size = new System.Drawing.Size(354, 244);
            this.viewFieldsGroupBox.TabIndex = 22;
            this.viewFieldsGroupBox.TabStop = false;
            this.viewFieldsGroupBox.Visible = false;
            // 
            // fieldsToListBox
            // 
            this.fieldsToListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fieldsToListBox.Location = new System.Drawing.Point(200, 16);
            this.fieldsToListBox.Name = "fieldsToListBox";
            this.fieldsToListBox.Size = new System.Drawing.Size(144, 186);
            this.fieldsToListBox.TabIndex = 23;
            // 
            // fieldsFromListBox
            // 
            this.fieldsFromListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fieldsFromListBox.Location = new System.Drawing.Point(8, 16);
            this.fieldsFromListBox.Name = "fieldsFromListBox";
            this.fieldsFromListBox.Size = new System.Drawing.Size(144, 186);
            this.fieldsFromListBox.TabIndex = 22;
            // 
            // addButton
            // 
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(160, 80);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(32, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = ">";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(160, 120);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(32, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "<";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // removeAllButton
            // 
            this.removeAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeAllButton.Location = new System.Drawing.Point(160, 160);
            this.removeAllButton.Name = "removeAllButton";
            this.removeAllButton.Size = new System.Drawing.Size(32, 23);
            this.removeAllButton.TabIndex = 2;
            this.removeAllButton.Text = "<<";
            this.removeAllButton.Click += new System.EventHandler(this.removeAllButton_Click);
            // 
            // addAllButton
            // 
            this.addAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAllButton.Location = new System.Drawing.Point(160, 40);
            this.addAllButton.Name = "addAllButton";
            this.addAllButton.Size = new System.Drawing.Size(32, 23);
            this.addAllButton.TabIndex = 0;
            this.addAllButton.Text = ">>";
            this.addAllButton.Click += new System.EventHandler(this.addAllButton_Click);
            // 
            // QueryOptionsButton
            // 
            this.QueryOptionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QueryOptionsButton.Location = new System.Drawing.Point(256, 0);
            this.QueryOptionsButton.Name = "QueryOptionsButton";
            this.QueryOptionsButton.Size = new System.Drawing.Size(88, 24);
            this.QueryOptionsButton.TabIndex = 23;
            this.QueryOptionsButton.Text = "Query Options";
            this.QueryOptionsButton.Click += new System.EventHandler(this.queryOptionsButton_Click);
            // 
            // QueryButton
            // 
            this.QueryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.QueryButton.Location = new System.Drawing.Point(72, 0);
            this.QueryButton.Name = "QueryButton";
            this.QueryButton.Size = new System.Drawing.Size(60, 24);
            this.QueryButton.TabIndex = 22;
            this.QueryButton.Text = "Query";
            this.QueryButton.Click += new System.EventHandler(this.queryButton_Click);
            // 
            // ViewFieldsButton
            // 
            this.ViewFieldsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ViewFieldsButton.Location = new System.Drawing.Point(0, 0);
            this.ViewFieldsButton.Name = "ViewFieldsButton";
            this.ViewFieldsButton.Size = new System.Drawing.Size(73, 24);
            this.ViewFieldsButton.TabIndex = 21;
            this.ViewFieldsButton.Text = "View Fields";
            this.ViewFieldsButton.Click += new System.EventHandler(this.viewFieldsButton_Click);
            // 
            // ContainsButton
            // 
            this.ContainsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ContainsButton.Location = new System.Drawing.Point(129, 0);
            this.ContainsButton.Name = "ContainsButton";
            this.ContainsButton.Size = new System.Drawing.Size(63, 24);
            this.ContainsButton.TabIndex = 26;
            this.ContainsButton.Text = "Contains";
            this.ContainsButton.Click += new System.EventHandler(this.ContainsButton_Click);
            // 
            // SinceButton
            // 
            this.SinceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SinceButton.Location = new System.Drawing.Point(191, 0);
            this.SinceButton.Name = "SinceButton";
            this.SinceButton.Size = new System.Drawing.Size(67, 24);
            this.SinceButton.TabIndex = 27;
            this.SinceButton.Text = "Since";
            this.SinceButton.Click += new System.EventHandler(this.SinceButton_Click);
            // 
            // SinceGroupBox
            // 
            this.SinceGroupBox.Controls.Add(this.SinceCheckBox);
            this.SinceGroupBox.Controls.Add(this.SinceDateGroupBox);
            this.SinceGroupBox.Location = new System.Drawing.Point(810, 288);
            this.SinceGroupBox.Name = "SinceGroupBox";
            this.SinceGroupBox.Size = new System.Drawing.Size(228, 240);
            this.SinceGroupBox.TabIndex = 28;
            this.SinceGroupBox.TabStop = false;
            // 
            // SinceCheckBox
            // 
            this.SinceCheckBox.AutoSize = true;
            this.SinceCheckBox.Location = new System.Drawing.Point(23, 29);
            this.SinceCheckBox.Name = "SinceCheckBox";
            this.SinceCheckBox.Size = new System.Drawing.Size(139, 17);
            this.SinceCheckBox.TabIndex = 28;
            this.SinceCheckBox.Text = "Retrieve changes as of:";
            this.SinceCheckBox.UseVisualStyleBackColor = true;
            this.SinceCheckBox.CheckedChanged += new System.EventHandler(this.SinceCheckBox_CheckedChanged);
            // 
            // SinceDateGroupBox
            // 
            this.SinceDateGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SinceDateGroupBox.Controls.Add(this.SecondsUpDown);
            this.SinceDateGroupBox.Controls.Add(this.TimeSeparator2Label);
            this.SinceDateGroupBox.Controls.Add(this.MinutesUpDown);
            this.SinceDateGroupBox.Controls.Add(this.TimeSeparator1Label);
            this.SinceDateGroupBox.Controls.Add(this.HourUpDown);
            this.SinceDateGroupBox.Controls.Add(this.TimeLabel);
            this.SinceDateGroupBox.Controls.Add(this.SinceDateTimePicker);
            this.SinceDateGroupBox.Enabled = false;
            this.SinceDateGroupBox.Location = new System.Drawing.Point(9, 65);
            this.SinceDateGroupBox.Name = "SinceDateGroupBox";
            this.SinceDateGroupBox.Size = new System.Drawing.Size(210, 135);
            this.SinceDateGroupBox.TabIndex = 27;
            this.SinceDateGroupBox.TabStop = false;
            this.SinceDateGroupBox.Text = "Since";
            // 
            // SecondsUpDown
            // 
            this.SecondsUpDown.Location = new System.Drawing.Point(157, 59);
            this.SecondsUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.SecondsUpDown.Name = "SecondsUpDown";
            this.SecondsUpDown.Size = new System.Drawing.Size(45, 20);
            this.SecondsUpDown.TabIndex = 6;
            this.SecondsUpDown.Click += new System.EventHandler(this.SecondsUpDown_Click);
            // 
            // TimeSeparator2Label
            // 
            this.TimeSeparator2Label.AutoSize = true;
            this.TimeSeparator2Label.Location = new System.Drawing.Point(145, 62);
            this.TimeSeparator2Label.Name = "TimeSeparator2Label";
            this.TimeSeparator2Label.Size = new System.Drawing.Size(10, 13);
            this.TimeSeparator2Label.TabIndex = 5;
            this.TimeSeparator2Label.Text = ":";
            // 
            // MinutesUpDown
            // 
            this.MinutesUpDown.Location = new System.Drawing.Point(99, 59);
            this.MinutesUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.MinutesUpDown.Name = "MinutesUpDown";
            this.MinutesUpDown.Size = new System.Drawing.Size(45, 20);
            this.MinutesUpDown.TabIndex = 4;
            this.MinutesUpDown.Click += new System.EventHandler(this.MinutesUpDown_Click);
            // 
            // TimeSeparator1Label
            // 
            this.TimeSeparator1Label.AutoSize = true;
            this.TimeSeparator1Label.Location = new System.Drawing.Point(88, 62);
            this.TimeSeparator1Label.Name = "TimeSeparator1Label";
            this.TimeSeparator1Label.Size = new System.Drawing.Size(10, 13);
            this.TimeSeparator1Label.TabIndex = 3;
            this.TimeSeparator1Label.Text = ":";
            // 
            // HourUpDown
            // 
            this.HourUpDown.Location = new System.Drawing.Point(42, 59);
            this.HourUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.HourUpDown.Name = "HourUpDown";
            this.HourUpDown.Size = new System.Drawing.Size(45, 20);
            this.HourUpDown.TabIndex = 2;
            this.HourUpDown.Click += new System.EventHandler(this.HourUpDown_Click);
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(7, 62);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(33, 13);
            this.TimeLabel.TabIndex = 1;
            this.TimeLabel.Text = "Time:";
            // 
            // SinceDateTimePicker
            // 
            this.SinceDateTimePicker.Location = new System.Drawing.Point(10, 27);
            this.SinceDateTimePicker.Name = "SinceDateTimePicker";
            this.SinceDateTimePicker.Size = new System.Drawing.Size(191, 20);
            this.SinceDateTimePicker.TabIndex = 0;
            this.SinceDateTimePicker.ValueChanged += new System.EventHandler(this.SinceDateTimePicker_ValueChanged);
            // 
            // ContainsGroupBox
            // 
            this.ContainsGroupBox.Controls.Add(this.ContainsDateTimeGroupBox);
            this.ContainsGroupBox.Controls.Add(this.ContainsValueDateTimePicker);
            this.ContainsGroupBox.Controls.Add(this.ContainsValueComboBox);
            this.ContainsGroupBox.Controls.Add(this.label3);
            this.ContainsGroupBox.Controls.Add(this.label4);
            this.ContainsGroupBox.Controls.Add(this.ContainsDataTypeTextBox);
            this.ContainsGroupBox.Controls.Add(this.AddContainsFieldButton);
            this.ContainsGroupBox.Controls.Add(this.ContainsValueLabel);
            this.ContainsGroupBox.Controls.Add(this.ContainsValueTextBox);
            this.ContainsGroupBox.Controls.Add(this.ContainsFieldsListBox);
            this.ContainsGroupBox.Location = new System.Drawing.Point(6, 272);
            this.ContainsGroupBox.Name = "ContainsGroupBox";
            this.ContainsGroupBox.Size = new System.Drawing.Size(506, 240);
            this.ContainsGroupBox.TabIndex = 29;
            this.ContainsGroupBox.TabStop = false;
            // 
            // ContainsDateTimeGroupBox
            // 
            this.ContainsDateTimeGroupBox.Location = new System.Drawing.Point(160, 57);
            this.ContainsDateTimeGroupBox.Name = "ContainsDateTimeGroupBox";
            this.ContainsDateTimeGroupBox.Size = new System.Drawing.Size(338, 136);
            this.ContainsDateTimeGroupBox.TabIndex = 47;
            this.ContainsDateTimeGroupBox.TabStop = false;
            this.ContainsDateTimeGroupBox.Visible = false;
            // 
            // ContainsValueDateTimePicker
            // 
            this.ContainsValueDateTimePicker.Location = new System.Drawing.Point(211, 27);
            this.ContainsValueDateTimePicker.Name = "ContainsValueDateTimePicker";
            this.ContainsValueDateTimePicker.Size = new System.Drawing.Size(177, 20);
            this.ContainsValueDateTimePicker.TabIndex = 46;
            this.ContainsValueDateTimePicker.Visible = false;
            // 
            // ContainsValueComboBox
            // 
            this.ContainsValueComboBox.Location = new System.Drawing.Point(212, 26);
            this.ContainsValueComboBox.Name = "ContainsValueComboBox";
            this.ContainsValueComboBox.Size = new System.Drawing.Size(176, 21);
            this.ContainsValueComboBox.TabIndex = 45;
            this.ContainsValueComboBox.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(459, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = ")";
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(395, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(8, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "(";
            this.label4.Visible = false;
            // 
            // ContainsDataTypeTextBox
            // 
            this.ContainsDataTypeTextBox.Enabled = false;
            this.ContainsDataTypeTextBox.Location = new System.Drawing.Point(403, 26);
            this.ContainsDataTypeTextBox.Name = "ContainsDataTypeTextBox";
            this.ContainsDataTypeTextBox.Size = new System.Drawing.Size(56, 20);
            this.ContainsDataTypeTextBox.TabIndex = 42;
            this.ContainsDataTypeTextBox.Visible = false;
            // 
            // AddContainsFieldButton
            // 
            this.AddContainsFieldButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AddContainsFieldButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddContainsFieldButton.Location = new System.Drawing.Point(473, 26);
            this.AddContainsFieldButton.Name = "AddContainsFieldButton";
            this.AddContainsFieldButton.Size = new System.Drawing.Size(24, 23);
            this.AddContainsFieldButton.TabIndex = 41;
            this.AddContainsFieldButton.Text = ">";
            this.AddContainsFieldButton.Click += new System.EventHandler(this.AddContainsFieldButton_Click);
            // 
            // ContainsValueLabel
            // 
            this.ContainsValueLabel.Location = new System.Drawing.Point(162, 25);
            this.ContainsValueLabel.Name = "ContainsValueLabel";
            this.ContainsValueLabel.Size = new System.Drawing.Size(40, 24);
            this.ContainsValueLabel.TabIndex = 40;
            this.ContainsValueLabel.Text = "Value:";
            this.ContainsValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ContainsValueTextBox
            // 
            this.ContainsValueTextBox.Location = new System.Drawing.Point(209, 26);
            this.ContainsValueTextBox.Name = "ContainsValueTextBox";
            this.ContainsValueTextBox.Size = new System.Drawing.Size(177, 20);
            this.ContainsValueTextBox.TabIndex = 39;
            // 
            // ContainsFieldsListBox
            // 
            this.ContainsFieldsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.ContainsFieldsListBox.Location = new System.Drawing.Point(8, 16);
            this.ContainsFieldsListBox.Name = "ContainsFieldsListBox";
            this.ContainsFieldsListBox.Size = new System.Drawing.Size(144, 173);
            this.ContainsFieldsListBox.TabIndex = 38;
            this.ContainsFieldsListBox.SelectedIndexChanged += new System.EventHandler(this.ContainsFieldsListBox_SelectedIndexChanged);
            // 
            // ChangeTokenButton
            // 
            this.ChangeTokenButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChangeTokenButton.Location = new System.Drawing.Point(338, 0);
            this.ChangeTokenButton.Name = "ChangeTokenButton";
            this.ChangeTokenButton.Size = new System.Drawing.Size(88, 24);
            this.ChangeTokenButton.TabIndex = 30;
            this.ChangeTokenButton.Text = "ChangeToken";
            this.ChangeTokenButton.Click += new System.EventHandler(this.ChangeTokenButton_Click);
            // 
            // ChangeTokenGroupBox
            // 
            this.ChangeTokenGroupBox.Controls.Add(this.ChangeTokenTextBox);
            this.ChangeTokenGroupBox.Controls.Add(this.ChangeTokenCheckBox);
            this.ChangeTokenGroupBox.Location = new System.Drawing.Point(524, 274);
            this.ChangeTokenGroupBox.Name = "ChangeTokenGroupBox";
            this.ChangeTokenGroupBox.Size = new System.Drawing.Size(218, 240);
            this.ChangeTokenGroupBox.TabIndex = 34;
            this.ChangeTokenGroupBox.TabStop = false;
            // 
            // ChangeTokenTextBox
            // 
            this.ChangeTokenTextBox.Enabled = false;
            this.ChangeTokenTextBox.Location = new System.Drawing.Point(43, 57);
            this.ChangeTokenTextBox.Name = "ChangeTokenTextBox";
            this.ChangeTokenTextBox.Size = new System.Drawing.Size(169, 20);
            this.ChangeTokenTextBox.TabIndex = 31;
            // 
            // ChangeTokenCheckBox
            // 
            this.ChangeTokenCheckBox.AutoSize = true;
            this.ChangeTokenCheckBox.Location = new System.Drawing.Point(23, 29);
            this.ChangeTokenCheckBox.Name = "ChangeTokenCheckBox";
            this.ChangeTokenCheckBox.Size = new System.Drawing.Size(169, 17);
            this.ChangeTokenCheckBox.TabIndex = 28;
            this.ChangeTokenCheckBox.Text = "Retrieve changes as of token:";
            this.ChangeTokenCheckBox.UseVisualStyleBackColor = true;
            this.ChangeTokenCheckBox.CheckedChanged += new System.EventHandler(this.ChangeTokenCheckBox_CheckedChanged);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ClearButton.Location = new System.Drawing.Point(983, 1);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(60, 23);
            this.ClearButton.TabIndex = 35;
            this.ClearButton.Text = "Clear";
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // QueryLabel
            // 
            this.QueryLabel.AutoSize = true;
            this.QueryLabel.Location = new System.Drawing.Point(488, 6);
            this.QueryLabel.Name = "QueryLabel";
            this.QueryLabel.Size = new System.Drawing.Size(52, 13);
            this.QueryLabel.TabIndex = 37;
            this.QueryLabel.Text = "Query by:";
            // 
            // QueryByIdRadioButton
            // 
            this.QueryByIdRadioButton.AutoSize = true;
            this.QueryByIdRadioButton.Location = new System.Drawing.Point(616, 4);
            this.QueryByIdRadioButton.Name = "QueryByIdRadioButton";
            this.QueryByIdRadioButton.Size = new System.Drawing.Size(36, 17);
            this.QueryByIdRadioButton.TabIndex = 38;
            this.QueryByIdRadioButton.Text = "ID";
            this.QueryByIdRadioButton.UseVisualStyleBackColor = true;
            this.QueryByIdRadioButton.CheckedChanged += new System.EventHandler(this.QueryByIdRadioButton_CheckedChanged);
            // 
            // QueryByNameRadioButton
            // 
            this.QueryByNameRadioButton.AutoSize = true;
            this.QueryByNameRadioButton.Checked = true;
            this.QueryByNameRadioButton.Location = new System.Drawing.Point(553, 4);
            this.QueryByNameRadioButton.Name = "QueryByNameRadioButton";
            this.QueryByNameRadioButton.Size = new System.Drawing.Size(53, 17);
            this.QueryByNameRadioButton.TabIndex = 39;
            this.QueryByNameRadioButton.TabStop = true;
            this.QueryByNameRadioButton.Text = "Name";
            this.QueryByNameRadioButton.UseVisualStyleBackColor = true;
            this.QueryByNameRadioButton.CheckedChanged += new System.EventHandler(this.QueryByNameRadioButton_CheckedChanged);
            // 
            // QueryUserControl
            // 
            this.Controls.Add(this.QueryByNameRadioButton);
            this.Controls.Add(this.QueryByIdRadioButton);
            this.Controls.Add(this.QueryLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ChangeTokenButton);
            this.Controls.Add(this.QueryOptionsButton);
            this.Controls.Add(this.SinceButton);
            this.Controls.Add(this.ContainsButton);
            this.Controls.Add(this.ViewFieldsButton);
            this.Controls.Add(this.QueryButton);
            this.Controls.Add(this.optionsGroupBox);
            this.Controls.Add(this.SinceGroupBox);
            this.Controls.Add(this.ChangeTokenGroupBox);
            this.Controls.Add(this.viewFieldsGroupBox);
            this.Controls.Add(this.ContainsGroupBox);
            this.Controls.Add(this.queryGroupBox);
            this.Name = "QueryUserControl";
            this.Size = new System.Drawing.Size(1046, 867);
            this.queryGroupBox.ResumeLayout(false);
            this.queryGroupBox.PerformLayout();
            this.optionsGroupBox.ResumeLayout(false);
            this.optionsGroupBox.PerformLayout();
            this.viewFieldsGroupBox.ResumeLayout(false);
            this.SinceGroupBox.ResumeLayout(false);
            this.SinceGroupBox.PerformLayout();
            this.SinceDateGroupBox.ResumeLayout(false);
            this.SinceDateGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SecondsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HourUpDown)).EndInit();
            this.ContainsGroupBox.ResumeLayout(false);
            this.ContainsGroupBox.PerformLayout();
            this.ChangeTokenGroupBox.ResumeLayout(false);
            this.ChangeTokenGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private const string xsdSchemaFile = @"CamlSchema.xsd";
        private const string xsdSchemaUri = @"http://tempuri.org/CamlSchema.xsd";
        private string executionPath;

        private bool isInitializingQueryControls;
        private bool isRemoving;
        private bool isRemoved;
        private bool isNewField;
        private bool isChangeOrderBy;
        private bool addCombinerNode;

        private U2U.SharePoint.CAML.Builder builder = null;
        private U2U.SharePoint.CAML.ISite sharepointSite = null;
        private string listName = null;
        private System.Guid listGuid = System.Guid.Empty;
        private XmlSchema xsdSchema;

        private FieldObject selectedFieldObject = null;
        private DateTimeUserControl ucDateTime = null;
        private DateTimeUserControl ucContainsDateTime = null;

        private TreeNode queryNode;
        private TreeNode whereNode;
        private TreeNode orderByNode;
        private TreeNode selectedTreeNode;
        private U2U.SharePoint.CAML.Enumerations.CamlTypes selectedQueryType;

        #region Constructors

        QueryInfo query;

        public QueryUserControl(QueryInfo queryInfo)
            : this()
        {
            this.selectedQueryType = query.QueryType;
            this.sharepointSite = queryInfo.Site;
            query = queryInfo;
            this.listName = query.List.Name;
            InitializeVariablesAndControls(true).Wait();
            if (builder == null)
            {
                builder = new U2U.SharePoint.CAML.Builder(selectedQueryType);
            }
        }

        #endregion

        #region Public Properties
        public U2U.SharePoint.CAML.ISite SharepointSite
        {
            get { return sharepointSite; }
            set { sharepointSite = value; }
        }

        public string ListName
        {
            get { return listName; }
            set { listName = value; }
        }

        public System.Guid ListGuid
        {
            get { return listGuid; }
            set
            {
                listGuid = value;
                if (sharepointSite != null)
                    InitializeVariablesAndControls(false).Wait();
            }
        }

        public U2U.SharePoint.CAML.Enumerations.CamlTypes QueryType
        {
            get { return selectedQueryType; }
            set
            {
                if (selectedQueryType != value)
                {
                    selectedQueryType = value;
                    if (builder != null)
                        builder.CamlType = selectedQueryType;
                    InitializeVariablesAndControls(true).Wait();
                }
            }
        }

        public XmlDocument CamlDocument
        {
            get { return builder.CamlDocument; }
            set
            {
                builder = new U2U.SharePoint.CAML.Builder(value);
                // set the treeview
                FillQueryUserControl(value).Wait();
                OnQueryExpressionChanged();
            }
        }

        public string Since
        {
            get
            {
                if (SinceCheckBox.Checked)
                {
                    return BuildDateTime(SinceDateTimePicker.Value, System.Convert.ToInt32(HourUpDown.Value),
                        System.Convert.ToInt32(MinutesUpDown.Value), System.Convert.ToInt32(SecondsUpDown.Value));
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    // analyse the string: date.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                    if (value.Length < 20) return;

                    int year = 0;
                    int.TryParse(value.Substring(0, 4), out year);
                    if (year == 0) return;

                    int month = 0;
                    int.TryParse(value.Substring(5, 2), out month);
                    if (month == 0) return;

                    int day = 0;
                    int.TryParse(value.Substring(8, 2), out day);
                    if (month == 0) return;

                    int hour = 0;
                    int.TryParse(value.Substring(11, 2), out hour);

                    int minutes = 0;
                    int.TryParse(value.Substring(14, 2), out minutes);

                    int seconds = 0;
                    int.TryParse(value.Substring(17, 2), out seconds);

                    DateTime date = new DateTime(year, month, day, hour, minutes, seconds);

                    SinceCheckBox.Checked = true;

                    SinceDateTimePicker.Value = date;
                    HourUpDown.Value = hour;
                    MinutesUpDown.Value = minutes;
                    SecondsUpDown.Value = seconds;

                    BuildDateTime(SinceDateTimePicker.Value, System.Convert.ToInt32(HourUpDown.Value),
                        System.Convert.ToInt32(MinutesUpDown.Value), System.Convert.ToInt32(SecondsUpDown.Value));
                }
            }
        }

        public string ChangeToken
        {
            get { return ChangeTokenTextBox.Text; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ChangeTokenTextBox.Text = value;
                    ChangeTokenCheckBox.Checked = true;
                    ChangeTokenButton_Click(this, new EventArgs());
                }
            }
        }

        public bool IsQueryByName
        {
            get { return QueryByNameRadioButton.Checked; }
            set
            {
                QueryByNameRadioButton.Checked = value;
            }
        }
        #endregion

        #region Private Properties
        private void SchemaValidationHandler(object sender, ValidationEventArgs args)
        {
            MessageBox.Show(args.Message);
        }

        private XmlSchema XsdSchema
        {
            get
            {
                if (xsdSchema == null)
                {
                    //XmlValidatingReader sr = null;
                    System.IO.StreamReader sr = null;

                    try
                    {
                        string codeBase = this.GetType().Assembly.CodeBase;
                        executionPath = System.IO.Path.GetDirectoryName(codeBase);
                        if (executionPath.StartsWith(@"file:\"))
                            executionPath = executionPath.Remove(0, 6);
                        if (System.IO.File.Exists(executionPath + @"\" + xsdSchemaFile))
                        {
                            //							XmlTextReader txtreader = new XmlTextReader (xsdSchemaFile);
                            //							sr = new XmlValidatingReader (txtreader);
                            //							sr.ValidationEventHandler += 
                            //								new ValidationEventHandler (SchemaValidationHandler);
                            //							while (sr.Read()){}
                            sr = new System.IO.StreamReader(executionPath + @"\" + xsdSchemaFile);
                            xsdSchema = System.Xml.Schema.XmlSchema.Read(sr, new ValidationEventHandler(SchemaValidationHandler));
                            xsdSchema.Compile(new ValidationEventHandler(SchemaValidationHandler));
                        }
                        else
                            MessageBox.Show("The CAML xsd schema is not found");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        sr.Close();
                    }
                }
                return xsdSchema;
            }
        }

        private TreeNode QueryNode
        {
            get
            {
                if (queryNode == null && queryTreeview.Nodes.Count == 0)
                {
                    queryNode = new TreeNode(Caml.Constants.Query.Tag);
                    queryTreeview.Nodes.Add(queryNode);
                }
                //else
                //	_queryNode = queryTreeview.Nodes[0];
                return queryNode;
            }
        }

        private TreeNode WhereNode
        {
            get
            {
                if (whereNode == null)
                {
                    whereNode = new TreeNode(Caml.Constants.Query.Where.Tag);
                    QueryNode.Nodes.Add(whereNode);
                }
                return whereNode;
            }
        }

        private TreeNode OrderByNode
        {
            get
            {
                if (orderByNode == null)
                {
                    orderByNode = new TreeNode(Caml.Constants.Query.OrderBy.Tag);
                    QueryNode.Nodes.Add(orderByNode);
                }
                return orderByNode;
            }
        }
        #endregion

        #region Initializing methods
        private async Task InitializeVariablesAndControls(bool isInitializing)
        {
            try
            {
                if (isInitializing)
                {
                    isInitializingQueryControls = true;

                    QueryByNameRadioButton.Checked = true;

                    // make all buttons invisible
                    QueryButton.Visible = false;
                    ViewFieldsButton.Visible = false;
                    QueryOptionsButton.Visible = false;
                    ContainsButton.Visible = false;
                    SinceButton.Visible = false;
                    ChangeTokenButton.Visible = false;

                    // make all group boxes invisible 
                    queryGroupBox.Visible = false;
                    optionsGroupBox.Visible = false;
                    viewFieldsGroupBox.Visible = false;
                    ContainsGroupBox.Visible = false;
                    SinceGroupBox.Visible = false;
                    ChangeTokenGroupBox.Visible = false;

                    switch (selectedQueryType)
                    {
                        case U2U.SharePoint.CAML.Enumerations.CamlTypes.Query:
                            {
                                // adapt the size and the location of the queryGroupBox
                                queryGroupBox.Size = new Size(728, 244);
                                queryGroupBox.Location = new Point(0, 18);
                                queryGroupBox.Visible = true;

                                break;
                            }
                        case U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItems:
                            {
                                // empty the fieldsTo listbox
                                fieldsToListBox.Items.Clear();

                                // make the buttons visible
                                ViewFieldsButton.Visible = true;
                                ViewFieldsButton.ForeColor = Color.Blue;
                                QueryButton.Visible = true;
                                QueryButton.ForeColor = Color.Black;
                                QueryButton.Location = new Point(ViewFieldsButton.Width, 0);
                                QueryOptionsButton.Visible = true;
                                QueryOptionsButton.ForeColor = Color.Black;
                                QueryOptionsButton.Location = new Point(QueryButton.Location.X + QueryButton.Width, 0);

                                // adapt the size and the location of the groupBoxes
                                queryGroupBox.Size = new Size(728, 244);
                                queryGroupBox.Location = new Point(0, 18);
                                queryGroupBox.Visible = false;

                                // show the view fields group box
                                viewFieldsGroupBox.Visible = true;

                                // change the location of the Clear button
                                ClearButton.Location = new Point(650, 1);

                                break;
                            }
                        case CamlTypes.GetListItemChanges:
                            {
                                // empty the fieldsTo listbox
                                fieldsToListBox.Items.Clear();

                                // make the buttons visible and place them one next to the other
                                ViewFieldsButton.Visible = true;
                                ViewFieldsButton.ForeColor = Color.Blue;
                                ContainsButton.Visible = true;
                                ContainsButton.ForeColor = Color.Black;
                                ContainsButton.Location = new Point(ViewFieldsButton.Width, 0);
                                SinceButton.Visible = true;
                                SinceButton.ForeColor = Color.Black;
                                SinceButton.Location = new Point(ContainsButton.Location.X + ContainsButton.Width, 0);

                                // adapt the size and the location of the groupBoxes
                                queryGroupBox.Size = new Size(728, 244);
                                queryGroupBox.Location = new Point(0, 18);
                                viewFieldsGroupBox.Visible = true;
                                SinceGroupBox.Visible = true;

                                // change the location of the Clear button
                                ClearButton.Location = new Point(650, 1);

                                break;
                            }
                        case U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItemChangesSinceToken:
                            {
                                // empty the fieldsTo listbox
                                fieldsToListBox.Items.Clear();

                                // make the buttons visible
                                ViewFieldsButton.Visible = true;
                                ViewFieldsButton.ForeColor = Color.Blue;

                                QueryButton.Visible = true;
                                QueryButton.ForeColor = Color.Black;
                                QueryButton.Location = new Point(ViewFieldsButton.Width, 0);

                                ContainsButton.Visible = true;
                                ContainsButton.ForeColor = Color.Black;
                                ContainsButton.Location = new Point(QueryButton.Location.X + QueryButton.Width, 0);

                                QueryOptionsButton.Visible = true;
                                QueryOptionsButton.ForeColor = Color.Black;
                                QueryOptionsButton.Location = new Point(ContainsButton.Location.X + ContainsButton.Width, 0);

                                ChangeTokenButton.Visible = true;
                                ChangeTokenButton.ForeColor = Color.Black;
                                ChangeTokenButton.Location = new Point(QueryOptionsButton.Location.X + QueryOptionsButton.Width, 0);

                                // adapt the size and the location of the groupBoxes
                                queryGroupBox.Size = new Size(728, 244);
                                queryGroupBox.Location = new Point(0, 18);
                                queryGroupBox.Visible = false;

                                // show the view fields group box
                                viewFieldsGroupBox.Visible = true;
                                ChangeTokenGroupBox.Visible = true;

                                // change the location of the Clear button
                                ClearButton.Location = new Point(650, 1);

                                break;
                            }
                    }

                    FillQueryComboBoxes();
                    InitializeQueryControls();

                    // handle the ViewFields controls
                    if (selectedQueryType == CamlTypes.GetListItems
                        || selectedQueryType == CamlTypes.GetListItemChangesSinceToken)
                    {
                        // clear the ViewFields list box
                        fieldsToListBox.Items.Clear();
                    }

                    // handle the QueryOptions controls
                    if (selectedQueryType == CamlTypes.GetListItems
                        || selectedQueryType == CamlTypes.GetListItemChangesSinceToken)
                    {
                        // uncheck all query options check boxes
                        IncludeMandatoryColumnsCheckBox.Checked = true;
                        DateInUtcCheckBox.Checked = false;
                        folderTextBox.Text = string.Empty;
                        PagingTextBox.Text = string.Empty;
                    }

                    InitializeQueryOptionsControl();

                    // handle the Contains controls 
                    if (selectedQueryType == CamlTypes.GetListItemChanges
                        || selectedQueryType == CamlTypes.GetListItemChangesSinceToken)
                    {
                        InitializeContainsControls();
                    }

                    // handle the Since controls
                    if (selectedQueryType == CamlTypes.GetListItemChanges)
                    {
                        InitializeSinceControls();
                    }

                    // handle the ChangeToken controls
                    if (selectedQueryType == CamlTypes.GetListItemChangesSinceToken)
                    {
                        InitializeChangeTokenControls();
                    }

                }
                await FillFieldsListBox();

                isInitializingQueryControls = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeContainsControls()
        {
            ContainsValueTextBox.Text = string.Empty;
            ContainsDataTypeTextBox.Text = string.Empty;
            ContainsValueComboBox.Text = string.Empty;
            ContainsValueComboBox.Items.Clear();

            // Add a DateTime user control
            ucContainsDateTime = new DateTimeUserControl();
            ucContainsDateTime.InitializeControls();
            ContainsDateTimeGroupBox.Controls.Add(ucContainsDateTime);
        }

        private void InitializeSinceControls()
        {
            SinceCheckBox.Checked = false;
            SinceDateGroupBox.Enabled = false;
            SinceDateTimePicker.MaxDate = DateTime.Now;
        }

        private void InitializeChangeTokenControls()
        {
            ChangeTokenCheckBox.Checked = false;
            ChangeTokenTextBox.Text = string.Empty;
            ChangeTokenTextBox.Enabled = false;
        }

        private void InitializeQueryOptionsControl()
        {
            IncludeMandatoryColumnsCheckBox.Checked = false;
            DateInUtcCheckBox.Checked = false;
            RecursiveCheckBox.Checked = false;
            ExpandUserFieldCheckBox.Checked = false;
            IncludePermissionsCheckBox.Checked = false;

            IncludeAttachmentUrlsCheckBox.Checked = false;
            IncludeAttachmentVersionCheckBox.Checked = false;
            IncludeAttachmentVersionCheckBox.Enabled = false;

            PagingTextBox.Text = string.Empty;

            FolderCheckBox.Checked = false;
            folderTextBox.Enabled = false;
            folderTextBox.Text = string.Empty;

            if (selectedQueryType == CamlTypes.GetListItemChangesSinceToken)
            {
                ExtraIdLabel.Visible = true;
                ExtraIdsTextBox.Visible = true;
            }
            else
            {
                ExtraIdLabel.Visible = false;
                ExtraIdsTextBox.Visible = false;
            }

            OptimizeForComboBox.SelectedIndex = 0;
        }

        private async Task FillFieldsListBox()
        {
            // fill the listbox
            switch (selectedQueryType)
            {
                case CamlTypes.Query:
                    {
                        // clear the Query list box
                        fieldsListBox.Items.Clear();

                        await UtilityFunctions.FillFields(fieldsListBox, query);

                        break;
                    }
                case CamlTypes.GetListItems:
                    {
                        fieldsListBox.Items.Clear();
                        fieldsFromListBox.Items.Clear();

                        await UtilityFunctions.FillFields(fieldsFromListBox, query);
                        await UtilityFunctions.FillFields(fieldsListBox, query);
                        break;
                    }
                case CamlTypes.GetListItemChanges:
                    {
                        // clear the fields list box on the contains tab
                        fieldsFromListBox.Items.Clear();
                        ContainsFieldsListBox.Items.Clear();

                        // repopulate the fist viewFields list box
                        await UtilityFunctions.FillFields(fieldsFromListBox, query);
                        await UtilityFunctions.FillFields(ContainsFieldsListBox, query);
                        break;
                    }
                case CamlTypes.GetListItemChangesSinceToken:
                    {
                        fieldsListBox.Items.Clear();
                        fieldsFromListBox.Items.Clear();
                        ContainsFieldsListBox.Items.Clear();

                        // repopulate the fist viewFields list box
                        await UtilityFunctions.FillFields(fieldsFromListBox, query);
                        await UtilityFunctions.FillFields(fieldsListBox, query);
                        await UtilityFunctions.FillFields(ContainsFieldsListBox, query);
                        break;
                    }
            }
        }

        //#region sharepoint object model methods
        //private void FillFieldsListBoxViaServer()
        //{
        //    SPList list = ((U2U.SharePoint.CAML.Server.SharePointSite)sharepointSite).Web.Lists[listGuid];
        //    foreach (SPField field in list.Fields)
        //    {
        //        if (!field.Hidden)
        //        {
        //            // TODO : wat met velden zoals 3x Title en Edit?
        //            FieldObject item = new FieldObject(field.Title, field.Id, field.InternalName, field.TypeAsString);
        //            if (field.Type.ToString() != "Invalid")
        //            {
        //                if (field is SPFieldLookup)
        //                {
        //                    SPFieldLookup lookupfield = (SPFieldLookup)field;
        //                    item.LookupList = lookupfield.LookupList;
        //                    item.ShowField = lookupfield.LookupField;
        //                }
        //                else if (field is SPFieldChoice)
        //                {
        //                    SPFieldChoice choicefield = (SPFieldChoice)field;
        //                    item.DefaultChoice = choicefield.DefaultValue;
        //                    item.ChoiceList = "<CHOICES>";
        //                    foreach (string choice in choicefield.Choices)
        //                        item.ChoiceList += "<CHOICE>" + choice + "</CHOICE>";
        //                    item.ChoiceList += "</CHOICES>";
        //                }
        //                else if (field is SPFieldMultiChoice)
        //                {
        //                    SPFieldMultiChoice choicefield = (SPFieldMultiChoice)field;
        //                    item.DefaultChoice = choicefield.DefaultValue;
        //                    item.ChoiceList = "<CHOICES>";
        //                    foreach (string choice in choicefield.Choices)
        //                        item.ChoiceList += "<CHOICE>" + choice + "</CHOICE>";
        //                    item.ChoiceList += "</CHOICES>";
        //                }
        //            }
        //            else
        //            {
        //                // This means it is a custom field. Get the base type
        //                string type = field.FieldValueType.ToString();
        //                item.TypeAsString = GetBaseTypeFromCustomField(field);
        //            }
        //            fieldsListBox.Items.Add(item);
        //            if (selectedQueryType == U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItems)
        //                fieldsFromListBox.Items.Add(item);
        //        }
        //    }
        //}

        //private void FillLookupComboBoxViaServer()
        //{
        //    SPList list = ((U2U.SharePoint.CAML.Server.SharePointSite)sharepointSite).Web.Lists[new System.Guid(selectedFieldObject.LookupList)];
        //    if (list != null)
        //    {
        //        SPQuery query = new SPQuery();
        //        foreach (SPListItem listitem in list.GetItems(query))
        //        {
        //            object fieldValue = listitem[selectedFieldObject.ShowField];
        //            if (fieldValue != null)
        //            {
        //                valueComboBox.Items.Add(fieldValue);
        //            }
        //        }
        //    }
        //}

        //private string GetBaseTypeFromCustomField(SPField field)
        //{
        //    string typeAsString = "Text";
        //    if (field is SPFieldText)
        //        typeAsString = U2U.SharePoint.CAML.Enumerations.DataTypes.Text.ToString();
        //    else if (field is SPFieldBoolean)
        //        typeAsString = U2U.SharePoint.CAML.Enumerations.DataTypes.Boolean.ToString();
        //    else if (field is SPFieldNumber)
        //        typeAsString = U2U.SharePoint.CAML.Enumerations.DataTypes.Number.ToString();
        //    else if (field is SPFieldDateTime)
        //        typeAsString = U2U.SharePoint.CAML.Enumerations.DataTypes.DateTime.ToString();
        //    else if (field is SPFieldUser)
        //        typeAsString = U2U.SharePoint.CAML.Enumerations.DataTypes.User.ToString();

        //    // TODO: die moeten nog uitgetest worden
        //    //Choice,
        //    //Lookup,
        //    //MultiChoice,

        //    return typeAsString;
        //}


        //#endregion

        private XmlSchemaSimpleTypeRestriction GetSchemaEnumerable(XmlSchema schema, string enumerable)
        {
            XmlSchemaSimpleType xsdEnumType;
            xsdEnumType = (XmlSchemaSimpleType)schema.SchemaTypes[new XmlQualifiedName(enumerable, xsdSchemaUri)];
            return (XmlSchemaSimpleTypeRestriction)xsdEnumType.Content;
        }

        private void FillQueryComboBoxes()
        {
            if (XsdSchema != null)
            {
                // get Query Operator enum
                this.operatorComboBox.Items.Clear();
                this.operatorComboBox.DisplayMember = "Value";
                this.operatorComboBox.ValueMember = "Id";
                foreach (XmlSchemaFacet facet in GetSchemaEnumerable(this.XsdSchema, Caml.Constants.CamlEnumerations.CamlOperatorEnumeration).Facets)
                    this.operatorComboBox.Items.Add(facet);

                // get Query Combiner enum
                this.combinerComboBox.Items.Clear();
                foreach (XmlSchemaFacet facet in GetSchemaEnumerable(this.XsdSchema, Caml.Constants.CamlEnumerations.CamlCombinerEnumeration).Facets)
                    this.combinerComboBox.Items.Add(facet.Value);
            }
        }

        private void InitializeQueryControls()
        {
            // handle the Query controls
            if (selectedQueryType == CamlTypes.Query
                || selectedQueryType == CamlTypes.GetListItems
                || selectedQueryType == CamlTypes.GetListItemChangesSinceToken)
            {
                this.orderByCheckBox.Checked = false;
                this.whereCheckBox.Checked = false;
                this.valueTextBox.Text = string.Empty;
                this.dataTypeTextBox.Text = string.Empty;
                this.valueComboBox.Text = string.Empty;
                this.valueComboBox.Items.Clear();
                this.combinerComboBox.Visible = false;

                ucDateTime = new DateTimeUserControl();
                ucDateTime.InitializeControls();
                dateTimeGroupBox.Controls.Add(ucDateTime);
            }

        }


        private async Task FillQueryUserControl(XmlDocument camlDocument)
        {
            queryGroupBox.Enabled = true;
            ClearQueryControls();
            await FillFieldsListBox();
            switch (selectedQueryType)
            {
                case U2U.SharePoint.CAML.Enumerations.CamlTypes.Query:
                    {
                        FillQueryControls(builder.CamlDocument.ChildNodes[0]);
                        break;
                    }
                case U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItems:
                    {
                        XmlNode node = builder.CamlDocument.SelectSingleNode("//" + Caml.Constants.Query.Tag);
                        FillQueryControls(node);
                        node = builder.CamlDocument.SelectSingleNode("//" + Caml.Constants.ViewFields.Tag);
                        FillViewFieldsControls(node);
                        node = builder.CamlDocument.SelectSingleNode("//" + Caml.Constants.QueryOptions.Tag);
                        FillQueryOptionsControls(node);
                        break;
                    }
                case CamlTypes.GetListItemChanges:
                    {
                        XmlNode node = builder.CamlDocument.SelectSingleNode("//" + Caml.Constants.ViewFields.Tag);
                        FillViewFieldsControls(node);
                        node = builder.CamlDocument.SelectSingleNode("//" + Caml.Constants.Contains.Tag);
                        FillContainsControls(node);
                        break;
                    }
                case CamlTypes.GetListItemChangesSinceToken:
                    {
                        XmlNode node = builder.CamlDocument.SelectSingleNode("//" + Caml.Constants.Query.Tag);
                        FillQueryControls(node);
                        node = builder.CamlDocument.SelectSingleNode("//" + Caml.Constants.ViewFields.Tag);
                        FillViewFieldsControls(node);
                        node = builder.CamlDocument.SelectSingleNode("//" + Caml.Constants.QueryOptions.Tag);
                        FillQueryOptionsControls(node);
                        node = builder.CamlDocument.SelectSingleNode("//" + Caml.Constants.Contains.Tag);
                        FillContainsControls(node);
                        break;
                    }
            }

            this.queryTreeview.ExpandAll();
        }

        private void FillViewFieldsControls(XmlNode viewFieldsNode)
        {
            if (viewFieldsNode == null) return;

            foreach (XmlNode node in viewFieldsNode.ChildNodes)
            {
                for (int i = 0; i < this.fieldsFromListBox.Items.Count; i++)
                {
                    FieldObject item = (FieldObject)fieldsFromListBox.Items[i];
                    if (item.InternalName == node.Attributes.GetNamedItem(Caml.Constants.ViewFields.FieldRef.Attributes.Name).Value)
                    {
                        fieldsToListBox.Items.Add(item);
                        fieldsFromListBox.Items.Remove(item);
                    }
                }
            }
        }

        private void FillQueryOptionsControls(XmlNode queryOptionsNode)
        {
            if (queryOptionsNode == null) return;

            foreach (XmlNode node in queryOptionsNode.ChildNodes)
            {
                switch (node.Name)
                {
                    case Caml.Constants.QueryOptions.IncludedMandatoryColumns:
                        this.IncludeMandatoryColumnsCheckBox.Checked = System.Convert.ToBoolean(node.InnerText);
                        break;

                    case Caml.Constants.QueryOptions.DatesInUtc:
                        this.DateInUtcCheckBox.Checked = System.Convert.ToBoolean(node.InnerText);
                        break;

                    case Caml.Constants.QueryOptions.Folder:
                        FolderCheckBox.Checked = true;
                        folderTextBox.Enabled = true;
                        this.folderTextBox.Text = node.InnerText;
                        break;

                    case Caml.Constants.QueryOptions.Paging:
                        this.PagingTextBox.Text = node.InnerText;
                        break;

                    case Caml.Constants.QueryOptions.ExpandUserField:
                        this.ExpandUserFieldCheckBox.Checked = System.Convert.ToBoolean(node.InnerText);
                        break;

                    case Caml.Constants.QueryOptions.ExtraIds:
                        this.ExtraIdsTextBox.Text = node.InnerText;
                        break;

                    case Caml.Constants.QueryOptions.IncludeAttachmentUrls:
                        this.IncludeAttachmentUrlsCheckBox.Checked = System.Convert.ToBoolean(node.InnerText);
                        break;

                    case Caml.Constants.QueryOptions.IncludeAttachmentVersion:
                        this.IncludeAttachmentVersionCheckBox.Checked = System.Convert.ToBoolean(node.InnerText);
                        break;

                    case Caml.Constants.QueryOptions.IncludePermissions:
                        this.IncludePermissionsCheckBox.Checked = System.Convert.ToBoolean(node.InnerText);
                        break;

                    case Caml.Constants.QueryOptions.MeetingInstanceID:
                        // TODO: what is MeetingInstanceID?
                        break;

                    case Caml.Constants.QueryOptions.OptimizeFor:
                        if (node.InnerText == "ItemIds")
                            this.OptimizeForComboBox.SelectedIndex = 0;
                        else
                            this.OptimizeForComboBox.SelectedIndex = 1;
                        break;

                    case Caml.Constants.QueryOptions.ViewAttributes:
                        this.RecursiveCheckBox.Checked = true;
                        break;

                }
            }
        }

        private void FillContainsControls(XmlNode containsNode)
        {
            if (containsNode == null) return;

            //<Contains>
            //    <FieldRef Name="Status"/>
            //    <Value Type="Text">Complete</Value>
            //</Contains>

            foreach (XmlNode node in containsNode.ChildNodes)
            {
                if (node.Name == Caml.Constants.Contains.FieldRef.Tag)
                {
                    string fieldref = null;
                    Guid fieldid = Guid.Empty;

                    if (QueryByNameRadioButton.Checked)
                        fieldref = node.Attributes.GetNamedItem("Name").Value;
                    else if (node.Attributes.GetNamedItem("ID").Value.Length > 0)
                        fieldid = new Guid(node.Attributes.GetNamedItem("ID").Value);

                    // handle the field value
                    string fieldvalue = null;
                    string datatype = null;
                    if (node.NextSibling != null)
                        fieldvalue = node.NextSibling.InnerText;

                    for (int i = 0; i < ContainsFieldsListBox.Items.Count; i++)
                    {
                        FieldObject fo = (FieldObject)ContainsFieldsListBox.Items[i];

                        if (QueryByNameRadioButton.Checked)
                        {
                            if (fo.InternalName == fieldref)
                            {
                                // this should trigger the event handler for showing the correct value control
                                ContainsFieldsListBox.SelectedIndex = i;
                                datatype = fo.TypeAsString;
                                break;
                            }
                        }
                        else
                        {
                            if (fo.ID == fieldid)
                            {
                                // this should trigger the event handler for showing the correct value control
                                ContainsFieldsListBox.SelectedIndex = i;
                                datatype = fo.TypeAsString;
                                break;
                            }
                        }
                    }
                }
                else if (node.Name == Caml.Constants.Contains.ValueType.Tag)
                {
                    // TODO: hoe moeten we dat aanpakken
                }
            }
        }

        private void FillQueryControls(XmlNode queryNode)
        {
            if (queryNode == null) return;

            foreach (XmlNode node in queryNode.ChildNodes)
            {
                if (node.Name == Caml.Constants.Query.OrderBy.Tag)
                {
                    orderByNode = new TreeNode(Caml.Constants.Query.OrderBy.Tag);
                    QueryNode.Nodes.Add(orderByNode);
                    AddOrderByNodes(node);
                }
                else if (node.Name == Caml.Constants.Query.Where.Tag)
                {
                    whereNode = new TreeNode(Caml.Constants.Query.Where.Tag);
                    QueryNode.Nodes.Add(whereNode);
                    AddWhereNodes(node);
                }
            }
        }

        private void AddOrderByNodes(XmlNode orderByNode)
        {
            foreach (XmlNode node in orderByNode)
            {
                string fieldref = null;
                Guid id = Guid.Empty;

                if (QueryByNameRadioButton.Checked)
                    fieldref = node.Attributes.GetNamedItem("Name").Value;
                else if (node.Attributes.GetNamedItem("ID").Value.Length > 0)
                    id = new Guid(node.Attributes.GetNamedItem("ID").Value);

                int orderbyIndex = 0;
                if (node.Attributes.GetNamedItem("Ascending") != null && node.Attributes.GetNamedItem("Ascending").Value == "FALSE")
                    orderbyIndex = 1;
                OrderField field = new OrderField(fieldref, id, orderbyIndex, node.ParentNode);

                string fieldname = fieldref;
                for (int i = 0; i < fieldsListBox.Items.Count; i++)
                {
                    FieldObject fo = (FieldObject)fieldsListBox.Items[i];
                    if (fo.InternalName == fieldref)
                    {
                        fieldname = fo.DisplayName;
                        break;
                    }
                }
                TreeNode treenode = new TreeNode(fieldname);
                treenode.Tag = field;
                OrderByNode.Nodes.Add(treenode);
            }
        }

        private void AddWhereNodes(XmlNode whereNode)
        {
            XmlNodeList fieldrefNodes = null;
            // check if there is a combiner node
            if (whereNode.ChildNodes[0].Name == "And" || whereNode.ChildNodes[0].Name == "Or")
            {
                foreach (XmlNode combNode in whereNode.ChildNodes)
                {
                    TreeNode treenode = new TreeNode(combNode.Name);
                    fieldrefNodes = combNode.SelectNodes("//Where/" + combNode.Name + "//" + Caml.Constants.Query.Where.FieldRef.Tag);
                    AddWhereFieldRefNodes(fieldrefNodes, treenode);
                    WhereNode.Nodes.Add(treenode);
                    //WhereNode.Nodes.Add(AddCombinerNode(combNode));
                }
            }
            else
            {
                fieldrefNodes = whereNode.SelectNodes("//Where/*/" + Caml.Constants.Query.Where.FieldRef.Tag);
                AddWhereFieldRefNodes(fieldrefNodes, WhereNode);
            }
        }

        private void AddWhereFieldRefNodes(XmlNodeList fieldrefNodes, TreeNode parentTreeNode)
        {
            foreach (XmlNode fieldrefNode in fieldrefNodes)
            {
                string fieldref = null;
                Guid id = Guid.Empty;

                if (QueryByNameRadioButton.Checked)
                    fieldref = fieldrefNode.Attributes.GetNamedItem("Name").Value;
                else if (fieldrefNode.Attributes.GetNamedItem("ID").Value.Length > 0)
                    id = new Guid(fieldrefNode.Attributes.GetNamedItem("ID").Value);

                // handle the operator
                string operatorname = fieldrefNode.ParentNode.Name;
                int operatorIndex = -1;
                for (int i = 0; i < this.operatorComboBox.Items.Count; i++)
                {
                    if (((System.Xml.Schema.XmlSchemaEnumerationFacet)this.operatorComboBox.Items[i]).Id == operatorname)
                    {
                        operatorIndex = i;
                        break;
                    }
                    if (operatorIndex >= 0) break;
                }
                // handle the field value
                string fieldvalue = null;
                string datatype = null;
                if (fieldrefNode.NextSibling != null)
                    fieldvalue = fieldrefNode.NextSibling.InnerText;

                string fieldname = fieldref;
                for (int i = 0; i < fieldsListBox.Items.Count; i++)
                {
                    FieldObject fo = (FieldObject)fieldsListBox.Items[i];
                    if (fo.InternalName == fieldref)
                    {
                        fieldname = fo.DisplayName;
                        datatype = fo.TypeAsString;
                        break;
                    }
                }
                WhereField field = new WhereField(fieldref, id, operatorIndex, fieldvalue, datatype, fieldrefNode.ParentNode);
                TreeNode treenode = new TreeNode(fieldname);
                treenode.Tag = field;
                parentTreeNode.Nodes.Add(treenode);
            }
        }

        #endregion

        private void generateCamlButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Only for testing purposes
                OnQueryExpressionChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Groupbox buttons
        private void viewFieldsButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                ViewFieldsButton.ForeColor = Color.Blue;
                QueryButton.ForeColor = Color.Black;
                QueryOptionsButton.ForeColor = Color.Black;
                ContainsButton.ForeColor = Color.Black;
                SinceButton.ForeColor = Color.Black;
                ChangeTokenButton.ForeColor = Color.Black;

                viewFieldsGroupBox.Visible = true;
                queryGroupBox.Visible = false;
                ContainsGroupBox.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void queryButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                ViewFieldsButton.ForeColor = Color.Black;
                QueryButton.ForeColor = Color.Blue;
                QueryOptionsButton.ForeColor = Color.Black;
                ContainsButton.ForeColor = Color.Black;
                SinceButton.ForeColor = Color.Black;
                ChangeTokenButton.ForeColor = Color.Black;

                queryGroupBox.Visible = true;
                viewFieldsGroupBox.Visible = false;
                optionsGroupBox.Visible = false;
                ContainsGroupBox.Visible = false;
                ChangeTokenGroupBox.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void queryOptionsButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                ViewFieldsButton.ForeColor = Color.Black;
                QueryButton.ForeColor = Color.Black;
                QueryOptionsButton.ForeColor = Color.Blue;
                ContainsButton.ForeColor = Color.Black;
                SinceButton.ForeColor = Color.Black;
                ChangeTokenButton.ForeColor = Color.Black;

                optionsGroupBox.Visible = true;
                queryGroupBox.Visible = false;
                ContainsGroupBox.Visible = false;
                SinceGroupBox.Visible = false;
                ChangeTokenGroupBox.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ContainsButton_Click(object sender, EventArgs e)
        {
            try
            {
                ViewFieldsButton.ForeColor = Color.Black;
                QueryButton.ForeColor = Color.Black;
                QueryOptionsButton.ForeColor = Color.Black;
                ContainsButton.ForeColor = Color.Blue;
                SinceButton.ForeColor = Color.Black;
                ChangeTokenButton.ForeColor = Color.Black;

                queryGroupBox.Visible = false;
                viewFieldsGroupBox.Visible = false;
                optionsGroupBox.Visible = false;
                ContainsGroupBox.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SinceButton_Click(object sender, EventArgs e)
        {
            try
            {
                ViewFieldsButton.ForeColor = Color.Black;
                QueryButton.ForeColor = Color.Black;
                QueryOptionsButton.ForeColor = Color.Black;
                ContainsButton.ForeColor = Color.Black;
                SinceButton.ForeColor = Color.Blue;
                ChangeTokenButton.ForeColor = Color.Black;

                queryGroupBox.Visible = false;
                optionsGroupBox.Visible = false;
                SinceGroupBox.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeTokenButton_Click(object sender, EventArgs e)
        {
            try
            {
                ViewFieldsButton.ForeColor = Color.Black;
                QueryButton.ForeColor = Color.Black;
                QueryOptionsButton.ForeColor = Color.Black;
                ContainsButton.ForeColor = Color.Black;
                SinceButton.ForeColor = Color.Black;
                ChangeTokenButton.ForeColor = Color.Blue;

                queryGroupBox.Visible = false;
                optionsGroupBox.Visible = false;
                ChangeTokenGroupBox.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void QueryByNameRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitializingQueryControls) return;

            if (QueryByNameRadioButton.Checked && builder != null)
            {
                DialogResult answer = MessageBox.Show("Continuing with this action will clear the complete query. You will have to rebuild your query.",
                    "Query by name", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (answer == DialogResult.OK)
                {
                    // the whole query must be cleared and rebuild
                    Clear();
                    builder.IsQueryByFieldName = true;
                }
                else
                {
                    QueryByNameRadioButton.Checked = false;
                }
            }
        }

        private void QueryByIdRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (isInitializingQueryControls) return;

            if (QueryByIdRadioButton.Checked && builder != null)
            {
                DialogResult answer = MessageBox.Show("Continuing with this action will clear the complete query. You will have to rebuild your query.",
                    "Query by ID", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (answer == DialogResult.OK)
                {
                    // the whole query must be cleared and rebuild
                    Clear();
                    builder.IsQueryByFieldName = false;
                }
                else
                {
                    QueryByIdRadioButton.Checked = false;
                }
            }
        }


        #endregion

        #region Clear button
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            selectedFieldObject = null;

            ClearQueryControls();
            ClearContainsControls();
            ClearViewFieldsControls();
            ClearChangeTokenControls();

            if (builder != null)
            {
                // empty the caml xml document
                builder.Clear();
                OnQueryExpressionChanged();
            }
        }

        private void ClearQueryControls()
        {
            // the treeviews must be cleared
            queryTreeview.Nodes.Clear();

            // the treenodes must be emptied
            selectedFieldObject = null;
            queryNode = null;
            whereNode = null;
            orderByNode = null;

            InitializeQueryControls();

            if (ContainsButton.Visible)
                ContainsButton.Enabled = true;
        }

        private void ClearViewFieldsControls()
        {
            foreach (object item in fieldsToListBox.Items)
            {
                fieldsFromListBox.Items.Add(item);
            }
            fieldsToListBox.Items.Clear();
        }

        private void ClearContainsControls()
        {
            SinceCheckBox.Checked = false;

            InitializeContainsControls();

            if (QueryButton.Visible)
                QueryButton.Enabled = true;
        }

        private void ClearChangeTokenControls()
        {
            ChangeTokenTextBox.Text = string.Empty;
            ChangeTokenCheckBox.Checked = false;
        }
        #endregion

        #region Remove button
        private void queryTreeview_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isRemoved = false;
                selectedTreeNode = queryTreeview.GetNodeAt(e.X, e.Y);
                if (selectedTreeNode != null)
                {
                    queryTreeview.SelectedNode = selectedTreeNode;
                    //					removeMenuItem_Click(_selectedTreeNode, new EventArgs());
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                selectedTreeNode = queryTreeview.GetNodeAt(e.X, e.Y);
                //				if (_selectedTreeNode != null)
                //				{
                //					System.Windows.Forms.TreeViewEventArgs args = new TreeViewEventArgs(_selectedTreeNode, TreeViewAction.ByMouse);
                //					queryTreeview_AfterSelect(queryTreeview, args);			
                //				}
            }
        }

        private void removeMenuItem_Click(object sender, System.EventArgs e)
        {
            if (isNewField) return;
            isRemoving = true;

            bool isOK = false;
            try
            {
                if (isRemoved) return;

                // remove the selected node
                if (queryTreeview.SelectedNode != null)
                {
                    if (queryTreeview.SelectedNode.Tag is OrderField)
                    {
                        XmlNode node = (XmlNode)((OrderField)queryTreeview.SelectedNode.Tag).FieldNode;
                        bool mustRemoveOrderBy = false;
                        // if an OrderBy node is removed, check if the OrderBy node is still needed
                        if (orderByNode.Nodes.Count == 1)
                            mustRemoveOrderBy = true;
                        // update the CAML document
                        builder.RemoveOrderByField(node);
                        if (mustRemoveOrderBy)
                        {
                            orderByNode.Remove();
                            orderByNode = null;
                        }
                        else
                            queryTreeview.SelectedNode.Remove();
                        isOK = true;
                    }
                    else if (queryTreeview.SelectedNode.Tag is WhereField)
                    {
                        XmlNode node = (XmlNode)((WhereField)queryTreeview.SelectedNode.Tag).FieldNode;
                        // if a where node is removed, check if the And or Or node are still needed
                        if (queryTreeview.SelectedNode.Parent.Text == "Where")
                        {
                            queryTreeview.SelectedNode.Parent.Remove();
                            whereNode = null;
                        }
                        else if (queryTreeview.SelectedNode.Parent.Text == "And" || queryTreeview.SelectedNode.Parent.Text == "Or")
                        {
                            TreeNode combinernode = queryTreeview.SelectedNode.Parent;
                            string combiner = combinernode.Text;
                            // TODO : this can result into incorrect CAML
                            if (combinernode.Nodes.Count <= 2)
                            {
                                TreeNode parentNode = queryTreeview.SelectedNode.Parent;
                                TreeNode whereNode = parentNode.Parent;
                                // check if there is still another child present in the combiner node. If so the child must be moved to the Where
                                TreeNode siblingNode = null;
                                if (queryTreeview.SelectedNode.NextNode != null)
                                    siblingNode = queryTreeview.SelectedNode.NextNode;
                                else if (queryTreeview.SelectedNode.PrevNode != null)
                                    siblingNode = queryTreeview.SelectedNode.PrevNode;
                                if (siblingNode != null)
                                {
                                    siblingNode.Remove();
                                    WhereNode.Nodes.Add(siblingNode);
                                }
                                queryTreeview.SelectedNode.Parent.Remove();
                            }
                            else
                            {
                                // remove only the selected node
                                queryTreeview.SelectedNode.Remove();
                            }
                        }
                        else
                        {
                            // remove only the selected node
                            queryTreeview.SelectedNode.Remove();
                        }
                        builder.RemoveWhereField(node);
                        isOK = true;
                    }
                    else if (queryTreeview.SelectedNode.Text == Caml.Constants.Query.OrderBy.Tag)
                    {
                        builder.RemoveOrderByNode();
                        queryTreeview.SelectedNode.Remove();
                        orderByNode = null;
                        isOK = true;
                    }
                    else if (queryTreeview.SelectedNode.Text == Caml.Constants.Query.Where.Tag)
                    {
                        builder.RemoveWhereNode();
                        queryTreeview.SelectedNode.Remove();
                        whereNode = null;
                        isOK = true;
                    }
                }
                // TODO : moet een combiner node ook kunnen gedelete worden? Dan is het misschien een goed idee
                //	      om ook die XmlNode in de TreeNode.Tag te steken.
                isRemoving = false;
                if (isOK)
                {
                    isRemoved = true;
                    isNewField = true;
                    InitializeQueryControls();
                    OnQueryExpressionChanged();
                    return;
                }
                else
                {
                    // in all other cases, the node may not be removed
                    throw new ApplicationException("This node may not be removed. Change its content by using the combo boxes and textboxes on the tab.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Query groupbox functionality
        private void fieldsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (selectedFieldObject == null
                    || selectedFieldObject.InternalName != ((FieldObject)fieldsListBox.SelectedItem).InternalName)
                {
                    isNewField = true;
                    selectedFieldObject = (FieldObject)fieldsListBox.SelectedItem;
                    InitializeQueryControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderByCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (orderByCheckBox.Checked)
                {
                    orderByComboBox.Visible = true;
                    orderByComboBox.SelectedIndex = 0;
                    if (isNewField)
                    {
                        BuildQueryTreeview();
                        // in case of GetListItemChangesSinceToken, only Query or Contains node can be filled
                        if (ContainsButton.Enabled && ContainsButton.Visible)
                            ContainsButton.Enabled = false;
                    }
                }
                else if (!isInitializingQueryControls)
                {
                    isRemoved = false;
                    removeMenuItem_Click(selectedTreeNode, new EventArgs());
                    orderByComboBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orderByComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (selectedFieldObject == null) return;

                isChangeOrderBy = true;
                BuildQueryTreeview();
                isChangeOrderBy = false;
                if (isNewField)
                    isNewField = false;

                // in case of GetListItemChangesSinceToken, only Query or Contains node can be filled
                if (ContainsButton.Enabled && ContainsButton.Visible)
                    ContainsButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void whereCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (selectedFieldObject == null) return;

                if (whereCheckBox.Checked)
                {
                    this.operatorComboBox.Visible = true;
                    this.operatorComboBox.SelectedIndex = 0;
                    this.valueLabel.Visible = true;
                    this.dataTypeTextBox.Text = selectedFieldObject.TypeAsString;
                    this.addFieldButton.Visible = true;
                    // check if this field is a lookup field
                    if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Lookup.ToString())
                    {
                        this.valueTextBox.Visible = false;
                        this.label1.Visible = false;
                        this.label2.Visible = false;
                        this.dataTypeTextBox.Visible = false;
                        this.valueDateTimePicker.Visible = false;
                        this.dateTimeGroupBox.Visible = false;
                        this.valueComboBox.Visible = true;
                        await UtilityFunctions.FillLookupComboBox(valueComboBox, query.Site, selectedFieldObject);
                    }
                    else if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Choice.ToString()
                        || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.MultiChoice.ToString())
                    {
                        this.valueTextBox.Visible = false;
                        this.label1.Visible = false;
                        this.label2.Visible = false;
                        this.dataTypeTextBox.Visible = false;
                        this.valueDateTimePicker.Visible = false;
                        this.dateTimeGroupBox.Visible = false;
                        this.valueComboBox.Visible = true;
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(selectedFieldObject.ChoiceList);
                        XmlNodeList list = xmlDoc.SelectNodes("//CHOICE");
                        foreach (XmlNode node in list)
                            valueComboBox.Items.Add(node.InnerText);
                        if (selectedFieldObject.DefaultChoice != string.Empty)
                            valueComboBox.Text = selectedFieldObject.DefaultChoice;
                    }
                    else if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.ModStat.ToString())
                    {
                        this.valueTextBox.Visible = false;
                        this.label1.Visible = false;
                        this.label2.Visible = false;
                        this.dataTypeTextBox.Visible = false;
                        this.valueDateTimePicker.Visible = false;
                        this.dateTimeGroupBox.Visible = false;
                        this.valueComboBox.Visible = true;

                        this.valueComboBox.Items.Clear();
                        this.valueComboBox.Items.Add("Approved");
                        this.valueComboBox.Items.Add("Pending");
                        this.valueComboBox.Items.Add("Rejected");
                        this.valueComboBox.Items.Add("Draft");
                        this.valueComboBox.Items.Add("Scheduled");
                    }
                    else if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.DateTime.ToString())
                    {
                        this.valueTextBox.Visible = false;
                        this.label1.Visible = false;
                        this.label2.Visible = false;
                        this.dataTypeTextBox.Visible = false;
                        this.valueComboBox.Visible = false;
                        this.valueDateTimePicker.Visible = true;
                        this.dateTimeGroupBox.Visible = true;
                    }
                    else
                    {
                        this.valueTextBox.Visible = true;
                        this.label1.Visible = true;
                        this.label2.Visible = true;
                        this.dataTypeTextBox.Visible = true;
                        this.valueComboBox.Visible = false;
                        this.valueDateTimePicker.Visible = false;
                        this.dateTimeGroupBox.Visible = false;
                    }

                    if (whereNode != null && whereNode.Nodes.Count > 0)
                    {
                        this.combinerComboBox.Visible = true;
                        this.combinerComboBox.SelectedIndex = 0;
                    }
                    if (this.combinerComboBox.Enabled == false)
                        this.combinerComboBox.Enabled = true;
                }
                else if (!isNewField && !isInitializingQueryControls)
                {
                    isRemoved = false;
                    removeMenuItem_Click(selectedTreeNode, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addFieldButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                //BuildQueryCamlString(Caml.Constants.Query.Where.Tag);
                BuildQueryTreeview();
                InitializeQueryControls();

                // in case of GetListItemChangesSinceToken, only Query or Contains node can be filled
                if (ContainsButton.Enabled && ContainsButton.Visible)
                    ContainsButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void queryTreeview_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Parent == null) return;
                if (isRemoving) return;
                InitializeQueryControls();
                isNewField = false;
                selectedTreeNode = e.Node;

                // get the corresponding field in the fields list box
                for (int i = 0; i < fieldsListBox.Items.Count; i++)
                {
                    FieldObject fo = (FieldObject)fieldsListBox.Items[i];
                    if (e.Node.Tag is WhereField)
                    {
                        if (fo.InternalName == ((WhereField)e.Node.Tag).FieldRef)
                            selectedFieldObject = fo;
                    }
                    else if (e.Node.Tag is OrderField)
                    {
                        if (fo.InternalName == ((OrderField)e.Node.Tag).FieldRef)
                            selectedFieldObject = fo;
                    }
                }
                // display the content in the controls
                if (e.Node.Tag is WhereField)
                {
                    this.whereCheckBox.Checked = true;
                    this.operatorComboBox.SelectedIndex = ((WhereField)e.Node.Tag).OperatorIndex;
                    if (((WhereField)e.Node.Tag).DataType == U2U.SharePoint.CAML.Enumerations.DataTypes.Lookup.ToString()
                        || ((WhereField)e.Node.Tag).DataType == U2U.SharePoint.CAML.Enumerations.DataTypes.Choice.ToString()
                        || ((WhereField)e.Node.Tag).DataType == U2U.SharePoint.CAML.Enumerations.DataTypes.MultiChoice.ToString()
                        || ((WhereField)e.Node.Tag).DataType == U2U.SharePoint.CAML.Enumerations.DataTypes.ModStat.ToString())
                        this.valueComboBox.Text = ((WhereField)e.Node.Tag).Value;
                    else
                        this.valueTextBox.Text = ((WhereField)e.Node.Tag).Value;

                    this.dataTypeTextBox.Text = ((WhereField)e.Node.Tag).DataType;
                    this.combinerComboBox.SelectedIndex = System.Convert.ToInt32(e.Node.Parent.Tag);
                    this.combinerComboBox.Enabled = false;
                    this.orderByCheckBox.Checked = false;
                }
                else if (e.Node.Tag is OrderField)
                {
                    this.orderByCheckBox.Checked = true;
                    this.orderByComboBox.SelectedIndex = ((OrderField)e.Node.Tag).OrderByIndex;
                    this.whereCheckBox.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BuildQueryTreeview()
        {
            if (isRemoving) return;

            if (this.orderByCheckBox.Checked)
            {
                if (isNewField)
                {
                    if (selectedFieldObject == null) return;

                    // check if the field is already in the OrderBy node
                    TreeNode orderFieldNode = null;
                    foreach (TreeNode node in OrderByNode.Nodes)
                    {
                        if (node.Text == selectedFieldObject.DisplayName)
                        {
                            isNewField = false;
                            orderFieldNode = node;
                            break;
                        }
                    }
                    if (isNewField)
                        AddOrderByNode();
                    else
                        UpdateOrderByNode(orderFieldNode);
                }
                else
                    UpdateOrderByNode(selectedTreeNode);
            }

            if (this.whereCheckBox.Checked)
            {
                if (isNewField)
                    AddWhereNode();
                else if (whereCheckBox.Checked && selectedTreeNode.Tag is OrderField)
                    AddWhereNode();
                else if (!isNewField && whereCheckBox.Checked)
                    UpdateWhereNode();
                else
                    RemoveWhereNode();
            }

            if (queryTreeview.Nodes.Count > 0)
                queryTreeview.ExpandAll();

            OnQueryExpressionChanged();
        }

        private void AddOrderByNode()
        {
            TreeNode fieldNode = new TreeNode(selectedFieldObject.DisplayName);
            XmlNode xnode = null;
            if (QueryByNameRadioButton.Checked)
                xnode = builder.AddOrderByField(selectedFieldObject.InternalName, this.orderByComboBox.SelectedItem.ToString());
            else
                xnode = builder.AddOrderByField(selectedFieldObject.ID, this.orderByComboBox.SelectedItem.ToString());

            fieldNode.Tag = new OrderField(selectedFieldObject.InternalName, selectedFieldObject.ID, this.orderByComboBox.SelectedIndex, xnode);
            OrderByNode.Nodes.Add(fieldNode);
            selectedTreeNode = fieldNode;
        }

        private void UpdateOrderByNode(TreeNode orderFieldNode)
        {
            // change the values in the node tag
            if (orderFieldNode.Tag is OrderField)
            {
                OrderField orderField = (OrderField)orderFieldNode.Tag;
                if (isChangeOrderBy)
                {
                    orderField.OrderByIndex = this.orderByComboBox.SelectedIndex;
                    orderField.FieldNode = builder.UpdateOrderByField(orderField.FieldNode, this.orderByComboBox.Text);
                }
                else if (!isChangeOrderBy)
                {
                    if (this.orderByCheckBox.Checked)
                        orderField.FieldNode = builder.UpdateOrderByField(orderField.FieldNode, this.orderByComboBox.Text);
                    else
                    {
                        builder.RemoveOrderByField(orderField.FieldNode);
                        selectedTreeNode.Remove();
                    }
                }
            }
        }

        private void AddWhereNode()
        {
            if (selectedFieldObject == null) return;

            TreeNode combinerNode = null;
            string operatortoken = ((System.Xml.Schema.XmlSchemaEnumerationFacet)this.operatorComboBox.SelectedItem).Id;
            string combinertoken = null;
            if (this.combinerComboBox.Visible)
                combinertoken = this.combinerComboBox.SelectedItem.ToString();

            string stringvalue = null;
            if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Lookup.ToString()
                || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Choice.ToString()
                || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.MultiChoice.ToString()
                || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.ModStat.ToString())
                stringvalue = valueComboBox.Text;
            else if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.DateTime.ToString())
                stringvalue = ucDateTime.CalculateDateTimeValue(valueDateTimePicker.Value.ToShortDateString());
            else
                stringvalue = valueTextBox.Text;

            XmlNode xnode = null;
            if (QueryByNameRadioButton.Checked)
                xnode = builder.AddWhereField(selectedFieldObject.InternalName, stringvalue,
                     selectedFieldObject.TypeAsString, operatortoken, combinertoken, out addCombinerNode);
            else
                xnode = builder.AddWhereField(selectedFieldObject.ID, stringvalue,
                     selectedFieldObject.TypeAsString, operatortoken, combinertoken, out addCombinerNode);

            if (addCombinerNode)
            {
                combinerNode = new TreeNode(this.combinerComboBox.SelectedItem.ToString());

                if (WhereNode.FirstNode.Tag is WhereField)
                {
                    // this means that this is the first combiner node to add
                    foreach (TreeNode node in WhereNode.Nodes)
                    {
                        // remove the field node from the where node
                        node.Remove();
                        // add the field node to the combiner node
                        combinerNode.Nodes.Add(node);
                    }
                }
                WhereNode.Nodes.Add(combinerNode);
            }
            else
            {
                // get the eventual corresponding combiner node
                foreach (TreeNode childNode in WhereNode.Nodes)
                {
                    if (this.combinerComboBox.SelectedItem.ToString() == childNode.Text)
                        combinerNode = childNode;
                }
            }

            TreeNode fieldNode = new TreeNode(selectedFieldObject.DisplayName);
            fieldNode.Tag = new WhereField(selectedFieldObject.InternalName, selectedFieldObject.ID,
                this.operatorComboBox.SelectedIndex, stringvalue, selectedFieldObject.TypeAsString, xnode);

            if (combinerNode == null)
                WhereNode.Nodes.Add(fieldNode);
            else
                combinerNode.Nodes.Add(fieldNode);

            selectedTreeNode = fieldNode;
            //			if (this._isNewField)
            //				this._isNewField = false;
        }

        private void UpdateWhereNode()
        {
            string stringvalue = null;
            if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Lookup.ToString()
                || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Choice.ToString()
                || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.MultiChoice.ToString()
                || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.ModStat.ToString())
                stringvalue = valueComboBox.Text;
            else if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.DateTime.ToString())
                stringvalue = ucDateTime.CalculateDateTimeValue(valueDateTimePicker.Value.ToShortDateString());
            else
                stringvalue = valueTextBox.Text;

            XmlNode fieldNode = (XmlNode)((WhereField)selectedTreeNode.Tag).FieldNode;
            string operatortoken = ((System.Xml.Schema.XmlSchemaEnumerationFacet)this.operatorComboBox.SelectedItem).Id;
            ((WhereField)selectedTreeNode.Tag).FieldNode = builder.UpdateWhereField(fieldNode, stringvalue, ((WhereField)selectedTreeNode.Tag).DataType, operatortoken);
            ((WhereField)selectedTreeNode.Tag).Value = stringvalue;
            ((WhereField)selectedTreeNode.Tag).OperatorIndex = this.operatorComboBox.SelectedIndex;
            ((WhereField)selectedTreeNode.Tag).DataType = this.dataTypeTextBox.Text;
        }

        private void RemoveWhereNode()
        {
            XmlNode fieldNode = (XmlNode)((WhereField)selectedTreeNode.Tag).FieldNode;
            builder.RemoveWhereField(fieldNode);
            // TODO : is dat niet ingewikkelder dan dat? ivm combinernode
            selectedTreeNode.Remove();
        }

        #endregion

        #region ViewFields functionality
        private void addAllButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                // move all fields
                for (int i = fieldsFromListBox.Items.Count - 1; i >= 0; i--)
                {
                    FieldObject item = (FieldObject)fieldsFromListBox.Items[i];
                    fieldsToListBox.Items.Insert(0, item);
                    fieldsFromListBox.Items.Remove(item);
                    // KBOS: 08/05/2008: this doesn't seem to work for ViewFields
                    //if (QueryByNameRadioButton.Checked)
                    builder.AddViewField(item.InternalName);
                    //else
                    //    builder.AddViewField(item.ID);
                }
                OnQueryExpressionChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                // move the selected field
                if (fieldsFromListBox.SelectedIndex > -1)
                {
                    FieldObject item = (FieldObject)fieldsFromListBox.SelectedItem;
                    fieldsToListBox.Items.Add(item);
                    fieldsFromListBox.Items.Remove(item);
                    //if (QueryByNameRadioButton.Checked)
                    builder.AddViewField(item.InternalName);
                    //else
                    //    builder.AddViewField(item.ID);
                    OnQueryExpressionChanged();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removeButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                // move the selected field back
                if (fieldsToListBox.SelectedIndex > -1)
                {
                    FieldObject item = (FieldObject)fieldsToListBox.SelectedItem;
                    fieldsFromListBox.Items.Add(item);
                    fieldsToListBox.Items.Remove(item);
                    if (QueryByNameRadioButton.Checked)
                        builder.RemoveViewField(item.InternalName);
                    else
                        builder.RemoveViewField(item.ID);
                    OnQueryExpressionChanged();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void removeAllButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                // move all fields back
                for (int i = fieldsToListBox.Items.Count - 1; i >= 0; i--)
                {
                    FieldObject item = (FieldObject)fieldsToListBox.Items[i];
                    fieldsFromListBox.Items.Insert(0, item);
                    fieldsToListBox.Items.Remove(item);
                    if (QueryByNameRadioButton.Checked)
                        builder.RemoveViewField(item.InternalName);
                    else
                        builder.RemoveViewField(item.ID);
                }
                OnQueryExpressionChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region QueryOptions functionality

        private void QueryFieldIdCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // this should raise an event that all FieldRef Nodes should work with ID instead of Name
        }

        private void includeMandatoryColumnsCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                ValidateQueryOption(Caml.Constants.QueryOptions.IncludedMandatoryColumns, IncludeMandatoryColumnsCheckBox.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateInUtcCheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            try
            {
                ValidateQueryOption(Caml.Constants.QueryOptions.DatesInUtc, DateInUtcCheckBox.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void folderTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ValidateQueryOption(Caml.Constants.QueryOptions.Folder, folderTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pagingTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                ValidateQueryOption(Caml.Constants.QueryOptions.Paging, PagingTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RecursiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (RecursiveCheckBox.Checked)
                {
                    FolderCheckBox.Checked = false;
                    folderTextBox.Text = string.Empty;
                    folderTextBox.Enabled = false;
                }

                ValidateQueryOption(Caml.Constants.QueryOptions.ViewAttributes, RecursiveCheckBox.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExpandUserFieldCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateQueryOption(Caml.Constants.QueryOptions.ExpandUserField, ExpandUserFieldCheckBox.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IncludePermissionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateQueryOption(Caml.Constants.QueryOptions.IncludePermissions, IncludePermissionsCheckBox.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IncludeAttachmentUrlsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateQueryOption(Caml.Constants.QueryOptions.IncludeAttachmentUrls, IncludeAttachmentUrlsCheckBox.Checked);
                if (IncludeAttachmentUrlsCheckBox.Checked)
                    IncludeAttachmentVersionCheckBox.Enabled = true;
                else
                    IncludeAttachmentVersionCheckBox.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IncludeAttachmentVersionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ValidateQueryOption(Caml.Constants.QueryOptions.IncludeAttachmentVersion, IncludeAttachmentVersionCheckBox.Checked);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OptimizeForComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (OptimizeForComboBox.SelectedItem.ToString() == "ItemIds")
                {
                    // This is the default, so remove it from the QueryOptions
                    ValidateQueryOption(Caml.Constants.QueryOptions.OptimizeFor, null);
                }
                else
                {
                    ValidateQueryOption(Caml.Constants.QueryOptions.OptimizeFor, OptimizeForComboBox.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExtraIdsTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                // first remove all extra ids
                ValidateQueryOption(Caml.Constants.QueryOptions.ExtraIds, null);

                if (!string.IsNullOrEmpty(ExtraIdsTextBox.Text))
                {
                    string[] ids = ExtraIdsTextBox.Text.Split(',');
                    if (ids.Length > 0)
                    {
                        foreach (string id in ids)
                        {
                            ValidateQueryOption(Caml.Constants.QueryOptions.ExtraIds, id);
                        }
                    }
                    else
                    {
                        ValidateQueryOption(Caml.Constants.QueryOptions.ExtraIds, ExtraIdsTextBox.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FolderCheckBox.Checked)
            {
                RecursiveCheckBox.Checked = false;
                folderTextBox.Enabled = true;
                folderTextBox.Text = listName + "/";
            }
            else
            {
                folderTextBox.Enabled = false;
                folderTextBox.Text = string.Empty;
            }
        }

        private void ValidateQueryOption(string queryOption, bool value)
        {
            if (isInitializingQueryControls) return;

            if (value)
                builder.AddQueryOptionField(queryOption, true);
            else
                builder.RemoveQueryOptionField(queryOption);
            OnQueryExpressionChanged();
        }

        private void ValidateQueryOption(string queryOption, string value)
        {
            if (isInitializingQueryControls) return;

            if (!string.IsNullOrEmpty(value))
                builder.AddQueryOptionField(queryOption, value);
            else
                builder.RemoveQueryOptionField(queryOption);
            OnQueryExpressionChanged();
        }

        #endregion

        #region Contains functionality

        private void AddContainsFieldButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (isNewField)
                    AddContainsNode();
                else
                    UpdateContainsNode();

                QueryButton.Enabled = false;

                OnQueryExpressionChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ContainsFieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (selectedFieldObject == null ||
                    selectedFieldObject.InternalName != ((FieldObject)ContainsFieldsListBox.SelectedItem).InternalName)
                {
                    isNewField = true;
                    selectedFieldObject = (FieldObject)ContainsFieldsListBox.SelectedItem;
                    InitializeContainsControls();

                    ContainsDataTypeTextBox.Text = selectedFieldObject.TypeAsString;

                    // check if this field is a lookup field
                    if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Lookup.ToString())
                    {
                        ContainsValueTextBox.Visible = false;
                        this.label3.Visible = false;
                        this.label4.Visible = false;
                        ContainsDataTypeTextBox.Visible = false;
                        ContainsValueDateTimePicker.Visible = false;
                        ContainsDateTimeGroupBox.Visible = false;
                        ContainsValueComboBox.Visible = true;
                        await UtilityFunctions.FillLookupComboBox(ContainsValueComboBox, query.Site, selectedFieldObject);
                    }
                    else if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Choice.ToString()
                        || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.MultiChoice.ToString())
                    {
                        ContainsValueTextBox.Visible = false;
                        this.label3.Visible = false;
                        this.label4.Visible = false;
                        ContainsDataTypeTextBox.Visible = false;
                        ContainsValueDateTimePicker.Visible = false;
                        ContainsDateTimeGroupBox.Visible = false;
                        ContainsValueComboBox.Visible = true;

                        ContainsValueComboBox.Items.Clear();
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.LoadXml(selectedFieldObject.ChoiceList);
                        XmlNodeList list = xmlDoc.SelectNodes("//CHOICE");
                        foreach (XmlNode node in list)
                            ContainsValueComboBox.Items.Add(node.InnerText);
                        if (selectedFieldObject.DefaultChoice != string.Empty)
                            ContainsValueComboBox.Text = selectedFieldObject.DefaultChoice;
                    }
                    else if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.ModStat.ToString())
                    {
                        ContainsValueTextBox.Visible = false;
                        this.label3.Visible = false;
                        this.label4.Visible = false;
                        ContainsDataTypeTextBox.Visible = false;
                        ContainsValueDateTimePicker.Visible = false;
                        ContainsDateTimeGroupBox.Visible = false;
                        ContainsValueComboBox.Visible = true;

                        ContainsValueComboBox.Items.Clear();
                        ContainsValueComboBox.Items.Add("Approved");
                        ContainsValueComboBox.Items.Add("Pending");
                        ContainsValueComboBox.Items.Add("Rejected");
                    }
                    else if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.DateTime.ToString())
                    {
                        ContainsValueTextBox.Visible = false;
                        this.label3.Visible = false;
                        this.label4.Visible = false;
                        ContainsDataTypeTextBox.Visible = false;
                        ContainsValueComboBox.Visible = false;
                        ContainsValueDateTimePicker.Visible = true;
                        ContainsDateTimeGroupBox.Visible = true;
                    }
                    else
                    {
                        ContainsValueTextBox.Visible = true;
                        this.label3.Visible = true;
                        this.label4.Visible = true;
                        ContainsDataTypeTextBox.Visible = true;
                        ContainsValueComboBox.Visible = false;
                        ContainsValueDateTimePicker.Visible = false;
                        ContainsDateTimeGroupBox.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddContainsNode()
        {
            if (selectedFieldObject == null) return;

            string stringvalue = null;
            if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Lookup.ToString()
                || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.Choice.ToString()
                || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.MultiChoice.ToString()
                || selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.ModStat.ToString())
                stringvalue = ContainsValueComboBox.Text;
            else if (selectedFieldObject.TypeAsString == U2U.SharePoint.CAML.Enumerations.DataTypes.DateTime.ToString())
                stringvalue = ucContainsDateTime.CalculateDateTimeValue(ContainsValueDateTimePicker.Value.ToShortDateString());
            else
                stringvalue = ContainsValueTextBox.Text;

            if (QueryByNameRadioButton.Checked)
                builder.AddContainsField(selectedFieldObject.InternalName, stringvalue, selectedFieldObject.TypeAsString);
            else
                builder.AddContainsField(selectedFieldObject.ID, stringvalue, selectedFieldObject.TypeAsString);

        }

        private void UpdateContainsNode()
        {
            // TODO
            if (selectedFieldObject == null) return;

        }

        #endregion

        #region Since functionality

        private void SinceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (SinceCheckBox.Checked)
                {
                    SinceDateGroupBox.Enabled = true;
                    //ParameterEvent("since", U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(DateTime.Today));
                }
                else
                {
                    SinceDateGroupBox.Enabled = false;
                    //ParameterEvent("since", null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SinceDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isInitializingQueryControls) return;
                BuildDateTime(SinceDateTimePicker.Value, System.Convert.ToInt32(HourUpDown.Value),
                    System.Convert.ToInt32(MinutesUpDown.Value), System.Convert.ToInt32(SecondsUpDown.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HourUpDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInitializingQueryControls) return;
                BuildDateTime(SinceDateTimePicker.Value, System.Convert.ToInt32(HourUpDown.Value),
                    System.Convert.ToInt32(MinutesUpDown.Value), System.Convert.ToInt32(SecondsUpDown.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MinutesUpDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInitializingQueryControls) return;
                BuildDateTime(SinceDateTimePicker.Value, System.Convert.ToInt32(HourUpDown.Value),
                    System.Convert.ToInt32(MinutesUpDown.Value), System.Convert.ToInt32(SecondsUpDown.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SecondsUpDown_Click(object sender, EventArgs e)
        {
            try
            {
                if (isInitializingQueryControls) return;
                BuildDateTime(SinceDateTimePicker.Value, System.Convert.ToInt32(HourUpDown.Value),
                    System.Convert.ToInt32(MinutesUpDown.Value), System.Convert.ToInt32(SecondsUpDown.Value));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string BuildDateTime(DateTime date, int hours, int minutes, int seconds)
        {
            string datetimestring = null;
            try
            {
                DateTime datetime = new DateTime(date.Year, date.Month, date.Day, hours, minutes, seconds);
                datetimestring = U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(datetime);
                //ParameterEvent("since", datetimestring);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return datetimestring;
        }

        #endregion

        #region ChangeToken region
        private void ChangeTokenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (ChangeTokenCheckBox.Checked)
                {
                    ChangeTokenTextBox.Enabled = true;
                    //ParameterEvent("changetoken", ChangeTokenTextBox.Text);
                }
                else
                {
                    ChangeTokenTextBox.Enabled = false;
                    //ParameterEvent("changetoken", null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }

}
