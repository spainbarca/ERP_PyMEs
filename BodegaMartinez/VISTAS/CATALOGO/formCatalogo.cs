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
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;

namespace BodegaMartinez.VISTAS.CATALOGO
{
    public partial class formCatalogo : Form
    {
        public formCatalogo()
        {
            InitializeComponent();
        }

        private void formCatalogo_Load(object sender, EventArgs e)
        {
            //MostrarListaClientes();
            //Limpiar();
            DibujarCategorias();
        }

        int idcat;
        int idsubcat;
        string nombrecat;
        string nombreprod;
        string unidades;
        int contaStockDetalle;
        int idProducto;
        int idCliente;
        int idUsuario;
        int idPedido;
        int idDetallePedido;
        int conta;
        int idCaja;
        int txtpantalla;
        int lblStockProductos;
        string tipoBusqueda;
        int total;
        string condicion;

        public void DibujarCategorias()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();
            SqlCommand sql = new SqlCommand();
            sql = new SqlCommand("SELECT * from t_categorias WHERE t_categorias.estado='ACTIVADO' ORDER BY nombre_cat ASC", con);
            SqlDataReader rdr = sql.ExecuteReader();

            while (rdr.Read())
            {
                //objeto + nombre = new objeto()

                Button btnMiBoton = new Button();

                string nombre = null;
                nombre = "Micat" + rdr["id_cat"].ToString();

                btnMiBoton.Size = new Size(146, 35);
                btnMiBoton.Name = nombre;
                btnMiBoton.Font = new Font("Berlin Sans FB Demi", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnMiBoton.BackColor = Color.Black;
                btnMiBoton.ForeColor = SystemColors.ButtonHighlight;
                btnMiBoton.Location = new Point(3, 3);
                btnMiBoton.TextAlign = ContentAlignment.MiddleCenter;
                btnMiBoton.Text = rdr["nombre_cat"].ToString();
                btnMiBoton.Tag = rdr["id_cat"].ToString();
                btnMiBoton.UseVisualStyleBackColor = false;
                btnMiBoton.Cursor = Cursors.Hand;

                flowCategorias.Controls.Add(btnMiBoton);

                btnMiBoton.Click += new EventHandler(btnMiBoton_Click);
            }
            con.Close();
        }

        string contacat;

        private void btnMiBoton_Click(object sender, EventArgs e)
        {
            pnlTabulacion.Visible = true;
            idcat = Convert.ToInt32(((Button)sender).Tag.ToString());
            lblIdCategoria.Text = ((Button)sender).Tag.ToString();
            flowProductos.Visible = true;
            this.flowProductos.Controls.Clear();
            DibujarProductosCategorias();
            this.flowSubcategorias.Controls.Clear();
            DibujarSubcategorias();


            try
            {
                ProductosDao.ContarCategoriaCatalogo(ref contacat, idcat);

                lblEtiquetaCat.Text = "Total de " + ((Button)sender).Text.ToString() + " :";
                lblCantidadCat.Text = contacat;
                lblEtiquetaSubcat.Text = "-";
                lblCantidadSubcat.Text = "-";
                total = Convert.ToInt32(contacat);
                condicion = "categoria";
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las subcategorías");
            }

            ConteoDataTable();
            ValidarPaginador();
            txtPagActual.Text = "1";
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = true;
        }


