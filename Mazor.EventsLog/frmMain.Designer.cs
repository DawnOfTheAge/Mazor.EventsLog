namespace Mazor.EventsLog
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ribbonMain = new System.Windows.Forms.Ribbon();
            this.rtCrudRecord = new System.Windows.Forms.RibbonTab();
            this.rpEvents = new System.Windows.Forms.RibbonPanel();
            this.btnDeleteEvent = new System.Windows.Forms.RibbonButton();
            this.btnModifyEvent = new System.Windows.Forms.RibbonButton();
            this.btnAddEvent = new System.Windows.Forms.RibbonButton();
            this.rpQueries = new System.Windows.Forms.RibbonPanel();
            this.btnCombined = new System.Windows.Forms.RibbonButton();
            this.btnByFamily = new System.Windows.Forms.RibbonButton();
            this.btnByEventType = new System.Windows.Forms.RibbonButton();
            this.btnByDateTime = new System.Windows.Forms.RibbonButton();
            this.btnByAddress = new System.Windows.Forms.RibbonButton();
            this.btnAll = new System.Windows.Forms.RibbonButton();
            this.rpMap = new System.Windows.Forms.RibbonPanel();
            this.btnMap = new System.Windows.Forms.RibbonButton();
            this.rpGeneral = new System.Windows.Forms.RibbonPanel();
            this.btnExit = new System.Windows.Forms.RibbonButton();
            this.btnVersion = new System.Windows.Forms.RibbonButton();
            this.btnSettings = new System.Windows.Forms.RibbonButton();
            this.ribbonButton4 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton5 = new System.Windows.Forms.RibbonButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvEventsLog = new System.Windows.Forms.DataGridView();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPresentInEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrivalDirection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStolen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFamily = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEventType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStreet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHouseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeEnum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAudit = new System.Windows.Forms.DataGridView();
            this.colDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeverity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tmrTestConnection = new System.Windows.Forms.Timer(this.components);
            this.btnBudget = new System.Windows.Forms.RibbonButton();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventsLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudit)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonMain
            // 
            this.ribbonMain.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbonMain.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.Minimized = false;
            this.ribbonMain.Name = "ribbonMain";
            // 
            // 
            // 
            this.ribbonMain.OrbDropDown.BorderRoundness = 8;
            this.ribbonMain.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbonMain.OrbDropDown.Name = "";
            this.ribbonMain.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbonMain.OrbDropDown.TabIndex = 0;
            this.ribbonMain.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbonMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ribbonMain.Size = new System.Drawing.Size(1099, 140);
            this.ribbonMain.TabIndex = 0;
            this.ribbonMain.Tabs.Add(this.rtCrudRecord);
            this.ribbonMain.Text = "ribbon1";
            // 
            // rtCrudRecord
            // 
            this.rtCrudRecord.Name = "rtCrudRecord";
            this.rtCrudRecord.Panels.Add(this.rpEvents);
            this.rtCrudRecord.Panels.Add(this.rpQueries);
            this.rtCrudRecord.Panels.Add(this.rpMap);
            this.rtCrudRecord.Panels.Add(this.rpGeneral);
            this.rtCrudRecord.Text = "פעולות";
            // 
            // rpEvents
            // 
            this.rpEvents.Items.Add(this.btnDeleteEvent);
            this.rpEvents.Items.Add(this.btnModifyEvent);
            this.rpEvents.Items.Add(this.btnAddEvent);
            this.rpEvents.Name = "rpEvents";
            this.rpEvents.Text = " אירועים";
            // 
            // btnDeleteEvent
            // 
            this.btnDeleteEvent.Image = global::Mazor.EventsLog.Properties.Resources.DeleteEvent;
            this.btnDeleteEvent.LargeImage = global::Mazor.EventsLog.Properties.Resources.DeleteEvent;
            this.btnDeleteEvent.Name = "btnDeleteEvent";
            this.btnDeleteEvent.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDeleteEvent.SmallImage")));
            this.btnDeleteEvent.Text = "הסרה";
            this.btnDeleteEvent.Click += new System.EventHandler(this.btnDeleteEvent_Click);
            // 
            // btnModifyEvent
            // 
            this.btnModifyEvent.Image = global::Mazor.EventsLog.Properties.Resources.ModifyEvent;
            this.btnModifyEvent.LargeImage = global::Mazor.EventsLog.Properties.Resources.ModifyEvent;
            this.btnModifyEvent.Name = "btnModifyEvent";
            this.btnModifyEvent.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnModifyEvent.SmallImage")));
            this.btnModifyEvent.Text = "עדכון";
            this.btnModifyEvent.Click += new System.EventHandler(this.btnUpdateEvent_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Image = global::Mazor.EventsLog.Properties.Resources.AddEvent;
            this.btnAddEvent.LargeImage = global::Mazor.EventsLog.Properties.Resources.AddEvent;
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAddEvent.SmallImage")));
            this.btnAddEvent.Text = "הוספה";
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // rpQueries
            // 
            this.rpQueries.Items.Add(this.btnCombined);
            this.rpQueries.Items.Add(this.btnByFamily);
            this.rpQueries.Items.Add(this.btnByEventType);
            this.rpQueries.Items.Add(this.btnByDateTime);
            this.rpQueries.Items.Add(this.btnByAddress);
            this.rpQueries.Items.Add(this.btnAll);
            this.rpQueries.Name = "rpQueries";
            this.rpQueries.Text = "שאילתות לפי";
            // 
            // btnCombined
            // 
            this.btnCombined.Image = global::Mazor.EventsLog.Properties.Resources.Combined;
            this.btnCombined.LargeImage = global::Mazor.EventsLog.Properties.Resources.Combined;
            this.btnCombined.Name = "btnCombined";
            this.btnCombined.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCombined.SmallImage")));
            this.btnCombined.Text = "משולב";
            this.btnCombined.Click += new System.EventHandler(this.btnCombined_Click);
            // 
            // btnByFamily
            // 
            this.btnByFamily.Image = global::Mazor.EventsLog.Properties.Resources.Family;
            this.btnByFamily.LargeImage = global::Mazor.EventsLog.Properties.Resources.Family;
            this.btnByFamily.Name = "btnByFamily";
            this.btnByFamily.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnByFamily.SmallImage")));
            this.btnByFamily.Text = "משק/משפחה";
            this.btnByFamily.Click += new System.EventHandler(this.btnByFamily_Click);
            // 
            // btnByEventType
            // 
            this.btnByEventType.Image = global::Mazor.EventsLog.Properties.Resources.EventType;
            this.btnByEventType.LargeImage = global::Mazor.EventsLog.Properties.Resources.EventType;
            this.btnByEventType.Name = "btnByEventType";
            this.btnByEventType.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnByEventType.SmallImage")));
            this.btnByEventType.Text = "אירוע";
            this.btnByEventType.Click += new System.EventHandler(this.btnByEventType_Click);
            // 
            // btnByDateTime
            // 
            this.btnByDateTime.Image = global::Mazor.EventsLog.Properties.Resources.DateTime;
            this.btnByDateTime.LargeImage = global::Mazor.EventsLog.Properties.Resources.DateTime;
            this.btnByDateTime.Name = "btnByDateTime";
            this.btnByDateTime.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnByDateTime.SmallImage")));
            this.btnByDateTime.Text = "תאריך/זמן";
            this.btnByDateTime.Click += new System.EventHandler(this.btnByDateTime_Click);
            // 
            // btnByAddress
            // 
            this.btnByAddress.Image = global::Mazor.EventsLog.Properties.Resources.Address;
            this.btnByAddress.LargeImage = global::Mazor.EventsLog.Properties.Resources.Address;
            this.btnByAddress.Name = "btnByAddress";
            this.btnByAddress.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnByAddress.SmallImage")));
            this.btnByAddress.Text = "כתובת";
            this.btnByAddress.Click += new System.EventHandler(this.btnByAddress_Click);
            // 
            // btnAll
            // 
            this.btnAll.Image = global::Mazor.EventsLog.Properties.Resources.All;
            this.btnAll.LargeImage = global::Mazor.EventsLog.Properties.Resources.All;
            this.btnAll.Name = "btnAll";
            this.btnAll.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnAll.SmallImage")));
            this.btnAll.Text = "הכל";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // rpMap
            // 
            this.rpMap.Items.Add(this.btnMap);
            this.rpMap.Name = "rpMap";
            this.rpMap.Text = "מפה";
            // 
            // btnMap
            // 
            this.btnMap.Image = global::Mazor.EventsLog.Properties.Resources.Map;
            this.btnMap.LargeImage = global::Mazor.EventsLog.Properties.Resources.Map;
            this.btnMap.Name = "btnMap";
            this.btnMap.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnMap.SmallImage")));
            this.btnMap.Text = "המושב";
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // rpGeneral
            // 
            this.rpGeneral.Items.Add(this.btnExit);
            this.rpGeneral.Items.Add(this.btnVersion);
            this.rpGeneral.Items.Add(this.btnSettings);
            this.rpGeneral.Items.Add(this.btnBudget);
            this.rpGeneral.Name = "rpGeneral";
            this.rpGeneral.Text = "כללי";
            // 
            // btnExit
            // 
            this.btnExit.Image = global::Mazor.EventsLog.Properties.Resources.Exit;
            this.btnExit.LargeImage = global::Mazor.EventsLog.Properties.Resources.Exit;
            this.btnExit.Name = "btnExit";
            this.btnExit.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnExit.SmallImage")));
            this.btnExit.Text = "יציאה";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnVersion
            // 
            this.btnVersion.Image = global::Mazor.EventsLog.Properties.Resources.Version;
            this.btnVersion.LargeImage = global::Mazor.EventsLog.Properties.Resources.Version;
            this.btnVersion.Name = "btnVersion";
            this.btnVersion.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnVersion.SmallImage")));
            this.btnVersion.Text = "גרסה";
            this.btnVersion.Click += new System.EventHandler(this.btnVersion_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.DropDownItems.Add(this.ribbonButton4);
            this.btnSettings.DropDownItems.Add(this.ribbonButton5);
            this.btnSettings.Image = global::Mazor.EventsLog.Properties.Resources.Settings;
            this.btnSettings.LargeImage = global::Mazor.EventsLog.Properties.Resources.Settings;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.SmallImage")));
            this.btnSettings.Text = "הגדרות";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // ribbonButton4
            // 
            this.ribbonButton4.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.Image")));
            this.ribbonButton4.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.LargeImage")));
            this.ribbonButton4.Name = "ribbonButton4";
            this.ribbonButton4.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton4.SmallImage")));
            this.ribbonButton4.Text = "ribbonButton4";
            // 
            // ribbonButton5
            // 
            this.ribbonButton5.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.Image")));
            this.ribbonButton5.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.LargeImage")));
            this.ribbonButton5.Name = "ribbonButton5";
            this.ribbonButton5.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton5.SmallImage")));
            this.ribbonButton5.Text = "ribbonButton5";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 140);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1099, 603);
            this.pnlMain.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dgvEventsLog);
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.dgvAudit);
            this.splitContainer.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer.Size = new System.Drawing.Size(1099, 603);
            this.splitContainer.SplitterDistance = 301;
            this.splitContainer.TabIndex = 1;
            // 
            // dgvEventsLog
            // 
            this.dgvEventsLog.AllowUserToAddRows = false;
            this.dgvEventsLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventsLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDescription,
            this.colPresentInEvent,
            this.colArrivalDirection,
            this.colStolen,
            this.colAddress,
            this.colFamily,
            this.colTime,
            this.colDay,
            this.colDate,
            this.colEventType,
            this.col,
            this.colFullTime,
            this.colStreet,
            this.colHouseNumber,
            this.colTypeEnum});
            this.dgvEventsLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEventsLog.Location = new System.Drawing.Point(0, 0);
            this.dgvEventsLog.Name = "dgvEventsLog";
            this.dgvEventsLog.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvEventsLog.Size = new System.Drawing.Size(1099, 301);
            this.dgvEventsLog.TabIndex = 1;
            // 
            // colDescription
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDescription.HeaderText = "תיאור כללי";
            this.colDescription.Name = "colDescription";
            // 
            // colPresentInEvent
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colPresentInEvent.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPresentInEvent.HeaderText = "נוכחים באירוע";
            this.colPresentInEvent.Name = "colPresentInEvent";
            // 
            // colArrivalDirection
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colArrivalDirection.DefaultCellStyle = dataGridViewCellStyle3;
            this.colArrivalDirection.HeaderText = "כיוון הגעה";
            this.colArrivalDirection.Name = "colArrivalDirection";
            // 
            // colStolen
            // 
            this.colStolen.HeaderText = "פרטי האירוע";
            this.colStolen.Name = "colStolen";
            // 
            // colAddress
            // 
            this.colAddress.HeaderText = "כתובת";
            this.colAddress.Name = "colAddress";
            // 
            // colFamily
            // 
            this.colFamily.HeaderText = "משפחה/משק";
            this.colFamily.Name = "colFamily";
            // 
            // colTime
            // 
            this.colTime.HeaderText = "שעה";
            this.colTime.Name = "colTime";
            // 
            // colDay
            // 
            this.colDay.HeaderText = "יום";
            this.colDay.Name = "colDay";
            // 
            // colDate
            // 
            this.colDate.HeaderText = "תאריך";
            this.colDate.Name = "colDate";
            // 
            // colEventType
            // 
            this.colEventType.HeaderText = "סוג אירוע";
            this.colEventType.Name = "colEventType";
            // 
            // col
            // 
            this.col.HeaderText = "Index";
            this.col.Name = "col";
            this.col.Visible = false;
            // 
            // colFullTime
            // 
            this.colFullTime.HeaderText = "Full Time";
            this.colFullTime.Name = "colFullTime";
            this.colFullTime.Visible = false;
            // 
            // colStreet
            // 
            this.colStreet.HeaderText = "Street";
            this.colStreet.Name = "colStreet";
            this.colStreet.Visible = false;
            // 
            // colHouseNumber
            // 
            this.colHouseNumber.HeaderText = "House Number";
            this.colHouseNumber.Name = "colHouseNumber";
            this.colHouseNumber.Visible = false;
            // 
            // colTypeEnum
            // 
            this.colTypeEnum.HeaderText = "Type";
            this.colTypeEnum.Name = "colTypeEnum";
            this.colTypeEnum.Visible = false;
            // 
            // dgvAudit
            // 
            this.dgvAudit.AllowUserToAddRows = false;
            this.dgvAudit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAudit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDateTime,
            this.colSeverity,
            this.colMessage});
            this.dgvAudit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAudit.Location = new System.Drawing.Point(0, 0);
            this.dgvAudit.Name = "dgvAudit";
            this.dgvAudit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAudit.Size = new System.Drawing.Size(1099, 298);
            this.dgvAudit.TabIndex = 0;
            // 
            // colDateTime
            // 
            this.colDateTime.HeaderText = "זמן";
            this.colDateTime.Name = "colDateTime";
            // 
            // colSeverity
            // 
            this.colSeverity.HeaderText = "חומרה";
            this.colSeverity.Name = "colSeverity";
            // 
            // colMessage
            // 
            this.colMessage.HeaderText = "הודעה";
            this.colMessage.Name = "colMessage";
            // 
            // tmrTestConnection
            // 
            this.tmrTestConnection.Tick += new System.EventHandler(this.tmrTestConnection_Tick);
            // 
            // btnBudget
            // 
            this.btnBudget.Image = global::Mazor.EventsLog.Properties.Resources.Budget;
            this.btnBudget.LargeImage = global::Mazor.EventsLog.Properties.Resources.Budget;
            this.btnBudget.Name = "btnBudget";
            this.btnBudget.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnBudget.SmallImage")));
            this.btnBudget.Text = "תקציב";
            this.btnBudget.Click += new System.EventHandler(this.btnBudget_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 743);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.ribbonMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "יומן אירועים - מושב מזור";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlMain.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventsLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAudit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbonMain;
        private System.Windows.Forms.RibbonTab rtCrudRecord;
        private System.Windows.Forms.RibbonPanel rpEvents;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.RibbonPanel rpQueries;
        private System.Windows.Forms.RibbonPanel rpGeneral;
        private System.Windows.Forms.RibbonButton btnAddEvent;
        private System.Windows.Forms.RibbonButton btnModifyEvent;
        private System.Windows.Forms.RibbonButton btnDeleteEvent;
        private System.Windows.Forms.RibbonButton btnSettings;
        private System.Windows.Forms.RibbonButton ribbonButton4;
        private System.Windows.Forms.RibbonButton ribbonButton5;
        private System.Windows.Forms.RibbonButton btnExit;
        private System.Windows.Forms.RibbonButton btnByAddress;
        private System.Windows.Forms.RibbonButton btnByDateTime;
        private System.Windows.Forms.RibbonButton btnByFamily;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dgvEventsLog;
        private System.Windows.Forms.DataGridView dgvAudit;
        private System.Windows.Forms.RibbonButton btnAll;
        private System.Windows.Forms.RibbonButton btnByEventType;
        private System.Windows.Forms.RibbonButton btnCombined;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeverity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMessage;
        private System.Windows.Forms.RibbonButton btnVersion;
        private System.Windows.Forms.RibbonPanel rpMap;
        private System.Windows.Forms.RibbonButton btnMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPresentInEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrivalDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStolen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFamily;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEventType;
        private System.Windows.Forms.DataGridViewTextBoxColumn col;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStreet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHouseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeEnum;
        private System.Windows.Forms.Timer tmrTestConnection;
        private System.Windows.Forms.RibbonButton btnBudget;
    }
}

