using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using System.IO;
//using Microsoft.SharePoint;
using U2U.SharePoint.CAML;
using U2U.SharePoint.CAML.Enumerations;

namespace U2U.CamlControlLibrary
{
    public partial class WhereElement : UserControl
    {
        public WhereElement(QueryInfo query, WhereDesigner parent)
        {
            InitializeComponent();
            Height = 26;
            this.query = query;
            this.parent = parent;
            UtilityFunctions.FillFields(fieldComboBox, query);
            FillOperators();
            foreach (Control item in Controls)
            {
                item.Top = 0;
            }
            dateFunctionsComboBox.SelectedIndex = 0;
            dateFunctionsComboBox.SelectedIndexChanged += (s, e) => AdaptUI();
        }

        private QueryInfo query;

        internal WhereDesigner parent = null;

        private void FillValueComboBox()
        {
            if (valueComboBox.Visible && selectedField != null)
            {
                if (selectedField.TypeAsString.Equals(DataTypes.Choice.ToString())
                    || selectedField.TypeAsString.Equals(DataTypes.MultiChoice.ToString()))
                {
                    UtilityFunctions.FillChoicesComboBox(valueComboBox, selectedField);
                }
                else if (selectedField.TypeAsString.Equals(DataTypes.Lookup.ToString()))
                {
                    UtilityFunctions.FillLookupComboBox(valueComboBox, query.Site, selectedField);
                }
                else if (selectedField.TypeAsString == DataTypes.ModStat.ToString())
                {
                    valueComboBox.Items.Clear();
                    valueComboBox.Items.Add("Approved");
                    valueComboBox.Items.Add("Pending");
                    valueComboBox.Items.Add("Rejected");
                }
            }
        }

        private void FillOperators()
        {
            operatorComboBox.Items.Clear();
            operatorComboBox.DisplayMember = "Value";
            operatorComboBox.ValueMember = "Id";
            foreach (XmlSchemaFacet facet in GetSchemaEnumerable(this.XsdSchema, Caml.Constants.CamlEnumerations.CamlOperatorEnumeration).Facets)
            {
                operatorComboBox.Items.Add(facet);
            }
        }

        public XmlNode BuildQueryExpression(Builder builder)
        {
            FieldObject field = fieldComboBox.SelectedItem as FieldObject;
            if (field != null)
            {
                bool addCombinerNode;
                string combinerTag = "";
                if (operatorComboBox.SelectedItem != null)
                {
                    string operatorTag = ((XmlSchemaEnumerationFacet)operatorComboBox.SelectedItem).Id;
                    if (field.TypeAsString == "DateTime")
                    {
                        string value = FilterValue;
                        if (!string.IsNullOrEmpty(value))
                        {
                            return builder.AddWhereField(field.InternalName, value, field.TypeAsString, operatorTag, combinerTag, out addCombinerNode);
                        }
                        else
                        {
                            return builder.AddWhereField(field.InternalName, valueDateTimePicker.Value, field.TypeAsString, operatorTag, combinerTag, out addCombinerNode);
                        }
                    }
                    else
                    {
                        return builder.AddWhereField(field.InternalName, FilterValue, field.TypeAsString, operatorTag, combinerTag, out addCombinerNode);
                    }
                }
            }

            return null;
        }

        public string FilterValue
        {
            get
            {
                if (selectedField.TypeAsString.Equals(DataTypes.Choice.ToString())
                                            || selectedField.TypeAsString.Equals(DataTypes.MultiChoice.ToString())
                                            || selectedField.TypeAsString.Equals(DataTypes.Lookup.ToString())
                                            || selectedField.TypeAsString.Equals(DataTypes.ModStat.ToString()))
                {
                    return valueComboBox.Text;
                }
                else if (selectedField.TypeAsString.Equals(DataTypes.DateTime.ToString()))
                {
                    int selectedIndex = dateFunctionsComboBox.SelectedIndex;
                    if (selectedIndex == 0)
                    {
                        int period;
                        if (int.TryParse(datePeriodsTextBox.Text, out period) && !string.IsNullOrEmpty(datePeriodsComboBox.Text))
                        {
                            return ("[" + valueDateTimePicker.Value.ToString() + this.dateAddComboBox.SelectedItem.ToString() + this.datePeriodsTextBox.Text + this.datePeriodsComboBox.Text + "]");
                        }
                    }
                    else if (!string.IsNullOrEmpty(dateAddComboBox.Text) && !string.IsNullOrEmpty(datePeriodsComboBox.Text) && !string.IsNullOrEmpty(datePeriodsTextBox.Text))
                    {
                        if (selectedIndex == 1)
                        {
                            return ("[Today" + dateAddComboBox.Text + datePeriodsTextBox.Text + this.datePeriodsComboBox.Text + "]");
                        }
                        else if (selectedIndex == 2)
                        {
                            return ("[Now" + dateAddComboBox.Text + datePeriodsTextBox.Text + this.datePeriodsComboBox.Text + "]");
                        }
                    }
                }
                else
                {
                    return valueTextBox.Text;
                }

                return null;
            }
        }

