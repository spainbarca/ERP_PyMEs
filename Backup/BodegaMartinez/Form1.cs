using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodegaMartinez
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPulsar_Click(object sender, EventArgs e)
        {
            //USUARIOS.formUsuarios usu = new USUARIOS.formUsuarios();
            //usu.ShowDialog();
            this.Hide();
            LOGIN.formLogin log = new LOGIN.formLogin();
            log.ShowDialog();
        }

        private void btnConocenos_Click(object sender, EventArgs e)
        {
            USUARIOS.formUsuarios usu = new USUARIOS.formUsuarios();
            usu.ShowDialog();
        }
    }
}
