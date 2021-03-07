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
    public class FabricasDao
    {
        public bool InsertarFabrica(Fabrica fabrica)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("crear_fabrica", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@nombre_fab", fabrica.NombreFabrica);
                sql.Parameters.AddWithValue("@descripcion_fab", fabrica.DescripcionFabrica);
                sql.Parameters.AddWithValue("@logo_fab", fabrica.LogoFabrica);
                sql.Parameters.AddWithValue("@nombrelogo_fab", fabrica.NombreLogo);
                sql.Parameters.AddWithValue("@estado", fabrica.Estado);
                sql.Parameters.AddWithValue("@fecha_reg", fabrica.FechaRegistro);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Registrar Fábrica!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void MostrarFabricas(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_fabricas", ConexionBD.conectar);
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

        public bool EditarFabrica(Fabrica fabrica)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("editar_fabrica", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_fab", fabrica.IdFabrica);
                sql.Parameters.AddWithValue("@nombre_fab", fabrica.NombreFabrica);
                sql.Parameters.AddWithValue("@descripcion_fab", fabrica.DescripcionFabrica);
                sql.Parameters.AddWithValue("@logo_fab", fabrica.LogoFabrica);
                sql.Parameters.AddWithValue("@nombrelogo_fab", fabrica.NombreLogo);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Editar Fábrica!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool EliminarFabrica(Fabrica fabrica)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_fabrica", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_fab", fabrica.IdFabrica);
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

        public DataTable ListarFabricas()
        {
            ConexionBD.abrir();
            SqlDataAdapter da = new SqlDataAdapter("listar_fabricas", ConexionBD.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void BuscarFabricas(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_fabricas", ConexionBD.conectar);
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

        public static void ContarFabricas(ref string contafab)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("total_fabricas", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                contafab = Convert.ToString(sql.ExecuteScalar());

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

        public static void TabularFabricas(ref DataTable dt, int pagina)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("tabular_fabricas", ConexionBD.conectar);
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
