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
    public class CategoriasDao
    {
        public bool InsertarCategoria(Categoria categoria)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("crear_categoria", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@nombre_cat", categoria.NombreCategoria);
                sql.Parameters.AddWithValue("@descripcion_cat", categoria.DescripcionCategoria);
                sql.Parameters.AddWithValue("@estado", categoria.Estado);
                sql.Parameters.AddWithValue("@fecha_reg", categoria.FechaRegistro);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Registrar Categoría!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void MostrarCategorias(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_categorias", ConexionBD.conectar);
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

        public bool EditarCategoria(Categoria categoria)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("editar_categoria", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@nombre_cat", categoria.NombreCategoria);
                sql.Parameters.AddWithValue("@descripcion_cat", categoria.DescripcionCategoria);
                sql.Parameters.AddWithValue("@id_cat", categoria.IdCategoria);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Editar Categoría!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool EliminarCategoria(Categoria categoria)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_categoria", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_cat", categoria.IdCategoria);
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

        public static void BuscarCategorias(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_categorias", ConexionBD.conectar);
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

        public DataTable ListarCategorias()
        {
            ConexionBD.abrir();
            SqlDataAdapter da = new SqlDataAdapter("listar_categorias", ConexionBD.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void MostrarAnterior(ref DataTable dt, int pagina)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("tabular_categorias", ConexionBD.conectar);
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

        public static void ContarCategorias(ref string contacat)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("total_categorias", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                contacat = Convert.ToString(sql.ExecuteScalar());

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
