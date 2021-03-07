
namespace BodegaMartinez.VISTAS.REPORTES
{
    partial class formReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formReportes));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlTipoReporte = new System.Windows.Forms.Panel();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pbxIcono = new System.Windows.Forms.PictureBox();
            this.pnlVentas = new System.Windows.Forms.Panel();
            this.mireporteventas = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.PanelEmpleado = new System.Windows.Forms.Panel();
            this.cbxEmpleado = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnHoy = new System.Windows.Forms.Button();
            this.checkFiltros = new System.Windows.Forms.CheckBox();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.MenuStrip6 = new System.Windows.Forms.MenuStrip();
            this.btnFiltros = new System.Windows.Forms.ToolStripMenuItem();
            this.flowOpcionesVentas = new System.Windows.Forms.FlowLayoutPanel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.btnResumenVentas = new System.Windows.Forms.Button();
            this.PResumenVentas = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.PVentasPorempleado = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTipoReporte.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcono)).BeginInit();
            this.pnlVentas.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.PanelEmpleado.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.MenuStrip6.SuspendLayout();
            this.flowOpcionesVentas.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTipoReporte
            // 
            this.pnlTipoReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.pnlTipoReporte.Controls.Add(this.btnProductos);
            this.pnlTipoReporte.Controls.Add(this.btnPagar);
            this.pnlTipoReporte.Controls.Add(this.btnCobrar);
            this.pnlTipoReporte.Controls.Add(this.btnVentas);
            this.pnlTipoReporte.Controls.Add(this.Panel1);
            this.pnlTipoReporte.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTipoReporte.Location = new System.Drawing.Point(0, 0);
            this.pnlTipoReporte.Margin = new System.Windows.Forms.Padding(4);
            this.pnlTipoReporte.Name = "pnlTipoReporte";
            this.pnlTipoReporte.Size = new System.Drawing.Size(252, 543);
            this.pnlTipoReporte.TabIndex = 403;
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProductos.Location = new System.Drawing.Point(0, 232);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(252, 60);
            this.btnProductos.TabIndex = 616;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPagar.FlatAppearance.BorderSize = 0;
            this.btnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagar.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPagar.Location = new System.Drawing.Point(0, 172);
            this.btnPagar.Margin = new System.Windows.Forms.Padding(4);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(252, 60);
            this.btnPagar.TabIndex = 615;
            this.btnPagar.Text = "Cuentas por Pagar";
            this.btnPagar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagar.UseVisualStyleBackColor = true;
            // 
            // btnCobrar
            // 
            this.btnCobrar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCobrar.FlatAppearance.BorderSize = 0;
            this.btnCobrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCobrar.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCobrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCobrar.Location = new System.Drawing.Point(0, 112);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(252, 60);
            this.btnCobrar.TabIndex = 614;
            this.btnCobrar.Text = "Cuentas por Cobrar";
            this.btnCobrar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCobrar.UseVisualStyleBackColor = true;
            // 
            // btnVentas
            // 
            this.btnVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVentas.Location = new System.Drawing.Point(0, 52);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(4);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(252, 60);
            this.btnVentas.TabIndex = 613;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVentas.UseVisualStyleBackColor = true;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(243)))), ((int)(((byte)(244)))));
            this.Panel1.Controls.Add(this.label1);
            this.Panel1.Controls.Add(this.pbxIcono);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(252, 52);
            this.Panel1.TabIndex = 593;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(77, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 35);
            this.label1.TabIndex = 404;
            this.label1.Text = "BODEGA";
            // 
            // pbxIcono
            // 
            this.pbxIcono.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcono.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxIcono.BackgroundImage")));
            this.pbxIcono.Image = ((System.Drawing.Image)(resources.GetObject("pbxIcono.Image")));
            this.pbxIcono.Location = new System.Drawing.Point(12, 3);
            this.pbxIcono.Name = "pbxIcono";
            this.pbxIcono.Size = new System.Drawing.Size(49, 46);
            this.pbxIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxIcono.TabIndex = 610;
            this.pbxIcono.TabStop = false;
            // 
            // pnlVentas
            // 
            this.pnlVentas.Controls.Add(this.mireporteventas);
            this.pnlVentas.Controls.Add(this.Panel4);
            this.pnlVentas.Controls.Add(this.flowOpcionesVentas);
            this.pnlVentas.Location = new System.Drawing.Point(454, 25);
            this.pnlVentas.Margin = new System.Windows.Forms.Padding(4);
            this.pnlVentas.Name = "pnlVentas";
            this.pnlVentas.Size = new System.Drawing.Size(827, 342);
            this.pnlVentas.TabIndex = 405;
            // 
            // mireporteventas
            // 
            this.mireporteventas.AccessibilityKeyMap = null;
            this.mireporteventas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.mireporteventas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mireporteventas.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.mireporteventas.Location = new System.Drawing.Point(0, 194);
            this.mireporteventas.Name = "mireporteventas";
            this.mireporteventas.Size = new System.Drawing.Size(827, 148);
            this.mireporteventas.TabIndex = 2;
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.PanelEmpleado);
            this.Panel4.Controls.Add(this.btnHoy);
            this.Panel4.Controls.Add(this.checkFiltros);
            this.Panel4.Controls.Add(this.pnlFiltros);
            this.Panel4.Controls.Add(this.MenuStrip6);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(0, 60);
            this.Panel4.Margin = new System.Windows.Forms.Padding(4);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(827, 134);
            this.Panel4.TabIndex = 1;
            // 
            // PanelEmpleado
            // 
            this.PanelEmpleado.Controls.Add(this.cbxEmpleado);
            this.PanelEmpleado.Controls.Add(this.Label4);
            this.PanelEmpleado.Location = new System.Drawing.Point(6, 72);
            this.PanelEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.PanelEmpleado.Name = "PanelEmpleado";
            this.PanelEmpleado.Size = new System.Drawing.Size(491, 51);
            this.PanelEmpleado.TabIndex = 616;
            this.PanelEmpleado.Visible = false;
            // 
            // cbxEmpleado
            // 
            this.cbxEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbxEmpleado.Font = new System.Drawing.Font("Consolas", 14F);
            this.cbxEmpleado.FormattingEnabled = true;
            this.cbxEmpleado.Location = new System.Drawing.Point(112, 9);
            this.cbxEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.cbxEmpleado.Name = "cbxEmpleado";
            this.cbxEmpleado.Size = new System.Drawing.Size(376, 30);
            this.cbxEmpleado.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Consolas", 14F);
            this.Label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label4.Location = new System.Drawing.Point(4, 13);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(100, 22);
            this.Label4.TabIndex = 2;
            this.Label4.Text = "Empleado:";
            // 
            // btnHoy
            // 
            this.btnHoy.BackColor = System.Drawing.Color.Transparent;
            this.btnHoy.FlatAppearance.BorderSize = 0;
            this.btnHoy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoy.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoy.ForeColor = System.Drawing.Color.DimGray;
            this.btnHoy.Location = new System.Drawing.Point(14, 16);
            this.btnHoy.Margin = new System.Windows.Forms.Padding(4);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(155, 41);
            this.btnHoy.TabIndex = 615;
            this.btnHoy.Text = "Hasta HOY";
            this.btnHoy.UseVisualStyleBackColor = false;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // checkFiltros
            // 
            this.checkFiltros.AutoSize = true;
            this.checkFiltros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.checkFiltros.Location = new System.Drawing.Point(183, 36);
            this.checkFiltros.Margin = new System.Windows.Forms.Padding(4);
            this.checkFiltros.Name = "checkFiltros";
            this.checkFiltros.Size = new System.Drawing.Size(15, 14);
            this.checkFiltros.TabIndex = 613;
            this.checkFiltros.UseVisualStyleBackColor = true;
            this.checkFiltros.CheckedChanged += new System.EventHandler(this.checkFiltros_CheckedChanged);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.dateHasta);
            this.pnlFiltros.Controls.Add(this.dateDesde);
            this.pnlFiltros.Controls.Add(this.Label2);
            this.pnlFiltros.Controls.Add(this.Label3);
            this.pnlFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.pnlFiltros.Location = new System.Drawing.Point(313, 15);
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(469, 51);
            this.pnlFiltros.TabIndex = 611;
            this.pnlFiltros.Visible = false;
            // 
            // dateHasta
            // 
            this.dateHasta.CustomFormat = "yyyy-MM-dd";
            this.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHasta.Location = new System.Drawing.Point(309, 10);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(119, 29);
            this.dateHasta.TabIndex = 3;
            this.dateHasta.ValueChanged += new System.EventHandler(this.dateHasta_ValueChanged);
            // 
            // dateDesde
            // 
            this.dateDesde.CustomFormat = "yyyy-MM-dd";
            this.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDesde.Location = new System.Drawing.Point(90, 10);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(119, 29);
            this.dateDesde.TabIndex = 2;
            this.dateDesde.ValueChanged += new System.EventHandler(this.dateDesde_ValueChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.Label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.Label2.Location = new System.Drawing.Point(233, 14);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(70, 22);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Hasta:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.Label3.Location = new System.Drawing.Point(13, 14);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(70, 22);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Desde:";
            // 
            // MenuStrip6
            // 
            this.MenuStrip6.AutoSize = false;
            this.MenuStrip6.BackColor = System.Drawing.Color.Transparent;
            this.MenuStrip6.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFiltros});
            this.MenuStrip6.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuStrip6.Location = new System.Drawing.Point(192, 25);
            this.MenuStrip6.Name = "MenuStrip6";
            this.MenuStrip6.ShowItemToolTips = true;
            this.MenuStrip6.Size = new System.Drawing.Size(121, 32);
            this.MenuStrip6.TabIndex = 612;
            this.MenuStrip6.Text = "MenuStrip6";
            // 
            // btnFiltros
            // 
            this.btnFiltros.BackColor = System.Drawing.Color.Transparent;
            this.btnFiltros.Checked = true;
            this.btnFiltros.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnFiltros.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.btnFiltros.ForeColor = System.Drawing.Color.DimGray;
            this.btnFiltros.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltros.Image")));
            this.btnFiltros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltros.Name = "btnFiltros";
            this.btnFiltros.Size = new System.Drawing.Size(108, 28);
            this.btnFiltros.Text = "Filtros";
            this.btnFiltros.Click += new System.EventHandler(this.btnFiltros_Click);
            // 
            // flowOpcionesVentas
            // 
            this.flowOpcionesVentas.AutoScroll = true;
            this.flowOpcionesVentas.Controls.Add(this.Panel2);
            this.flowOpcionesVentas.Controls.Add(this.Panel3);
            this.flowOpcionesVentas.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowOpcionesVentas.Location = new System.Drawing.Point(0, 0);
            this.flowOpcionesVentas.Margin = new System.Windows.Forms.Padding(4);
            this.flowOpcionesVentas.Name = "flowOpcionesVentas";
            this.flowOpcionesVentas.Size = new System.Drawing.Size(827, 60);
            this.flowOpcionesVentas.TabIndex = 0;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.btnResumenVentas);
            this.Panel2.Controls.Add(this.PResumenVentas);
            this.Panel2.Location = new System.Drawing.Point(4, 4);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(240, 48);
            this.Panel2.TabIndex = 405;
            // 
            // btnResumenVentas
            // 
            this.btnResumenVentas.BackColor = System.Drawing.Color.Transparent;
            this.btnResumenVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResumenVentas.FlatAppearance.BorderSize = 0;
            this.btnResumenVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResumenVentas.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResumenVentas.ForeColor = System.Drawing.Color.DimGray;
            this.btnResumenVentas.Location = new System.Drawing.Point(0, 0);
            this.btnResumenVentas.Margin = new System.Windows.Forms.Padding(4);
            this.btnResumenVentas.Name = "btnResumenVentas";
            this.btnResumenVentas.Size = new System.Drawing.Size(240, 44);
            this.btnResumenVentas.TabIndex = 614;
            this.btnResumenVentas.Text = "Resumen de Ventas";
            this.btnResumenVentas.UseVisualStyleBackColor = false;
            // 
            // PResumenVentas
            // 
            this.PResumenVentas.BackColor = System.Drawing.Color.OrangeRed;
            this.PResumenVentas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PResumenVentas.ForeColor = System.Drawing.Color.OrangeRed;
            this.PResumenVentas.Location = new System.Drawing.Point(0, 44);
            this.PResumenVentas.Margin = new System.Windows.Forms.Padding(4);
            this.PResumenVentas.Name = "PResumenVentas";
            this.PResumenVentas.Size = new System.Drawing.Size(240, 4);
            this.PResumenVentas.TabIndex = 0;
            this.PResumenVentas.Visible = false;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.btnEmpleado);
            this.Panel3.Controls.Add(this.PVentasPorempleado);
            this.Panel3.Location = new System.Drawing.Point(252, 4);
            this.Panel3.Margin = new System.Windows.Forms.Padding(4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(287, 48);
            this.Panel3.TabIndex = 618;
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.btnEmpleado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEmpleado.FlatAppearance.BorderSize = 0;
            this.btnEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleado.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleado.ForeColor = System.Drawing.Color.DimGray;
            this.btnEmpleado.Location = new System.Drawing.Point(0, 0);
            this.btnEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(287, 44);
            this.btnEmpleado.TabIndex = 615;
            this.btnEmpleado.Text = "Ventas por Empleado";
            this.btnEmpleado.UseVisualStyleBackColor = false;
            // 
            // PVentasPorempleado
            // 
            this.PVentasPorempleado.BackColor = System.Drawing.Color.OrangeRed;
            this.PVentasPorempleado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PVentasPorempleado.Location = new System.Drawing.Point(0, 44);
            this.PVentasPorempleado.Margin = new System.Windows.Forms.Padding(4);
            this.PVentasPorempleado.Name = "PVentasPorempleado";
            this.PVentasPorempleado.Size = new System.Drawing.Size(287, 4);
            this.PVentasPorempleado.TabIndex = 0;
            this.PVentasPorempleado.Visible = false;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Font = new System.Drawing.Font("Consolas", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.Gray;
            this.lblBienvenida.Location = new System.Drawing.Point(278, 51);
            this.lblBienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(124, 131);
            this.lblBienvenida.TabIndex = 406;
            this.lblBienvenida.Text = "Seleccione un Grupo de Reportes para Empezar";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(352, 259);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(415, 261);
            this.chart1.TabIndex = 407;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(821, 259);
            this.chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(415, 261);
            this.chart2.TabIndex = 408;
            this.chart2.Text = "chart2";
            this.chart2.Visible = false;
            // 
            // formReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 543);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.pnlVentas);
            this.Controls.Add(this.pnlTipoReporte);
            this.Name = "formReportes";
            this.Text = "formReportes";
            this.Load += new System.EventHandler(this.formReportes_Load);
            this.pnlTipoReporte.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcono)).EndInit();
            this.pnlVentas.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.PanelEmpleado.ResumeLayout(false);
            this.PanelEmpleado.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.MenuStrip6.ResumeLayout(false);
            this.MenuStrip6.PerformLayout();
            this.flowOpcionesVentas.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel pnlTipoReporte;
        internal System.Windows.Forms.Button btnProductos;
        internal System.Windows.Forms.Button btnPagar;
        internal System.Windows.Forms.Button btnCobrar;
        internal System.Windows.Forms.Button btnVentas;
        internal System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.PictureBox pbxIcono;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Panel pnlVentas;
        internal Telerik.ReportViewer.WinForms.ReportViewer mireporteventas;
        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Panel PanelEmpleado;
        internal System.Windows.Forms.ComboBox cbxEmpleado;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnHoy;
        internal System.Windows.Forms.CheckBox checkFiltros;
        internal System.Windows.Forms.Panel pnlFiltros;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.MenuStrip MenuStrip6;
        internal System.Windows.Forms.ToolStripMenuItem btnFiltros;
        internal System.Windows.Forms.FlowLayoutPanel flowOpcionesVentas;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Button btnResumenVentas;
        internal System.Windows.Forms.Panel PResumenVentas;
        internal System.Windows.Forms.Panel Panel3;
        internal System.Windows.Forms.Button btnEmpleado;
        internal System.Windows.Forms.Panel PVentasPorempleado;
        internal System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}