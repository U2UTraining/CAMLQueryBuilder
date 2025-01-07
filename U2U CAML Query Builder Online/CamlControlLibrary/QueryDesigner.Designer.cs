namespace U2U.CamlControlLibrary
{
    partial class QueryDesigner
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.queryTabPages = new System.Windows.Forms.TabControl();
            this.camlEditor = new U2U.CamlControlLibrary.CAMLEditorUserControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.queryTabPages);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.camlEditor);
            this.splitContainer1.Size = new System.Drawing.Size(625, 600);
            this.splitContainer1.SplitterDistance = 396;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 4;
            // 
            // queryTabPages
            // 
            this.queryTabPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.queryTabPages.Location = new System.Drawing.Point(0, 0);
            this.queryTabPages.Name = "queryTabPages";
            this.queryTabPages.SelectedIndex = 0;
            this.queryTabPages.Size = new System.Drawing.Size(625, 396);
            this.queryTabPages.TabIndex = 1;
            // 
            // camlEditor
            // 
            this.camlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.camlEditor.Location = new System.Drawing.Point(0, 0);
            this.camlEditor.Margin = new System.Windows.Forms.Padding(2);
            this.camlEditor.Name = "camlEditor";
            this.camlEditor.Size = new System.Drawing.Size(625, 201);
            this.camlEditor.TabIndex = 0;
            // 
            // QueryDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "QueryDesigner";
            this.Size = new System.Drawing.Size(625, 600);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CAMLEditorUserControl camlEditor;
        private System.Windows.Forms.TabControl queryTabPages;

    }
}
