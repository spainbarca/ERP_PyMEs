using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Capa_Soporte;

namespace Capa_Persistencia
{
    public class ConexionBD
    {
        //public static string conexion = Convert.ToString(Desencriptacion.InvocarArchivoXML());
        //public static string conexion = @"Server=sql5092.site4now.net;Database=DB_A6A216_bdbodega;User Id=DB_A6A216_bdbodega_admin;Password=Casuistica1;";
        public static string conexion = @"Data Source=DESKTOP-0FCR2FF\SQLEXPRESS;Initial Catalog=BD_I2_Bodega;Integrated Security=true";
        //public static string conexion = @"Data Source=DESKTOP-I1T18H1;Initial Catalog=BD_I2_Bodega;Integrated Security=true";

        public static SqlConnection conectar = new SqlConnection(conexion);
        public static void abrir()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
        }
        public static void cerrar()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
