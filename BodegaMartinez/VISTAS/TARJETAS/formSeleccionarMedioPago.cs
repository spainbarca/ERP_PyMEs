using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Windows;

namespace BodegaMartinez.VISTAS.TARJETAS
{
    public partial class formSeleccionarMedioPago : Form
    {
        public formSeleccionarMedioPago()
        {
            InitializeComponent();
        }

        private void formSeleccionarMedioPago_Load(object sender, EventArgs e)
        {
            
            DibujarMediosPago();
        }

        public void DibujarMediosPago()
        {
            //idcat = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();
            SqlCommand sql = new SqlCommand();
            sql = new SqlCommand("seleccionar_mediospago", con);
            sql.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = sql.ExecuteReader();
            //flowProductos.Refresh();

            while (rdr.Read())
            {
                Label lbl1 = new Label();
                Panel pnl1 = new Panel();
                PictureBox box1 = new PictureBox();

                lbl1.Text = rdr["nombre_card"].ToString();
                lbl1.Name = rdr["id_card"].ToString();
                lbl1.Size = new Size(120, 30);
                lbl1.Font = new Font("Berlin Sans FB", 8);
                lbl1.BackColor = Color.LavenderBlush;
                lbl1.ForeColor = Color.Black;
                lbl1.Dock = DockStyle.Bottom;
                lbl1.BorderStyle = BorderStyle.FixedSingle;
                lbl1.FlatStyle = FlatStyle.Flat;
                lbl1.TextAlign = ContentAlignment.MiddleCenter;
                lbl1.Tag = rdr["id_card"].ToString();
                lbl1.Cursor = Cursors.Hand;

                pnl1.Size = new Size(120, 150);
                pnl1.BorderStyle = BorderStyle.None;
                pnl1.BackColor = Color.FromArgb(20, 20, 20);

                box1.Size = new Size(120, 120);
                box1.Dock = DockStyle.Top;
                box1.Name = rdr["nombre_card"].ToString();
                box1.BackgroundImage = null;
                byte[] bi = (byte[])rdr["imagen_card"];
                MemoryStream ms = new MemoryStream(bi);
                box1.Image = Image.FromStream(ms);
                box1.SizeMode = PictureBoxSizeMode.Zoom;
                box1.Tag = rdr["id_card"].ToString();
                box1.Cursor = Cursors.Hand;

                pnl1.Controls.Add(lbl1);
                pnl1.Controls.Add(box1);
                lbl1.BringToFront();
                flowProductos.Controls.Add(pnl1);

                lbl1.Click += new EventHandler(miEventolbl);
                box1.Click += new EventHandler(miEventobox);
            }
            con.Close();
        }

        private void miEventobox(System.Object sender, EventArgs e)
        {
            //label10.Text = ((PictureBox)sender).Tag.ToString();
            //pnlInfoProd.Visible = true;

            MENUPRINCIPAL.formMediosPago pag = Owner as MENUPRINCIPAL.formMediosPago;
            pag.lblIdCard.Text = ((PictureBox)sender).Tag.ToString();
            pag.txtNombreCard.Text = ((PictureBox)sender).Name.ToString();
            this.Close();

            //idProducto = Convert.ToInt32(((PictureBox)sender).Tag.ToString());
            //lblIdProd.Text = ((PictureBox)sender).Tag.ToString();
            ////flowProductos.Visible = false;
        }

        private void miEventolbl(System.Object sender, EventArgs e)
        {
            MENUPRINCIPAL.formMediosPago pag = Owner as MENUPRINCIPAL.formMediosPago;
            pag.lblIdCard.Text = ((Label)sender).Tag.ToString();
            pag.txtNombreCard.Text = ((Label)sender).Text.ToString();
            this.Close();

            //idProducto = Convert.ToInt32(((PictureBox)sender).Tag.ToString());
            //lblIdProd.Text = ((PictureBox)sender).Tag.ToString();
            ////flowProductos.Visible = false;
        }

        private void flowProductos_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
