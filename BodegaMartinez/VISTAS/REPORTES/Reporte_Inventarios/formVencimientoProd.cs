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
    public partial class formVencimientoProd : Form
    {
        public formVencimientoProd()
        {
            InitializeComponent();
        }

        repVencimiento repvenc = new repVencimiento();

        private void ImprimirReporteVencimientos()
        {
            if (INVENTARIOS.formInventarios.cond=="producto")
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    da = new SqlDataAdapter("buscar_productos_vencidos", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand.Parameters.AddWithValue("@multi", INVENTARIOS.formInventarios.multi);

                    da.Fill(dt);
                    con.Close();

                    repvenc = new repVencimiento();
                    repvenc.DataSource = dt;
                    repvenc.tableVencimiento.DataSource = dt;

                    mireporteVenc.Report = repvenc;
                    mireporteVenc.RefreshReport();
                }
                catch (Exception)
                {

                }
            }
            else if (INVENTARIOS.formInventarios.cond=="30dias")
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    da = new SqlDataAdapter("productos_30dias", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.Fill(dt);
                    con.Close();

                    repvenc = new repVencimiento();
                    repvenc.DataSource = dt;
                    repvenc.tableVencimiento.DataSource = dt;
                    repvenc.txtEnca.Value = "Días por vencer";

                    mireporteVenc.Report = repvenc;
                    mireporteVenc.RefreshReport();
                }
                catch (Exception)
                {

                }
            }
            else if (INVENTARIOS.formInventarios.cond == "vencido")
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    da = new SqlDataAdapter("mostrar_productos_vencidos", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.Fill(dt);
                    con.Close();

                    repvenc = new repVencimiento();
                    repvenc.DataSource = dt;
                    repvenc.tableVencimiento.DataSource = dt;
                    repvenc.txtEnca.Value = "Días vencidos";

                    mireporteVenc.Report = repvenc;
                    mireporteVenc.RefreshReport();
                }
                catch (Exception)
                {

                }
            }
            else if (INVENTARIOS.formInventarios.cond == "dinamico")
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    da = new SqlDataAdapter("vencimiento_dinamico", con);
                    da.SelectCommand.Parameters.AddWithValue("@dias", INVENTARIOS.formInventarios.dia);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.Fill(dt);
                    con.Close();

                    repvenc = new repVencimiento();
                    repvenc.DataSource = dt;
                    repvenc.tableVencimiento.DataSource = dt;
                    repvenc.txtEnca.Value = "Días por vencer";

                    mireporteVenc.Report = repvenc;
                    mireporteVenc.RefreshReport();
                }
                catch (Exception)
                {

                }
            }     
            
        }


        private void mireporteVenc_Load(object sender, EventArgs e)
        {
            ImprimirReporteVencimientos();
        }
    }
}
