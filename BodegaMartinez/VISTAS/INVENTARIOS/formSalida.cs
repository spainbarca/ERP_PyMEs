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

namespace BodegaMartinez.INVENTARIOS
{
    public partial class formSalida : Form
    {
        public formSalida()
        {
            InitializeComponent();
        }

        private void InvocarProductos()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                SqlCommand sql = new SqlCommand("mostrar_productos_entradas", con);
                sql.Parameters.AddWithValue("@id_prod", lblIdProd.Text);
                sql.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader sdr = sql.ExecuteReader();
                if (sdr.Read())
                {
                    lblActual.Text = sdr["Actual"].ToString();
                    lblCosto.Text = sdr["precio_compra"].ToString();
                    lblAlmacen.Text = sdr["habia"].ToString();
                    byte[] bi = (byte[])sdr["imagen_prod"];
                    MemoryStream ms = new MemoryStream(bi);
                    pbxProd.Image = Image.FromStream(ms);
                }

                con.Close();
                txtCantidad.Enabled = true;
                limite = Convert.ToDecimal(lblActual.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        private void gridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdProd.Text = gridProductos.SelectedCells[0].Value.ToString();
            txtBuscarProd.Text = gridProductos.SelectedCells[2].Value.ToString();

            txtBuscarProd.ReadOnly = true;
            txtBuscarProd.ForeColor = Color.White;
            txtBuscarProd.BackColor = SystemColors.HotTrack;

            gridProductos.Visible = false;
            pnlFoto.Visible = true;

            InvocarProductos();
        }

        private void AutobusquedaProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("autobusqueda_productos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@multi", txtBuscarProd.Text);
                da.Fill(dt);
                gridProductos.DataSource = dt;
                con.Close();

                gridProductos.Columns[0].Visible = false;
                gridProductos.Columns[1].Visible = false;
                gridProductos.Columns[2].Visible = true;
                gridProductos.Columns[3].Visible = false;
                gridProductos.Columns[4].Visible = false;
                gridProductos.Columns[5].Visible = false;
                gridProductos.Columns[6].Visible = false;
                gridProductos.Columns[7].Visible = false;
                gridProductos.Columns[8].Visible = false;
                gridProductos.Columns[9].Visible = false;
                gridProductos.Columns[10].Visible = false;
            }
            catch (Exception)
            {

            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref gridProductos);
        }

        private void txtBuscarProd_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarProd.Text != "")
            {
                gridProductos.Visible = true;
                AutobusquedaProductos();
            }
        }

        private void SalidasProductos()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                double actual = Convert.ToDouble(lblActual.Text);
                double cant = Convert.ToDouble(txtCantidad.Text);

                double hay = actual - cant;

                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("insertar_entrada", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@fecha", DateTime.Now);
                sql.Parameters.AddWithValue("@motivo", richMotivo.Text);
                sql.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                sql.Parameters.AddWithValue("@producto", lblIdProd.Text);
                sql.Parameters.AddWithValue("@usuario", LOGIN.formLogin.id_usuario);
                sql.Parameters.AddWithValue("@tipo", "SALIDA");
                sql.Parameters.AddWithValue("@estado", "CONFIRMO");
                sql.Parameters.AddWithValue("@costo_unit", lblCosto.Text);
                sql.Parameters.AddWithValue("@habia", lblAlmacen.Text);
                sql.Parameters.AddWithValue("@hay", hay);
                sql.Parameters.AddWithValue("@id_caja", lblIdCajaSerial.Text);

                sql.ExecuteNonQuery();

                MessageBox.Show("Stock modificado correctamente");
                con.Close();
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
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("SELECT id_caja FROM t_caja WHERE serial_pc = '" + LOGIN.formLogin.serial + "'", con);

                lblIdCajaSerial.Text = "";
                lblIdCajaSerial.Text = Convert.ToString(sql.ExecuteScalar());

                //cajastatic = lblIdCajaSerial.Text;

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("El caja no existe en la bd");
            }
        }

        private void LimpiarSalida()
        {
            txtBuscarProd.ReadOnly = false;
            txtBuscarProd.BackColor = Color.White;
            txtBuscarProd.ForeColor = Color.Black;
            txtBuscarProd.Clear();
            lblIdProd.Text = "";
            lblActual.Text = "0";
            txtCantidad.Value = 0;
            dateReg.Value = DateTime.Today;
            richMotivo.Clear();
            pnlFoto.Visible = false;
            txtCantidad.Enabled = false;

            txtBuscarProd.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SalidasProductos();
        }

        private void formSalida_Load(object sender, EventArgs e)
        {
            Mostrar_IdCaja_Serial();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            txtBuscarProd.Clear();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnNuevoProv_Click(object sender, EventArgs e)
        {
            if (txtBuscarProd.Text != "")
            {
                if (txtCantidad.Value>0)
                {
                    if (richMotivo.Text != "")
                    {
                        SalidasProductos();
                    }
                    else
                    {
                        MessageBox.Show("El motivo está vacío ¡Digítelo!", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("La cantidad está vacía ¡Digítela!", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No hay un producto elegido ¡Seleccione!", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            LimpiarSalida();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateReg_ValueChanged(object sender, EventArgs e)
        {

        }

        private void richMotivo_TextChanged(object sender, EventArgs e)
        {

        }

        decimal limite;
        private void txtCantidad_ValueChanged(object sender, EventArgs e)
        {
            
            txtCantidad.Maximum = limite;
        }
    }
}
