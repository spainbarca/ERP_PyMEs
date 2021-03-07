namespace BodegaMartinez
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbxIcono = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConocenos = new System.Windows.Forms.Button();
            this.btnBD = new System.Windows.Forms.Button();
            this.btnPulsar = new System.Windows.Forms.Button();
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxIcono
            // 
            this.pbxIcono.BackColor = System.Drawing.Color.Transparent;
            this.pbxIcono.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxIcono.BackgroundImage")));
            this.pbxIcono.Image = ((System.Drawing.Image)(resources.GetObject("pbxIcono.Image")));
            this.pbxIcono.Location = new System.Drawing.Point(67, 2);
            this.pbxIcono.Name = "pbxIcono";
            this.pbxIcono.Size = new System.Drawing.Size(73, 67);
            this.pbxIcono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxIcono.TabIndex = 0;
            this.pbxIcono.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(152, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "BODEGA";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Bernard MT Condensed", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(517, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 126);
            this.label2.TabIndex = 2;
            this.label2.Text = "BODEGA - \r\n\"MARTÍNEZ\"";
            // 
            // btnConocenos
            // 
            this.btnConocenos.BackColor = System.Drawing.Color.Orange;
            this.btnConocenos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConocenos.Font = new System.Drawing.Font("Bernard MT Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConocenos.Location = new System.Drawing.Point(646, 244);
            this.btnConocenos.Name = "btnConocenos";
            this.btnConocenos.Size = new System.Drawing.Size(114, 32);
            this.btnConocenos.TabIndex = 3;
            this.btnConocenos.Text = "CONÓCENOS";
            this.btnConocenos.UseVisualStyleBackColor = false;
            this.btnConocenos.Click += new System.EventHandler(this.btnConocenos_Click);
            // 
            // btnBD
            // 
            this.btnBD.BackColor = System.Drawing.Color.Fuchsia;
            this.btnBD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBD.Font = new System.Drawing.Font("Bernard MT Condensed", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBD.Location = new System.Drawing.Point(675, 209);
            this.btnBD.Name = "btnBD";
            this.btnBD.Size = new System.Drawing.Size(69, 32);
            this.btnBD.TabIndex = 4;
            this.btnBD.Text = "BD";
            this.btnBD.UseVisualStyleBackColor = false;
            // 
            // btnPulsar
            // 
            this.btnPulsar.BackColor = System.Drawing.Color.Yellow;
            this.btnPulsar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPulsar.Font = new System.Drawing.Font("Old English Text MT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPulsar.Location = new System.Drawing.Point(514, 392);
            this.btnPulsar.Name = "btnPulsar";
            this.btnPulsar.Size = new System.Drawing.Size(246, 52);
            this.btnPulsar.TabIndex = 5;
            this.btnPulsar.Text = "Pulsar Aquí";
            this.btnPulsar.UseVisualStyleBackColor = false;
            this.btnPulsar.Click += new System.EventHandler(this.btnPulsar_Click);
            // 
            // pbxImagen
            // 
            this.pbxImagen.BackColor = System.Drawing.Color.Transparent;
            this.pbxImagen.Image = ((System.Drawing.Image)(resources.GetObject("pbxImagen.Image")));
            this.pbxImagen.Location = new System.Drawing.Point(58, 153);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(444, 197);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImagen.TabIndex = 6;
            this.pbxImagen.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbxImagen);
            this.Controls.Add(this.btnPulsar);
            this.Controls.Add(this.btnBD);
            this.Controls.Add(this.btnConocenos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxIcono);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BODEGA MARTINEZ - PRESENTACION";
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxIcono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConocenos;
        private System.Windows.Forms.Button btnBD;
        private System.Windows.Forms.Button btnPulsar;
        private System.Windows.Forms.PictureBox pbxImagen;
    }
}

