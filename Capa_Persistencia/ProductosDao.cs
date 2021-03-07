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
    public class ProductosDao
    {
        public bool InsertarProducto(Producto producto, Inventario inventario)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("crear_producto", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@nombre_prod", producto.NombreProducto);
                sql.Parameters.AddWithValue("@imagen_prod", producto.ImagenProducto);
                sql.Parameters.AddWithValue("@nombre_imagen", producto.NombreImagen);
                sql.Parameters.AddWithValue("@id_categoria", producto.IdCategoria);
                sql.Parameters.AddWithValue("@id_subcategoria", producto.IdSubcategoria);
                sql.Parameters.AddWithValue("@id_marca", producto.IdMarca);
                sql.Parameters.AddWithValue("@usa_inventario", producto.UsaInventario);
                sql.Parameters.AddWithValue("@stock", producto.Stock);
                sql.Parameters.AddWithValue("@stock_min", producto.StockMinimo);
                sql.Parameters.AddWithValue("@fecha_venc", producto.FechaVencimiento);
                sql.Parameters.AddWithValue("@precio_compra", producto.PrecioCompra);
                sql.Parameters.AddWithValue("@precio_venta", producto.PrecioVenta);
                sql.Parameters.AddWithValue("@codigo", producto.Codigo);
                sql.Parameters.AddWithValue("@precio_mayor", producto.PrecioMayor);
                sql.Parameters.AddWithValue("@cant_mayor", producto.CantidadMayor);
                sql.Parameters.AddWithValue("@impuesto", producto.Impuesto);
                sql.Parameters.AddWithValue("@estadoprod", producto.Estado);
                sql.Parameters.AddWithValue("@fecha_reg", producto.FechaRegistro);
                sql.Parameters.AddWithValue("@tipo_prod", producto.TipoProducto);

                sql.Parameters.AddWithValue("@fecha", inventario.Fecha);
                sql.Parameters.AddWithValue("@motivo", inventario.Motivo);
                sql.Parameters.AddWithValue("@cantidad", inventario.Cantidad);
                sql.Parameters.AddWithValue("@usuario", inventario.IdUsuario);
                sql.Parameters.AddWithValue("@tipo", inventario.Tipo);
                sql.Parameters.AddWithValue("@estado", inventario.Estado);
                sql.Parameters.AddWithValue("@id_caja", inventario.IdCaja);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Registrar Producto!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void MostrarProductos(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_productos", ConexionBD.conectar);
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

        public bool EditarProducto(Producto producto)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("editar_producto", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_prod", producto.IdProducto);
                sql.Parameters.AddWithValue("@nombre_prod", producto.NombreProducto);
                sql.Parameters.AddWithValue("@imagen_prod", producto.ImagenProducto);
                sql.Parameters.AddWithValue("@nombre_imagen", producto.NombreImagen);
                sql.Parameters.AddWithValue("@id_categoria", producto.IdCategoria);
                sql.Parameters.AddWithValue("@id_subcategoria", producto.IdSubcategoria);
                sql.Parameters.AddWithValue("@id_marca", producto.IdMarca);
                sql.Parameters.AddWithValue("@precio_compra", producto.PrecioCompra);
                sql.Parameters.AddWithValue("@precio_venta", producto.PrecioVenta);
                sql.Parameters.AddWithValue("@codigo", producto.Codigo);
                sql.Parameters.AddWithValue("@precio_mayor", producto.PrecioMayor);
                sql.Parameters.AddWithValue("@cant_mayor", producto.CantidadMayor);
                sql.Parameters.AddWithValue("@impuesto", producto.Impuesto);
                sql.Parameters.AddWithValue("@tipo_prod", producto.TipoProducto);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("¡Error al Editar Producto!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool EliminarProducto(Producto producto)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_producto", ConexionBD.conectar);
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

        public static void ContarProductos(ref string contaprod)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("contar_productos", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

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

        public static void SumarInversion(ref string suminver)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("sumar_inversion", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                suminver = Convert.ToString(sql.ExecuteScalar());

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

        public static void BuscarProductos(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_productos", ConexionBD.conectar);
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

        public static void GenerarCodigoBarras(ref double codebar)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("generar_codigobarras", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                codebar = Convert.ToDouble(sql.ExecuteScalar()) + 1;
            }
            catch (Exception)
            {
                codebar = 1;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void TabularProductos(ref DataTable dt, int pagina)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("tabular_productos", ConexionBD.conectar);
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

        public bool InsertarExcel(Producto producto, Inventario inventario)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("insertar_producto_importacion", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@nombre_prod", producto.NombreProducto);
                sql.Parameters.AddWithValue("@imagen_prod", producto.ImagenProducto);
                sql.Parameters.AddWithValue("@nombre_imagen", producto.NombreImagen);
                sql.Parameters.AddWithValue("@id_categoria", producto.IdCategoria);
                sql.Parameters.AddWithValue("@id_subcategoria", producto.IdSubcategoria);
                sql.Parameters.AddWithValue("@id_marca", producto.IdMarca);
                sql.Parameters.AddWithValue("@usa_inventario", producto.UsaInventario);
                sql.Parameters.AddWithValue("@stock", producto.Stock);
                sql.Parameters.AddWithValue("@stock_min", producto.StockMinimo);
                sql.Parameters.AddWithValue("@fecha_venc", producto.FechaVencimiento);
                sql.Parameters.AddWithValue("@precio_compra", producto.PrecioCompra);
                sql.Parameters.AddWithValue("@precio_venta", producto.PrecioVenta);
                sql.Parameters.AddWithValue("@codigo", producto.Codigo);
                sql.Parameters.AddWithValue("@precio_mayor", producto.PrecioMayor);
                sql.Parameters.AddWithValue("@cant_mayor", producto.CantidadMayor);
                sql.Parameters.AddWithValue("@impuesto", producto.Impuesto);
                sql.Parameters.AddWithValue("@estadoprod", producto.Estado);
                sql.Parameters.AddWithValue("@fecha_reg", producto.FechaRegistro);
                sql.Parameters.AddWithValue("@tipo_prod", producto.TipoProducto);

                sql.Parameters.AddWithValue("@fecha", inventario.Fecha);
                sql.Parameters.AddWithValue("@motivo", inventario.Motivo);
                sql.Parameters.AddWithValue("@cantidad", inventario.Cantidad);
                sql.Parameters.AddWithValue("@usuario", inventario.IdUsuario);
                sql.Parameters.AddWithValue("@tipo", inventario.Tipo);
                sql.Parameters.AddWithValue("@estado", inventario.Estado);
                sql.Parameters.AddWithValue("@id_caja", inventario.IdCaja);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Importar productos!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void AutobusquedaVentas(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("autobusqueda_ventas", ConexionBD.conectar);
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

        public static void ContarSubcategoriaCatalogo(ref string contasubcat, int subcat)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("contar_subcategoriascatalogo", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_subcategoria", subcat);

                contasubcat = Convert.ToString(sql.ExecuteScalar()); 

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

        public static void ContarCategoriaCatalogo(ref string contacat, int cat)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("contar_categoriascatalogo", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_categoria", cat);

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

        public bool InsertarDetalleReporte(Producto producto)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("insertar_detallereporte", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@idprod_rep", producto.IdProducto);
                sql.Parameters.AddWithValue("@cod_rep", producto.Codigo);
                sql.Parameters.AddWithValue("@prod_rep", producto.NombreProducto);
                sql.Parameters.AddWithValue("@costo_rep", producto.PrecioCompra);
                sql.Parameters.AddWithValue("@precio_rep", producto.PrecioVenta);
                sql.Parameters.AddWithValue("@stock_rep", producto.Stock);
                sql.Parameters.AddWithValue("@minimo_rep", producto.StockMinimo);
                sql.Parameters.AddWithValue("@total_rep", producto.Total);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Registrar Producto!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void MostrarDetalleProductos(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_detallereporte", ConexionBD.conectar);
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
