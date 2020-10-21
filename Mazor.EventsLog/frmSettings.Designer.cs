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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.txtLocationServiceCity = new System.Windows.Forms.TextBox();
            this.txtLocationServiceCountry = new System.Windows.Forms.TextBox();
            this.txtLocationServiceUrl = new System.Windows.Forms.TextBox();
            this.txtLocationServiceBingKey = new System.Windows.Forms.TextBox();
            this.nudZoomLevel = new System.Windows.Forms.NumericUpDown();
            this.nudPingTestIntervalInSeconds = new System.Windows.Forms.NumericUpDown();
            this.txtPingTestAddress = new System.Windows.Forms.TextBox();
            this.lblLocationServiceCity = new System.Windows.Forms.Label();
            this.lblLocationServiceCountry = new System.Windows.Forms.Label();
            this.lblLocationServiceUrl = new System.Windows.Forms.Label();
            this.lblZoomLevel = new System.Windows.Forms.Label();
            this.lblPingTestAddress = new System.Windows.Forms.Label();
            this.lblLocationServiceBingKey = new System.Windows.Forms.Label();
            this.lblPingTestIntervalInSeconds = new System.Windows.Forms.Label();
            this.btnSaveGeneral = new System.Windows.Forms.Button();
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
            this.dgvStreets = new System.Windows.Forms.DataGridView();
            this.colStreet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddStreet = new System.Windows.Forms.Button();
            this.tabLocations = new System.Windows.Forms.TabPage();
            this.dgvLocations = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLongtitue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLocation = new System.Windows.Forms.Button();
            this.tabArrivalDirections = new System.Windows.Forms.TabPage();
            this.dgvArrivalDirections = new System.Windows.Forms.DataGridView();
            this.colArrivalDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddArrivalDirection = new System.Windows.Forms.Button();
            this.tabLawEnforcementUnits = new System.Windows.Forms.TabPage();
            this.dgvLawEnforcementUnits = new System.Windows.Forms.DataGridView();
            this.colLawEnforcementUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLawEnforcementPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLawEnforcementEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddLawEnforcementUnit = new System.Windows.Forms.Button();
            this.tabTrainingUnits = new System.Windows.Forms.TabPage();
            this.dgvTrainingUnits = new System.Windows.Forms.DataGridView();
            this.colTrainingUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFromHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrainingUnitContact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrainingUnitPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrainingUnitEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddTrainingUnit = new System.Windows.Forms.Button();
            this.tabCriminalEvents = new System.Windows.Forms.TabPage();
            this.dgvCriminalEventTypes = new System.Windows.Forms.DataGridView();
            this.colCriminalEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCriminalEventId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddCriminalEventType = new System.Windows.Forms.Button();
            this.tabCameras = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colCamera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCameraLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCameraLongtitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddCamera = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoomLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPingTestIntervalInSeconds)).BeginInit();
            this.tabFilesLocations.SuspendLayout();
            this.tabStreets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStreets)).BeginInit();
            this.tabLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).BeginInit();
            this.tabArrivalDirections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArrivalDirections)).BeginInit();
            this.tabLawEnforcementUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLawEnforcementUnits)).BeginInit();
            this.tabTrainingUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainingUnits)).BeginInit();
            this.tabCriminalEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriminalEventTypes)).BeginInit();
            this.tabCameras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabGeneral);
            this.tabSettings.Controls.Add(this.tabFilesLocations);
            this.tabSettings.Controls.Add(this.tabStreets);
            this.tabSettings.Controls.Add(this.tabLocations);
            this.tabSettings.Controls.Add(this.tabArrivalDirections);
            this.tabSettings.Controls.Add(this.tabLawEnforcementUnits);
            this.tabSettings.Controls.Add(this.tabTrainingUnits);
            this.tabSettings.Controls.Add(this.tabCriminalEvents);
            this.tabSettings.Controls.Add(this.tabCameras);
            this.tabSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSettings.Location = new System.Drawing.Point(0, 0);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(1042, 460);
            this.tabSettings.TabIndex = 11;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.txtLocationServiceCity);
            this.tabGeneral.Controls.Add(this.txtLocationServiceCountry);
            this.tabGeneral.Controls.Add(this.txtLocationServiceUrl);
            this.tabGeneral.Controls.Add(this.txtLocationServiceBingKey);
            this.tabGeneral.Controls.Add(this.nudZoomLevel);
            this.tabGeneral.Controls.Add(this.nudPingTestIntervalInSeconds);
            this.tabGeneral.Controls.Add(this.txtPingTestAddress);
            this.tabGeneral.Controls.Add(this.lblLocationServiceCity);
            this.tabGeneral.Controls.Add(this.lblLocationServiceCountry);
            this.tabGeneral.Controls.Add(this.lblLocationServiceUrl);
            this.tabGeneral.Controls.Add(this.lblZoomLevel);
            this.tabGeneral.Controls.Add(this.lblPingTestAddress);
            this.tabGeneral.Controls.Add(this.lblLocationServiceBingKey);
            this.tabGeneral.Controls.Add(this.lblPingTestIntervalInSeconds);
            this.tabGeneral.Controls.Add(this.btnSaveGeneral);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(1034, 434);
            this.tabGeneral.TabIndex = 8;
            this.tabGeneral.Text = "כללי";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // txtLocationServiceCity
            // 
            this.txtLocationServiceCity.Location = new System.Drawing.Point(691, 104);
            this.txtLocationServiceCity.Name = "txtLocationServiceCity";
            this.txtLocationServiceCity.Size = new System.Drawing.Size(179, 20);
            this.txtLocationServiceCity.TabIndex = 35;
            // 
            // txtLocationServiceCountry
            // 
            this.txtLocationServiceCountry.Location = new System.Drawing.Point(770, 70);
            this.txtLocationServiceCountry.Name = "txtLocationServiceCountry";
            this.txtLocationServiceCountry.Size = new System.Drawing.Size(100, 20);
            this.txtLocationServiceCountry.TabIndex = 34;
            // 
            // txtLocationServiceUrl
            // 
            this.txtLocationServiceUrl.Location = new System.Drawing.Point(510, 36);
            this.txtLocationServiceUrl.Name = "txtLocationServiceUrl";
            this.txtLocationServiceUrl.Size = new System.Drawing.Size(360, 20);
            this.txtLocationServiceUrl.TabIndex = 33;
            // 
            // txtLocationServiceBingKey
            // 
            this.txtLocationServiceBingKey.Location = new System.Drawing.Point(510, 160);
            this.txtLocationServiceBingKey.Name = "txtLocationServiceBingKey";
            this.txtLocationServiceBingKey.Size = new System.Drawing.Size(360, 20);
            this.txtLocationServiceBingKey.TabIndex = 32;
            // 
            // nudZoomLevel
            // 
            this.nudZoomLevel.Location = new System.Drawing.Point(814, 235);
            this.nudZoomLevel.Name = "nudZoomLevel";
            this.nudZoomLevel.Size = new System.Drawing.Size(56, 20);
            this.nudZoomLevel.TabIndex = 31;
            // 
            // nudPingTestIntervalInSeconds
            // 
            this.nudPingTestIntervalInSeconds.Location = new System.Drawing.Point(814, 351);
            this.nudPingTestIntervalInSeconds.Name = "nudPingTestIntervalInSeconds";
            this.nudPingTestIntervalInSeconds.Size = new System.Drawing.Size(56, 20);
            this.nudPingTestIntervalInSeconds.TabIndex = 30;
            // 
            // txtPingTestAddress
            // 
            this.txtPingTestAddress.Location = new System.Drawing.Point(729, 324);
            this.txtPingTestAddress.Name = "txtPingTestAddress";
            this.txtPingTestAddress.Size = new System.Drawing.Size(141, 20);
            this.txtPingTestAddress.TabIndex = 29;
            // 
            // lblLocationServiceCity
            // 
            this.lblLocationServiceCity.AutoSize = true;
            this.lblLocationServiceCity.Location = new System.Drawing.Point(900, 107);
            this.lblLocationServiceCity.Name = "lblLocationServiceCity";
            this.lblLocationServiceCity.Size = new System.Drawing.Size(103, 13);
            this.lblLocationServiceCity.TabIndex = 28;
            this.lblLocationServiceCity.Text = "שרות מיקום - ישוב";
            // 
            // lblLocationServiceCountry
            // 
            this.lblLocationServiceCountry.AutoSize = true;
            this.lblLocationServiceCountry.Location = new System.Drawing.Point(896, 73);
            this.lblLocationServiceCountry.Name = "lblLocationServiceCountry";
            this.lblLocationServiceCountry.Size = new System.Drawing.Size(108, 13);
            this.lblLocationServiceCountry.TabIndex = 27;
            this.lblLocationServiceCountry.Text = "שרות מיקום - מדינה";
            // 
            // lblLocationServiceUrl
            // 
            this.lblLocationServiceUrl.AutoSize = true;
            this.lblLocationServiceUrl.Location = new System.Drawing.Point(876, 39);
            this.lblLocationServiceUrl.Name = "lblLocationServiceUrl";
            this.lblLocationServiceUrl.Size = new System.Drawing.Size(128, 13);
            this.lblLocationServiceUrl.TabIndex = 26;
            this.lblLocationServiceUrl.Text = "כתובת אתר שרות מיקום";
            // 
            // lblZoomLevel
            // 
            this.lblZoomLevel.AutoSize = true;
            this.lblZoomLevel.Location = new System.Drawing.Point(894, 237);
            this.lblZoomLevel.Name = "lblZoomLevel";
            this.lblZoomLevel.Size = new System.Drawing.Size(110, 13);
            this.lblZoomLevel.TabIndex = 25;
            this.lblZoomLevel.Text = "רמת ZOOM ראשונית";
            // 
            // lblPingTestAddress
            // 
            this.lblPingTestAddress.AutoSize = true;
            this.lblPingTestAddress.Location = new System.Drawing.Point(892, 327);
            this.lblPingTestAddress.Name = "lblPingTestAddress";
            this.lblPingTestAddress.Size = new System.Drawing.Size(112, 13);
            this.lblPingTestAddress.TabIndex = 24;
            this.lblPingTestAddress.Text = "כתובת לבדיקת PING";
            // 
            // lblLocationServiceBingKey
            // 
            this.lblLocationServiceBingKey.AutoSize = true;
            this.lblLocationServiceBingKey.Location = new System.Drawing.Point(939, 163);
            this.lblLocationServiceBingKey.Name = "lblLocationServiceBingKey";
            this.lblLocationServiceBingKey.Size = new System.Drawing.Size(64, 13);
            this.lblLocationServiceBingKey.TabIndex = 23;
            this.lblLocationServiceBingKey.Text = "מפתח BING";
            // 
            // lblPingTestIntervalInSeconds
            // 
            this.lblPingTestIntervalInSeconds.AutoSize = true;
            this.lblPingTestIntervalInSeconds.Location = new System.Drawing.Point(876, 353);
            this.lblPingTestIntervalInSeconds.Name = "lblPingTestIntervalInSeconds";
            this.lblPingTestIntervalInSeconds.Size = new System.Drawing.Size(128, 13);
            this.lblPingTestIntervalInSeconds.TabIndex = 22;
            this.lblPingTestIntervalInSeconds.Text = "שניות בין בדיקות PING";
            // 
            // btnSaveGeneral
            // 
            this.btnSaveGeneral.Location = new System.Drawing.Point(6, 396);
            this.btnSaveGeneral.Name = "btnSaveGeneral";
            this.btnSaveGeneral.Size = new System.Drawing.Size(92, 30);
            this.btnSaveGeneral.TabIndex = 21;
            this.btnSaveGeneral.Text = "שמירה";
            this.btnSaveGeneral.UseVisualStyleBackColor = true;
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
            // btnAddStreet
            // 
            this.btnAddStreet.Location = new System.Drawing.Point(686, 6);
            this.btnAddStreet.Name = "btnAddStreet";
            this.btnAddStreet.Size = new System.Drawing.Size(94, 36);
            this.btnAddStreet.TabIndex = 1;
            this.btnAddStreet.Text = "הוספת רחוב";
            this.btnAddStreet.UseVisualStyleBackColor = true;
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
            // btnLocation
            // 
            this.btnLocation.Location = new System.Drawing.Point(498, 8);
            this.btnLocation.Name = "btnLocation";
            this.btnLocation.Size = new System.Drawing.Size(94, 36);
            this.btnLocation.TabIndex = 3;
            this.btnLocation.Text = "הוספת מיקום";
            this.btnLocation.UseVisualStyleBackColor = true;
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
            // colArrivalDirection
            // 
            this.colArrivalDirection.HeaderText = "כוון הגעה";
            this.colArrivalDirection.Name = "colArrivalDirection";
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
            // btnAddLawEnforcementUnit
            // 
            this.btnAddLawEnforcementUnit.Location = new System.Drawing.Point(419, 8);
            this.btnAddLawEnforcementUnit.Name = "btnAddLawEnforcementUnit";
            this.btnAddLawEnforcementUnit.Size = new System.Drawing.Size(130, 36);
            this.btnAddLawEnforcementUnit.TabIndex = 7;
            this.btnAddLawEnforcementUnit.Text = "הוספת גורם אכיפה";
            this.btnAddLawEnforcementUnit.UseVisualStyleBackColor = true;
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
            // btnAddTrainingUnit
            // 
            this.btnAddTrainingUnit.Location = new System.Drawing.Point(34, 8);
            this.btnAddTrainingUnit.Name = "btnAddTrainingUnit";
            this.btnAddTrainingUnit.Size = new System.Drawing.Size(130, 36);
            this.btnAddTrainingUnit.TabIndex = 7;
            this.btnAddTrainingUnit.Text = "הוספת יחידה מתאמנת";
            this.btnAddTrainingUnit.UseVisualStyleBackColor = true;
            // 
            // tabCriminalEvents
            // 
            this.tabCriminalEvents.Controls.Add(this.dgvCriminalEventTypes);
            this.tabCriminalEvents.Controls.Add(this.btnAddCriminalEventType);
            this.tabCriminalEvents.Location = new System.Drawing.Point(4, 22);
            this.tabCriminalEvents.Name = "tabCriminalEvents";
            this.tabCriminalEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tabCriminalEvents.Size = new System.Drawing.Size(1034, 434);
            this.tabCriminalEvents.TabIndex = 6;
            this.tabCriminalEvents.Text = "אירועים";
            this.tabCriminalEvents.UseVisualStyleBackColor = true;
            // 
            // dgvCriminalEventTypes
            // 
            this.dgvCriminalEventTypes.AllowUserToAddRows = false;
            this.dgvCriminalEventTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriminalEventTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCriminalEventType,
            this.colCriminalEventId});
            this.dgvCriminalEventTypes.Location = new System.Drawing.Point(786, 8);
            this.dgvCriminalEventTypes.Name = "dgvCriminalEventTypes";
            this.dgvCriminalEventTypes.Size = new System.Drawing.Size(240, 420);
            this.dgvCriminalEventTypes.TabIndex = 4;
            // 
            // colCriminalEventType
            // 
            this.colCriminalEventType.HeaderText = "סוג אירוע";
            this.colCriminalEventType.Name = "colCriminalEventType";
            // 
            // colCriminalEventId
            // 
            this.colCriminalEventId.HeaderText = "Id";
            this.colCriminalEventId.Name = "colCriminalEventId";
            this.colCriminalEventId.Visible = false;
            // 
            // btnAddCriminalEventType
            // 
            this.btnAddCriminalEventType.Location = new System.Drawing.Point(674, 8);
            this.btnAddCriminalEventType.Name = "btnAddCriminalEventType";
            this.btnAddCriminalEventType.Size = new System.Drawing.Size(106, 36);
            this.btnAddCriminalEventType.TabIndex = 3;
            this.btnAddCriminalEventType.Text = "הוספת סוג אירוע";
            this.btnAddCriminalEventType.UseVisualStyleBackColor = true;
            this.btnAddCriminalEventType.Click += new System.EventHandler(this.btnAddCriminalEventType_Click);
            // 
            // tabCameras
            // 
            this.tabCameras.Controls.Add(this.dataGridView1);
            this.tabCameras.Controls.Add(this.btnAddCamera);
            this.tabCameras.Location = new System.Drawing.Point(4, 22);
            this.tabCameras.Name = "tabCameras";
            this.tabCameras.Padding = new System.Windows.Forms.Padding(3);
            this.tabCameras.Size = new System.Drawing.Size(1034, 434);
            this.tabCameras.TabIndex = 7;
            this.tabCameras.Text = "מצלמות";
            this.tabCameras.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCamera,
            this.colCameraLatitude,
            this.colCameraLongtitude});
            this.dataGridView1.Location = new System.Drawing.Point(598, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(428, 420);
            this.dataGridView1.TabIndex = 6;
            // 
            // colCamera
            // 
            this.colCamera.HeaderText = "מצלמה";
            this.colCamera.Name = "colCamera";
            // 
            // colCameraLatitude
            // 
            this.colCameraLatitude.HeaderText = "נקודת רוחב";
            this.colCameraLatitude.Name = "colCameraLatitude";
            // 
            // colCameraLongtitude
            // 
            this.colCameraLongtitude.HeaderText = "נקודת אורך";
            this.colCameraLongtitude.Name = "colCameraLongtitude";
            // 
            // btnAddCamera
            // 
            this.btnAddCamera.Location = new System.Drawing.Point(498, 8);
            this.btnAddCamera.Name = "btnAddCamera";
            this.btnAddCamera.Size = new System.Drawing.Size(94, 36);
            this.btnAddCamera.TabIndex = 5;
            this.btnAddCamera.Text = "הוספת מצלמה";
            this.btnAddCamera.UseVisualStyleBackColor = true;
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
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudZoomLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPingTestIntervalInSeconds)).EndInit();
            this.tabFilesLocations.ResumeLayout(false);
            this.tabFilesLocations.PerformLayout();
            this.tabStreets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStreets)).EndInit();
            this.tabLocations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).EndInit();
            this.tabArrivalDirections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArrivalDirections)).EndInit();
            this.tabLawEnforcementUnits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLawEnforcementUnits)).EndInit();
            this.tabTrainingUnits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrainingUnits)).EndInit();
            this.tabCriminalEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriminalEventTypes)).EndInit();
            this.tabCameras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.TabPage tabCriminalEvents;
        private System.Windows.Forms.TabPage tabCameras;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCamera;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCameraLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCameraLongtitude;
        private System.Windows.Forms.Button btnAddCamera;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.Button btnSaveGeneral;
        private System.Windows.Forms.Label lblLocationServiceCity;
        private System.Windows.Forms.Label lblLocationServiceCountry;
        private System.Windows.Forms.Label lblLocationServiceUrl;
        private System.Windows.Forms.Label lblZoomLevel;
        private System.Windows.Forms.Label lblPingTestAddress;
        private System.Windows.Forms.Label lblLocationServiceBingKey;
        private System.Windows.Forms.Label lblPingTestIntervalInSeconds;
        private System.Windows.Forms.NumericUpDown nudZoomLevel;
        private System.Windows.Forms.NumericUpDown nudPingTestIntervalInSeconds;
        private System.Windows.Forms.TextBox txtPingTestAddress;
        private System.Windows.Forms.TextBox txtLocationServiceCity;
        private System.Windows.Forms.TextBox txtLocationServiceCountry;
        private System.Windows.Forms.TextBox txtLocationServiceUrl;
        private System.Windows.Forms.TextBox txtLocationServiceBingKey;
        private System.Windows.Forms.DataGridView dgvCriminalEventTypes;
        private System.Windows.Forms.Button btnAddCriminalEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriminalEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCriminalEventId;
    }
}