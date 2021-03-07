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
    public class VentasDao
    {
        public static void SumatoriaVenta(ref string suminver, Venta venta)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("sumatoria_venta", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_venta", venta.IdVenta);

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

        public static void TraerIdVenta(ref string miidventa)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("traer_idventa", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                miidventa = Convert.ToString(sql.ExecuteScalar());

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

        public bool AperturarVenta(Venta venta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("aperturar_venta", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@monto_total", venta.MontoTotal);
                sql.Parameters.AddWithValue("@estado", venta.Estado);

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

        public static void GenerarSerie(ref int lastventa)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("generar_serie", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                lastventa = Convert.ToInt32(sql.ExecuteScalar());

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

        public bool ProcesarVenta(Venta venta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("procesar_venta", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_venta", venta.IdVenta);
                sql.Parameters.AddWithValue("@cliente", venta.IdCliente);
                sql.Parameters.AddWithValue("@fecha_venta", venta.FechaVenta);
                sql.Parameters.AddWithValue("@num_doc", venta.NumeroDoc);
                sql.Parameters.AddWithValue("@monto_total", venta.MontoTotal);
                sql.Parameters.AddWithValue("@subtotal", venta.Subtotal);
                sql.Parameters.AddWithValue("@descuento", venta.Descuento);
                sql.Parameters.AddWithValue("@tipo_pago", venta.TipoPago);
                sql.Parameters.AddWithValue("@estado", venta.Estado);
                sql.Parameters.AddWithValue("@boleta", venta.Boleta);
                sql.Parameters.AddWithValue("@usuario", venta.IdUsuario);
                sql.Parameters.AddWithValue("@fecha_pago", venta.FechaPago);
                sql.Parameters.AddWithValue("@accion", venta.Accion);
                sql.Parameters.AddWithValue("@pago_parcial", venta.PagoParcial);
                sql.Parameters.AddWithValue("@porc_igv", venta.PorcIgv);
                sql.Parameters.AddWithValue("@caja", venta.IdCaja);
                sql.Parameters.AddWithValue("@referencia_card", venta.ReferenciaTarjeta);
                sql.Parameters.AddWithValue("@efectivo", venta.Efectivo); //efectivo=dinero pagado en primera instancia
                sql.Parameters.AddWithValue("@credito", venta.Credito);
                sql.Parameters.AddWithValue("@tarjeta", venta.Tarjeta);

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

        public bool EliminarVenta(Venta venta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_venta", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_venta", venta.IdVenta);
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

        public static void MostrarVentasRango(ref DataTable dt, Venta venta)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_ventasrango", ConexionBD.conectar);
                da.SelectCommand.Parameters.AddWithValue("@fechadesde", venta.FechaVenta);
                da.SelectCommand.Parameters.AddWithValue("@fechahasta", venta.FechaPago);
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

        public static void MostrarVentasTodas(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_ventastodas", ConexionBD.conectar);
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

        public static void VerHistorial(ref DataTable dt, Venta venta)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrarventas_historial", ConexionBD.conectar);
                da.SelectCommand.Parameters.AddWithValue("@id_venta", venta.IdVenta);
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

        public bool VentaEspera(Venta venta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("poner_ventaespera", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_venta", venta.IdVenta);
                sql.Parameters.AddWithValue("@fecha_venta", venta.FechaVenta);
                sql.Parameters.AddWithValue("@num_doc", venta.NumeroDoc);
                sql.Parameters.AddWithValue("@monto_total", venta.MontoTotal);
                sql.Parameters.AddWithValue("@subtotal", venta.Subtotal);
                sql.Parameters.AddWithValue("@descuento", venta.Descuento);
                sql.Parameters.AddWithValue("@estado", venta.Estado);
                sql.Parameters.AddWithValue("@usuario", venta.IdUsuario);
                sql.Parameters.AddWithValue("@accion", venta.Accion);

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

        public static void ContadorVentasEspera(ref string contaespera)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("total_ventasespera", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                contaespera = Convert.ToString(sql.ExecuteScalar());

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

        public static void MostrarVentasEspera(ref DataTable dt, Venta venta)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_ventasespera", ConexionBD.conectar);
                da.SelectCommand.Parameters.AddWithValue("@fechadesde", venta.FechaVenta);
                da.SelectCommand.Parameters.AddWithValue("@fechahasta", venta.FechaPago);
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

        public static void MostrarVentasEsperaTodas(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrartodas_ventaespera", ConexionBD.conectar);
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

        public static void MostrarDetalleVentaEspera(ref DataTable dt, Venta venta)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_detalleventaespera", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@id_venta", venta.IdVenta);

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

        public bool EliminarVentaEspera(Venta venta)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_ventaespera", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_venta", venta.IdVenta);
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
