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
    public partial class formProductosInv : Form
    {
        public formProductosInv()
        {
            InitializeComponent();
        }

        repProductosInv repprod = new repProductosInv(); //llamo a mi maquetacion de reporte

        private void ImprimirReporteProductos()
        {
            if (INVENTARIOS.formInventarios.condrep=="T")
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    da = new SqlDataAdapter("reporte_productos", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.Fill(dt);
                    con.Close();

                    repprod = new repProductosInv(); //llamo al reves
                    repprod.DataSource = dt; //llenando los datos en mi objeto de maquetacion
                    repprod.tablaProductos.DataSource = dt; //mandando los datos capturados a mi tabla de maquetacion ---recomendacion: la tabla debe ser publica
                    repprod.txtTotal.Value = INVENTARIOS.formInventarios.totalinv; //mandando un parametro a mi reporte (tiene q ser publico)

                    mireporteProd.Report = repprod; //adhiriendo mi maquetacion con mi interfaz de reporte
                    mireporteProd.RefreshReport(); //actualizo los datos al iniciar reporte
                }
                catch (Exception)
                {
                }
            }
            else if (INVENTARIOS.formInventarios.condrep == "F")
            {
                try
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da;

                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.Conexion.conectar;
                    con.Open();
                    da = new SqlDataAdapter("mostrar_detallereporte", con);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da.Fill(dt);
                    con.Close();

                    repprod = new repProductosInv(); //llamo al reves
                    repprod.DataSource = dt; //llenando los datos en mi objeto de maquetacion
                    repprod.tablaProductos.DataSource = dt; //mandando los datos capturados a mi tabla de maquetacion ---recomendacion: la tabla debe ser publica
                    repprod.txtTotal.Value = INVENTARIOS.formInventarios.totalinv; //mandando un parametro a mi reporte (tiene q ser publico)

                    mireporteProd.Report = repprod; //adhiriendo mi maquetacion con mi interfaz de reporte
                    mireporteProd.RefreshReport(); //actualizo los datos al iniciar reporte
                }
                catch (Exception)
                {
                }
            }
        }

        private void mireporteProd_Load(object sender, EventArgs e)
        {
            ImprimirReporteProductos();
        }
    }
}
