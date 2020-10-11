namespace Mazor.EventsLog
{
    partial class frmSearchByFamily
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
            this.btnQuery = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblSearchBy = new System.Windows.Forms.Label();
            this.lbSearch = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblFamily = new System.Windows.Forms.Label();
            this.txtFamily = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(10, 268);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 38;
            this.btnQuery.Text = "בצע";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(10, 94);
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
            this.lblSearchBy.Location = new System.Drawing.Point(330, 78);
            this.lblSearchBy.Name = "lblSearchBy";
            this.lblSearchBy.Size = new System.Drawing.Size(62, 13);
            this.lblSearchBy.TabIndex = 36;
            this.lblSearchBy.Text = "חיפוש לפי";
            // 
            // lbSearch
            // 
            this.lbSearch.FormattingEnabled = true;
            this.lbSearch.Location = new System.Drawing.Point(102, 94);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbSearch.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbSearch.Size = new System.Drawing.Size(290, 147);
            this.lbSearch.TabIndex = 35;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 34;
            this.btnAdd.Text = "הוספה";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblFamily
            // 
            this.lblFamily.AutoSize = true;
            this.lblFamily.Location = new System.Drawing.Point(398, 14);
            this.lblFamily.Name = "lblFamily";
            this.lblFamily.Size = new System.Drawing.Size(103, 13);
            this.lblFamily.TabIndex = 32;
            this.lblFamily.Text = "משפחה/משק/מבנה";
            // 
            // txtFamily
            // 
            this.txtFamily.Location = new System.Drawing.Point(102, 13);
            this.txtFamily.Name = "txtFamily";
            this.txtFamily.Size = new System.Drawing.Size(290, 20);
            this.txtFamily.TabIndex = 39;
            // 
            // frmSearchByFamily
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 301);
            this.Controls.Add(this.txtFamily);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblSearchBy);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblFamily);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSearchByFamily";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "חיפוש לפי משפחה/משק/מבנה";
            this.Load += new System.EventHandler(this.frmSearchByFamily_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblSearchBy;
        private System.Windows.Forms.ListBox lbSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblFamily;
        private System.Windows.Forms.TextBox txtFamily;
    }
}