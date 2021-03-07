namespace BodegaMartinez.CAJA
{
    partial class formCaja
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.btnOmitir = new System.Windows.Forms.Button();
            this.btnIniciarCaja = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblIdUsu = new System.Windows.Forms.Label();
            this.gridCajas = new System.Windows.Forms.DataGridView();
            this.lblIdCaja = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCajas)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1197, 102);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.txtSaldo);
            this.panel2.Controls.Add(this.btnOmitir);
            this.panel2.Controls.Add(this.btnIniciarCaja);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(153, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(905, 394);
            this.panel2.TabIndex = 1;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Font = new System.Drawing.Font("Berlin Sans FB", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Location = new System.Drawing.Point(73, 219);
            this.txtSaldo.Multiline = true;
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Size = new System.Drawing.Size(730, 55);
            this.txtSaldo.TabIndex = 13;
            this.txtSaldo.TextChanged += new System.EventHandler(this.txtSaldo_TextChanged);
            this.txtSaldo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaldo_KeyPress);
            // 
            // btnOmitir
            // 
            this.btnOmitir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOmitir.Font = new System.Drawing.Font("Forte", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOmitir.ForeColor = System.Drawing.Color.Black;
            this.btnOmitir.Location = new System.Drawing.Point(459, 302);
            this.btnOmitir.Name = "btnOmitir";
            this.btnOmitir.Size = new System.Drawing.Size(221, 46);
            this.btnOmitir.TabIndex = 12;
            this.btnOmitir.Text = "Omitir";
            this.btnOmitir.UseVisualStyleBackColor = false;
            this.btnOmitir.Click += new System.EventHandler(this.btnOmitir_Click);
            // 
            // btnIniciarCaja
            // 
            this.btnIniciarCaja.BackColor = System.Drawing.Color.Gold;
            this.btnIniciarCaja.Font = new System.Drawing.Font("Forte", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarCaja.ForeColor = System.Drawing.Color.Black;
            this.btnIniciarCaja.Location = new System.Drawing.Point(188, 302);
            this.btnIniciarCaja.Name = "btnIniciarCaja";
            this.btnIniciarCaja.Size = new System.Drawing.Size(221, 46);
            this.btnIniciarCaja.TabIndex = 11;
            this.btnIniciarCaja.Text = "Iniciar";
            this.btnIniciarCaja.UseVisualStyleBackColor = false;
            this.btnIniciarCaja.Click += new System.EventHandler(this.btnIniciarCaja_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(709, 60);
            this.label2.TabIndex = 1;
            this.label2.Text = "EFECTIVO INICIAL EN LA CAJA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "DINERO EN LA CAJA";
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(15, 111);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(33, 13);
            this.lblSerial.TabIndex = 2;
            this.lblSerial.Text = "Serial";
            // 
            // lblIdUsu
            // 
            this.lblIdUsu.AutoSize = true;
            this.lblIdUsu.Location = new System.Drawing.Point(27, 90);
            this.lblIdUsu.Name = "lblIdUsu";
            this.lblIdUsu.Size = new System.Drawing.Size(35, 13);
            this.lblIdUsu.TabIndex = 3;
            this.lblIdUsu.Text = "label3";
            // 
            // gridCajas
            // 
            this.gridCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCajas.Location = new System.Drawing.Point(18, 7);
            this.gridCajas.Name = "gridCajas";
            this.gridCajas.Size = new System.Drawing.Size(222, 63);
            this.gridCajas.TabIndex = 4;
            // 
            // lblIdCaja
            // 
            this.lblIdCaja.AutoSize = true;
            this.lblIdCaja.Location = new System.Drawing.Point(27, 73);
            this.lblIdCaja.Name = "lblIdCaja";
            this.lblIdCaja.Size = new System.Drawing.Size(35, 13);
            this.lblIdCaja.TabIndex = 5;
            this.lblIdCaja.Text = "label3";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gridCajas);
            this.panel3.Controls.Add(this.lblSerial);
            this.panel3.Controls.Add(this.lblIdUsu);
            this.panel3.Controls.Add(this.lblIdCaja);
            this.panel3.Location = new System.Drawing.Point(28, 148);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(14, 27);
            this.panel3.TabIndex = 6;
            // 
            // formCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1197, 585);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "formCaja";
            this.Text = "formCaja";
            this.Load += new System.EventHandler(this.formCaja_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCajas)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Button btnOmitir;
        private System.Windows.Forms.Button btnIniciarCaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblIdUsu;
        private System.Windows.Forms.DataGridView gridCajas;
        private System.Windows.Forms.Label lblIdCaja;
        private System.Windows.Forms.Panel panel3;
    }
}