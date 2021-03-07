
namespace BodegaMartinez.VISTAS.VENTAS
{
    partial class formVentasEspera
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formVentasEspera));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gridVentaEspera = new System.Windows.Forms.DataGridView();
            this.Eliminar = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridDetalleRestaurar = new System.Windows.Forms.DataGridView();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblIdVenta = new System.Windows.Forms.Label();
            this.lblfechadeventa = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.Label51 = new System.Windows.Forms.Label();
            this.MenuStrip2 = new System.Windows.Forms.MenuStrip();
            this.btnHoy = new System.Windows.Forms.ToolStripMenuItem();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVentaEspera)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleRestaurar)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.MenuStrip2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 59);
            this.panel1.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Font = new System.Drawing.Font("Ravie", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(843, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(60, 59);
            this.btnCerrar.TabIndex = 21;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "VENTAS EN ESPERA";
            // 
            // gridVentaEspera
            // 
            this.gridVentaEspera.AllowUserToAddRows = false;
            this.gridVentaEspera.AllowUserToDeleteRows = false;
            this.gridVentaEspera.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.gridVentaEspera.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridVentaEspera.BackgroundColor = System.Drawing.Color.White;
            this.gridVentaEspera.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridVentaEspera.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridVentaEspera.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridVentaEspera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridVentaEspera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVentaEspera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Eliminar});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridVentaEspera.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridVentaEspera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVentaEspera.EnableHeadersVisualStyles = false;
            this.gridVentaEspera.Location = new System.Drawing.Point(0, 132);
            this.gridVentaEspera.Name = "gridVentaEspera";
            this.gridVentaEspera.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridVentaEspera.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridVentaEspera.RowHeadersVisible = false;
            this.gridVentaEspera.RowHeadersWidth = 9;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            this.gridVentaEspera.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridVentaEspera.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gridVentaEspera.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gridVentaEspera.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.gridVentaEspera.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gridVentaEspera.RowTemplate.Height = 40;
            this.gridVentaEspera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVentaEspera.Size = new System.Drawing.Size(340, 399);
            this.gridVentaEspera.TabIndex = 360;
            this.gridVentaEspera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVentaEspera_CellClick);
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "";
            this.Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar.Image")));
            this.Eliminar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eliminar.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridDetalleRestaurar);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(340, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(563, 531);
            this.panel2.TabIndex = 361;
            // 
            // gridDetalleRestaurar
            // 
            this.gridDetalleRestaurar.AllowUserToAddRows = false;
            this.gridDetalleRestaurar.AllowUserToDeleteRows = false;
            this.gridDetalleRestaurar.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.gridDetalleRestaurar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.gridDetalleRestaurar.BackgroundColor = System.Drawing.Color.White;
            this.gridDetalleRestaurar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridDetalleRestaurar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridDetalleRestaurar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalleRestaurar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridDetalleRestaurar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalleRestaurar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn1});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDetalleRestaurar.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridDetalleRestaurar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetalleRestaurar.EnableHeadersVisualStyles = false;
            this.gridDetalleRestaurar.Location = new System.Drawing.Point(5, 102);
            this.gridDetalleRestaurar.Name = "gridDetalleRestaurar";
            this.gridDetalleRestaurar.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDetalleRestaurar.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridDetalleRestaurar.RowHeadersVisible = false;
            this.gridDetalleRestaurar.RowHeadersWidth = 9;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Gainsboro;
            this.gridDetalleRestaurar.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gridDetalleRestaurar.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gridDetalleRestaurar.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gridDetalleRestaurar.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.gridDetalleRestaurar.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gridDetalleRestaurar.RowTemplate.Height = 40;
            this.gridDetalleRestaurar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDetalleRestaurar.Size = new System.Drawing.Size(558, 429);
            this.gridDetalleRestaurar.TabIndex = 360;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblIdVenta);
            this.panel5.Controls.Add(this.lblfechadeventa);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(5, 53);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(558, 49);
            this.panel5.TabIndex = 1;
            // 
            // lblIdVenta
            // 
            this.lblIdVenta.AutoSize = true;
            this.lblIdVenta.Location = new System.Drawing.Point(511, 12);
            this.lblIdVenta.Name = "lblIdVenta";
            this.lblIdVenta.Size = new System.Drawing.Size(35, 13);
            this.lblIdVenta.TabIndex = 2;
            this.lblIdVenta.Text = "label3";
            // 
            // lblfechadeventa
            // 
            this.lblfechadeventa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblfechadeventa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfechadeventa.Location = new System.Drawing.Point(134, 0);
            this.lblfechadeventa.Name = "lblfechadeventa";
            this.lblfechadeventa.Size = new System.Drawing.Size(424, 49);
            this.lblfechadeventa.TabIndex = 1;
            this.lblfechadeventa.Text = "--";
            this.lblfechadeventa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 49);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha de venta:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btneliminar);
            this.panel4.Controls.Add(this.btnRestaurar);
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(5, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(558, 53);
            this.panel4.TabIndex = 0;
            // 
            // btneliminar
            // 
            this.btneliminar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btneliminar.FlatAppearance.BorderSize = 0;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneliminar.Image = global::BodegaMartinez.Properties.Resources.detener;
            this.btneliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btneliminar.Location = new System.Drawing.Point(168, 6);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(153, 47);
            this.btneliminar.TabIndex = 3;
            this.btneliminar.Text = "Eliminar venta";
            this.btneliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRestaurar.FlatAppearance.BorderSize = 0;
            this.btnRestaurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestaurar.Image = global::BodegaMartinez.Properties.Resources.jugar;
            this.btnRestaurar.Location = new System.Drawing.Point(0, 6);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(168, 47);
            this.btnRestaurar.TabIndex = 4;
            this.btnRestaurar.Text = "Restaurar venta";
            this.btnRestaurar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(558, 6);
            this.panel7.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(5, 531);
            this.panel6.TabIndex = 361;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.BackColor = System.Drawing.Color.White;
            this.pnlFiltros.Controls.Add(this.Label51);
            this.pnlFiltros.Controls.Add(this.MenuStrip2);
            this.pnlFiltros.Controls.Add(this.dateHasta);
            this.pnlFiltros.Controls.Add(this.dateDesde);
            this.pnlFiltros.Controls.Add(this.Label20);
            this.pnlFiltros.Controls.Add(this.Label19);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltros.Location = new System.Drawing.Point(0, 0);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(340, 132);
            this.pnlFiltros.TabIndex = 548;
            // 
            // Label51
            // 
            this.Label51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(63)))));
            this.Label51.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.Label51.ForeColor = System.Drawing.Color.White;
            this.Label51.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label51.Location = new System.Drawing.Point(0, 0);
            this.Label51.Name = "Label51";
            this.Label51.Size = new System.Drawing.Size(46, 132);
            this.Label51.TabIndex = 547;
            this.Label51.Text = "F\r\nI\r\nL\r\nT\r\nR\r\nO\r\nS";
            this.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuStrip2
            // 
            this.MenuStrip2.AutoSize = false;
            this.MenuStrip2.BackColor = System.Drawing.Color.Transparent;
            this.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHoy});
            this.MenuStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuStrip2.Location = new System.Drawing.Point(220, 89);
            this.MenuStrip2.Name = "MenuStrip2";
            this.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuStrip2.ShowItemToolTips = true;
            this.MenuStrip2.Size = new System.Drawing.Size(112, 37);
            this.MenuStrip2.TabIndex = 545;
            this.MenuStrip2.Text = "MenuStrip7";
            // 
            // btnHoy
            // 
            this.btnHoy.BackColor = System.Drawing.Color.Gainsboro;
            this.btnHoy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHoy.ForeColor = System.Drawing.Color.Black;
            this.btnHoy.Image = ((System.Drawing.Image)(resources.GetObject("btnHoy.Image")));
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.btnHoy.Size = new System.Drawing.Size(100, 33);
            this.btnHoy.Text = "Hoy (Todos)";
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // dateHasta
            // 
            this.dateHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateHasta.Location = new System.Drawing.Point(145, 55);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(124, 27);
            this.dateHasta.TabIndex = 543;
            this.dateHasta.ValueChanged += new System.EventHandler(this.dateHasta_ValueChanged);
            // 
            // dateDesde
            // 
            this.dateDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDesde.Location = new System.Drawing.Point(145, 15);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(124, 27);
            this.dateDesde.TabIndex = 543;
            this.dateDesde.ValueChanged += new System.EventHandler(this.dateDesde_ValueChanged);
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Label20.ForeColor = System.Drawing.Color.Black;
            this.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label20.Location = new System.Drawing.Point(66, 55);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(68, 22);
            this.Label20.TabIndex = 460;
            this.Label20.Text = "Hasta:";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.Label19.ForeColor = System.Drawing.Color.Black;
            this.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label19.Location = new System.Drawing.Point(66, 20);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(73, 22);
            this.Label19.TabIndex = 460;
            this.Label19.Text = "Desde:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridVentaEspera);
            this.panel3.Controls.Add(this.pnlFiltros);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(340, 531);
            this.panel3.TabIndex = 549;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // formVentasEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 590);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formVentasEspera";
            this.Text = "formVentasEspera";
            this.Load += new System.EventHandler(this.formVentasEspera_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVentaEspera)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalleRestaurar)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.MenuStrip2.ResumeLayout(false);
            this.MenuStrip2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.DataGridView gridVentaEspera;
        private System.Windows.Forms.DataGridViewImageColumn Eliminar;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView gridDetalleRestaurar;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblfechadeventa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        internal System.Windows.Forms.Panel pnlFiltros;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.MenuStrip MenuStrip2;
        internal System.Windows.Forms.ToolStripMenuItem btnHoy;
        internal System.Windows.Forms.DateTimePicker dateHasta;
        internal System.Windows.Forms.DateTimePicker dateDesde;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label lblIdVenta;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}