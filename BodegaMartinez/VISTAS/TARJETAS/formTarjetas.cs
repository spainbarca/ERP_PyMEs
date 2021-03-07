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
using System.IO;

namespace BodegaMartinez.VISTAS.TARJETAS
{
    public partial class formTarjetas : Form
    {
        public formTarjetas()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //MENUPRINCIPAL.formMediosPago pag = Owner as MENUPRINCIPAL.formMediosPago;
            //pag.lblIdCard.Text = "Hola";
            //this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbxAgregarPago_Click(object sender, EventArgs e)
        {
            pbxImagen.Visible = false;
            groupBox1.Visible = true;
            groupBox1.Dock = DockStyle.Fill;

            menuStrip1.Visible = true;

            btnAgregar.Visible = true;
            btnEditar.Visible = false;
            btnCancelar.Visible = true;
            btnCancelar.Visible = true;

            pbxAgregarPago.Visible = false;
        }

        private void formTarjetas_Load(object sender, EventArgs e)
        {
            pbxImagen.Dock = DockStyle.Fill;
            MostrarMediosPago();
        }

        private void MostrarMediosPago()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_tarjetas", con);
                da.Fill(dt);

                gridMedioPago.DataSource = dt;
                con.Close();
                //Nombretabla+Columns[n]+.Visible=true/false
                gridMedioPago.Columns[3].Visible = false;
                gridMedioPago.Columns[4].Visible = true;
                gridMedioPago.Columns[5].Visible = false;
                gridMedioPago.Columns[6].Visible = false;
                gridMedioPago.Columns[7].Visible = false;
            }
            catch (Exception)
            {

            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref gridMedioPago);
        }

        private void pbxPago_Click(object sender, EventArgs e)
        {
            LlamarLogoMedioPago();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            AgregarMediosPago();
        }

        private void AgregarMediosPago()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("crear_tarjeta", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@nombre_card", txtMedioPago.Text);
                sql.Parameters.AddWithValue("@descripcion_card", richDescripcionPago.Text);
                MemoryStream ms = new MemoryStream();
                pbxPago.Image.Save(ms, pbxPago.Image.RawFormat);
                sql.Parameters.AddWithValue("@imagen_card", ms.GetBuffer());
                sql.Parameters.AddWithValue("@nombre_imagen", lblIcoPago.Text);
                sql.Parameters.AddWithValue("@estado", "ACTIVADO");
                sql.Parameters.AddWithValue("@fecha_reg", DateTime.Now);

                sql.ExecuteNonQuery();

                MessageBox.Show("Medio de Pago insertado correctamente", "Inserción exitosa", MessageBoxButtons.OK);
                con.Close();
                MostrarMediosPago();
                LimpiarMediosPago();

                groupBox1.Visible = false;
                pbxImagen.Visible = true;
                pbxImagen.Dock = DockStyle.Fill;

                menuStrip1.Visible = false;
                pbxAgregarPago.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error al insertar Medio de Pago", "Inserción fallida", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void LimpiarMediosPago()
        {
            pbxPago.BackgroundImage = null;
            txtMedioPago.Clear();
            richDescripcionPago.Clear();
            lblEligePago.Visible = true;
        }

        private void lblEligePago_Click(object sender, EventArgs e)
        {
            LlamarLogoMedioPago();
        }

        private void LlamarLogoMedioPago()
        {
            dlgPago.InitialDirectory = "";                   //ruta de inicio de visualizacion
            dlgPago.Filter = "Imagenes|*.jpg;*.png";         //que tipo de archivos deseo ver
            dlgPago.FilterIndex = 2;
            dlgPago.Title = "Logo para marca";             //Titulo de la ventana
            if (dlgPago.ShowDialog() == DialogResult.OK)
            {
                pbxPago.BackgroundImage = null;
                pbxPago.Image = new Bitmap(dlgPago.FileName); //capturo la imagen que seleccione
                lblIcoPago.Text = Path.GetFileName(dlgPago.FileName);
                lblEligePago.Visible = false;
            }
        }
    }
}
