using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Capa_Soporte
{
    public class Desencriptacion
    {
        static private AES aes = new AES();
        static string textoXML; //Texto de la etiqueta
        static public string micifrado; //nombre de la etiqueta
        static public string llave = "Alekséi.2020";

        public static object InvocarArchivoXML()
        {
            XmlDocument docxml = new XmlDocument();             //Invoco el archivo con extension .xml
            docxml.Load("cadenacifrada.xml");                   // Cargar el archivo con la ruta especificada
            XmlElement principal = docxml.DocumentElement;      //Representa el tipo de elemento
            textoXML = principal.Attributes[0].Value;           //Lee el valor de la primera fila
            micifrado = (aes.Decrypt(textoXML, llave, 256));    //Capturo ese valor

            return micifrado;
            //cifrado=Data source=DESKTOP-3K3977G\SQLEXPRESS;Initial Catalog=BD_I2_Bodega;Integrated Security=True
        }

        //public static object UsuarioEncrip()
        //{
        //    XmlDocument doc = new XmlDocument();
        //    label root = new label();

        //    return micifrado;
        //}

        //public static double() esto devuelve un numero decimal
        //public static int     esto devuelve un numero entero
        //public static string  esto devuelvo una cadena
        //public static object  esto devuelve un archivo
    }
}
