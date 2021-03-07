namespace BodegaMartinez.CAJA
{
    partial class formCierreCaja
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
            this.btnFinTurno = new System.Windows.Forms.Button();
            this.dateCierre = new System.Windows.Forms.DateTimePicker();
            this.lblSerialCierre = new System.Windows.Forms.Label();
            this.gridCierreCajas = new System.Windows.Forms.DataGridView();
            this.lblIdUsuario = new System.Windows.Forms.Label();
            this.lblIdCaja = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIngresos = new System.Windows.Forms.TextBox();
            this.txtEgresos = new System.Windows.Forms.TextBox();
            this.txtTotalReal = new System.Windows.Forms.TextBox();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridCierreCajas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinTurno
            // 
            this.btnFinTurno.BackColor = System.Drawing.Color.Red;
            this.btnFinTurno.Font = new System.Drawing.Font("Berlin Sans FB Demi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinTurno.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnFinTurno.Location = new System.Drawing.Point(621, 12);
            this.btnFinTurno.Name = "btnFinTurno";
            this.btnFinTurno.Size = new System.Drawing.Size(167, 41);
            this.btnFinTurno.TabIndex = 1;
            this.btnFinTurno.Text = "FINALIZAR TURNO";
            this.btnFinTurno.UseVisualStyleBackColor = false;
            this.btnFinTurno.Click += new System.EventHandler(this.btnFinTurno_Click);
            // 
            // dateCierre
            // 
            this.dateCierre.CustomFormat = "yyyy-MM-dd";
            this.dateCierre.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCierre.Location = new System.Drawing.Point(242, 79);
            this.dateCierre.Name = "dateCierre";
            this.dateCierre.Size = new System.Drawing.Size(236, 20);
            this.dateCierre.TabIndex = 2;
            // 
            // lblSerialCierre
            // 
            this.lblSerialCierre.AutoSize = true;
            this.lblSerialCierre.Location = new System.Drawing.Point(26, 106);
            this.lblSerialCierre.Name = "lblSerialCierre";
            this.lblSerialCierre.Size = new System.Drawing.Size(33, 13);
            this.lblSerialCierre.TabIndex = 3;
            this.lblSerialCierre.Text = "Serial";
            // 
            // gridCierreCajas
            // 
            this.gridCierreCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCierreCajas.Location = new System.Drawing.Point(29, 8);
            this.gridCierreCajas.Name = "gridCierreCajas";
            this.gridCierreCajas.Size = new System.Drawing.Size(238, 80);
            this.gridCierreCajas.TabIndex = 4;
            // 
            // lblIdUsuario
            // 
            this.lblIdUsuario.AutoSize = true;
            this.lblIdUsuario.Location = new System.Drawing.Point(14, 56);
            this.lblIdUsuario.Name = "lblIdUsuario";
            this.lblIdUsuario.Size = new System.Drawing.Size(58, 13);
            this.lblIdUsuario.TabIndex = 5;
            this.lblIdUsuario.Text = "Id_Usuario";
            // 
            // lblIdCaja
            // 
            this.lblIdCaja.AutoSize = true;
            this.lblIdCaja.Location = new System.Drawing.Point(37, 151);
            this.lblIdCaja.Name = "lblIdCaja";
            this.lblIdCaja.Size = new System.Drawing.Size(35, 13);
            this.lblIdCaja.TabIndex = 6;
            this.lblIdCaja.Text = "idcaja";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Ingresos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Egresos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total Real:";
            // 
            // txtIngresos
            // 
            this.txtIngresos.BackColor = System.Drawing.Color.Honeydew;
            this.txtIngresos.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIngresos.Location = new System.Drawing.Point(98, 152);
            this.txtIngresos.Multiline = true;
            this.txtIngresos.Name = "txtIngresos";
            this.txtIngresos.Size = new System.Drawing.Size(167, 29);
            this.txtIngresos.TabIndex = 10;
            // 
            // txtEgresos
            // 
            this.txtEgresos.BackColor = System.Drawing.Color.SeaShell;
            this.txtEgresos.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEgresos.Location = new System.Drawing.Point(98, 225);
            this.txtEgresos.Multiline = true;
            this.txtEgresos.Name = "txtEgresos";
            this.txtEgresos.Size = new System.Drawing.Size(167, 29);
            this.txtEgresos.TabIndex = 11;
            // 
            // txtTotalReal
            // 
            this.txtTotalReal.BackColor = System.Drawing.Color.LightCyan;
            this.txtTotalReal.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReal.Location = new System.Drawing.Point(98, 294);
            this.txtTotalReal.Multiline = true;
            this.txtTotalReal.Name = "txtTotalReal";
            this.txtTotalReal.Size = new System.Drawing.Size(167, 29);
            this.txtTotalReal.TabIndex = 12;
            // 
            // lblSaldo
            // 
            this.lblSaldo.AutoSize = true;
            this.lblSaldo.Location = new System.Drawing.Point(26, 164);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(32, 13);
            this.lblSaldo.TabIndex = 13;
            this.lblSaldo.Text = "saldo";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(12, 13);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(157, 34);
            this.lblUsuario.TabIndex = 14;
            this.lblUsuario.Text = "nombreusu";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSaldo);
            this.panel1.Controls.Add(this.lblIdUsuario);
            this.panel1.Controls.Add(this.lblSerialCierre);
            this.panel1.Controls.Add(this.lblIdCaja);
            this.panel1.Controls.Add(this.gridCierreCajas);
            this.panel1.Location = new System.Drawing.Point(737, 337);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(30, 29);
            this.panel1.TabIndex = 15;
            // 
            // formCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtTotalReal);
            this.Controls.Add(this.txtEgresos);
            this.Controls.Add(this.txtIngresos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateCierre);
            this.Controls.Add(this.btnFinTurno);
            this.Name = "formCierreCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formCierreCaja";
            this.Load += new System.EventHandler(this.formCierreCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCierreCajas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFinTurno;
        private System.Windows.Forms.DateTimePicker dateCierre;
        private System.Windows.Forms.Label lblSerialCierre;
        private System.Windows.Forms.DataGridView gridCierreCajas;
        private System.Windows.Forms.Label lblIdUsuario;
        private System.Windows.Forms.Label lblIdCaja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIngresos;
        private System.Windows.Forms.TextBox txtEgresos;
        private System.Windows.Forms.TextBox txtTotalReal;
        private System.Windows.Forms.Label lblSaldo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel panel1;
    }
}