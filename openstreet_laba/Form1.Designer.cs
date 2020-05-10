namespace openstreet_laba
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gmap = new GMap.NET.WindowsForms.GMapControl();
            this.tb_city1 = new System.Windows.Forms.TextBox();
            this.b_city1 = new System.Windows.Forms.Button();
            this.b_city2 = new System.Windows.Forms.Button();
            this.tb_city2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_district = new System.Windows.Forms.TextBox();
            this.b_district = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cb_showOnMap = new System.Windows.Forms.ComboBox();
            this.b_showOnMap = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gmap
            // 
            this.gmap.Bearing = 0F;
            this.gmap.CanDragMap = true;
            this.gmap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmap.GrayScaleMode = false;
            this.gmap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmap.LevelsKeepInMemmory = 5;
            this.gmap.Location = new System.Drawing.Point(12, 12);
            this.gmap.MarkersEnabled = true;
            this.gmap.MaxZoom = 2;
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
            this.gmap.Size = new System.Drawing.Size(604, 405);
            this.gmap.TabIndex = 0;
            this.gmap.Zoom = 0D;
            this.gmap.Load += new System.EventHandler(this.gMapControl1_Load);
            this.gmap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gmap_MouseClick);
            // 
            // tb_city1
            // 
            this.tb_city1.Location = new System.Drawing.Point(6, 19);
            this.tb_city1.Name = "tb_city1";
            this.tb_city1.Size = new System.Drawing.Size(100, 20);
            this.tb_city1.TabIndex = 1;
            // 
            // b_city1
            // 
            this.b_city1.Location = new System.Drawing.Point(6, 45);
            this.b_city1.Name = "b_city1";
            this.b_city1.Size = new System.Drawing.Size(75, 23);
            this.b_city1.TabIndex = 2;
            this.b_city1.Text = "Принять";
            this.b_city1.UseVisualStyleBackColor = true;
            this.b_city1.Click += new System.EventHandler(this.button1_Click);
            // 
            // b_city2
            // 
            this.b_city2.Location = new System.Drawing.Point(149, 45);
            this.b_city2.Name = "b_city2";
            this.b_city2.Size = new System.Drawing.Size(75, 23);
            this.b_city2.TabIndex = 4;
            this.b_city2.Text = "Принять";
            this.b_city2.UseVisualStyleBackColor = true;
            this.b_city2.Click += new System.EventHandler(this.b_city2_Click);
            // 
            // tb_city2
            // 
            this.tb_city2.Location = new System.Drawing.Point(149, 19);
            this.tb_city2.Name = "tb_city2";
            this.tb_city2.Size = new System.Drawing.Size(100, 20);
            this.tb_city2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_city1);
            this.groupBox1.Controls.Add(this.b_city1);
            this.groupBox1.Controls.Add(this.b_city2);
            this.groupBox1.Controls.Add(this.tb_city2);
            this.groupBox1.Location = new System.Drawing.Point(623, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Введите два города:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(625, 127);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(363, 290);
            this.dataGridView1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.b_showOnMap);
            this.groupBox2.Controls.Add(this.cb_showOnMap);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.b_district);
            this.groupBox2.Controls.Add(this.tb_district);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(990, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(295, 405);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Расчет плотности покрытия района услугами";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите город, район (например: \"Пермь, Кировский район\")";
            // 
            // tb_district
            // 
            this.tb_district.Location = new System.Drawing.Point(9, 48);
            this.tb_district.Name = "tb_district";
            this.tb_district.Size = new System.Drawing.Size(280, 20);
            this.tb_district.TabIndex = 2;
            // 
            // b_district
            // 
            this.b_district.Location = new System.Drawing.Point(9, 74);
            this.b_district.Name = "b_district";
            this.b_district.Size = new System.Drawing.Size(75, 23);
            this.b_district.TabIndex = 3;
            this.b_district.Text = "Принять";
            this.b_district.UseVisualStyleBackColor = true;
            this.b_district.Click += new System.EventHandler(this.b_district_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(10, 103);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(279, 263);
            this.dataGridView2.TabIndex = 8;
            // 
            // cb_showOnMap
            // 
            this.cb_showOnMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_showOnMap.FormattingEnabled = true;
            this.cb_showOnMap.Location = new System.Drawing.Point(10, 372);
            this.cb_showOnMap.Name = "cb_showOnMap";
            this.cb_showOnMap.Size = new System.Drawing.Size(150, 21);
            this.cb_showOnMap.TabIndex = 9;
            // 
            // b_showOnMap
            // 
            this.b_showOnMap.Location = new System.Drawing.Point(166, 371);
            this.b_showOnMap.Name = "b_showOnMap";
            this.b_showOnMap.Size = new System.Drawing.Size(123, 23);
            this.b_showOnMap.TabIndex = 10;
            this.b_showOnMap.Text = "Показать на карте";
            this.b_showOnMap.UseVisualStyleBackColor = true;
            this.b_showOnMap.Click += new System.EventHandler(this.b_showOnMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gmap);
            this.Name = "Form1";
            this.Text = "Лабораторная работа OpenStreetMap";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmap;
        private System.Windows.Forms.TextBox tb_city1;
        private System.Windows.Forms.Button b_city1;
        private System.Windows.Forms.Button b_city2;
        private System.Windows.Forms.TextBox tb_city2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_district;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_district;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button b_showOnMap;
        private System.Windows.Forms.ComboBox cb_showOnMap;
    }
}

