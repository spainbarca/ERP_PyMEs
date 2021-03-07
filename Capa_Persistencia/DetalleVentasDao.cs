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
    public class DetalleVentasDao
    {
        public static void CondicionProducto(ref string condiprod, DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("evitar_repetido", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);
                sql.Parameters.AddWithValue("@producto", detalleVenta.IdProducto);

                condiprod = Convert.ToString(sql.ExecuteScalar());

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

        public static void ContadorVenta(ref string contaprod, DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("conta_ventareal", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);

                contaprod = Convert.ToString(sql.ExecuteScalar());

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

        public bool InsertarDetalleVenta(DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("insertar_detalleventa", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);
                sql.Parameters.AddWithValue("@id_detalleventa", detalleVenta.IdDetalleVenta);
                sql.Parameters.AddWithValue("@producto", detalleVenta.IdProducto);
                sql.Parameters.AddWithValue("@cantidad", detalleVenta.Cantidad);
                sql.Parameters.AddWithValue("@precio_unit", detalleVenta.PrecioUnitario);
                sql.Parameters.AddWithValue("@moneda", detalleVenta.Moneda);
                sql.Parameters.AddWithValue("@unidad_medida", detalleVenta.UnidadMedida);
                sql.Parameters.AddWithValue("@cant_mostrada", detalleVenta.CantidadMostrada);
                sql.Parameters.AddWithValue("@estado", detalleVenta.Estado);
                sql.Parameters.AddWithValue("@descripcion", detalleVenta.Descripcion);
                sql.Parameters.AddWithValue("@codigo", detalleVenta.Codigo);
                sql.Parameters.AddWithValue("@stock", detalleVenta.Stock);
                sql.Parameters.AddWithValue("@unidades", detalleVenta.Unidades);
                sql.Parameters.AddWithValue("@usa_inventario", detalleVenta.UsaInventario);
                sql.Parameters.AddWithValue("@costo", detalleVenta.Costo);
                sql.Parameters.AddWithValue("@precio_mayor", detalleVenta.PrecioMayor);
                sql.Parameters.AddWithValue("@cant_mayor", detalleVenta.CantidadMayor);
                sql.Parameters.AddWithValue("@precio_venta", detalleVenta.PrecioVenta);
                sql.Parameters.AddWithValue("@nivel", detalleVenta.Nivel);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show("¡Error al Registrar DetalleVenta!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void MostrarDetalleVenta(ref DataTable dt, DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_detalleventa", ConexionBD.conectar);
                da.SelectCommand.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);
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

        public bool ActualizarProductoRepetido(DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("actualizar_productorepetido", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);
                sql.Parameters.AddWithValue("@producto", detalleVenta.IdProducto);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show("¡Error al Registrar DetalleVenta!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool EliminarDetalleVenta(DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_detalleventa", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@producto", detalleVenta.IdProducto);
                sql.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);
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

        public bool BotonMas(DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("boton_mas", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@producto", detalleVenta.IdProducto);
                sql.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("¡Error al Registrar DetalleVenta!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool BotonMenos(DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("boton_menos", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@producto", detalleVenta.IdProducto);
                sql.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("¡Error al Registrar DetalleVenta!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool CambiarPrecioVenta(DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("cambiar_precioventa", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@precio_unit", detalleVenta.PrecioUnitario);
                sql.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);
                sql.Parameters.AddWithValue("@producto", detalleVenta.IdProducto); 

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show("¡Error al Registrar DetalleVenta!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool CambiarCantidad(DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("cantidad_producto", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@cantidad", detalleVenta.Cantidad);
                sql.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);
                sql.Parameters.AddWithValue("@producto", detalleVenta.IdProducto);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show("¡Error al Registrar DetalleVenta!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool ActualizarEstadoDetalle(DetalleVenta detalleVenta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("terminar_detalleventa", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_venta", detalleVenta.IdVenta);
                sql.Parameters.AddWithValue("@id_detalleventa", detalleVenta.IdDetalleVenta);
                sql.Parameters.AddWithValue("@estado", detalleVenta.Estado);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show("¡Error al Registrar DetalleVenta!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }
    }
}
