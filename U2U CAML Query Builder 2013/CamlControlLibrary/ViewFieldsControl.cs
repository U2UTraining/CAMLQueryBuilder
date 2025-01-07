namespace U2U.CamlControlLibrary
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using U2U.SharePoint.CAML;
    using U2U.SharePoint.CAML.Enumerations;
    using System.Xml;

    public class ViewFieldsControl : UserControl
    {
        private Button addAllButton;
        private Button addButton;
        private Builder builder;
        private ListBox fieldsFromListBox;
        private ListBox fieldsToListBox;
        private string listName;
        private Button removeAllButton;
        private Panel panel1;
        private Button removeButton;

        public ViewFieldsControl()
        {
            InitializeComponent();
        }

        public void Initialize(QueryInfo query)
        {
            this.listName = query.List.Name;
            this.fieldsToListBox.Items.Clear();
            this.fieldsFromListBox.Items.Clear();
            ListBox[] fieldsListBoxes = new ListBox[] { this.fieldsFromListBox };
            UtilityFunctions.FillFields(fieldsFromListBox, query);
            this.builder = new Builder(CamlTypes.GetListItemChanges);
        }

        private void addAllButton_Click(object sender, EventArgs e)
        {
            for (int i = this.fieldsFromListBox.Items.Count - 1; i >= 0; i--)
            {
                FieldObject item = (FieldObject)this.fieldsFromListBox.Items[i];
                this.fieldsToListBox.Items.Insert(0, item);
                this.fieldsFromListBox.Items.Remove(item);
            }
            OnQueryExpressionChanged();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (this.fieldsFromListBox.SelectedIndex > -1)
            {
                FieldObject selectedItem = (FieldObject)this.fieldsFromListBox.SelectedItem;
                this.fieldsToListBox.Items.Add(selectedItem);
                this.fieldsFromListBox.Items.Remove(selectedItem);
            }
            OnQueryExpressionChanged();
        }

        public void Clear()
        {
            this.fieldsToListBox.Items.Clear();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.fieldsToListBox = new System.Windows.Forms.ListBox();
            this.fieldsFromListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.removeAllButton = new System.Windows.Forms.Button();
            this.addAllButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldsToListBox
            // 
            this.fieldsToListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fieldsToListBox.Location = new System.Drawing.Point(247, 4);
            this.fieldsToListBox.Name = "fieldsToListBox";
            this.fieldsToListBox.Size = new System.Drawing.Size(167, 251);
            this.fieldsToListBox.TabIndex = 23;
            this.fieldsToListBox.DoubleClick += new System.EventHandler(this.removeButton_Click);
            // 
            // fieldsFromListBox
            // 
            this.fieldsFromListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.fieldsFromListBox.Location = new System.Drawing.Point(9, 4);
            this.fieldsFromListBox.Name = "fieldsFromListBox";
            this.fieldsFromListBox.Size = new System.Drawing.Size(170, 251);
            this.fieldsFromListBox.TabIndex = 22;
            this.fieldsFromListBox.DoubleClick += new System.EventHandler(this.addButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addButton.Location = new System.Drawing.Point(3, 97);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(53, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = ">";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(3, 126);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(53, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "<";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // removeAllButton
            // 
            this.removeAllButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.removeAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeAllButton.Location = new System.Drawing.Point(3, 155);
            this.removeAllButton.Name = "removeAllButton";
            this.removeAllButton.Size = new System.Drawing.Size(53, 23);
            this.removeAllButton.TabIndex = 2;
            this.removeAllButton.Text = "<<";
            this.removeAllButton.Click += new System.EventHandler(this.removeAllButton_Click);
            // 
            // addAllButton
            // 
            this.addAllButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addAllButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAllButton.Location = new System.Drawing.Point(3, 68);
            this.addAllButton.Name = "addAllButton";
            this.addAllButton.Size = new System.Drawing.Size(53, 23);
            this.addAllButton.TabIndex = 0;
            this.addAllButton.Text = ">>";
            this.addAllButton.Click += new System.EventHandler(this.addAllButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.addAllButton);
            this.panel1.Controls.Add(this.removeAllButton);
            this.panel1.Controls.Add(this.removeButton);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Location = new System.Drawing.Point(182, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(59, 246);
            this.panel1.TabIndex = 24;
            // 
            // ViewFieldsControl
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.fieldsToListBox);
            this.Controls.Add(this.fieldsFromListBox);
            this.Name = "ViewFieldsControl";
            this.Size = new System.Drawing.Size(422, 269);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void removeAllButton_Click(object sender, EventArgs e)
        {
            for (int i = this.fieldsToListBox.Items.Count - 1; i >= 0; i--)
            {
                FieldObject item = (FieldObject)this.fieldsToListBox.Items[i];
                this.fieldsFromListBox.Items.Insert(0, item);
                this.fieldsToListBox.Items.Remove(item);
            }
            OnQueryExpressionChanged();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (this.fieldsToListBox.SelectedIndex > -1)
            {
                FieldObject selectedItem = (FieldObject)this.fieldsToListBox.SelectedItem;
                this.fieldsFromListBox.Items.Add(selectedItem);
                this.fieldsToListBox.Items.Remove(selectedItem);
            }
            OnQueryExpressionChanged();
        }

        public XmlNode BuildQueryExpression(Builder builder)
        {
            foreach (FieldObject field in fieldsToListBox.Items)
            {
                builder.AddViewField(field.InternalName);
            }

            return builder.ViewFieldsNode;
        }

        public event EventHandler QueryExpressionChanged;

        protected void OnQueryExpressionChanged()
        {
            if (QueryExpressionChanged != null)
            {
                QueryExpressionChanged(this, new EventArgs());
            }
        }
    }
}

