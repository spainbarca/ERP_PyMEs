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
    public class CajasDao
    {
        public static void CapturarSerial(ref string capser, Caja caja)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("comparar_serial", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@serial_pc", caja.SerialPc);
                capser = Convert.ToString(sql.ExecuteScalar());

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

        public bool AgregarCaja(Caja caja)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("agregar_serial", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@descripcion", caja.Descripcion);
                sql.Parameters.AddWithValue("@tema", caja.Tema);
                sql.Parameters.AddWithValue("@serial_pc", caja.SerialPc);
                sql.Parameters.AddWithValue("@impresora_ticket", caja.ImpresoraTicket);
                sql.Parameters.AddWithValue("@impresora_a4", caja.ImpresoraA4);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Registrar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void MostrarIdCajaSerial(ref DataTable dt, Caja caja)
        {
            try
            {
                ConexionBD.abrir();

                SqlDataAdapter da = new SqlDataAdapter("mostrar_idcaja_serial", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@serial", caja.SerialPc);

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

        public static void MostrarIdCajaSerialProducto(ref string idserialprod, Caja caja)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("SELECT id_caja FROM t_caja WHERE serial_pc = '" + caja.SerialPc + "'", ConexionBD.conectar);
 
                idserialprod = Convert.ToString(sql.ExecuteScalar());

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

        public static void EstadoCaja(ref string estcaja, Caja caja)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("estado_caja", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_caja", caja.IdCaja);
                estcaja = Convert.ToString(sql.ExecuteScalar());

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

        public static void ListarCierreCajas(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("listar_cierrecajas", ConexionBD.conectar);
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
    }
}
