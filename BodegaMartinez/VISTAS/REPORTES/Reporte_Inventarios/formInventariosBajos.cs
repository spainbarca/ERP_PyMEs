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
    public partial class formInventariosBajos : Form
    {
        public formInventariosBajos()
        {
            InitializeComponent();
        }

        repInventariosBajos repbajo = new repInventariosBajos();

        private void ImprimirReporteBajos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("inventarios_bajos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.Fill(dt);
                con.Close();

                repbajo = new repInventariosBajos();
                repbajo.DataSource = dt;
                repbajo.tablaBajos.DataSource = dt;

                mireporteBajos.Report = repbajo;

                mireporteBajos.RefreshReport();
            }
            catch (Exception)
            {

            }
        }

        private void formInventariosBajos_Load(object sender, EventArgs e)
        {
            ImprimirReporteBajos();
        }
    }
}
