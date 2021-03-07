
namespace BodegaMartinez.VISTAS.CAJA
{
    partial class formNuevaCaja
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
            this.pnlRegistroCaja = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTicket = new UIDC.UI_TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxTema = new UIDC.UI_ComboBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxImpresora = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSerial = new UIDC.UI_TextBox();
            this.txtDescripcion = new UIDC.UI_TextBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.bunifuDragControl2 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlRegistroCaja.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRegistroCaja
            // 
            this.pnlRegistroCaja.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.pnlRegistroCaja.Controls.Add(this.label5);
            this.pnlRegistroCaja.Controls.Add(this.txtTicket);
            this.pnlRegistroCaja.Controls.Add(this.label4);
            this.pnlRegistroCaja.Controls.Add(this.label3);
            this.pnlRegistroCaja.Controls.Add(this.label2);
            this.pnlRegistroCaja.Controls.Add(this.cbxTema);
            this.pnlRegistroCaja.Controls.Add(this.btnRegistrar);
            this.pnlRegistroCaja.Controls.Add(this.pnlEncabezado);
            this.pnlRegistroCaja.Controls.Add(this.cbxImpresora);
            this.pnlRegistroCaja.Controls.Add(this.label7);
            this.pnlRegistroCaja.Controls.Add(this.txtSerial);
            this.pnlRegistroCaja.Controls.Add(this.txtDescripcion);
            this.pnlRegistroCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRegistroCaja.Location = new System.Drawing.Point(0, 0);
            this.pnlRegistroCaja.Name = "pnlRegistroCaja";
            this.pnlRegistroCaja.Size = new System.Drawing.Size(375, 438);
            this.pnlRegistroCaja.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(35, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 590;
            this.label5.Text = "Ticket:";
            // 
            // txtTicket
            // 
            this.txtTicket.BackColor = System.Drawing.Color.Transparent;
            this.txtTicket.BackgroundColour = System.Drawing.Color.White;
            this.txtTicket.BorderColour = System.Drawing.Color.DodgerBlue;
            this.txtTicket.BorderSize = 3;
            this.txtTicket.Enabled = false;
            this.txtTicket.Location = new System.Drawing.Point(136, 260);
            this.txtTicket.MaxLength = 32767;
            this.txtTicket.Multiline = false;
            this.txtTicket.Name = "txtTicket";
            this.txtTicket.ReadOnly = false;
            this.txtTicket.Size = new System.Drawing.Size(184, 29);
            this.txtTicket.StyleBorder = UIDC.UI_TextBox.Styles.NotBorderRounded;
            this.txtTicket.TabIndex = 589;
            this.txtTicket.Text = "No disponible";
            this.txtTicket.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTicket.TextColour = System.Drawing.Color.DodgerBlue;
            this.txtTicket.UseSystemPasswordChar = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(35, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 588;
            this.label4.Text = "Serial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(34, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 587;
            this.label3.Text = "Tema:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(34, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 586;
            this.label2.Text = "Descripción:";
            // 
            // cbxTema
            // 
            this.cbxTema.ArrowColour = System.Drawing.Color.DodgerBlue;
            this.cbxTema.BackColor = System.Drawing.Color.Transparent;
            this.cbxTema.BaseColour = System.Drawing.Color.White;
            this.cbxTema.BorderColour = System.Drawing.Color.Gray;
            this.cbxTema.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxTema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTema.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbxTema.FontColour = System.Drawing.Color.Black;
            this.cbxTema.FormattingEnabled = true;
            this.cbxTema.Items.AddRange(new object[] {
            "Claro",
            "Oscuro"});
            this.cbxTema.LineColour = System.Drawing.Color.DodgerBlue;
            this.cbxTema.Location = new System.Drawing.Point(135, 161);
            this.cbxTema.Name = "cbxTema";
            this.cbxTema.Size = new System.Drawing.Size(183, 26);
            this.cbxTema.SqaureColour = System.Drawing.Color.Gainsboro;
            this.cbxTema.SqaureHoverColour = System.Drawing.Color.Gray;
            this.cbxTema.StartIndex = 0;
            this.cbxTema.TabIndex = 585;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnRegistrar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRegistrar.Font = new System.Drawing.Font("Berlin Sans FB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.Location = new System.Drawing.Point(0, 388);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(375, 50);
            this.btnRegistrar.TabIndex = 584;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnlEncabezado.Controls.Add(this.btnCerrar);
            this.pnlEncabezado.Controls.Add(this.label1);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Location = new System.Drawing.Point(0, 0);
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(375, 50);
            this.pnlEncabezado.TabIndex = 583;
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Font = new System.Drawing.Font("Ravie", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCerrar.Location = new System.Drawing.Point(315, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(60, 50);
            this.btnCerrar.TabIndex = 21;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Ravie", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "NUEVA CAJA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbxImpresora
            // 
            this.cbxImpresora.BackColor = System.Drawing.Color.White;
            this.cbxImpresora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbxImpresora.FormattingEnabled = true;
            this.cbxImpresora.Location = new System.Drawing.Point(39, 345);
            this.cbxImpresora.Name = "cbxImpresora";
            this.cbxImpresora.Size = new System.Drawing.Size(308, 28);
            this.cbxImpresora.TabIndex = 582;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(35, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 581;
            this.label7.Text = "Impresora:";
            // 
            // txtSerial
            // 
            this.txtSerial.BackColor = System.Drawing.Color.Transparent;
            this.txtSerial.BackgroundColour = System.Drawing.Color.White;
            this.txtSerial.BorderColour = System.Drawing.Color.DodgerBlue;
            this.txtSerial.BorderSize = 3;
            this.txtSerial.Location = new System.Drawing.Point(135, 210);
            this.txtSerial.MaxLength = 32767;
            this.txtSerial.Multiline = false;
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.ReadOnly = true;
            this.txtSerial.Size = new System.Drawing.Size(184, 29);
            this.txtSerial.StyleBorder = UIDC.UI_TextBox.Styles.NotBorderRounded;
            this.txtSerial.TabIndex = 2;
            this.txtSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSerial.TextColour = System.Drawing.Color.DodgerBlue;
            this.txtSerial.UseSystemPasswordChar = false;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.txtDescripcion.BackgroundColour = System.Drawing.Color.White;
            this.txtDescripcion.BorderColour = System.Drawing.Color.DodgerBlue;
            this.txtDescripcion.BorderSize = 3;
            this.txtDescripcion.Location = new System.Drawing.Point(38, 103);
            this.txtDescripcion.MaxLength = 32767;
            this.txtDescripcion.Multiline = false;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = false;
            this.txtDescripcion.Size = new System.Drawing.Size(309, 29);
            this.txtDescripcion.StyleBorder = UIDC.UI_TextBox.Styles.NotBorderRounded;
            this.txtDescripcion.TabIndex = 0;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescripcion.TextColour = System.Drawing.Color.DodgerBlue;
            this.txtDescripcion.UseSystemPasswordChar = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.pnlEncabezado;
            this.bunifuDragControl1.Vertical = true;
            // 
            // bunifuDragControl2
            // 
            this.bunifuDragControl2.Fixed = true;
            this.bunifuDragControl2.Horizontal = true;
            this.bunifuDragControl2.TargetControl = this.label1;
            this.bunifuDragControl2.Vertical = true;
            // 
            // formNuevaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 438);
            this.Controls.Add(this.pnlRegistroCaja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formNuevaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formNuevaCaja";
            this.Load += new System.EventHandler(this.formNuevaCaja_Load);
            this.pnlRegistroCaja.ResumeLayout(false);
            this.pnlRegistroCaja.PerformLayout();
            this.pnlEncabezado.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRegistroCaja;
        internal System.Windows.Forms.ComboBox cbxImpresora;
        internal System.Windows.Forms.Label label7;
        private UIDC.UI_TextBox txtSerial;
        private UIDC.UI_TextBox txtDescripcion;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegistrar;
        internal System.Windows.Forms.Label label5;
        private UIDC.UI_TextBox txtTicket;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        private UIDC.UI_ComboBox cbxTema;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;
    }
}