        public void DibujarProductosCategorias()
        {
            //idcat = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();
            SqlCommand sql = new SqlCommand();
            sql = new SqlCommand("mostrar_catalogo_categoria", con);
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.AddWithValue("@id_categoria", idcat);


            SqlDataReader rdr = sql.ExecuteReader();
            //flowProductos.Refresh();

            while (rdr.Read())
            {
                Label lbl1 = new Label();
                Panel pnl1 = new Panel();
                PictureBox box1 = new PictureBox();

                lbl1.Text = rdr["nombre_prod"].ToString();
                lbl1.Name = rdr["id_prod"].ToString();
                lbl1.Size = new Size(120, 30);
                lbl1.Font = new Font("Berlin Sans FB", 8);
                lbl1.BackColor = Color.LavenderBlush;
                lbl1.ForeColor = Color.Black;
                lbl1.Dock = DockStyle.Bottom;
                lbl1.BorderStyle = BorderStyle.FixedSingle;
                lbl1.FlatStyle = FlatStyle.Flat;
                lbl1.TextAlign = ContentAlignment.MiddleCenter;
                lbl1.Tag = rdr["id_prod"].ToString();
                lbl1.Cursor = Cursors.Hand;

                pnl1.Size = new Size(120, 150);
                pnl1.BorderStyle = BorderStyle.None;
                pnl1.BackColor = Color.FromArgb(20, 20, 20);

                box1.Size = new Size(120, 120);
                box1.Dock = DockStyle.Top;
                box1.BackgroundImage = null;
                byte[] bi = (byte[])rdr["imagen_prod"];
                MemoryStream ms = new MemoryStream(bi);
                box1.Image = Image.FromStream(ms);
                box1.SizeMode = PictureBoxSizeMode.Zoom;
                box1.Tag = rdr["id_prod"].ToString();
                box1.Cursor = Cursors.Hand;

                pnl1.Controls.Add(lbl1);
                pnl1.Controls.Add(box1);
                lbl1.BringToFront();
                flowProductos.Controls.Add(pnl1);

                lbl1.Click += new EventHandler(miEventolbl);
                box1.Click += new EventHandler(miEventobox);
            }
            con.Close();
            ConteoDataTable();
            ValidarPaginador();
            txtPagActual.Text = "1";
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = true;
        }


