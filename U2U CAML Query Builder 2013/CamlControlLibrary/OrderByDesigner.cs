using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using U2U.SharePoint.CAML;
using System.Xml;

namespace U2U.CamlControlLibrary
{
    public partial class OrderByDesigner : UserControl
    {
        public OrderByDesigner(QueryInfo query)
        {
            InitializeComponent();
            this.query = query;
            addOrderByButton.Click += new EventHandler(AddOrderByButtonClick);
        }

        private QueryInfo query;

        public void AddExpression(OrderByElement element)
        {
            element.Visible = true;
            element.Left = 0;
            element.QueryExpressionChanged += new EventHandler(ElementQueryExpressionChanged);
            expressionPanel.Controls.Add(element);
            RecalculateSize();
        }

        public XmlNode BuildQueryExpression(Builder builder)
        {
            foreach (OrderByElement element in expressionPanel.Controls)
            {
                XmlNode childNode = element.BuildQueryExpression(builder);
                if (childNode != null)
                {
                    builder.OrderByNode.AppendChild(childNode);
                }
            }

            return null;
        }

        private void AddOrderByButtonClick(object sender, EventArgs e)
        {
            AddExpression(new OrderByElement(query, this));
        }

        void ElementQueryExpressionChanged(object sender, EventArgs e)
        {
            OnQueryExpressionChanged();
        }

        public event EventHandler QueryExpressionChanged;

        protected void OnQueryExpressionChanged()
        {
            if (QueryExpressionChanged != null)
            {
                QueryExpressionChanged(this, new EventArgs());
            }
        }

        public void RecalculateSize()
        {
            int height = 0;
            int width = 0;
            for (int i = 0; i < expressionPanel.Controls.Count; i++)
            {
                expressionPanel.Controls[i].Top = height;
                height = expressionPanel.Controls[i].Top + expressionPanel.Controls[i].Height + 2;
                width = Math.Max(expressionPanel.Controls[i].Width, width);
            }
            Height = expressionPanel.Top + height;
            Width = expressionPanel.Left + width + 2;
        }
    }
}
