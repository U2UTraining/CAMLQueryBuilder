namespace U2U.CamlControlLibrary
{
    using System;
    using System.Xml;
    using System.Windows.Forms;
    using U2U.SharePoint.CAML.Enumerations;
    //using Microsoft.SharePoint;
    using U2U.SharePoint.CAML;

    /// <summary>
    /// Summary description for UtilityFunctions.
    /// </summary>
    public class UtilityFunctions
    {
        public static void FillLookupComboBox(ComboBox valueComboBox, ISite sharePointSite, FieldObject selectedField)
        {
            valueComboBox.Items.Clear();
            foreach (var item in sharePointSite.GetLookupValues(selectedField))
            {
                valueComboBox.Items.Add(item);
            }
        }

        public static void FillChoicesComboBox(ComboBox valueComboBox, FieldObject selectedField)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(selectedField.ChoiceList);
            XmlNodeList list = xmlDoc.SelectNodes("//CHOICE");
            valueComboBox.Items.Clear();
            foreach (XmlNode node in list)
            {
                valueComboBox.Items.Add(node.InnerText);
            }
            if (string.IsNullOrEmpty(selectedField.DefaultChoice))
            {
                valueComboBox.Text = selectedField.DefaultChoice;
            }
        }

        internal static void FillFields(ComboBox fieldComboBox, QueryInfo query)
        {
            if (query.List == null || String.IsNullOrEmpty(query.List.Id) || query.Site == null)
            {
                return;
            }

            foreach (var field in query.Site.GetFields(query.List.Id))
            {
                fieldComboBox.Items.Add(field);
            }
        }

        internal static void FillFields(ListBox fieldListBox, QueryInfo query)
        {
            if (query.List == null || String.IsNullOrEmpty(query.List.Id) || query.Site == null)
            {
                return;
            }

            foreach (var field in query.Site.GetFields(query.List.Id))
            {
                fieldListBox.Items.Add(field);
            }
        }
    }
}