        private void PaginarCatalogoProductos(int pagina)
        {
            //idcat = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();
            SqlCommand sql = new SqlCommand();

            if (condicion == "categoria")
            {
                sql = new SqlCommand("tabular_catalogo_categorias", con);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_categoria", idcat);
                sql.Parameters.AddWithValue("@pagina", pagina);
            }
            else if (condicion == "subcategoria")
            {
                sql = new SqlCommand("tabular_catalogo_subcategorias", con);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_categoria", idcat);
                sql.Parameters.AddWithValue("@id_subcategoria", idsubcat);
                sql.Parameters.AddWithValue("@pagina", pagina);
            }

            SqlDataReader rdr = sql.ExecuteReader();
            //flowProductos.Refresh();

            while (rdr.Read())
            {
                Label lbl1 = new Label();
                Panel pnl1 = new Panel();
                PictureBox box1 = new PictureBox();

                lbl1.Text = rdr["nombre_prod"].ToString();
                lbl1.Name = rdr["id_prod"].ToString();
                lbl1.Size = new Size(120, 30);
                lbl1.Font = new Font("Berlin Sans FB", 8);
                lbl1.BackColor = Color.LavenderBlush;
                lbl1.ForeColor = Color.Black;
                lbl1.Dock = DockStyle.Bottom;
                lbl1.BorderStyle = BorderStyle.FixedSingle;
                lbl1.FlatStyle = FlatStyle.Flat;
                lbl1.TextAlign = ContentAlignment.MiddleCenter;
                lbl1.Tag = rdr["id_prod"].ToString();
                lbl1.Cursor = Cursors.Hand;

                pnl1.Size = new Size(120, 150);
                pnl1.BorderStyle = BorderStyle.None;
                pnl1.BackColor = Color.FromArgb(20, 20, 20);

                box1.Size = new Size(120, 120);
                box1.Dock = DockStyle.Top;
                box1.BackgroundImage = null;
                byte[] bi = (byte[])rdr["imagen_prod"];
                MemoryStream ms = new MemoryStream(bi);
                box1.Image = Image.FromStream(ms);
                box1.SizeMode = PictureBoxSizeMode.Zoom;
                box1.Tag = rdr["id_prod"].ToString();
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

            idProducto = Convert.ToInt32(((PictureBox)sender).Tag.ToString());
            lblIdProd.Text = ((PictureBox)sender).Tag.ToString();
            flowProductos.Visible = false;
            pnlTabulacion.Visible = false;
            //pnlInfoProd.Visible = true;
            RellenarCampos();
            //panel1.Visible = false;
            //MostrarPermisos();
        }

        private void miEventolbl(System.Object sender, EventArgs e)
        {
            idProducto = Convert.ToInt32(((Label)sender).Tag.ToString());
            lblIdProd.Text = ((Label)sender).Tag.ToString();
            flowProductos.Visible = false;
            pnlTabulacion.Visible = false;
            //pnlInfoProd.Visible = true;
            //nombreprod = ((Label)sender).Text;
            //pnlInfoProd.Visible = true;
            //RellenarCampos();
            //panel1.Visible = false;
            //MostrarPermisos();
        }

        public void DibujarSubcategorias()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();
            SqlCommand sql = new SqlCommand();
            sql = new SqlCommand("select * from t_subcategorias where id_cat=" + idcat + " AND t_subcategorias.estado='ACTIVADO' ORDER BY nombre_subcat ASC", con);
            SqlDataReader rdr = sql.ExecuteReader();

            flowSubcategorias.Visible = true;

            while (rdr.Read())
            {
                //objeto + nombre = new objeto()

                Button btnMiBotonSub = new Button();

                string name = null;
                name = "Misubcat" + rdr["id_subcat"].ToString();

                btnMiBotonSub.MinimumSize = new Size(90, 33);
                btnMiBotonSub.AutoSize = true;
                btnMiBotonSub.Name = name;
                btnMiBotonSub.Font = new Font("Berlin Sans FB Demi", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                btnMiBotonSub.BackColor = SystemColors.HotTrack;
                btnMiBotonSub.ForeColor = Color.White;
                btnMiBotonSub.Location = new Point(1, 1);
                btnMiBotonSub.Margin = new Padding(5);
                btnMiBotonSub.TabIndex = 1;
                btnMiBotonSub.TextAlign = ContentAlignment.MiddleCenter;
                btnMiBotonSub.Text = rdr["nombre_subcat"].ToString();
                btnMiBotonSub.Tag = rdr["id_subcat"].ToString();
                btnMiBotonSub.UseVisualStyleBackColor = false;
                btnMiBotonSub.Cursor = Cursors.Hand;

                flowSubcategorias.Controls.Add(btnMiBotonSub);

                btnMiBotonSub.Click += new EventHandler(btnMiBotonSub_Click);
            }
            con.Close();
        }

        string contasubcat;

        private void btnMiBotonSub_Click(object sender, EventArgs e)
        {
            pnlTabulacion.Visible = true;
            idsubcat = Convert.ToInt32(((Button)sender).Tag.ToString());
            lblIdSubcat.Text = ((Button)sender).Tag.ToString();
            flowProductos.Visible = true;
            this.flowProductos.Controls.Clear();
            DibujarProductosSubcategorias();


            try
            {
                ProductosDao.ContarSubcategoriaCatalogo(ref contasubcat, idsubcat);

                lblEtiquetaSubcat.Text = "Total de " + ((Button)sender).Text.ToString() + ":";
                lblCantidadSubcat.Text = contasubcat;
                total = Convert.ToInt32(contasubcat);
                condicion = "subcategoria";
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las subcategorías");
            }

            ConteoDataTable();
            ValidarPaginador();
            txtPagActual.Text = "1";
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = true;
        }

        public void DibujarProductosSubcategorias()
        {
            //idcat = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();
            SqlCommand sql = new SqlCommand();
            sql = new SqlCommand("mostrar_catalogo_subcategoria", con);
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.AddWithValue("@id_categoria", idcat);
            sql.Parameters.AddWithValue("@id_subcategoria", idsubcat);


            SqlDataReader rdr = sql.ExecuteReader();
            //flowProductos.Refresh();

            while (rdr.Read())
            {
                Label lbl1 = new Label();
                Panel pnl1 = new Panel();
                PictureBox box1 = new PictureBox();

                lbl1.Text = rdr["nombre_prod"].ToString();
                lbl1.Name = rdr["id_prod"].ToString();
                lbl1.Size = new Size(120, 30);
                lbl1.Font = new Font("Berlin Sans FB", 8);
                lbl1.BackColor = Color.LavenderBlush;
                lbl1.ForeColor = Color.Black;
                lbl1.Dock = DockStyle.Bottom;
                lbl1.BorderStyle = BorderStyle.FixedSingle;
                lbl1.FlatStyle = FlatStyle.Flat;
                lbl1.TextAlign = ContentAlignment.MiddleCenter;
                lbl1.Tag = rdr["id_prod"].ToString();
                lbl1.Cursor = Cursors.Hand;

                pnl1.Size = new Size(120, 150);
                pnl1.BorderStyle = BorderStyle.None;
                pnl1.BackColor = Color.FromArgb(20, 20, 20);

                box1.Size = new Size(120, 120);
                box1.Dock = DockStyle.Top;
                box1.BackgroundImage = null;
                byte[] bi = (byte[])rdr["imagen_prod"];
                MemoryStream ms = new MemoryStream(bi);
                box1.Image = Image.FromStream(ms);
                box1.SizeMode = PictureBoxSizeMode.Zoom;
                box1.Tag = rdr["id_prod"].ToString();
                box1.Cursor = Cursors.Hand;

                pnl1.Controls.Add(lbl1);
                pnl1.Controls.Add(box1);
                lbl1.BringToFront();
                flowProductos.Controls.Add(pnl1);

                lbl1.Click += new EventHandler(miEventolbl);
                box1.Click += new EventHandler(miEventobox);
            }
            con.Close();
            ConteoDataTable();
            ValidarPaginador();
            txtPagActual.Text = "1";
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = true;
        }

        private void RellenarCampos()
        {
            nombreprod = label10.Text;
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("mostrar_productos_catalogo", con);
                sql.CommandType = CommandType.StoredProcedure;

                sql.Parameters.AddWithValue("@id_prod", idProducto);

                SqlDataReader rdr = sql.ExecuteReader();

                while (rdr.Read())
                {
                    lblIdCode.Text = rdr["id_prod"].ToString();
                    lblNomProd.Text = rdr["nombre_prod"].ToString();
                    lblCodigo.Text = rdr["codigo"].ToString();
                    lblCategoria.Text = rdr["nombre_cat"].ToString();
                    lblSubcategoria.Text = rdr["nombre_subcat"].ToString();
                    lblPrecio.Text = rdr["precio_venta"].ToString();
                    lblStock.Text = rdr["stock"].ToString();
                    lblFechaVenc.Text = rdr["fecha_venc"].ToString();
                    lblMayor.Text = rdr["precio_mayor"].ToString();
                    lblApartir.Text = rdr["cant_mayor"].ToString();
                    lblMarca.Text = rdr["nombre_mar"].ToString();
                    unidades = rdr["tipo_prod"].ToString();

                    pbxProducto.BackgroundImage = null;
                    byte[] biProd = (byte[])rdr["imagen_prod"];
                    MemoryStream msProd = new MemoryStream(biProd);
                    pbxProducto.Image = Image.FromStream(msProd);
                    pbxProducto.SizeMode = PictureBoxSizeMode.Zoom;

                    pbxMarca.BackgroundImage = null;
                    byte[] biMar = (byte[])rdr["logo_mar"];
                    MemoryStream msMar = new MemoryStream(biMar);
                    pbxMarca.Image = Image.FromStream(msMar);
                    pbxMarca.SizeMode = PictureBoxSizeMode.Zoom;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnVolvListado_Click(object sender, EventArgs e)
        {
            flowProductos.Visible = true;
            flowProductos.Dock = DockStyle.Fill;
            pnlTabulacion.Visible = true;
        }

        private void dateFechaEnvio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            if (condicion== "categoria")
            {
                DibujarProductosCategorias();
            }
            else if (condicion== "subcategoria")
            {
                DibujarProductosSubcategorias();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual - 2) * 24;

            PaginarCatalogoProductos(pagina);

            txtPagActual.Text = Convert.ToString(paginaactual - 1);

            if (txtPagActual.Text == "1")
            {
                btnAnterior.Enabled = false;
            }
            btnSiguiente.Enabled = true;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual) * 24;

            PaginarCatalogoProductos(pagina);

            txtPagActual.Text = Convert.ToString(paginaactual + 1);

            if (txtPagActual.Text == lblTotalPag.Text)
            {
                btnSiguiente.Enabled = false;
            }
            btnAnterior.Enabled = true;
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            this.flowProductos.Controls.Clear();
            int paginaactual = Convert.ToInt32(lblTotalPag.Text);
            int pagina = (paginaactual - 1) * 24;

            PaginarCatalogoProductos(pagina);

            txtPagActual.Text = lblTotalPag.Text;

            btnSiguiente.Enabled = false;
            btnAnterior.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaActual.Text = DateTime.Today.ToShortDateString();
            lblHoraActual.Text = DateTime.Now.ToLongTimeString();
        }

        decimal totalpaginas;
        private void ConteoDataTable()
        {
            totalpaginas = Math.Ceiling(Convert.ToDecimal(total) / 24);
            lblTotalPag.Text = totalpaginas.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void ValidarPaginador()
        {
            if (lblTotalPag.Text == "1" || lblTotalPag.Text=="0")
            {
                pnlTabulacion.Enabled = false;
            }
            else
            {
                pnlTabulacion.Enabled = true;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text!="")
            {
                this.flowProductos.Controls.Clear();
                BuscarProductos();
                pnlTabulacion.Enabled = false;
            }
            else
            {
                this.flowProductos.Controls.Clear();
                //pnlTabulacion.Enabled = true;
            }
        }

        public void BuscarProductos()
        {
            //idcat = 1;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            con.Open();
            SqlCommand sql = new SqlCommand();
            sql = new SqlCommand("buscar_productos_catalogo", con);
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.AddWithValue("@multi", txtBuscar.Text);


            SqlDataReader rdr = sql.ExecuteReader();
            //flowProductos.Refresh();

            while (rdr.Read())
            {
                Label lbl1 = new Label();
                Panel pnl1 = new Panel();
                PictureBox box1 = new PictureBox();

                lbl1.Text = rdr["nombre_prod"].ToString();
                lbl1.Name = rdr["id_prod"].ToString();
                lbl1.Size = new Size(120, 30);
                lbl1.Font = new Font("Berlin Sans FB", 8);
                lbl1.BackColor = Color.LavenderBlush;
                lbl1.ForeColor = Color.Black;
                lbl1.Dock = DockStyle.Bottom;
                lbl1.BorderStyle = BorderStyle.FixedSingle;
                lbl1.FlatStyle = FlatStyle.Flat;
                lbl1.TextAlign = ContentAlignment.MiddleCenter;
                lbl1.Tag = rdr["id_prod"].ToString();
                lbl1.Cursor = Cursors.Hand;

                pnl1.Size = new Size(120, 150);
                pnl1.BorderStyle = BorderStyle.None;
                pnl1.BackColor = Color.FromArgb(20, 20, 20);

                box1.Size = new Size(120, 120);
                box1.Dock = DockStyle.Top;
                box1.BackgroundImage = null;
                byte[] bi = (byte[])rdr["imagen_prod"];
                MemoryStream ms = new MemoryStream(bi);
                box1.Image = Image.FromStream(ms);
                box1.SizeMode = PictureBoxSizeMode.Zoom;
                box1.Tag = rdr["id_prod"].ToString();
                box1.Cursor = Cursors.Hand;

                pnl1.Controls.Add(lbl1);
                pnl1.Controls.Add(box1);
                lbl1.BringToFront();
                flowProductos.Controls.Add(pnl1);

                lbl1.Click += new EventHandler(miEventolbl);
                box1.Click += new EventHandler(miEventobox);
            }
            con.Close();
            ConteoDataTable();
            ValidarPaginador();
            txtPagActual.Text = "1";
            btnAnterior.Enabled = false;
            btnSiguiente.Enabled = true;
        }
    }
}
