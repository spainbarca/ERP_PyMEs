namespace BodegaMartinez.REPORTES.Reporte_Inventarios
{
    partial class formAcumulado
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
            this.mireporteAcum = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // mireporteAcum
            // 
            this.mireporteAcum.AccessibilityKeyMap = null;
            this.mireporteAcum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mireporteAcum.Location = new System.Drawing.Point(0, 0);
            this.mireporteAcum.Name = "mireporteAcum";
            this.mireporteAcum.Size = new System.Drawing.Size(800, 450);
            this.mireporteAcum.TabIndex = 0;
            this.mireporteAcum.Load += new System.EventHandler(this.mireporteAcum_Load);
            // 
            // formAcumulado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mireporteAcum);
            this.Name = "formAcumulado";
            this.Text = "formAcumulado";
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer mireporteAcum;
    }
}