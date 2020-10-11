namespace Mazor.EventsLog
{
    partial class frmSearchByEvent
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
            this.gbEventTypes = new System.Windows.Forms.GroupBox();
            this.lbEventTypes = new System.Windows.Forms.ListBox();
            this.gbEventTypes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(12, 172);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(132, 23);
            this.btnQuery.TabIndex = 39;
            this.btnQuery.Text = "בצע";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // gbEventTypes
            // 
            this.gbEventTypes.Controls.Add(this.lbEventTypes);
            this.gbEventTypes.Location = new System.Drawing.Point(12, 12);
            this.gbEventTypes.Name = "gbEventTypes";
            this.gbEventTypes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbEventTypes.Size = new System.Drawing.Size(132, 154);
            this.gbEventTypes.TabIndex = 40;
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
            // frmSearchByEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(156, 211);
            this.Controls.Add(this.gbEventTypes);
            this.Controls.Add(this.btnQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSearchByEvent";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "חיפוש לפי סוג אירוע";
            this.Load += new System.EventHandler(this.frmSearchByEvent_Load);
            this.gbEventTypes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox gbEventTypes;
        private System.Windows.Forms.ListBox lbEventTypes;
    }
}