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
    public partial class formMarcas : Form
    {
        public formMarcas()
        {
            InitializeComponent();
        }

        private void MostrarMarcas()
        {
            try
            {
                //Nombretabla+Columns[n]+.Visible=true/false

                DataTable dt = new DataTable();
                MarcasDao.MostrarMarcas(ref dt);

                gridMarcas.DataSource = dt;

                gridMarcas.Columns[2].Visible = false;
                gridMarcas.Columns[3].Visible = false;
                gridMarcas.Columns[3].Width = 70;
                gridMarcas.Columns[4].Visible = true;
                gridMarcas.Columns[5].Visible = true;
                gridMarcas.Columns[6].Visible = false;
                gridMarcas.Columns[7].Visible = false;

                txtPagActual.Text = "1";
                btnAntes.Enabled = false;
                btnDespues.Enabled = true;
                ContarMarcas();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden mostrar las fábricas");
            }
            Datatables_tamañoAuto.Multilinea(ref gridMarcas);
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            MostrarMarcas();
        }

        private void btnAntes_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual - 2) * 10;

            PaginarMarcas(pagina);

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

            PaginarMarcas(pagina);

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

            PaginarMarcas(pagina);

            txtPagActual.Text = lblTotalPag.Text;

            btnDespues.Enabled = false;
            btnAntes.Enabled = true;
        }

        private void formMarcas_Load(object sender, EventArgs e)
        {
            MostrarMarcas();
            ContarMarcas();
            ConteoDataTable();
            ValidarSiguiente();
        }

        private void gridMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdMarca.Text = gridMarcas.SelectedCells[2].Value.ToString();
            txtMarca.Text = gridMarcas.SelectedCells[4].Value.ToString();
            //cbxFabrica.Text = gridMarcas.SelectedCells[5].Value.ToString();

            pbxMarca.BackgroundImage = null;
            byte[] b = (Byte[])gridMarcas.SelectedCells[6].Value;
            MemoryStream ms = new MemoryStream(b);
            pbxMarca.Image = Image.FromStream(ms);
            lblEligeMarca.Visible = false;
            lblIcoMarca.Text = gridMarcas.SelectedCells[7].Value.ToString();
        }

        string contamar;
        private void ContarMarcas()
        {
            try
            {
                MarcasDao.ContarMarcas(ref contamar);

                lblTotalCatNombre.Text = "Total de Marcas:";
                lblTotalCatNumero.Text = "";
                lblTotalCatNumero.Text = contamar;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las categorías");
            }

            ValidarSiguiente();
        }

        private void BuscarMarcas()
        {
            if (txtBuscarMar.Text != "")
            {
                try
                {
                    DataTable dt = new DataTable();
                    MarcasDao.BuscarMarcas(ref dt, txtBuscarMar.Text);
                    gridMarcas.DataSource = dt;

                    gridMarcas.Columns[2].Visible = false;
                    gridMarcas.Columns[3].Visible = true;
                    gridMarcas.Columns[3].Width = 70;
                    gridMarcas.Columns[4].Visible = true;
                    gridMarcas.Columns[5].Visible = true;
                    gridMarcas.Columns[6].Visible = false;
                    gridMarcas.Columns[7].Visible = false;
                }
                catch (Exception)
                {
                }
                Datatables_tamañoAuto.Multilinea(ref gridMarcas);

                pnlTabulacion.Enabled = false;
            }
            else
            {
                MostrarMarcas();
                pnlTabulacion.Enabled = true;
            }
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

        private void PaginarMarcas(int pagina)
        {
            try
            {
                DataTable dt = new DataTable();
                MarcasDao.TabularMarcas(ref dt, pagina);
                gridMarcas.DataSource = dt;

                gridMarcas.Columns[2].Visible = false;
                gridMarcas.Columns[3].Visible = false;
                gridMarcas.Columns[3].Width = 70;
                gridMarcas.Columns[4].Visible = true;
                gridMarcas.Columns[5].Visible = true;
                gridMarcas.Columns[6].Visible = false;
                gridMarcas.Columns[7].Visible = false;
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

        private void btnElegir_Click(object sender, EventArgs e)
        {
            ElegirMarca();
        }

        private void ElegirMarca()
        {
            if (txtMarca.Text != "")
            {
                BodegaMartinez.PRODUCTOS.formProductos prod = Owner as BodegaMartinez.PRODUCTOS.formProductos;
                prod.lblIdMarca.Text = lblIdMarca.Text;
                prod.txtMarca.Text = txtMarca.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione una marca", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void gridMarcas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ElegirMarca();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBuscarMar_TextChanged(object sender, EventArgs e)
        {
            BuscarMarcas();
        }
    }
}
