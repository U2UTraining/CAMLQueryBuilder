namespace U2U.CamlControlLibrary
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    using U2U.SharePoint.CAML;
    using U2U.SharePoint.CAML.Enumerations;

    public partial class QueryDesigner : UserControl
    {
        private const string keyQueryTab = "Query";
        private const string keyQueryOptionsTab = "QueryOptions";
        private const string keyViewFieldsTab = "ViewFields";
        private const string keyContainsTab = "Contains";
        private const string keyChangeTokenTab = "ChangeToken";

        public QueryDesigner(QueryInfo query)
        {
            InitializeComponent();
            QueryInfo = query;

            if (query.QueryType == CamlTypes.Query)
            {
                LoadQueryTab();
            }
            else if (query.QueryType == CamlTypes.GetListItems)
            {
                LoadQueryTab();
                LoadViewFieldsTab().Wait();

                //LoadQueryOptionsTab();
            }
            else if (query.QueryType == CamlTypes.GetListItemChanges)
            {
                LoadViewFieldsTab().Wait();
                LoadContainsTab();
            }
            else if (query.QueryType == CamlTypes.GetListItemChangesSinceToken)
            {
                LoadViewFieldsTab().Wait();
                LoadQueryTab();
                LoadContainsTab();
                LoadQueryOptionsTab();
                LoadChangeTokenTab();
            }
            else if (query.QueryType == CamlTypes.UpdateListItems)
            {
                LoadUpdateListItemsTab();
            }

            camlEditor.Initialize(QueryInfo);
            camlEditor.QueryChanged += new EventHandler(QueryTextChanged);
        }

        private void LoadChangeTokenTab()
        {
            ChangeTokenControl control = new ChangeTokenControl(QueryInfo) { Dock = DockStyle.Fill };
            control.QueryExpressionChanged += new EventHandler(RebuildQuery);
            queryTabPages.TabPages.Add(keyChangeTokenTab, "Change Token");
            queryTabPages.TabPages[keyChangeTokenTab].Controls.Add(control);
        }

        private void LoadContainsTab()
        {
            ContainsControl contains = new ContainsControl(QueryInfo) { Dock = DockStyle.Fill };
            contains.QueryExpressionChanged += new EventHandler(RebuildQuery);
            queryTabPages.TabPages.Add(keyContainsTab, "Contains");
            queryTabPages.TabPages[keyContainsTab].Controls.Add(contains);
        }

        private void LoadUpdateListItemsTab()
        {
            UpdateListItemsUserControl updateListItems = new UpdateListItemsUserControl(QueryInfo) { Dock = DockStyle.Fill };
            updateListItems.QueryExpressionChanged += new EventHandler(RebuildQuery);
            splitContainer1.Panel1.Controls.Add(updateListItems);
            queryTabPages.Visible = false;
        }

        private void LoadQueryOptionsTab()
        {
            QueryOptions queryOptions = new QueryOptions();
            queryOptions.Initialize(QueryInfo);
            queryOptions.QueryExpressionChanged += new EventHandler(RebuildQuery);
            queryTabPages.TabPages.Add(keyQueryOptionsTab, "Query options");
            queryTabPages.TabPages[keyQueryOptionsTab].Controls.Add(queryOptions);
        }

        private async Task LoadViewFieldsTab()
        {
            ViewFieldsControl viewFields = new ViewFieldsControl() { Visible = true, Dock = DockStyle.Fill };
            await viewFields.Initialize(QueryInfo).ConfigureAwait(false);
            viewFields.QueryExpressionChanged += new EventHandler(RebuildQuery);
            queryTabPages.TabPages.Add(keyViewFieldsTab, "View fields");
            queryTabPages.TabPages[keyViewFieldsTab].Controls.Add(viewFields);
        }

        private void LoadQueryTab()
        {
            FlowLayoutPanel expressionPanel = new FlowLayoutPanel()
            {
                FlowDirection = FlowDirection.TopDown,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            WhereDesigner condition = new WhereDesigner(QueryInfo);
            condition.QueryExpressionChanged += new EventHandler(RebuildQuery);
            expressionPanel.Controls.Add(condition);

            OrderByDesigner orderBy = new OrderByDesigner(QueryInfo);
            orderBy.QueryExpressionChanged += new EventHandler(RebuildQuery);
            expressionPanel.Controls.Add(orderBy);

            queryTabPages.TabPages.Add(keyQueryTab, "Query");
            queryTabPages.TabPages[keyQueryTab].Controls.Add(expressionPanel);
        }

        public QueryInfo QueryInfo { get; set; }

        public WhereElement SelectedExpression { get; set; }

        public void AddExpression()
        {
            if (queryTabPages.TabPages.ContainsKey(keyQueryTab))
            {
                FlowLayoutPanel expressionPanel = queryTabPages.TabPages[keyQueryTab].Controls[0] as FlowLayoutPanel;
                if (expressionPanel != null)
                {
                    WhereElement expression = new WhereElement(QueryInfo, null);
                    expressionPanel.Controls.Add(expression);
                    expression.Visible = true;
                    expression.Left = 0;
                    expression.Selected += new EventHandler(ExpressionSelected);
                    expression.QueryExpressionChanged += new EventHandler(RebuildQuery);
                    SelectedExpression = expression;
                }
            }
        }

        public void DeleteExpression()
        {
            if (SelectedExpression != null)
            {
                SelectedExpression.QueryExpressionChanged -= RebuildQuery;
                SelectedExpression.Selected -= ExpressionSelected;
                if (queryTabPages.TabPages.ContainsKey(keyQueryTab))
                {
                    FlowLayoutPanel expressionPanel = queryTabPages.TabPages[keyQueryTab].Controls[0] as FlowLayoutPanel;
                    if (expressionPanel != null)
                    {

                        expressionPanel.Controls.Remove(SelectedExpression);
                        if (expressionPanel.Controls.Count > 0)
                        {
                            SelectedExpression = expressionPanel.Controls[expressionPanel.Controls.Count - 1] as WhereElement;
                        }
                        else
                        {
                            SelectedExpression = null;
                        }
                    }
                }
            }
        }

        void AddButtonClick(object sender, EventArgs e)
        {
            AddExpression();
        }

        void DeleteButtonClick(object sender, EventArgs e)
        {
            DeleteExpression();
        }

        void ExpressionSelected(object sender, EventArgs e)
        {
            SelectedExpression = sender as WhereElement;
        }

        private void BuildQuery()
        {
            Builder builder = new Builder(QueryInfo.QueryType);

            if (queryTabPages.TabPages.ContainsKey(keyViewFieldsTab))
            {
                ViewFieldsControl control = queryTabPages.TabPages[keyViewFieldsTab].Controls[0] as ViewFieldsControl;
                control.BuildQueryExpression(builder);
            }

            if (QueryInfo.QueryType == CamlTypes.GetListItemChangesSinceToken)
            {
                ContainsControl contains = queryTabPages.TabPages[keyContainsTab].Controls[0] as ContainsControl;
                FlowLayoutPanel expressionPanel = queryTabPages.TabPages[keyQueryTab].Controls[0] as FlowLayoutPanel;

                BuildWhereElement(builder);
                if (builder.WhereNode.ChildNodes.Count == 0)
                {
                    builder.RemoveQueryNode();
                    contains.BuildQueryExpression(builder);
                }
                if (builder.ContainsNode.ChildNodes.Count == 0)
                {
                    builder.RemoveContainsNode();
                }

                expressionPanel.Visible = !builder.HasContainsNode;
                contains.Visible = !builder.HasWhereNode;
            }
            else
            {
                BuildContainsElement(builder);
                BuildWhereElement(builder);
            }

            BuildQueryOptionsElement(builder);

            if (!queryTabPages.Visible)
            {
                UpdateListItemsUserControl control = splitContainer1.Panel1.Controls[1] as UpdateListItemsUserControl;
                if (control != null)
                {
                    builder = control.Builder;
                    control.BuildQueryExpression(builder);
                }
            }

            QueryInfo.CamlDocument = builder.CamlDocument;
            camlEditor.Bind(QueryInfo);
        }

        private void BuildQueryOptionsElement(Builder builder)
        {
            if (queryTabPages.TabPages.ContainsKey(keyQueryOptionsTab))
            {
                QueryOptions control = queryTabPages.TabPages[keyQueryOptionsTab].Controls[0] as QueryOptions;
                control.BuildQueryExpression(builder);
            }
        }

        private void BuildContainsElement(Builder builder)
        {
            if (queryTabPages.TabPages.ContainsKey(keyContainsTab))
            {
                ContainsControl control = queryTabPages.TabPages[keyContainsTab].Controls[0] as ContainsControl;
                control.BuildQueryExpression(builder);
            }
        }

        private void BuildWhereElement(Builder builder)
        {
            if (queryTabPages.TabPages.ContainsKey(keyQueryTab))
            {
                FlowLayoutPanel expressionPanel = queryTabPages.TabPages[keyQueryTab].Controls[0] as FlowLayoutPanel;
                if (expressionPanel != null)
                {
                    WhereDesigner condition = expressionPanel.Controls[0] as WhereDesigner;
                    if (condition != null)
                    {
                        XmlNode node = condition.BuildQueryExpression(builder);
                        if (node != null)
                        {
                            builder.WhereNode.RemoveAll();
                            builder.WhereNode.AppendChild(node);
                        }
                    }

                    OrderByDesigner orderBy = expressionPanel.Controls[1] as OrderByDesigner;
                    if (orderBy != null)
                    {
                        orderBy.BuildQueryExpression(builder);
                    }
                }
            }
        }

        public event EventHandler QueryRebuilt;

        private void OnQueryRebuilt()
        {
            if (QueryRebuilt != null)
            {
                QueryRebuilt(this, new EventArgs());
            }
        }

        private void RebuildQuery(object sender, EventArgs e)
        {
            SelectedExpression = sender as WhereElement;
            BuildQuery();
            OnQueryRebuilt();
        }

        void QueryTextChanged(object sender, EventArgs e)
        {
            OnQueryRebuilt();
        }

        public void Execute()
        {
            camlEditor.Execute();
        }

        public bool CanExecute
        {
            get { return camlEditor.CanExecute; }
        }

        public void CopyToClipboard()
        {
            camlEditor.CopyToClipboard();
        }

        public bool CanCopyToClipboard
        {
            get { return camlEditor.CanCopyToClipBoard; }
        }

        public void RefreshEditor()
        {
            camlEditor.RefreshEditor();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            camlEditor.CopyToClipboard();
        }

        private void viewFieldsControl_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            BuildQuery();
        }
    }
}
