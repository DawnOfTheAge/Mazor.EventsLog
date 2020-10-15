﻿namespace Mazor.EventsLog
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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabFilesLocations = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLogFilePath = new System.Windows.Forms.TextBox();
            this.txtJsonFileName = new System.Windows.Forms.TextBox();
            this.chkLogToFile = new System.Windows.Forms.CheckBox();
            this.lblJsonFileName = new System.Windows.Forms.Label();
            this.lblLogFilePath = new System.Windows.Forms.Label();
            this.btnJsonFilePath = new System.Windows.Forms.Button();
            this.btnLogFilePath = new System.Windows.Forms.Button();
            this.txtJsonFilePath = new System.Windows.Forms.TextBox();
            this.lblJsonFilePath = new System.Windows.Forms.Label();
            this.tabStreets = new System.Windows.Forms.TabPage();
            this.tabLocations = new System.Windows.Forms.TabPage();
            this.tabLawEnforcementUnits = new System.Windows.Forms.TabPage();
            this.tabTrainingUnits = new System.Windows.Forms.TabPage();
            this.tabArrivalDirections = new System.Windows.Forms.TabPage();
            this.btnAddStreet = new System.Windows.Forms.Button();
            this.dgvStreets = new System.Windows.Forms.DataGridView();
            this.colStreet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLocations = new System.Windows.Forms.DataGridView();
            this.btnLocation = new System.Windows.Forms.Button();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLongtitue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvArrivalDirections = new System.Windows.Forms.DataGridView();
            this.btnAddArrivalDirection = new System.Windows.Forms.Button();
            this.colArrivalDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLawEnforcementUnits = new System.Windows.Forms.DataGridView();
            this.btnAddLawEnforcementUnit = new System.Windows.Forms.Button();
            this.dgvTrainingUnits = new System.Windows.Forms.DataGridView();
            this.btnAddTrainingUnit = new System.Windows.Forms.Button();
            this.colLawEnforcementUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLawEnforcementPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLawEnforcementEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrainingUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrainingUnitContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrainingUnitPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrainingUnitEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSettings.SuspendLayout();
            this.tabFilesLocations.SuspendLayout();
            this.tabStreets.SuspendLayout();
            this.tabLocations.SuspendLayout();
            this.tabLawEnforcementUnits.SuspendLayout();
            this.tabTrainingUnits.SuspendLayout();
            this.tabArrivalDirections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStreets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArrivalDirections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLawEnforcementUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainingUnits)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabFilesLocations);
            this.tabSettings.Controls.Add(this.tabStreets);
            this.tabSettings.Controls.Add(this.tabLocations);
            this.tabSettings.Controls.Add(this.tabArrivalDirections);
            this.tabSettings.Controls.Add(this.tabLawEnforcementUnits);
            this.tabSettings.Controls.Add(this.tabTrainingUnits);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Location = new System.Drawing.Point(0, 0);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(1042, 460);
            this.tabSettings.TabIndex = 11;
            // 
            // tabFilesLocations
            // 
            this.tabFilesLocations.Controls.Add(this.btnSave);
            this.tabFilesLocations.Controls.Add(this.txtLogFilePath);
            this.tabFilesLocations.Controls.Add(this.txtJsonFileName);
            this.tabFilesLocations.Controls.Add(this.chkLogToFile);
            this.tabFilesLocations.Controls.Add(this.lblJsonFileName);
            this.tabFilesLocations.Controls.Add(this.lblLogFilePath);
            this.tabFilesLocations.Controls.Add(this.btnJsonFilePath);
            this.tabFilesLocations.Controls.Add(this.btnLogFilePath);
            this.tabFilesLocations.Controls.Add(this.txtJsonFilePath);
            this.tabFilesLocations.Controls.Add(this.lblJsonFilePath);
            this.tabFilesLocations.Location = new System.Drawing.Point(4, 22);
            this.tabFilesLocations.Name = "tabFilesLocations";
            this.tabFilesLocations.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilesLocations.Size = new System.Drawing.Size(1034, 434);
            this.tabFilesLocations.TabIndex = 0;
            this.tabFilesLocations.Text = "מיקומי קבצים";
            this.tabFilesLocations.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 396);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 30);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "שמירה";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLogFilePath
            // 
            this.txtLogFilePath.Location = new System.Drawing.Point(304, 113);
            this.txtLogFilePath.Name = "txtLogFilePath";
            this.txtLogFilePath.Size = new System.Drawing.Size(597, 20);
            this.txtLogFilePath.TabIndex = 13;
            // 
            // txtJsonFileName
            // 
            this.txtJsonFileName.Location = new System.Drawing.Point(805, 27);
            this.txtJsonFileName.Name = "txtJsonFileName";
            this.txtJsonFileName.Size = new System.Drawing.Size(96, 20);
            this.txtJsonFileName.TabIndex = 19;
            // 
            // chkLogToFile
            // 
            this.chkLogToFile.AutoSize = true;
            this.chkLogToFile.Location = new System.Drawing.Point(875, 95);
            this.chkLogToFile.Name = "chkLogToFile";
            this.chkLogToFile.Size = new System.Drawing.Size(138, 17);
            this.chkLogToFile.TabIndex = 11;
            this.chkLogToFile.Text = "שמירת הודעות לקובץ";
            this.chkLogToFile.UseVisualStyleBackColor = true;
            // 
            // lblJsonFileName
            // 
            this.lblJsonFileName.AutoSize = true;
            this.lblJsonFileName.Location = new System.Drawing.Point(922, 30);
            this.lblJsonFileName.Name = "lblJsonFileName";
            this.lblJsonFileName.Size = new System.Drawing.Size(90, 13);
            this.lblJsonFileName.TabIndex = 18;
            this.lblJsonFileName.Text = "שם קובץ נתונים";
            // 
            // lblLogFilePath
            // 
            this.lblLogFilePath.AutoSize = true;
            this.lblLogFilePath.Location = new System.Drawing.Point(907, 115);
            this.lblLogFilePath.Name = "lblLogFilePath";
            this.lblLogFilePath.Size = new System.Drawing.Size(109, 13);
            this.lblLogFilePath.TabIndex = 12;
            this.lblLogFilePath.Text = "מיקום קובץ הודעות";
            // 
            // btnJsonFilePath
            // 
            this.btnJsonFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJsonFilePath.Location = new System.Drawing.Point(239, 45);
            this.btnJsonFilePath.Name = "btnJsonFilePath";
            this.btnJsonFilePath.Size = new System.Drawing.Size(41, 30);
            this.btnJsonFilePath.TabIndex = 17;
            this.btnJsonFilePath.Text = "...";
            this.btnJsonFilePath.UseVisualStyleBackColor = true;
            this.btnJsonFilePath.Click += new System.EventHandler(this.btnJsonFilePath_Click);
            // 
            // btnLogFilePath
            // 
            this.btnLogFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogFilePath.Location = new System.Drawing.Point(239, 105);
            this.btnLogFilePath.Name = "btnLogFilePath";
            this.btnLogFilePath.Size = new System.Drawing.Size(41, 30);
            this.btnLogFilePath.TabIndex = 14;
            this.btnLogFilePath.Text = "...";
            this.btnLogFilePath.UseVisualStyleBackColor = true;
            this.btnLogFilePath.Click += new System.EventHandler(this.btnLogFilePath_Click);
            // 
            // txtJsonFilePath
            // 
            this.txtJsonFilePath.Location = new System.Drawing.Point(304, 53);
            this.txtJsonFilePath.Name = "txtJsonFilePath";
            this.txtJsonFilePath.Size = new System.Drawing.Size(597, 20);
            this.txtJsonFilePath.TabIndex = 16;
            // 
            // lblJsonFilePath
            // 
            this.lblJsonFilePath.AutoSize = true;
            this.lblJsonFilePath.Location = new System.Drawing.Point(907, 55);
            this.lblJsonFilePath.Name = "lblJsonFilePath";
            this.lblJsonFilePath.Size = new System.Drawing.Size(105, 13);
            this.lblJsonFilePath.TabIndex = 15;
            this.lblJsonFilePath.Text = "מיקום קובץ נתונים";
            // 
            // tabStreets
            // 
            this.tabStreets.Controls.Add(this.dgvStreets);
            this.tabStreets.Controls.Add(this.btnAddStreet);
            this.tabStreets.Location = new System.Drawing.Point(4, 22);
            this.tabStreets.Name = "tabStreets";
            this.tabStreets.Padding = new System.Windows.Forms.Padding(3);
            this.tabStreets.Size = new System.Drawing.Size(1034, 434);
            this.tabStreets.TabIndex = 1;
            this.tabStreets.Text = "רחובות";
            this.tabStreets.UseVisualStyleBackColor = true;
            // 
            // tabLocations
            // 
            this.tabLocations.Controls.Add(this.dgvLocations);
            this.tabLocations.Controls.Add(this.btnLocation);
            this.tabLocations.Location = new System.Drawing.Point(4, 22);
            this.tabLocations.Name = "tabLocations";
            this.tabLocations.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocations.Size = new System.Drawing.Size(1034, 434);
            this.tabLocations.TabIndex = 2;
            this.tabLocations.Text = "מיקומים";
            this.tabLocations.UseVisualStyleBackColor = true;
            // 
            // tabLawEnforcementUnits
            // 
            this.tabLawEnforcementUnits.Controls.Add(this.dgvLawEnforcementUnits);
            this.tabLawEnforcementUnits.Controls.Add(this.btnAddLawEnforcementUnit);
            this.tabLawEnforcementUnits.Location = new System.Drawing.Point(4, 22);
            this.tabLawEnforcementUnits.Name = "tabLawEnforcementUnits";
            this.tabLawEnforcementUnits.Padding = new System.Windows.Forms.Padding(3);
            this.tabLawEnforcementUnits.Size = new System.Drawing.Size(1034, 434);
            this.tabLawEnforcementUnits.TabIndex = 3;
            this.tabLawEnforcementUnits.Text = "גורמי אכיפה";
            this.tabLawEnforcementUnits.UseVisualStyleBackColor = true;
            // 
            // tabTrainingUnits
            // 
            this.tabTrainingUnits.Controls.Add(this.dgvTrainingUnits);
            this.tabTrainingUnits.Controls.Add(this.btnAddTrainingUnit);
            this.tabTrainingUnits.Location = new System.Drawing.Point(4, 22);
            this.tabTrainingUnits.Name = "tabTrainingUnits";
            this.tabTrainingUnits.Padding = new System.Windows.Forms.Padding(3);
            this.tabTrainingUnits.Size = new System.Drawing.Size(1034, 434);
            this.tabTrainingUnits.TabIndex = 4;
            this.tabTrainingUnits.Text = "יחידות מתאמנות";
            this.tabTrainingUnits.UseVisualStyleBackColor = true;
            // 
            // tabArrivalDirections
            // 
            this.tabArrivalDirections.Controls.Add(this.dgvArrivalDirections);
            this.tabArrivalDirections.Controls.Add(this.btnAddArrivalDirection);
            this.tabArrivalDirections.Location = new System.Drawing.Point(4, 22);
            this.tabArrivalDirections.Name = "tabArrivalDirections";
            this.tabArrivalDirections.Padding = new System.Windows.Forms.Padding(3);
            this.tabArrivalDirections.Size = new System.Drawing.Size(1034, 434);
            this.tabArrivalDirections.TabIndex = 5;
            this.tabArrivalDirections.Text = "כווני הגעה";
            this.tabArrivalDirections.UseVisualStyleBackColor = true;
            // 
            // btnAddStreet
            // 
            this.btnAddStreet.Location = new System.Drawing.Point(686, 6);
            this.btnAddStreet.Name = "btnAddStreet";
            this.btnAddStreet.Size = new System.Drawing.Size(94, 36);
            this.btnAddStreet.TabIndex = 1;
            this.btnAddStreet.Text = "הוספת רחוב";
            this.btnAddStreet.UseVisualStyleBackColor = true;
            // 
            // dgvStreets
            // 
            this.dgvStreets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStreets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStreet});
            this.dgvStreets.Location = new System.Drawing.Point(786, 6);
            this.dgvStreets.Name = "dgvStreets";
            this.dgvStreets.Size = new System.Drawing.Size(240, 420);
            this.dgvStreets.TabIndex = 2;
            // 
            // colStreet
            // 
            this.colStreet.HeaderText = "שם רחוב";
            this.colStreet.Name = "colStreet";
            // 
            // dgvLocations
            // 
            this.dgvLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colLatitude,
            this.colLongtitue});
            this.dgvLocations.Location = new System.Drawing.Point(598, 8);
            this.dgvLocations.Name = "dgvLocations";
            this.dgvLocations.Size = new System.Drawing.Size(428, 420);
            this.dgvLocations.TabIndex = 4;
            // 
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(498, 8);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(94, 36);
            this.btnLocation.TabIndex = 3;
            this.btnLocation.Text = "הוספת מיקום";
            this.btnLocation.UseVisualStyleBackColor = true;
            // 
            // colName
            // 
            this.colName.HeaderText = "שם מיקום";
            this.colName.Name = "colName";
            // 
            // colLatitude
            // 
            this.colLatitude.HeaderText = "נקודת רוחב";
            this.colLatitude.Name = "colLatitude";
            // 
            // colLongtitue
            // 
            this.colLongtitue.HeaderText = "נקודת אורך";
            this.colLongtitue.Name = "colLongtitue";
            // 
            // dgvArrivalDirections
            // 
            this.dgvArrivalDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArrivalDirections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colArrivalDirection});
            this.dgvArrivalDirections.Location = new System.Drawing.Point(598, 8);
            this.dgvArrivalDirections.Name = "dgvArrivalDirections";
            this.dgvArrivalDirections.Size = new System.Drawing.Size(428, 420);
            this.dgvArrivalDirections.TabIndex = 6;
            // 
            // btnAddArrivalDirection
            // 
            this.btnAddArrivalDirection.Location = new System.Drawing.Point(462, 8);
            this.btnAddArrivalDirection.Name = "btnAddArrivalDirection";
            this.btnAddArrivalDirection.Size = new System.Drawing.Size(130, 36);
            this.btnAddArrivalDirection.TabIndex = 5;
            this.btnAddArrivalDirection.Text = "הוספת כוון הגעה";
            this.btnAddArrivalDirection.UseVisualStyleBackColor = true;
            // 
            // colArrivalDirection
            // 
            this.colArrivalDirection.HeaderText = "כוון הגעה";
            this.colArrivalDirection.Name = "colArrivalDirection";
            // 
            // dgvLawEnforcementUnits
            // 
            this.dgvLawEnforcementUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLawEnforcementUnits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLawEnforcementUnit,
            this.colContact,
            this.colLawEnforcementPhone,
            this.colLawEnforcementEmail});
            this.dgvLawEnforcementUnits.Location = new System.Drawing.Point(555, 8);
            this.dgvLawEnforcementUnits.Name = "dgvLawEnforcementUnits";
            this.dgvLawEnforcementUnits.Size = new System.Drawing.Size(473, 420);
            this.dgvLawEnforcementUnits.TabIndex = 8;
            // 
            // btnAddLawEnforcementUnit
            // 
            this.btnAddLawEnforcementUnit.Location = new System.Drawing.Point(419, 8);
            this.btnAddLawEnforcementUnit.Name = "btnAddLawEnforcementUnit";
            this.btnAddLawEnforcementUnit.Size = new System.Drawing.Size(130, 36);
            this.btnAddLawEnforcementUnit.TabIndex = 7;
            this.btnAddLawEnforcementUnit.Text = "הוספת גורם אכיפה";
            this.btnAddLawEnforcementUnit.UseVisualStyleBackColor = true;
            // 
            // dgvTrainingUnits
            // 
            this.dgvTrainingUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrainingUnits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTrainingUnit,
            this.colFromDate,
            this.colToDate,
            this.colFromHour,
            this.colToTime,
            this.colTrainingUnitContact,
            this.colTrainingUnitPhone,
            this.colTrainingUnitEmail});
            this.dgvTrainingUnits.Location = new System.Drawing.Point(170, 8);
            this.dgvTrainingUnits.Name = "dgvTrainingUnits";
            this.dgvTrainingUnits.Size = new System.Drawing.Size(858, 420);
            this.dgvTrainingUnits.TabIndex = 8;
            // 
            // btnAddTrainingUnit
            // 
            this.btnAddTrainingUnit.Location = new System.Drawing.Point(34, 8);
            this.btnAddTrainingUnit.Name = "btnAddTrainingUnit";
            this.btnAddTrainingUnit.Size = new System.Drawing.Size(130, 36);
            this.btnAddTrainingUnit.TabIndex = 7;
            this.btnAddTrainingUnit.Text = "הוספת יחידה מתאמנת";
            this.btnAddTrainingUnit.UseVisualStyleBackColor = true;
            // 
            // colLawEnforcementUnit
            // 
            this.colLawEnforcementUnit.HeaderText = "גורם אכיפה";
            this.colLawEnforcementUnit.Name = "colLawEnforcementUnit";
            // 
            // colContact
            // 
            this.colContact.HeaderText = "איש קשר";
            this.colContact.Name = "colContact";
            // 
            // colLawEnforcementPhone
            // 
            this.colLawEnforcementPhone.HeaderText = "טלפון";
            this.colLawEnforcementPhone.Name = "colLawEnforcementPhone";
            // 
            // colLawEnforcementEmail
            // 
            this.colLawEnforcementEmail.HeaderText = "דואל";
            this.colLawEnforcementEmail.Name = "colLawEnforcementEmail";
            // 
            // colTrainingUnit
            // 
            this.colTrainingUnit.HeaderText = "יחידה מתאמנת";
            this.colTrainingUnit.Name = "colTrainingUnit";
            // 
            // colFromDate
            // 
            this.colFromDate.HeaderText = "מתאריך";
            this.colFromDate.Name = "colFromDate";
            // 
            // colToDate
            // 
            this.colToDate.HeaderText = "עד תאריך";
            this.colToDate.Name = "colToDate";
            // 
            // colFromHour
            // 
            this.colFromHour.HeaderText = "מזמן";
            this.colFromHour.Name = "colFromHour";
            // 
            // colToTime
            // 
            this.colToTime.HeaderText = "עד זמן";
            this.colToTime.Name = "colToTime";
            // 
            // colTrainingUnitContact
            // 
            this.colTrainingUnitContact.HeaderText = "איש קשר";
            this.colTrainingUnitContact.Name = "colTrainingUnitContact";
            // 
            // colTrainingUnitPhone
            // 
            this.colTrainingUnitPhone.HeaderText = "טלפון";
            this.colTrainingUnitPhone.Name = "colTrainingUnitPhone";
            // 
            // colTrainingUnitEmail
            // 
            this.colTrainingUnitEmail.HeaderText = "דואל";
            this.colTrainingUnitEmail.Name = "colTrainingUnitEmail";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 460);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSettings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "הגדרות";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tabSettings.ResumeLayout(false);
            this.tabFilesLocations.ResumeLayout(false);
            this.tabFilesLocations.PerformLayout();
            this.tabStreets.ResumeLayout(false);
            this.tabLocations.ResumeLayout(false);
            this.tabLawEnforcementUnits.ResumeLayout(false);
            this.tabTrainingUnits.ResumeLayout(false);
            this.tabArrivalDirections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStreets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArrivalDirections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLawEnforcementUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainingUnits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabFilesLocations;
        private System.Windows.Forms.TabPage tabStreets;
        private System.Windows.Forms.TabPage tabLocations;
        private System.Windows.Forms.TabPage tabLawEnforcementUnits;
        private System.Windows.Forms.TabPage tabTrainingUnits;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLogFilePath;
        private System.Windows.Forms.TextBox txtJsonFileName;
        private System.Windows.Forms.CheckBox chkLogToFile;
        private System.Windows.Forms.Label lblJsonFileName;
        private System.Windows.Forms.Label lblLogFilePath;
        private System.Windows.Forms.Button btnJsonFilePath;
        private System.Windows.Forms.Button btnLogFilePath;
        private System.Windows.Forms.TextBox txtJsonFilePath;
        private System.Windows.Forms.Label lblJsonFilePath;
        private System.Windows.Forms.TabPage tabArrivalDirections;
        private System.Windows.Forms.DataGridView dgvStreets;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStreet;
        private System.Windows.Forms.Button btnAddStreet;
        private System.Windows.Forms.DataGridView dgvLocations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLongtitue;
        private System.Windows.Forms.Button btnLocation;
        private System.Windows.Forms.DataGridView dgvArrivalDirections;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrivalDirection;
        private System.Windows.Forms.Button btnAddArrivalDirection;
        private System.Windows.Forms.DataGridView dgvLawEnforcementUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLawEnforcementUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLawEnforcementPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLawEnforcementEmail;
        private System.Windows.Forms.Button btnAddLawEnforcementUnit;
        private System.Windows.Forms.DataGridView dgvTrainingUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrainingUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFromHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrainingUnitContact;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrainingUnitPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrainingUnitEmail;
        private System.Windows.Forms.Button btnAddTrainingUnit;
    }
}