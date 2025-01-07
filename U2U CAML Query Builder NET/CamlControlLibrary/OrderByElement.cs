﻿using System;
using System.Windows.Forms;
using System.Xml;
using U2U.SharePoint.CAML;

namespace U2U.CamlControlLibrary
{
    public partial class OrderByElement : UserControl
    {
        public OrderByElement(QueryInfo query, OrderByDesigner parent)
        {
            InitializeComponent();
            this.parent = parent;
            UtilityFunctions.FillFields(fieldComboBox, query).Wait();

            fieldComboBox.SelectedIndexChanged += new EventHandler(SelectedValueChanged);
            fieldComboBox.TextChanged += new EventHandler(SelectedValueChanged);

            sortTypeComboBox.SelectedIndexChanged += new EventHandler(SelectedValueChanged);
            sortTypeComboBox.TextChanged += new EventHandler(SelectedValueChanged);
        }

        private OrderByDesigner parent = null;

        public XmlNode BuildQueryExpression(Builder builder)
        {
            FieldObject field = fieldComboBox.SelectedItem as FieldObject;
            if (field != null)
            {
                return builder.AddOrderByField(field.InternalName, sortTypeComboBox.Text);
            }
            else
            {
                return null;
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

        private void SelectedValueChanged(object sender, EventArgs e)
        {
            if (fieldComboBox.SelectedItem != null)
            {
                OnQueryExpressionChanged();
            }
        }
    }
}
