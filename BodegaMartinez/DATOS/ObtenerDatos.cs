using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BodegaMartinez.DATOS
{
    class ObtenerDatos
    {
        public static void Productos5MasVendidos(ref DataTable dt)
        {
            try
            {
                CONEXION.Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("productos5_masvendidos", CONEXION.Conexion.conectar);

                //da.SelectCommand.Parameters.AddWithValue("@fecha", DateTime.Today);
                da.Fill(dt);
                CONEXION.Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void MostrarVentasGrafica(ref DataTable dt)
        {
            try
            {
                CONEXION.Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("graficoventas_mensual", CONEXION.Conexion.conectar);
                da.Fill(dt);
                CONEXION.Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void MostrarVentasGrafica6Meses(ref DataTable dt)
        {
            try
            {
                CONEXION.Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("graficoventas_mensual_historico", CONEXION.Conexion.conectar);
                da.Fill(dt);
                CONEXION.Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        public static void MostrarVentasGraficaFechas(ref DataTable dt, DateTime fi, DateTime ff)
        {
            try
            {
                CONEXION.Conexion.abrir();
                SqlDataAdapter da = new SqlDataAdapter("graficoventas_avanzado", CONEXION.Conexion.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha_inicial", fi);
                da.SelectCommand.Parameters.AddWithValue("@fecha_final", ff);

                da.Fill(dt);
                CONEXION.Conexion.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
