namespace BodegaMartinez.REPORTES.Reporte_Inventarios
{
    partial class formVencimientoProd
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
            this.mireporteVenc = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // mireporteVenc
            // 
            this.mireporteVenc.AccessibilityKeyMap = null;
            this.mireporteVenc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mireporteVenc.Location = new System.Drawing.Point(0, 0);
            this.mireporteVenc.Name = "mireporteVenc";
            this.mireporteVenc.Size = new System.Drawing.Size(800, 450);
            this.mireporteVenc.TabIndex = 0;
            this.mireporteVenc.Load += new System.EventHandler(this.mireporteVenc_Load);
            // 
            // formVencimientoProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mireporteVenc);
            this.Name = "formVencimientoProd";
            this.Text = "formVencimientoProd";
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer mireporteVenc;
    }
}