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

namespace BodegaMartinez.CAJA
{
    public partial class formCaja : Form
    {
        public formCaja()
        {
            InitializeComponent();
        }

        private void btnIniciarCaja_Click(object sender, EventArgs e)
        {
            SaldoInicial();

            this.Hide();
            MENUPRINCIPAL.formMenuPrincipal frmMen = new MENUPRINCIPAL.formMenuPrincipal();
            frmMen.ShowDialog();

        }

        private void formCaja_Load(object sender, EventArgs e)
        {
            lblSerial.Text = LOGIN.formLogin.serial;
            lblIdUsu.Text = LOGIN.formLogin.id_usuario;
            Mostrar_IdCaja_Serial();
            lblIdCaja.Text = gridCajas.SelectedCells[0].Value.ToString();
        }

        private void btnOmitir_Click(object sender, EventArgs e)
        {
            this.Hide();
            MENUPRINCIPAL.formMenuPrincipal frmMen = new MENUPRINCIPAL.formMenuPrincipal();
            frmMen.ShowDialog();
        }

        private void SaldoInicial()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();

            SqlCommand sql = new SqlCommand();
            sql = new SqlCommand("editar_saldoinicial", con);
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@id_caja", lblIdCaja.Text);
            sql.Parameters.AddWithValue("@saldo", txtSaldo.Text);


            sql.ExecuteNonQuery();
            con.Close();
        }

        private void Mostrar_IdCaja_Serial()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                //SqlCommand sql = new SqlCommand("validar_usuario", con);
                da = new SqlDataAdapter("mostrar_idcaja_serial", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerial.Text);

                da.Fill(dt);
                gridCajas.DataSource = dt;

                con.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
