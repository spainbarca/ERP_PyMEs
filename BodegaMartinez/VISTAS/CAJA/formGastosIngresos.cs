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
using System.IO;
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;


namespace BodegaMartinez.VISTAS.CAJA
{
    public partial class formGastosIngresos : Form
    {
        public formGastosIngresos()
        {
            InitializeComponent();
        }

        Caja caja = new Caja();
        CajasDao funcionCaja = new CajasDao();

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void TotalIngresos()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("total_ingresos", con);
                sql.CommandType = CommandType.StoredProcedure;

                lbltotalIngresos.Text = "";
                lbltotalIngresos.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Esta caja ya esta cerrada");
            }
        }

        private void TotalGastos()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("total_egresos", con);
                sql.CommandType = CommandType.StoredProcedure;

                lbltotalGastos.Text = "";
                lbltotalGastos.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Esta caja ya esta cerrada");
            }
        }

        private void CajaActualFecha()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("cajaaperturada_actual", con);
                sql.CommandType = CommandType.StoredProcedure;

                lblCajaActualFecha.Text = "";
                lblCajaActualFecha.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Esta caja ya esta cerrada");
            }
        }

        private void ListarIngresos()
        {
            try
            {
                DataTable dt = new DataTable();
                CajasDao.ListarCierreCajas(ref dt);

                gridIngresos.DataSource = dt;

                gridIngresos.Columns[0].Visible = false;
                gridIngresos.Columns[1].Visible = false;
                gridIngresos.Columns[2].Visible = true;
                gridIngresos.Columns[3].Visible = true;
                gridIngresos.Columns[4].Visible = true;
                gridIngresos.Columns[5].Visible = false;
                gridIngresos.Columns[6].Visible = false;
                gridIngresos.Columns[7].Visible = true;
                gridIngresos.Columns[4].DefaultCellStyle.BackColor = Color.Green;
                gridIngresos.Columns[4].DefaultCellStyle.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Datatables_tamañoAuto.Multilinea(ref gridIngresos);
        }

        private void ListarEgresos()
        {
            try
            {
                DataTable dt = new DataTable();
                CajasDao.ListarCierreCajas(ref dt);

                gridGastos.DataSource = dt;

                gridGastos.Columns[0].Visible = false;
                gridGastos.Columns[1].Visible = false;
                gridGastos.Columns[2].Visible = true;
                gridGastos.Columns[3].Visible = true;
                gridGastos.Columns[4].Visible = false;
                gridGastos.Columns[5].Visible = true;
                gridGastos.Columns[6].Visible = false;
                gridGastos.Columns[7].Visible = true;
                gridGastos.Columns[5].DefaultCellStyle.BackColor = Color.Red;
                gridGastos.Columns[5].DefaultCellStyle.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Datatables_tamañoAuto.Multilinea(ref gridGastos);
        }

        private void formGastosIngresos_Load(object sender, EventArgs e)
        {
            ListarIngresos();
            ListarEgresos();
            CajaActualFecha();
            TotalGastos();
            TotalIngresos();
        }
    }
}
