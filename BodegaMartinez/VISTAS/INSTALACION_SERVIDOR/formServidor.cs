using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodegaMartinez.VISTAS.INSTALACION_SERVIDOR
{
    public partial class formServidor : Form
    {
        public formServidor()
        {
            InitializeComponent();
        }

        private void btnSecundaria_Click(object sender, EventArgs e)
        {
            Dispose();
            VISTAS.CAJA.formNuevaCaja ncaj = new VISTAS.CAJA.formNuevaCaja();
            ncaj.ShowDialog();
        }

        private void btnPrimaria_Click(object sender, EventArgs e)
        {
            Dispose();
            INSTALACION_SERVIDOR.formSQLServer sql = new formSQLServer();
            sql.ShowDialog();
        }
    }
}
