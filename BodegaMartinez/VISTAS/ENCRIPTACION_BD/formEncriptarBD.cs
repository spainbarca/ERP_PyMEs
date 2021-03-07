using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace BodegaMartinez.ENCRIPTACION_BD
{
    public partial class formEncriptarBD : Form
    {
        private CONEXION.AES aes = new CONEXION.AES();
        public formEncriptarBD()
        { 
            InitializeComponent();  
        }   

        public void GuardaXml(object micifrado)
        {
            XmlDocument docxml = new XmlDocument();                             //instancia del XML
            docxml.Load("cadenacifrada.xml");                                   //cargo el archivo xml
            XmlElement principal = docxml.DocumentElement;                      //ingresoalatributo
            principal.Attributes[0].Value = Convert.ToString(micifrado);         // convierto mi cifrado a string
            XmlTextWriter writer = new XmlTextWriter("cadenacifrada.xml", null); //leo el archivo
            writer.Formatting = Formatting.Indented;                             //reconoce sin alterar los espacios
            docxml.Save(writer);                                                 //guarda el arvhivo
            writer.Close();                                                      //cierra el archivo
        }

        public string micifrado;

        public void LeerXml()
        {
            try
            {
                XmlDocument docxml = new XmlDocument();
                docxml.Load("cadenacifrada.xml");
                XmlElement principal = docxml.DocumentElement;
                micifrado = principal.Attributes[0].Value;
                txtCadenaConexion.Text = (aes.Decrypt(micifrado, CONEXION.Desencriptacion.llave, int.Parse("256")));
            }
            catch (Exception)
            {
                EjecutarXML();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            EjecutarXML();
        }

        private void EjecutarXML()
        {
            try
            {
                GuardaXml(aes.Encrypt(txtCadenaConexion.Text, CONEXION.Desencriptacion.llave, Convert.ToInt32("256")));
                MessageBox.Show("Conexión realizada correctamente", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception)
            {
                MessageBox.Show("Sin conexion a la Base de datos", "Conexion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formEncriptarBD_Load(object sender, EventArgs e)
        {
            LeerXml();
        }
    }
}
