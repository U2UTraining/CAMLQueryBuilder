using System;
using System.Windows.Forms;
using System.Xml;
using U2U.SharePoint.CAML;
using U2U.SharePoint.CAML.Enumerations;

namespace U2U.CamlControlLibrary
{
    public partial class ContainsControl : UserControl
    {
        private bool isInitializing;

        private QueryInfo query;

        public ContainsControl()
        {
            InitializeComponent();
        }

        public ContainsControl(QueryInfo queryInfo)
            : this()
        {
            // empty the fieldsTo listbox
            query = queryInfo;
            isInitializing = true;
            try
            {
                InitializeContainsControls();
                InitializeSinceControls();
                UtilityFunctions.FillFields(ContainsFieldsListBox, queryInfo).Wait();
            }
            finally
            {
                isInitializing = false;
            }
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
            if (selectedFieldObject == null)
            {
                return null;
            }

            if (query.QueryType == CamlTypes.GetListItemChanges)
            {
                query.Since = Since;
            }
            string stringvalue = null;
            if (selectedFieldObject.TypeAsString == DataTypes.Lookup.ToString()
                || selectedFieldObject.TypeAsString == DataTypes.Choice.ToString()
                || selectedFieldObject.TypeAsString == DataTypes.MultiChoice.ToString()
                || selectedFieldObject.TypeAsString == DataTypes.ModStat.ToString())
            {
                stringvalue = ContainsValueComboBox.Text;
            }
            else if (selectedFieldObject.TypeAsString == DataTypes.DateTime.ToString())
            {
                if (ContainsDateTimeGroupBox.Controls.Count > 0)
                {
                    DateTimeUserControl ucContainsDateTime = ContainsDateTimeGroupBox.Controls[0] as DateTimeUserControl;
                    stringvalue = ucContainsDateTime.CalculateDateTimeValue(ContainsValueDateTimePicker.Value.ToShortDateString());
                }
            }
            else
            {
                stringvalue = ContainsValueTextBox.Text;
            }

            //if (QueryByNameRadioButton.Checked)
            if (builder != null)
            {
                builder.AddContainsField(selectedFieldObject.InternalName, stringvalue, selectedFieldObject.TypeAsString);
            }
            //else
            //    builder.AddContainsField(selectedFieldObject.ID, stringvalue, selectedFieldObject.TypeAsString);

            return null;
        }


        private void InitializeContainsControls()
        {
            ContainsValueTextBox.Text = string.Empty;
            ContainsValueTextBox.TextChanged += (s, e) => OnQueryExpressionChanged();
            ContainsDataTypeTextBox.Text = string.Empty;
            ContainsValueComboBox.Text = string.Empty;
            ContainsValueComboBox.TextChanged += (s, e) => OnQueryExpressionChanged();
            ContainsValueComboBox.Items.Clear();
            ContainsValueComboBox.TextChanged += (s, e) => OnQueryExpressionChanged();

            // Add a DateTime user control
            DateTimeUserControl ucContainsDateTime = new DateTimeUserControl();
            ucContainsDateTime.InitializeControls();
            ContainsDateTimeGroupBox.Controls.Add(ucContainsDateTime);
        }

        private void InitializeSinceControls()
        {
            SincePanel.Visible = query.QueryType == CamlTypes.GetListItemChanges;
            if (query.QueryType == CamlTypes.GetListItemChanges)
            {
                SinceCheckBox.Checked = false;
                SinceDateGroupBox.Enabled = false;
                SinceDateTimePicker.MaxDate = DateTime.Now;
            }
        }

        public string Since
        {
            get
            {
                if (SinceCheckBox.Checked && query.QueryType == CamlTypes.GetListItemChanges)
                {
                    return BuildDateTime(SinceDateTimePicker.Value);
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
                    if (query.QueryType == CamlTypes.GetListItemChanges)
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

                        BuildDateTime(SinceDateTimePicker.Value);
                    }
                }
            }
        }

        #region Since functionality

        private void SinceCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SinceDateGroupBox.Enabled = SinceCheckBox.Checked;
                if (SinceCheckBox.Checked)
                {
                    SinceDateTimePicker.Value = DateTime.Today;
                }
                OnQueryExpressionChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SinceDateTimePickerValueChanged(object sender, EventArgs e)
        {
            BuildDateTime(SinceDateTimePicker.Value);
            OnQueryExpressionChanged();
        }

        private string BuildDateTime(DateTime date)
        {
            if (isInitializing)
            {
                return null;
            }

            try
            {
                DateTime datetime = new DateTime(date.Year, date.Month, date.Day,
                                                 (int)HourUpDown.Value,
                                                 (int)MinutesUpDown.Value,
                                                 (int)SecondsUpDown.Value);
                return U2U.UtilityFunctions.CAML.CreateISO8601DateTimeFromSystemDateTime(datetime);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return null;
        }

        #endregion


        #region Contains functionality

        private bool isNewField;

        private FieldObject selectedFieldObject;

        private void AddContainsFieldButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (isNewField)
            //    {
            //        AddContainsNode();
            //    }
            //    else
            //    {
            //        UpdateContainsNode();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            OnQueryExpressionChanged();
        }

        private async void ContainsFieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (selectedFieldObject == null ||
                    selectedFieldObject.InternalName != ((FieldObject)ContainsFieldsListBox.SelectedItem).InternalName)
                {
                    isNewField = true;
                    selectedFieldObject = ContainsFieldsListBox.SelectedItem as FieldObject;
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
                        {
                            ContainsValueComboBox.Items.Add(node.InnerText);
                        }
                        if (selectedFieldObject.DefaultChoice != string.Empty)
                        {
                            ContainsValueComboBox.Text = selectedFieldObject.DefaultChoice;
                        }
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
                OnQueryExpressionChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddContainsNode()
        {
            AddContainsNode(null);
        }

        private void AddContainsNode(Builder builder)
        {
            if (selectedFieldObject == null)
            {
                return;
            }
            OnQueryExpressionChanged();
        }

        private void UpdateContainsNode()
        {
            // TODO
            if (selectedFieldObject == null) return;

        }

        #endregion

        private void ContainsControl_Load(object sender, EventArgs e)
        {

        }


    }
}
