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
    public class MarcasDao
    {
        public static void MostrarMarcas(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_marcas", ConexionBD.conectar);
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

        public static void BuscarMarcas(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_marcas", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@multi", letra);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool InsertarMarca(Marca marca)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("crear_marca", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@nombre_mar", marca.NombreMarca);
                sql.Parameters.AddWithValue("@id_fab", marca.IdFabrica);
                sql.Parameters.AddWithValue("@logo_mar", marca.LogoMarca);
                sql.Parameters.AddWithValue("@nombrelogo_mar", marca.NombreLogo);
                sql.Parameters.AddWithValue("@estado", marca.Estado);
                sql.Parameters.AddWithValue("@fecha_reg", marca.FechaRegistro);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Registrar Marca!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool EditarMarca(Marca marca)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("editar_marca", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_mar", marca.IdMarca);
                sql.Parameters.AddWithValue("@nombre_mar", marca.NombreMarca);
                sql.Parameters.AddWithValue("@id_fab", marca.IdFabrica);
                sql.Parameters.AddWithValue("@logo_mar", marca.LogoMarca);
                sql.Parameters.AddWithValue("@nombrelogo_mar", marca.NombreLogo);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Registrar Marca!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool EliminarMarca(Marca marca)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_marca", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_mar", marca.IdMarca);
                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Eliminar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void ContarMarcas(ref string contamar)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("total_marcas", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                contamar = Convert.ToString(sql.ExecuteScalar());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void TabularMarcas(ref DataTable dt, int pagina)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("tabular_marcas", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@pagina", pagina);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }
    }
}
