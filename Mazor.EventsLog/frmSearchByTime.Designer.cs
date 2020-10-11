namespace Mazor.EventsLog
{
    partial class frmSearchByTime
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbDays = new System.Windows.Forms.GroupBox();
            this.lbDays = new System.Windows.Forms.ListBox();
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.rbTimeInterval = new System.Windows.Forms.RadioButton();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dtTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.gbDate = new System.Windows.Forms.GroupBox();
            this.rbDateInterval = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.chkDay = new System.Windows.Forms.CheckBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.gbDays.SuspendLayout();
            this.gbTime.SuspendLayout();
            this.gbDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDays
            // 
            this.gbDays.Controls.Add(this.lbDays);
            this.gbDays.Location = new System.Drawing.Point(549, 6);
            this.gbDays.Name = "gbDays";
            this.gbDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbDays.Size = new System.Drawing.Size(77, 138);
            this.gbDays.TabIndex = 0;
            this.gbDays.TabStop = false;
            this.gbDays.Text = "יום / ימים";
            // 
            // lbDays
            // 
            this.lbDays.FormattingEnabled = true;
            this.lbDays.Items.AddRange(new object[] {
            "ראשון",
            "שני",
            "שלישי",
            "רביעי",
            "חמישי",
            "שישי",
            "שבת"});
            this.lbDays.Location = new System.Drawing.Point(6, 19);
            this.lbDays.Name = "lbDays";
            this.lbDays.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbDays.Size = new System.Drawing.Size(64, 108);
            this.lbDays.TabIndex = 2;
            // 
            // gbTime
            // 
            this.gbTime.Controls.Add(this.rbTimeInterval);
            this.gbTime.Controls.Add(this.rbTime);
            this.gbTime.Controls.Add(this.lblTime);
            this.gbTime.Controls.Add(this.lblTo);
            this.gbTime.Controls.Add(this.lblFrom);
            this.gbTime.Controls.Add(this.dtTimeTo);
            this.gbTime.Controls.Add(this.dtTimeFrom);
            this.gbTime.Controls.Add(this.dtTime);
            this.gbTime.Location = new System.Drawing.Point(322, 6);
            this.gbTime.Name = "gbTime";
            this.gbTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbTime.Size = new System.Drawing.Size(196, 138);
            this.gbTime.TabIndex = 1;
            this.gbTime.TabStop = false;
            this.gbTime.Text = "זמן";
            // 
            // rbTimeInterval
            // 
            this.rbTimeInterval.AutoSize = true;
            this.rbTimeInterval.Location = new System.Drawing.Point(172, 81);
            this.rbTimeInterval.Name = "rbTimeInterval";
            this.rbTimeInterval.Size = new System.Drawing.Size(14, 13);
            this.rbTimeInterval.TabIndex = 7;
            this.rbTimeInterval.TabStop = true;
            this.rbTimeInterval.UseVisualStyleBackColor = true;
            this.rbTimeInterval.CheckedChanged += new System.EventHandler(this.rbTimeInterval_CheckedChanged);
            // 
            // rbTime
            // 
            this.rbTime.AutoSize = true;
            this.rbTime.Location = new System.Drawing.Point(172, 23);
            this.rbTime.Name = "rbTime";
            this.rbTime.Size = new System.Drawing.Size(14, 13);
            this.rbTime.TabIndex = 6;
            this.rbTime.TabStop = true;
            this.rbTime.UseVisualStyleBackColor = true;
            this.rbTime.CheckedChanged += new System.EventHandler(this.rbTime_CheckedChanged);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(131, 22);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(24, 13);
            this.lblTime.TabIndex = 5;
            this.lblTime.Text = "זמן";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(134, 104);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "עד";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(138, 80);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(17, 13);
            this.lblFrom.TabIndex = 3;
            this.lblFrom.Text = "מ-";
            // 
            // dtTimeTo
            // 
            this.dtTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimeTo.Location = new System.Drawing.Point(12, 102);
            this.dtTimeTo.Name = "dtTimeTo";
            this.dtTimeTo.Size = new System.Drawing.Size(109, 20);
            this.dtTimeTo.TabIndex = 2;
            // 
            // dtTimeFrom
            // 
            this.dtTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTimeFrom.Location = new System.Drawing.Point(12, 76);
            this.dtTimeFrom.Name = "dtTimeFrom";
            this.dtTimeFrom.Size = new System.Drawing.Size(109, 20);
            this.dtTimeFrom.TabIndex = 1;
            // 
            // dtTime
            // 
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTime.Location = new System.Drawing.Point(12, 19);
            this.dtTime.Name = "dtTime";
            this.dtTime.Size = new System.Drawing.Size(109, 20);
            this.dtTime.TabIndex = 0;
            // 
            // gbDate
            // 
            this.gbDate.Controls.Add(this.rbDateInterval);
            this.gbDate.Controls.Add(this.rbDate);
            this.gbDate.Controls.Add(this.lblDate);
            this.gbDate.Controls.Add(this.lblToDate);
            this.gbDate.Controls.Add(this.lblFromDate);
            this.gbDate.Controls.Add(this.dtDateTo);
            this.gbDate.Controls.Add(this.dtDateFrom);
            this.gbDate.Controls.Add(this.dtDate);
            this.gbDate.Location = new System.Drawing.Point(4, 6);
            this.gbDate.Name = "gbDate";
            this.gbDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbDate.Size = new System.Drawing.Size(287, 138);
            this.gbDate.TabIndex = 2;
            this.gbDate.TabStop = false;
            this.gbDate.Text = "תאריך";
            // 
            // rbDateInterval
            // 
            this.rbDateInterval.AutoSize = true;
            this.rbDateInterval.Location = new System.Drawing.Point(261, 81);
            this.rbDateInterval.Name = "rbDateInterval";
            this.rbDateInterval.Size = new System.Drawing.Size(14, 13);
            this.rbDateInterval.TabIndex = 12;
            this.rbDateInterval.TabStop = true;
            this.rbDateInterval.UseVisualStyleBackColor = true;
            this.rbDateInterval.CheckedChanged += new System.EventHandler(this.rbDateInterval_CheckedChanged);
            // 
            // rbDate
            // 
            this.rbDate.AutoSize = true;
            this.rbDate.Location = new System.Drawing.Point(261, 23);
            this.rbDate.Name = "rbDate";
            this.rbDate.Size = new System.Drawing.Size(14, 13);
            this.rbDate.TabIndex = 11;
            this.rbDate.TabStop = true;
            this.rbDate.UseVisualStyleBackColor = true;
            this.rbDate.CheckedChanged += new System.EventHandler(this.rbDate_CheckedChanged);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(220, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 13);
            this.lblDate.TabIndex = 10;
            this.lblDate.Text = "תאריך";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(234, 104);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(21, 13);
            this.lblToDate.TabIndex = 9;
            this.lblToDate.Text = "עד";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(238, 81);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(17, 13);
            this.lblFromDate.TabIndex = 8;
            this.lblFromDate.Text = "מ-";
            // 
            // dtDateTo
            // 
            this.dtDateTo.Location = new System.Drawing.Point(14, 102);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(200, 20);
            this.dtDateTo.TabIndex = 2;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.Location = new System.Drawing.Point(14, 75);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(200, 20);
            this.dtDateFrom.TabIndex = 1;
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(14, 19);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(200, 20);
            this.dtDate.TabIndex = 0;
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(264, 150);
            this.chkDate.Name = "chkDate";
            this.chkDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDate.Size = new System.Drawing.Size(15, 14);
            this.chkDate.TabIndex = 3;
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Location = new System.Drawing.Point(493, 150);
            this.chkTime.Name = "chkTime";
            this.chkTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTime.Size = new System.Drawing.Size(15, 14);
            this.chkTime.TabIndex = 4;
            this.chkTime.UseVisualStyleBackColor = true;
            this.chkTime.CheckedChanged += new System.EventHandler(this.chkTime_CheckedChanged);
            // 
            // chkDay
            // 
            this.chkDay.AutoSize = true;
            this.chkDay.Location = new System.Drawing.Point(604, 150);
            this.chkDay.Name = "chkDay";
            this.chkDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDay.Size = new System.Drawing.Size(15, 14);
            this.chkDay.TabIndex = 5;
            this.chkDay.UseVisualStyleBackColor = true;
            this.chkDay.CheckedChanged += new System.EventHandler(this.chkDay_CheckedChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(4, 184);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "בצע";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // frmSearchByTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 219);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.chkDay);
            this.Controls.Add(this.chkTime);
            this.Controls.Add(this.chkDate);
            this.Controls.Add(this.gbDate);
            this.Controls.Add(this.gbTime);
            this.Controls.Add(this.gbDays);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSearchByTime";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "חיפוש לפי זמן";
            this.Load += new System.EventHandler(this.frmSearchByTime_Load);
            this.gbDays.ResumeLayout(false);
            this.gbTime.ResumeLayout(false);
            this.gbTime.PerformLayout();
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDays;
        private System.Windows.Forms.ListBox lbDays;
        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.DateTimePicker dtTimeTo;
        private System.Windows.Forms.DateTimePicker dtTimeFrom;
        private System.Windows.Forms.DateTimePicker dtTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.RadioButton rbTimeInterval;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.GroupBox gbDate;
        private System.Windows.Forms.RadioButton rbDateInterval;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkTime;
        private System.Windows.Forms.CheckBox chkDay;
        private System.Windows.Forms.Button btnQuery;
    }
}