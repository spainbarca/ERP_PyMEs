using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;
using System.Threading;
using System.Data.SqlClient;

namespace BodegaMartinez.VISTAS.COPIAS_SEGURIDAD
{
    public partial class formCopiasSeguridad : Form
    {
        public formCopiasSeguridad()
        {
            InitializeComponent();
        }

        string txtsoftware = "Bodega";
        string Base_De_datos = "BD_I2_Bodega";
        private Thread Hilo;
        private bool acaba = false;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (acaba == true)
            {
                timer1.Stop();
                pbxLoading.Visible = false;
                lbldirectorio.Visible = true;
                lbldirectorio.Text = "Copia Guardada en: " + txtRuta.Text + @"\" + "BD_I2_Bodega.bak";
                //editarRespaldos();

            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            GenerarBackup();
        }

        private void GenerarBackup()
        {
            if (!string.IsNullOrEmpty(txtRuta.Text))
            {
                Hilo = new Thread(new ThreadStart(EjecutarBackup));
                pbxLoading.Visible = true;
                Hilo.Start();
                acaba = false;
                timer1.Start();

            }
            else
            {
                MessageBox.Show("Selecciona una Ruta donde Guardar las Copias de Seguridad", "Seleccione Ruta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRuta.Focus();
            }
        }

        private void EjecutarBackup()
        {
            string miCarpeta = "Copias_de_Seguridad_de_" + txtsoftware;
            if (System.IO.Directory.Exists(txtRuta.Text + miCarpeta))
            {

            }
            else
            {
                System.IO.Directory.CreateDirectory(txtRuta.Text + miCarpeta);
            }
            string ruta_completa = txtRuta.Text + miCarpeta;
            string SubCarpeta = ruta_completa + @"\Respaldo_al_" + DateTime.Now.Day + "_" + (DateTime.Now.Month) + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute;
            try
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(ruta_completa, SubCarpeta));

            }
            catch (Exception)
            {


            }
            try
            {
                string v_nombre_respaldo = Base_De_datos + ".bak";
                ConexionBD.abrir();
                SqlCommand cmd = new SqlCommand("BACKUP DATABASE " + Base_De_datos + " TO DISK = '" + SubCarpeta + @"\" + v_nombre_respaldo + "'", ConexionBD.conectar);
                cmd.ExecuteNonQuery();
                acaba = true;
            }
            catch (Exception ex)
            {
                acaba = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            ObtenerRuta();
        }

        private void lblRuta_Click(object sender, EventArgs e)
        {
            ObtenerRuta();
        }

        private void ObtenerRuta()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
