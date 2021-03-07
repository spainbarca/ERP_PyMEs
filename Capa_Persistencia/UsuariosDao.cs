using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Persistencia;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Capa_Dominio;

namespace Capa_Persistencia
{
    public class UsuariosDao
    {
        public bool InsertarUsuario(Usuario usuario)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("crear_usuario", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@prinom_usu", usuario.PrimerNombre);
                sql.Parameters.AddWithValue("@segnom_usu", usuario.SegundoNombre);
                sql.Parameters.AddWithValue("@app_usu", usuario.ApellidoPaterno);
                sql.Parameters.AddWithValue("@apm_usu", usuario.ApellidoMaterno);
                sql.Parameters.AddWithValue("@fecha_nac", usuario.FechaNacimiento);
                sql.Parameters.AddWithValue("@genero", usuario.Genero);
                sql.Parameters.AddWithValue("@rol_usu", usuario.Rol);
                sql.Parameters.AddWithValue("@correo", usuario.Correo);

                sql.Parameters.AddWithValue("@icono", usuario.Icono);
                sql.Parameters.AddWithValue("@nom_icono", usuario.NombreIcono);

                sql.Parameters.AddWithValue("@usuario", usuario.User);
                sql.Parameters.AddWithValue("@clave", usuario.Clave);

                
                sql.Parameters.AddWithValue("@estado", usuario.Estado);

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

        public static void MostrarUsuarios(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_usuario", ConexionBD.conectar);
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

        public bool EditarUsuario(Usuario usuario)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("actualizar_usuario", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_usu", usuario.IdUsuario);
                sql.Parameters.AddWithValue("@prinom_usu", usuario.PrimerNombre);
                sql.Parameters.AddWithValue("@segnom_usu", usuario.SegundoNombre);
                sql.Parameters.AddWithValue("@app_usu", usuario.ApellidoPaterno);
                sql.Parameters.AddWithValue("@apm_usu", usuario.ApellidoMaterno);
                sql.Parameters.AddWithValue("@fecha_nac", usuario.FechaNacimiento);
                sql.Parameters.AddWithValue("@genero", usuario.Genero);
                sql.Parameters.AddWithValue("@rol_usu", usuario.Rol);
                sql.Parameters.AddWithValue("@correo", usuario.Correo);

                //MemoryStream ms = new MemoryStream();
                //pbxFoto.Image.Save(ms, pbxFoto.Image.RawFormat);
                sql.Parameters.AddWithValue("@icono", usuario.Icono);
                sql.Parameters.AddWithValue("@nom_icono", usuario.NombreIcono);

                sql.Parameters.AddWithValue("@usuario", usuario.User);
                sql.Parameters.AddWithValue("@clave", usuario.Clave);


                sql.Parameters.AddWithValue("@estado", usuario.Estado);

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

        public static void BuscarUsuarios(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_usuarios", ConexionBD.conectar);
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

        public bool EliminarUsuario(Usuario usuario)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_usuario", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_usu", usuario.IdUsuario);
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

        public static void ValidarUsuario(ref DataTable dt, Usuario usuario)
        {
            try
            {
                ConexionBD.abrir();

                SqlDataAdapter da = new SqlDataAdapter("validar_usuario", ConexionBD.conectar);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@usuario", usuario.User);
                da.SelectCommand.Parameters.AddWithValue("@clave", usuario.Clave);

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

        public DataTable ListarCorreos()
        {
            ConexionBD.abrir();
            SqlDataAdapter da = new SqlDataAdapter("listar_correos", ConexionBD.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void MostrarClave(ref string clave, Usuario usuario)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("mostrar_clave_correo", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@correo", usuario.Correo);
                clave = Convert.ToString(sql.ExecuteScalar());

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

        public static void MostrarCorreoUsuarioClick(ref string user, Usuario usuario)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("mostrar_correo_usuario", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@usuario", usuario.User);
                user = Convert.ToString(sql.ExecuteScalar());

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

        public static void MostrarFotoPerfil(ref byte[]imagen, Usuario usuario)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("mostrar_fotoperfil", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@usuario", usuario.User);
                imagen = (Byte[])sql.ExecuteScalar();

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

        public static void InvocarRol(ref string mirol, Usuario usuario)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("invocar_rol_usuario", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@usuario", usuario.User);
                mirol = Convert.ToString(sql.ExecuteScalar());

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

        public static void TabularUsuarios(ref DataTable dt, int pagina)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("tabular_usuarios", ConexionBD.conectar);
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

        public static void ContarUsuarios(ref string contausu)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("total_usuarios", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                contausu = Convert.ToString(sql.ExecuteScalar());

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
