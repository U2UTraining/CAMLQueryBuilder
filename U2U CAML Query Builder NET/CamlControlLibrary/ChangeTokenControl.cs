namespace U2U.CamlControlLibrary
{
    using System;
    using System.Windows.Forms;
    using System.Xml;
    using U2U.SharePoint.CAML;

    public partial class ChangeTokenControl : UserControl
    {
        public ChangeTokenControl()
        {
            InitializeComponent();
        }

        private QueryInfo query;

        public ChangeTokenControl(QueryInfo queryInfo)
            : this()
        {
            // empty the fieldsTo listbox
            query = queryInfo;
            InitializeSinceControls();
            ChangeTokenTextBox.DataBindings.Add(new Binding("Text", query, "ChangeToken"));
            ChangeTokenTextBox.TextChanged += new EventHandler(ChangeTokenTextBoxTextChanged);
        }

        void ChangeTokenTextBoxTextChanged(object sender, EventArgs e)
        {
            ChangeTokenCheckBox.Checked = !string.IsNullOrEmpty(ChangeTokenTextBox.Text);
        }

        public event EventHandler QueryExpressionChanged;

        protected void OnQueryExpressionChanged()
        {
            if (QueryExpressionChanged != null)
            {
                QueryExpressionChanged(this, new EventArgs());
            }
        }

        public XmlNode BuildQueryExpression(Builder builder)
        {
            return null;
        }

        private void InitializeSinceControls()
        {
            ChangeTokenCheckBox.Checked = false;
            ChangeTokenTextBox.Enabled = false;
        }

        private void ChangeTokenCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ChangeTokenTextBox.Enabled = ChangeTokenCheckBox.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}