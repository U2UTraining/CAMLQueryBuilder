namespace U2U.CamlControlLibrary
{
    partial class WhereElement
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.fieldComboBox = new System.Windows.Forms.ComboBox();
            this.valueTextBox = new System.Windows.Forms.TextBox();
            this.valueDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.valueComboBox = new System.Windows.Forms.ComboBox();
            this.operatorComboBox = new System.Windows.Forms.ComboBox();
            this.dateFunctionsComboBox = new System.Windows.Forms.ComboBox();
            this.datePeriodsComboBox = new System.Windows.Forms.ComboBox();
            this.datePeriodsTextBox = new System.Windows.Forms.TextBox();
            this.dateAddComboBox = new System.Windows.Forms.ComboBox();
            this.dateFunctionsPanel = new System.Windows.Forms.Panel();
            this.dateFunctionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fieldComboBox
            // 
            this.fieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fieldComboBox.FormattingEnabled = true;
            this.fieldComboBox.Location = new System.Drawing.Point(0, 0);
            this.fieldComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.fieldComboBox.Name = "fieldComboBox";
            this.fieldComboBox.Size = new System.Drawing.Size(138, 21);
            this.fieldComboBox.TabIndex = 0;
            this.fieldComboBox.SelectedValueChanged += new System.EventHandler(this.SelectedValueChanged);
            this.fieldComboBox.TextChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // valueTextBox
            // 
            this.valueTextBox.Location = new System.Drawing.Point(237, 0);
            this.valueTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.valueTextBox.Name = "valueTextBox";
            this.valueTextBox.Size = new System.Drawing.Size(153, 20);
            this.valueTextBox.TabIndex = 2;
            this.valueTextBox.Visible = false;
            this.valueTextBox.TextChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // valueDateTimePicker
            // 
            this.valueDateTimePicker.Location = new System.Drawing.Point(319, 49);
            this.valueDateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.valueDateTimePicker.Name = "valueDateTimePicker";
            this.valueDateTimePicker.Size = new System.Drawing.Size(153, 20);
            this.valueDateTimePicker.TabIndex = 5;
            this.valueDateTimePicker.Visible = false;
            this.valueDateTimePicker.ValueChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // valueComboBox
            // 
            this.valueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valueComboBox.FormattingEnabled = true;
            this.valueComboBox.Location = new System.Drawing.Point(237, 24);
            this.valueComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.valueComboBox.Name = "valueComboBox";
            this.valueComboBox.Size = new System.Drawing.Size(153, 21);
            this.valueComboBox.TabIndex = 3;
            this.valueComboBox.Visible = false;
            this.valueComboBox.SelectedValueChanged += new System.EventHandler(this.SelectedValueChanged);
            this.valueComboBox.TextChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // operatorComboBox
            // 
            this.operatorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operatorComboBox.FormattingEnabled = true;
            this.operatorComboBox.Location = new System.Drawing.Point(142, 0);
            this.operatorComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.operatorComboBox.Name = "operatorComboBox";
            this.operatorComboBox.Size = new System.Drawing.Size(92, 21);
            this.operatorComboBox.TabIndex = 1;
            this.operatorComboBox.Visible = false;
            this.operatorComboBox.SelectedValueChanged += new System.EventHandler(this.SelectedValueChanged);
            this.operatorComboBox.TextChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // dateFunctionsComboBox
            // 
            this.dateFunctionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateFunctionsComboBox.FormattingEnabled = true;
            this.dateFunctionsComboBox.Items.AddRange(new object[] {
            "Date",
            "Today",
            "Now"});
            this.dateFunctionsComboBox.Location = new System.Drawing.Point(237, 49);
            this.dateFunctionsComboBox.Name = "dateFunctionsComboBox";
            this.dateFunctionsComboBox.Size = new System.Drawing.Size(77, 21);
            this.dateFunctionsComboBox.TabIndex = 4;
            this.dateFunctionsComboBox.Visible = false;
            this.dateFunctionsComboBox.SelectedValueChanged += new System.EventHandler(this.SelectedValueChanged);
            this.dateFunctionsComboBox.TextChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // datePeriodsComboBox
            // 
            this.datePeriodsComboBox.Items.AddRange(new object[] {
            "Day(s)",
            "Month(s)",
            "Year(s)",
            "Hour(s)",
            "Minute(s)",
            "Second(s)"});
            this.datePeriodsComboBox.Location = new System.Drawing.Point(85, 0);
            this.datePeriodsComboBox.Name = "datePeriodsComboBox";
            this.datePeriodsComboBox.Size = new System.Drawing.Size(104, 21);
            this.datePeriodsComboBox.TabIndex = 8;
            this.datePeriodsComboBox.SelectedValueChanged += new System.EventHandler(this.SelectedValueChanged);
            this.datePeriodsComboBox.TextChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // datePeriodsTextBox
            // 
            this.datePeriodsTextBox.Location = new System.Drawing.Point(47, 0);
            this.datePeriodsTextBox.Name = "datePeriodsTextBox";
            this.datePeriodsTextBox.Size = new System.Drawing.Size(32, 20);
            this.datePeriodsTextBox.TabIndex = 7;
            this.datePeriodsTextBox.TextChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // dateAddComboBox
            // 
            this.dateAddComboBox.Items.AddRange(new object[] {
            "+",
            "-"});
            this.dateAddComboBox.Location = new System.Drawing.Point(1, 0);
            this.dateAddComboBox.Name = "dateAddComboBox";
            this.dateAddComboBox.Size = new System.Drawing.Size(40, 21);
            this.dateAddComboBox.TabIndex = 6;
            this.dateAddComboBox.SelectedValueChanged += new System.EventHandler(this.SelectedValueChanged);
            this.dateAddComboBox.TextChanged += new System.EventHandler(this.SelectedValueChanged);
            // 
            // dateFunctionsPanel
            // 
            this.dateFunctionsPanel.Controls.Add(this.datePeriodsComboBox);
            this.dateFunctionsPanel.Controls.Add(this.dateAddComboBox);
            this.dateFunctionsPanel.Controls.Add(this.datePeriodsTextBox);
            this.dateFunctionsPanel.Location = new System.Drawing.Point(477, 49);
            this.dateFunctionsPanel.Name = "dateFunctionsPanel";
            this.dateFunctionsPanel.Size = new System.Drawing.Size(196, 21);
            this.dateFunctionsPanel.TabIndex = 9;
            this.dateFunctionsPanel.Visible = false;
            // 
            // WhereElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateFunctionsPanel);
            this.Controls.Add(this.dateFunctionsComboBox);
            this.Controls.Add(this.valueComboBox);
            this.Controls.Add(this.valueDateTimePicker);
            this.Controls.Add(this.valueTextBox);
            this.Controls.Add(this.operatorComboBox);
            this.Controls.Add(this.fieldComboBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WhereElement";
            this.Size = new System.Drawing.Size(667, 108);
            this.dateFunctionsPanel.ResumeLayout(false);
            this.dateFunctionsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox fieldComboBox;
        private System.Windows.Forms.TextBox valueTextBox;
        private System.Windows.Forms.DateTimePicker valueDateTimePicker;
        private System.Windows.Forms.ComboBox valueComboBox;
        private System.Windows.Forms.ComboBox operatorComboBox;
        private System.Windows.Forms.ComboBox dateFunctionsComboBox;
        private System.Windows.Forms.ComboBox datePeriodsComboBox;
        private System.Windows.Forms.TextBox datePeriodsTextBox;
        private System.Windows.Forms.ComboBox dateAddComboBox;
        private System.Windows.Forms.Panel dateFunctionsPanel;
    }
}
