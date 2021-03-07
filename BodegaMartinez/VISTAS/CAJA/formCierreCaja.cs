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

namespace BodegaMartinez.CAJA
{
    public partial class formCierreCaja : Form
    {
        public formCierreCaja()
        {
            InitializeComponent();
        }

        private void btnFinTurno_Click(object sender, EventArgs e)
        {
            try
            {
                double total_calc;
                double diferencia;

                total_calc = Convert.ToDouble(txtIngresos.Text) - Convert.ToDouble(txtEgresos.Text) + Convert.ToDouble(lblSaldo.Text);
                diferencia = Convert.ToDouble(txtTotalReal.Text) - total_calc;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("cerrar_caja", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@fecha_fin", dateCierre.Value);
                sql.Parameters.AddWithValue("@fecha_cierre", DateTime.Now);
                sql.Parameters.AddWithValue("@ingresos", txtIngresos.Text);
                sql.Parameters.AddWithValue("@egresos", txtEgresos.Text);
                sql.Parameters.AddWithValue("@id_usuario", lblIdUsuario.Text);
                sql.Parameters.AddWithValue("@total_real", txtTotalReal.Text);
                sql.Parameters.AddWithValue("@diferencia", diferencia);
                sql.Parameters.AddWithValue("@id_caja", lblIdCaja.Text);
                sql.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Gracias!!, regrese pronto!!");
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                da.SelectCommand.Parameters.AddWithValue("@serial", lblSerialCierre.Text);

                da.Fill(dt);
                gridCierreCajas.DataSource = dt;

                con.Close();
            }
            catch (Exception)
            {

            }
        }

        private void InvocarSerial()
        {
            try
            {
                ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");
                lblSerialCierre.Text = MOS.Properties["SerialNumber"].Value.ToString();
                lblSerialCierre.Text = lblSerialCierre.Text.Trim();
                
                Mostrar_IdCaja_Serial();

                lblIdCaja.Text = gridCierreCajas.SelectedCells[0].Value.ToString();

                InvocarSaldo();

            }
            catch (Exception)
            {
                MessageBox.Show("No se puede ver el numero de serie");
            }
        }

        private void formCierreCaja_Load(object sender, EventArgs e)
        {
            InvocarSerial();
            lblUsuario.Text = LOGIN.formLogin.usuarioingresa;
            InvocarIdUsuario();

            InvocarIngreso();
        }

        private void InvocarIngreso()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("ingreso_actual", con);
                sql.CommandType = CommandType.StoredProcedure;

                txtIngresos.Text = "";
                txtIngresos.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Esta caja ya esta cerrada");
            }
        }

        private void InvocarSaldo()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("invocar_saldo", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_caja", lblIdCaja.Text);

                lblSaldo.Text = "";
                lblSaldo.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Esta caja ya esta cerrada");
            }
        }

        private void InvocarIdUsuario()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("mostrar_idusuario_usuario", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@usuario", lblUsuario.Text);

                lblIdUsuario.Text = "";
                lblIdUsuario.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Esta usuario no existe");
            }
        }
    }
}
