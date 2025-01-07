namespace U2U.CamlControlLibrary
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Xml;
    //using Microsoft.SharePoint;
    using U2U.SharePoint.CAML;

    /// <summary>
    /// Summary description for UtilityFunctions.
    /// </summary>
    public class UtilityFunctions
    {
        public static async Task FillLookupComboBox(ComboBox valueComboBox, ISite sharePointSite, FieldObject selectedField)
        {
            valueComboBox.Items.Clear();
            foreach (var item in await sharePointSite.GetLookupValues(selectedField).ConfigureAwait(false))
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

        internal static async Task FillFields(ComboBox fieldComboBox, QueryInfo query)
        {
            if (query.List == null || String.IsNullOrEmpty(query.List.Id) || query.Site == null)
            {
                return;
            }

            foreach (var field in await query.Site.GetFields(query.List.Id).ConfigureAwait(false))
            {
                fieldComboBox.Items.Add(field);
            }
        }

        internal static async Task FillFields(ListBox fieldListBox, QueryInfo query)
        {
            if (query.List == null || String.IsNullOrEmpty(query.List.Id) || query.Site == null)
            {
                return;
            }

            foreach (var field in await query.Site.GetFields(query.List.Id).ConfigureAwait(false))
            {
                fieldListBox.Items.Add(field);
            }
        }
    }
}
