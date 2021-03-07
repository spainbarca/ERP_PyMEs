using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Capa_Dominio;
using Capa_Persistencia;
using Capa_Soporte;

namespace BodegaMartinez.VISTAS.PRODUCTOS
{
    public partial class formSubcategorias : Form
    {
        public formSubcategorias()
        {
            InitializeComponent();
        }

        Categoria categoria = new Categoria();
        CategoriasDao funcionCategoria = new CategoriasDao();

        Subcategoria subcategoria = new Subcategoria();
        SubcategoriasDao funcionSubcategoria = new SubcategoriasDao();

        private void lblIdSubCat_Click(object sender, EventArgs e)
        {

        }

        private void lblIdCat_Click(object sender, EventArgs e)
        {

        }

        private void formSubcategorias_Load(object sender, EventArgs e)
        {
            MostrarSubcategorias();
            ContarSubcategorias();
            ConteoDataTable();
            ValidarSiguiente();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridSubcategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdSubCat.Text = gridSubcategorias.SelectedCells[2].Value.ToString();
            cbxCategoria.Text = gridSubcategorias.SelectedCells[4].Value.ToString();
            txtNombreSubcat.Text = gridSubcategorias.SelectedCells[5].Value.ToString();
            lblIdCat.Text = gridSubcategorias.SelectedCells[7].Value.ToString();
        }

        string contasubcat;
        private void ContarSubcategorias()
        {
            try
            {
                SubcategoriasDao.ContarSubcategorias(ref contasubcat);

                lblTotalCatNombre.Text = "Total de Subcategorías:";
                lblTotalCatNumero.Text = "";
                lblTotalCatNumero.Text = contasubcat;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las categorías");
            }

            ValidarSiguiente();
        }

        private void MostrarSubcategorias()
        {
            try
            {
                DataTable dt = new DataTable();
                SubcategoriasDao.MostrarSubcategorias(ref dt);

                gridSubcategorias.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                gridSubcategorias.Columns[2].Visible = false;
                gridSubcategorias.Columns[3].Visible = false;
                gridSubcategorias.Columns[3].Width = 70;
                gridSubcategorias.Columns[4].Visible = true;
                gridSubcategorias.Columns[5].Visible = true;
                gridSubcategorias.Columns[6].Visible = false;
                //gridSubcategorias.Columns[6].Width = 300;
                gridSubcategorias.Columns[7].Visible = false;

                txtPagActual.Text = "1";
                btnAntes.Enabled = false;
                btnDespues.Enabled = true;
                ContarSubcategorias();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden mostrar las subcategorías");
            }
            Datatables_tamañoAuto.Multilinea(ref gridSubcategorias);
        }

        private void ValidarSiguiente()
        {
            if (lblTotalPag.Text == "1")
            {
                pnlTabulacion.Enabled = false;
            }
            else
            {
                pnlTabulacion.Enabled = true;
            }
        }

        private void BuscarSubcategorias()
        {
            if (txtBuscarSubCat.Text != "")
            {
                try
                {
                    DataTable dt = new DataTable();
                    SubcategoriasDao.BuscarSubcategorias(ref dt, txtBuscarSubCat.Text);
                    gridSubcategorias.DataSource = dt;

                    gridSubcategorias.Columns[2].Visible = false;
                    gridSubcategorias.Columns[3].Visible = false;
                    gridSubcategorias.Columns[3].Width = 70;
                    gridSubcategorias.Columns[4].Visible = true;
                    gridSubcategorias.Columns[5].Visible = true;
                    gridSubcategorias.Columns[6].Visible = false;
                    //gridSubcategorias.Columns[6].Width = 300;
                    gridSubcategorias.Columns[7].Visible = false;
                }
                catch (Exception)
                {

                }
                Datatables_tamañoAuto.Multilinea(ref gridSubcategorias);

                pnlTabulacion.Enabled = false;
            }
            else
            {
                MostrarSubcategorias();
                pnlTabulacion.Enabled = true;
            }
        }

        private void PaginarSubcategorias(int pagina)
        {
            try
            {
                DataTable dt = new DataTable();
                SubcategoriasDao.TabularSubcategorias(ref dt, pagina);
                gridSubcategorias.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                gridSubcategorias.Columns[2].Visible = false;
                gridSubcategorias.Columns[3].Visible = false;
                gridSubcategorias.Columns[3].Width = 70;
                gridSubcategorias.Columns[4].Visible = true;
                gridSubcategorias.Columns[5].Visible = true;
                gridSubcategorias.Columns[6].Visible = false;
                //gridSubcategorias.Columns[6].Width = 300;
                gridSubcategorias.Columns[7].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Hola");
            }
        }

        decimal totalpaginas;
        private void ConteoDataTable()
        {
            totalpaginas = Math.Ceiling(Convert.ToDecimal(lblTotalCatNumero.Text) / 10);
            lblTotalPag.Text = totalpaginas.ToString();
        }

        private void ElegirSubcategoria()
        {
            if (txtNombreSubcat.Text != "")
            {
                BodegaMartinez.PRODUCTOS.formProductos prod = Owner as BodegaMartinez.PRODUCTOS.formProductos;
                prod.lblIdCat.Text = lblIdCat.Text;
                prod.lblIdSubCat.Text = lblIdSubCat.Text;
                prod.txtCategoria.Text = cbxCategoria.Text;
                prod.txtSubcategoria.Text = txtNombreSubcat.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una subcategoría", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnElegir_Click(object sender, EventArgs e)
        {
            //MENUPRINCIPAL.formMediosPago pag = Owner as MENUPRINCIPAL.formMediosPago;
            ElegirSubcategoria();
        }

        private void txtBuscarSubCat_TextChanged(object sender, EventArgs e)
        {
            BuscarSubcategorias();
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            MostrarSubcategorias();
        }

        private void btnAntes_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual - 2) * 10;

            PaginarSubcategorias(pagina);

            txtPagActual.Text = Convert.ToString(paginaactual - 1);

            if (txtPagActual.Text == "1")
            {
                btnAntes.Enabled = false;
            }
            btnDespues.Enabled = true;
        }

        private void btnDespues_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual) * 10;

            PaginarSubcategorias(pagina);

            txtPagActual.Text = Convert.ToString(paginaactual + 1);

            if (txtPagActual.Text == lblTotalPag.Text)
            {
                btnDespues.Enabled = false;
            }
            btnAntes.Enabled = true;
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(lblTotalPag.Text);
            int pagina = (paginaactual - 1) * 10;
            
            PaginarSubcategorias(pagina);

            txtPagActual.Text = lblTotalPag.Text;

            btnDespues.Enabled = false;
            btnAntes.Enabled = true;
        }

        private void gridSubcategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ElegirSubcategoria();
        }
    }
}
