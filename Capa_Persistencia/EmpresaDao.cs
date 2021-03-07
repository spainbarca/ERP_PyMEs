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
    public class EmpresaDao
    {
        public bool InsertarEmpresa(Empresa empresa)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("crear_empresa", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@nombre_empresa", empresa.Nombre);
                sql.Parameters.AddWithValue("@logo", empresa.Logo);
                sql.Parameters.AddWithValue("@impuesto", empresa.Impuesto);
                sql.Parameters.AddWithValue("@porc_impuesto", empresa.PorcImpuesto);
                sql.Parameters.AddWithValue("@moneda", empresa.Moneda);
                sql.Parameters.AddWithValue("@trabaja_impuesto", empresa.Trabaja);
                sql.Parameters.AddWithValue("@modo_busqueda", empresa.ModoBusqueda);
                sql.Parameters.AddWithValue("@carpeta_backup", empresa.CarpetaBackup);
                sql.Parameters.AddWithValue("@correo_reportes", empresa.CorreoReportes);
                sql.Parameters.AddWithValue("@ultimafecha_backup", empresa.UltimaFecha);
                sql.Parameters.AddWithValue("@frecuencia_backup", empresa.Frecuencia);
                sql.Parameters.AddWithValue("@estado", empresa.Estado);
                sql.Parameters.AddWithValue("@tipo_empresa", empresa.TipoEmpresa);
                sql.Parameters.AddWithValue("@pais", empresa.Pais);
                sql.Parameters.AddWithValue("@redondeo_total", empresa.Redondeo);

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

        public static void ContarEmpresa(ref string contacli)
        {
            try
            {
                ConexionBD.abrir();

                SqlCommand sql = new SqlCommand("contar_empresa", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

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
    }
}
