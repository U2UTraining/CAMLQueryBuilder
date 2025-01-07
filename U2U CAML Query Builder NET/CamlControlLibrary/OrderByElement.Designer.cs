namespace U2U.CamlControlLibrary
{
    partial class OrderByElement
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
            this.sortTypeComboBox = new System.Windows.Forms.ComboBox();
            this.fieldComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // sortTypeComboBox
            // 
            this.sortTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortTypeComboBox.FormattingEnabled = true;
            this.sortTypeComboBox.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.sortTypeComboBox.Location = new System.Drawing.Point(189, 0);
            this.sortTypeComboBox.Name = "sortTypeComboBox";
            this.sortTypeComboBox.Size = new System.Drawing.Size(121, 24);
            this.sortTypeComboBox.TabIndex = 4;
            // 
            // fieldComboBox
            // 
            this.fieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fieldComboBox.FormattingEnabled = true;
            this.fieldComboBox.Location = new System.Drawing.Point(0, 0);
            this.fieldComboBox.Name = "fieldComboBox";
            this.fieldComboBox.Size = new System.Drawing.Size(183, 24);
            this.fieldComboBox.TabIndex = 3;
            // 
            // OrderByExpression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sortTypeComboBox);
            this.Controls.Add(this.fieldComboBox);
            this.Name = "OrderByExpression";
            this.Size = new System.Drawing.Size(316, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox sortTypeComboBox;
        private System.Windows.Forms.ComboBox fieldComboBox;
    }
}
