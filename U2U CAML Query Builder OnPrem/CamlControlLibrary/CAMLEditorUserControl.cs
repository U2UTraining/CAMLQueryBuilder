namespace U2U.CamlControlLibrary
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Web.Services.Protocols;
    using System.Windows.Forms;
    using System.Xml;
    using U2U.SharePoint.CAML.Enumerations;
    using U2U.SharePoint.CAML;
    using System.Xml.Linq;

    /// <summary>
    /// Summary description for CAMLEditorUserControl.
    /// </summary>
    public class CAMLEditorUserControl : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.TextBox camlTextBox;
        private System.Windows.Forms.TabControl queryTabControl;
        private System.Windows.Forms.TabPage editorTabPage;
        private System.Windows.Forms.TabPage resultTabPage;
        private System.Windows.Forms.DataGrid resultDataGrid;
        private System.Windows.Forms.TabPage parametersTabPage;
        private System.Windows.Forms.DataGrid parametersDataGrid;
        private TabPage CSOMTabPage;
        private TextBox CSOMTextBox;
        private TabPage SOMTabPage;
        private TextBox serverTextBox;

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public CAMLEditorUserControl()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
        }


        private QueryInfo query;

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
            this.queryTabControl = new System.Windows.Forms.TabControl();
            this.editorTabPage = new System.Windows.Forms.TabPage();
            this.camlTextBox = new System.Windows.Forms.TextBox();
            this.parametersTabPage = new System.Windows.Forms.TabPage();
            this.parametersDataGrid = new System.Windows.Forms.DataGrid();
            this.resultTabPage = new System.Windows.Forms.TabPage();
            this.resultDataGrid = new System.Windows.Forms.DataGrid();
            this.CSOMTabPage = new System.Windows.Forms.TabPage();
            this.CSOMTextBox = new System.Windows.Forms.TextBox();
            this.SOMTabPage = new System.Windows.Forms.TabPage();
            this.serverTextBox = new System.Windows.Forms.TextBox();
            this.queryTabControl.SuspendLayout();
            this.editorTabPage.SuspendLayout();
            this.parametersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parametersDataGrid)).BeginInit();
            this.resultTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            this.CSOMTabPage.SuspendLayout();
            this.SOMTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryTabControl
            // 
            this.queryTabControl.Controls.Add(this.editorTabPage);
            this.queryTabControl.Controls.Add(this.parametersTabPage);
            this.queryTabControl.Controls.Add(this.resultTabPage);
            this.queryTabControl.Controls.Add(this.CSOMTabPage);
            this.queryTabControl.Controls.Add(this.SOMTabPage);
            this.queryTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryTabControl.Location = new System.Drawing.Point(0, 0);
            this.queryTabControl.Name = "queryTabControl";
            this.queryTabControl.SelectedIndex = 0;
            this.queryTabControl.Size = new System.Drawing.Size(728, 224);
            this.queryTabControl.TabIndex = 8;
            // 
            // editorTabPage
            // 
            this.editorTabPage.Controls.Add(this.camlTextBox);
            this.editorTabPage.Location = new System.Drawing.Point(4, 22);
            this.editorTabPage.Name = "editorTabPage";
            this.editorTabPage.Size = new System.Drawing.Size(720, 198);
            this.editorTabPage.TabIndex = 0;
            this.editorTabPage.Text = "Editor";
            // 
            // camlTextBox
            // 
            this.camlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.camlTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.camlTextBox.Location = new System.Drawing.Point(0, 0);
            this.camlTextBox.Multiline = true;
            this.camlTextBox.Name = "camlTextBox";
            this.camlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.camlTextBox.Size = new System.Drawing.Size(720, 198);
            this.camlTextBox.TabIndex = 0;
            this.camlTextBox.TextChanged += new System.EventHandler(this.QueryTextChanged);
            // 
            // parametersTabPage
            // 
            this.parametersTabPage.Controls.Add(this.parametersDataGrid);
            this.parametersTabPage.Location = new System.Drawing.Point(4, 22);
            this.parametersTabPage.Name = "parametersTabPage";
            this.parametersTabPage.Size = new System.Drawing.Size(720, 198);
            this.parametersTabPage.TabIndex = 2;
            this.parametersTabPage.Text = "Parameters";
            // 
            // parametersDataGrid
            // 
            this.parametersDataGrid.DataMember = "";
            this.parametersDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.parametersDataGrid.Location = new System.Drawing.Point(0, 0);
            this.parametersDataGrid.Name = "parametersDataGrid";
            this.parametersDataGrid.Size = new System.Drawing.Size(720, 198);
            this.parametersDataGrid.TabIndex = 0;
            // 
            // resultTabPage
            // 
            this.resultTabPage.Controls.Add(this.resultDataGrid);
            this.resultTabPage.Location = new System.Drawing.Point(4, 22);
            this.resultTabPage.Name = "resultTabPage";
            this.resultTabPage.Size = new System.Drawing.Size(720, 198);
            this.resultTabPage.TabIndex = 1;
            this.resultTabPage.Text = "Result";
            // 
            // resultDataGrid
            // 
            this.resultDataGrid.DataMember = "";
            this.resultDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.resultDataGrid.Location = new System.Drawing.Point(0, 0);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.ReadOnly = true;
            this.resultDataGrid.Size = new System.Drawing.Size(720, 198);
            this.resultDataGrid.TabIndex = 0;
            // 
            // CSOMTabPage
            // 
            this.CSOMTabPage.Controls.Add(this.CSOMTextBox);
            this.CSOMTabPage.Location = new System.Drawing.Point(4, 22);
            this.CSOMTabPage.Name = "CSOMTabPage";
            this.CSOMTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CSOMTabPage.Size = new System.Drawing.Size(720, 198);
            this.CSOMTabPage.TabIndex = 3;
            this.CSOMTabPage.Text = "CSOM Code";
            this.CSOMTabPage.UseVisualStyleBackColor = true;
            // 
            // CSOMTextBox
            // 
            this.CSOMTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CSOMTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CSOMTextBox.Location = new System.Drawing.Point(3, 3);
            this.CSOMTextBox.Multiline = true;
            this.CSOMTextBox.Name = "CSOMTextBox";
            this.CSOMTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CSOMTextBox.Size = new System.Drawing.Size(714, 192);
            this.CSOMTextBox.TabIndex = 1;
            // 
            // SOMTabPage
            // 
            this.SOMTabPage.Controls.Add(this.serverTextBox);
            this.SOMTabPage.Location = new System.Drawing.Point(4, 22);
            this.SOMTabPage.Name = "SOMTabPage";
            this.SOMTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SOMTabPage.Size = new System.Drawing.Size(720, 198);
            this.SOMTabPage.TabIndex = 4;
            this.SOMTabPage.Text = "Server Code";
            this.SOMTabPage.UseVisualStyleBackColor = true;
            // 
            // serverTextBox
            // 
            this.serverTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverTextBox.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serverTextBox.Location = new System.Drawing.Point(3, 3);
            this.serverTextBox.Multiline = true;
            this.serverTextBox.Name = "serverTextBox";
            this.serverTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverTextBox.Size = new System.Drawing.Size(714, 192);
            this.serverTextBox.TabIndex = 2;
            // 
            // CAMLEditorUserControl
            // 
            this.Controls.Add(this.queryTabControl);
            this.Name = "CAMLEditorUserControl";
            this.Size = new System.Drawing.Size(728, 224);
            this.queryTabControl.ResumeLayout(false);
            this.editorTabPage.ResumeLayout(false);
            this.editorTabPage.PerformLayout();
            this.parametersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parametersDataGrid)).EndInit();
            this.resultTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).EndInit();
            this.CSOMTabPage.ResumeLayout(false);
            this.CSOMTabPage.PerformLayout();
            this.SOMTabPage.ResumeLayout(false);
            this.SOMTabPage.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion


        private List<CamlParameter> parameterList = new List<CamlParameter>();

        private XmlDocument _camlDocument = null;

        private XmlDocument CamlDocument
        {
            get { return _camlDocument; }
            set
            {
                _camlDocument = value;
                var caml = IndentCAML();
                camlTextBox.Text = caml;
                CSOMTextBox.Text = IndentCSOM();
                serverTextBox.Text = IndentSOM();
                resultDataGrid.DataSource = null;
            }
        }

        public void Bind(QueryInfo query)
        {
            this.query = query;
            _camlDocument = query.CamlDocument;
            var caml = IndentCAML();
            camlTextBox.Text = caml;
            CSOMTextBox.Text = IndentCSOM();
            serverTextBox.Text = IndentSOM();
            resultDataGrid.DataSource = null;
            queryTabControl.SelectedIndex = 0;
        }

        private string IndentCSOM()
        {
            string caml = string.Empty;
            string csom = string.Empty;
            if (_camlDocument!=null)
            {
                caml = _camlDocument.InnerXml.Replace("\"", "'").Replace("<GetListItems>", "").Replace("</GetListItems>", "");
            }

            if (!string.IsNullOrEmpty(caml))
            {
                csom = File.ReadAllText("CSOM.code");
                csom = csom.Replace("*SITE*", query.Site.SiteUrl);
                csom = csom.Replace("*LISTID*", this.query.List.Id);
                caml = caml.Replace("\n", "");
                csom = csom.Replace("*CAML*", "<View>" + caml + "</View>");
            }
            return csom;
        }

        private string IndentSOM()
        {
            string caml = string.Empty;
            if (_camlDocument!=null)
            {
                caml = _camlDocument.InnerXml.Replace("\"", "'");
            }
            string som = string.Empty;
            if (!string.IsNullOrEmpty(caml))
            {
                som = File.ReadAllText("Server.code");
                som = som.Replace("*LISTID*", this.query.List.Id);
                caml = caml.Replace("\n", "");
                if (this.query.QueryType == CamlTypes.Query)
                {
                    caml = caml.Replace("<Query>", "").Replace("</Query>", "").Replace("<Query />", "");
                    som = som.Replace("*WHERE*", caml);
                    som = som.Replace("q.ViewFields = @\"*VIEWFIELDS*\";", "");
                }
                else
                {
                    XDocument doc = XDocument.Parse(caml);
                    var c = doc.Element("GetListItems");
                    var q = c.Element("Query");
                     
                    var views = c.Element("ViewFields");

                    if (q!=null)
                    {
                        var query = c.Element("Query").Element("Where");
                        if (query!=null)
                        {
                            som = som.Replace("*WHERE*", query.ToString().Replace("\n", "").Replace("\"","'")); 
                        }
                        else
                        {
                            som = som.Replace("Query = @\"*WHERE*\"", "");
                        }
                        
                    }
                    else
                    {
                        som = som.Replace("Query = @\"*WHERE*\"", "");
                    }
                    if (views!=null)
                    {
                        som = som.Replace("*VIEWFIELDS*", views.ToString().Replace("<ViewFields>", "").Replace("</ViewFields>", "").Replace("\n","").Replace("\"","'")); 
                    }
                }

            }
            return som;
        }

        public override string Text
        {
            get { return this.camlTextBox.Text; }
            set
            {
                if (value != null)
                    this.camlTextBox.Text = value;
            }
        }

        public void Clear()
        {
            this.camlTextBox.Text = string.Empty;
            this.parameterList = new List<CamlParameter>();
            this.resultDataGrid.DataSource = null;
            _camlDocument = null;
        }

        private string IndentCAML()
        {
            string result = null;

            if (_camlDocument != null)
            {
                MemoryStream ms = new MemoryStream();
                XmlTextWriter xw = new XmlTextWriter(ms, System.Text.Encoding.Unicode);
                System.IO.StreamReader sr = null;
                try
                {
                    xw.Formatting = Formatting.Indented;
                    xw.QuoteChar = '\'';
                    xw.Indentation = 3;
                    switch (query.QueryType)
                    {
                        case U2U.SharePoint.CAML.Enumerations.CamlTypes.Query:
                            {
                                _camlDocument.WriteContentTo(xw);
                                break;
                            }
                        default:
                            {
                                if (_camlDocument.FirstChild != null)
                                    _camlDocument.FirstChild.WriteContentTo(xw);
                                break;
                            }
                    }
                    xw.Flush();
                    ms.Flush();
                    ms.Position = 0;
                    sr = new System.IO.StreamReader(ms);
                    result = sr.ReadToEnd();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    xw.Close();
                    ms.Close();
                    sr.Close();
                }
            }

            return result;
        }

        public bool CanExecute
        {
            get
            {
                return !string.IsNullOrEmpty(camlTextBox.Text);
            }
        }

        public void Execute()
        {
            try
            {
                TestQuery();
            }
            catch (SoapException ex)
            {
                MessageBox.Show(ex.Detail.InnerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshEditor()
        {
            var caml = _camlDocument == null ? string.Empty : IndentCAML();
            camlTextBox.Text = caml;
            CSOMTextBox.Text = IndentCSOM();
            serverTextBox.Text = IndentSOM();
            resultDataGrid.DataSource = null;
            queryTabControl.SelectedIndex = 0;
        }

        public bool CanCopyToClipBoard
        {
            get { return !string.IsNullOrEmpty(camlTextBox.Text); }
        }

        public void CopyToClipboard()
        {
            try
            {
                if (this._camlDocument != null)
                {
                    Clipboard.SetDataObject(this._camlDocument.InnerXml, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TestQuery()
        {
            if (query != null && query.Site != null)
            {
                XmlDocument queryDoc = new XmlDataDocument();
                queryDoc.LoadXml(this._camlDocument.OuterXml);
                if (query.QueryType == CamlTypes.Query)
                {
                    resultDataGrid.DataSource = query.Site.GetListItems(query.List.Name, queryDoc);
                }
                else if (query.QueryType == CamlTypes.GetListItems)
                {
                    resultDataGrid.DataSource = query.Site.GetListItems(query.List.Name, queryDoc);
                }
                else if (query.QueryType == CamlTypes.GetListItemChanges)
                {
                    resultDataGrid.DataSource = query.Site.GetListItemChanges(query.List.Name, query.Since, queryDoc);
                }
                else if (query.QueryType == CamlTypes.GetListItemChangesSinceToken)
                {
                    string changeToken = query.ChangeToken;
                    if (parameterList == null)
                    {
                        parameterList = new List<CamlParameter>();
                    }

                    var parameter = parameterList.FirstOrDefault(p => p.ParameterName.Equals("changetoken"));
                    if (parameter != null)
                    {
                        changeToken = parameter.ParameterValue;
                    }
                    else
                    {
                        parameter = new CamlParameter("changetoken", changeToken);
                        parameterList.Add(parameter);
                    }

                    resultDataGrid.DataSource = query.Site.GetListItemChangesSinceToken(query.List.Name, ref changeToken, queryDoc);
                    query.ChangeToken = changeToken;
                    parameter.ParameterValue = changeToken;
                    parametersDataGrid.DataSource = parameterList;
                }
                queryTabControl.SelectedTab = queryTabControl.TabPages[U2U.Constants.UserControls.CamlEditor.TabControl.ResultTab];
            }
            else
            {
                throw new ApplicationException("Please, pass a path to a CAML file first or pass the necessary data like virtual server, site name and list name");
            }

        }

        //private void TestGetListItems()
        //{
        //    U2U.SharePoint.CAML.Client.Helper helper = null;

        //    if (_sharePointSite != null && _sharePointSite.SiteUrl != null && _sharePointSite.SiteUrl != string.Empty)
        //    {
        //        XmlDocument queryDoc = new XmlDataDocument();
        //        XmlNode rootNode = queryDoc.CreateElement(_selectedQueryType.ToString());
        //        rootNode.InnerXml = this.camlTextBox.Text;
        //        queryDoc.AppendChild(rootNode);
        //        helper = new U2U.SharePoint.CAML.Client.Helper(_sharePointSite.SiteUrl, _listName, queryDoc);
        //    }
        //    else
        //    {
        //        throw new ApplicationException("Please, pass a path to a CAML file first or pass the necessary data like virtual server, site name and list name");
        //    }

        //    StringReader sr = null;
        //    switch (_selectedQueryType)
        //    {
        //        case U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItems:
        //            {
        //                if (parametersDataGrid.DataSource == null)
        //                    sr = new StringReader(helper.GetListItems().OuterXml);
        //                else
        //                    sr = new StringReader(helper.GetListItems(parameterList).OuterXml);

        //                XmlTextReader tr = new XmlTextReader(sr);
        //                DataSet ds = new DataSet("resultDataSet");
        //                ds.ReadXml(tr);
        //                if (ds != null && ds.Tables.Count >= 2)
        //                {
        //                    this.resultDataGrid.DataSource = ds.Tables[1];
        //                }
        //                else
        //                {
        //                    this.resultDataGrid.DataSource = null;
        //                }
        //                break;
        //            }
        //        case U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItemChanges:
        //            {
        //                if (parametersDataGrid.DataSource == null)
        //                {
        //                    sr = new System.IO.StringReader(helper.GetListItemChanges(string.Empty).OuterXml);
        //                }
        //                else
        //                {
        //                    sr = new System.IO.StringReader(helper.GetListItemChanges(parameterList).OuterXml);
        //                }
        //                XmlTextReader tr = new XmlTextReader(sr);
        //                DataSet ds = new DataSet("resultDataSet");
        //                ds.ReadXml(tr);
        //                this.resultDataGrid.DataSource = null;
        //                if (ds != null && ds.Tables.Count >= 3)
        //                {
        //                    this.resultDataGrid.DataSource = ds.Tables[2];
        //                }
        //                break;
        //            }
        //        case U2U.SharePoint.CAML.Enumerations.CamlTypes.GetListItemChangesSinceToken:
        //            {
        //                string changeToken = null;
        //                if (parametersDataGrid.DataSource != null)
        //                {
        //                    foreach (U2U.SharePoint.CAML.CamlParameter param in parameterList)
        //                    {
        //                        if (param.ParameterName == "changetoken")
        //                            changeToken = param.ParameterValue;
        //                    }
        //                }

        //                string result = helper.GetListItemChangesSinceToken(ref changeToken).OuterXml;
        //                // a lot of metadata comes back and not everything can be loaded in a datatable. 
        //                // As the changetoken is passed in a ref variable, wer are going to cut out the changes node.
        //                if (result.IndexOf("<Changes") > 0)
        //                {
        //                    //int startindex = result.IndexOf("<rs:data");
        //                    //int endindex = result.IndexOf("</rs:data>");
        //                    //result = result.Substring(startindex, (endindex + 10) - startindex);
        //                    int startindex = result.IndexOf("<Changes");
        //                    int endindex = result.IndexOf("</Changes>");
        //                    result = result.Remove(startindex, (endindex + 10) - startindex);
        //                }
        //                sr = new System.IO.StringReader(result);
        //                XmlTextReader tr = new XmlTextReader(sr);
        //                DataSet ds = new DataSet("resultDataSet");
        //                ds.ReadXml(tr);

        //                // retrieve the changetoken and place it in the datagrid
        //                if (parameterList == null)
        //                    parameterList = new List<U2U.SharePoint.CAML.CamlParameter>();
        //                parameterList.Add(new U2U.SharePoint.CAML.CamlParameter("changetoken", changeToken));
        //                parametersDataGrid.DataSource = parameterList;
        //                ChangedParameterEvent("changetoken", changeToken);

        //                // convert the results into a dataset and display them in the result datagrid
        //                this.resultDataGrid.DataSource = null;
        //                if (ds != null && ds.Tables.Count > 0)
        //                    this.resultDataGrid.DataSource = ds.Tables[ds.Tables.Count - 1];
        //                break;
        //            }
        //        case U2U.SharePoint.CAML.Enumerations.CamlTypes.UpdateListItems:
        //            {
        //                string result = null;
        //                if (parametersDataGrid.DataSource == null)
        //                    result = helper.UpdateListItems().OuterXml;
        //                else
        //                    result = helper.UpdateListItems(parameterList).OuterXml;
        //                // check if a node was created
        //                result = result.Replace("<ID />", "");
        //                sr = new System.IO.StringReader(result);
        //                XmlTextReader tr = new XmlTextReader(sr);
        //                DataSet ds = new DataSet("resultDataSet");
        //                ds.ReadXml(tr);
        //                // both tables should be visible in the grid: the first table contains eventual errors and the second tables contains the changed data
        //                if (ds != null && ds.Tables.Count > 0)
        //                    this.resultDataGrid.DataSource = ds.Tables[0];
        //                break;
        //            }
        //    }
        //    this.queryTabControl.SelectedTab = this.queryTabControl.TabPages[U2U.Constants.UserControls.CamlEditor.TabControl.ResultTab];
        //}

        //private void button2_Click(object sender, System.EventArgs e)
        //{
        //    U2U.SharePoint.CAML.Server.CAMLHelper helper = new U2U.SharePoint.CAML.Server.CAMLHelper(@"C:\TestCaml\products.CAML");
        //    List<U2U.SharePoint.CAML.CamlParameter> pars = new List<U2U.SharePoint.CAML.CamlParameter>(); ;
        //    pars.Add(new U2U.SharePoint.CAML.CamlParameter("Model", "Mountain"));
        //    DataTable dt = helper.ExecuteQuery(pars);
        //    if (dt != null)
        //        resultDataGrid.DataSource = dt;
        //}

        public void GetParameters()
        {
            Builder builder = new Builder(_camlDocument);
            List<CamlParameter> parameters = builder.GetEmptyParameterStructure();
            foreach (CamlParameter parameter in parameters)
            {
                if (!parameterList.Contains(parameter))
                {
                    parameterList.Add(parameter);
                }
            }

            parametersDataGrid.DataSource = parameterList;
        }

        public void AddParameter(string parameterName, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (parameterList == null)
                {
                    parameterList = new List<CamlParameter>();
                }

                parameterList.Add(new CamlParameter(parameterName, value));
                parametersDataGrid.DataSource = parameterList;
            }
        }

        private void getParametersButton_Click(object sender, EventArgs e)
        {
            GetParameters();
        }

        public event EventHandler QueryChanged;

        private void OnQueryChanged()
        {
            if (QueryChanged != null)
            {
                QueryChanged(this, new EventArgs());
            }
        }

        private void QueryTextChanged(object sender, EventArgs e)
        {
            OnQueryChanged();
        }

        internal void Initialize(QueryInfo query)
        {
            Bind(query);
        }
    }
}
