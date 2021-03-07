namespace BodegaMartinez.REPORTES.Reporte_Inventarios
{
    partial class formInventariosBajos
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
            this.mireporteBajos = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // mireporteBajos
            // 
            this.mireporteBajos.AccessibilityKeyMap = null;
            this.mireporteBajos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mireporteBajos.Location = new System.Drawing.Point(0, 0);
            this.mireporteBajos.Name = "mireporteBajos";
            this.mireporteBajos.Size = new System.Drawing.Size(800, 450);
            this.mireporteBajos.TabIndex = 0;
            // 
            // formInventariosBajos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mireporteBajos);
            this.Name = "formInventariosBajos";
            this.Text = "formInventariosBajos";
            this.Load += new System.EventHandler(this.formInventariosBajos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer mireporteBajos;
    }
}