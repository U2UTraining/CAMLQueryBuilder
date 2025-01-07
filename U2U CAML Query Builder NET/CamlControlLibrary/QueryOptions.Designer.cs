namespace U2U.CamlControlLibrary
{
    partial class QueryOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OptimizeForComboBox = new System.Windows.Forms.ComboBox();
            this.OptimizeForLabel = new System.Windows.Forms.Label();
            this.IncludeMandatoryColumnsCheckBox = new System.Windows.Forms.CheckBox();
            this.ExtraIdsTextBox = new System.Windows.Forms.TextBox();
            this.DateInUtcCheckBox = new System.Windows.Forms.CheckBox();
            this.ExtraIdLabel = new System.Windows.Forms.Label();
            this.RecursiveCheckBox = new System.Windows.Forms.CheckBox();
            this.PagingTextBox = new System.Windows.Forms.TextBox();
            this.pagingLabel = new System.Windows.Forms.Label();
            this.IncludeAttachmentUrlsCheckBox = new System.Windows.Forms.CheckBox();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.IncludeAttachmentVersionCheckBox = new System.Windows.Forms.CheckBox();
            this.FolderCheckBox = new System.Windows.Forms.CheckBox();
            this.ExpandUserFieldCheckBox = new System.Windows.Forms.CheckBox();
            this.IncludePermissionsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OptimizeForComboBox
            // 
            this.OptimizeForComboBox.FormattingEnabled = true;
            this.OptimizeForComboBox.Items.AddRange(new object[] {
            "ItemIds",
            "FolderUrls"});
            this.OptimizeForComboBox.Location = new System.Drawing.Point(538, 3);
            this.OptimizeForComboBox.Name = "OptimizeForComboBox";
            this.OptimizeForComboBox.Size = new System.Drawing.Size(163, 21);
            this.OptimizeForComboBox.TabIndex = 34;
            this.OptimizeForComboBox.Visible = false;
            // 
            // OptimizeForLabel
            // 
            this.OptimizeForLabel.Location = new System.Drawing.Point(461, 2);
            this.OptimizeForLabel.Name = "OptimizeForLabel";
            this.OptimizeForLabel.Size = new System.Drawing.Size(72, 21);
            this.OptimizeForLabel.TabIndex = 33;
            this.OptimizeForLabel.Text = "Optimize for:";
            this.OptimizeForLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OptimizeForLabel.Visible = false;
            // 
            // IncludeMandatoryColumnsCheckBox
            // 
            this.IncludeMandatoryColumnsCheckBox.Location = new System.Drawing.Point(0, 0);
            this.IncludeMandatoryColumnsCheckBox.Name = "IncludeMandatoryColumnsCheckBox";
            this.IncludeMandatoryColumnsCheckBox.Size = new System.Drawing.Size(273, 24);
            this.IncludeMandatoryColumnsCheckBox.TabIndex = 20;
            this.IncludeMandatoryColumnsCheckBox.Text = "Include mandatory columns";
            // 
            // ExtraIdsTextBox
            // 
            this.ExtraIdsTextBox.Location = new System.Drawing.Point(538, 29);
            this.ExtraIdsTextBox.Name = "ExtraIdsTextBox";
            this.ExtraIdsTextBox.Size = new System.Drawing.Size(163, 20);
            this.ExtraIdsTextBox.TabIndex = 32;
            this.ExtraIdsTextBox.Visible = false;
            // 
            // DateInUtcCheckBox
            // 
            this.DateInUtcCheckBox.Location = new System.Drawing.Point(0, 24);
            this.DateInUtcCheckBox.Name = "DateInUtcCheckBox";
            this.DateInUtcCheckBox.Size = new System.Drawing.Size(273, 24);
            this.DateInUtcCheckBox.TabIndex = 21;
            this.DateInUtcCheckBox.Text = "Date in UTC";
            // 
            // ExtraIdLabel
            // 
            this.ExtraIdLabel.Location = new System.Drawing.Point(462, 28);
            this.ExtraIdLabel.Name = "ExtraIdLabel";
            this.ExtraIdLabel.Size = new System.Drawing.Size(61, 21);
            this.ExtraIdLabel.TabIndex = 31;
            this.ExtraIdLabel.Text = "Extra Ids:";
            this.ExtraIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExtraIdLabel.Visible = false;
            // 
            // RecursiveCheckBox
            // 
            this.RecursiveCheckBox.Location = new System.Drawing.Point(0, 50);
            this.RecursiveCheckBox.Name = "RecursiveCheckBox";
            this.RecursiveCheckBox.Size = new System.Drawing.Size(273, 24);
            this.RecursiveCheckBox.TabIndex = 25;
            this.RecursiveCheckBox.Text = "Query all folders and sub folders";
            this.RecursiveCheckBox.CheckedChanged += new System.EventHandler(this.RecursiveCheckBox_CheckedChanged);
            // 
            // PagingTextBox
            // 
            this.PagingTextBox.Location = new System.Drawing.Point(111, 104);
            this.PagingTextBox.Name = "PagingTextBox";
            this.PagingTextBox.Size = new System.Drawing.Size(162, 20);
            this.PagingTextBox.TabIndex = 24;
            // 
            // pagingLabel
            // 
            this.pagingLabel.Location = new System.Drawing.Point(0, 103);
            this.pagingLabel.Name = "pagingLabel";
            this.pagingLabel.Size = new System.Drawing.Size(48, 21);
            this.pagingLabel.TabIndex = 23;
            this.pagingLabel.Text = "Paging:";
            this.pagingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IncludeAttachmentUrlsCheckBox
            // 
            this.IncludeAttachmentUrlsCheckBox.Location = new System.Drawing.Point(279, 50);
            this.IncludeAttachmentUrlsCheckBox.Name = "IncludeAttachmentUrlsCheckBox";
            this.IncludeAttachmentUrlsCheckBox.Size = new System.Drawing.Size(174, 24);
            this.IncludeAttachmentUrlsCheckBox.TabIndex = 29;
            this.IncludeAttachmentUrlsCheckBox.Text = "Include attachment urls";
            this.IncludeAttachmentUrlsCheckBox.Visible = false;
            this.IncludeAttachmentUrlsCheckBox.CheckedChanged += new System.EventHandler(this.IncludeAttachmentUrlsCheckBox_CheckedChanged);
            // 
            // folderTextBox
            // 
            this.folderTextBox.Location = new System.Drawing.Point(111, 78);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(162, 20);
            this.folderTextBox.TabIndex = 22;
            // 
            // IncludeAttachmentVersionCheckBox
            // 
            this.IncludeAttachmentVersionCheckBox.Enabled = false;
            this.IncludeAttachmentVersionCheckBox.Location = new System.Drawing.Point(279, 76);
            this.IncludeAttachmentVersionCheckBox.Name = "IncludeAttachmentVersionCheckBox";
            this.IncludeAttachmentVersionCheckBox.Size = new System.Drawing.Size(174, 24);
            this.IncludeAttachmentVersionCheckBox.TabIndex = 30;
            this.IncludeAttachmentVersionCheckBox.Text = "Include attachment version";
            this.IncludeAttachmentVersionCheckBox.Visible = false;
            // 
            // FolderCheckBox
            // 
            this.FolderCheckBox.Location = new System.Drawing.Point(0, 76);
            this.FolderCheckBox.Name = "FolderCheckBox";
            this.FolderCheckBox.Size = new System.Drawing.Size(105, 24);
            this.FolderCheckBox.TabIndex = 26;
            this.FolderCheckBox.Text = "Query subfolder ";
            this.FolderCheckBox.CheckedChanged += new System.EventHandler(this.FolderCheckBox_CheckedChanged);
            // 
            // ExpandUserFieldCheckBox
            // 
            this.ExpandUserFieldCheckBox.Location = new System.Drawing.Point(279, 0);
            this.ExpandUserFieldCheckBox.Name = "ExpandUserFieldCheckBox";
            this.ExpandUserFieldCheckBox.Size = new System.Drawing.Size(174, 24);
            this.ExpandUserFieldCheckBox.TabIndex = 27;
            this.ExpandUserFieldCheckBox.Text = "Expand user field";
            this.ExpandUserFieldCheckBox.Visible = false;
            // 
            // IncludePermissionsCheckBox
            // 
            this.IncludePermissionsCheckBox.Location = new System.Drawing.Point(279, 24);
            this.IncludePermissionsCheckBox.Name = "IncludePermissionsCheckBox";
            this.IncludePermissionsCheckBox.Size = new System.Drawing.Size(174, 24);
            this.IncludePermissionsCheckBox.TabIndex = 28;
            this.IncludePermissionsCheckBox.Text = "Include permissions";
            this.IncludePermissionsCheckBox.Visible = false;
            // 
            // QueryOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OptimizeForComboBox);
            this.Controls.Add(this.OptimizeForLabel);
            this.Controls.Add(this.IncludeMandatoryColumnsCheckBox);
            this.Controls.Add(this.ExtraIdsTextBox);
            this.Controls.Add(this.DateInUtcCheckBox);
            this.Controls.Add(this.ExtraIdLabel);
            this.Controls.Add(this.RecursiveCheckBox);
            this.Controls.Add(this.PagingTextBox);
            this.Controls.Add(this.pagingLabel);
            this.Controls.Add(this.IncludeAttachmentUrlsCheckBox);
            this.Controls.Add(this.folderTextBox);
            this.Controls.Add(this.IncludeAttachmentVersionCheckBox);
            this.Controls.Add(this.FolderCheckBox);
            this.Controls.Add(this.ExpandUserFieldCheckBox);
            this.Controls.Add(this.IncludePermissionsCheckBox);
            this.Name = "QueryOptions";
            this.Size = new System.Drawing.Size(709, 133);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox OptimizeForComboBox;
        private System.Windows.Forms.Label OptimizeForLabel;
        private System.Windows.Forms.CheckBox IncludeMandatoryColumnsCheckBox;
        private System.Windows.Forms.TextBox ExtraIdsTextBox;
        private System.Windows.Forms.CheckBox DateInUtcCheckBox;
        private System.Windows.Forms.Label ExtraIdLabel;
        private System.Windows.Forms.CheckBox RecursiveCheckBox;
        private System.Windows.Forms.TextBox PagingTextBox;
        private System.Windows.Forms.Label pagingLabel;
        private System.Windows.Forms.CheckBox IncludeAttachmentUrlsCheckBox;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.CheckBox IncludeAttachmentVersionCheckBox;
        private System.Windows.Forms.CheckBox FolderCheckBox;
        private System.Windows.Forms.CheckBox ExpandUserFieldCheckBox;
        private System.Windows.Forms.CheckBox IncludePermissionsCheckBox;
    }
}
