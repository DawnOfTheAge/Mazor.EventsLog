namespace Mazor.EventsLog
{
    partial class frmAddUpdateCriminalRecord
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
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblWhatWasStolen = new System.Windows.Forms.Label();
            this.txtWhatWasStolen = new System.Windows.Forms.TextBox();
            this.txtArrivalDirection = new System.Windows.Forms.TextBox();
            this.lblArrivalDirection = new System.Windows.Forms.Label();
            this.txtWhoArrivedAfterTheEvent = new System.Windows.Forms.TextBox();
            this.lblWhoArrivedAfterTheEvent = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFamily = new System.Windows.Forms.TextBox();
            this.lblFamily = new System.Windows.Forms.Label();
            this.cboStreet = new System.Windows.Forms.ComboBox();
            this.nudHouseNumber = new System.Windows.Forms.NumericUpDown();
            this.lblStreet = new System.Windows.Forms.Label();
            this.lblHouseNumber = new System.Windows.Forms.Label();
            this.lblEventType = new System.Windows.Forms.Label();
            this.cboEventType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudHouseNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // dtDate
            // 
            this.dtDate.Location = new System.Drawing.Point(190, 16);
            this.dtDate.Name = "dtDate";
            this.dtDate.ShowUpDown = true;
            this.dtDate.Size = new System.Drawing.Size(200, 20);
            this.dtDate.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(415, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(40, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "תאריך";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(138, 22);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(30, 13);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "שעה";
            // 
            // dtTime
            // 
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtTime.Location = new System.Drawing.Point(28, 16);
            this.dtTime.Name = "dtTime";
            this.dtTime.ShowUpDown = true;
            this.dtTime.Size = new System.Drawing.Size(104, 20);
            this.dtTime.TabIndex = 3;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(415, 155);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(40, 13);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "כתובת";
            // 
            // lblWhatWasStolen
            // 
            this.lblWhatWasStolen.AutoSize = true;
            this.lblWhatWasStolen.Location = new System.Drawing.Point(382, 274);
            this.lblWhatWasStolen.Name = "lblWhatWasStolen";
            this.lblWhatWasStolen.Size = new System.Drawing.Size(73, 13);
            this.lblWhatWasStolen.TabIndex = 6;
            this.lblWhatWasStolen.Text = "פרטי האירוע";
            // 
            // txtWhatWasStolen
            // 
            this.txtWhatWasStolen.Location = new System.Drawing.Point(18, 271);
            this.txtWhatWasStolen.Multiline = true;
            this.txtWhatWasStolen.Name = "txtWhatWasStolen";
            this.txtWhatWasStolen.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWhatWasStolen.Size = new System.Drawing.Size(328, 63);
            this.txtWhatWasStolen.TabIndex = 7;
            // 
            // txtArrivalDirection
            // 
            this.txtArrivalDirection.Location = new System.Drawing.Point(18, 190);
            this.txtArrivalDirection.Multiline = true;
            this.txtArrivalDirection.Name = "txtArrivalDirection";
            this.txtArrivalDirection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtArrivalDirection.Size = new System.Drawing.Size(328, 63);
            this.txtArrivalDirection.TabIndex = 9;
            // 
            // lblArrivalDirection
            // 
            this.lblArrivalDirection.AutoSize = true;
            this.lblArrivalDirection.Location = new System.Drawing.Point(389, 193);
            this.lblArrivalDirection.Name = "lblArrivalDirection";
            this.lblArrivalDirection.Size = new System.Drawing.Size(66, 13);
            this.lblArrivalDirection.TabIndex = 8;
            this.lblArrivalDirection.Text = "כוון ההגעה";
            // 
            // txtWhoArrivedAfterTheEvent
            // 
            this.txtWhoArrivedAfterTheEvent.Location = new System.Drawing.Point(18, 372);
            this.txtWhoArrivedAfterTheEvent.Multiline = true;
            this.txtWhoArrivedAfterTheEvent.Name = "txtWhoArrivedAfterTheEvent";
            this.txtWhoArrivedAfterTheEvent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtWhoArrivedAfterTheEvent.Size = new System.Drawing.Size(328, 63);
            this.txtWhoArrivedAfterTheEvent.TabIndex = 11;
            // 
            // lblWhoArrivedAfterTheEvent
            // 
            this.lblWhoArrivedAfterTheEvent.AutoSize = true;
            this.lblWhoArrivedAfterTheEvent.Location = new System.Drawing.Point(371, 375);
            this.lblWhoArrivedAfterTheEvent.Name = "lblWhoArrivedAfterTheEvent";
            this.lblWhoArrivedAfterTheEvent.Size = new System.Drawing.Size(84, 13);
            this.lblWhoArrivedAfterTheEvent.TabIndex = 10;
            this.lblWhoArrivedAfterTheEvent.Text = "נוכחים באירוע";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(18, 462);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescription.Size = new System.Drawing.Size(328, 63);
            this.txtDescription.TabIndex = 13;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(388, 465);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 13);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "תיאור כללי";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(18, 542);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "שמירה";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFamily
            // 
            this.txtFamily.Location = new System.Drawing.Point(18, 116);
            this.txtFamily.Name = "txtFamily";
            this.txtFamily.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtFamily.Size = new System.Drawing.Size(328, 20);
            this.txtFamily.TabIndex = 16;
            // 
            // lblFamily
            // 
            this.lblFamily.AutoSize = true;
            this.lblFamily.Location = new System.Drawing.Point(352, 119);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.Size = new System.Drawing.Size(103, 13);
            this.lblFamily.TabIndex = 15;
            this.lblFamily.Text = "משפחה/משק/מבנה";
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
            this.cboStreet.Location = new System.Drawing.Point(148, 152);
            this.cboStreet.Name = "cboStreet";
            this.cboStreet.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboStreet.Size = new System.Drawing.Size(160, 21);
            this.cboStreet.TabIndex = 17;
            // 
            // nudHouseNumber
            // 
            this.nudHouseNumber.Location = new System.Drawing.Point(18, 153);
            this.nudHouseNumber.Name = "nudHouseNumber";
            this.nudHouseNumber.Size = new System.Drawing.Size(84, 20);
            this.nudHouseNumber.TabIndex = 18;
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(314, 155);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(32, 13);
            this.lblStreet.TabIndex = 19;
            this.lblStreet.Text = "רחוב";
            // 
            // lblHouseNumber
            // 
            this.lblHouseNumber.AutoSize = true;
            this.lblHouseNumber.Location = new System.Drawing.Point(108, 155);
            this.lblHouseNumber.Name = "lblHouseNumber";
            this.lblHouseNumber.Size = new System.Drawing.Size(34, 13);
            this.lblHouseNumber.TabIndex = 20;
            this.lblHouseNumber.Text = "מספר";
            // 
            // lblEventType
            // 
            this.lblEventType.AutoSize = true;
            this.lblEventType.Location = new System.Drawing.Point(396, 75);
            this.lblEventType.Name = "lblEventType";
            this.lblEventType.Size = new System.Drawing.Size(59, 13);
            this.lblEventType.TabIndex = 22;
            this.lblEventType.Text = "סוג אירוע";
            // 
            // cboEventType
            // 
            this.cboEventType.FormattingEnabled = true;
            this.cboEventType.Location = new System.Drawing.Point(186, 72);
            this.cboEventType.Name = "cboEventType";
            this.cboEventType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboEventType.Size = new System.Drawing.Size(160, 21);
            this.cboEventType.TabIndex = 21;
            // 
            // frmAddUpdateCriminalRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 602);
            this.Controls.Add(this.lblEventType);
            this.Controls.Add(this.cboEventType);
            this.Controls.Add(this.lblHouseNumber);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.nudHouseNumber);
            this.Controls.Add(this.cboStreet);
            this.Controls.Add(this.txtFamily);
            this.Controls.Add(this.lblFamily);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtWhoArrivedAfterTheEvent);
            this.Controls.Add(this.lblWhoArrivedAfterTheEvent);
            this.Controls.Add(this.txtArrivalDirection);
            this.Controls.Add(this.lblArrivalDirection);
            this.Controls.Add(this.txtWhatWasStolen);
            this.Controls.Add(this.lblWhatWasStolen);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.dtTime);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateCriminalRecord";
            this.Load += new System.EventHandler(this.frmAddUpdateCriminalRecord_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHouseNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtTime;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblWhatWasStolen;
        private System.Windows.Forms.TextBox txtWhatWasStolen;
        private System.Windows.Forms.TextBox txtArrivalDirection;
        private System.Windows.Forms.Label lblArrivalDirection;
        private System.Windows.Forms.TextBox txtWhoArrivedAfterTheEvent;
        private System.Windows.Forms.Label lblWhoArrivedAfterTheEvent;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFamily;
        private System.Windows.Forms.Label lblFamily;
        private System.Windows.Forms.ComboBox cboStreet;
        private System.Windows.Forms.NumericUpDown nudHouseNumber;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.Label lblHouseNumber;
        private System.Windows.Forms.Label lblEventType;
        private System.Windows.Forms.ComboBox cboEventType;
    }
}