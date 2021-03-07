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

namespace BodegaMartinez.PRODUCTOS
{
    public partial class formOpcionesProductos : Form
    {
        public formOpcionesProductos()
        {
            InitializeComponent();
        }

        private void CrearCategoria()
        {
            if (txtNombreCat.Text=="" && string.IsNullOrEmpty(txtDescripcionCat.Text))
            {
                MessageBox.Show("Hay campos vacios, digite!");
            }
            else
            {
                if (txtNombreCat.Text!="")
                {
                    if (string.IsNullOrEmpty(txtDescripcionCat.Text))
                    {
                        MessageBox.Show("Digite la descripción de la categoría");
                        txtDescripcionCat.Focus();
                    }
                    else
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = CONEXION.Conexion.conectar;
                            con.Open();

                            SqlCommand sql = new SqlCommand();
                            sql = new SqlCommand("crear_categoria", con);
                            sql.CommandType = CommandType.StoredProcedure;
                            sql.Parameters.AddWithValue("@nombre_cat", txtNombreCat.Text);
                            sql.Parameters.AddWithValue("@descripcion_cat", txtDescripcionCat.Text);

                            sql.ExecuteNonQuery();

                            MessageBox.Show("Categoria insertada correctamente");
                            con.Close();
                            MostrarCategorias();
                            LimpiarCategoria();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al insertar categoría");
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
                SqlDataAdapter da;              //Para instanciar en una tabla

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_categorias", con);
                da.Fill(dt);

                gridCategorias.DataSource = dt;
                con.Close();
                //Nombretabla+Columns[n]+.Visible=true/false
                gridCategorias.Columns[2].Visible = false;
                gridCategorias.Columns[3].Visible = true;
                gridCategorias.Columns[3].Width = 70;
                gridCategorias.Columns[4].Visible = true;
                gridCategorias.Columns[5].Visible = true;
                gridCategorias.Columns[5].Width = 300;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden mostrar las categorías");
            }
        }

        private void EditarCategorias()
        {
            if (txtNombreCat.Text == "" && string.IsNullOrEmpty(txtDescripcionCat.Text))
            {
                MessageBox.Show("Hay campos vacios, digite!");
            }
            else
            {
                if (txtNombreCat.Text != "")
                {
                    if (string.IsNullOrEmpty(txtDescripcionCat.Text))
                    {
                        MessageBox.Show("Digite la descripción de la categoría");
                        txtDescripcionCat.Focus();
                    }
                    else
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = CONEXION.Conexion.conectar;
                            con.Open();

                            SqlCommand sql = new SqlCommand();
                            sql = new SqlCommand("editar_categoria", con);
                            sql.CommandType = CommandType.StoredProcedure;
                            sql.Parameters.AddWithValue("@nombre_cat", txtNombreCat.Text);
                            sql.Parameters.AddWithValue("@descripcion_cat", txtDescripcionCat.Text);
                            sql.Parameters.AddWithValue("@id_cat", lblIdCat.Text);

                            sql.ExecuteNonQuery();

                            MessageBox.Show("Categoria editada correctamente");
                            con.Close();
                            MostrarCategorias();
                            LimpiarCategoria();
                            menuAgregarCat.Visible = true;
                            menuEditarCat.Visible = false;
                            menuNuevaCat.Visible = false;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al editar categoría");
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

            menuEditarCat.Visible = false;
            menuNuevaCat.Visible = false;
            MostrarCategorias();
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
                DialogResult preguntacat;
                preguntacat = MessageBox.Show("¿Está seguro de eliminar esta categoría?", "Eliminar Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preguntacat == DialogResult.Yes)
                {
                    SqlCommand sql;
                    try
                    {
                        foreach (DataGridViewRow filacat in gridCategorias.SelectedRows)
                        {
                            int id = Convert.ToInt32(filacat.Cells["ID"].Value);

                            try
                            {
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = CONEXION.Conexion.conectar;
                                con.Open();

                                sql = new SqlCommand("eliminar_categoria", con);
                                sql.CommandType = CommandType.StoredProcedure;
                                sql.Parameters.AddWithValue("@id_cat", id);

                                sql.ExecuteNonQuery();

                                MessageBox.Show("Categoria eliminada correctamente");
                                con.Close();
                                MostrarCategorias();
                                LimpiarCategoria();
                                menuAgregarCat.Visible = true;
                                menuEditarCat.Visible = false;
                                menuNuevaCat.Visible = false;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("No se puede eliminar esta categoría");
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void ListarCategorias()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("listar_categorias", con);
                da.Fill(dt);

                cbxCategoria.DisplayMember = "nombre_cat";
                cbxCategoria.ValueMember = "id_cat";
                cbxCategoria.DataSource = dt;

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Categoria no invocada");
            }
        }

        private void btnEditarCat_Click(object sender, EventArgs e)
        {
            EditarCategorias();
        }

        private void btnNuevaCat_Click(object sender, EventArgs e)
        {
            LimpiarCategoria();
            menuAgregarCat.Visible = true;
            menuEditarCat.Visible = false;
            menuNuevaCat.Visible = false;
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
                        MessageBox.Show("Digite la descripción de la subcategoría");
                    }
                    else
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = CONEXION.Conexion.conectar;
                            con.Open();

                            SqlCommand sql = new SqlCommand();
                            sql = new SqlCommand("crear_subcategoria", con);
                            sql.CommandType = CommandType.StoredProcedure;
                            sql.Parameters.AddWithValue("@id_cat", cbxCategoria.SelectedValue);
                            sql.Parameters.AddWithValue("@nombre_subcat", txtNombreSubcat.Text);
                            sql.Parameters.AddWithValue("@descripcion_subcat", txtDescripcionSubCat.Text);

                            sql.ExecuteNonQuery();

                            MessageBox.Show("Subcategoria insertada correctamente");
                            con.Close();
                            MostrarSubcategorias();
                            LimpiarSubcategoria();
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al insertar subcategoría");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Subcategoría está vacía, digite");
                    txtNombreSubcat.Focus();
                }
            }
        }

        private void MostrarSubcategorias()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;              //Para instanciar en una tabla

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_subcategorias", con);
                da.Fill(dt);

                gridSubcategorias.DataSource = dt;
                con.Close();
                //Nombretabla+Columns[n]+.Visible=true/false
                gridSubcategorias.Columns[2].Visible = false;
                gridSubcategorias.Columns[3].Visible = true;
                gridSubcategorias.Columns[3].Width = 70;
                gridSubcategorias.Columns[4].Visible = true;
                gridSubcategorias.Columns[5].Visible = true;
                gridSubcategorias.Columns[6].Visible = true;
                gridSubcategorias.Columns[6].Width = 300;
                gridSubcategorias.Columns[7].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden mostrar las subcategorías");
            }
        }

        private void btnSubcategorias_Click(object sender, EventArgs e)
        {
            pnlCategorias.Visible = false;
            pnlSubcategorias.Visible = true;
            pnlMarca.Visible = false;
            pnlFabrica.Visible = false;

            menuEditarSubCat.Visible = false;
            menuNuevaSubCat.Visible = false;

            ListarCategorias();
            MostrarSubcategorias();
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
                DialogResult preguntasub;
                preguntasub = MessageBox.Show("¿Está seguro de eliminar esta subcategoría?", "Eliminar Subcategoría", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preguntasub == DialogResult.Yes)
                {
                    SqlCommand sql;
                    try
                    {
                        foreach (DataGridViewRow filasub in gridSubcategorias.SelectedRows)
                        {
                            int id = Convert.ToInt32(filasub.Cells["ID"].Value);

                            try
                            {
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = CONEXION.Conexion.conectar;
                                con.Open();

                                sql = new SqlCommand("eliminar_subcategoria", con);
                                sql.CommandType = CommandType.StoredProcedure;
                                sql.Parameters.AddWithValue("@id_subcat", id);

                                sql.ExecuteNonQuery();

                                MessageBox.Show("Subcategoria eliminada correctamente");
                                con.Close();
                                MostrarSubcategorias();
                                LimpiarSubcategoria();
                                menuAgregarCat.Visible = true;
                                menuEditarCat.Visible = false;
                                menuNuevaCat.Visible = false;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("No se puede eliminar esta subcategoría");
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void EditarSubcategoria()
        {
            if (txtNombreSubcat.Text == "" && string.IsNullOrEmpty(txtDescripcionSubCat.Text))
            {
                MessageBox.Show("Campos vacíos, rellenelos");
            }
            else
            {
                if (txtNombreSubcat.Text != "")
                {
                    if (string.IsNullOrEmpty(txtDescripcionSubCat.Text))
                    {
                        MessageBox.Show("Digite la descripción de la subcategoría");
                    }
                    else
                    {
                        try
                        {
                            SqlConnection con = new SqlConnection();
                            con.ConnectionString = CONEXION.Conexion.conectar;
                            con.Open();

                            SqlCommand sql = new SqlCommand();
                            sql = new SqlCommand("editar_subcategoria", con);
                            sql.CommandType = CommandType.StoredProcedure;
                            sql.Parameters.AddWithValue("@id_cat", cbxCategoria.SelectedValue);
                            sql.Parameters.AddWithValue("@nombre_subcat", txtNombreSubcat.Text);
                            sql.Parameters.AddWithValue("@descripcion_subcat", txtDescripcionSubCat.Text);
                            sql.Parameters.AddWithValue("@id_subcat", lblIdSubCat.Text);

                            sql.ExecuteNonQuery();

                            MessageBox.Show("Subcategoria editada correctamente");
                            con.Close();
                            MostrarSubcategorias();
                            LimpiarSubcategoria();
                            menuAgregarSubCat.Visible = true;
                            menuEditarSubCat.Visible = false;
                            menuNuevaSubCat.Visible = false;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al editar subcategoría");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Subcategoría está vacía, digite");
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

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            pnlCategorias.Visible = false;
            pnlSubcategorias.Visible = false;
            pnlMarca.Visible = true;
            pnlFabrica.Visible = false;

            menuEditarMar.Visible = false;
            menuNuevaMar.Visible = false;

            ListarFabricas();
            MostrarMarcas();
        }

        private void btnFabricas_Click(object sender, EventArgs e)
        {
            pnlCategorias.Visible = false;
            pnlSubcategorias.Visible = false;
            pnlMarca.Visible = false;
            pnlFabrica.Visible = true;

            menuEditarFab.Visible = false;
            menuNuevaFab.Visible = false;

            MostrarFabricas();
        }

        private void btnLimpiarSubCat_Click(object sender, EventArgs e)
        {
           LimpiarSubcategoria();
        }

        private void CrearFabrica()
        {
            if (txtNombreFab.Text == "" && string.IsNullOrEmpty(txtDescripcionFab.Text))
            {
                MessageBox.Show("Hay campos vacios, digite!");
            }
            else
            {
                if (txtNombreFab.Text != "")
                {
                    if (string.IsNullOrEmpty(txtDescripcionFab.Text))
                    {
                        MessageBox.Show("Digite la descripción de la categoría");
                        txtDescripcionFab.Focus();
                    }
                    else
                    {
                        if (lblEligeFab.Visible==true)
                        {
                            MessageBox.Show("Inserte el logo de la fábrica");
                        }
                        else
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = CONEXION.Conexion.conectar;
                                con.Open();

                                SqlCommand sql = new SqlCommand();
                                sql = new SqlCommand("crear_fabrica", con);
                                sql.CommandType = CommandType.StoredProcedure;
                                sql.Parameters.AddWithValue("@nombre_fab", txtNombreFab.Text);
                                sql.Parameters.AddWithValue("@descripcion_fab", txtDescripcionFab.Text);
                                MemoryStream ms = new MemoryStream();
                                pbxFab.Image.Save(ms, pbxFab.Image.RawFormat);
                                sql.Parameters.AddWithValue("@logo_fab", ms.GetBuffer());
                                sql.Parameters.AddWithValue("@nombrelogo_fab", lblIcoFab.Text);

                                sql.ExecuteNonQuery();

                                MessageBox.Show("Fábrica insertada correctamente");
                                con.Close();
                                MostrarFabricas();
                                LimpiarFabrica();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error al insertar fábrica");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Digite el nombre de la categoría");
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
                SqlDataAdapter da;              //Para instanciar en una tabla

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_fabricas", con);
                da.Fill(dt);

                gridFabrica.DataSource = dt;
                con.Close();
                //Nombretabla+Columns[n]+.Visible=true/false
                gridFabrica.Columns[2].Visible = false;
                gridFabrica.Columns[3].Visible = true;
                gridFabrica.Columns[3].Width = 70;
                gridFabrica.Columns[4].Visible = true;
                gridFabrica.Columns[5].Visible = true;
                gridFabrica.Columns[5].Width = 300;
                gridFabrica.Columns[6].Visible = false;
                gridFabrica.Columns[7].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("No se pueden mostrar las fábricas");
            }
        }

        private void EditarFabrica()
        {
            if (txtNombreFab.Text == "" && string.IsNullOrEmpty(txtDescripcionFab.Text))
            {
                MessageBox.Show("Hay campos vacios, digite!");
            }
            else
            {
                if (txtNombreFab.Text != "")
                {
                    if (string.IsNullOrEmpty(txtDescripcionFab.Text))
                    {
                        MessageBox.Show("Digite la descripción de la categoría");
                        txtDescripcionFab.Focus();
                    }
                    else
                    {
                        if (lblEligeFab.Visible == true)
                        {
                            MessageBox.Show("Inserte el logo de la fábrica");
                        }
                        else
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = CONEXION.Conexion.conectar;
                                con.Open();

                                SqlCommand sql = new SqlCommand();
                                sql = new SqlCommand("editar_fabrica", con);
                                sql.CommandType = CommandType.StoredProcedure;
                                sql.Parameters.AddWithValue("@id_fab", lblIdFab.Text);
                                sql.Parameters.AddWithValue("@nombre_fab", txtNombreFab.Text);
                                sql.Parameters.AddWithValue("@descripcion_fab", txtDescripcionFab.Text);
                                MemoryStream ms = new MemoryStream();
                                pbxFab.Image.Save(ms, pbxFab.Image.RawFormat);
                                sql.Parameters.AddWithValue("@logo_fab", ms.GetBuffer());
                                sql.Parameters.AddWithValue("@nombrelogo_fab", lblIcoFab.Text);

                                sql.ExecuteNonQuery();

                                MessageBox.Show("Fábrica editada correctamente");
                                con.Close();
                                MostrarFabricas();
                                LimpiarFabrica();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error al editar fábrica");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Digite el nombre de la categoría");
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
                DialogResult preguntafab;
                preguntafab = MessageBox.Show("¿Está seguro de eliminar esta fábrica?", "Eliminar Fábrica", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preguntafab == DialogResult.Yes)
                {
                    SqlCommand sql;
                    try
                    {
                        foreach (DataGridViewRow filafab in gridFabrica.SelectedRows)
                        {
                            int id = Convert.ToInt32(filafab.Cells["ID"].Value);

                            try
                            {
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = CONEXION.Conexion.conectar;
                                con.Open();

                                sql = new SqlCommand("eliminar_fabrica", con);
                                sql.CommandType = CommandType.StoredProcedure;
                                sql.Parameters.AddWithValue("@id_fab", id);

                                sql.ExecuteNonQuery();

                                MessageBox.Show("Fábrica eliminada correctamente");
                                con.Close();
                                MostrarFabricas();
                                LimpiarFabrica();
                                menuAgregarCat.Visible = true;
                                menuEditarCat.Visible = false;
                                menuNuevaCat.Visible = false;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("No se puede eliminar esta subcategoría");
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
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
                MessageBox.Show("Digite el nombre de la marca");
            }
            else
            {
                if (lblEligeMarca.Visible==true)
                {
                    MessageBox.Show("Inserte el logo de la marca");
                }
                else
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();

                        SqlCommand sql = new SqlCommand();
                        sql = new SqlCommand("crear_marca", con);
                        sql.CommandType = CommandType.StoredProcedure;
                        sql.Parameters.AddWithValue("@nombre_mar", txtMarca.Text);
                        sql.Parameters.AddWithValue("@id_fab", cbxFabrica.SelectedValue);
                        MemoryStream ms = new MemoryStream();
                        pbxMarca.Image.Save(ms, pbxMarca.Image.RawFormat);
                        sql.Parameters.AddWithValue("@logo_mar", ms.GetBuffer());
                        sql.Parameters.AddWithValue("@nombrelogo_mar", lblIcoMarca.Text);

                        sql.ExecuteNonQuery();

                        MessageBox.Show("Marca insertada correctamente");
                        con.Close();
                        LimpiarMarcas();
                        MostrarMarcas();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al insertar marca");
                    }
                }
            }
        }

        private void ListarFabricas()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("listar_fabricas", con);
                da.Fill(dt);

                cbxFabrica.DisplayMember = "nombre_fab";
                cbxFabrica.ValueMember = "id_fab";
                cbxFabrica.DataSource = dt;

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Fábricas no invocadas");
            }
        }

        private void MostrarMarcas()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;              //Para instanciar en una tabla

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_marcas", con);
                da.Fill(dt);

                gridMarcas.DataSource = dt;
                con.Close();
                //Nombretabla+Columns[n]+.Visible=true/false
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
                MessageBox.Show("No se pueden mostrar las fábricas");
            }
        }

        

        private void EditarMarca()
        {
            if (txtMarca.Text == "")
            {
                MessageBox.Show("Digite el nombre de la marca");
            }
            else
            {
                if (lblEligeMarca.Visible == true)
                {
                    MessageBox.Show("Inserte el logo de la marca");
                }
                else
                {
                    try
                    {
                        SqlConnection con = new SqlConnection();
                        con.ConnectionString = CONEXION.Conexion.conectar;
                        con.Open();

                        SqlCommand sql = new SqlCommand();
                        sql = new SqlCommand("editar_marca", con);
                        sql.CommandType = CommandType.StoredProcedure;
                        sql.Parameters.AddWithValue("@id_mar", lblIdMarca.Text);
                        sql.Parameters.AddWithValue("@nombre_mar", txtMarca.Text);
                        sql.Parameters.AddWithValue("@id_fab", cbxFabrica.SelectedValue);
                        MemoryStream ms = new MemoryStream();
                        pbxMarca.Image.Save(ms, pbxMarca.Image.RawFormat);
                        sql.Parameters.AddWithValue("@logo_mar", ms.GetBuffer());
                        sql.Parameters.AddWithValue("@nombrelogo_mar", lblIcoMarca.Text);

                        sql.ExecuteNonQuery();

                        MessageBox.Show("Marca editada correctamente");
                        con.Close();
                        MostrarMarcas();
                        LimpiarMarcas();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al editar marca");
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
                DialogResult preguntamar;
                preguntamar = MessageBox.Show("¿Está seguro de eliminar esta marca?", "Eliminar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preguntamar == DialogResult.Yes)
                {
                    SqlCommand sql;
                    try
                    {
                        foreach (DataGridViewRow filamar in gridMarcas.SelectedRows)
                        {
                            int id = Convert.ToInt32(filamar.Cells["ID"].Value);

                            try
                            {
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = CONEXION.Conexion.conectar;
                                con.Open();

                                sql = new SqlCommand("eliminar_marca", con);
                                sql.CommandType = CommandType.StoredProcedure;
                                sql.Parameters.AddWithValue("@id_mar", id);

                                sql.ExecuteNonQuery();

                                MessageBox.Show("Marca eliminada correctamente");
                                con.Close();
                                MostrarMarcas();
                                LimpiarMarcas();
                                menuAgregarMarca.Visible = true;
                                menuEditarMar.Visible = false;
                                menuNuevaMar.Visible = false;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("No se puede eliminar esta marca");
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
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
            LimpiarMarcas();
            menuAgregarMarca.Visible = true;
            menuEditarMar.Visible = false;
            menuNuevaMar.Visible = false;
        }

        private void btnNuevaSubCat_Click(object sender, EventArgs e)
        {
            LimpiarSubcategoria();
            menuAgregarSubCat.Visible = true;
            menuEditarSubCat.Visible = false;
            menuNuevaSubCat.Visible = false;
        }

        private void BuscarCategorias()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("buscar_categorias", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@multi",txtBuscaCat.Text);
                da.Fill(dt);

                gridCategorias.DataSource = dt;

                con.Close();

                gridCategorias.Columns[2].Visible = false;
                gridCategorias.Columns[3].Visible = true;
                gridCategorias.Columns[3].Width = 70;
                gridCategorias.Columns[4].Visible = true;
                gridCategorias.Columns[5].Visible = true;
                gridCategorias.Columns[5].Width = 300;
            }
            catch (Exception)
            {

            }
        }

        private void BuscarSubcategorias()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("buscar_subcategorias", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@multi", txtBuscarSubCat.Text);
                da.Fill(dt);

                gridSubcategorias.DataSource = dt;

                con.Close();

                gridSubcategorias.Columns[2].Visible = false;
                gridSubcategorias.Columns[3].Visible = true;
                gridSubcategorias.Columns[3].Width = 70;
                gridSubcategorias.Columns[4].Visible = true;
                gridSubcategorias.Columns[5].Visible = true;
                gridSubcategorias.Columns[6].Visible = true;
                gridSubcategorias.Columns[6].Width = 300;
            }
            catch (Exception)
            {

            }
        }

        private void BuscarFabricas()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("buscar_fabricas", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@multi", txtBuscarFab.Text);
                da.Fill(dt);

                gridFabrica.DataSource = dt;

                con.Close();

                gridFabrica.Columns[2].Visible = false;
                gridFabrica.Columns[3].Visible = true;
                gridFabrica.Columns[3].Width = 70;
                gridFabrica.Columns[4].Visible = true;
                gridFabrica.Columns[5].Visible = true;
                gridFabrica.Columns[5].Width = 300;
                gridFabrica.Columns[6].Visible = false;
                gridFabrica.Columns[7].Visible = false;
            }
            catch (Exception)
            {

            }
        }

        private void BuscarMarcas()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("buscar_marcas", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@multi", txtBuscarMar.Text);
                da.Fill(dt);

                gridMarcas.DataSource = dt;

                con.Close();

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
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void ValidarRichTextBox(RichTextBox sCaneda, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtNombreCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTextBox(txtNombreCat, e);
        }

        private void txtDescripcionCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarRichTextBox(txtDescripcionCat, e);
        }

        private void txtNombreSubcat_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTextBox(txtNombreSubcat, e);
        }

        private void txtNombreFab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDescripcionSubCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarRichTextBox(txtDescripcionSubCat, e);
        }

        private void txtDescripcionFab_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarRichTextBox(txtDescripcionFab, e);
        }
    }
}
