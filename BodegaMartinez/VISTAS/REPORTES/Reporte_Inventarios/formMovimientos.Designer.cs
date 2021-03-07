namespace BodegaMartinez.REPORTES.Reporte_Inventarios
{
    partial class formMovimientos
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
            this.mireporteMov = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // mireporteMov
            // 
            this.mireporteMov.AccessibilityKeyMap = null;
            this.mireporteMov.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mireporteMov.Location = new System.Drawing.Point(0, 0);
            this.mireporteMov.Name = "mireporteMov";
            this.mireporteMov.Size = new System.Drawing.Size(800, 450);
            this.mireporteMov.TabIndex = 0;
            this.mireporteMov.Load += new System.EventHandler(this.mireporteMov_Load);
            // 
            // formMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mireporteMov);
            this.Name = "formMovimientos";
            this.Text = "formMovimientos";
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer mireporteMov;
    }
}