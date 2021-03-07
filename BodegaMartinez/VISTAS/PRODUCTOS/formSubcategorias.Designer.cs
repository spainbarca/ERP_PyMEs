
namespace BodegaMartinez.VISTAS.PRODUCTOS
{
    partial class formSubcategorias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formSubcategorias));
            this.pnlSubcategorias = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblIdCat = new System.Windows.Forms.Label();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.txtNombreSubcat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIdSubCat = new System.Windows.Forms.Label();
            this.txtBuscarSubCat = new System.Windows.Forms.TextBox();
            this.gridSubcategorias = new System.Windows.Forms.DataGridView();
            this.menuLimpiarSubcat = new System.Windows.Forms.MenuStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.menuAgregarSubCat = new System.Windows.Forms.MenuStrip();
            this.pnlTabulacion = new System.Windows.Forms.Panel();
            this.btnDespues = new UIDC.UI_ButtonMaterial();
            this.btnAntes = new UIDC.UI_ButtonMaterial();
            this.lblTotalPag = new System.Windows.Forms.Label();
            this.txtPagActual = new System.Windows.Forms.TextBox();
            this.btnUltima = new UIDC.UI_ButtonMaterial();
            this.btnPrimera = new UIDC.UI_ButtonMaterial();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTotalCatNombre = new System.Windows.Forms.Label();
            this.lblTotalCatNumero = new System.Windows.Forms.Label();
            this.lblHoraActual = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.EliSub = new System.Windows.Forms.DataGridViewImageColumn();
            this.EdiSub = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnVolver = new System.Windows.Forms.ToolStripMenuItem();
            this.btnElegir = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSubcategorias.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubcategorias)).BeginInit();
            this.menuLimpiarSubcat.SuspendLayout();
            this.menuAgregarSubCat.SuspendLayout();
            this.pnlTabulacion.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSubcategorias
            // 
            this.pnlSubcategorias.BackColor = System.Drawing.Color.Honeydew;
            this.pnlSubcategorias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSubcategorias.Controls.Add(this.panel3);
            this.pnlSubcategorias.Controls.Add(this.lblIdCat);
            this.pnlSubcategorias.Controls.Add(this.cbxCategoria);
            this.pnlSubcategorias.Controls.Add(this.txtNombreSubcat);
            this.pnlSubcategorias.Controls.Add(this.label1);
            this.pnlSubcategorias.Controls.Add(this.lblIdSubCat);
            this.pnlSubcategorias.Controls.Add(this.pictureBox2);
            this.pnlSubcategorias.Controls.Add(this.txtBuscarSubCat);
            this.pnlSubcategorias.Controls.Add(this.gridSubcategorias);
            this.pnlSubcategorias.Controls.Add(this.menuLimpiarSubcat);
            this.pnlSubcategorias.Controls.Add(this.label3);
            this.pnlSubcategorias.Controls.Add(this.menuAgregarSubCat);
            this.pnlSubcategorias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSubcategorias.Location = new System.Drawing.Point(0, 0);
            this.pnlSubcategorias.Name = "pnlSubcategorias";
            this.pnlSubcategorias.Size = new System.Drawing.Size(811, 466);
            this.pnlSubcategorias.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pictureBox7);
            this.panel3.Controls.Add(this.pictureBox8);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(416, 98);
            this.panel3.TabIndex = 39;
            // 
            // lblIdCat
            // 
            this.lblIdCat.AutoSize = true;
            this.lblIdCat.Location = new System.Drawing.Point(242, 195);
            this.lblIdCat.Name = "lblIdCat";
            this.lblIdCat.Size = new System.Drawing.Size(35, 13);
            this.lblIdCat.TabIndex = 38;
            this.lblIdCat.Text = "label6";
            this.lblIdCat.Click += new System.EventHandler(this.lblIdCat_Click);
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.Enabled = false;
            this.cbxCategoria.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(24, 221);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(243, 31);
            this.cbxCategoria.TabIndex = 37;
            // 
            // txtNombreSubcat
            // 
            this.txtNombreSubcat.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreSubcat.Location = new System.Drawing.Point(24, 305);
            this.txtNombreSubcat.Name = "txtNombreSubcat";
            this.txtNombreSubcat.Size = new System.Drawing.Size(243, 29);
            this.txtNombreSubcat.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 270);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 23);
            this.label1.TabIndex = 35;
            this.label1.Text = "Subcategoría:";
            // 
            // lblIdSubCat
            // 
            this.lblIdSubCat.AutoSize = true;
            this.lblIdSubCat.Location = new System.Drawing.Point(198, 195);
            this.lblIdSubCat.Name = "lblIdSubCat";
            this.lblIdSubCat.Size = new System.Drawing.Size(35, 13);
            this.lblIdSubCat.TabIndex = 34;
            this.lblIdSubCat.Text = "label1";
            this.lblIdSubCat.Click += new System.EventHandler(this.lblIdSubCat_Click);
            // 
            // txtBuscarSubCat
            // 
            this.txtBuscarSubCat.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarSubCat.Location = new System.Drawing.Point(49, 121);
            this.txtBuscarSubCat.Multiline = true;
            this.txtBuscarSubCat.Name = "txtBuscarSubCat";
            this.txtBuscarSubCat.Size = new System.Drawing.Size(367, 26);
            this.txtBuscarSubCat.TabIndex = 31;
            this.txtBuscarSubCat.TextChanged += new System.EventHandler(this.txtBuscarSubCat_TextChanged);
            // 
            // gridSubcategorias
            // 
            this.gridSubcategorias.AllowUserToAddRows = false;
            this.gridSubcategorias.AllowUserToResizeRows = false;
            this.gridSubcategorias.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.gridSubcategorias.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridSubcategorias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.gridSubcategorias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridSubcategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSubcategorias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EliSub,
            this.EdiSub});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSubcategorias.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridSubcategorias.EnableHeadersVisualStyles = false;
            this.gridSubcategorias.Location = new System.Drawing.Point(433, 10);
            this.gridSubcategorias.Name = "gridSubcategorias";
            this.gridSubcategorias.ReadOnly = true;
            this.gridSubcategorias.RowHeadersVisible = false;
            this.gridSubcategorias.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.gridSubcategorias.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSubcategorias.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.gridSubcategorias.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MediumBlue;
            this.gridSubcategorias.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.gridSubcategorias.RowTemplate.Height = 30;
            this.gridSubcategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSubcategorias.Size = new System.Drawing.Size(359, 353);
            this.gridSubcategorias.TabIndex = 30;
            this.gridSubcategorias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSubcategorias_CellClick);
            this.gridSubcategorias.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSubcategorias_CellDoubleClick);
            // 
            // menuLimpiarSubcat
            // 
            this.menuLimpiarSubcat.AutoSize = false;
            this.menuLimpiarSubcat.BackColor = System.Drawing.Color.IndianRed;
            this.menuLimpiarSubcat.Dock = System.Windows.Forms.DockStyle.None;
            this.menuLimpiarSubcat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnVolver});
            this.menuLimpiarSubcat.Location = new System.Drawing.Point(303, 281);
            this.menuLimpiarSubcat.Name = "menuLimpiarSubcat";
            this.menuLimpiarSubcat.Size = new System.Drawing.Size(107, 37);
            this.menuLimpiarSubcat.TabIndex = 29;
            this.menuLimpiarSubcat.Text = "menuStrip2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB Demi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 23);
            this.label3.TabIndex = 23;
            this.label3.Text = "Categoría:";
            // 
            // menuAgregarSubCat
            // 
            this.menuAgregarSubCat.AutoSize = false;
            this.menuAgregarSubCat.BackColor = System.Drawing.SystemColors.Desktop;
            this.menuAgregarSubCat.Dock = System.Windows.Forms.DockStyle.None;
            this.menuAgregarSubCat.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnElegir});
            this.menuAgregarSubCat.Location = new System.Drawing.Point(303, 215);
            this.menuAgregarSubCat.Name = "menuAgregarSubCat";
            this.menuAgregarSubCat.Size = new System.Drawing.Size(107, 37);
            this.menuAgregarSubCat.TabIndex = 27;
            this.menuAgregarSubCat.Text = "menuStrip1";
            // 
            // pnlTabulacion
            // 
            this.pnlTabulacion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlTabulacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlTabulacion.Controls.Add(this.btnDespues);
            this.pnlTabulacion.Controls.Add(this.btnAntes);
            this.pnlTabulacion.Controls.Add(this.lblTotalPag);
            this.pnlTabulacion.Controls.Add(this.txtPagActual);
            this.pnlTabulacion.Controls.Add(this.btnUltima);
            this.pnlTabulacion.Controls.Add(this.btnPrimera);
            this.pnlTabulacion.Controls.Add(this.label9);
            this.pnlTabulacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTabulacion.Location = new System.Drawing.Point(0, 381);
            this.pnlTabulacion.Name = "pnlTabulacion";
            this.pnlTabulacion.Size = new System.Drawing.Size(811, 50);
            this.pnlTabulacion.TabIndex = 37;
            // 
            // btnDespues
            // 
            this.btnDespues.BGColor = "#508ef5";
            this.btnDespues.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDespues.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDespues.Location = new System.Drawing.Point(455, 6);
            this.btnDespues.Name = "btnDespues";
            this.btnDespues.Size = new System.Drawing.Size(113, 34);
            this.btnDespues.TabIndex = 8;
            this.btnDespues.Text = "Siguiente";
            this.btnDespues.UIFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDespues.UIFontColor = "#ffffff";
            this.btnDespues.UseVisualStyleBackColor = true;
            this.btnDespues.Click += new System.EventHandler(this.btnDespues_Click);
            // 
            // btnAntes
            // 
            this.btnAntes.BGColor = "#508ef5";
            this.btnAntes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAntes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAntes.Location = new System.Drawing.Point(232, 8);
            this.btnAntes.Name = "btnAntes";
            this.btnAntes.Size = new System.Drawing.Size(105, 34);
            this.btnAntes.TabIndex = 7;
            this.btnAntes.Text = "Anterior";
            this.btnAntes.UIFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAntes.UIFontColor = "#ffffff";
            this.btnAntes.UseVisualStyleBackColor = true;
            this.btnAntes.Click += new System.EventHandler(this.btnAntes_Click);
            // 
            // lblTotalPag
            // 
            this.lblTotalPag.AutoSize = true;
            this.lblTotalPag.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPag.Location = new System.Drawing.Point(425, 15);
            this.lblTotalPag.Name = "lblTotalPag";
            this.lblTotalPag.Size = new System.Drawing.Size(18, 18);
            this.lblTotalPag.TabIndex = 6;
            this.lblTotalPag.Text = "0";
            // 
            // txtPagActual
            // 
            this.txtPagActual.BackColor = System.Drawing.Color.White;
            this.txtPagActual.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagActual.Location = new System.Drawing.Point(356, 13);
            this.txtPagActual.Name = "txtPagActual";
            this.txtPagActual.ReadOnly = true;
            this.txtPagActual.Size = new System.Drawing.Size(41, 26);
            this.txtPagActual.TabIndex = 5;
            this.txtPagActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUltima
            // 
            this.btnUltima.BGColor = "#508ef5";
            this.btnUltima.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUltima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltima.Location = new System.Drawing.Point(576, 7);
            this.btnUltima.Name = "btnUltima";
            this.btnUltima.Size = new System.Drawing.Size(116, 34);
            this.btnUltima.TabIndex = 4;
            this.btnUltima.Text = "Última Página";
            this.btnUltima.UIFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltima.UIFontColor = "#ffffff";
            this.btnUltima.UseVisualStyleBackColor = true;
            this.btnUltima.Click += new System.EventHandler(this.btnUltima_Click);
            // 
            // btnPrimera
            // 
            this.btnPrimera.BGColor = "#508ef5";
            this.btnPrimera.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrimera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimera.Location = new System.Drawing.Point(113, 8);
            this.btnPrimera.Name = "btnPrimera";
            this.btnPrimera.Size = new System.Drawing.Size(110, 34);
            this.btnPrimera.TabIndex = 3;
            this.btnPrimera.Text = "Primera Página";
            this.btnPrimera.UIFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimera.UIFontColor = "#ffffff";
            this.btnPrimera.UseVisualStyleBackColor = true;
            this.btnPrimera.Click += new System.EventHandler(this.btnPrimera_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(403, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 18);
            this.label9.TabIndex = 2;
            this.label9.Text = "de";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn1.Image")));
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Visible = false;
            this.dataGridViewImageColumn1.Width = 35;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Visible = false;
            this.dataGridViewImageColumn2.Width = 35;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.flowLayoutPanel1);
            this.bunifuGradientPanel1.Controls.Add(this.lblHoraActual);
            this.bunifuGradientPanel1.Controls.Add(this.label11);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.SystemColors.HotTrack;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 431);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(811, 35);
            this.bunifuGradientPanel1.TabIndex = 38;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.lblTotalCatNombre);
            this.flowLayoutPanel1.Controls.Add(this.lblTotalCatNumero);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(18, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(493, 25);
            this.flowLayoutPanel1.TabIndex = 15;
            // 
            // lblTotalCatNombre
            // 
            this.lblTotalCatNombre.AutoSize = true;
            this.lblTotalCatNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCatNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCatNombre.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalCatNombre.Location = new System.Drawing.Point(3, 0);
            this.lblTotalCatNombre.Name = "lblTotalCatNombre";
            this.lblTotalCatNombre.Size = new System.Drawing.Size(16, 24);
            this.lblTotalCatNombre.TabIndex = 9;
            this.lblTotalCatNombre.Text = "-";
            // 
            // lblTotalCatNumero
            // 
            this.lblTotalCatNumero.AutoSize = true;
            this.lblTotalCatNumero.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCatNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCatNumero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(198)))), ((int)(((byte)(91)))));
            this.lblTotalCatNumero.Location = new System.Drawing.Point(25, 0);
            this.lblTotalCatNumero.Name = "lblTotalCatNumero";
            this.lblTotalCatNumero.Size = new System.Drawing.Size(17, 24);
            this.lblTotalCatNumero.TabIndex = 10;
            this.lblTotalCatNumero.Text = "-";
            // 
            // lblHoraActual
            // 
            this.lblHoraActual.AutoSize = true;
            this.lblHoraActual.BackColor = System.Drawing.Color.Transparent;
            this.lblHoraActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblHoraActual.Location = new System.Drawing.Point(868, 5);
            this.lblHoraActual.Name = "lblHoraActual";
            this.lblHoraActual.Size = new System.Drawing.Size(54, 24);
            this.lblHoraActual.TabIndex = 14;
            this.lblHoraActual.Text = "3456";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label11.Location = new System.Drawing.Point(810, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 24);
            this.label11.TabIndex = 12;
            this.label11.Text = "Hora:";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(216, 23);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(193, 43);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 36;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(6, 4);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(204, 89);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 35;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(10, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 32;
            this.pictureBox2.TabStop = false;
            // 
            // EliSub
            // 
            this.EliSub.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EliSub.HeaderText = "";
            this.EliSub.Image = ((System.Drawing.Image)(resources.GetObject("EliSub.Image")));
            this.EliSub.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EliSub.Name = "EliSub";
            this.EliSub.ReadOnly = true;
            this.EliSub.Visible = false;
            this.EliSub.Width = 35;
            // 
            // EdiSub
            // 
            this.EdiSub.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EdiSub.HeaderText = "";
            this.EdiSub.Image = ((System.Drawing.Image)(resources.GetObject("EdiSub.Image")));
            this.EdiSub.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EdiSub.Name = "EdiSub";
            this.EdiSub.ReadOnly = true;
            this.EdiSub.Visible = false;
            this.EdiSub.Width = 35;
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(97, 33);
            this.btnVolver.Text = "Volver";
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnElegir
            // 
            this.btnElegir.Font = new System.Drawing.Font("Berlin Sans FB", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElegir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnElegir.Image = ((System.Drawing.Image)(resources.GetObject("btnElegir.Image")));
            this.btnElegir.Name = "btnElegir";
            this.btnElegir.Size = new System.Drawing.Size(93, 33);
            this.btnElegir.Text = "Elegir";
            this.btnElegir.Click += new System.EventHandler(this.btnElegir_Click);
            // 
            // formSubcategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 466);
            this.Controls.Add(this.pnlTabulacion);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Controls.Add(this.pnlSubcategorias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formSubcategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formSubcategorias";
            this.Load += new System.EventHandler(this.formSubcategorias_Load);
            this.pnlSubcategorias.ResumeLayout(false);
            this.pnlSubcategorias.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSubcategorias)).EndInit();
            this.menuLimpiarSubcat.ResumeLayout(false);
            this.menuLimpiarSubcat.PerformLayout();
            this.menuAgregarSubCat.ResumeLayout(false);
            this.menuAgregarSubCat.PerformLayout();
            this.pnlTabulacion.ResumeLayout(false);
            this.pnlTabulacion.PerformLayout();
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSubcategorias;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label lblIdCat;
        private System.Windows.Forms.ComboBox cbxCategoria;
        private System.Windows.Forms.TextBox txtNombreSubcat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIdSubCat;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtBuscarSubCat;
        private System.Windows.Forms.DataGridView gridSubcategorias;
        private System.Windows.Forms.MenuStrip menuLimpiarSubcat;
        private System.Windows.Forms.ToolStripMenuItem btnVolver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuAgregarSubCat;
        private System.Windows.Forms.ToolStripMenuItem btnElegir;
        private System.Windows.Forms.Panel pnlTabulacion;
        private UIDC.UI_ButtonMaterial btnDespues;
        private UIDC.UI_ButtonMaterial btnAntes;
        private System.Windows.Forms.Label lblTotalPag;
        private System.Windows.Forms.TextBox txtPagActual;
        private UIDC.UI_ButtonMaterial btnUltima;
        private UIDC.UI_ButtonMaterial btnPrimera;
        private System.Windows.Forms.Label label9;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Label lblTotalCatNombre;
        internal System.Windows.Forms.Label lblTotalCatNumero;
        internal System.Windows.Forms.Label lblHoraActual;
        internal System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewImageColumn EliSub;
        private System.Windows.Forms.DataGridViewImageColumn EdiSub;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
    }
}