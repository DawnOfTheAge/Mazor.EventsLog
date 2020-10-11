namespace Mazor.EventsLog
{
    partial class frmMap
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
            DevExpress.XtraMap.ImageTilesLayer imageTilesLayer1 = new DevExpress.XtraMap.ImageTilesLayer();
            DevExpress.XtraMap.BingMapDataProvider bingMapDataProvider1 = new DevExpress.XtraMap.BingMapDataProvider();
            DevExpress.XtraMap.MapOverlay mapOverlay1 = new DevExpress.XtraMap.MapOverlay();
            this.tabMaps = new System.Windows.Forms.TabControl();
            this.tabGMap = new System.Windows.Forms.TabPage();
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.tabBing = new System.Windows.Forms.TabPage();
            this.bingMap = new DevExpress.XtraMap.MapControl();
            this.tabMaps.SuspendLayout();
            this.tabGMap.SuspendLayout();
            this.tabBing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bingMap)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMaps
            // 
            this.tabMaps.Controls.Add(this.tabGMap);
            this.tabMaps.Controls.Add(this.tabBing);
            this.tabMaps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMaps.Location = new System.Drawing.Point(0, 0);
            this.tabMaps.Name = "tabMaps";
            this.tabMaps.SelectedIndex = 0;
            this.tabMaps.Size = new System.Drawing.Size(1113, 749);
            this.tabMaps.TabIndex = 4;
            // 
            // tabGMap
            // 
            this.tabGMap.Controls.Add(this.gmap);
            this.tabGMap.Location = new System.Drawing.Point(4, 22);
            this.tabGMap.Name = "tabGMap";
            this.tabGMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabGMap.Size = new System.Drawing.Size(1105, 723);
            this.tabGMap.TabIndex = 0;
            this.tabGMap.Text = "GMap";
            this.tabGMap.UseVisualStyleBackColor = true;
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(3, 3);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 18;
            this.gmap.MinZoom = 2;
            this.gmap.MouseWheelZoomEnabled = true;
            this.gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmap.Name = "gmap";
            this.gmap.NegativeMode = false;
            this.gmap.PolygonsEnabled = true;
            this.gmap.RetryLoadTile = 0;
            this.gmap.RoutesEnabled = true;
            this.gmap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmap.ShowTileGridLines = false;
            this.gmap.Size = new System.Drawing.Size(1099, 717);
            this.gmap.TabIndex = 3;
            this.gmap.Zoom = 0D;
            // 
            // tabBing
            // 
            this.tabBing.Controls.Add(this.bingMap);
            this.tabBing.Location = new System.Drawing.Point(4, 22);
            this.tabBing.Name = "tabBing";
            this.tabBing.Padding = new System.Windows.Forms.Padding(3);
            this.tabBing.Size = new System.Drawing.Size(1105, 750);
            this.tabBing.TabIndex = 1;
            this.tabBing.Text = "המושב";
            this.tabBing.UseVisualStyleBackColor = true;
            // 
            // bingMap
            // 
            this.bingMap.Dock = System.Windows.Forms.DockStyle.Fill;
            bingMapDataProvider1.BingKey = "sWso5nC3GzNly45E6OOc~cIvCiT2Z6cXux0c8GvBb0w~Al-KC2g_9V8ETMZ-YdKyKEiPDQGRthztTwCwg" +
    "_LgOpadEfFxeZ_xFjF0lpVgJLQs";
            bingMapDataProvider1.TileSource = null;
            imageTilesLayer1.DataProvider = bingMapDataProvider1;
            this.bingMap.Layers.Add(imageTilesLayer1);
            this.bingMap.Location = new System.Drawing.Point(3, 3);
            this.bingMap.Name = "bingMap";
            this.bingMap.Overlays.Add(mapOverlay1);
            this.bingMap.Size = new System.Drawing.Size(1099, 744);
            this.bingMap.TabIndex = 4;
            // 
            // frmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 749);
            this.Controls.Add(this.tabMaps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmMap";
            this.Text = "אזור המושב";
            this.Load += new System.EventHandler(this.frmMap_Load);
            this.tabMaps.ResumeLayout(false);
            this.tabGMap.ResumeLayout(false);
            this.tabBing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bingMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMaps;
        private System.Windows.Forms.TabPage tabGMap;
        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.TabPage tabBing;
        private DevExpress.XtraMap.MapControl bingMap;
    }
}