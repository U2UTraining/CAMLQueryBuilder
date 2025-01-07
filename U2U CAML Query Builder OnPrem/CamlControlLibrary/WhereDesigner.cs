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
    public partial class WhereDesigner : UserControl
    {
        public WhereDesigner()
        {
            InitializeComponent();
        }

        public WhereDesigner(QueryInfo query, WhereDesigner parent, WhereElement expression)
        {
            InitializeComponent();
            this.query = query;
            this.parent = parent;
            if (expression == null)
            {
                andOrComboBox.SelectedIndex = 0;
            }
            else
            {
                AddExpression(expression);
            }
        }

        public WhereDesigner(QueryInfo query, WhereDesigner parent)
            : this(query, parent, null)
        {
        }

        public WhereDesigner(QueryInfo query)
            : this(query, null, null)
        {
        }

        internal WhereDesigner parent = null;

        private QueryInfo query;

        private int selectedIndex = 0;

        private bool preventIndexChange = false;

        public void AddExpression(WhereElement expression)
        {
            preventIndexChange = true;
            try
            {
                expression.parent = this;
                expressionPanel.Controls.Add(expression);
                andOrComboBox.SelectedIndex = 0;
                RecalculateSize();
            }
            finally
            {
                preventIndexChange = false;
            }
        }

        public XmlNode BuildQueryExpression(Builder builder)
        {
            if (expressionPanel.Controls.Count == 1)
            {
                WhereElement expression = expressionPanel.Controls[0] as WhereElement;
                if (expression != null)
                {
                    return expression.BuildQueryExpression(builder);
                }
            }
            else
            {
                XmlNode node = builder.AddAndOrNode(andOrComboBox.Text, null);
                foreach (WhereDesigner condition in expressionPanel.Controls)
                {
                    XmlNode childNode = condition.BuildQueryExpression(builder);
                    if (childNode != null)
                    {
                        node.AppendChild(childNode);
                    }
                }

                return node;
            }

            return null;
        }

        private void andOrComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (preventIndexChange)
            {
                return;
            }

            if (andOrComboBox.SelectedIndex == 0)
            {
                if (expressionPanel.Controls.Count == 2)
                {
                    expressionPanel.Controls.RemoveAt(1);
                }
                expressionPanel.Controls.Clear();
                WhereElement expression = new WhereElement(query, this)
                {
                    Visible = true,
                    Left = 0
                };
                expression.QueryExpressionChanged += new EventHandler(expression_QueryExpressionChanged);
                expressionPanel.Controls.Add(expression);
            }
            else if (selectedIndex == 0)
            {
                WhereElement control = null;
                if (expressionPanel.Controls.Count > 0)
                {
                    control = expressionPanel.Controls[0] as WhereElement;
                }

                expressionPanel.Controls.Add(new WhereDesigner(query, this, control)
                {
                    Visible = true,
                    Left = 0,
                    Top = 0
                });
                expressionPanel.Controls.Add(new WhereDesigner(query, this)
                {
                    Visible = true,
                    Left = 0,
                    Top = 0,
                });
            }

            RecalculateSize();
            selectedIndex = andOrComboBox.SelectedIndex;
            InvokeRootQueryExpressionChanged();
        }

        void expression_QueryExpressionChanged(object sender, EventArgs e)
        {
            InvokeRootQueryExpressionChanged();
        }

        private void InvokeRootQueryExpressionChanged()
        {
            WhereDesigner root = this;
            while (root.parent != null)
            {
                root = root.parent;
            }
            root.OnQueryExpressionChanged();
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
            if (parent != null)
            {
                parent.RecalculateSize();
            }
        }
    }
}
