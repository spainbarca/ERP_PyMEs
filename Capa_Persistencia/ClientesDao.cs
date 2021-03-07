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
    public class ClientesDao
    {
        public static void AutoBusquedaClientes(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("autobusqueda_clientes", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@multi", letra);
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

        public static void TabularClientes(ref DataTable dt, int pagina)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("tabular_clientes", ConexionBD.conectar);
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

        public bool InsertarCliente(Cliente cliente)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("crear_cliente", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@prinom_cli", cliente.PrimerNombre);
                sql.Parameters.AddWithValue("@segnom_cli", cliente.SegundoNombre);
                sql.Parameters.AddWithValue("@app_cli", cliente.ApellidoPaterno);
                sql.Parameters.AddWithValue("@apm_cli", cliente.ApellidoMaterno);
                sql.Parameters.AddWithValue("@fecha_cli", cliente.FechaNacimiento);
                sql.Parameters.AddWithValue("@genero", cliente.Genero);
                sql.Parameters.AddWithValue("@tipo_cli", cliente.TipoCliente);
                sql.Parameters.AddWithValue("@email", cliente.Correo);
                sql.Parameters.AddWithValue("@telefono", cliente.Telefono);
                sql.Parameters.AddWithValue("@celular", cliente.Celular);
                sql.Parameters.AddWithValue("@direccion", cliente.Direccion);
                sql.Parameters.AddWithValue("@dni", cliente.Dni);
                sql.Parameters.AddWithValue("@alias", cliente.Alias);
                sql.Parameters.AddWithValue("@foto_cli",cliente.Foto);
                sql.Parameters.AddWithValue("@nombrefoto", cliente.NombreFoto);
                sql.Parameters.AddWithValue("@estado", cliente.Estado);
                sql.Parameters.AddWithValue("@fecha_reg", cliente.FechaRegistro);

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

        public static void MostrarClientes(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_clientes", ConexionBD.conectar);
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

        public bool EditarCliente(Cliente cliente)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("editar_cliente", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@prinom_cli", cliente.PrimerNombre);
                sql.Parameters.AddWithValue("@segnom_cli", cliente.SegundoNombre);
                sql.Parameters.AddWithValue("@app_cli", cliente.ApellidoPaterno);
                sql.Parameters.AddWithValue("@apm_cli", cliente.ApellidoMaterno);
                sql.Parameters.AddWithValue("@fecha_cli", cliente.FechaNacimiento);
                sql.Parameters.AddWithValue("@genero", cliente.Genero);
                sql.Parameters.AddWithValue("@tipo_cli", cliente.TipoCliente);
                sql.Parameters.AddWithValue("@email", cliente.Correo);
                sql.Parameters.AddWithValue("@telefono", cliente.Telefono);
                sql.Parameters.AddWithValue("@celular", cliente.Celular);
                sql.Parameters.AddWithValue("@direccion", cliente.Direccion);
                sql.Parameters.AddWithValue("@dni", cliente.Dni);
                sql.Parameters.AddWithValue("@alias", cliente.Alias);
                sql.Parameters.AddWithValue("@foto_cli", cliente.Foto);
                sql.Parameters.AddWithValue("@nombrefoto", cliente.NombreFoto);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Editar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public static void BuscarClientes(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_clientes", ConexionBD.conectar);
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

        public static void ContarClientes(ref string contacli, int condicion)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("contar_clientes", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@condicion", condicion);

                contacli = Convert.ToString(sql.ExecuteScalar());

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

        public bool EliminarCliente(Cliente cliente)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_cliente", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_cli", cliente.IdCliente);
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

        public bool RestaurarCliente(Cliente cliente)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("restaurar_cliente", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_cli", cliente.IdCliente);
                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Restaurar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public bool FunarCliente(Cliente cliente)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eyectar_cliente", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_cli", cliente.IdCliente);
                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Error al Restaurar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                ConexionBD.cerrar();
            }
        }

        public DataTable ListarTipo()
        {
            ConexionBD.abrir();
            SqlDataAdapter da = new SqlDataAdapter("listar_tipocliente", ConexionBD.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
