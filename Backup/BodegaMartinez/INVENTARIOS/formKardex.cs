using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodegaMartinez.INVENTARIOS
{
    public partial class formKardex : Form
    {
        public formKardex()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MENUPRINCIPAL.formMenuPrincipal men = new MENUPRINCIPAL.formMenuPrincipal();
            men.ShowDialog();
        }
    }
}
