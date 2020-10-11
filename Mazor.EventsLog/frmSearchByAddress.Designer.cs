namespace Mazor.EventsLog
{
    partial class frmSearchByAddress
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
            this.lblHouseNumber = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.nudHouseNumber = new System.Windows.Forms.NumericUpDown();
            this.cboStreet = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.ListBox();
            this.lblSearchBy = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudHouseNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHouseNumber
            // 
            this.lblHouseNumber.AutoSize = true;
            this.lblHouseNumber.Location = new System.Drawing.Point(193, 14);
            this.lblHouseNumber.Name = "lblHouseNumber";
            this.lblHouseNumber.Size = new System.Drawing.Size(34, 13);
            this.lblHouseNumber.TabIndex = 24;
            this.lblHouseNumber.Text = "מספר";
            // 
            // lblStreet
            // 
            this.lblStreet.AutoSize = true;
            this.lblStreet.Location = new System.Drawing.Point(399, 14);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(32, 13);
            this.lblStreet.TabIndex = 23;
            this.lblStreet.Text = "רחוב";
            // 
            // nudHouseNumber
            // 
            this.nudHouseNumber.Location = new System.Drawing.Point(103, 12);
            this.nudHouseNumber.Name = "nudHouseNumber";
            this.nudHouseNumber.Size = new System.Drawing.Size(84, 20);
            this.nudHouseNumber.TabIndex = 22;
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
            this.cboStreet.Location = new System.Drawing.Point(233, 11);
            this.cboStreet.Name = "cboStreet";
            this.cboStreet.Size = new System.Drawing.Size(160, 21);
            this.cboStreet.TabIndex = 21;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(11, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "הוספה";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbSearch
            // 
            this.lbSearch.FormattingEnabled = true;
            this.lbSearch.Location = new System.Drawing.Point(103, 94);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbSearch.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbSearch.Size = new System.Drawing.Size(290, 147);
            this.lbSearch.TabIndex = 26;
            // 
            // lblSearchBy
            // 
            this.lblSearchBy.AutoSize = true;
            this.lblSearchBy.Location = new System.Drawing.Point(331, 78);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(62, 13);
            this.lblSearchBy.TabIndex = 27;
            this.lblSearchBy.Text = "חיפוש לפי";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(11, 94);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 28;
            this.btnRemove.Text = "הסרה";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(11, 268);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 29;
            this.btnQuery.Text = "בצע";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // frmSearchByAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 298);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblSearchBy);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblHouseNumber);
            this.Controls.Add(this.lblStreet);
            this.Controls.Add(this.nudHouseNumber);
            this.Controls.Add(this.cboStreet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSearchByAddress";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "חיפוש לפי כתובת";
            this.Load += new System.EventHandler(this.frmSearchByAddress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudHouseNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHouseNumber;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.NumericUpDown nudHouseNumber;
        private System.Windows.Forms.ComboBox cboStreet;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox lbSearch;
        private System.Windows.Forms.Label lblSearchBy;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnQuery;
    }
}