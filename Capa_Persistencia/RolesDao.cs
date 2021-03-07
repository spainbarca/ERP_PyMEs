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
    public class RolesDao
    {
        //public void ListarRoles(ComboBox cb)
        //{
        //    try
        //    {
        //        //ConexionBD.abrir();
        //        //SqlDataAdapter da = new SqlDataAdapter("listar_roles", ConexionBD.conectar);
        //        //da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //        //da.Fill(cb);
        //        ////cbxRol.DisplayMember = "nombre_rol";
        //        ////cbxRol.ValueMember = "id_rol";
        //        ////cbxRol.DataSource = dt;
        //        ///

        //        ConexionBD.abrir();
        //        SqlDataReader rdr;
        //        SqlCommand sql = new SqlCommand("listar_Roles", ConexionBD.conectar);
        //        sql.CommandType = CommandType.StoredProcedure;

        //        rdr=sql.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            cb.Items.Add(rdr["nombre_rol"].ToString());
        //            cb.ValueMember.Aggregate<1,2,3>;
        //        }
        //        cb.SelectedIndex = 0;
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("¡Error al Editar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        //MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        ConexionBD.cerrar();
        //    }
        //}

        public DataTable ListarRoles()
        {
            //try
            //{
            //    ConexionBD.abrir();
            //    SqlDataAdapter da = new SqlDataAdapter("listar_roles", ConexionBD.conectar);
            //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    return dt;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("¡Error al Editar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    ConexionBD.cerrar();
            //}
            ConexionBD.abrir();
            SqlDataAdapter da = new SqlDataAdapter("listar_roles", ConexionBD.conectar);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
