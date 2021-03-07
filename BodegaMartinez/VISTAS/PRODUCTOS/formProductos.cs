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
    public partial class formProductos : Form
    {
        public formProductos()
        {
            InitializeComponent();
        }

        public static string cajastatic;

        Producto producto = new Producto();
        ProductosDao funcionProducto = new ProductosDao();

        Inventario inventario = new Inventario();

        Caja caja = new Caja();
        CajasDao funcionCaja = new CajasDao();

        SubcategoriasDao funcionSubcategoria = new SubcategoriasDao();
        MarcasDao funcionMarca = new MarcasDao();

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
            Mostrar_IdCaja_Serial();
            MostrarProductos();
            pnlTabulacion.Visible = true;
            gridProductos.Visible = true;
            gridProductos.Dock = DockStyle.Fill;
            ContarProductos();
            SumarInversion();
            ConteoDataTable();
            ValidarPaginador();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlTabulacion.Visible = true;
            gridProductos.Visible = true;
            pnlRegistrarProd.Visible = false;
            gridProductos.Dock = DockStyle.Fill;
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            pnlTabulacion.Visible = false;
            gridProductos.Visible = false;
            pnlRegistrarProd.Visible = true;
            pnlRegistrarProd.Dock = DockStyle.Fill;

            btnGuardarProd.Visible = true;
            btnModificar.Visible = false;
            pnlInventario.Enabled = true;
            pnlInventario.Visible = true;
            LimpiarProducto();
        }

        private void checkInventario_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void CrearProducto()
        {
            if (txtDescripcionProducto.Text!="")
            {
                if (txtCategoria.Text!="")
                {
                    if (txtMarca.Text!="")
                    {
                        if (txtPrecioCompra.Text!="")
                        {
                            if (txtPrecioVenta.Text!="")
                            {
                                if (txtPrecioMayor.Text!="")
                                {
                                    if (txtCodigo.Text!="")
                                    {
                                        if (txtCantMayor.Value>=3)
                                        {
                                            if (lblEligeProd.Visible==false)
                                            {
                                                try
                                                {
                                                    MemoryStream ms = new MemoryStream();
                                                    pbxImagenProd.Image.Save(ms, pbxImagenProd.Image.RawFormat);
                                                    byte[] imagen = ms.GetBuffer();

                                                    producto.NombreProducto = txtDescripcionProducto.Text;
                                                    producto.ImagenProducto = imagen;
                                                    producto.NombreImagen = lblProducto.Text;
                                                    producto.IdCategoria = Convert.ToInt32(lblIdCat.Text);
                                                    producto.IdSubcategoria = Convert.ToInt32(lblIdSubCat.Text);
                                                    producto.IdMarca = Convert.ToInt32(lblIdMarca.Text);

                                                    if (checkInv.Checked)
                                                    {
                                                        producto.UsaInventario = "SI";
                                                        producto.Stock = Convert.ToInt32(txtStock.Text);
                                                        producto.StockMinimo = Convert.ToInt32(txtMinimo.Text);

                                                        if (checkVenc.Checked)
                                                        {
                                                            producto.FechaVencimiento = "NO APLICA";
                                                        }
                                                        else
                                                        {
                                                            producto.FechaVencimiento = dateVencimiento.Text;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        producto.UsaInventario = "NO";
                                                        producto.Stock = 0;
                                                        producto.StockMinimo = 0;
                                                        producto.FechaVencimiento = "NO APLICA";
                                                    }

                                                    producto.PrecioCompra = Convert.ToDouble(txtPrecioCompra.Text);
                                                    producto.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                                                    producto.Codigo = txtCodigo.Text;
                                                    producto.PrecioMayor = Convert.ToDouble(txtPrecioMayor.Text);
                                                    producto.CantidadMayor = Convert.ToInt32(txtCantMayor.Text);
                                                    producto.Impuesto = 0;
                                                    producto.Estado = "ACTIVADO";
                                                    producto.FechaRegistro = DateTime.Now;

                                                    if (radUnidad.Checked == true)
                                                    {
                                                        producto.TipoProducto = "UNIDAD";
                                                    }

                                                    if (radGranel.Checked == true)
                                                    {
                                                        producto.TipoProducto = "GRANEL";
                                                    }

                                                    inventario.Fecha = DateTime.Now;
                                                    inventario.Motivo = "Registro inicial del producto";
                                                    inventario.Cantidad = Convert.ToInt32(txtStock.Text);
                                                    inventario.IdUsuario = Convert.ToInt32(LOGIN.formLogin.id_usuario);
                                                    inventario.Tipo = "ENTRADA";
                                                    inventario.Estado = "CONFIRMO";
                                                    inventario.IdCaja = Convert.ToInt32(lblIdCajaSerial.Text);

                                                    if (funcionProducto.InsertarProducto(producto, inventario) == true)
                                                    {
                                                        MessageBox.Show("¡Producto registrado exitosamente!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        MostrarProductos();
                                                        pnlRegistrarProd.Visible = false;
                                                        LimpiarProducto();
                                                        ContarProductos();
                                                        SumarInversion();
                                                        ConteoDataTable();
                                                        ValidarPaginador();
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("La imagen está vacía, ¡Insértela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("La cantidad mínima es 3, ¡Modifíquelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            txtCantMayor.Value = 0;
                                            txtCantMayor.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El código esta vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtCodigo.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El precio por mayor está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtPrecioMayor.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El precio venta está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPrecioVenta.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El precio compra está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPrecioCompra.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La marca está vacía, ¡Seleccione!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //pnlMarca.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("La subcategoría está vacía, ¡Seleccione!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //pnlSubcategorias.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("La descripción está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcionProducto.Focus();
            }
        }


        private void MostrarProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                ProductosDao.MostrarProductos(ref dt);

                gridProductos.DataSource = dt;

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

                ContarProductos();
                ConteoDataTable();
                ValidarPaginador();
                txtPagActual.Text = "1";
                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = true;

            }
            catch (Exception)
            {
                MessageBox.Show("No se muestran los datos", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Datatables_tamañoAuto.Multilinea(ref gridProductos);
        }

        private void EditarProducto()
        {
            if (txtDescripcionProducto.Text != "")
            {
                if (txtCategoria.Text != "")
                {
                    if (txtMarca.Text != "")
                    {
                        if (txtPrecioCompra.Text != "")
                        {
                            if (txtPrecioVenta.Text != "")
                            {
                                if (txtPrecioMayor.Text != "")
                                {
                                    if (txtCodigo.Text != "")
                                    {
                                        if (txtCantMayor.Value >= 3)
                                        {
                                            if (lblEligeProd.Visible == false)
                                            {
                                                try
                                                {
                                                    MemoryStream ms = new MemoryStream();
                                                    pbxImagenProd.Image.Save(ms, pbxImagenProd.Image.RawFormat);
                                                    byte[] imagen = ms.GetBuffer();

                                                    producto.IdProducto = Convert.ToInt32(lblIdProd.Text);
                                                    producto.NombreProducto = txtDescripcionProducto.Text;
                                                    producto.ImagenProducto = imagen;
                                                    producto.NombreImagen = lblProducto.Text;
                                                    producto.IdCategoria = Convert.ToInt32(lblIdCat_Sub.Text);
                                                    producto.IdSubcategoria = Convert.ToInt32(lblIdSubCat.Text);
                                                    producto.IdMarca = Convert.ToInt32(lblIdMarca.Text);
                                                    producto.PrecioCompra = Convert.ToDouble(txtPrecioCompra.Text);
                                                    producto.PrecioVenta = Convert.ToDouble(txtPrecioVenta.Text);
                                                    producto.Codigo = txtCodigo.Text;
                                                    producto.PrecioMayor = Convert.ToDouble(txtPrecioMayor.Text);
                                                    producto.CantidadMayor = Convert.ToInt32(txtCantMayor.Text);
                                                    producto.Impuesto = 0;

                                                    if (radUnidad.Checked == true)
                                                    {
                                                        producto.TipoProducto = "UNIDAD";
                                                    }

                                                    if (radGranel.Checked == true)
                                                    {
                                                        producto.TipoProducto = "GRANEL";
                                                    }

                                                    if (funcionProducto.EditarProducto(producto) == true)
                                                    {
                                                        MessageBox.Show("¡Producto editado!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        pnlRegistrarProd.Visible = false;
                                                        MostrarProductos();
                                                        LimpiarProducto();
                                                        ContarProductos();
                                                        SumarInversion();
                                                        ConteoDataTable();
                                                        ValidarPaginador();
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("La imagen está vacía, ¡Insértela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("La cantidad mínima es 3, ¡Modifíquelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            txtCantMayor.Value = 0;
                                            txtCantMayor.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El código esta vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtCodigo.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El precio por mayor está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtPrecioMayor.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El precio venta está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtPrecioVenta.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("El precio compra está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPrecioCompra.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("La marca está vacía, ¡Seleccione!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //pnlMarca.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("La subcategoría está vacía, ¡Seleccione!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //pnlSubcategorias.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("La descripción está vacía, ¡Digítela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcionProducto.Focus();
            }
        }

        string idserialprod;
        private void Mostrar_IdCaja_Serial()
        {
            try
            {
                DataTable dt = new DataTable();

                caja.SerialPc = LOGIN.formLogin.serial;

                CajasDao.MostrarIdCajaSerialProducto(ref idserialprod, caja);

                lblIdCajaSerial.Text = "";
                lblIdCajaSerial.Text = idserialprod;

                cajastatic = lblIdCajaSerial.Text;
            }
            catch (Exception)
            {

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
            //pnlSubcategorias.Visible = true;
            //pnlMarca.Visible = false;

            //pnlSubcategorias.Dock = DockStyle.Fill;
            //MostrarSubcategorias();

            VISTAS.PRODUCTOS.formSubcategorias sub = new VISTAS.PRODUCTOS.formSubcategorias();
            AddOwnedForm(sub);
            sub.ShowDialog();
        }

        private void pbxMarca_Click(object sender, EventArgs e)
        {
            VISTAS.PRODUCTOS.formMarcas mar = new VISTAS.PRODUCTOS.formMarcas();
            AddOwnedForm(mar);
            mar.ShowDialog();
        }

        private void btnAgregarSubCat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditarSubCat_Click(object sender, EventArgs e)
        {
        }

        private void btnLimpiarSubCat_Click(object sender, EventArgs e)
        {
        }

        private void btnNuevaSubCat_Click(object sender, EventArgs e)
        {
        }


        private void btnElegir_Click(object sender, EventArgs e)
        {
        }

        private void gridSubcategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnLimpiarMar_Click(object sender, EventArgs e)
        {
        }

        private void btnElegirMarca_Click(object sender, EventArgs e)
        {
        }


        private void gridMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            EditarProducto();
        }

        private void gridProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void EliminarProducto()
        {
            DialogResult preguntaprod;
            preguntaprod = MessageBox.Show("¿Está seguro de eliminar este producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preguntaprod == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow filaprod in gridProductos.SelectedRows)
                    {
                        int id = Convert.ToInt32(filaprod.Cells["ID"].Value);

                        try
                        {
                            producto.IdProducto = id;
                            if (funcionProducto.EliminarProducto(producto) == true)
                            {
                                MostrarProductos();
                                LimpiarProducto();
                                ContarProductos();
                                SumarInversion();
                                ConteoDataTable();
                                ValidarPaginador();
                                btnModificar.Visible = false;
                                btnGuardarProd.Visible = true;
                            }

                            MessageBox.Show("¡Eliminación exitosa!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al eliminar el producto");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al Eliminar Producto!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LimpiarProducto()
        {
            txtDescripcionProducto.Text="";
            txtDescripcionProducto.LabelText = "Descripción del producto:";
            txtCategoria.Clear();
            txtSubcategoria.Clear();
            txtMarca.Clear();
            txtPrecioCompra.Clear();
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

            pbxImagenProd.Image = null;
            lblEligeProd.Visible = true;
        }

        string contaprod;
        private void ContarProductos()
        {

            try
            {
                ProductosDao.ContarProductos(ref contaprod);

                lblCantidadProd.Text = "";
                lblCantidadProd.Text = contaprod;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        string suminver;
        private void SumarInversion()
        {
            try
            {
                ProductosDao.SumarInversion(ref suminver);

                lblCostoProd.Text = "";
                lblCostoProd.Text = suminver;
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
            if (txtBuscarProd.Text!="")
            {
                BuscarProductos();
            }
            else
            {
                MostrarProductos();
            }
            
        }

        private void BuscarProductosAuto()
        {
            
        }

        private void BuscarProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                ProductosDao.BuscarProductos(ref dt, txtBuscarProd.Text);
                gridProductos.DataSource = dt;

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
            Datatables_tamañoAuto.Multilinea(ref gridProductos);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BuscarProductosAuto();
        }

        private void btnCodigo_Click(object sender, EventArgs e)
        {
            GenerarCodigoBarras();
        }

        double codebar;
        Double resultado;
        private void GenerarCodigoBarras()
        {
            //string queryMoneda;
            //queryMoneda = "SELECT max(id_prod)  FROM t_productos";
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = CONEXION.Conexion.conectar;
            //SqlCommand comMoneda = new SqlCommand(queryMoneda, con);
            //try
            //{
            //    con.Open();
            //    resultado = Convert.ToDouble(comMoneda.ExecuteScalar()) + 1;
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    resultado = 1;
            //}

            try
            {
                ProductosDao.GenerarCodigoBarras(ref codebar);

                resultado = codebar;
            }
            catch (Exception)
            {
                MessageBox.Show("No se genera el codigo");
            }

            string Cadena = txtSubcategoria.Text;
            string[] Palabra;
            String espacio = " ";
            Palabra = Cadena.Split(Convert.ToChar(espacio));
            try
            {

                txtCodigo.Text = resultado + Palabra[0].Substring(0, 2) + 20;
            }
            catch (Exception)
            {
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidarDecimales(txtPrecioCompra, e);
            new ValidacionCampos().ValidarSoloDecimales(txtPrecioCompra, e);
        }

        private void txtGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloDecimales(txtPrecioVenta, e);
        }

        private void txtPrecioMayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloDecimales(txtPrecioMayor, e);
        }

        private void txtBuscarMar_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBuscarSubCat_TextChanged(object sender, EventArgs e)
        {
        }

        private void timerCodigo_Tick(object sender, EventArgs e)
        {
            
        }

        private void checkGanancia_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPorcGan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
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

        private void txtBuniGan_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        decimal porc;
        private void checkPorc_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPorc.Checked)
            {
                txtBuniGan.Enabled = true;
                txtPrecioVenta.ReadOnly = true;
            }
            else
            {
                txtBuniGan.Text = "";
                txtBuniGan.Enabled = false;
                txtPrecioVenta.ReadOnly = false;
            }
        }

        decimal nuevoTotalVenta;
        decimal precioCompra;
        private void txtBuniGan_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                porc = Convert.ToDecimal(txtBuniGan.Text);
                precioCompra = Convert.ToDecimal(txtPrecioCompra.Text);
                nuevoTotalVenta = Math.Round((precioCompra * porc/100) + precioCompra,2);
                txtPrecioVenta.Text = nuevoTotalVenta.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioCompra.Text=="")
            {
                pnlGanancia.Visible = false;
            }
            else
            {
                pnlGanancia.Visible = true;
            }
        }

        private void checkInv_OnChange(object sender, EventArgs e)
        {
            if (checkInv.Checked)
            {
                pnlOpcionesInv.Visible = true;
            }
            else
            {
                pnlOpcionesInv.Visible = false;
            }
        }

        private void dataGridViewPaging1_Click(object sender, EventArgs e)
        {
      
        }

        private void PaginarProductos(int pagina)
        {
            try
            {
                DataTable dt = new DataTable();
                ProductosDao.TabularProductos(ref dt, pagina);

                gridProductos.DataSource = dt;

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
            catch (Exception)
            {
                MessageBox.Show("No se muestran los datos", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            
        }

        decimal totalpaginas;
        private void ConteoDataTable()
        {
            totalpaginas = Math.Ceiling(Convert.ToDecimal(lblCantidadProd.Text)/20);
            lblTotalPag.Text = totalpaginas.ToString();
        }

        private void ValidarPaginador()
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaActual.Text = DateTime.Today.ToShortDateString();
            lblHoraActual.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnPrimera_Click_1(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual - 2) * 20;

            PaginarProductos(pagina);

            txtPagActual.Text = Convert.ToString(paginaactual - 1);

            if (txtPagActual.Text == "1")
            {
                btnAnterior.Enabled = false;
            }
            btnSiguiente.Enabled = true;
        }

        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual) * 20;

            PaginarProductos(pagina);

            txtPagActual.Text = Convert.ToString(paginaactual + 1);

            if (txtPagActual.Text == lblTotalPag.Text)
            {
                btnSiguiente.Enabled = false;
            }
            btnAnterior.Enabled = true;
        }

        private void btnUltima_Click_1(object sender, EventArgs e)
        {
            
        }

        private void xD()
        {
            
        }

        private void gridProductos_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gridProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridProductos_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            
            
            string tipo;

            if (e.ColumnIndex == this.gridProductos.Columns["EdiProd2"].Index)
            {
                gridProductos.Visible = false;
                pnlRegistrarProd.Visible = true;
                pnlTabulacion.Visible = false;
                pnlRegistrarProd.Dock = DockStyle.Fill;

                lblIdProd.Text = gridProductos.SelectedCells[2].Value.ToString();
                txtDescripcionProducto.Text = gridProductos.SelectedCells[3].Value.ToString();
                txtDescripcionProducto.LabelText = gridProductos.SelectedCells[3].Value.ToString();

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


                lblFcha.Text = gridProductos.SelectedCells[16].Value.ToString();

                if (lblFcha.Text == "NO APLICA")
                {
                    dateVencimiento.Visible = false;
                }
                else
                {
                    dateVencimiento.Value = Convert.ToDateTime(gridProductos.SelectedCells[16].Value);
                }

                txtCodigo.Text = gridProductos.SelectedCells[17].Value.ToString();
                txtPrecioMayor.Text = gridProductos.SelectedCells[18].Value.ToString();
                txtCantMayor.Text = gridProductos.SelectedCells[19].Value.ToString();
                //.Text = gridProductos.SelectedCells[20].Value.ToString();
                txtMinimo.Text = gridProductos.SelectedCells[21].Value.ToString();
                tipo = gridProductos.SelectedCells[22].Value.ToString();

                if (tipo == "UNIDAD")
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
                EliminarProducto();
            }
        }

        private void btnUltiPage_Click(object sender, EventArgs e)
        {

        }

        private void btnUltiPage_Click_1(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(lblTotalPag.Text);
            int pagina = (paginaactual - 1) * 20;

            PaginarProductos(pagina);

            txtPagActual.Text = lblTotalPag.Text;

            btnSiguiente.Enabled = false;
            btnAnterior.Enabled = true;
        }
    }
}
