namespace U2U.CamlControlLibrary
{
    partial class ChangeTokenControl
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
            this.ChangeTokenTextBox = new System.Windows.Forms.TextBox();
            this.ChangeTokenCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ChangeTokenTextBox
            // 
            this.ChangeTokenTextBox.Enabled = false;
            this.ChangeTokenTextBox.Location = new System.Drawing.Point(9, 30);
            this.ChangeTokenTextBox.Name = "ChangeTokenTextBox";
            this.ChangeTokenTextBox.Size = new System.Drawing.Size(517, 20);
            this.ChangeTokenTextBox.TabIndex = 33;
            // 
            // ChangeTokenCheckBox
            // 
            this.ChangeTokenCheckBox.AutoSize = true;
            this.ChangeTokenCheckBox.Location = new System.Drawing.Point(3, 3);
            this.ChangeTokenCheckBox.Name = "ChangeTokenCheckBox";
            this.ChangeTokenCheckBox.Size = new System.Drawing.Size(169, 17);
            this.ChangeTokenCheckBox.TabIndex = 32;
            this.ChangeTokenCheckBox.Text = "Retrieve changes as of token:";
            this.ChangeTokenCheckBox.UseVisualStyleBackColor = true;
            this.ChangeTokenCheckBox.CheckedChanged += new System.EventHandler(this.ChangeTokenCheckBoxCheckedChanged);
            // 
            // ChangeTokenControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChangeTokenTextBox);
            this.Controls.Add(this.ChangeTokenCheckBox);
            this.Name = "ChangeTokenControl";
            this.Size = new System.Drawing.Size(569, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ChangeTokenTextBox;
        private System.Windows.Forms.CheckBox ChangeTokenCheckBox;
    }
}
