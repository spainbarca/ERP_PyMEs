using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodegaMartinez.VISTAS.MENUPRINCIPAL
{
    public partial class formConocenos : Form
    {
        public formConocenos()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void btnMapa_Click(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnMapa_Click_1(object sender, EventArgs e)
        {
            string calle = txtCalle.Text;
            string ciudad = txtCiudad.Text;
            string estado = txtEstado.Text;
            string postal = txtPostal.Text;

            StringBuilder queryadress = new StringBuilder();
            queryadress.Append("http://google.com/maps?q=");

            if (calle!=string.Empty)
            {
                queryadress.Append(calle + "," + "+");
            }
            if (ciudad != string.Empty)
            {
                queryadress.Append(ciudad + "," + "+");
            }
            if (estado != string.Empty)
            {
                queryadress.Append(estado + "," + "+");
            }
            if (postal != string.Empty)
            {
                queryadress.Append(postal + "," + "+");
            }

            webBrowser1.Navigate(queryadress.ToString());

            panel1.Visible = false;
        }
    }
}
