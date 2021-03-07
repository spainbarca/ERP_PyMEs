
namespace BodegaMartinez.VISTAS.TARJETAS
{
    partial class formSeleccionarMedioPago
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
            this.flowProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowProductos
            // 
            this.flowProductos.AutoScroll = true;
            this.flowProductos.AutoSize = true;
            this.flowProductos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowProductos.BackColor = System.Drawing.Color.Lavender;
            this.flowProductos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowProductos.Location = new System.Drawing.Point(0, 0);
            this.flowProductos.Name = "flowProductos";
            this.flowProductos.Size = new System.Drawing.Size(529, 168);
            this.flowProductos.TabIndex = 4;
            this.flowProductos.Paint += new System.Windows.Forms.PaintEventHandler(this.flowProductos_Paint);
            // 
            // formSeleccionarMedioPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(529, 168);
            this.Controls.Add(this.flowProductos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formSeleccionarMedioPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formSeleccionarMedioPago";
            this.Load += new System.EventHandler(this.formSeleccionarMedioPago_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowProductos;
    }
}