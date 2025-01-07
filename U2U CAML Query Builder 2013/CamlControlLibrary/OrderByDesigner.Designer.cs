namespace U2U.CamlControlLibrary
{
    partial class OrderByDesigner
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
            this.addOrderByButton = new System.Windows.Forms.Button();
            this.expressionPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // addOrderByButton
            // 
            this.addOrderByButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addOrderByButton.Location = new System.Drawing.Point(0, 0);
            this.addOrderByButton.Name = "addOrderByButton";
            this.addOrderByButton.Size = new System.Drawing.Size(176, 24);
            this.addOrderByButton.TabIndex = 0;
            this.addOrderByButton.Text = "Add order by element";
            this.addOrderByButton.UseVisualStyleBackColor = true;
            // 
            // expressionPanel
            // 
            this.expressionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.expressionPanel.Location = new System.Drawing.Point(65, 31);
            this.expressionPanel.Name = "expressionPanel";
            this.expressionPanel.Size = new System.Drawing.Size(175, 19);
            this.expressionPanel.TabIndex = 1;
            // 
            // OrderByDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.expressionPanel);
            this.Controls.Add(this.addOrderByButton);
            this.Name = "OrderByDesigner";
            this.Size = new System.Drawing.Size(203, 51);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addOrderByButton;
        private System.Windows.Forms.Panel expressionPanel;
    }
}
