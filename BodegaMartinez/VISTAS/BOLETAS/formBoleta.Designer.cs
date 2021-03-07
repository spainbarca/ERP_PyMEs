
namespace BodegaMartinez.BOLETAS
{
    partial class formBoleta
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
            this.miBoleta = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // miBoleta
            // 
            this.miBoleta.AccessibilityKeyMap = null;
            this.miBoleta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miBoleta.Location = new System.Drawing.Point(0, 0);
            this.miBoleta.Name = "miBoleta";
            this.miBoleta.Size = new System.Drawing.Size(800, 450);
            this.miBoleta.TabIndex = 0;
            this.miBoleta.Load += new System.EventHandler(this.miBoleta_Load);
            // 
            // formBoleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.miBoleta);
            this.Name = "formBoleta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formBoleta";
            this.Load += new System.EventHandler(this.formBoleta_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.ReportViewer.WinForms.ReportViewer miBoleta;
    }
}