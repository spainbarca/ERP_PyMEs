
namespace BodegaMartinez.VISTAS.TARJETAS
{
    partial class formTarjetas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTarjetas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnlMedioPago = new UIDC.UI_Panel();
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.gridMedioPago = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbxAgregarPago = new System.Windows.Forms.PictureBox();
            this.lblIcoPago = new System.Windows.Forms.Label();
            this.lblEligePago = new System.Windows.Forms.Label();
            this.pbxPago = new System.Windows.Forms.PictureBox();
            this.txtMedioPago = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dlgPago = new System.Windows.Forms.OpenFileDialog();
            this.panel6 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLimpiar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancelar = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richDescripcionPago = new System.Windows.Forms.RichTextBox();
            this.EliPag = new System.Windows.Forms.DataGridViewImageColumn();
            this.EdiPag = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnEstado = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlMedioPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMedioPago)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAgregarPago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPago)).BeginInit();
            this.panel6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 22);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Thistle;
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 59);
            this.panel1.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Font = new System.Drawing.Font("Ravie", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(657, 0);
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
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(443, 50);
            this.label1.TabIndex = 2;
            this.label1.Text = "MEDIOS DE PAGO";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlMedioPago);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 534);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridMedioPago);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(415, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 534);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(43, 50);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(367, 58);
            this.panel4.TabIndex = 0;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // pnlMedioPago
            // 
            this.pnlMedioPago.BottomColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.pnlMedioPago.BottomTranparen = 255;
            this.pnlMedioPago.Controls.Add(this.groupBox1);
            this.pnlMedioPago.Controls.Add(this.pbxImagen);
            this.pnlMedioPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMedioPago.LeftColour = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlMedioPago.Location = new System.Drawing.Point(0, 58);
            this.pnlMedioPago.Name = "pnlMedioPago";
            this.pnlMedioPago.RightColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.pnlMedioPago.Rotate_Left = 90;
            this.pnlMedioPago.Rotate_Top = 360;
            this.pnlMedioPago.Size = new System.Drawing.Size(415, 476);
            this.pnlMedioPago.TabIndex = 1;
            this.pnlMedioPago.Text = "UIPanel";
            this.pnlMedioPago.TopColour = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pnlMedioPago.TopTranparen = 255;
            // 
            // pbxImagen
            // 
            this.pbxImagen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxImagen.BackgroundImage")));
            this.pbxImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxImagen.Image = ((System.Drawing.Image)(resources.GetObject("pbxImagen.Image")));
            this.pbxImagen.Location = new System.Drawing.Point(0, 6);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(128, 88);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagen.TabIndex = 0;
            this.pbxImagen.TabStop = false;
            // 
            // gridMedioPago
            // 
            this.gridMedioPago.AllowUserToAddRows = false;
            this.gridMedioPago.AllowUserToResizeRows = false;
            this.gridMedioPago.BackgroundColor = System.Drawing.SystemColors.Info;
            this.gridMedioPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridMedioPago.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridMedioPago.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridMedioPago.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridMedioPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EliPag,
            this.EdiPag,
            this.btnEstado});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMedioPago.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridMedioPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMedioPago.EnableHeadersVisualStyles = false;
            this.gridMedioPago.Location = new System.Drawing.Point(0, 0);
            this.gridMedioPago.Name = "gridMedioPago";
            this.gridMedioPago.ReadOnly = true;
            this.gridMedioPago.RowHeadersVisible = false;
            this.gridMedioPago.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gridMedioPago.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridMedioPago.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gridMedioPago.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.gridMedioPago.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gridMedioPago.RowTemplate.Height = 40;
            this.gridMedioPago.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMedioPago.Size = new System.Drawing.Size(302, 534);
            this.gridMedioPago.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtMedioPago);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lblIcoPago);
            this.groupBox1.Controls.Add(this.lblEligePago);
            this.groupBox1.Controls.Add(this.pbxPago);
            this.groupBox1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(341, 360);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(68, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar medio de pago";
            this.groupBox1.Visible = false;
            // 
            // pbxAgregarPago
            // 
            this.pbxAgregarPago.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxAgregarPago.BackgroundImage")));
            this.pbxAgregarPago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxAgregarPago.Location = new System.Drawing.Point(75, 4);
            this.pbxAgregarPago.Name = "pbxAgregarPago";
            this.pbxAgregarPago.Size = new System.Drawing.Size(241, 44);
            this.pbxAgregarPago.TabIndex = 0;
            this.pbxAgregarPago.TabStop = false;
            this.pbxAgregarPago.Click += new System.EventHandler(this.pbxAgregarPago_Click);
            // 
            // lblIcoPago
            // 
            this.lblIcoPago.AutoSize = true;
            this.lblIcoPago.Location = new System.Drawing.Point(331, 307);
            this.lblIcoPago.Name = "lblIcoPago";
            this.lblIcoPago.Size = new System.Drawing.Size(34, 23);
            this.lblIcoPago.TabIndex = 44;
            this.lblIcoPago.Text = "ico";
            // 
            // lblEligePago
            // 
            this.lblEligePago.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblEligePago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblEligePago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEligePago.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEligePago.Location = new System.Drawing.Point(73, 42);
            this.lblEligePago.Name = "lblEligePago";
            this.lblEligePago.Size = new System.Drawing.Size(270, 229);
            this.lblEligePago.TabIndex = 42;
            this.lblEligePago.Text = "Elige logo";
            this.lblEligePago.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEligePago.Click += new System.EventHandler(this.lblEligePago_Click);
            // 
            // pbxPago
            // 
            this.pbxPago.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbxPago.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxPago.BackgroundImage")));
            this.pbxPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxPago.Location = new System.Drawing.Point(71, 42);
            this.pbxPago.Name = "pbxPago";
            this.pbxPago.Size = new System.Drawing.Size(270, 229);
            this.pbxPago.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxPago.TabIndex = 43;
            this.pbxPago.TabStop = false;
            this.pbxPago.Click += new System.EventHandler(this.pbxPago_Click);
            // 
            // txtMedioPago
            // 
            this.txtMedioPago.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtMedioPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMedioPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedioPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMedioPago.Location = new System.Drawing.Point(68, 274);
            this.txtMedioPago.Multiline = true;
            this.txtMedioPago.Name = "txtMedioPago";
            this.txtMedioPago.Size = new System.Drawing.Size(270, 27);
            this.txtMedioPago.TabIndex = 637;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel5.Location = new System.Drawing.Point(68, 307);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(273, 3);
            this.panel5.TabIndex = 636;
            // 
            // dlgPago
            // 
            this.dlgPago.FileName = "dlgPago";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.menuStrip1);
            this.panel6.Controls.Add(this.pbxAgregarPago);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(415, 58);
            this.panel6.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar,
            this.btnEditar,
            this.btnLimpiar,
            this.btnCancelar});
            this.menuStrip1.Location = new System.Drawing.Point(3, 14);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(521, 35);
            this.menuStrip1.TabIndex = 510;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::BodegaMartinez.Properties.Resources.verde;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregar.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(134, 31);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click_1);
            // 
            // btnEditar
            // 
            this.btnEditar.BackgroundImage = global::BodegaMartinez.Properties.Resources.naranja;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditar.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(114, 31);
            this.btnEditar.Text = "Editar";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = global::BodegaMartinez.Properties.Resources.azul;
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(125, 31);
            this.btnLimpiar.Text = "Limpiar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::BodegaMartinez.Properties.Resources.negro;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 31);
            this.btnCancelar.Text = "Cancelar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richDescripcionPago);
            this.groupBox2.Location = new System.Drawing.Point(39, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 140);
            this.groupBox2.TabIndex = 638;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Descripción:";
            // 
            // richDescripcionPago
            // 
            this.richDescripcionPago.Location = new System.Drawing.Point(16, 33);
            this.richDescripcionPago.Name = "richDescripcionPago";
            this.richDescripcionPago.Size = new System.Drawing.Size(315, 95);
            this.richDescripcionPago.TabIndex = 0;
            this.richDescripcionPago.Text = "";
            // 
            // EliPag
            // 
            this.EliPag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EliPag.HeaderText = "";
            this.EliPag.Image = ((System.Drawing.Image)(resources.GetObject("EliPag.Image")));
            this.EliPag.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EliPag.Name = "EliPag";
            this.EliPag.ReadOnly = true;
            this.EliPag.Width = 35;
            // 
            // EdiPag
            // 
            this.EdiPag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EdiPag.HeaderText = "";
            this.EdiPag.Image = ((System.Drawing.Image)(resources.GetObject("EdiPag.Image")));
            this.EdiPag.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EdiPag.Name = "EdiPag";
            this.EdiPag.ReadOnly = true;
            this.EdiPag.Width = 35;
            // 
            // btnEstado
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.btnEstado.DefaultCellStyle = dataGridViewCellStyle1;
            this.btnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado.HeaderText = "Estado";
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.ReadOnly = true;
            this.btnEstado.Text = "Activado";
            this.btnEstado.UseColumnTextForButtonValue = true;
            // 
            // formTarjetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 593);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "formTarjetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formTarjetas";
            this.Load += new System.EventHandler(this.formTarjetas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnlMedioPago.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMedioPago)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxAgregarPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPago)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView gridMedioPago;
        private UIDC.UI_Panel pnlMedioPago;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbxAgregarPago;
        private System.Windows.Forms.Label lblIcoPago;
        private System.Windows.Forms.Label lblEligePago;
        private System.Windows.Forms.PictureBox pbxPago;
        public System.Windows.Forms.TextBox txtMedioPago;
        internal System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.OpenFileDialog dlgPago;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnAgregar;
        private System.Windows.Forms.ToolStripMenuItem btnEditar;
        private System.Windows.Forms.ToolStripMenuItem btnLimpiar;
        private System.Windows.Forms.ToolStripMenuItem btnCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richDescripcionPago;
        private System.Windows.Forms.DataGridViewImageColumn EliPag;
        private System.Windows.Forms.DataGridViewImageColumn EdiPag;
        private System.Windows.Forms.DataGridViewButtonColumn btnEstado;
    }
}