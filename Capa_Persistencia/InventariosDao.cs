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
    public class InventariosDao
    {
        public static void CantidadInventario(ref string cantinv)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("contar_inventario", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                cantinv = Convert.ToString(sql.ExecuteScalar());
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void CostoInventario(ref string costoinv)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("sumar_inventario", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                costoinv = Convert.ToString(sql.ExecuteScalar());
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los inventarios");
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void MostrarInventariosBajos(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("inventarios_bajos", ConexionBD.conectar);
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

        public static void BuscarKardex(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_kardex", ConexionBD.conectar);
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

        public static void BuscarMovimientos(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_movimientos", ConexionBD.conectar);
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

        public DataTable ListarUsuarios()
        {
            ConexionBD.abrir();
            SqlDataAdapter da = new SqlDataAdapter("listar_usuarios_kardex", ConexionBD.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void FiltroAvanzadoKardex(ref DataTable dt, Inventario inventario)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("filtros_avanzados_kardex", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", inventario.Fecha);
                da.SelectCommand.Parameters.AddWithValue("@tipo", inventario.Tipo);
                da.SelectCommand.Parameters.AddWithValue("@usuario", inventario.IdUsuario);
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

        public static void FiltroAcumuladoKardex(ref DataTable dt, Inventario inventario)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("filtro_acumulado", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@fecha", inventario.Fecha);
                da.SelectCommand.Parameters.AddWithValue("@tipo", inventario.Tipo);
                da.SelectCommand.Parameters.AddWithValue("@usuario", inventario.IdUsuario);
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

        public static void MostrarProductosReporte(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("reporte_productos", ConexionBD.conectar);
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

        public bool VaciarListaDetalle()
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("vaciar_detallereporte", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Vaciar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void AutobusquedaProductos(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("autobusqueda_productos", ConexionBD.conectar);
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

        public static void MostrarProductosVencidos(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_productos_vencidos", ConexionBD.conectar);
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

        public static void MostrarProductos30Dias(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("productos_30dias", ConexionBD.conectar);
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

        public static void VencimientoDinamico(ref DataTable dt, int dias)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("vencimiento_dinamico", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@dias", dias);
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

        public static void BuscarProductoVencido(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_productos_vencidos", ConexionBD.conectar);
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

        public static void RealizarKardex(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("realizar_kardex", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id_prod", letra);
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

        public static void RealizarKardexFiltro(ref DataTable dt, string letra, int mes, int year)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("realizar_kardex_filtro", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id_prod", letra);
                da.SelectCommand.Parameters.AddWithValue("@mes", mes);
                da.SelectCommand.Parameters.AddWithValue("@year", year);
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

        public bool EliminarDetalle(Producto producto)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_detallereporte", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_prod", producto.IdProducto);
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
    }
}
