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
    public class CierreCajasDao
    {
        public bool AperturarCaja(CierreCaja cierreCaja)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand sql = new SqlCommand("apertura_cajainicial", ConexionBD.conectar);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@fecha_inicio", cierreCaja.FechaInicio);
                sql.Parameters.AddWithValue("@fecha_fin", cierreCaja.FechaFin);
                sql.Parameters.AddWithValue("@fecha_cierre", cierreCaja.FechaCierre);
                sql.Parameters.AddWithValue("@ingresos", cierreCaja.Ingresos);
                sql.Parameters.AddWithValue("@egresos", cierreCaja.Egresos);
                sql.Parameters.AddWithValue("@saldo", cierreCaja.Saldo);
                sql.Parameters.AddWithValue("@id_usuario", cierreCaja.IdUsuario );
                sql.Parameters.AddWithValue("@total_real", cierreCaja.TotalReal);
                sql.Parameters.AddWithValue("@estado", cierreCaja.Estado);
                sql.Parameters.AddWithValue("@diferencia", cierreCaja.Diferencia);
                sql.Parameters.AddWithValue("@id_caja", cierreCaja.IdCaja);

                sql.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("¡Caja ya aperturada!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
