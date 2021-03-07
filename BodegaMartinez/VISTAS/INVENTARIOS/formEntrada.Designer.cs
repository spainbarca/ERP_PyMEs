namespace BodegaMartinez.INVENTARIOS
{
    partial class formEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEntrada));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridProductos = new System.Windows.Forms.DataGridView();
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.pbxProd = new System.Windows.Forms.PictureBox();
            this.lblProd = new System.Windows.Forms.Label();
            this.lblIdCajaSerial = new System.Windows.Forms.Label();
            this.btnClean = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNuevoProv = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.lblIdProd = new System.Windows.Forms.Label();
            this.lblActual = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateReg = new System.Windows.Forms.DateTimePicker();
            this.richMotivo = new System.Windows.Forms.RichTextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtVenta = new System.Windows.Forms.TextBox();
            this.txtBuscarProd = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.txtCantidad = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductos)).BeginInit();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProd)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Honeydew;
            this.panel1.Controls.Add(this.gridProductos);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.pnlFoto);
            this.panel1.Controls.Add(this.lblIdCajaSerial);
            this.panel1.Controls.Add(this.btnClean);
            this.panel1.Controls.Add(this.btnNuevoProv);
            this.panel1.Controls.Add(this.lblAlmacen);
            this.panel1.Controls.Add(this.lblIdProd);
            this.panel1.Controls.Add(this.lblActual);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dateReg);
            this.panel1.Controls.Add(this.richMotivo);
            this.panel1.Controls.Add(this.txtCosto);
            this.panel1.Controls.Add(this.txtVenta);
            this.panel1.Controls.Add(this.txtBuscarProd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 463);
            this.panel1.TabIndex = 0;
            // 
            // gridProductos
            // 
            this.gridProductos.AllowUserToAddRows = false;
            this.gridProductos.AllowUserToDeleteRows = false;
            this.gridProductos.AllowUserToResizeColumns = false;
            this.gridProductos.AllowUserToResizeRows = false;
            this.gridProductos.BackgroundColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProductos.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Azure;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkOliveGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridProductos.Location = new System.Drawing.Point(21, 77);
            this.gridProductos.MultiSelect = false;
            this.gridProductos.Name = "gridProductos";
            this.gridProductos.RowHeadersVisible = false;
            this.gridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProductos.Size = new System.Drawing.Size(410, 98);
            this.gridProductos.TabIndex = 612;
            this.gridProductos.Visible = false;
            this.gridProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProductos_CellClick);
            // 
            // pnlFoto
            // 
            this.pnlFoto.Controls.Add(this.pbxProd);
            this.pnlFoto.Controls.Add(this.lblProd);
            this.pnlFoto.Location = new System.Drawing.Point(333, 113);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(138, 145);
            this.pnlFoto.TabIndex = 619;
            this.pnlFoto.Visible = false;
            // 
            // pbxProd
            // 
            this.pbxProd.BackColor = System.Drawing.Color.White;
            this.pbxProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxProd.Image = ((System.Drawing.Image)(resources.GetObject("pbxProd.Image")));
            this.pbxProd.Location = new System.Drawing.Point(0, 0);
            this.pbxProd.Name = "pbxProd";
            this.pbxProd.Size = new System.Drawing.Size(138, 123);
            this.pbxProd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxProd.TabIndex = 3;
            this.pbxProd.TabStop = false;
            // 
            // lblProd
            // 
            this.lblProd.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblProd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblProd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblProd.ForeColor = System.Drawing.Color.White;
            this.lblProd.Location = new System.Drawing.Point(0, 123);
            this.lblProd.Name = "lblProd";
            this.lblProd.Size = new System.Drawing.Size(138, 22);
            this.lblProd.TabIndex = 589;
            this.lblProd.Text = "Imagen ";
            this.lblProd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblIdCajaSerial
            // 
            this.lblIdCajaSerial.AutoSize = true;
            this.lblIdCajaSerial.Location = new System.Drawing.Point(450, 438);
            this.lblIdCajaSerial.Name = "lblIdCajaSerial";
            this.lblIdCajaSerial.Size = new System.Drawing.Size(35, 13);
            this.lblIdCajaSerial.TabIndex = 2;
            this.lblIdCajaSerial.Text = "label9";
            // 
            // btnClean
            // 
            this.btnClean.Activecolor = System.Drawing.Color.MistyRose;
            this.btnClean.BackColor = System.Drawing.Color.IndianRed;
            this.btnClean.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClean.BorderRadius = 0;
            this.btnClean.ButtonText = "Limpiar";
            this.btnClean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClean.DisabledColor = System.Drawing.Color.Gray;
            this.btnClean.Iconcolor = System.Drawing.Color.Transparent;
            this.btnClean.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnClean.Iconimage")));
            this.btnClean.Iconimage_right = null;
            this.btnClean.Iconimage_right_Selected = null;
            this.btnClean.Iconimage_Selected = null;
            this.btnClean.IconMarginLeft = 0;
            this.btnClean.IconMarginRight = 0;
            this.btnClean.IconRightVisible = true;
            this.btnClean.IconRightZoom = 0D;
            this.btnClean.IconVisible = true;
            this.btnClean.IconZoom = 50D;
            this.btnClean.IsTab = false;
            this.btnClean.Location = new System.Drawing.Point(24, 395);
            this.btnClean.Name = "btnClean";
            this.btnClean.Normalcolor = System.Drawing.Color.IndianRed;
            this.btnClean.OnHovercolor = System.Drawing.Color.Red;
            this.btnClean.OnHoverTextColor = System.Drawing.Color.White;
            this.btnClean.selected = false;
            this.btnClean.Size = new System.Drawing.Size(152, 40);
            this.btnClean.TabIndex = 618;
            this.btnClean.Text = "Limpiar";
            this.btnClean.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClean.Textcolor = System.Drawing.Color.White;
            this.btnClean.TextFont = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnNuevoProv
            // 
            this.btnNuevoProv.Activecolor = System.Drawing.Color.Gainsboro;
            this.btnNuevoProv.BackColor = System.Drawing.SystemColors.InfoText;
            this.btnNuevoProv.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNuevoProv.BorderRadius = 0;
            this.btnNuevoProv.ButtonText = "PROCESAR ENTRADA";
            this.btnNuevoProv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoProv.DisabledColor = System.Drawing.Color.Gray;
            this.btnNuevoProv.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNuevoProv.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnNuevoProv.Iconimage")));
            this.btnNuevoProv.Iconimage_right = null;
            this.btnNuevoProv.Iconimage_right_Selected = null;
            this.btnNuevoProv.Iconimage_Selected = null;
            this.btnNuevoProv.IconMarginLeft = 0;
            this.btnNuevoProv.IconMarginRight = 0;
            this.btnNuevoProv.IconRightVisible = true;
            this.btnNuevoProv.IconRightZoom = 0D;
            this.btnNuevoProv.IconVisible = true;
            this.btnNuevoProv.IconZoom = 50D;
            this.btnNuevoProv.IsTab = false;
            this.btnNuevoProv.Location = new System.Drawing.Point(209, 395);
            this.btnNuevoProv.Name = "btnNuevoProv";
            this.btnNuevoProv.Normalcolor = System.Drawing.SystemColors.InfoText;
            this.btnNuevoProv.OnHovercolor = System.Drawing.Color.DarkGray;
            this.btnNuevoProv.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNuevoProv.selected = false;
            this.btnNuevoProv.Size = new System.Drawing.Size(246, 40);
            this.btnNuevoProv.TabIndex = 616;
            this.btnNuevoProv.Text = "PROCESAR ENTRADA";
            this.btnNuevoProv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNuevoProv.Textcolor = System.Drawing.Color.White;
            this.btnNuevoProv.TextFont = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoProv.Click += new System.EventHandler(this.btnNuevoProv_Click);
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(21, 179);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(35, 13);
            this.lblAlmacen.TabIndex = 615;
            this.lblAlmacen.Text = "label9";
            // 
            // lblIdProd
            // 
            this.lblIdProd.AutoSize = true;
            this.lblIdProd.Location = new System.Drawing.Point(458, 22);
            this.lblIdProd.Name = "lblIdProd";
            this.lblIdProd.Size = new System.Drawing.Size(35, 13);
            this.lblIdProd.TabIndex = 613;
            this.lblIdProd.Text = "label9";
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.Font = new System.Drawing.Font("Berlin Sans FB Demi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActual.ForeColor = System.Drawing.Color.DarkRed;
            this.lblActual.Location = new System.Drawing.Point(165, 87);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(96, 27);
            this.lblActual.TabIndex = 16;
            this.lblActual.Text = "number";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Cantidad actual:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Motivo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(170, 18);
            this.label6.TabIndex = 13;
            this.label6.Text = "Fecha de vencimiento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Precio venta:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Costo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Agregar:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Buscar producto:";
            // 
            // dateReg
            // 
            this.dateReg.CustomFormat = "yyyy-MM-dd ";
            this.dateReg.Font = new System.Drawing.Font("Berlin Sans FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateReg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateReg.Location = new System.Drawing.Point(222, 285);
            this.dateReg.Name = "dateReg";
            this.dateReg.Size = new System.Drawing.Size(209, 22);
            this.dateReg.TabIndex = 7;
            // 
            // richMotivo
            // 
            this.richMotivo.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richMotivo.Location = new System.Drawing.Point(155, 326);
            this.richMotivo.Name = "richMotivo";
            this.richMotivo.Size = new System.Drawing.Size(276, 40);
            this.richMotivo.TabIndex = 6;
            this.richMotivo.Text = "";
            // 
            // txtCosto
            // 
            this.txtCosto.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosto.Location = new System.Drawing.Point(155, 195);
            this.txtCosto.Multiline = true;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(141, 29);
            this.txtCosto.TabIndex = 4;
            // 
            // txtVenta
            // 
            this.txtVenta.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVenta.Location = new System.Drawing.Point(155, 240);
            this.txtVenta.Multiline = true;
            this.txtVenta.Name = "txtVenta";
            this.txtVenta.Size = new System.Drawing.Size(141, 28);
            this.txtVenta.TabIndex = 1;
            // 
            // txtBuscarProd
            // 
            this.txtBuscarProd.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProd.Location = new System.Drawing.Point(21, 48);
            this.txtBuscarProd.Multiline = true;
            this.txtBuscarProd.Name = "txtBuscarProd";
            this.txtBuscarProd.Size = new System.Drawing.Size(410, 30);
            this.txtBuscarProd.TabIndex = 0;
            this.txtBuscarProd.TextChanged += new System.EventHandler(this.txtBuscarProd_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGreen;
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 54);
            this.panel2.TabIndex = 1;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Font = new System.Drawing.Font("Ravie", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(437, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(60, 54);
            this.btnCerrar.TabIndex = 22;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Ravie", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "ENTRADAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel2;
            this.bunifuDragControl1.Vertical = true;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Font = new System.Drawing.Font("Berlin Sans FB Demi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(155, 144);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(110, 31);
            this.txtCantidad.TabIndex = 629;
            this.txtCantidad.ValueChanged += new System.EventHandler(this.txtCantidad_ValueChanged);
            // 
            // formEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(497, 517);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formEntrada";
            this.Load += new System.EventHandler(this.formEntrada_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductos)).EndInit();
            this.pnlFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxProd)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateReg;
        private System.Windows.Forms.RichTextBox richMotivo;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtVenta;
        private System.Windows.Forms.TextBox txtBuscarProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView gridProductos;
        private System.Windows.Forms.Label lblIdProd;
        private System.Windows.Forms.Label lblIdCajaSerial;
        private System.Windows.Forms.Label lblAlmacen;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Button btnCerrar;
        private Bunifu.Framework.UI.BunifuFlatButton btnNuevoProv;
        private Bunifu.Framework.UI.BunifuFlatButton btnClean;
        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.PictureBox pbxProd;
        internal System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.NumericUpDown txtCantidad;
    }
}