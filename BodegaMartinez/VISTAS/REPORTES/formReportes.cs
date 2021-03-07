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

namespace BodegaMartinez.VISTAS.REPORTES
{
    public partial class formReportes : Form
    {
        public formReportes()
        {
            InitializeComponent();
        }

        //invocar la maquetacion
        Reporte_Ventas.repResumenVentas repres = new Reporte_Ventas.repResumenVentas();

        private void btnHoy_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("mostrar_ventashoy", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@fechahoy", DateTime.Today);

                da.Fill(dt);
                con.Close();

                repres = new Reporte_Ventas.repResumenVentas();
                repres.DataSource = dt;
                repres.tablaHoy.DataSource = dt;

                mireporteventas.Report = repres;
                mireporteventas.RefreshReport();
                mireporteventas.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth;
            }
            catch (Exception)
            {

            }
        }

        private void formReportes_Load(object sender, EventArgs e)
        {
            lblBienvenida.Dock = DockStyle.Fill;
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            lblBienvenida.Dock = DockStyle.None;
            lblBienvenida.Visible = false;
            pnlVentas.Dock = DockStyle.Fill;
            chart1.Visible = false;
            chart2.Visible = false;
        }

        private void checkFiltros_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFiltros.Checked)
            {
                pnlFiltros.Visible = true;
            }
            else
            {
                pnlFiltros.Visible = false;
            }
        }

        private void btnFiltros_Click(object sender, EventArgs e)
        {
            if (checkFiltros.Checked==false)
            {
                checkFiltros.Checked = true;
            }
            else
            {
                checkFiltros.Checked = false;
            }
            
        }

        private void VentasRangoFecha()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("mostrar_ventasrango", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@fechadesde", dateDesde.Value);
                da.SelectCommand.Parameters.AddWithValue("@fechahasta", dateHasta.Value);

                da.Fill(dt);
                con.Close();

                repres = new Reporte_Ventas.repResumenVentas();
                repres.DataSource = dt;
                repres.tablaHoy.DataSource = dt;
                repres.txtEncFecha.Value = "Fecha";
                repres.txtTitulo.Value = "REPORTE DE VENTAS SEGÚN RANGO DE FECHA";

                mireporteventas.Report = repres;
                mireporteventas.RefreshReport();
                mireporteventas.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth;
            }
            catch (Exception)
            {

            }
        }

        private void dateDesde_ValueChanged(object sender, EventArgs e)
        {
            VentasRangoFecha();
        }

        private void dateHasta_ValueChanged(object sender, EventArgs e)
        {
            VentasRangoFecha();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            
            chart1.Visible = true;
            chart2.Visible = true;
        }
    }
}
