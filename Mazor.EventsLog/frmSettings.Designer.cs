namespace Mazor.EventsLog
{
    partial class frmSettings
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
            this.chkLogToFile = new System.Windows.Forms.CheckBox();
            this.lblLogFilePath = new System.Windows.Forms.Label();
            this.txtLogFilePath = new System.Windows.Forms.TextBox();
            this.btnLogFilePath = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnJsonFilePath = new System.Windows.Forms.Button();
            this.txtJsonFilePath = new System.Windows.Forms.TextBox();
            this.lblJsonFilePath = new System.Windows.Forms.Label();
            this.txtJsonFileName = new System.Windows.Forms.TextBox();
            this.lblJsonFileName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // chkLogToFile
            // 
            this.chkLogToFile.AutoSize = true;
            this.chkLogToFile.Location = new System.Drawing.Point(644, 79);
            this.chkLogToFile.Name = "chkLogToFile";
            this.chkLogToFile.Size = new System.Drawing.Size(138, 17);
            this.chkLogToFile.TabIndex = 0;
            this.chkLogToFile.Text = "שמירת הודעות לקובץ";
            this.chkLogToFile.UseVisualStyleBackColor = true;
            // 
            // lblLogFilePath
            // 
            this.lblLogFilePath.AutoSize = true;
            this.lblLogFilePath.Location = new System.Drawing.Point(676, 99);
            this.lblLogFilePath.Name = "lblLogFilePath";
            this.lblLogFilePath.Size = new System.Drawing.Size(109, 13);
            this.lblLogFilePath.TabIndex = 1;
            this.lblLogFilePath.Text = "מיקום קובץ הודעות";
            // 
            // txtLogFilePath
            // 
            this.txtLogFilePath.Location = new System.Drawing.Point(73, 97);
            this.txtLogFilePath.Name = "txtLogFilePath";
            this.txtLogFilePath.Size = new System.Drawing.Size(597, 20);
            this.txtLogFilePath.TabIndex = 2;
            // 
            // btnLogFilePath
            // 
            this.btnLogFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogFilePath.Location = new System.Drawing.Point(8, 89);
            this.btnLogFilePath.Name = "btnLogFilePath";
            this.btnLogFilePath.Size = new System.Drawing.Size(41, 30);
            this.btnLogFilePath.TabIndex = 3;
            this.btnLogFilePath.Text = "...";
            this.btnLogFilePath.UseVisualStyleBackColor = true;
            this.btnLogFilePath.Click += new System.EventHandler(this.btnLogFilePath_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 141);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "שמירה";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnJsonFilePath
            // 
            this.btnJsonFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJsonFilePath.Location = new System.Drawing.Point(8, 29);
            this.btnJsonFilePath.Name = "btnJsonFilePath";
            this.btnJsonFilePath.Size = new System.Drawing.Size(41, 30);
            this.btnJsonFilePath.TabIndex = 8;
            this.btnJsonFilePath.Text = "...";
            this.btnJsonFilePath.UseVisualStyleBackColor = true;
            this.btnJsonFilePath.Click += new System.EventHandler(this.btnJsonFilePath_Click);
            // 
            // txtJsonFilePath
            // 
            this.txtJsonFilePath.Location = new System.Drawing.Point(73, 37);
            this.txtJsonFilePath.Name = "txtJsonFilePath";
            this.txtJsonFilePath.Size = new System.Drawing.Size(597, 20);
            this.txtJsonFilePath.TabIndex = 7;
            // 
            // lblJsonFilePath
            // 
            this.lblJsonFilePath.AutoSize = true;
            this.lblJsonFilePath.Location = new System.Drawing.Point(676, 39);
            this.lblJsonFilePath.Name = "lblJsonFilePath";
            this.lblJsonFilePath.Size = new System.Drawing.Size(105, 13);
            this.lblJsonFilePath.TabIndex = 6;
            this.lblJsonFilePath.Text = "מיקום קובץ נתונים";
            // 
            // txtJsonFileName
            // 
            this.txtJsonFileName.Location = new System.Drawing.Point(574, 11);
            this.txtJsonFileName.Name = "txtJsonFileName";
            this.txtJsonFileName.Size = new System.Drawing.Size(96, 20);
            this.txtJsonFileName.TabIndex = 10;
            // 
            // lblJsonFileName
            // 
            this.lblJsonFileName.AutoSize = true;
            this.lblJsonFileName.Location = new System.Drawing.Point(691, 14);
            this.lblJsonFileName.Name = "lblJsonFileName";
            this.lblJsonFileName.Size = new System.Drawing.Size(90, 13);
            this.lblJsonFileName.TabIndex = 9;
            this.lblJsonFileName.Text = "שם קובץ נתונים";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 180);
            this.Controls.Add(this.txtJsonFileName);
            this.Controls.Add(this.lblJsonFileName);
            this.Controls.Add(this.btnJsonFilePath);
            this.Controls.Add(this.txtJsonFilePath);
            this.Controls.Add(this.lblJsonFilePath);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLogFilePath);
            this.Controls.Add(this.txtLogFilePath);
            this.Controls.Add(this.lblLogFilePath);
            this.Controls.Add(this.chkLogToFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "הגדרות";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkLogToFile;
        private System.Windows.Forms.Label lblLogFilePath;
        private System.Windows.Forms.TextBox txtLogFilePath;
        private System.Windows.Forms.Button btnLogFilePath;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnJsonFilePath;
        private System.Windows.Forms.TextBox txtJsonFilePath;
        private System.Windows.Forms.Label lblJsonFilePath;
        private System.Windows.Forms.TextBox txtJsonFileName;
        private System.Windows.Forms.Label lblJsonFileName;
    }
}