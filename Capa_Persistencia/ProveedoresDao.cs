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
    public class ProveedoresDao
    {
        public DataTable ListarDepartamentos()
        {
            ConexionBD.abrir();
            SqlDataAdapter da = new SqlDataAdapter("listar_departamentos", ConexionBD.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();

            da.Fill(dt);

            DataRow r = dt.NewRow();
            r[0] = null;
            r[1] = "Seleccione:";
            dt.Rows.InsertAt(r, 0);

            return dt;
        }

        public DataTable ListarProvincias(string id_dep)
        {
            ConexionBD.abrir();
            SqlDataAdapter da = new SqlDataAdapter("listar_provincias", ConexionBD.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_departamento", id_dep);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow r = dt.NewRow();
            r[0] = null;
            r[1] = "Seleccione:";
            dt.Rows.InsertAt(r, 0);

            return dt;
        }

        public DataTable ListarDistritos(string id_dep, string id_prov)
        {
            ConexionBD.abrir();
            SqlDataAdapter da = new SqlDataAdapter("listar_distritos", ConexionBD.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@id_provincia", id_prov);
            da.SelectCommand.Parameters.AddWithValue("@id_departamento", id_dep);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow r = dt.NewRow();
            r[0] = null;
            r[1] = "Seleccione:";
            dt.Rows.InsertAt(r, 0);

            return dt;
        }

        public bool InsertarProveedor(Proveedor proveedor)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("crear_proveedor", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@nombre_proveedor", proveedor.NombreProveedor);
                sql.Parameters.AddWithValue("@logo", proveedor.Logo);
                sql.Parameters.AddWithValue("@nombre_logo", proveedor.NombreLogo);
                sql.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                sql.Parameters.AddWithValue("@anexo", proveedor.Anexo);
                sql.Parameters.AddWithValue("@departamento", proveedor.Departamento);
                sql.Parameters.AddWithValue("@provincia", proveedor.Provincia);
                sql.Parameters.AddWithValue("@distrito", proveedor.Distrito);
                sql.Parameters.AddWithValue("@rubro", proveedor.Rubro);
                sql.Parameters.AddWithValue("@celular_proveedor", proveedor.Celular);
                sql.Parameters.AddWithValue("@telefono_proveedor", proveedor.Telefono);
                sql.Parameters.AddWithValue("@ruc_proveedor", proveedor.Ruc);
                sql.Parameters.AddWithValue("@vendedor", proveedor.Vendedor);
                sql.Parameters.AddWithValue("@estado", proveedor.Estado);
                sql.Parameters.AddWithValue("@fecha_reg", proveedor.FechaRegistro);

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

        public static void MostrarProveedores(ref DataTable dt)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_proveedores", ConexionBD.conectar);
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

        public bool EditarProveedor(Proveedor proveedor)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("editar_proveedor", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@nombre_proveedor", proveedor.NombreProveedor);
                sql.Parameters.AddWithValue("@logo", proveedor.Logo);
                sql.Parameters.AddWithValue("@nombre_logo", proveedor.NombreLogo);
                sql.Parameters.AddWithValue("@direccion", proveedor.Direccion);
                sql.Parameters.AddWithValue("@anexo", proveedor.Anexo);
                sql.Parameters.AddWithValue("@departamento", proveedor.Departamento);
                sql.Parameters.AddWithValue("@provincia", proveedor.Provincia);
                sql.Parameters.AddWithValue("@distrito", proveedor.Distrito);
                sql.Parameters.AddWithValue("@rubro", proveedor.Rubro);
                sql.Parameters.AddWithValue("@celular_proveedor", proveedor.Celular);
                sql.Parameters.AddWithValue("@telefono_proveedor", proveedor.Telefono);
                sql.Parameters.AddWithValue("@ruc_proveedor", proveedor.Ruc);
                sql.Parameters.AddWithValue("@vendedor", proveedor.Vendedor);
                sql.Parameters.AddWithValue("@id_proveedor", proveedor.IdProveedor);

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

        public bool RestaurarProveedor(Proveedor proveedor)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("restaurar_proveedor", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_proveedor", proveedor.IdProveedor);
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

        public bool EliminarProveedor(Proveedor proveedor)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("eliminar_proveedor", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@id_proveedor", proveedor.IdProveedor);
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

        public static void ContarProveedores(ref string contacli, int condicion)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("contar_proveedores", ConexionBD.conectar);
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

        public static void BuscarProveedores(ref DataTable dt, string letra)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("buscar_proveedores", ConexionBD.conectar);
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

        public static void TabularProveedores(ref DataTable dt, int pagina)
        {
            try
            {
                ConexionBD.abrir();
                SqlDataAdapter da = new SqlDataAdapter("tabular_proveedores", ConexionBD.conectar);
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
