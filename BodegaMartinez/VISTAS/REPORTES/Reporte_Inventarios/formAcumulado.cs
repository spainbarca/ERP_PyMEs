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
    public partial class formAcumulado : Form
    {
        public formAcumulado()
        {
            InitializeComponent();
        }

        //invocar la maquetacion
        repAcumulado repacum = new repAcumulado();

        private void ImprimirReporteAcumulado()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("filtro_acumulado", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@fecha", INVENTARIOS.formInventarios.fecha);
                da.SelectCommand.Parameters.AddWithValue("@tipo", INVENTARIOS.formInventarios.tipo);
                da.SelectCommand.Parameters.AddWithValue("@id_usuario", INVENTARIOS.formInventarios.usuario);

                da.Fill(dt);
                con.Close();

                repacum = new repAcumulado();
                repacum.DataSource = dt;
                repacum.tablaAcum.DataSource = dt;
                repacum.txtUsuarios.Value = INVENTARIOS.formInventarios.encargado;

                mireporteAcum.Report = repacum;
                mireporteAcum.RefreshReport();
            }
            catch (Exception)
            {

            }
        }

        private void mireporteAcum_Load(object sender, EventArgs e)
        {
            ImprimirReporteAcumulado();
        }
    }
}
