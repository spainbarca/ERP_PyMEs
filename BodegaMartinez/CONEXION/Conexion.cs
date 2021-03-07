using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BodegaMartinez.CONEXION
{
    class Conexion
    {
        //public static string conectar = Convert.ToString(Desencriptacion.InvocarArchivoXML());
        //public static string conectar = @"Server=sql5092.site4now.net;Database=DB_A6A216_bdbodega;User Id=DB_A6A216_bdbodega_admin;Password=Casuistica1;";
        public static string conectar = @"Data Source=DESKTOP-0FCR2FF\SQLEXPRESS;Initial Catalog=BD_I2_Bodega;Integrated Security=true";
        //public static string conectar = @"Data Source=DESKTOP-I1T18H1;Initial Catalog=BD_I2_Bodega;Integrated Security=true";

        public static SqlConnection conectate = new SqlConnection(conectar);
        public static void abrir()
        {
            if (conectate.State == ConnectionState.Closed)
            {
                conectate.Open();
            }
        }
        public static void cerrar()
        {
            if (conectate.State == ConnectionState.Open)
            {
                conectate.Close();
            }
        }
    }
}
