using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Management;
using System.Drawing.Printing;
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;

namespace BodegaMartinez.VISTAS.CAJA
{
    public partial class formNuevaCaja : Form
    {
        public formNuevaCaja()
        {
            InitializeComponent();
        }

        Caja caja = new Caja();
        CajasDao funcionCaja = new CajasDao();

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            AgregarSerial();
        }

        private void AgregarSerial()
        {
            try
            {
                caja.Descripcion = txtDescripcion.Text;
                caja.Tema = cbxTema.Text;
                caja.SerialPc = txtSerial.Text;
                caja.ImpresoraTicket = txtTicket.Text;
                caja.ImpresoraA4 = cbxImpresora.Text;

                if (funcionCaja.AgregarCaja(caja) == true)
                {
                    MessageBox.Show("¡Registro exitoso!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Application.Exit();
                    Dispose();
                    LOGIN.formLogin log = new LOGIN.formLogin();
                    log.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo guardar el serial");
            }
        }

        void CargarImpresoras()
        {
            cbxImpresora.Items.Clear();
            for (var I = 0; I < PrinterSettings.InstalledPrinters.Count; I++)
            {
                cbxImpresora.Items.Add(PrinterSettings.InstalledPrinters[I]);
            }
            cbxImpresora.Items.Add("Ninguna");
        }

        private void formNuevaCaja_Load(object sender, EventArgs e)
        {
            CargarImpresoras();
            txtSerial.Text = LOGIN.formLogin.serial;
        }
    }
}
