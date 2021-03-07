using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Capa_Dominio;

namespace Capa_Persistencia
{
    public class DashboardsDao
    {
        public static void FrecuenciaClientes(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("ventastotales_cliente", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public DataTable ListarAño()
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("seleccionar_año_dashboard", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
                return null;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public DataTable ListarMes(string year)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("seleccionar_mes_dashboard", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@year", year);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {

                //MessageBox.Show(ex.StackTrace);
                return null;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void MostrarVentasGraficoAnual(ref DataTable dt, int year)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("graficoventas_mensual_anual", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@year", year);

                da.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void MostrarVentasGraficoMensual(ref DataTable dt, int year, int mes)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("graficoventas_mensual_mes", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@year", year);
                da.SelectCommand.Parameters.AddWithValue("@mes", mes);

                da.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }
    }
}
