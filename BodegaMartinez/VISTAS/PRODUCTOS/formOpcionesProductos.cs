using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient;
using System.IO;
using Capa_Dominio;
using Capa_Persistencia;
using Capa_Soporte;

namespace BodegaMartinez.PRODUCTOS
{
    public partial class formOpcionesProductos : Form
    {
        public formOpcionesProductos()
        {
            InitializeComponent();
        }

        Categoria categoria = new Categoria();
        CategoriasDao funcionCategoria = new CategoriasDao();

        Subcategoria subcategoria = new Subcategoria();
        SubcategoriasDao funcionSubcategoria = new SubcategoriasDao();

        Marca marca = new Marca();
        MarcasDao funcionMarca = new MarcasDao();

        Fabrica fabrica = new Fabrica();
        FabricasDao funcionFabrica = new FabricasDao();

        string tabla;

        private void CrearCategoria()
        {
            if (txtNombreCat.Text=="" && string.IsNullOrEmpty(txtDescripcionCat.Text))
            {
                MessageBox.Show("Hay campos vacíos, ¡Digítelos!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombreCat.Text!="")
                {
                    if (string.IsNullOrEmpty(txtDescripcionCat.Text))
                    {
                        MessageBox.Show("La descripción está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDescripcionCat.Focus();
                    }
                    else
                    {
                        try
                        {
                            categoria.NombreCategoria = txtNombreCat.Text;
                            categoria.DescripcionCategoria = txtDescripcionCat.Text;
                            categoria.Estado = "ACTIVADO";
                            categoria.FechaRegistro = DateTime.Now;

                            if (funcionCategoria.InsertarCategoria(categoria) == true)
                            {
                                MessageBox.Show("¡Categoría registrada exitosamente!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MostrarCategorias();
                                LimpiarCategoria();
                                ContarCategorias();
                                ConteoDataTable();
                                ValidarSiguiente();
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Digite el nombre de la categoría");
                    txtNombreCat.Focus();
                }
            }
        }

        private void MostrarCategorias()
        {
            try
            {
                DataTable dt = new DataTable();
                CategoriasDao.MostrarCategorias(ref dt);

                gridCategorias.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                gridCategorias.Columns[2].Visible = false;
                gridCategorias.Columns[3].Visible = false;
                gridCategorias.Columns[3].Width = 70;
                gridCategorias.Columns[4].Visible = true;
                gridCategorias.Columns[5].Visible = true;
                gridCategorias.Columns[5].Width = 300;

                txtPagActual.Text = "1";
                btnAntes.Enabled = false;
                btnDespues.Enabled = true;
                ContarCategorias();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden mostrar las categorías");
            }
            Datatables_tamañoAuto.Multilinea(ref gridCategorias);
        }

        private void EditarCategorias()
        {
            if (txtNombreCat.Text == "" && string.IsNullOrEmpty(txtDescripcionCat.Text))
            {
                MessageBox.Show("Hay campos vacíos, ¡Digítelos!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombreCat.Text != "")
                {
                    if (string.IsNullOrEmpty(txtDescripcionCat.Text))
                    {
                        MessageBox.Show("La descripción está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDescripcionCat.Focus();
                    }
                    else
                    {
                        try
                        {
                            categoria.NombreCategoria = txtNombreCat.Text;
                            categoria.DescripcionCategoria = txtDescripcionCat.Text;
                            categoria.IdCategoria = Convert.ToInt32(lblIdCat.Text);

                            if (funcionCategoria.EditarCategoria(categoria) == true)
                            {
                                MessageBox.Show("¡Categoría editada!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MostrarCategorias();
                                LimpiarCategoria();
                                ContarCategorias();
                                ConteoDataTable();
                                ValidarSiguiente();
                                menuAgregarCat.Visible = true;
                                menuEditarCat.Visible = false;
                                menuNuevaCat.Visible = false;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Digite el nombre de la categoría");
                    txtNombreCat.Focus();
                }
            }
        }

        private void LimpiarCategoria()
        {
            txtNombreCat.Clear();
            txtDescripcionCat.Clear();
            txtBuscaCat.Clear();
            lblIdCat.Text = "";
            txtNombreCat.Focus();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            pnlCategorias.Visible = true;
            pnlSubcategorias.Visible = false;
            pnlMarca.Visible = false;
            pnlFabrica.Visible = false;
            pnlTabulacion.Visible = true;

            pnlCategorias.Dock = DockStyle.Fill;

            MostrarCategorias();
            tabla = "t_categorias";
            ContarCategorias();
            ConteoDataTable();
            ValidarSiguiente();
            NuevaCategoria();
        }

        private void btnAgregarCat_Click(object sender, EventArgs e)
        {
            CrearCategoria();
            
        }

        private void btnLimpiarCat_Click(object sender, EventArgs e)
        {
            LimpiarCategoria();
        }

        private void gridCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==this.gridCategorias.Columns["EdiCat"].Index)
            {
                lblIdCat.Text = gridCategorias.SelectedCells[2].Value.ToString();
                txtNombreCat.Text = gridCategorias.SelectedCells[4].Value.ToString();
                txtDescripcionCat.Text = gridCategorias.SelectedCells[5].Value.ToString();
                menuEditarCat.Visible = true;
                menuAgregarCat.Visible = false;
                menuNuevaCat.Visible = true;
            }

            if (e.ColumnIndex == this.gridCategorias.Columns["EliCat"].Index)
            {
                EliminarCategoria();
            }
        }

        private void EliminarCategoria()
        {
            DialogResult preguntacat;
            preguntacat = MessageBox.Show("¿Está seguro de eliminar esta categoría?", "Eliminar Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preguntacat == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow filacat in gridCategorias.SelectedRows)
                    {
                        int id = Convert.ToInt32(filacat.Cells["ID"].Value);

                        try
                        {
                            categoria.IdCategoria = id;
                            if (funcionCategoria.EliminarCategoria(categoria) == true)
                            {
                                MostrarCategorias();
                                LimpiarCategoria();
                                ContarCategorias();
                                ConteoDataTable();
                                ValidarSiguiente();
                                menuAgregarCat.Visible = true;
                                menuEditarCat.Visible = false;
                                menuNuevaCat.Visible = false;
                            }

                            MessageBox.Show("¡Categoría eliminada correctamente!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al eliminar esta categoria");
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void ListarCategorias()
        {
            try
            {
                cbxCategoria.DataSource = funcionCategoria.ListarCategorias();
                cbxCategoria.DisplayMember = "nombre_cat";
                cbxCategoria.ValueMember = "id_cat";

            }
            catch (Exception)
            {
                MessageBox.Show("No hay categorías listadas", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditarCat_Click(object sender, EventArgs e)
        {
            EditarCategorias();
            
        }

        private void btnNuevaCat_Click(object sender, EventArgs e)
        {
            NuevaCategoria();
        }

        private void NuevaCategoria()
        {
            LimpiarCategoria();
            menuAgregarCat.Visible = true;
            menuEditarCat.Visible = false;
            menuNuevaCat.Visible = false;
        }

        string contacad;
        private void ContarCategorias()
        {
            try
            {
                CategoriasDao.ContarCategorias(ref contacad);

                lblTotalCatNombre.Text = "Total de Categorías:";
                lblTotalCatNumero.Text = "";
                lblTotalCatNumero.Text = contacad;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las categorías");
            }

            ValidarSiguiente();
        }

        private void ValidarSiguiente()
        {
            if (lblTotalPag.Text=="1")
            {
                pnlTabulacion.Enabled = false;
            }
            else
            {
                pnlTabulacion.Enabled = true;
            }
        }

        private void CrearSubcategoria()
        {
            if (txtNombreSubcat.Text=="" && string.IsNullOrEmpty(txtDescripcionSubCat.Text))
            {
                MessageBox.Show("Campos vacíos, rellenelos");
            }
            else
            {
                if (txtNombreSubcat.Text!="")
                {
                    if (string.IsNullOrEmpty(txtDescripcionSubCat.Text))
                    {
                        MessageBox.Show("Los campos están vacíos, ¡Digítelos!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            subcategoria.NombreSubcategoria = txtNombreSubcat.Text;
                            subcategoria.DescripcionSubcategoria = txtDescripcionSubCat.Text;
                            subcategoria.IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue);
                            subcategoria.Estado = "ACTIVADO";
                            subcategoria.FechaRegistro = DateTime.Now;

                            if (funcionSubcategoria.InsertarSubcategoria(subcategoria) == true)
                            {
                                MessageBox.Show("¡Subcategoría registrada exitosamente!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MostrarSubcategorias();
                                LimpiarSubcategoria();
                                ContarSubcategorias();
                                ConteoDataTable();
                                ValidarSiguiente();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.StackTrace);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La subcategoria está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreSubcat.Focus();
                }
            }
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
                gridSubcategorias.Columns[6].Visible = true;
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

        private void btnSubcategorias_Click(object sender, EventArgs e)
        {
            pnlCategorias.Visible = false;
            pnlSubcategorias.Visible = true;
            pnlMarca.Visible = false;
            pnlFabrica.Visible = false;
            pnlTabulacion.Visible = true;

            pnlSubcategorias.Dock = DockStyle.Fill;

            ListarCategorias();
            MostrarSubcategorias();
            tabla = "t_subcategorias";
            ContarSubcategorias();
            ConteoDataTable();
            ValidarSiguiente();
            NuevaSubcategoria();
        }

        private void btnAgregarSubCat_Click(object sender, EventArgs e)
        {
            CrearSubcategoria();
        }

        private void gridSubcategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.gridSubcategorias.Columns["EdiSub"].Index)
            {
                lblIdSubCat.Text = gridSubcategorias.SelectedCells[2].Value.ToString();
                cbxCategoria.Text = gridSubcategorias.SelectedCells[4].Value.ToString();
                txtNombreSubcat.Text = gridSubcategorias.SelectedCells[5].Value.ToString();
                txtDescripcionSubCat.Text = gridSubcategorias.SelectedCells[6].Value.ToString();
                lblIdCat_Sub.Text = gridSubcategorias.SelectedCells[7].Value.ToString();
                menuEditarSubCat.Visible = true;
                menuAgregarSubCat.Visible = false;
                menuNuevaSubCat.Visible = true;
            }

            if (e.ColumnIndex == this.gridSubcategorias.Columns["EliSub"].Index)
            {
                EliminarSubcategoria();
            }
        }

        private void EliminarSubcategoria()
        {
            DialogResult preguntasub;
            preguntasub = MessageBox.Show("¿Está seguro de eliminar esta subcategoría?", "Eliminar Subcategoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preguntasub == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow filasub in gridSubcategorias.SelectedRows)
                    {
                        int id = Convert.ToInt32(filasub.Cells["ID"].Value);

                        try
                        {
                            subcategoria.IdSubcategoria = id;
                            if (funcionSubcategoria.EliminarSubcategoria(subcategoria) == true)
                            {
                                MostrarSubcategorias();
                                LimpiarSubcategoria();
                                ContarSubcategorias();
                                ConteoDataTable();
                                ValidarSiguiente();
                                menuAgregarSubCat.Visible = true;
                                menuEditarSubCat.Visible = false;
                                menuNuevaSubCat.Visible = false;
                            }

                            MessageBox.Show("¡Subcategoría eliminada correctamente!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al eliminar esta categoria");
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void EditarSubcategoria()
        {
            if (txtNombreSubcat.Text == "" && string.IsNullOrEmpty(txtDescripcionSubCat.Text))
            {
                MessageBox.Show("Los campos están vacíos, ¡Digítelos!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombreSubcat.Text != "")
                {
                    if (string.IsNullOrEmpty(txtDescripcionSubCat.Text))
                    {
                        MessageBox.Show("La descripción está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            subcategoria.IdSubcategoria = Convert.ToInt32(lblIdSubCat.Text);
                            subcategoria.NombreSubcategoria = txtNombreSubcat.Text;
                            subcategoria.DescripcionSubcategoria = txtDescripcionSubCat.Text;
                            subcategoria.IdCategoria = Convert.ToInt32(cbxCategoria.SelectedValue);

                            if (funcionSubcategoria.EditarSubcategoria(subcategoria) == true)
                            {
                                MessageBox.Show("¡Subcategoría editada!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                MostrarSubcategorias();
                                LimpiarSubcategoria();
                                ContarSubcategorias();
                                ConteoDataTable();
                                ValidarSiguiente();
                                menuAgregarSubCat.Visible = true;
                                menuEditarSubCat.Visible = false;
                                menuNuevaSubCat.Visible = false;
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                else
                {
                    MessageBox.Show("La subcategoría está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreSubcat.Focus();
                }
            }
        }

        private void btnEditarSubCat_Click(object sender, EventArgs e)
        {
            EditarSubcategoria();
        }

        private void LimpiarSubcategoria()
        {
            txtNombreSubcat.Clear();
            txtDescripcionSubCat.Clear();
            lblIdSubCat.Text = "";
            cbxCategoria.SelectedIndex=0;
            txtNombreSubcat.Focus();
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

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            pnlCategorias.Visible = false;
            pnlSubcategorias.Visible = false;
            pnlMarca.Visible = true;
            pnlFabrica.Visible = false;
            pnlTabulacion.Visible = true;

            pnlMarca.Dock = DockStyle.Fill;

            ListarFabricas();
            MostrarMarcas();

            tabla = "t_marcas";

            ContarMarcas();
            ConteoDataTable();
            ValidarSiguiente();
            NuevaMarca();
        }

        private void btnFabricas_Click(object sender, EventArgs e)
        {
            pnlCategorias.Visible = false;
            pnlSubcategorias.Visible = false;
            pnlMarca.Visible = false;
            pnlFabrica.Visible = true;
            pnlTabulacion.Visible = true;

            pnlFabrica.Dock = DockStyle.Fill;

            MostrarFabricas();
            tabla = "t_fabricas";

            ContarFabricas();
            ConteoDataTable();
            ValidarSiguiente();
            NuevaFabrica();
        }

        private void btnLimpiarSubCat_Click(object sender, EventArgs e)
        {
           LimpiarSubcategoria();
        }

        private void CrearFabrica()
        {
            if (txtNombreFab.Text == "" && string.IsNullOrEmpty(txtDescripcionFab.Text))
            {
                MessageBox.Show("Los campos están vacíos, ¡Digítelos!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombreFab.Text != "")
                {
                    if (string.IsNullOrEmpty(txtDescripcionFab.Text))
                    {
                        MessageBox.Show("La descripción está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDescripcionFab.Focus();
                    }
                    else
                    {
                        if (lblEligeFab.Visible==true)
                        {
                            MessageBox.Show("La imagen está vacía, ¡Insértela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            try
                            {
                                MemoryStream ms = new MemoryStream();
                                pbxFab.Image.Save(ms, pbxFab.Image.RawFormat);
                                byte[] imagen = ms.GetBuffer();

                                fabrica.NombreFabrica = txtNombreFab.Text;
                                fabrica.DescripcionFabrica = txtDescripcionFab.Text;
                                fabrica.LogoFabrica = imagen;
                                fabrica.NombreLogo = lblIcoFab.Text;
                                fabrica.Estado = "ACTIVADO";
                                fabrica.FechaRegistro = DateTime.Now;

                                if (funcionFabrica.InsertarFabrica(fabrica) == true)
                                {
                                    MessageBox.Show("¡Fábrica Registrada exitosamente!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MostrarFabricas();
                                    LimpiarFabrica();
                                    ContarFabricas();
                                    ConteoDataTable();
                                    ValidarSiguiente();
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La fábrica está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreFab.Focus();
                }
            }
        }

        private void LlamarLogoFabrica()
        {
            dlgFabrica.InitialDirectory = "";                   //ruta de inicio de visualizacion
            dlgFabrica.Filter = "Imagenes|*.jpg;*.png";         //que tipo de archivos deseo ver
            dlgFabrica.FilterIndex = 2;
            dlgFabrica.Title = "Logo para fábrica";             //Titulo de la ventana
            if (dlgFabrica.ShowDialog()==DialogResult.OK)
            {
                pbxFab.BackgroundImage = null;
                pbxFab.Image = new Bitmap(dlgFabrica.FileName); //capturo la imagen que seleccione
                lblIcoFab.Text = Path.GetFileName(dlgFabrica.FileName);
                lblEligeFab.Visible = false;    
            }
        }

        private void MostrarFabricas()
        {
            try
            {
                DataTable dt = new DataTable();
                FabricasDao.MostrarFabricas(ref dt);

                gridFabrica.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                gridFabrica.Columns[2].Visible = false;
                gridFabrica.Columns[3].Visible = false;
                gridFabrica.Columns[3].Width = 70;
                gridFabrica.Columns[4].Visible = true;
                gridFabrica.Columns[5].Visible = true;
                //gridFabrica.Columns[5].Width = 300;
                gridFabrica.Columns[6].Visible = false;
                gridFabrica.Columns[7].Visible = false;

                txtPagActual.Text = "1";
                btnAntes.Enabled = false;
                btnDespues.Enabled = true;
                ContarFabricas();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden mostrar las fábricas");
            }
            Datatables_tamañoAuto.Multilinea(ref gridFabrica);
        }

        private void EditarFabrica()
        {
            if (txtNombreFab.Text == "" && string.IsNullOrEmpty(txtDescripcionFab.Text))
            {
                MessageBox.Show("Los campos están vacíos, ¡Digítelos!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombreFab.Text != "")
                {
                    if (string.IsNullOrEmpty(txtDescripcionFab.Text))
                    {
                        MessageBox.Show("La descripcion está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtDescripcionFab.Focus();
                    }
                    else
                    {
                        if (lblEligeFab.Visible == true)
                        {
                            MessageBox.Show("La imagen está vacía, ¡Insértela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            try
                            {
                                MemoryStream ms = new MemoryStream();
                                pbxFab.Image.Save(ms, pbxFab.Image.RawFormat);
                                byte[] imagen = ms.GetBuffer();

                                fabrica.IdFabrica = Convert.ToInt32(lblIdFab.Text);
                                fabrica.NombreFabrica = txtNombreFab.Text;
                                fabrica.DescripcionFabrica = txtDescripcionFab.Text;
                                fabrica.LogoFabrica = imagen;
                                fabrica.NombreLogo = lblIcoFab.Text;

                                if (funcionFabrica.EditarFabrica(fabrica) == true)
                                {
                                    MessageBox.Show("¡Fábrica Editada!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    MostrarFabricas();
                                    LimpiarFabrica();
                                    ContarFabricas();
                                    ConteoDataTable();
                                    ValidarSiguiente();
                                }
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("La fábrica está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombreFab.Focus();
                }
            }
        }

        private void btnAgregarFab_Click(object sender, EventArgs e)
        {
            CrearFabrica();
        }

        private void lblEligeFab_Click(object sender, EventArgs e)
        {
            LlamarLogoFabrica();
        }

        private void pbxFab_Click(object sender, EventArgs e)
        {
            LlamarLogoFabrica();
        }

        private void gridFabrica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.gridFabrica.Columns["EdiFab"].Index)
            {
                lblIdFab.Text = gridFabrica.SelectedCells[2].Value.ToString();
                txtNombreFab.Text = gridFabrica.SelectedCells[4].Value.ToString();
                txtDescripcionFab.Text = gridFabrica.SelectedCells[5].Value.ToString();

                pbxFab.BackgroundImage = null;
                byte[] b = (Byte[])gridFabrica.SelectedCells[6].Value;
                MemoryStream ms = new MemoryStream(b);
                pbxFab.Image = Image.FromStream(ms);
                lblEligeFab.Visible = false;
                lblIcoFab.Text = gridFabrica.SelectedCells[7].Value.ToString();

                menuEditarFab.Visible = true;
                menuAgregarFab.Visible = false;
                menuNuevaFab.Visible = true;
            }

            if (e.ColumnIndex == this.gridFabrica.Columns["EliFab"].Index)
            {
                EliminarFabrica();
            }
        }

        private void EliminarFabrica()
        {
            DialogResult preguntafab;
            preguntafab = MessageBox.Show("¿Está seguro de eliminar esta fábrica?", "Eliminar Fábrica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preguntafab == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow filafab in gridFabrica.SelectedRows)
                    {
                        int id = Convert.ToInt32(filafab.Cells["ID"].Value);

                        try
                        {
                            fabrica.IdFabrica = id;
                            if (funcionFabrica.EliminarFabrica(fabrica) == true)
                            {
                                MostrarFabricas();
                                LimpiarFabrica();
                                ContarFabricas();
                                ConteoDataTable();
                                ValidarSiguiente();
                                menuAgregarFab.Visible = true;
                                menuEditarFab.Visible = false;
                                menuNuevaFab.Visible = false;
                            }

                            MessageBox.Show("¡Fábrica eliminada correctamente!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al eliminar esta fábrica");
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void LimpiarFabrica()
        {
            txtNombreFab.Clear();
            txtDescripcionFab.Clear();
            pbxFab.BackgroundImage = null;
            lblIcoFab.Text = "";
            lblEligeFab.Visible = true;
            lblIdFab.Text = "";
            txtNombreFab.Focus();
        }

        string contafab;
        private void ContarFabricas()
        {
            try
            {
                FabricasDao.ContarFabricas(ref contafab);

                lblTotalCatNombre.Text = "Total de Fábricas:";
                lblTotalCatNumero.Text = "";
                lblTotalCatNumero.Text = contafab;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las categorías");
            }

            ValidarSiguiente();
        }

        private void btnLimpiarFab_Click(object sender, EventArgs e)
        {
            LimpiarFabrica();
        }

        private void btnEditarFab_Click(object sender, EventArgs e)
        {
            EditarFabrica();
        }

        private void btnNuevaFab_Click(object sender, EventArgs e)
        {
            NuevaFabrica();
        }

        private void NuevaFabrica()
        {
            LimpiarFabrica();
            menuAgregarFab.Visible = true;
            menuEditarFab.Visible = false;
            menuNuevaFab.Visible = false;
        }

        private void btnAgregarMar_Click(object sender, EventArgs e)
        {
            CrearMarca();
        }

        private void CrearMarca()
        {
            if (txtMarca.Text=="")
            {
                MessageBox.Show("La marca está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (lblEligeMarca.Visible==true)
                {
                    MessageBox.Show("La imagen está vacía, ¡Insértela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pbxMarca.Image.Save(ms, pbxMarca.Image.RawFormat);
                        byte[] imagen = ms.GetBuffer();

                        marca.NombreMarca = txtMarca.Text;
                        marca.IdFabrica = Convert.ToInt32(cbxFabrica.SelectedValue);
                        marca.LogoMarca = imagen;
                        marca.NombreLogo = lblIcoMarca.Text;
                        marca.Estado = "ACTIVADO";
                        marca.FechaRegistro = DateTime.Now;

                        if (funcionMarca.InsertarMarca(marca) == true)
                        {
                            MessageBox.Show("¡Marca Registrada exitosamente!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarMarcas();
                            MostrarMarcas();
                            ContarMarcas();
                            ConteoDataTable();
                            ValidarSiguiente();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void ListarFabricas()
        {
            try
            {
                cbxFabrica.DataSource = funcionFabrica.ListarFabricas();
                cbxFabrica.DisplayMember = "nombre_fab";
                cbxFabrica.ValueMember = "id_fab";

            }
            catch (Exception)
            {
                MessageBox.Show("No hay fabricas listadas", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void EditarMarca()
        {
            if (txtMarca.Text == "")
            {
                MessageBox.Show("La marca está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (lblEligeMarca.Visible == true)
                {
                    MessageBox.Show("La imagen está vacía, ¡Insértela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pbxMarca.Image.Save(ms, pbxMarca.Image.RawFormat);
                        byte[] imagen = ms.GetBuffer();

                        marca.IdMarca = Convert.ToInt32(lblIdMarca.Text);
                        marca.NombreMarca = txtMarca.Text;
                        marca.IdFabrica = Convert.ToInt32(cbxFabrica.SelectedValue);
                        marca.LogoMarca = imagen;
                        marca.NombreLogo = lblIcoMarca.Text;
                        marca.Estado = "ACTIVADO";
                        marca.FechaRegistro = DateTime.Now;

                        if (funcionMarca.EditarMarca(marca) == true)
                        {
                            MessageBox.Show("¡Marca Editada!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LimpiarMarcas();
                            MostrarMarcas();
                            ContarMarcas();
                            ConteoDataTable();
                            ValidarSiguiente();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void LlamarLogoMarca()
        {
            dlgMarca.InitialDirectory = "";                   //ruta de inicio de visualizacion
            dlgMarca.Filter = "Imagenes|*.jpg;*.png";         //que tipo de archivos deseo ver
            dlgMarca.FilterIndex = 2;
            dlgMarca.Title = "Logo para marca";             //Titulo de la ventana
            if (dlgMarca.ShowDialog() == DialogResult.OK)
            {
                pbxMarca.BackgroundImage = null;
                pbxMarca.Image = new Bitmap(dlgMarca.FileName); //capturo la imagen que seleccione
                lblIcoMarca.Text = Path.GetFileName(dlgMarca.FileName);
                lblEligeMarca.Visible = false;
            }
        }

        private void LimpiarMarcas()
        {
            txtMarca.Clear();
            cbxFabrica.SelectedIndex=0;
            pbxMarca.BackgroundImage = null;
            lblIcoMarca.Text = "";
            lblEligeMarca.Visible = true;
            lblIdMarca.Text = "";

            txtMarca.Focus();
        }


        private void gridMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.gridMarcas.Columns["EdiMar"].Index)
            {
                lblIdMarca.Text = gridMarcas.SelectedCells[2].Value.ToString();
                txtMarca.Text = gridMarcas.SelectedCells[4].Value.ToString();
                cbxFabrica.Text = gridMarcas.SelectedCells[5].Value.ToString();

                pbxMarca.BackgroundImage = null;
                byte[] b = (Byte[])gridMarcas.SelectedCells[6].Value;
                MemoryStream ms = new MemoryStream(b);
                pbxMarca.Image = Image.FromStream(ms);
                lblEligeMarca.Visible = false;
                lblIcoMarca.Text = gridMarcas.SelectedCells[7].Value.ToString();

                menuEditarMar.Visible = true;
                menuAgregarMarca.Visible = false;
                menuNuevaMar.Visible = true;
            }

            if (e.ColumnIndex == this.gridMarcas.Columns["EliMar"].Index)
            {
                EliminarMarca();
            }
        }

        private void EliminarMarca()
        {
            DialogResult preguntamar;
            preguntamar = MessageBox.Show("¿Está seguro de eliminar esta marca?", "Eliminar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preguntamar == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow filamar in gridMarcas.SelectedRows)
                    {
                        int id = Convert.ToInt32(filamar.Cells["ID"].Value);
                        try
                        {
                            marca.IdMarca = id;
                            if (funcionMarca.EliminarMarca(marca) == true)
                            {
                                MostrarMarcas();
                                LimpiarMarcas();
                                ContarMarcas();
                                ConteoDataTable();
                                ValidarSiguiente();
                                menuAgregarMarca.Visible = true;
                                menuEditarMar.Visible = false;
                                menuNuevaMar.Visible = false;
                            }

                            MessageBox.Show("¡Marca eliminada correctamente!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al eliminar esta fábrica");
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
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

        private void lblEligeMarca_Click(object sender, EventArgs e)
        {
            LlamarLogoMarca();
        }

        private void pbxMarca_Click(object sender, EventArgs e)
        {
            LlamarLogoMarca();
        }

        private void btnLimpiarMar_Click(object sender, EventArgs e)
        {
            LimpiarMarcas();
        }

        private void btnEditarMar_Click(object sender, EventArgs e)
        {
            EditarMarca();
        }

        private void btnNuevaMar_Click(object sender, EventArgs e)
        {
            NuevaMarca();
        }

        private void NuevaMarca()
        {
            LimpiarMarcas();
            menuAgregarMarca.Visible = true;
            menuEditarMar.Visible = false;
            menuNuevaMar.Visible = false;
        }

        private void btnNuevaSubCat_Click(object sender, EventArgs e)
        {
            NuevaSubcategoria();
        }

        private void NuevaSubcategoria()
        {
            LimpiarSubcategoria();
            menuAgregarSubCat.Visible = true;
            menuEditarSubCat.Visible = false;
            menuNuevaSubCat.Visible = false;
        }

        private void BuscarCategorias()
        {
            if (txtBuscaCat.Text!="")
            {
                try
                {
                    DataTable dt = new DataTable();
                    CategoriasDao.BuscarCategorias(ref dt, txtBuscaCat.Text);
                    gridCategorias.DataSource = dt;

                    gridCategorias.Columns[2].Visible = false;
                    gridCategorias.Columns[3].Visible = false;
                    gridCategorias.Columns[3].Width = 70;
                    gridCategorias.Columns[4].Visible = true;
                    gridCategorias.Columns[5].Visible = true;
                    gridCategorias.Columns[5].Width = 300;
                }
                catch (Exception)
                {

                }
                Datatables_tamañoAuto.Multilinea(ref gridCategorias);

                pnlTabulacion.Enabled = false;
            }
            else
            {
                MostrarCategorias();
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
                    gridSubcategorias.Columns[6].Visible = true;
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

        private void BuscarFabricas()
        {
            if (txtBuscarFab.Text != "")
            {
                try
                {
                    DataTable dt = new DataTable();
                    FabricasDao.BuscarFabricas(ref dt, txtBuscarFab.Text);
                    gridFabrica.DataSource = dt;

                    gridFabrica.Columns[2].Visible = false;
                    gridFabrica.Columns[3].Visible = false;
                    gridFabrica.Columns[3].Width = 70;
                    gridFabrica.Columns[4].Visible = true;
                    gridFabrica.Columns[5].Visible = true;
                    //gridFabrica.Columns[5].Width = 300;
                    gridFabrica.Columns[6].Visible = false;
                    gridFabrica.Columns[7].Visible = false;
                }
                catch (Exception)
                {

                }
                Datatables_tamañoAuto.Multilinea(ref gridFabrica);

                pnlTabulacion.Enabled = false;
            }
            else
            {
                MostrarFabricas();
                pnlTabulacion.Enabled = true;
            }
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

        private void txtBuscarMar_TextChanged(object sender, EventArgs e)
        {
            BuscarMarcas();
        }

        private void txtBuscaCat_TextChanged(object sender, EventArgs e)
        {
            BuscarCategorias();
        }

        private void txtBuscarSubCat_TextChanged(object sender, EventArgs e)
        {
            BuscarSubcategorias();
        }

        private void txtBuscarFab_TextChanged(object sender, EventArgs e)
        {
            BuscarFabricas();
        }


        private void ValidarTextBox(TextBox sCaneda, KeyPressEventArgs e)
        {
            //if (Char.IsLetter(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsWhiteSpace(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void ValidarRichTextBox(RichTextBox sCaneda, KeyPressEventArgs e)
        {
            //if (Char.IsLetter(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsWhiteSpace(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
        }

        private void txtNombreCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidarTextBox(txtNombreCat, e);
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtDescripcionCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidarRichTextBox(txtDescripcionCat, e);
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtNombreSubcat_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidarTextBox(txtNombreSubcat, e);
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtNombreFab_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (Char.IsLetterOrDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsPunctuation(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsWhiteSpace(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
            new ValidacionCampos().ValidarTextoEnriquecido(e);
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (Char.IsLetterOrDigit(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsControl(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsPunctuation(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else if (Char.IsWhiteSpace(e.KeyChar))
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    e.Handled = true;
            //}
            new ValidacionCampos().ValidarTextoEnriquecido(e);
        }

        private void txtDescripcionSubCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidarRichTextBox(txtDescripcionSubCat, e);
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtDescripcionFab_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidarRichTextBox(txtDescripcionFab, e);
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void PaginarCategorias(int pagina)
        {
            try
            {
                DataTable dt = new DataTable();
                CategoriasDao.MostrarAnterior(ref dt, pagina);
                gridCategorias.DataSource = dt;

                gridCategorias.Columns[2].Visible = false;
                gridCategorias.Columns[3].Visible = false;
                gridCategorias.Columns[3].Width = 70;
                gridCategorias.Columns[4].Visible = true;
                gridCategorias.Columns[5].Visible = true;
                //gridCategorias.Columns[5].Width = 300;
            }
            catch (Exception)
            {
                MessageBox.Show("Hola");
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
                gridSubcategorias.Columns[6].Visible = true;
                //gridSubcategorias.Columns[6].Width = 300;
                gridSubcategorias.Columns[7].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Hola");
            }
        }

        private void PaginarFabricas(int pagina)
        {
            try
            {
                DataTable dt = new DataTable();
                FabricasDao.TabularFabricas(ref dt, pagina);
                gridFabrica.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                gridFabrica.Columns[2].Visible = false;
                gridFabrica.Columns[3].Visible = false;
                gridFabrica.Columns[3].Width = 70;
                gridFabrica.Columns[4].Visible = true;
                gridFabrica.Columns[5].Visible = true;
                //gridFabrica.Columns[5].Width = 300;
                gridFabrica.Columns[6].Visible = false;
                gridFabrica.Columns[7].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Hola");
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

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            if (tabla == "t_categorias")
            {
                MostrarCategorias();
            }
            else if (tabla == "t_subcategorias")
            {
                MostrarSubcategorias();
            }
            else if (tabla == "t_fabricas")
            {
                MostrarFabricas();
            }
            else if (tabla == "t_marcas")
            {
                MostrarMarcas();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(lblTotalPag.Text);
            int pagina = (paginaactual - 2) * 10;

            if (tabla == "t_categorias")
            {
                PaginarCategorias(pagina);
            }
            else if (tabla == "t_subcategorias")
            {
                PaginarSubcategorias(pagina);
            }
            else if (tabla == "t_fabricas")
            {
                PaginarFabricas(pagina);
            }
            else if (tabla == "t_marcas")
            {
                PaginarMarcas(pagina);
            }

            txtPagActual.Text = Convert.ToString(paginaactual - 1);

            if (txtPagActual.Text == "1")
            {
                btnAntes.Enabled = false;
            }
            btnDespues.Enabled = true;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(lblTotalPag.Text);
            int pagina = (paginaactual) * 10;

            if (tabla == "t_categorias")
            {
                PaginarCategorias(pagina);
            }
            else if (tabla == "t_subcategorias")
            {
                PaginarSubcategorias(pagina);
            }
            else if (tabla == "t_fabricas")
            {
                PaginarFabricas(pagina);
            }
            else if (tabla == "t_marcas")
            {
                PaginarMarcas(pagina);
            }

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
            int pagina = (paginaactual-1) * 10;

            if (tabla == "t_categorias")
            {
                PaginarCategorias(pagina);
            }
            else if (tabla == "t_subcategorias")
            {
                PaginarSubcategorias(pagina);
            }
            else if (tabla == "t_fabricas")
            {
                PaginarFabricas(pagina);
            }
            else if (tabla == "t_marcas")
            {
                PaginarMarcas(pagina);
            }

            txtPagActual.Text = lblTotalPag.Text;

            btnDespues.Enabled = false;
            btnAntes.Enabled = true;
        }

        decimal totalpaginas;
        private void ConteoDataTable()
        {
            totalpaginas = Math.Ceiling(Convert.ToDecimal(lblTotalCatNumero.Text) / 10);
            lblTotalPag.Text = totalpaginas.ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void formOpcionesProductos_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaActual.Text = DateTime.Today.ToShortDateString();
            lblHoraActual.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnAntes_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual - 2) * 10;

            if (tabla == "t_categorias")
            {
                PaginarCategorias(pagina);
            }
            else if (tabla == "t_subcategorias")
            {
                PaginarSubcategorias(pagina);
            }
            else if (tabla == "t_fabricas")
            {
                PaginarFabricas(pagina);
            }
            else if (tabla == "t_marcas")
            {
                PaginarMarcas(pagina);
            }

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

            if (tabla == "t_categorias")
            {
                PaginarCategorias(pagina);
            }
            else if (tabla == "t_subcategorias")
            {
                PaginarSubcategorias(pagina);
            }
            else if (tabla == "t_fabricas")
            {
                PaginarFabricas(pagina);
            }
            else if (tabla == "t_marcas")
            {
                PaginarMarcas(pagina);
            }

            txtPagActual.Text = Convert.ToString(paginaactual + 1);

            if (txtPagActual.Text == lblTotalPag.Text)
            {
                btnDespues.Enabled = false;
            }
            btnAntes.Enabled = true;
        }
    }
}
