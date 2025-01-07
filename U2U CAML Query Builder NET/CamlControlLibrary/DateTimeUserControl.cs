namespace U2U.CamlControlLibrary
{
    using System;
    using System.Windows.Forms;

    public class DateTimeUserControl : UserControl
    {
        private ComboBox dateAddComboBox;
        private ComboBox datePeriodsComboBox;
        private TextBox datePeriodsTextBox;
        private RadioButton dateRadioButton;
        private ComboBox nowAddComboBox;
        private ComboBox nowPeriodsComboBox;
        private TextBox nowPeriodsTextBox;
        private RadioButton nowRadioButton;
        private RadioButton parameterRadioButton;
        private TextBox parameterTextBox;
        private ComboBox todayAddComboBox;
        private ComboBox todayPeriodsComboBox;
        private TextBox todayPeriodsTextBox;
        private RadioButton todayRadioButton;

        public DateTimeUserControl()
        {
            this.InitializeComponent();
        }

        public string CalculateDateTimeValue(string dateTimeValue)
        {
            if ((this.dateRadioButton.Checked || this.todayRadioButton.Checked) || (this.nowRadioButton.Checked || this.parameterRadioButton.Checked))
            {
                if (this.parameterRadioButton.Checked)
                {
                    return this.parameterTextBox.Text;
                }
                if (this.dateRadioButton.Checked)
                {
                    return ("[" + dateTimeValue + this.dateAddComboBox.SelectedItem.ToString() + this.datePeriodsTextBox.Text + this.datePeriodsComboBox.SelectedItem.ToString() + "]");
                }
                if (this.todayRadioButton.Checked)
                {
                    return ("[Today" + this.todayAddComboBox.SelectedItem.ToString() + this.todayPeriodsTextBox.Text + this.todayPeriodsComboBox.SelectedItem.ToString() + "]");
                }
            }

            return dateTimeValue;
        }

        private void dateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dateRadioButton.Checked)
            {
                if (this.dateAddComboBox.SelectedIndex == -1)
                {
                    this.dateAddComboBox.SelectedIndex = 0;
                }
                if (this.datePeriodsTextBox.Text == string.Empty)
                {
                    this.datePeriodsTextBox.Text = "1";
                }
                if (this.datePeriodsComboBox.SelectedIndex == -1)
                {
                    this.datePeriodsComboBox.SelectedIndex = 0;
                }
            }
            else
            {
                this.dateAddComboBox.SelectedIndex = -1;
                this.datePeriodsTextBox.Text = string.Empty;
                this.datePeriodsComboBox.SelectedIndex = -1;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.nowPeriodsComboBox = new System.Windows.Forms.ComboBox();
            this.nowPeriodsTextBox = new System.Windows.Forms.TextBox();
            this.nowAddComboBox = new System.Windows.Forms.ComboBox();
            this.nowRadioButton = new System.Windows.Forms.RadioButton();
            this.todayPeriodsComboBox = new System.Windows.Forms.ComboBox();
            this.datePeriodsComboBox = new System.Windows.Forms.ComboBox();
            this.todayPeriodsTextBox = new System.Windows.Forms.TextBox();
            this.datePeriodsTextBox = new System.Windows.Forms.TextBox();
            this.parameterTextBox = new System.Windows.Forms.TextBox();
            this.todayAddComboBox = new System.Windows.Forms.ComboBox();
            this.dateAddComboBox = new System.Windows.Forms.ComboBox();
            this.parameterRadioButton = new System.Windows.Forms.RadioButton();
            this.dateRadioButton = new System.Windows.Forms.RadioButton();
            this.todayRadioButton = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // nowPeriodsComboBox
            // 
            this.nowPeriodsComboBox.Items.AddRange(new object[] {
            "Day(s)",
            "Month(s)",
            "Year(s)",
            "Hour(s)",
            "Minute(s)",
            "Second(s)"});
            this.nowPeriodsComboBox.Location = new System.Drawing.Point(281, 67);
            this.nowPeriodsComboBox.Name = "nowPeriodsComboBox";
            this.nowPeriodsComboBox.Size = new System.Drawing.Size(104, 24);
            this.nowPeriodsComboBox.TabIndex = 27;
            // 
            // nowPeriodsTextBox
            // 
            this.nowPeriodsTextBox.Location = new System.Drawing.Point(239, 67);
            this.nowPeriodsTextBox.Name = "nowPeriodsTextBox";
            this.nowPeriodsTextBox.Size = new System.Drawing.Size(32, 22);
            this.nowPeriodsTextBox.TabIndex = 26;
            // 
            // nowAddComboBox
            // 
            this.nowAddComboBox.Items.AddRange(new object[] {
            "+",
            "-"});
            this.nowAddComboBox.Location = new System.Drawing.Point(191, 67);
            this.nowAddComboBox.Name = "nowAddComboBox";
            this.nowAddComboBox.Size = new System.Drawing.Size(40, 24);
            this.nowAddComboBox.TabIndex = 25;
            // 
            // nowRadioButton
            // 
            this.nowRadioButton.Location = new System.Drawing.Point(9, 66);
            this.nowRadioButton.Name = "nowRadioButton";
            this.nowRadioButton.Size = new System.Drawing.Size(104, 24);
            this.nowRadioButton.TabIndex = 24;
            this.nowRadioButton.Text = "Now";
            this.nowRadioButton.CheckedChanged += new System.EventHandler(this.nowRadioButton_CheckedChanged);
            // 
            // todayPeriodsComboBox
            // 
            this.todayPeriodsComboBox.Items.AddRange(new object[] {
            "Day(s)",
            "Month(s)",
            "Year(s)"});
            this.todayPeriodsComboBox.Location = new System.Drawing.Point(281, 33);
            this.todayPeriodsComboBox.Name = "todayPeriodsComboBox";
            this.todayPeriodsComboBox.Size = new System.Drawing.Size(104, 24);
            this.todayPeriodsComboBox.TabIndex = 23;
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
            this.datePeriodsComboBox.Location = new System.Drawing.Point(281, 3);
            this.datePeriodsComboBox.Name = "datePeriodsComboBox";
            this.datePeriodsComboBox.Size = new System.Drawing.Size(104, 24);
            this.datePeriodsComboBox.TabIndex = 22;
            // 
            // todayPeriodsTextBox
            // 
            this.todayPeriodsTextBox.Location = new System.Drawing.Point(239, 33);
            this.todayPeriodsTextBox.Name = "todayPeriodsTextBox";
            this.todayPeriodsTextBox.Size = new System.Drawing.Size(32, 22);
            this.todayPeriodsTextBox.TabIndex = 21;
            // 
            // datePeriodsTextBox
            // 
            this.datePeriodsTextBox.Location = new System.Drawing.Point(239, 3);
            this.datePeriodsTextBox.Name = "datePeriodsTextBox";
            this.datePeriodsTextBox.Size = new System.Drawing.Size(32, 22);
            this.datePeriodsTextBox.TabIndex = 20;
            // 
            // parameterTextBox
            // 
            this.parameterTextBox.Location = new System.Drawing.Point(191, 99);
            this.parameterTextBox.Name = "parameterTextBox";
            this.parameterTextBox.Size = new System.Drawing.Size(194, 22);
            this.parameterTextBox.TabIndex = 19;
            this.parameterTextBox.Text = "[par]";
            // 
            // todayAddComboBox
            // 
            this.todayAddComboBox.Items.AddRange(new object[] {
            "+",
            "-"});
            this.todayAddComboBox.Location = new System.Drawing.Point(191, 33);
            this.todayAddComboBox.Name = "todayAddComboBox";
            this.todayAddComboBox.Size = new System.Drawing.Size(40, 24);
            this.todayAddComboBox.TabIndex = 18;
            // 
            // dateAddComboBox
            // 
            this.dateAddComboBox.Items.AddRange(new object[] {
            "+",
            "-"});
            this.dateAddComboBox.Location = new System.Drawing.Point(191, 3);
            this.dateAddComboBox.Name = "dateAddComboBox";
            this.dateAddComboBox.Size = new System.Drawing.Size(40, 24);
            this.dateAddComboBox.TabIndex = 17;
            // 
            // parameterRadioButton
            // 
            this.parameterRadioButton.Location = new System.Drawing.Point(9, 98);
            this.parameterRadioButton.Name = "parameterRadioButton";
            this.parameterRadioButton.Size = new System.Drawing.Size(104, 20);
            this.parameterRadioButton.TabIndex = 16;
            this.parameterRadioButton.Text = "Parameter:";
            this.parameterRadioButton.CheckedChanged += new System.EventHandler(this.parameterRadioButton_CheckedChanged);
            // 
            // dateRadioButton
            // 
            this.dateRadioButton.Location = new System.Drawing.Point(9, 2);
            this.dateRadioButton.Name = "dateRadioButton";
            this.dateRadioButton.Size = new System.Drawing.Size(176, 24);
            this.dateRadioButton.TabIndex = 15;
            this.dateRadioButton.Text = "Add to selected date:";
            this.dateRadioButton.CheckedChanged += new System.EventHandler(this.dateRadioButton_CheckedChanged);
            // 
            // todayRadioButton
            // 
            this.todayRadioButton.Location = new System.Drawing.Point(9, 34);
            this.todayRadioButton.Name = "todayRadioButton";
            this.todayRadioButton.Size = new System.Drawing.Size(176, 24);
            this.todayRadioButton.TabIndex = 14;
            this.todayRadioButton.Text = "Today";
            this.todayRadioButton.CheckedChanged += new System.EventHandler(this.todayRadioButton_CheckedChanged);
            // 
            // DateTimeUserControl
            // 
            this.Controls.Add(this.nowPeriodsComboBox);
            this.Controls.Add(this.nowPeriodsTextBox);
            this.Controls.Add(this.nowAddComboBox);
            this.Controls.Add(this.nowRadioButton);
            this.Controls.Add(this.todayPeriodsComboBox);
            this.Controls.Add(this.datePeriodsComboBox);
            this.Controls.Add(this.todayPeriodsTextBox);
            this.Controls.Add(this.datePeriodsTextBox);
            this.Controls.Add(this.parameterTextBox);
            this.Controls.Add(this.todayAddComboBox);
            this.Controls.Add(this.dateAddComboBox);
            this.Controls.Add(this.parameterRadioButton);
            this.Controls.Add(this.dateRadioButton);
            this.Controls.Add(this.todayRadioButton);
            this.Name = "DateTimeUserControl";
            this.Size = new System.Drawing.Size(388, 126);
            this.Load += new System.EventHandler(this.DateTimeUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void InitializeControls()
        {
            this.dateRadioButton.Checked = false;
            this.dateAddComboBox.SelectedIndex = -1;
            this.datePeriodsComboBox.SelectedIndex = -1;
            this.datePeriodsTextBox.Text = string.Empty;
            this.todayRadioButton.Checked = false;
            this.todayAddComboBox.SelectedIndex = -1;
            this.todayPeriodsComboBox.SelectedIndex = -1;
            this.todayPeriodsTextBox.Text = string.Empty;
            this.nowRadioButton.Checked = false;
            this.nowAddComboBox.SelectedIndex = -1;
            this.nowPeriodsComboBox.SelectedIndex = -1;
            this.nowPeriodsTextBox.Text = string.Empty;
            this.parameterRadioButton.Checked = false;
            this.parameterTextBox.Text = "[par]";
        }

        private void nowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.nowRadioButton.Checked)
            {
                if (this.nowAddComboBox.SelectedIndex == -1)
                {
                    this.nowAddComboBox.SelectedIndex = 0;
                }
                if (this.nowPeriodsTextBox.Text == string.Empty)
                {
                    this.nowPeriodsTextBox.Text = "1";
                }
                if (this.nowPeriodsComboBox.SelectedIndex == -1)
                {
                    this.nowPeriodsComboBox.SelectedIndex = 0;
                }
            }
            else
            {
                this.nowAddComboBox.SelectedIndex = -1;
                this.nowPeriodsTextBox.Text = string.Empty;
                this.nowPeriodsComboBox.SelectedIndex = -1;
            }
        }

        private void parameterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.parameterRadioButton.Checked)
            {
                if (this.parameterTextBox.Text == string.Empty)
                {
                    this.parameterTextBox.Text = "[par]";
                }
            }
            else
            {
                this.parameterTextBox.Text = string.Empty;
            }
        }

        private void todayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (this.todayRadioButton.Checked)
            {
                if (this.todayAddComboBox.SelectedIndex == -1)
                {
                    this.todayAddComboBox.SelectedIndex = 0;
                }
                if (this.todayPeriodsTextBox.Text == string.Empty)
                {
                    this.todayPeriodsTextBox.Text = "1";
                }
                if (this.todayPeriodsComboBox.SelectedIndex == -1)
                {
                    this.todayPeriodsComboBox.SelectedIndex = 0;
                }
            }
            else
            {
                this.todayAddComboBox.SelectedIndex = -1;
                this.todayPeriodsTextBox.Text = string.Empty;
                this.todayPeriodsComboBox.SelectedIndex = -1;
            }
        }

        //public event EventHandler Expanded;

        //private void OnExpanded()
        //{
        //    if (Expanded != null)
        //    {
        //        Expanded(this, new EventArgs());
        //    }
        //}

        //public event EventHandler Collapsed;

        //private void OnCollapsed()
        //{
        //    if (Collapsed != null)
        //    {
        //        Collapsed(this, new EventArgs());
        //    }
        //}

        //private void expandButton_Click(object sender, EventArgs e)
        //{
        //    if (Height > 26)
        //    {
        //        Height = 26;
        //        OnCollapsed();
        //    }
        //    else
        //    {
        //        Height = 155;
        //        OnExpanded();
        //    }
        //}

        private void DateTimeUserControl_Load(object sender, EventArgs e)
        {

        }
    }
}

