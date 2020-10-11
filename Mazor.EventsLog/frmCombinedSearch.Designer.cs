namespace Mazor.EventsLog
{
    partial class frmCombinedSearch
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
            this.gbByAddress = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblSearchBy = new System.Windows.Forms.Label();
            this.lbSearch = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblHouseNumber = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.nudHouseNumber = new System.Windows.Forms.NumericUpDown();
            this.cboStreet = new System.Windows.Forms.ComboBox();
            this.gbEventTypes = new System.Windows.Forms.GroupBox();
            this.lbEventTypes = new System.Windows.Forms.ListBox();
            this.gbByFamily = new System.Windows.Forms.GroupBox();
            this.txtFamily = new System.Windows.Forms.TextBox();
            this.btnRemoveFamily = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSearchFamily = new System.Windows.Forms.ListBox();
            this.btnAddFamily = new System.Windows.Forms.Button();
            this.lblFamily = new System.Windows.Forms.Label();
            this.gbByTime = new System.Windows.Forms.GroupBox();
            this.chkDay = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.gbDate = new System.Windows.Forms.GroupBox();
            this.rbDateInterval = new System.Windows.Forms.RadioButton();
            this.rbDate = new System.Windows.Forms.RadioButton();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.rbTimeInterval = new System.Windows.Forms.RadioButton();
            this.rbTime = new System.Windows.Forms.RadioButton();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtTimeTo = new System.Windows.Forms.DateTimePicker();
            this.dtTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.gbDays = new System.Windows.Forms.GroupBox();
            this.lbDays = new System.Windows.Forms.ListBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.rbOr = new System.Windows.Forms.RadioButton();
            this.rbAnd = new System.Windows.Forms.RadioButton();
            this.gbByAddress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHouseNumber)).BeginInit();
            this.gbEventTypes.SuspendLayout();
            this.gbByFamily.SuspendLayout();
            this.gbByTime.SuspendLayout();
            this.gbDate.SuspendLayout();
            this.gbTime.SuspendLayout();
            this.gbDays.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbByAddress
            // 
            this.gbByAddress.Controls.Add(this.btnRemove);
            this.gbByAddress.Controls.Add(this.lblSearchBy);
            this.gbByAddress.Controls.Add(this.lbSearch);
            this.gbByAddress.Controls.Add(this.btnAdd);
            this.gbByAddress.Controls.Add(this.lblHouseNumber);
            this.gbByAddress.Controls.Add(this.lblStreet);
            this.gbByAddress.Controls.Add(this.nudHouseNumber);
            this.gbByAddress.Controls.Add(this.cboStreet);
            this.gbByAddress.Location = new System.Drawing.Point(425, 9);
            this.gbByAddress.Name = "gbByAddress";
            this.gbByAddress.Size = new System.Drawing.Size(442, 269);
            this.gbByAddress.TabIndex = 0;
            this.gbByAddress.TabStop = false;
            this.gbByAddress.Text = "כתובת";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(15, 102);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 37;
            this.btnRemove.Text = "הסרה";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblSearchBy
            // 
            this.lblSearchBy.AutoSize = true;
            this.lblSearchBy.Location = new System.Drawing.Point(335, 86);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(62, 13);
            this.lblSearchBy.TabIndex = 36;
            this.lblSearchBy.Text = "חיפוש לפי";
            // 
            // lbSearch
            // 
            this.lbSearch.FormattingEnabled = true;
            this.lbSearch.Location = new System.Drawing.Point(107, 102);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbSearch.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbSearch.Size = new System.Drawing.Size(290, 147);
            this.lbSearch.TabIndex = 35;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(15, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "הוספה";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblHouseNumber
            // 
            this.lblHouseNumber.AutoSize = true;
            this.lblHouseNumber.Location = new System.Drawing.Point(197, 22);
            this.lblHouseNumber.Name = "lblHouseNumber";
            this.lblHouseNumber.Size = new System.Drawing.Size(34, 13);
            this.lblHouseNumber.TabIndex = 33;
            this.lblHouseNumber.Text = "מספר";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(403, 22);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(32, 13);
            this.lblStreet.TabIndex = 32;
            this.lblStreet.Text = "רחוב";
            // 
            // nudHouseNumber
            // 
            this.nudHouseNumber.Location = new System.Drawing.Point(107, 20);
            this.nudHouseNumber.Name = "nudHouseNumber";
            this.nudHouseNumber.Size = new System.Drawing.Size(84, 20);
            this.nudHouseNumber.TabIndex = 31;
            // 
            // cboStreet
            // 
            this.cboStreet.FormattingEnabled = true;
            this.cboStreet.Items.AddRange(new object[] {
            "הגפן",
            "הדקל",
            "היוגב",
            "היסמין",
            "הכלנית",
            "המייסדים",
            "הנוטע",
            "הנרקיס",
            "הפרדס",
            "הצבעוני",
            "הרימון",
            "הרקפות",
            "השחר",
            "מזור",
            "סמטת האירוס",
            "סמטת הבוקרים"});
            this.cboStreet.Location = new System.Drawing.Point(237, 19);
            this.cboStreet.Name = "cboStreet";
            this.cboStreet.Size = new System.Drawing.Size(160, 21);
            this.cboStreet.TabIndex = 30;
            // 
            // gbEventTypes
            // 
            this.gbEventTypes.Controls.Add(this.lbEventTypes);
            this.gbEventTypes.Location = new System.Drawing.Point(70, 284);
            this.gbEventTypes.Name = "gbEventTypes";
            this.gbEventTypes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbEventTypes.Size = new System.Drawing.Size(132, 154);
            this.gbEventTypes.TabIndex = 43;
            this.gbEventTypes.TabStop = false;
            this.gbEventTypes.Text = "סוגי אירוע";
            // 
            // lbEventTypes
            // 
            this.lbEventTypes.FormattingEnabled = true;
            this.lbEventTypes.Location = new System.Drawing.Point(6, 19);
            this.lbEventTypes.Name = "lbEventTypes";
            this.lbEventTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbEventTypes.Size = new System.Drawing.Size(120, 121);
            this.lbEventTypes.TabIndex = 2;
            // 
            // gbByFamily
            // 
            this.gbByFamily.Controls.Add(this.txtFamily);
            this.gbByFamily.Controls.Add(this.btnRemoveFamily);
            this.gbByFamily.Controls.Add(this.label1);
            this.gbByFamily.Controls.Add(this.lbSearchFamily);
            this.gbByFamily.Controls.Add(this.btnAddFamily);
            this.gbByFamily.Controls.Add(this.lblFamily);
            this.gbByFamily.Location = new System.Drawing.Point(9, 9);
            this.gbByFamily.Name = "gbByFamily";
            this.gbByFamily.Size = new System.Drawing.Size(410, 269);
            this.gbByFamily.TabIndex = 44;
            this.gbByFamily.TabStop = false;
            // 
            // txtFamily
            // 
            this.txtFamily.Location = new System.Drawing.Point(105, 44);
            this.txtFamily.Name = "txtFamily";
            this.txtFamily.Size = new System.Drawing.Size(290, 20);
            this.txtFamily.TabIndex = 45;
            // 
            // btnRemoveFamily
            // 
            this.btnRemoveFamily.Location = new System.Drawing.Point(13, 102);
            this.btnRemoveFamily.Name = "btnRemoveFamily";
            this.btnRemoveFamily.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveFamily.TabIndex = 44;
            this.btnRemoveFamily.Text = "הסרה";
            this.btnRemoveFamily.UseVisualStyleBackColor = true;
            this.btnRemoveFamily.Click += new System.EventHandler(this.btnRemoveFamily_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "חיפוש לפי";
            // 
            // lbSearchFamily
            // 
            this.lbSearchFamily.FormattingEnabled = true;
            this.lbSearchFamily.Location = new System.Drawing.Point(105, 102);
            this.lbSearchFamily.Name = "lbSearchFamily";
            this.lbSearchFamily.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbSearchFamily.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbSearchFamily.Size = new System.Drawing.Size(290, 147);
            this.lbSearchFamily.TabIndex = 42;
            // 
            // btnAddFamily
            // 
            this.btnAddFamily.Location = new System.Drawing.Point(13, 42);
            this.btnAddFamily.Name = "btnAddFamily";
            this.btnAddFamily.Size = new System.Drawing.Size(75, 23);
            this.btnAddFamily.TabIndex = 41;
            this.btnAddFamily.Text = "הוספה";
            this.btnAddFamily.UseVisualStyleBackColor = true;
            this.btnAddFamily.Click += new System.EventHandler(this.btnAddFamily_Click);
            // 
            // lblFamily
            // 
            this.lblFamily.AutoSize = true;
            this.lblFamily.Location = new System.Drawing.Point(295, 29);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.Size = new System.Drawing.Size(103, 13);
            this.lblFamily.TabIndex = 40;
            this.lblFamily.Text = "משפחה/משק/מבנה";
            // 
            // gbByTime
            // 
            this.gbByTime.Controls.Add(this.chkDay);
            this.gbByTime.Controls.Add(this.chkDate);
            this.gbByTime.Controls.Add(this.chkTime);
            this.gbByTime.Controls.Add(this.gbDate);
            this.gbByTime.Controls.Add(this.gbTime);
            this.gbByTime.Controls.Add(this.gbDays);
            this.gbByTime.Location = new System.Drawing.Point(208, 284);
            this.gbByTime.Name = "gbByTime";
            this.gbByTime.Size = new System.Drawing.Size(659, 197);
            this.gbByTime.TabIndex = 45;
            this.gbByTime.TabStop = false;
            this.gbByTime.Text = "זמן";
            // 
            // chkDay
            // 
            this.chkDay.AutoSize = true;
            this.chkDay.Location = new System.Drawing.Point(620, 170);
            this.chkDay.Name = "chkDay";
            this.chkDay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDay.Size = new System.Drawing.Size(15, 14);
            this.chkDay.TabIndex = 11;
            this.chkDay.UseVisualStyleBackColor = true;
            this.chkDay.CheckedChanged += new System.EventHandler(this.chkDay_CheckedChanged);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Location = new System.Drawing.Point(280, 170);
            this.chkDate.Name = "chkDate";
            this.chkDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDate.Size = new System.Drawing.Size(15, 14);
            this.chkDate.TabIndex = 9;
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.CheckedChanged += new System.EventHandler(this.chkDate_CheckedChanged);
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Location = new System.Drawing.Point(509, 170);
            this.chkTime.Name = "chkTime";
            this.chkTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkTime.Size = new System.Drawing.Size(15, 14);
            this.chkTime.TabIndex = 10;
            this.chkTime.UseVisualStyleBackColor = true;
            this.chkTime.CheckedChanged += new System.EventHandler(this.chkTime_CheckedChanged);
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
            this.gbDate.Location = new System.Drawing.Point(20, 26);
            this.gbDate.Name = "gbDate";
            this.gbDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbDate.Size = new System.Drawing.Size(287, 138);
            this.gbDate.TabIndex = 8;
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
            this.gbTime.Location = new System.Drawing.Point(338, 26);
            this.gbTime.Name = "gbTime";
            this.gbTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbTime.Size = new System.Drawing.Size(196, 138);
            this.gbTime.TabIndex = 7;
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
            // gbDays
            // 
            this.gbDays.Controls.Add(this.lbDays);
            this.gbDays.Location = new System.Drawing.Point(565, 26);
            this.gbDays.Name = "gbDays";
            this.gbDays.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbDays.Size = new System.Drawing.Size(77, 138);
            this.gbDays.TabIndex = 6;
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
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(9, 458);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 46;
            this.btnQuery.Text = "בצע";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // rbOr
            // 
            this.rbOr.AutoSize = true;
            this.rbOr.Location = new System.Drawing.Point(144, 461);
            this.rbOr.Name = "rbOr";
            this.rbOr.Size = new System.Drawing.Size(38, 17);
            this.rbOr.TabIndex = 48;
            this.rbOr.TabStop = true;
            this.rbOr.Text = "או";
            this.rbOr.UseVisualStyleBackColor = true;
            // 
            // rbAnd
            // 
            this.rbAnd.AutoSize = true;
            this.rbAnd.Location = new System.Drawing.Point(100, 461);
            this.rbAnd.Name = "rbAnd";
            this.rbAnd.Size = new System.Drawing.Size(38, 17);
            this.rbAnd.TabIndex = 49;
            this.rbAnd.TabStop = true;
            this.rbAnd.Text = "גם";
            this.rbAnd.UseVisualStyleBackColor = true;
            // 
            // frmCombinedSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 485);
            this.Controls.Add(this.rbAnd);
            this.Controls.Add(this.rbOr);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.gbByTime);
            this.Controls.Add(this.gbByFamily);
            this.Controls.Add(this.gbEventTypes);
            this.Controls.Add(this.gbByAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCombinedSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "חיפוש משולב";
            this.Load += new System.EventHandler(this.frmCombinedSearch_Load);
            this.gbByAddress.ResumeLayout(false);
            this.gbByAddress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHouseNumber)).EndInit();
            this.gbEventTypes.ResumeLayout(false);
            this.gbByFamily.ResumeLayout(false);
            this.gbByFamily.PerformLayout();
            this.gbByTime.ResumeLayout(false);
            this.gbByTime.PerformLayout();
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.gbTime.ResumeLayout(false);
            this.gbTime.PerformLayout();
            this.gbDays.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbByAddress;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblSearchBy;
        private System.Windows.Forms.ListBox lbSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblHouseNumber;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.NumericUpDown nudHouseNumber;
        private System.Windows.Forms.ComboBox cboStreet;
        private System.Windows.Forms.GroupBox gbEventTypes;
        private System.Windows.Forms.ListBox lbEventTypes;
        private System.Windows.Forms.GroupBox gbByFamily;
        private System.Windows.Forms.TextBox txtFamily;
        private System.Windows.Forms.Button btnRemoveFamily;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbSearchFamily;
        private System.Windows.Forms.Button btnAddFamily;
        private System.Windows.Forms.Label lblFamily;
        private System.Windows.Forms.GroupBox gbByTime;
        private System.Windows.Forms.CheckBox chkDay;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkTime;
        private System.Windows.Forms.GroupBox gbDate;
        private System.Windows.Forms.RadioButton rbDateInterval;
        private System.Windows.Forms.RadioButton rbDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.RadioButton rbTimeInterval;
        private System.Windows.Forms.RadioButton rbTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtTimeTo;
        private System.Windows.Forms.DateTimePicker dtTimeFrom;
        private System.Windows.Forms.DateTimePicker dtTime;
        private System.Windows.Forms.GroupBox gbDays;
        private System.Windows.Forms.ListBox lbDays;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.RadioButton rbOr;
        private System.Windows.Forms.RadioButton rbAnd;
    }
}