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

namespace BodegaMartinez.REPORTES.Reporte_Inventarios
{
    public partial class formMovimientos : Form
    {
        public formMovimientos()
        {
            InitializeComponent();
        }

        repMovimientos repmov = new repMovimientos();

        private void ImprimirReporteMovimientos()
        {
            if (INVENTARIOS.formInventarios.cond=="simple")
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    da = new SqlDataAdapter("buscar_movimientos", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.AddWithValue("@multi", INVENTARIOS.formInventarios.multi);
                    da.Fill(dt);
                    con.Close();

                    repmov = new repMovimientos();
                    repmov.DataSource = dt;
                    repmov.tablaMov.DataSource = dt;
                    repmov.txtTituloMov.Value = "REPORTE DE MOVIMIENTOS SIMPLES DE INVENTARIO";

                    mireporteMov.Report = repmov;
                    mireporteMov.RefreshReport();
                }
                catch (Exception)
                {

                }
            }
            else if (INVENTARIOS.formInventarios.cond == "avanzado")
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    da = new SqlDataAdapter("filtros_avanzados_kardex", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.AddWithValue("@fecha", INVENTARIOS.formInventarios.fecha);
                    da.SelectCommand.Parameters.AddWithValue("@tipo", INVENTARIOS.formInventarios.tipo);
                    da.SelectCommand.Parameters.AddWithValue("@usuario", INVENTARIOS.formInventarios.usuario);

                    da.Fill(dt);
                    con.Close();

                    repmov = new repMovimientos();
                    repmov.DataSource = dt;
                    repmov.tablaMov.DataSource = dt;
                    repmov.txtTituloMov.Value = "REPORTE DE MOVIMIENTOS CON FILTROS AVANZADOS DE INVENTARIO";

                    mireporteMov.Report = repmov;
                    mireporteMov.RefreshReport();
                }
                catch (Exception)
                {

                }
            }
        }

        private void mireporteMov_Load(object sender, EventArgs e)
        {
            ImprimirReporteMovimientos();
        }
    }
}