        #region CAML Xsd Utilities

        private XmlSchemaSimpleTypeRestriction GetSchemaEnumerable(XmlSchema schema, string enumerable)
        {
            XmlSchemaSimpleType xsdEnumType = (XmlSchemaSimpleType)schema.SchemaTypes[new XmlQualifiedName(enumerable, xsdSchemaUri)];

            return (XmlSchemaSimpleTypeRestriction)xsdEnumType.Content;
        }

        private const string xsdSchemaFile = @"CamlSchema.xsd";
        private const string xsdSchemaUri = @"http://tempuri.org/CamlSchema.xsd";

        private string executionPath;

        private XmlSchema xsdSchema = null;

        private XmlSchema XsdSchema
        {
            get
            {
                if (xsdSchema == null)
                {
                    try
                    {
                        string codeBase = this.GetType().Assembly.CodeBase;
                        executionPath = Path.GetDirectoryName(codeBase);
                        if (executionPath.StartsWith(@"file:\"))
                        {
                            executionPath = executionPath.Remove(0, 6);
                        }
                        string filename = Path.Combine(executionPath, xsdSchemaFile);
                        if (File.Exists(filename))
                        {
                            using (StreamReader sr = new System.IO.StreamReader(filename))
                            {
                                xsdSchema = System.Xml.Schema.XmlSchema.Read(sr, (sender, args) => MessageBox.Show(args.Message));
                                xsdSchema.Compile((sender, args) => MessageBox.Show(args.Message));
                            }
                        }
                        else
                        {
                            MessageBox.Show(String.Format("The CAML xsd schema is not found at {0}", filename));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                return xsdSchema;
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

        public event EventHandler Selected;

        protected void OnSelected()
        {
            if (Selected != null)
            {
                Selected(this, new EventArgs());
            }
        }

        private FieldObject selectedField;

        private void SelectedValueChanged(object sender, EventArgs e)
        {
            OnSelected();
            AdaptUI();
            if (fieldComboBox.SelectedItem != null && operatorComboBox.SelectedItem != null)
            {
                OnQueryExpressionChanged();
            }
        }

        private void AdaptUI()
        {
            operatorComboBox.Visible = true;
            FieldObject field = fieldComboBox.SelectedItem as FieldObject;
            if (field != null)
            {
                if (selectedField != field)
                {
                    selectedField = field;
                    valueComboBox.Visible = (field.TypeAsString.Equals(DataTypes.Choice.ToString())
                                             || field.TypeAsString.Equals(DataTypes.MultiChoice.ToString())
                                             || field.TypeAsString.Equals(DataTypes.Lookup.ToString())
                                             || field.TypeAsString.Equals(DataTypes.ModStat.ToString()));
                    dateFunctionsComboBox.Visible = field.TypeAsString.Equals(DataTypes.DateTime.ToString());
                    dateFunctionsPanel.Visible = dateFunctionsComboBox.Visible;
                    FillValueComboBox();
                }

                if (dateFunctionsComboBox.Visible)
                {
                    int selectedIndex = dateFunctionsComboBox.SelectedIndex;
                    valueDateTimePicker.Visible = selectedIndex == 0;
                    if (selectedIndex == 0)
                    {
                        dateFunctionsPanel.Left = valueDateTimePicker.Left + valueDateTimePicker.Width + 5;
                    }
                    else
                    {
                        dateFunctionsPanel.Left = dateFunctionsComboBox.Left + dateFunctionsComboBox.Width + 5;
                    }
                }
                else
                {
                    valueDateTimePicker.Visible = false;
                }
                valueTextBox.Visible = !dateFunctionsComboBox.Visible && !valueComboBox.Visible;
            }
        }
    }
}
