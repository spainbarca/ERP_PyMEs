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
    public partial class formSQLServer : Form
    {
        public formSQLServer()
        {
            InitializeComponent();
        }

        private void formSQLServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
