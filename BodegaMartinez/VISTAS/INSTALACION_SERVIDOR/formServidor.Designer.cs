
namespace BodegaMartinez.VISTAS.INSTALACION_SERVIDOR
{
    partial class formServidor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formServidor));
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnSecundaria = new System.Windows.Forms.Button();
            this.btnPrimaria = new System.Windows.Forms.Button();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.Label4);
            this.Panel4.Controls.Add(this.btnSecundaria);
            this.Panel4.Controls.Add(this.btnPrimaria);
            this.Panel4.Controls.Add(this.Label9);
            this.Panel4.Controls.Add(this.Label1);
            this.Panel4.Controls.Add(this.Panel1);
            this.Panel4.Controls.Add(this.Panel2);
            this.Panel4.Controls.Add(this.PictureBox1);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(1013, 491);
            this.Panel4.TabIndex = 613;
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Label4.ForeColor = System.Drawing.Color.White;
            this.Label4.Location = new System.Drawing.Point(669, 339);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(318, 103);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Se Conecta a la Computadora Principal siempre y cuando la Principal este Encendid" +
    "a";
            // 
            // btnSecundaria
            // 
            this.btnSecundaria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnSecundaria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSecundaria.FlatAppearance.BorderSize = 0;
            this.btnSecundaria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecundaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.btnSecundaria.ForeColor = System.Drawing.Color.White;
            this.btnSecundaria.Location = new System.Drawing.Point(39, 324);
            this.btnSecundaria.Name = "btnSecundaria";
            this.btnSecundaria.Size = new System.Drawing.Size(247, 84);
            this.btnSecundaria.TabIndex = 609;
            this.btnSecundaria.Text = "Secundaria";
            this.btnSecundaria.UseVisualStyleBackColor = false;
            this.btnSecundaria.Click += new System.EventHandler(this.btnSecundaria_Click);
            // 
            // btnPrimaria
            // 
            this.btnPrimaria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.btnPrimaria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrimaria.FlatAppearance.BorderSize = 0;
            this.btnPrimaria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrimaria.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.btnPrimaria.ForeColor = System.Drawing.Color.White;
            this.btnPrimaria.Location = new System.Drawing.Point(137, 122);
            this.btnPrimaria.Name = "btnPrimaria";
            this.btnPrimaria.Size = new System.Drawing.Size(247, 84);
            this.btnPrimaria.TabIndex = 608;
            this.btnPrimaria.Text = "Principal";
            this.btnPrimaria.UseVisualStyleBackColor = false;
            this.btnPrimaria.Click += new System.EventHandler(this.btnPrimaria_Click);
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.Label9.ForeColor = System.Drawing.Color.White;
            this.Label9.Location = new System.Drawing.Point(571, 132);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(387, 103);
            this.Label9.TabIndex = 0;
            this.Label9.Text = "Esta Computadora debe estar Encendida para que las Computadoras\r\nSecundarias se C" +
    "onecten. Si se apaga no podran conectarse.";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold);
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(228, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(473, 46);
            this.Label1.TabIndex = 605;
            this.Label1.Text = "¿Esta Computadora es?";
            // 
            // Panel1
            // 
            this.Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel1.BackgroundImage")));
            this.Panel1.Location = new System.Drawing.Point(555, 113);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(3, 135);
            this.Panel1.TabIndex = 606;
            // 
            // Panel2
            // 
            this.Panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel2.BackgroundImage")));
            this.Panel2.Location = new System.Drawing.Point(653, 313);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(3, 139);
            this.Panel2.TabIndex = 607;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(236, 113);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(472, 339);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 604;
            this.PictureBox1.TabStop = false;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.Panel4;
            this.bunifuDragControl1.Vertical = true;
            // 
            // formServidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1013, 491);
            this.Controls.Add(this.Panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formServidor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formServidor";
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Button btnSecundaria;
        internal System.Windows.Forms.Button btnPrimaria;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.PictureBox PictureBox1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
    }
}