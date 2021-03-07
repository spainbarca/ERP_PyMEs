
namespace BodegaMartinez.VISTAS.COPIAS_SEGURIDAD
{
    partial class formCopiasSeguridad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCopiasSeguridad));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Label6 = new System.Windows.Forms.Label();
            this.lblfrecuencia = new System.Windows.Forms.ComboBox();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblRuta = new System.Windows.Forms.Label();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRuta = new System.Windows.Forms.ToolStripButton();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pbxLoading = new System.Windows.Forms.PictureBox();
            this.lbldirectorio = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ToolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 53);
            this.panel1.TabIndex = 608;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Old English Text MT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 32);
            this.label2.TabIndex = 604;
            this.label2.Text = "Copias de Seguridad";
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Font = new System.Drawing.Font("Ravie", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(574, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(60, 53);
            this.btnCerrar.TabIndex = 603;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnGenerar);
            this.panel2.Controls.Add(this.Label6);
            this.panel2.Controls.Add(this.lblfrecuencia);
            this.panel2.Controls.Add(this.txtRuta);
            this.panel2.Controls.Add(this.Label3);
            this.panel2.Controls.Add(this.Label4);
            this.panel2.Controls.Add(this.lblRuta);
            this.panel2.Controls.Add(this.ToolStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 278);
            this.panel2.TabIndex = 615;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Label6.Location = new System.Drawing.Point(406, 184);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(48, 20);
            this.Label6.TabIndex = 597;
            this.Label6.Text = "dia(s)";
            this.Label6.Visible = false;
            // 
            // lblfrecuencia
            // 
            this.lblfrecuencia.BackColor = System.Drawing.Color.White;
            this.lblfrecuencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblfrecuencia.FormattingEnabled = true;
            this.lblfrecuencia.Items.AddRange(new object[] {
            "1",
            "7",
            "15",
            "30"});
            this.lblfrecuencia.Location = new System.Drawing.Point(353, 180);
            this.lblfrecuencia.Name = "lblfrecuencia";
            this.lblfrecuencia.Size = new System.Drawing.Size(47, 28);
            this.lblfrecuencia.TabIndex = 596;
            this.lblfrecuencia.Visible = false;
            // 
            // txtRuta
            // 
            this.txtRuta.BackColor = System.Drawing.Color.White;
            this.txtRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtRuta.Enabled = false;
            this.txtRuta.Font = new System.Drawing.Font("Berlin Sans FB Demi", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuta.Location = new System.Drawing.Point(53, 69);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(555, 24);
            this.txtRuta.TabIndex = 1;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.White;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Label3.Location = new System.Drawing.Point(27, 111);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(424, 51);
            this.Label3.TabIndex = 0;
            this.Label3.Text = "Guarda copias de Seguridad de la base de datos para no perder \r\nningun Dato de tu" +
    " Empresa. Podras recuperar toda la Informacion\r\nen caso Tu PC tenga algun proble" +
    "ma";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.White;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.Label4.Location = new System.Drawing.Point(26, 180);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(329, 24);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Generar copias Automaticas cada:";
            this.Label4.Visible = false;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.BackColor = System.Drawing.Color.White;
            this.lblRuta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblRuta.Location = new System.Drawing.Point(61, 27);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(284, 24);
            this.lblRuta.TabIndex = 0;
            this.lblRuta.Text = "Ruta de Copias de Seguridad";
            this.lblRuta.Click += new System.EventHandler(this.lblRuta_Click);
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.BackColor = System.Drawing.Color.White;
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRuta});
            this.ToolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ToolStrip1.Location = new System.Drawing.Point(9, 2);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip1.Size = new System.Drawing.Size(72, 49);
            this.ToolStrip1.TabIndex = 595;
            this.ToolStrip1.Text = "ToolStrip1";
            // 
            // btnRuta
            // 
            this.btnRuta.BackColor = System.Drawing.Color.White;
            this.btnRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnRuta.ForeColor = System.Drawing.Color.Black;
            this.btnRuta.Image = ((System.Drawing.Image)(resources.GetObject("btnRuta.Image")));
            this.btnRuta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRuta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRuta.Name = "btnRuta";
            this.btnRuta.Size = new System.Drawing.Size(37, 46);
            this.btnRuta.Text = "+";
            this.btnRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRuta.ToolTipText = "Buscar Ruta";
            this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGenerar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerar.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(0, 228);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(634, 50);
            this.btnGenerar.TabIndex = 606;
            this.btnGenerar.Text = "Generar Copia ahora mismo";
            this.btnGenerar.UseVisualStyleBackColor = false;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2750;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.pbxLoading);
            this.panel3.Controls.Add(this.lbldirectorio);
            this.panel3.Controls.Add(this.lblfecha);
            this.panel3.Controls.Add(this.Label5);
            this.panel3.Controls.Add(this.Label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 331);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(634, 112);
            this.panel3.TabIndex = 616;
            // 
            // pbxLoading
            // 
            this.pbxLoading.Image = ((System.Drawing.Image)(resources.GetObject("pbxLoading.Image")));
            this.pbxLoading.Location = new System.Drawing.Point(0, -32);
            this.pbxLoading.Name = "pbxLoading";
            this.pbxLoading.Size = new System.Drawing.Size(634, 200);
            this.pbxLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLoading.TabIndex = 613;
            this.pbxLoading.TabStop = false;
            this.pbxLoading.Visible = false;
            // 
            // lbldirectorio
            // 
            this.lbldirectorio.BackColor = System.Drawing.Color.White;
            this.lbldirectorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbldirectorio.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldirectorio.ForeColor = System.Drawing.Color.DimGray;
            this.lbldirectorio.Location = new System.Drawing.Point(14, 31);
            this.lbldirectorio.Name = "lbldirectorio";
            this.lbldirectorio.Size = new System.Drawing.Size(425, 59);
            this.lbldirectorio.TabIndex = 1;
            this.lbldirectorio.Text = "-";
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.BackColor = System.Drawing.Color.White;
            this.lblfecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblfecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.lblfecha.ForeColor = System.Drawing.Color.DimGray;
            this.lblfecha.Location = new System.Drawing.Point(14, 110);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(47, 13);
            this.lblfecha.TabIndex = 0;
            this.lblfecha.Text = "Ninguna";
            this.lblfecha.Visible = false;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.White;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Label5.ForeColor = System.Drawing.Color.DimGray;
            this.Label5.Location = new System.Drawing.Point(14, 86);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(33, 13);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "Local";
            this.Label5.Visible = false;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.White;
            this.Label7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.Label7.Location = new System.Drawing.Point(12, 62);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(127, 24);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "Ultima Copia";
            this.Label7.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(461, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 607;
            this.pictureBox1.TabStop = false;
            // 
            // formCopiasSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 443);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formCopiasSeguridad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formCopiasSeguridad";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCerrar;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox lblfrecuencia;
        internal System.Windows.Forms.TextBox txtRuta;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label lblRuta;
        internal System.Windows.Forms.ToolStrip ToolStrip1;
        internal System.Windows.Forms.ToolStripButton btnRuta;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.PictureBox pbxLoading;
        internal System.Windows.Forms.Label lbldirectorio;
        internal System.Windows.Forms.Label lblfecha;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label7;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}