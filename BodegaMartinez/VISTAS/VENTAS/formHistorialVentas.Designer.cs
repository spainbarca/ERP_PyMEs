
namespace BodegaMartinez.VISTAS.HISTORIAL_VENTAS
{
    partial class formHistorialVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formHistorialVentas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridHistorialVentas = new System.Windows.Forms.DataGridView();
            this.Boleta = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip7 = new System.Windows.Forms.MenuStrip();
            this.btnImprimir = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxImpresora = new System.Windows.Forms.ComboBox();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.Label51 = new System.Windows.Forms.Label();
            this.MenuStrip2 = new System.Windows.Forms.MenuStrip();
            this.btnHoy = new System.Windows.Forms.ToolStripMenuItem();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.Label20 = new System.Windows.Forms.Label();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rptHistorial = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHistorialVentas)).BeginInit();
            this.panel3.SuspendLayout();
            this.menuStrip7.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.MenuStrip2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1037, 59);
            this.panel1.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Font = new System.Drawing.Font("Ravie", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(977, 0);
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
            this.label1.Size = new System.Drawing.Size(596, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "HISTORIAL DE VENTAS";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridHistorialVentas);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pnlFiltros);
            this.panel2.Controls.Add(this.Label17);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(435, 569);
            this.panel2.TabIndex = 2;
            // 
            // gridHistorialVentas
            // 
            this.gridHistorialVentas.AllowUserToAddRows = false;
            this.gridHistorialVentas.AllowUserToDeleteRows = false;
            this.gridHistorialVentas.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DeepSkyBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.gridHistorialVentas.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridHistorialVentas.BackgroundColor = System.Drawing.Color.White;
            this.gridHistorialVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridHistorialVentas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridHistorialVentas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHistorialVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridHistorialVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridHistorialVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Boleta});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Berlin Sans FB Demi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SlateBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridHistorialVentas.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridHistorialVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHistorialVentas.EnableHeadersVisualStyles = false;
            this.gridHistorialVentas.Location = new System.Drawing.Point(0, 229);
            this.gridHistorialVentas.Name = "gridHistorialVentas";
            this.gridHistorialVentas.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHistorialVentas.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridHistorialVentas.RowHeadersVisible = false;
            this.gridHistorialVentas.RowHeadersWidth = 9;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            this.gridHistorialVentas.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridHistorialVentas.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gridHistorialVentas.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.gridHistorialVentas.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            this.gridHistorialVentas.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.gridHistorialVentas.RowTemplate.Height = 40;
            this.gridHistorialVentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHistorialVentas.Size = new System.Drawing.Size(435, 340);
            this.gridHistorialVentas.TabIndex = 549;
            this.gridHistorialVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHistorialVentas_CellClick);
            this.gridHistorialVentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHistorialVentas_CellDoubleClick);
            // 
            // Boleta
            // 
            this.Boleta.HeaderText = "";
            this.Boleta.Image = ((System.Drawing.Image)(resources.GetObject("Boleta.Image")));
            this.Boleta.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Boleta.Name = "Boleta";
            this.Boleta.ReadOnly = true;
            this.Boleta.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.menuStrip7);
            this.panel3.Controls.Add(this.cbxImpresora);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 173);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(435, 56);
            this.panel3.TabIndex = 548;
            // 
            // menuStrip7
            // 
            this.menuStrip7.AutoSize = false;
            this.menuStrip7.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImprimir});
            this.menuStrip7.Location = new System.Drawing.Point(315, 10);
            this.menuStrip7.Name = "menuStrip7";
            this.menuStrip7.Size = new System.Drawing.Size(117, 31);
            this.menuStrip7.TabIndex = 582;
            this.menuStrip7.Text = "menuStrip7";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.SystemColors.Info;
            this.btnImprimir.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(98, 27);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // cbxImpresora
            // 
            this.cbxImpresora.BackColor = System.Drawing.Color.White;
            this.cbxImpresora.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxImpresora.FormattingEnabled = true;
            this.cbxImpresora.Location = new System.Drawing.Point(12, 13);
            this.cbxImpresora.Name = "cbxImpresora";
            this.cbxImpresora.Size = new System.Drawing.Size(291, 25);
            this.cbxImpresora.TabIndex = 581;
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
            this.pnlFiltros.Location = new System.Drawing.Point(0, 41);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(435, 132);
            this.pnlFiltros.TabIndex = 547;
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
            this.MenuStrip2.Location = new System.Drawing.Point(286, 83);
            this.MenuStrip2.Name = "MenuStrip2";
            this.MenuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuStrip2.ShowItemToolTips = true;
            this.MenuStrip2.Size = new System.Drawing.Size(131, 37);
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
            // Label17
            // 
            this.Label17.BackColor = System.Drawing.Color.Transparent;
            this.Label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Label17.ForeColor = System.Drawing.Color.Black;
            this.Label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Label17.Location = new System.Drawing.Point(0, 0);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(435, 41);
            this.Label17.TabIndex = 542;
            this.Label17.Text = "Ventas Realizadas";
            this.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.rptHistorial);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(435, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(602, 569);
            this.panel4.TabIndex = 3;
            // 
            // rptHistorial
            // 
            this.rptHistorial.AccessibilityKeyMap = null;
            this.rptHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rptHistorial.Location = new System.Drawing.Point(0, 0);
            this.rptHistorial.Name = "rptHistorial";
            this.rptHistorial.Size = new System.Drawing.Size(602, 569);
            this.rptHistorial.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Visible = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // formHistorialVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1037, 628);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formHistorialVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formHistorialVentas";
            this.Load += new System.EventHandler(this.formHistorialVentas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHistorialVentas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.menuStrip7.ResumeLayout(false);
            this.menuStrip7.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.MenuStrip2.ResumeLayout(false);
            this.MenuStrip2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Panel pnlFiltros;
        internal System.Windows.Forms.Label Label51;
        internal System.Windows.Forms.MenuStrip MenuStrip2;
        internal System.Windows.Forms.ToolStripMenuItem btnHoy;
        internal System.Windows.Forms.DateTimePicker dateHasta;
        internal System.Windows.Forms.DateTimePicker dateDesde;
        internal System.Windows.Forms.Label Label20;
        internal System.Windows.Forms.Label Label19;
        internal System.Windows.Forms.Label Label17;
        private System.Windows.Forms.Panel panel4;
        private Telerik.ReportViewer.WinForms.ReportViewer rptHistorial;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn Boleta;
        public System.Windows.Forms.DataGridView gridHistorialVentas;
        internal System.Windows.Forms.ComboBox cbxImpresora;
        private System.Windows.Forms.MenuStrip menuStrip7;
        private System.Windows.Forms.ToolStripMenuItem btnImprimir;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}