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
using BodegaMartinez.DATOS;
using System.Collections;
using System.IO;
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;

namespace BodegaMartinez.DASHBOARD
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);

        }

        private const int cGrip = 16;
        private const int cCaption = 32;

        DashboardsDao funcionDashboard = new DashboardsDao();

        protected override void WndProc(ref Message m)
        {
            if (m.Msg==0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y<cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X>=this.ClientSize.Width-cGrip && pos.Y>=this.ClientSize.Height-cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        DataTable dt5Productos;
        DataTable dtVentas;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            MENUPRINCIPAL.formMenuPrincipal men = new MENUPRINCIPAL.formMenuPrincipal();
            men.ShowDialog();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            ContarProductos();
            ContarClientesActivos();
            ContarStockMinimo();
            InvocarMesActual();
            Productos5MasVendidos();
            MostrarVentasGrafica();
            TotalGananciasActuales();
            TotalCreditosActuales();
            VentasFrecuenciaClientes();
            VentasMagnitudClientes();
            ListarAño();
        }

        private void VentasFrecuenciaClientes()
        {
            ArrayList fecha = new ArrayList();
            ArrayList monto = new ArrayList();
            dtVentas = new DataTable();
            ObtenerDatos.MostrarVentasGrafica(ref dtVentas);
            foreach (DataRow filas in dtVentas.Rows)
            {
                fecha.Add(filas["periodo"]);
                monto.Add(filas["conta"]);
            }
            chartContaVenta.Series[0].Points.DataBindXY(fecha, monto);
            //ReporteTotalVentas();
            //ReporteGanancias();
        }

        private void VentasMagnitudClientes()
        {
            DataTable dt = new DataTable();
            DashboardsDao.FrecuenciaClientes(ref dt);
            ArrayList venta = new ArrayList();
            ArrayList descripcion = new ArrayList();
            foreach (DataRow filas in dt.Rows)
            {
                venta.Add(filas["Venta"]);
                descripcion.Add(filas["cliente"]);
            }
            chartMagnitudClientes.Series[0].Points.DataBindXY(descripcion, venta);
        }

        private void ContarProductos()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("contar_productos", con);
                sql.CommandType = CommandType.StoredProcedure;

                lblProductos.Text = "";
                lblProductos.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        private void ContarClientesActivos()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("contar_clientes", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@condicion", 1);


                lblNclientes.Text = "";
                lblNclientes.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
            }
        }

        private void ContarStockMinimo()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("contar_stockminimo", con);
                sql.CommandType = CommandType.StoredProcedure;

                lblStockBajo.Text = "";
                lblStockBajo.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        private void InvocarMesActual()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("mes_actual", con);
                sql.CommandType = CommandType.StoredProcedure;

                lblfechaHoy.Text = "";
                lblfechaHoy.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        private void TotalGananciasActuales()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("total_ganancias_actuales", con);
                sql.CommandType = CommandType.StoredProcedure;

                lblGanancias.Text = "";
                lblGanancias.Text = "S/. "+Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        private void TotalCreditosActuales()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("total_creditos_actuales", con);
                sql.CommandType = CommandType.StoredProcedure;

                lblPorcobrar.Text = "";
                lblPorcobrar.Text = "S/. " + Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        private void Productos5MasVendidos()
        {
            ArrayList cantidad = new ArrayList();
            ArrayList producto = new ArrayList();
            dt5Productos = new DataTable();
            ObtenerDatos.Productos5MasVendidos(ref dt5Productos);
            foreach (DataRow filas in dt5Productos.Rows)
            {
                cantidad.Add(filas["contaprod"]);
                producto.Add(filas["Descripcion"]);
            }
            chartProductos.Series[0].Points.DataBindXY(producto, cantidad);
        }

        private void btnFiltroFechas_Click(object sender, EventArgs e)
        {
            if (chekFiltroFechas.Checked == false)
            {
                chekFiltroFechas.Checked = true;
            }
            else
            {
                chekFiltroFechas.Checked = false;
            }

        }

        private void chekFiltroFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chekFiltroFechas.Checked)
            {
                pnlFechasVentas.Visible = true;
            }
            else
            {
                pnlFechasVentas.Visible = false;
            }
        }

        private void MostrarVentasGrafica()
        {
            ArrayList fecha = new ArrayList();
            ArrayList monto = new ArrayList();
            dtVentas = new DataTable();
            ObtenerDatos.MostrarVentasGrafica(ref dtVentas);
            foreach (DataRow filas in dtVentas.Rows)
            {
                fecha.Add(filas["label"]);
                monto.Add(filas["totalventas"]);
            }
            //fecha.Reverse();
            //monto.Reverse();
            chartVentas.Series[0].Points.DataBindXY(fecha, monto);
            //ReporteTotalVentas();
            //ReporteGanancias();
        }

        private void MostrarVentasGrafica6Meses()
        {
            ArrayList fecha = new ArrayList();
            ArrayList monto = new ArrayList();
            dtVentas = new DataTable();
            ObtenerDatos.MostrarVentasGrafica6Meses(ref dtVentas);
            foreach (DataRow filas in dtVentas.Rows)
            {
                fecha.Add(filas["periodo"]);
                monto.Add(filas["totalventas"]);
            }
            fecha.Reverse();
            monto.Reverse();
            chartVentas.Series[0].Points.DataBindXY(fecha, monto);
            //ReporteTotalVentas();
            //ReporteGanancias();
        }

        private void MostrarVentasGraficaAnual()
        {
            ArrayList fecha = new ArrayList();
            ArrayList monto = new ArrayList();
            dtVentas = new DataTable();
            int year = Convert.ToInt32(cbxAño.Text);
            DashboardsDao.MostrarVentasGraficoAnual(ref dtVentas, year);
            foreach (DataRow filas in dtVentas.Rows)
            {
                fecha.Add(filas["periodo"]);
                monto.Add(filas["totalventas"]);
            }
            //fecha.Reverse();
            //monto.Reverse();
            chartVentas.Series[0].Points.DataBindXY(fecha, monto);
            //ReporteTotalVentas();
            //ReporteGanancias();
        }

        private void MostrarVentasGraficaMensual()
        {
            ArrayList fecha = new ArrayList();
            ArrayList monto = new ArrayList();
            dtVentas = new DataTable();
            int year = Convert.ToInt32(cbxAño.Text);
            int mes = Convert.ToInt32(cbxMes.SelectedValue);
            DashboardsDao.MostrarVentasGraficoMensual(ref dtVentas, year, mes);
            foreach (DataRow filas in dtVentas.Rows)
            {
                fecha.Add(filas["label"]);
                monto.Add(filas["totalventas"]);
            }
            //fecha.Reverse();
            //monto.Reverse();
            chartVentas.Series[0].Points.DataBindXY(fecha, monto);
            //ReporteTotalVentas();
            //ReporteGanancias();
        }

        private void MostrarVentasGraficaFechas()
        {
            ArrayList fecha = new ArrayList();
            ArrayList monto = new ArrayList();
            dtVentas = new DataTable();
            ObtenerDatos.MostrarVentasGraficaFechas(ref dtVentas, dateFechaIni.Value, dateFechaFin.Value);
            foreach (DataRow filas in dtVentas.Rows)
            {
                fecha.Add(filas["periodo"]);
                monto.Add(filas["totalventas"]);
            }
            chartVentas.Series[0].Points.DataBindXY(fecha, monto);
            //ReporteTotalVentasFechas();
            //ReporteGananciasFecha();
        }

        public void ListarAño()
        {
            try
            {
                cbxAño.DataSource = funcionDashboard.ListarAño();
                cbxAño.DisplayMember = "Año";
                cbxAño.ValueMember = "Año";
            }
            catch (Exception)
            {
                MessageBox.Show("No hay roles listados", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ListarMes()
        {
            try
            {
                cbxMes.DataSource = funcionDashboard.ListarMes(cbxAño.Text);
                cbxMes.DisplayMember = "Mes";
                cbxMes.ValueMember = "id";
            }
            catch (Exception)
            {
                //MessageBox.Show("No hay roles listados", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dateFechaIni_ValueChanged(object sender, EventArgs e)
        {
            MostrarVentasGraficaFechas();
        }

        private void dateFechaFin_ValueChanged(object sender, EventArgs e)
        {
            MostrarVentasGraficaFechas();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            VISTAS.REPORTES.formReportes rep = new VISTAS.REPORTES.formReportes();
            rep.ShowDialog();
        }

        private void btnInventarios_Click(object sender, EventArgs e)
        {
            INVENTARIOS.formInventarios kdx = new INVENTARIOS.formInventarios();
            kdx.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            this.Hide();

            MENUPRINCIPAL.formMenuPrincipal men = new MENUPRINCIPAL.formMenuPrincipal();
            men.ShowDialog();
        }

        private void lblhastaHoy_Click(object sender, EventArgs e)
        {
            MostrarVentasGrafica();
        }

        private void frmDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnHastaHoy_Click(object sender, EventArgs e)
        {
            MostrarVentasGrafica();
        }

        private void cbxAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarMes();
            checkMes.Checked = false;
        }

        private void cbxAño_Click(object sender, EventArgs e)
        {
            
        }

        private void cbxAño_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void cbxAño_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        
        private void cbxMes_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void cbxMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void checkMes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkMes.Checked==true)
            {
                cbxMes.Enabled = true;
            }
            if (checkMes.Checked == false)
            {
                cbxMes.Enabled = false;
            }

        }

        private void cbxAño_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxMes_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (cbxMes.Enabled==false)
            {
                MostrarVentasGraficaAnual();
            }
            else
            {
                MostrarVentasGraficaMensual();
            }
            checkMes.Checked = false;
        }

        private void btn6meses_Click(object sender, EventArgs e)
        {
            MostrarVentasGrafica6Meses();
        }

        private void MenuStrip14_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
