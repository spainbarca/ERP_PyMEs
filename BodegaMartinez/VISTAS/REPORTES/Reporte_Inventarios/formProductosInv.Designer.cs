namespace BodegaMartinez.REPORTES.Reporte_Inventarios
{
    partial class formProductosInv
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
            this.mireporteProd = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // mireporteProd
            // 
            this.mireporteProd.AccessibilityKeyMap = null;
            this.mireporteProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mireporteProd.Location = new System.Drawing.Point(0, 0);
            this.mireporteProd.Name = "mireporteProd";
            this.mireporteProd.Size = new System.Drawing.Size(800, 450);
            this.mireporteProd.TabIndex = 0;
            this.mireporteProd.Load += new System.EventHandler(this.mireporteProd_Load);
            // 
            // formProductosInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mireporteProd);
            this.Name = "formProductosInv";
            this.Text = "formProductosInv";
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer mireporteProd;
    }
}