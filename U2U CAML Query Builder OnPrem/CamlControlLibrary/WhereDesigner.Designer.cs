namespace U2U.CamlControlLibrary
{
    partial class WhereDesigner
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
            this.andOrComboBox = new System.Windows.Forms.ComboBox();
            this.expressionPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // andOrComboBox
            // 
            this.andOrComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.andOrComboBox.FormattingEnabled = true;
            this.andOrComboBox.Items.AddRange(new object[] {
            "Filter",
            "And",
            "Or"});
            this.andOrComboBox.Location = new System.Drawing.Point(0, 0);
            this.andOrComboBox.Name = "andOrComboBox";
            this.andOrComboBox.Size = new System.Drawing.Size(60, 24);
            this.andOrComboBox.TabIndex = 1;
            this.andOrComboBox.SelectedIndexChanged += new System.EventHandler(this.andOrComboBox_SelectedIndexChanged);
            // 
            // expressionPanel
            // 
            this.expressionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionPanel.Location = new System.Drawing.Point(65, 0);
            this.expressionPanel.Name = "expressionPanel";
            this.expressionPanel.Size = new System.Drawing.Size(358, 27);
            this.expressionPanel.TabIndex = 2;
            // 
            // WhereDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.expressionPanel);
            this.Controls.Add(this.andOrComboBox);
            this.Name = "WhereDesigner";
            this.Size = new System.Drawing.Size(425, 27);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox andOrComboBox;
        private System.Windows.Forms.Panel expressionPanel;
    }
}
