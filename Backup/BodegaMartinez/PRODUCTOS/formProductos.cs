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
    public partial class formProductos : Form
    {
        public formProductos()
        {
            InitializeComponent();
        }

        public static string cajastatic;

        private void txtPrecioCompra_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            formImportarExcel exe = new formImportarExcel();
            exe.ShowDialog();
        }

        private void formProductos_Load(object sender, EventArgs e)
        {
            //checkInventario.Appearance = Appearance.Button;
            //checkInventario.Font = new Font("Microsoft Sans Serif", 4);
            //checkInventario.AutoSize = false;
            //checkInventario.Size = new Size(50, 50);

            Mostrar_IdCaja_Serial();
            pnlMarca.Visible = false;
            pnlSubcategorias.Visible = false;
            MostrarProductos();
            ContarProductos();
            SumarInversion();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlRegistrarProd.Visible = false;
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            pnlRegistrarProd.Visible = true;
            btnModificar.Visible = false;
        }

        private void checkInventario_CheckedChanged(object sender, EventArgs e)
        {
            if (checkInventario.Checked)
            {
                pnlOpcionesInv.Visible = true;
            }
            else
            {
                pnlOpcionesInv.Visible = false;
            }
        }

        private void CrearProducto()
        {
            if (txtDescripcion.Text!=null)
            {
                if (txtCategoria.Text!=null)
                {
                    if (txtMarca.Text!=null)
                    {
                        if (txtPrecioCompra.Text!=null)
                        {
                            if (txtPrecioVenta.Text!=null)
                            {
                                if (txtPrecioMayor.Text!=null)
                                {
                                    if (txtCodigo.Text!=null)
                                    {
                                        if (txtCantMayor.Value>=3)
                                        {
                                            if (lblEligeProd.Visible==false)
                                            {
                                                try
                                                {
                                                    SqlConnection con = new SqlConnection();
                                                    con.ConnectionString = CONEXION.Conexion.conectar;
                                                    con.Open();

                                                    SqlCommand sql = new SqlCommand();
                                                    sql = new SqlCommand("crear_producto", con);
                                                    sql.CommandType = CommandType.StoredProcedure;
                                                    sql.Parameters.AddWithValue("@nombre_prod", txtDescripcion.Text);

                                                    MemoryStream ms = new MemoryStream();
                                                    pbxImagenProd.Image.Save(ms, pbxImagenProd.Image.RawFormat);
                                                    sql.Parameters.AddWithValue("@imagen_prod", ms.GetBuffer());
                                                    sql.Parameters.AddWithValue("@nombre_imagen", lblProducto.Text);
                                                    sql.Parameters.AddWithValue("@id_categoria", lblIdCat_Sub.Text);
                                                    sql.Parameters.AddWithValue("@id_subcategoria", lblIdSubCat.Text);
                                                    sql.Parameters.AddWithValue("@id_marca", lblIdMarca.Text);

                                                    if (checkInventario.Checked)
                                                    {
                                                        sql.Parameters.AddWithValue("@usa_inventario", "SI");
                                                        
                                                        sql.Parameters.AddWithValue("@stock", txtStock.Text);
                                                        sql.Parameters.AddWithValue("@stock_min", txtMinimo.Text);


                                                        if (checkVenc.Checked)
                                                        {
                                                            sql.Parameters.AddWithValue("@fecha_venc", "2100-01-01");
                                                        }
                                                        else
                                                        {
                                                            sql.Parameters.AddWithValue("@fecha_venc", dateVencimiento.Value);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        sql.Parameters.AddWithValue("@usa_inventario", "NO");
                                                        sql.Parameters.AddWithValue("@stock", 0);
                                                        sql.Parameters.AddWithValue("@stock_min", 0);
                                                        sql.Parameters.AddWithValue("@fecha_venc", "2100-01-01");
                                                    }

                                                    sql.Parameters.AddWithValue("@precio_compra", txtPrecioCompra.Text);
                                                    sql.Parameters.AddWithValue("@precio_venta", txtPrecioVenta.Text);
                                                    sql.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                                                    sql.Parameters.AddWithValue("@precio_mayor", txtPrecioMayor.Text);
                                                    sql.Parameters.AddWithValue("@cant_mayor", txtCantMayor.Text);
                                                    sql.Parameters.AddWithValue("@impuesto", 0);

                                                    if (radUnidad.Checked == true)
                                                    {
                                                        sql.Parameters.AddWithValue("@tipo_prod", "UNIDAD");
                                                    }

                                                    if (radGranel.Checked == true)
                                                    {
                                                        sql.Parameters.AddWithValue("@tipo_prod", "GRANEL");
                                                    }

                                                    sql.Parameters.AddWithValue("@fecha", DateTime.Now);
                                                    sql.Parameters.AddWithValue("@motivo", "Registro inicial del producto");
                                                    sql.Parameters.AddWithValue("@cantidad", txtStock.Text);
                                                    sql.Parameters.AddWithValue("@usuario", LOGIN.formLogin.id_usuario);
                                                    sql.Parameters.AddWithValue("@tipo", "ENTRADA");
                                                    sql.Parameters.AddWithValue("@estado", "CONFIRMO");
                                                    sql.Parameters.AddWithValue("@id_caja", lblIdCajaSerial.Text);

                                                    sql.ExecuteNonQuery();

                                                    MessageBox.Show("Producto insertado correctamente");
                                                    con.Close();

                                                    MostrarProductos();
                                                    pnlRegistrarProd.Visible = false;
                                                    LimpiarProducto();
                                                    ContarProductos();
                                                    SumarInversion();
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Inserte la imagen del producto");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("La cantidad mínima es 3, modifique");
                                            txtCantMayor.Value = 0;
                                            txtCantMayor.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Digite el código del producto");
                                        txtCodigo.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Digite el precio por mayor del producto");
                                    txtPrecioMayor.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Digite el precio de venta del producto");
                                txtPrecioVenta.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Digite el precio de compra del producto");
                            txtPrecioCompra.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione la marca del producto");
                        pnlMarca.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione la subcategoría del producto");
                    pnlSubcategorias.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Descripción vacía, digitela!");
                txtDescripcion.Focus();
            }
        }

        private void MostrarProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_productos", con);
                da.Fill(dt);

                gridProductos.DataSource = dt;
                con.Close();
                //Nombretabla+Columns[n]+.Visible=true/false
                gridProductos.Columns[2].Visible = false;
                gridProductos.Columns[3].Visible = true;
                gridProductos.Columns[4].Visible = false;
                gridProductos.Columns[5].Visible = false;
                gridProductos.Columns[6].Visible = false;
                gridProductos.Columns[7].Visible = true;
                gridProductos.Columns[8].Visible = false;
                gridProductos.Columns[9].Visible = true;
                gridProductos.Columns[10].Visible = false;
                gridProductos.Columns[11].Visible = true;
                gridProductos.Columns[12].Visible = false;
                gridProductos.Columns[13].Visible = true;
                gridProductos.Columns[14].Visible = false;
                gridProductos.Columns[15].Visible = true;
                gridProductos.Columns[16].Visible = false;
                gridProductos.Columns[17].Visible = true;
                gridProductos.Columns[18].Visible = true;
                gridProductos.Columns[19].Visible = true;
                gridProductos.Columns[20].Visible = false;
                gridProductos.Columns[21].Visible = false;
                gridProductos.Columns[22].Visible = false;
            }
            catch (Exception ex)
            {
                
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref gridProductos);
        }

        private void EditarProducto()
        {
            if (txtDescripcion.Text != null)
            {
                if (txtCategoria.Text != null)
                {
                    if (txtMarca.Text != null)
                    {
                        if (txtPrecioCompra.Text != null)
                        {
                            if (txtPrecioVenta.Text != null)
                            {
                                if (txtPrecioMayor.Text != null)
                                {
                                    if (txtCodigo.Text != null)
                                    {
                                        if (txtCantMayor.Value >= 3)
                                        {
                                            if (lblEligeProd.Visible == false)
                                            {
                                                try
                                                {
                                                    SqlConnection con = new SqlConnection();
                                                    con.ConnectionString = CONEXION.Conexion.conectar;
                                                    con.Open();

                                                    SqlCommand sql = new SqlCommand();
                                                    sql = new SqlCommand("editar_producto", con);
                                                    sql.CommandType = CommandType.StoredProcedure;
                                                    sql.Parameters.AddWithValue("@id_prod", lblIdProd.Text);
                                                    sql.Parameters.AddWithValue("@nombre_prod", txtDescripcion.Text);

                                                    MemoryStream ms = new MemoryStream();
                                                    pbxImagenProd.Image.Save(ms, pbxImagenProd.Image.RawFormat);
                                                    sql.Parameters.AddWithValue("@imagen_prod", ms.GetBuffer());
                                                    sql.Parameters.AddWithValue("@nombre_imagen", lblProducto.Text);
                                                    sql.Parameters.AddWithValue("@id_categoria", lblIdCat_Sub.Text);
                                                    sql.Parameters.AddWithValue("@id_subcategoria", lblIdSubCat.Text);
                                                    sql.Parameters.AddWithValue("@id_marca", lblIdMarca.Text);


                                                    sql.Parameters.AddWithValue("@precio_compra", txtPrecioCompra.Text);
                                                    sql.Parameters.AddWithValue("@precio_venta", txtPrecioVenta.Text);
                                                    sql.Parameters.AddWithValue("@codigo", txtCodigo.Text);
                                                    sql.Parameters.AddWithValue("@precio_mayor", txtPrecioMayor.Text);
                                                    sql.Parameters.AddWithValue("@cant_mayor", txtCantMayor.Text);
                                                    sql.Parameters.AddWithValue("@impuesto", 0);

                                                    if (radUnidad.Checked)
                                                    {
                                                        sql.Parameters.AddWithValue("@tipo_prod", "UNIDAD");
                                                    }

                                                    if (radGranel.Checked)
                                                    {
                                                        sql.Parameters.AddWithValue("@tipo_prod", "GRANEL");
                                                    }

                                                    sql.ExecuteNonQuery();

                                                    MessageBox.Show("Producto editado correctamente");
                                                    con.Close();

                                                    pnlRegistrarProd.Visible = false;
                                                    MostrarProductos();
                                                    LimpiarProducto();
                                                    ContarProductos();
                                                    SumarInversion();
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Inserte la imagen del producto");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("La cantidad mínima es 3, modifique");
                                            txtCantMayor.Value = 0;
                                            txtCantMayor.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Digite el código del producto");
                                        txtCodigo.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Digite el precio por mayor del producto");
                                    txtPrecioMayor.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Digite el precio de venta del producto");
                                txtPrecioVenta.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Digite el precio de compra del producto");
                            txtPrecioCompra.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione la marca del producto");
                        pnlMarca.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione la subcategoría del producto");
                    pnlSubcategorias.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Descripción vacía, digitela!");
                txtDescripcion.Focus();
            }
        }

        private void Mostrar_IdCaja_Serial()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("SELECT id_caja FROM t_caja WHERE serial_pc = '"+LOGIN.formLogin.serial+"'", con);

                lblIdCajaSerial.Text = "";
                lblIdCajaSerial.Text = Convert.ToString(sql.ExecuteScalar());

                cajastatic = lblIdCajaSerial.Text;

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("El caja no existe en la bd");
            }
        }

        private void LlamarImagen()
        {
            dlgProducto.InitialDirectory = "";                   //ruta de inicio de visualizacion
            dlgProducto.Filter = "Imagenes|*.jpg;*.png";         //que tipo de archivos deseo ver
            dlgProducto.FilterIndex = 2;
            dlgProducto.Title = "Logo para fábrica";             //Titulo de la ventana
            if (dlgProducto.ShowDialog() == DialogResult.OK)
            {
                pbxImagenProd.BackgroundImage = null;
                pbxImagenProd.Image = new Bitmap(dlgProducto.FileName); //capturo la imagen que seleccione
                lblProducto.Text = Path.GetFileName(dlgProducto.FileName);
                lblEligeProd.Visible = false;
            }
        }

        private void btnGuardarProd_Click(object sender, EventArgs e)
        {
            CrearProducto();
            pnlRegistrarProd.Visible = false;
        }

        private void pbxImagenProd_Click(object sender, EventArgs e)
        {
            LlamarImagen();
        }

        private void lblEligeProd_Click(object sender, EventArgs e)
        {
            LlamarImagen();
        }

        private void pbxSubCat_Click(object sender, EventArgs e)
        {
            pnlSubcategorias.Visible = true;
            pnlMarca.Visible = false;

            MostrarSubcategorias();
        }

        private void pbxMarca_Click(object sender, EventArgs e)
        {
            
            pnlSubcategorias.Visible = false;
            pnlMarca.Visible = true;

            MostrarMarcas();
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

        private void LimpiarSubcategoria()
        {
            txtNombreSubcat.Clear();
            txtDescripcionSubCat.Clear();
            txtBuscarSubCat.Clear();
            lblIdSubCat.Text = "";
            txtNombreCat.Clear();
            txtNombreSubcat.Focus();
        }

        private void btnAgregarSubCat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditarSubCat_Click(object sender, EventArgs e)
        {
        }

        private void btnLimpiarSubCat_Click(object sender, EventArgs e)
        {
            LimpiarSubcategoria();
        }

        private void btnNuevaSubCat_Click(object sender, EventArgs e)
        {
        }


        private void btnElegir_Click(object sender, EventArgs e)
        {
            if (txtNombreCat.Text!=null && txtNombreSubcat.Text!=null)
            {
                txtCategoria.Text = txtNombreCat.Text;
                txtSubcategoria.Text = txtNombreSubcat.Text;
                pnlSubcategorias.Visible = false;
            }
            else
            {
                MessageBox.Show("Campos vacíos, seleccione una opción");
            }
        }

        private void gridSubcategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdSubCat.Text = gridSubcategorias.SelectedCells[2].Value.ToString();
            txtNombreCat.Text = gridSubcategorias.SelectedCells[4].Value.ToString();
            txtNombreSubcat.Text = gridSubcategorias.SelectedCells[5].Value.ToString();
            txtDescripcionSubCat.Text = gridSubcategorias.SelectedCells[6].Value.ToString();
            lblIdCat_Sub.Text = gridSubcategorias.SelectedCells[7].Value.ToString();
        }

        private void btnLimpiarMar_Click(object sender, EventArgs e)
        {
            LimpiarMarcas();
        }

        private void btnElegirMarca_Click(object sender, EventArgs e)
        {
            if (txtNombreMarca.Text!=null)
            {
                txtMarca.Text = txtNombreMarca.Text;
                pnlMarca.Visible = false;
                LimpiarMarcas();
            }
            else
            {
                MessageBox.Show("Seleccione una marca, por favor");
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

        

        private void LimpiarMarcas()
        {
            txtMarca.Clear();
            txtFabrica.Clear();
            txtBuscarMar.Clear();
            pbxMarca.BackgroundImage = null;
            lblIcoMarca.Text = "";
            
            lblIdMarca.Text = "";

            txtMarca.Focus();
        }

        private void gridMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            lblIdMarca.Text = gridMarcas.SelectedCells[2].Value.ToString();
            txtNombreMarca.Text = gridMarcas.SelectedCells[4].Value.ToString();
            txtFabrica.Text = gridMarcas.SelectedCells[5].Value.ToString();

            pbxMarca.BackgroundImage = null;
            byte[] b = (Byte[])gridMarcas.SelectedCells[6].Value;
            MemoryStream ms = new MemoryStream(b);
            pbxMarca.Image = Image.FromStream(ms);

            lblIcoMarca.Text = gridMarcas.SelectedCells[7].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            EditarProducto();
        }

        private void gridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string tipo;

            if (e.ColumnIndex == this.gridProductos.Columns["EdiProd"].Index)
            {
                lblIdProd.Text = gridProductos.SelectedCells[2].Value.ToString();
                txtDescripcion.Text = gridProductos.SelectedCells[3].Value.ToString();

                pbxImagenProd.BackgroundImage = null;
                byte[] b = (Byte[])gridProductos.SelectedCells[4].Value;
                MemoryStream ms = new MemoryStream(b);
                pbxImagenProd.Image = Image.FromStream(ms);
                lblEligeProd.Visible = false;
                lblProducto.Text = gridProductos.SelectedCells[5].Value.ToString();

                lblIdCat_Sub.Text = gridProductos.SelectedCells[6].Value.ToString();
                txtCategoria.Text = gridProductos.SelectedCells[7].Value.ToString();
                lblIdSubCat.Text = gridProductos.SelectedCells[8].Value.ToString();
                txtSubcategoria.Text = gridProductos.SelectedCells[9].Value.ToString();
                lblIdMarca.Text = gridProductos.SelectedCells[10].Value.ToString();
                txtMarca.Text = gridProductos.SelectedCells[11].Value.ToString();
                //lblIdSubCat.Text = gridProductos.SelectedCells[12].Value.ToString();
                txtStock.Text = gridProductos.SelectedCells[13].Value.ToString();
                txtPrecioCompra.Text = gridProductos.SelectedCells[14].Value.ToString();
                txtPrecioVenta.Text = gridProductos.SelectedCells[15].Value.ToString();
                dateVencimiento.Value = (DateTime)gridProductos.SelectedCells[16].Value;
                txtCodigo.Text = gridProductos.SelectedCells[17].Value.ToString();
                txtPrecioMayor.Text = gridProductos.SelectedCells[18].Value.ToString();
                txtCantMayor.Text = gridProductos.SelectedCells[19].Value.ToString();
                //.Text = gridProductos.SelectedCells[20].Value.ToString();
                txtMinimo.Text = gridProductos.SelectedCells[21].Value.ToString();
                tipo = gridProductos.SelectedCells[22].Value.ToString();

                if (tipo=="UNIDAD")
                {
                    radUnidad.Checked = true;
                }
                if (tipo == "GRANEL")
                {
                    radGranel.Checked = true;
                }
                btnGuardarProd.Visible = false;
                btnModificar.Visible = true;
                pnlRegistrarProd.Visible = true;
                pnlInventario.Enabled = false;
                pnlInventario.Visible = false;
                //pnlOpcionesInv.Visible = true;
            }

            if (e.ColumnIndex == this.gridProductos.Columns["EliProd"].Index)
            {
                DialogResult preguntaprod;
                preguntaprod = MessageBox.Show("¿Está seguro de eliminar este producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preguntaprod == DialogResult.Yes)
                {
                    SqlCommand sql;
                    try
                    {
                        foreach (DataGridViewRow filaprod in gridProductos.SelectedRows)
                        {
                            int id = Convert.ToInt32(filaprod.Cells["ID"].Value);

                            try
                            {
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = CONEXION.Conexion.conectar;
                                con.Open();

                                sql = new SqlCommand("eliminar_producto", con);
                                sql.CommandType = CommandType.StoredProcedure;
                                sql.Parameters.AddWithValue("@id_prod", id);

                                sql.ExecuteNonQuery();

                                MessageBox.Show("Producto eliminado correctamente");
                                con.Close();
                                MostrarProductos();
                                LimpiarProducto();
                                ContarProductos();
                                SumarInversion();
                                btnModificar.Visible = false;
                                btnGuardarProd.Visible = true;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("No se puede eliminar este producto");
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void LimpiarProducto()
        {
            txtDescripcion.Clear();
            txtCategoria.Clear();
            txtSubcategoria.Clear();
            txtMarca.Clear();
            txtPrecioCompra.Clear();
            txtGanancia.Clear();
            txtPrecioVenta.Clear();
            txtPrecioMayor.Clear();
            txtCantMayor.Value=0;
            txtCodigo.Clear();
            txtStock.Value = 0;
            txtMinimo.Value = 0;

            lblIdProd.Text = "";
            lblIdCat_Sub.Text = "";
            lblIdSubCat.Text = "";
            lblIdMarca.Text = "";
            lblProducto.Text = "";

            pbxImagenProd.BackgroundImage = null;
            lblEligeProd.Visible = true;
        }

        private void ContarProductos()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("contar_productos", con);
                sql.CommandType = CommandType.StoredProcedure;

                lblCantidadProd.Text = "";
                lblCantidadProd.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        private void SumarInversion()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("sumar_inversion", con);
                sql.CommandType = CommandType.StoredProcedure;

                lblCostoProd.Text = "";
                lblCostoProd.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarProducto();
        }

        private void txtBuscarProd_TextChanged(object sender, EventArgs e)
        {
            BuscarProductos();
        }

        private void BuscarProductosAuto()
        {
            
        }

        private void BuscarProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("buscar_productos", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@multi", txtBuscarProd.Text);
                da.Fill(dt);
                gridProductos.DataSource = dt;
                con.Close();

                gridProductos.Columns[2].Visible = false;
                gridProductos.Columns[3].Visible = true;
                gridProductos.Columns[4].Visible = false;
                gridProductos.Columns[5].Visible = false;
                gridProductos.Columns[6].Visible = false;
                gridProductos.Columns[7].Visible = true;
                gridProductos.Columns[8].Visible = false;
                gridProductos.Columns[9].Visible = true;
                gridProductos.Columns[10].Visible = false;
                gridProductos.Columns[11].Visible = true;
                gridProductos.Columns[12].Visible = false;
                gridProductos.Columns[13].Visible = true;
                gridProductos.Columns[14].Visible = false;
                gridProductos.Columns[15].Visible = true;
                gridProductos.Columns[16].Visible = false;
                gridProductos.Columns[17].Visible = true;
                gridProductos.Columns[18].Visible = true;
                gridProductos.Columns[19].Visible = true;
                gridProductos.Columns[20].Visible = false;
                gridProductos.Columns[21].Visible = false;
                gridProductos.Columns[22].Visible = false;
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BuscarProductosAuto();
        }

        private void btnCodigo_Click(object sender, EventArgs e)
        {
            GenerarCodigoBarras();
        }

        private void GenerarCodigoBarras()
        {
            Double resultado;
            string queryMoneda;
            queryMoneda = "SELECT max(id_prod)  FROM t_productos";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.Conexion.conectar;
            SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            try
            {
                con.Open();
                resultado = Convert.ToDouble(comMoneda.ExecuteScalar()) + 1;
                con.Close();
            }
            catch (Exception ex)
            {
                resultado = 1;
            }

            string Cadena = txtSubcategoria.Text;
            string[] Palabra;
            String espacio = " ";
            Palabra = Cadena.Split(Convert.ToChar(espacio));
            try
            {

                txtCodigo.Text = resultado + Palabra[0].Substring(0, 2) + 20;
            }
            catch (Exception ex)
            {
            }
        }

        private void ValidarDecimales(TextBox sCadena, KeyPressEventArgs e)
        {
            char signo_decimal = (char)46;

            if (e.KeyChar == signo_decimal)
            {
                if (sCadena.Text.Length == 0 | sCadena.Text.LastIndexOf(signo_decimal) >= 0)
                {
                    e.Handled = true; // Interceptamos la pulsación para que no permitirla.
                }
                else //Si hay caracteres continuamos las comprobaciones
                {
                    //Cambiamos la pulsación al separador decimal definido por el sistema 
                    e.KeyChar = Convert.ToChar(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator);
                    e.Handled = false; // No hacemos nada y dejamos que el sistema controle la pulsación de tecla
                }
                return;
            }
            else if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDecimales(txtPrecioCompra, e);
        }

        private void txtGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDecimales(txtGanancia, e);
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDecimales(txtPrecioVenta, e);
        }

        private void txtPrecioMayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDecimales(txtPrecioMayor, e);
        }

        private void txtBuscarMar_TextChanged(object sender, EventArgs e)
        {
            BuscarMarcas();
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

        private void txtBuscarSubCat_TextChanged(object sender, EventArgs e)
        {
            BuscarSubcategorias();
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
    }
}
