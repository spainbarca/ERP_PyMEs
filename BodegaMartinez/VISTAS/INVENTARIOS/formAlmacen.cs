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

namespace BodegaMartinez.PRODUCTOS
{
    public partial class formAlmacen : Form
    {
        public formAlmacen()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            txtBuscarProd.Clear();
        }

        private void MovimientosAlmacen()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("movimientos_almacen", con);
                da.SelectCommand.Parameters.AddWithValue("@fecha", dateReg.Value);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.Fill(dt);
                gridAlmacen.DataSource = dt;
                con.Close();

                //hay un boton creado previamente
                gridAlmacen.Columns[0].Visible = false;
                gridAlmacen.Columns[1].Visible = true;
                gridAlmacen.Columns[2].Visible = true;
                gridAlmacen.Columns[3].Visible = false;
                gridAlmacen.Columns[4].Visible = true;
                gridAlmacen.Columns[5].Visible = false;
                gridAlmacen.Columns[6].Visible = true;
            }
            catch (Exception)
            {

            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref gridAlmacen);
        }

        private void formAlmacen_Load(object sender, EventArgs e)
        {
            MovimientosAlmacen();
        }

        private void dateReg_ValueChanged(object sender, EventArgs e)
        {
            MovimientosAlmacen();
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
                gridProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                AutobusquedaProductos();
            }
            else
            {
                gridProductos.Visible = false;
            }
        }

        private void AlmacenProductos()
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
                sql = new SqlCommand("insertar_almacen", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@fecha", DateTime.Now);
                sql.Parameters.AddWithValue("@motivo", richMotivo.Text);
                sql.Parameters.AddWithValue("@cantidad", txtCantidad.Text);
                sql.Parameters.AddWithValue("@tipo", cbxTipo.Text);
                sql.Parameters.AddWithValue("@producto", lblIdProd.Text);

                sql.ExecuteNonQuery();

                MessageBox.Show("Productos mandados a tienda");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AlmacenProductos();
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

        private void LimpiarAlmacen()
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
            cbxTipo.SelectedIndex = 0;
            pnlFoto.Visible = false;
            txtCantidad.Enabled = false;

            txtBuscarProd.Focus();
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (txtBuscarProd.Text != "")
            {
                if (txtCantidad.Value>0)
                {
                    if (cbxTipo.SelectedIndex!=0)
                    {
                        if (richMotivo.Text != "")
                        {
                            AlmacenProductos();
                        }
                        else
                        {
                            MessageBox.Show("El motivo está vacío ¡Digítelo!", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡Seleccione el tipo de movimiento!", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            LimpiarAlmacen();
        }

        decimal limite;
        private void txtCantidad_ValueChanged(object sender, EventArgs e)
        {
            
            txtCantidad.Maximum = limite;
        }
    }
}
