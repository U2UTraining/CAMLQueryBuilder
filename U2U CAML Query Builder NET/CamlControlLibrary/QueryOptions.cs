namespace U2U.CamlControlLibrary
{
    using System;
    using System.Windows.Forms;
    using System.Xml;
    using U2U.SharePoint.CAML;
    using U2U.SharePoint.CAML.Enumerations;

    public partial class QueryOptions : UserControl
    {
        public QueryOptions()
        {
            InitializeComponent();
        }

        bool isInitializing;

        private QueryInfo query;

        public void Initialize(QueryInfo queryInfo)
        {
            isInitializing = true;
            try
            {
                query = queryInfo;
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

                ExtraIdLabel.Visible = query.QueryType == CamlTypes.GetListItemChangesSinceToken;
                ExtraIdsTextBox.Visible = query.QueryType == CamlTypes.GetListItemChangesSinceToken;
                ExpandUserFieldCheckBox.Visible = query.QueryType == CamlTypes.GetListItemChangesSinceToken;
                IncludePermissionsCheckBox.Visible = query.QueryType == CamlTypes.GetListItemChangesSinceToken;
                IncludeAttachmentVersionCheckBox.Visible = query.QueryType == CamlTypes.GetListItemChangesSinceToken;
                IncludeAttachmentUrlsCheckBox.Visible = query.QueryType == CamlTypes.GetListItemChangesSinceToken;

                OptimizeForComboBox.SelectedIndex = 0;

                BindEvents();
            }
            finally
            {
                isInitializing = false;
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
                        {
                            this.OptimizeForComboBox.SelectedIndex = 0;
                        }
                        else
                        {
                            this.OptimizeForComboBox.SelectedIndex = 1;
                        }
                        break;

                    case Caml.Constants.QueryOptions.ViewAttributes:
                        this.RecursiveCheckBox.Checked = true;
                        break;

                }
            }
        }

        private void BindEvents()
        {
            IncludeMandatoryColumnsCheckBox.CheckedChanged += (s, e) => OnQueryExpressionChanged();
            DateInUtcCheckBox.CheckedChanged += (s, e) => OnQueryExpressionChanged();
            folderTextBox.Validating += (s, e) => OnQueryExpressionChanged();
            PagingTextBox.Validating += (s, e) => OnQueryExpressionChanged();
            ExpandUserFieldCheckBox.CheckedChanged += (s, e) => OnQueryExpressionChanged();
            IncludePermissionsCheckBox.CheckedChanged += (s, e) => OnQueryExpressionChanged();
            IncludeAttachmentVersionCheckBox.CheckedChanged += (s, e) => OnQueryExpressionChanged();
            OptimizeForComboBox.SelectedIndexChanged += (s, e) => OnQueryExpressionChanged();
            ExtraIdsTextBox.Leave += (s, e) => OnQueryExpressionChanged();
        }

        #region QueryOptions functionality

        private void QueryFieldIdCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // this should raise an event that all FieldRef Nodes should work with ID instead of Name
        }

        private void RecursiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (RecursiveCheckBox.Checked)
            {
                FolderCheckBox.Checked = false;
                folderTextBox.Text = string.Empty;
                folderTextBox.Enabled = false;
            }
            OnQueryExpressionChanged();
        }


        private void IncludeAttachmentUrlsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            IncludeAttachmentVersionCheckBox.Enabled = IncludeAttachmentUrlsCheckBox.Checked;
            OnQueryExpressionChanged();
        }

        private void FolderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FolderCheckBox.Checked)
            {
                RecursiveCheckBox.Checked = false;
                folderTextBox.Enabled = true;
                folderTextBox.Text = query.List.Name + "/";
            }
            else
            {
                folderTextBox.Enabled = false;
                folderTextBox.Text = string.Empty;
            }
            OnQueryExpressionChanged();
        }

        public XmlNode BuildQueryExpression(Builder builder)
        {
            ValidateQueryOption(builder, Caml.Constants.QueryOptions.IncludedMandatoryColumns, IncludeMandatoryColumnsCheckBox.Checked);
            ValidateQueryOption(builder, Caml.Constants.QueryOptions.DatesInUtc, DateInUtcCheckBox.Checked);
            ValidateQueryOption(builder, Caml.Constants.QueryOptions.Folder, folderTextBox.Text);
            ValidateQueryOption(builder, Caml.Constants.QueryOptions.Paging, PagingTextBox.Text);
            ValidateQueryOption(builder, Caml.Constants.QueryOptions.ViewAttributes, RecursiveCheckBox.Checked);
            ValidateQueryOption(builder, Caml.Constants.QueryOptions.ExpandUserField, ExpandUserFieldCheckBox.Checked);
            ValidateQueryOption(builder, Caml.Constants.QueryOptions.IncludePermissions, IncludePermissionsCheckBox.Checked);
            ValidateQueryOption(builder, Caml.Constants.QueryOptions.IncludeAttachmentUrls, IncludeAttachmentUrlsCheckBox.Checked);
            ValidateQueryOption(builder, Caml.Constants.QueryOptions.IncludeAttachmentVersion, IncludeAttachmentVersionCheckBox.Checked);
            if (OptimizeForComboBox.SelectedItem.ToString() == "ItemIds")
            {
                // This is the default, so remove it from the QueryOptions
                ValidateQueryOption(builder, Caml.Constants.QueryOptions.OptimizeFor, null);
            }
            else
            {
                ValidateQueryOption(builder, Caml.Constants.QueryOptions.OptimizeFor, OptimizeForComboBox.SelectedItem.ToString());
            }
            ValidateQueryOption(builder, Caml.Constants.QueryOptions.ExtraIds, null);

            if (!string.IsNullOrEmpty(ExtraIdsTextBox.Text))
            {
                string[] ids = ExtraIdsTextBox.Text.Split(',');
                if (ids.Length > 0)
                {
                    foreach (string id in ids)
                    {
                        ValidateQueryOption(builder, Caml.Constants.QueryOptions.ExtraIds, id);
                    }
                }
                else
                {
                    ValidateQueryOption(builder, Caml.Constants.QueryOptions.ExtraIds, ExtraIdsTextBox.Text);
                }
            }

            return null;
        }


        private void ValidateQueryOption(Builder builder, string queryOption, bool value)
        {
            if (isInitializing)
            {
                return;
            }

            if (value)
            {
                builder.AddQueryOptionField(queryOption, true);
            }
            else
            {
                builder.RemoveQueryOptionField(queryOption);
            }
        }

        private void ValidateQueryOption(Builder builder, string queryOption, string value)
        {
            if (isInitializing) return;

            if (!string.IsNullOrEmpty(value))
                builder.AddQueryOptionField(queryOption, value);
            else
                builder.RemoveQueryOptionField(queryOption);
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
