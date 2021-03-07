namespace BodegaMartinez.PRODUCTOS
{
    partial class formAlmacen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAlmacen));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateReg = new System.Windows.Forms.DateTimePicker();
            this.gridProductos = new System.Windows.Forms.DataGridView();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblActual = new System.Windows.Forms.Label();
            this.gridAlmacen = new System.Windows.Forms.DataGridView();
            this.lblIdProd = new System.Windows.Forms.Label();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richMotivo = new System.Windows.Forms.RichTextBox();
            this.txtBuscarProd = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.btnClean = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnProcesar = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlFoto = new System.Windows.Forms.Panel();
            this.pbxProd = new System.Windows.Forms.PictureBox();
            this.lblProd = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlmacen)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FloralWhite;
            this.panel1.Controls.Add(this.gridProductos);
            this.panel1.Controls.Add(this.txtCantidad);
            this.panel1.Controls.Add(this.pnlFoto);
            this.panel1.Controls.Add(this.btnClean);
            this.panel1.Controls.Add(this.btnProcesar);
            this.panel1.Controls.Add(this.dateReg);
            this.panel1.Controls.Add(this.cbxTipo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblActual);
            this.panel1.Controls.Add(this.gridAlmacen);
            this.panel1.Controls.Add(this.lblIdProd);
            this.panel1.Controls.Add(this.lblAlmacen);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.richMotivo);
            this.panel1.Controls.Add(this.txtBuscarProd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 54);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 598);
            this.panel1.TabIndex = 5;
            // 
            // dateReg
            // 
            this.dateReg.CustomFormat = "yyyy-MM-dd ";
            this.dateReg.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateReg.Location = new System.Drawing.Point(572, 50);
            this.dateReg.Name = "dateReg";
            this.dateReg.Size = new System.Drawing.Size(59, 20);
            this.dateReg.TabIndex = 623;
            // 
            // gridProductos
            // 
            this.gridProductos.AllowUserToAddRows = false;
            this.gridProductos.AllowUserToDeleteRows = false;
            this.gridProductos.AllowUserToResizeColumns = false;
            this.gridProductos.AllowUserToResizeRows = false;
            this.gridProductos.BackgroundColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gridProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProductos.ColumnHeadersVisible = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkOliveGreen;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridProductos.DefaultCellStyle = dataGridViewCellStyle11;
            this.gridProductos.Location = new System.Drawing.Point(24, 70);
            this.gridProductos.MultiSelect = false;
            this.gridProductos.Name = "gridProductos";
            this.gridProductos.RowHeadersVisible = false;
            this.gridProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProductos.Size = new System.Drawing.Size(506, 103);
            this.gridProductos.TabIndex = 613;
            this.gridProductos.Visible = false;
            this.gridProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProductos_CellClick);
            // 
            // cbxTipo
            // 
            this.cbxTipo.BackColor = System.Drawing.Color.LawnGreen;
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Seleccione:",
            "Ventas",
            "Retiro"});
            this.cbxTipo.Location = new System.Drawing.Point(162, 213);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(174, 26);
            this.cbxTipo.TabIndex = 622;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 18);
            this.label4.TabIndex = 621;
            this.label4.Text = "Movimiento:";
            // 
            // lblActual
            // 
            this.lblActual.AutoSize = true;
            this.lblActual.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActual.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblActual.Location = new System.Drawing.Point(177, 87);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(75, 34);
            this.lblActual.TabIndex = 620;
            this.lblActual.Text = "$ven";
            this.lblActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridAlmacen
            // 
            this.gridAlmacen.AllowUserToAddRows = false;
            this.gridAlmacen.AllowUserToDeleteRows = false;
            this.gridAlmacen.AllowUserToResizeColumns = false;
            this.gridAlmacen.AllowUserToResizeRows = false;
            this.gridAlmacen.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridAlmacen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAlmacen.DefaultCellStyle = dataGridViewCellStyle12;
            this.gridAlmacen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gridAlmacen.Location = new System.Drawing.Point(0, 389);
            this.gridAlmacen.Name = "gridAlmacen";
            this.gridAlmacen.ReadOnly = true;
            this.gridAlmacen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAlmacen.Size = new System.Drawing.Size(656, 209);
            this.gridAlmacen.TabIndex = 619;
            // 
            // lblIdProd
            // 
            this.lblIdProd.AutoSize = true;
            this.lblIdProd.Location = new System.Drawing.Point(455, 9);
            this.lblIdProd.Name = "lblIdProd";
            this.lblIdProd.Size = new System.Drawing.Size(35, 13);
            this.lblIdProd.TabIndex = 618;
            this.lblIdProd.Text = "label9";
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(21, 280);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(35, 13);
            this.lblAlmacen.TabIndex = 617;
            this.lblAlmacen.Text = "label9";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(21, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "Cantidad actual:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(82, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Motivo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cantidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Buscar producto:";
            // 
            // richMotivo
            // 
            this.richMotivo.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richMotivo.Location = new System.Drawing.Point(162, 264);
            this.richMotivo.Name = "richMotivo";
            this.richMotivo.Size = new System.Drawing.Size(304, 40);
            this.richMotivo.TabIndex = 6;
            this.richMotivo.Text = "";
            // 
            // txtBuscarProd
            // 
            this.txtBuscarProd.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProd.Location = new System.Drawing.Point(24, 40);
            this.txtBuscarProd.Multiline = true;
            this.txtBuscarProd.Name = "txtBuscarProd";
            this.txtBuscarProd.Size = new System.Drawing.Size(506, 30);
            this.txtBuscarProd.TabIndex = 0;
            this.txtBuscarProd.TextChanged += new System.EventHandler(this.txtBuscarProd_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(656, 54);
            this.panel2.TabIndex = 4;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Font = new System.Drawing.Font("Ravie", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(596, 0);
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
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "ALMACEN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel2;
            this.bunifuDragControl1.Vertical = true;
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
            this.btnClean.Location = new System.Drawing.Point(68, 332);
            this.btnClean.Name = "btnClean";
            this.btnClean.Normalcolor = System.Drawing.Color.IndianRed;
            this.btnClean.OnHovercolor = System.Drawing.Color.Red;
            this.btnClean.OnHoverTextColor = System.Drawing.Color.White;
            this.btnClean.selected = false;
            this.btnClean.Size = new System.Drawing.Size(152, 40);
            this.btnClean.TabIndex = 625;
            this.btnClean.Text = "Limpiar";
            this.btnClean.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClean.Textcolor = System.Drawing.Color.White;
            this.btnClean.TextFont = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnProcesar
            // 
            this.btnProcesar.Activecolor = System.Drawing.Color.Gainsboro;
            this.btnProcesar.BackColor = System.Drawing.SystemColors.InfoText;
            this.btnProcesar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnProcesar.BorderRadius = 0;
            this.btnProcesar.ButtonText = "PROCESAR MOVIMIENTO";
            this.btnProcesar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesar.DisabledColor = System.Drawing.Color.Gray;
            this.btnProcesar.Iconcolor = System.Drawing.Color.Transparent;
            this.btnProcesar.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnProcesar.Iconimage")));
            this.btnProcesar.Iconimage_right = null;
            this.btnProcesar.Iconimage_right_Selected = null;
            this.btnProcesar.Iconimage_Selected = null;
            this.btnProcesar.IconMarginLeft = 0;
            this.btnProcesar.IconMarginRight = 0;
            this.btnProcesar.IconRightVisible = true;
            this.btnProcesar.IconRightZoom = 0D;
            this.btnProcesar.IconVisible = true;
            this.btnProcesar.IconZoom = 50D;
            this.btnProcesar.IsTab = false;
            this.btnProcesar.Location = new System.Drawing.Point(293, 332);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Normalcolor = System.Drawing.SystemColors.InfoText;
            this.btnProcesar.OnHovercolor = System.Drawing.Color.DarkGray;
            this.btnProcesar.OnHoverTextColor = System.Drawing.Color.White;
            this.btnProcesar.selected = false;
            this.btnProcesar.Size = new System.Drawing.Size(307, 40);
            this.btnProcesar.TabIndex = 624;
            this.btnProcesar.Text = "PROCESAR MOVIMIENTO";
            this.btnProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnProcesar.Textcolor = System.Drawing.Color.White;
            this.btnProcesar.TextFont = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // pnlFoto
            // 
            this.pnlFoto.Controls.Add(this.pbxProd);
            this.pnlFoto.Controls.Add(this.lblProd);
            this.pnlFoto.Location = new System.Drawing.Point(491, 110);
            this.pnlFoto.Name = "pnlFoto";
            this.pnlFoto.Size = new System.Drawing.Size(138, 145);
            this.pnlFoto.TabIndex = 626;
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
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Font = new System.Drawing.Font("Berlin Sans FB Demi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(162, 147);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(110, 31);
            this.txtCantidad.TabIndex = 627;
            this.txtCantidad.ValueChanged += new System.EventHandler(this.txtCantidad_ValueChanged);
            // 
            // formAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(656, 652);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAlmacen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formAlmacen";
            this.Load += new System.EventHandler(this.formAlmacen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlmacen)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pnlFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView gridAlmacen;
        private System.Windows.Forms.Label lblIdProd;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.DataGridView gridProductos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richMotivo;
        private System.Windows.Forms.TextBox txtBuscarProd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblActual;
        private System.Windows.Forms.DateTimePicker dateReg;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Button btnCerrar;
        private Bunifu.Framework.UI.BunifuFlatButton btnClean;
        private Bunifu.Framework.UI.BunifuFlatButton btnProcesar;
        private System.Windows.Forms.Panel pnlFoto;
        private System.Windows.Forms.PictureBox pbxProd;
        internal System.Windows.Forms.Label lblProd;
        private System.Windows.Forms.NumericUpDown txtCantidad;
    }
}