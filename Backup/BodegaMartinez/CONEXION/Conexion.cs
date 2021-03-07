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
        public static string conectar = Convert.ToString(Desencriptacion.InvocarArchivoXML());
        //public static string conectar = @"Server=sql5092.site4now.net;Database=DB_A6971E_bdi2bodega;User Id=DB_A6971E_bdi2bodega_admin;Password=Integrador.02;";

        public static SqlConnection conectate = new SqlConnection(conectar);
        internal void abrir()
        {
            if (conectate.State == ConnectionState.Closed)
            {
                conectate.Open();
            }
        }
        internal void cerrar()
        {
            if (conectate.State == ConnectionState.Open)
            {
                conectate.Close();
            }
        }
    }
}
