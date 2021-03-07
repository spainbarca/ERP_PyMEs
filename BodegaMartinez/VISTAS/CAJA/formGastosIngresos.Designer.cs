
namespace BodegaMartinez.VISTAS.CAJA
{
    partial class formGastosIngresos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGastosIngresos));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbltotalIngresos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.uI_GradientPanel1 = new UIDC.UI_GradientPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbltotalGastos = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblCajaActualFecha = new System.Windows.Forms.Label();
            this.gridIngresos = new System.Windows.Forms.DataGridView();
            this.gridGastos = new System.Windows.Forms.DataGridView();
            this.EliVen = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIngresos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGastos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.uI_GradientPanel1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 492);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridIngresos);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.Label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(502, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(552, 492);
            this.panel3.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbltotalIngresos);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 431);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(552, 61);
            this.panel5.TabIndex = 373;
            // 
            // lbltotalIngresos
            // 
            this.lbltotalIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbltotalIngresos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lbltotalIngresos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbltotalIngresos.Location = new System.Drawing.Point(78, 0);
            this.lbltotalIngresos.Name = "lbltotalIngresos";
            this.lbltotalIngresos.Size = new System.Drawing.Size(474, 61);
            this.lbltotalIngresos.TabIndex = 3;
            this.lbltotalIngresos.Text = "0.00";
            this.lbltotalIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 61);
            this.label4.TabIndex = 2;
            this.label4.Text = "Total:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.Honeydew;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(552, 49);
            this.Label2.TabIndex = 371;
            this.Label2.Text = "Ingresos de caja";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uI_GradientPanel1
            // 
            this.uI_GradientPanel1.BackColor = System.Drawing.Color.White;
            this.uI_GradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.uI_GradientPanel1.Location = new System.Drawing.Point(498, 0);
            this.uI_GradientPanel1.Name = "uI_GradientPanel1";
            this.uI_GradientPanel1.Size = new System.Drawing.Size(4, 492);
            this.uI_GradientPanel1.TabIndex = 2;
            this.uI_GradientPanel1.UIBackColor = System.Drawing.Color.Empty;
            this.uI_GradientPanel1.UIBottomLeft = System.Drawing.Color.Black;
            this.uI_GradientPanel1.UIBottomRight = System.Drawing.Color.Blue;
            this.uI_GradientPanel1.UIForeColor = System.Drawing.Color.Empty;
            this.uI_GradientPanel1.UIPrimerColor = System.Drawing.Color.White;
            this.uI_GradientPanel1.UIStyle = UIDC.UI_GradientPanel.GradientStyle.Corners;
            this.uI_GradientPanel1.UITopLeft = System.Drawing.Color.DeepSkyBlue;
            this.uI_GradientPanel1.UITopRight = System.Drawing.Color.Fuchsia;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridGastos);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.Label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 492);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbltotalGastos);
            this.panel4.Controls.Add(this.Label7);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 431);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(498, 61);
            this.panel4.TabIndex = 372;
            // 
            // lbltotalGastos
            // 
            this.lbltotalGastos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbltotalGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lbltotalGastos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbltotalGastos.Location = new System.Drawing.Point(78, 0);
            this.lbltotalGastos.Name = "lbltotalGastos";
            this.lbltotalGastos.Size = new System.Drawing.Size(420, 61);
            this.lbltotalGastos.TabIndex = 3;
            this.lbltotalGastos.Text = "0.00";
            this.lbltotalGastos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label7
            // 
            this.Label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.Label7.Location = new System.Drawing.Point(0, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(78, 61);
            this.Label7.TabIndex = 2;
            this.Label7.Text = "Total:";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.LavenderBlush;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(498, 49);
            this.Label1.TabIndex = 371;
            this.Label1.Text = "Gastos de caja";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SlateGray;
            this.panel6.Controls.Add(this.lblCajaActualFecha);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.btnCerrar);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1054, 59);
            this.panel6.TabIndex = 2;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Font = new System.Drawing.Font("Ravie", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(994, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(60, 59);
            this.btnCerrar.TabIndex = 21;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Ravie", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 50);
            this.label3.TabIndex = 2;
            this.label3.Text = "CAJAS";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel6;
            this.bunifuDragControl1.Vertical = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(396, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "Última caja aperturada:";
            // 
            // lblCajaActualFecha
            // 
            this.lblCajaActualFecha.AutoSize = true;
            this.lblCajaActualFecha.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCajaActualFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblCajaActualFecha.Location = new System.Drawing.Point(618, 16);
            this.lblCajaActualFecha.Name = "lblCajaActualFecha";
            this.lblCajaActualFecha.Size = new System.Drawing.Size(216, 23);
            this.lblCajaActualFecha.TabIndex = 23;
            this.lblCajaActualFecha.Text = "Última caja aperturada:";
            // 
            // gridIngresos
            // 
            this.gridIngresos.AllowUserToAddRows = false;
            this.gridIngresos.AllowUserToDeleteRows = false;
            this.gridIngresos.AllowUserToResizeColumns = false;
            this.gridIngresos.AllowUserToResizeRows = false;
            this.gridIngresos.BackgroundColor = System.Drawing.Color.White;
            this.gridIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EliVen});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridIngresos.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridIngresos.Location = new System.Drawing.Point(0, 49);
            this.gridIngresos.Name = "gridIngresos";
            this.gridIngresos.ReadOnly = true;
            this.gridIngresos.RowHeadersVisible = false;
            this.gridIngresos.RowTemplate.Height = 30;
            this.gridIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridIngresos.Size = new System.Drawing.Size(552, 382);
            this.gridIngresos.TabIndex = 374;
            // 
            // gridGastos
            // 
            this.gridGastos.AllowUserToAddRows = false;
            this.gridGastos.AllowUserToDeleteRows = false;
            this.gridGastos.AllowUserToResizeColumns = false;
            this.gridGastos.AllowUserToResizeRows = false;
            this.gridGastos.BackgroundColor = System.Drawing.Color.White;
            this.gridGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridGastos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewImageColumn3});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PowderBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridGastos.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridGastos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridGastos.Location = new System.Drawing.Point(0, 49);
            this.gridGastos.Name = "gridGastos";
            this.gridGastos.ReadOnly = true;
            this.gridGastos.RowHeadersVisible = false;
            this.gridGastos.RowTemplate.Height = 30;
            this.gridGastos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridGastos.Size = new System.Drawing.Size(498, 382);
            this.gridGastos.TabIndex = 373;
            // 
            // EliVen
            // 
            this.EliVen.HeaderText = "";
            this.EliVen.Image = ((System.Drawing.Image)(resources.GetObject("EliVen.Image")));
            this.EliVen.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EliVen.Name = "EliVen";
            this.EliVen.ReadOnly = true;
            this.EliVen.Width = 40;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn3.Image")));
            this.dataGridViewImageColumn3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Width = 40;
            // 
            // formGastosIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 551);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formGastosIngresos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formGastosIngresos";
            this.Load += new System.EventHandler(this.formGastosIngresos_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIngresos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGastos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Label lbltotalIngresos;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label Label2;
        private UIDC.UI_GradientPanel uI_GradientPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Label lbltotalGastos;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label3;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Label lblCajaActualFecha;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DataGridView gridIngresos;
        private System.Windows.Forms.DataGridViewImageColumn EliVen;
        public System.Windows.Forms.DataGridView gridGastos;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
    }
}