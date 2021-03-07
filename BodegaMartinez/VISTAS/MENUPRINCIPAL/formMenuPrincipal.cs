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
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;

namespace BodegaMartinez.MENUPRINCIPAL
{
    public partial class formMenuPrincipal : Form
    {
        public formMenuPrincipal()
        {
            InitializeComponent();
        }

        Usuario usuario = new Usuario();
        UsuariosDao funcionUsuario = new UsuariosDao();

        Producto producto = new Producto();
        ProductosDao funcionProducto = new ProductosDao();

        Venta venta = new Venta();
        VentasDao funcionVenta = new VentasDao();

        DetalleVenta detalleVenta = new DetalleVenta();
        DetalleVentasDao funcionDetalleVenta = new DetalleVentasDao();

        private void btnFinTurno_Click(object sender, EventArgs e)
        {
            CAJA.formCierreCaja cie = new CAJA.formCierreCaja();
            cie.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void formMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuarioIngresa.Text = LOGIN.formLogin.usuarioingresa;
            if (txtBuscar.Text=="")
            {
                lblTipoBusqueda.Visible = true;
            }

            MostrarFotoPerfil();
            InvocarRol();
            AsignarModulos();

            ContadorVentaEspera();

            btnMas.Width = 70;
            btnMenos.Width = 70;
        }

        byte[] imagen;
        private void MostrarFotoPerfil()
        {
            try
            {
                usuario.User = lblUsuarioIngresa.Text;
                UsuariosDao.MostrarFotoPerfil(ref imagen, usuario);

                pbxUser.BackgroundImage = null;

                MemoryStream ms = new MemoryStream(imagen);
                pbxUser.Image = Image.FromStream(ms);
            }
            catch (Exception)
            {
                MessageBox.Show("Este usuario no tiene foto de perfil");
            }
        }

        private void AutobusquedaProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                ProductosDao.AutobusquedaVentas(ref dt, txtBuscar.Text);
                gridAutoBusqueda.DataSource = dt;

                gridAutoBusqueda.Columns[0].Visible = false;
                gridAutoBusqueda.Columns[1].Visible = false;
                gridAutoBusqueda.Columns[2].Visible = false;
                gridAutoBusqueda.Columns[3].Visible = false;
                gridAutoBusqueda.Columns[4].Visible = false;
                gridAutoBusqueda.Columns[5].Visible = false;
                gridAutoBusqueda.Columns[6].Visible = false;
                gridAutoBusqueda.Columns[7].Visible = false;
                gridAutoBusqueda.Columns[8].Visible = false;
                gridAutoBusqueda.Columns[9].Visible = false;
                gridAutoBusqueda.Columns[10].Visible = false;
                gridAutoBusqueda.Columns[11].Visible = false;
                gridAutoBusqueda.Columns[12].Visible = false;
                gridAutoBusqueda.Columns[13].Visible = true;
                gridAutoBusqueda.Columns[14].Visible = false;
                gridAutoBusqueda.Columns[15].Visible = false;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridAutoBusqueda);
        }

        string mirol;
        private void InvocarRol()
        {         
            try
            {
                usuario.User = lblUsuarioIngresa.Text;
                UsuariosDao.InvocarRol(ref mirol, usuario);

                lblRol.Text = "";
                lblRol.Text = mirol;
            }
            catch (Exception)
            {
                MessageBox.Show("Este usuario no tiene foto de perfil");
            }
        }

        private void AsignarModulos()
        {
            if (lblRol.Text=="Administrador")
            {
                
            }
            else if (lblRol.Text == "Almacenero")
            {
                pnlCaja.Enabled = false;
                pnlPagos.Enabled = false;
                pnlCobros.Enabled = false;
                pnlTarjetas.Enabled = false;
                pnlClientes.Enabled = false;
                pnlCobrarCred.Enabled = false;
                pnlJefe.Enabled = false;
                pnlPrestamos.Enabled = false;
                pnlUsuarios.Enabled = false;

                btnCaja.BackColor = Color.Gray;
                btnPagos.BackColor = Color.Gray;
                btnCobros.BackColor = Color.Gray;
                btnTarjetas.BackColor = Color.Gray;
                btnClientes.BackColor = Color.Gray;
                btnCobrarCred.BackColor = Color.Gray;
                btnJefe.BackColor = Color.Gray;
                btnPrestamos.BackColor = Color.Gray;
                btnUsuarios.BackColor = Color.Gray;

                btnFinTurno.Enabled = false;
                btnFinTurno.BackColor = Color.Gray;

                
            }
            else if (lblRol.Text == "Vendedor")
            {
                pnlCaja.Enabled = false;
                pnlPagos.Enabled = false;
                pnlJefe.Enabled = false;
                pnlPrestamos.Enabled = false;
                pnlUsuarios.Enabled = false;
                pnlInventario.Enabled = false;
                pnlReportes.Enabled = false;
                pnlProveedores.Enabled = false;
                pnlBackup.Enabled = false;

                btnCaja.BackColor = Color.Gray;
                btnPagos.BackColor = Color.Gray;
                btnJefe.BackColor = Color.Gray;
                btnPrestamos.BackColor = Color.Gray;
                btnUsuarios.BackColor = Color.Gray;
                btnInventario.BackColor = Color.Gray;
                btnReportes.BackColor = Color.Gray;
                btnProveedores.BackColor = Color.Gray;
                btnBackup.BackColor = Color.Gray;

                btnFinTurno.Enabled = false;
                btnFinTurno.BackColor = Color.Gray;

                menuProducto.Enabled = false;
                menuProducto.BackColor = Color.Gray;
            }
            else if (lblRol.Text == "Cajero")
            {
                pnlInventario.Enabled = false;
                pnlClientes.Enabled = false;
                pnlReportes.Enabled = false;
                pnlProveedores.Enabled = false;
                pnlUsuarios.Enabled = false;
                pnlBoletas.Enabled = false;
                pnlJefe.Enabled = false;
                pnlBackup.Enabled = false;

                btnInventario.BackColor = Color.Gray;
                btnClientes.BackColor = Color.Gray;
                btnReportes.BackColor = Color.Gray;
                btnProveedores.BackColor = Color.Gray;
                btnUsuarios.BackColor = Color.Gray;
                btnBoletas.BackColor = Color.Gray;
                btnJefe.BackColor = Color.Gray;
                btnBackup.BackColor = Color.Gray;

                menuProducto.Enabled = false;
                menuProducto.BackColor = Color.Gray;
            }
            else
            {
                MessageBox.Show("Este usuario no tiene un rol validado por el sistema");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {
            lblTipoBusqueda.Text = "Búsqueda por teclado";
            lblTipoBusqueda2.Text = "TECLADO";
            txtBuscar.Text = "";
            txtBuscar.Focus();
            btnTeclado.BackColor = Color.Orange;
            btnLectora.BackColor = Color.White;
        }

        private void btnLectora_Click(object sender, EventArgs e)
        {
            lblTipoBusqueda.Text = "Búsqueda por lectora";
            lblTipoBusqueda2.Text = "LECTORA";
            txtBuscar.Text = "";
            txtBuscar.Focus();
            btnTeclado.BackColor = Color.White;
            btnLectora.BackColor = Color.CornflowerBlue;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (pnlModulos.Visible==false)
            {
                pnlModulos.Visible = true;
            }
            else
            {
                pnlModulos.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lblCondVenta.Text == "VENTAS" || lblCondVenta.Text == "FINALIZADO")
            {
                Application.Exit();
            }
            else if (lblCondVenta.Text == "PROCESO")
            {
                DialogResult cerrar;
                cerrar = MessageBox.Show("Hay una venta en proceso, ¿Está seguro de cerrar el sistema?", "Cerrar sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cerrar == DialogResult.Yes)
                {
                    EliminarVenta();
                    Application.Exit();
                }
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            USUARIOS.formUsuarios usu = new USUARIOS.formUsuarios();
            usu.ShowDialog();
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            USUARIOS.formUsuarios usu = new USUARIOS.formUsuarios();
            usu.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            INVENTARIOS.formInventarios kdx = new INVENTARIOS.formInventarios();
            kdx.ShowDialog();
        }

        private void lblInventario_Click(object sender, EventArgs e)
        {
            INVENTARIOS.formInventarios kdx = new INVENTARIOS.formInventarios();
            kdx.ShowDialog();
        }

        private void btnJefe_Click(object sender, EventArgs e)
        {
            ENCRIPTACION_BD.formEncriptarBD bd = new ENCRIPTACION_BD.formEncriptarBD();
            bd.ShowDialog();
        }

        private void btnMasProductos_Click(object sender, EventArgs e)
        {
            PRODUCTOS.formProductos prod = new PRODUCTOS.formProductos();
            prod.ShowDialog();
        }

        private void btnOpcProd_Click(object sender, EventArgs e)
        {
            PRODUCTOS.formOpcionesProductos opc = new PRODUCTOS.formOpcionesProductos();
            opc.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            CLIENTES.formClientes cli = new CLIENTES.formClientes();
            cli.ShowDialog();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text!="")
            {
                if (lblTipoBusqueda2.Text=="LECTORA")
                {
                    timerBuscadorBarras.Start();
                }

                if (lblTipoBusqueda2.Text == "TECLADO")
                {
                    AutobusquedaProductos();
                }
                lblTipoBusqueda.Visible = false;
                gridAutoBusqueda.Visible = true;
                
            }
            else
            {
                gridAutoBusqueda.Visible = false;
            }
        }

        private void gridAutoBusqueda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ContadorDetalleVenta();

            lblIdProd.Text = gridAutoBusqueda.SelectedCells[0].Value.ToString();
            lblCodigo.Text = gridAutoBusqueda.SelectedCells[1].Value.ToString();
            lblDescripcion.Text = gridAutoBusqueda.SelectedCells[2].Value.ToString();
            lblCosto.Text = gridAutoBusqueda.SelectedCells[3].Value.ToString();
            lblPrecioVenta.Text = gridAutoBusqueda.SelectedCells[4].Value.ToString();
            lblStock.Text = gridAutoBusqueda.SelectedCells[5].Value.ToString();
            lblTipo.Text = gridAutoBusqueda.SelectedCells[11].Value.ToString();
            lblUsaInv.Text = gridAutoBusqueda.SelectedCells[12].Value.ToString();
            lblPrecioMayor.Text = gridAutoBusqueda.SelectedCells[14].Value.ToString();
            lblCantMayor.Text = gridAutoBusqueda.SelectedCells[15].Value.ToString();

            gridAutoBusqueda.Visible = false;
            txtBuscar.Clear();

            CondicionProducto();

            //InsertarDetalleVenta();
        }

        private void ContadorDetalleVenta()
        {
            int conta;

            if (lblDetalle.Text=="$det")
            {
                lblDetalle.Text = "0";
            }
            conta =  Convert.ToInt32(lblDetalle.Text) +1;
            lblDetalle.Text = Convert.ToString(conta);
        }

        private void DisminuirContador()
        {
            int conta;

            conta = Convert.ToInt32(lblDetalle.Text) - 1;
            lblDetalle.Text = Convert.ToString(conta);
        }

        string sumaven;
        private void SumatoriaVenta()
        {
            try
            {
                venta.IdVenta = Convert.ToInt32(lblVenta.Text);
                VentasDao.SumatoriaVenta(ref sumaven, venta);

                lblTotalVenta.Text = "";
                lblTotalVenta.Text = sumaven;
                lblTotalActual.Text = lblTotalVenta.Text;
                lblSubtotal.Text = lblTotalVenta.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        string condiprod;
        private void CondicionProducto()
        {
            try
            {
                detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);
                detalleVenta.IdProducto = Convert.ToInt32(lblIdProd.Text);
                DetalleVentasDao.CondicionProducto(ref condiprod, detalleVenta);

                lblCond.Text = "";
                lblCond.Text = condiprod;

                if (lblCond.Text=="")
                {
                    InsertarDetalleVenta();
                }
                else 
                {
                    ActualizarRepeticion();
                }
            }
            catch (Exception)
            {
                
            }
        }

        string contaprod;
        private void ContaVenta()
        {
            try
            {
                detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);
                DetalleVentasDao.ContadorVenta(ref contaprod, detalleVenta);

                lblTotalVenta.Text = "";
                lblTotalVenta.Text = sumaven;
                lblTotalActual.Text = lblTotalVenta.Text;
                lblSubtotal.Text = lblTotalVenta.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        private void InsertarDetalleVenta()
        {
            try
            {
                //SqlConnection con = new SqlConnection();
                //con.ConnectionString = CONEXION.Conexion.conectar;
                //con.Open();

                //double preciounit = Convert.ToDouble(lblPrecioVenta.Text);

                //SqlCommand sql = new SqlCommand();
                //sql = new SqlCommand("insertar_detalleventa", con);
                //sql.CommandType = CommandType.StoredProcedure;
                //sql.Parameters.AddWithValue("@id_venta", lblVenta.Text);
                //sql.Parameters.AddWithValue("@id_detalleventa", lblDetalle.Text);
                //sql.Parameters.AddWithValue("@producto", lblIdProd.Text);
                //sql.Parameters.AddWithValue("@cantidad", "1");
                //sql.Parameters.AddWithValue("@precio_unit", lblPrecioVenta.Text);
                //sql.Parameters.AddWithValue("@moneda", "S/.");
                //sql.Parameters.AddWithValue("@unidad_medida", "u");
                //sql.Parameters.AddWithValue("@cant_mostrada", "1");
                //sql.Parameters.AddWithValue("@estado", "VENTA EN PROCESO");
                //sql.Parameters.AddWithValue("@descripcion", lblDescripcion.Text);
                //sql.Parameters.AddWithValue("@codigo", lblCodigo.Text);
                //sql.Parameters.AddWithValue("@stock", lblStock.Text);
                //sql.Parameters.AddWithValue("@unidades", lblTipo.Text);
                //sql.Parameters.AddWithValue("@usa_inventario", lblUsaInv.Text);
                //sql.Parameters.AddWithValue("@costo", lblCosto.Text);
                //sql.Parameters.AddWithValue("@precio_mayor", lblPrecioMayor.Text);
                //sql.Parameters.AddWithValue("@cant_mayor", lblCantMayor.Text);
                //sql.Parameters.AddWithValue("@precio_venta", lblPrecioVenta.Text);
                //sql.Parameters.AddWithValue("@nivel", "N");

                //sql.ExecuteNonQuery();

                //con.Close();


                //MostrarDetalleVenta();
                //SumatoriaVenta();
                //ContaVenta();

                detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);
                detalleVenta.IdDetalleVenta = Convert.ToInt32(lblDetalle.Text);
                detalleVenta.IdProducto = Convert.ToInt32(lblIdProd.Text);
                detalleVenta.Cantidad = 1;
                detalleVenta.PrecioUnitario = Convert.ToDouble(lblPrecioVenta.Text);
                detalleVenta.Moneda = "S/.";
                detalleVenta.UnidadMedida = "u";
                detalleVenta.CantidadMostrada = 1;
                detalleVenta.Estado = "VENTA EN PROCESO";
                detalleVenta.Descripcion = lblDescripcion.Text;
                detalleVenta.Codigo = lblCodigo.Text;
                detalleVenta.Stock = Convert.ToInt32(lblStock.Text);
                detalleVenta.Unidades = lblTipo.Text;
                detalleVenta.UsaInventario = lblUsaInv.Text;
                detalleVenta.Costo = Convert.ToDouble(lblCosto.Text);
                detalleVenta.PrecioMayor = Convert.ToDouble(lblPrecioMayor.Text);
                detalleVenta.CantidadMayor = Convert.ToInt32(lblCantMayor.Text);
                detalleVenta.PrecioVenta = Convert.ToDouble(lblPrecioVenta.Text);
                detalleVenta.Nivel = "N";


                if (funcionDetalleVenta.InsertarDetalleVenta(detalleVenta) == true)
                {
                    //MessageBox.Show("¡Producto registrado exitosamente!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarDetalleVenta();
                    SumatoriaVenta();
                    ContaVenta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarDetalleVenta()
        {
            try
            {
                //DataTable dt = new DataTable();
                //SqlDataAdapter da;

                //SqlConnection con = new SqlConnection();
                //con.ConnectionString = CONEXION.Conexion.conectar;
                //con.Open();
                //da = new SqlDataAdapter("mostrar_detalleventa", con);
                //da.SelectCommand.Parameters.AddWithValue("@id_venta", lblVenta.Text);
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;

                //da.Fill(dt);
                //gridVentas.DataSource = dt;
                //con.Close();
                detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);

                DataTable dt = new DataTable();
                DetalleVentasDao.MostrarDetalleVenta(ref dt, detalleVenta);

                gridVentas.DataSource = dt;

                gridVentas.Columns[0].Visible = true;
                gridVentas.Columns[1].Visible = true;
                gridVentas.Columns[2].Visible = true;
                gridVentas.Columns[3].Visible = false;
                gridVentas.Columns[4].Visible = false;
                gridVentas.Columns[5].Visible = true;
                gridVentas.Columns[6].Visible = false;
                gridVentas.Columns[7].Visible = true;
                gridVentas.Columns[8].Visible = true;
                gridVentas.Columns[9].Visible = true;
                gridVentas.Columns[10].Visible = true;
                gridVentas.Columns[11].Visible = true;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridVentas);
        }

        private void ActualizarRepeticion()
        {
            try
            {
                detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);
                detalleVenta.IdProducto = Convert.ToInt32(lblIdProd.Text);

                if (funcionDetalleVenta.ActualizarProductoRepetido(detalleVenta) == true)
                {
                    MostrarDetalleVenta();
                    SumatoriaVenta();
                    DisminuirContador();
                    ContaVenta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        string miidventa;
        private void TraerIdVenta()
        {
            try
            {
                VentasDao.TraerIdVenta(ref miidventa);

                lblVenta.Text = "";
                lblVenta.Text = miidventa;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        private void AperturarVenta()
        {
            try
            {
                venta.MontoTotal = 0;
                venta.Estado = "VENTA APERTURADA";

                if (funcionVenta.AperturarVenta(venta) == true)
                {
                    TraerIdVenta();
                    btnCobrar.Visible = true;
                }
            }
            catch (Exception)
            {
            }
            
        }

        
        public static string serie;
        int lastventa;
        public void GenerarSerie()
        {     
            int cifra;
            int digito;
            try
            {
                try
                {
                    VentasDao.GenerarSerie(ref lastventa);

                    lblSerie.Text = "";
                    digito = lastventa + 1;

                    cifra = Convert.ToString(digito).Length;

                    if (cifra == 1)
                    {
                        serie = "0000000" + digito;
                    }
                    else if (cifra == 2)
                    {
                        serie = "000000" + digito;
                    }
                    else if (cifra == 3)
                    {
                        serie = "00000" + digito;
                    }
                    else if (cifra == 4)
                    {
                        serie = "0000" + digito;
                    }
                    else if (cifra == 5)
                    {
                        serie = "000" + digito;
                    }
                    else if (cifra == 6)
                    {
                        serie = "00" + digito;
                    }
                    else if (cifra == 7)
                    {
                        serie = "0" + digito;
                    }
                    else if (cifra == 8)
                    {
                        serie = digito.ToString();
                    }

                    lblSerie.Text = serie.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se cuentan los productos");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Este usuario no tiene foto de perfil");
            }
        }

        private void btnCrearVenta_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
            txtBuscar.Enabled = true;
            pnlModulos.Visible = false;
            

            AperturarVenta();

            lblDetalle.Text = "0";
            lblDescuento.Text = "0.00";
            lblSubtotal.Text = "0.00";
            lblCondVenta.Text = "PROCESO";
            btnCobrar.Visible = true;

            GenerarSerie();

            btnEliminarVenta.Visible = true;

            btnCrearVenta.Visible = false;
            ListarClientes();

            //pnlCalculadora.Enabled = true;
        }

        //private void ProcesarVenta()
        //{
        //    try
        //    {
        //        //SqlConnection con = new SqlConnection();
        //        //con.ConnectionString = CONEXION.Conexion.conectar;
        //        //con.Open();

        //        //double preciounit = Convert.ToDouble(lblPrecioVenta.Text);

        //        //SqlCommand sql = new SqlCommand();
        //        //sql = new SqlCommand("procesar_venta", con);
        //        //sql.CommandType = CommandType.StoredProcedure;
        //        //sql.Parameters.AddWithValue("@id_venta", lblVenta.Text);
        //        //sql.Parameters.AddWithValue("@cliente", cbxCliente.SelectedValue);
        //        //sql.Parameters.AddWithValue("@fecha_venta", DateTime.Now);
        //        //sql.Parameters.AddWithValue("@num_doc", "0001");
        //        //sql.Parameters.AddWithValue("@monto_total", lblTotalVenta.Text);
        //        //sql.Parameters.AddWithValue("@subtotal", lblSubtotal.Text);
        //        //sql.Parameters.AddWithValue("@descuento", lblDescuento.Text);
        //        //sql.Parameters.AddWithValue("@tipo_pago", "EFECTIVO");
        //        //sql.Parameters.AddWithValue("@estado", "VENTA FINALIZADA");
        //        //sql.Parameters.AddWithValue("@boleta", serie);
        //        //sql.Parameters.AddWithValue("@usuario", LOGIN.formLogin.id_usuario);
        //        //sql.Parameters.AddWithValue("@fecha_pago", DateTime.Now);
        //        //sql.Parameters.AddWithValue("@accion", "CORRECTO");
        //        //sql.Parameters.AddWithValue("@pago_parcial", 0);
        //        //sql.Parameters.AddWithValue("@porc_igv", 18);
        //        //sql.Parameters.AddWithValue("@caja", 1);
        //        //sql.Parameters.AddWithValue("@referencia_card", 1);
        //        //sql.Parameters.AddWithValue("@efectivo", lblTotalVenta.Text); //efectivo=dinero pagado en primera instancia
        //        //sql.Parameters.AddWithValue("@credito", "NO");
        //        //sql.Parameters.AddWithValue("@tarjeta", "NO");

        //        //sql.ExecuteNonQuery();

        //        //con.Close();

                
        //        //MessageBox.Show("Venta procesada correctamente");

        //        //ActualizarEstadoDetalle();

        //        venta.IdVenta = Convert.ToInt32(lblVenta.Text);
        //        venta.IdCliente=

        //        venta.Estado = "VENTA APERTURADA";

        //        if (funcionVenta.ProcesarVenta(venta) == true)
        //        {
        //            MessageBox.Show("Venta procesada correctamente");

        //            ActualizarEstadoDetalle();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void ActualizarEstadoDetalle()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection();
        //        con.ConnectionString = CONEXION.Conexion.conectar;
        //        con.Open();


        //        SqlCommand sql = new SqlCommand();
        //        sql = new SqlCommand("terminar_detalleventa", con);
        //        sql.CommandType = CommandType.StoredProcedure;

        //        sql.Parameters.AddWithValue("@id_venta", lblVenta.Text);
        //        sql.Parameters.AddWithValue("@estado", "VENTA FINALIZADA");

        //        sql.ExecuteNonQuery();

        //        con.Close();

        //        idventa = lblVenta.Text;
        //        totalventa = lblTotalVenta.Text;
        //        subtotal = lblSubtotal.Text;
        //        descuento = lblDescuento.Text;
        //        lblCondVenta.Text = "FINALIZADO";

        //        lblVenta.Text = "0";
        //        lblTotalVenta.Text = "0";
        //        lblDetalle.Text = "$det";
        //        gridVentas.DataSource = null; //Vaciar los datos del gridview
        //        gridVentas.Refresh(); //Actualizo mi gridview

        //        BOLETAS.formBoleta bol = new BOLETAS.formBoleta();
        //        bol.ShowDialog();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        public static string idventa;
        public static string totalventa;
        public static string subtotal;
        public static string descuento;

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                btnCrearVenta.Visible = true;
                txtBuscar.Clear();
                txtBuscar.Enabled = false;

                //ProcesarVenta();

                btnCobrar.Visible = false;

                idventa = lblVenta.Text;
                totalventa = lblTotalVenta.Text;
                subtotal = lblSubtotal.Text;
                descuento = lblDescuento.Text;

                VISTAS.MENUPRINCIPAL.formMediosPago pag = new VISTAS.MENUPRINCIPAL.formMediosPago();
                pag.ShowDialog();

                lblVenta.Text = "0";
                lblTotalVenta.Text = "0";
                lblDetalle.Text = "$det";
                gridVentas.DataSource = null; //Vaciar los datos del gridview
                gridVentas.Refresh(); //Actualizo mi gridview
                lblCondVenta.Text = "FINALIZADO";
                pnlTeclado.Enabled = false;
                ContadorVentaEspera();
            }
            catch (Exception)
            {
                MessageBox.Show("Número incorrecto, digite bien", "Número Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void gridAutoBusqueda_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void EliminarDetalle()
        {
            //SqlCommand sql;
            //try
            //{
            //    foreach (DataGridViewRow filacli in gridVentas.SelectedRows)
            //    {
            //        int id = Convert.ToInt32(filacli.Cells["producto"].Value);

            //        try
            //        {
            //            SqlConnection con = new SqlConnection();
            //            con.ConnectionString = CONEXION.Conexion.conectar;
            //            con.Open();

            //            sql = new SqlCommand("eliminar_detalleventa", con);
            //            sql.CommandType = CommandType.StoredProcedure;
            //            sql.Parameters.AddWithValue("@producto", id);
            //            sql.Parameters.AddWithValue("@id_venta", lblVenta.Text);

            //            sql.ExecuteNonQuery();
            //            con.Close();
            //            MostrarDetalleVenta();
            //            SumatoriaVenta();
            //            ContaVenta();
            //            //DisminuirContador();
            //        }
            //        catch (Exception)
            //        {

            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //}

            try
            {
                foreach (DataGridViewRow filacli in gridVentas.SelectedRows)
                {
                    int id = Convert.ToInt32(filacli.Cells["producto"].Value);

                    detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);
                    detalleVenta.IdProducto = id;

                    if (funcionDetalleVenta.EliminarDetalleVenta(detalleVenta) == true)
                    {
                        MostrarDetalleVenta();
                        SumatoriaVenta();
                        ContaVenta();
                        //DisminuirContador();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el producto");
            }
        }

        private void gridVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pnlTeclado.Enabled = true;
            lblMyIdDetVen.Text = gridVentas.SelectedCells[4].Value.ToString();

            if (e.ColumnIndex == this.gridVentas.Columns["EliVen"].Index)
            {
                EliminarDetalle();
            }

            if (e.ColumnIndex == this.gridVentas.Columns["btnMas"].Index)
            {
                try
                {
                    foreach (DataGridViewRow filasub in gridVentas.SelectedRows)
                    {
                        int id_prod = Convert.ToInt32(filasub.Cells["producto"].Value);

                        //try
                        //{
                        //    SqlConnection con = new SqlConnection();
                        //    con.ConnectionString = CONEXION.Conexion.conectar;
                        //    con.Open();


                        //    sql = new SqlCommand("boton_mas", con);
                        //    sql.CommandType = CommandType.StoredProcedure;
                        //    sql.Parameters.AddWithValue("@producto", id_prod);
                        //    sql.Parameters.AddWithValue("@id_venta", lblVenta.Text);

                        //    sql.ExecuteNonQuery();

                        //    con.Close();

                        //    MostrarDetalleVenta();
                        //    SumatoriaVenta();
                        //    ContaVenta();
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message);
                        //}

                        try
                        {
                            detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);
                            detalleVenta.IdProducto = id_prod;

                            if (funcionDetalleVenta.BotonMas(detalleVenta) == true)
                            {
                                MostrarDetalleVenta();
                                SumatoriaVenta();
                                ContaVenta();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.ColumnIndex == this.gridVentas.Columns["btnMenos"].Index)
            {
                try
                {
                    foreach (DataGridViewRow filasub in gridVentas.SelectedRows)
                    {
                        int id_prod = Convert.ToInt32(filasub.Cells["producto"].Value);

                        //try
                        //{
                        //    SqlConnection con = new SqlConnection();
                        //    con.ConnectionString = CONEXION.Conexion.conectar;
                        //    con.Open();


                        //    sql = new SqlCommand("boton_menos", con);
                        //    sql.CommandType = CommandType.StoredProcedure;
                        //    sql.Parameters.AddWithValue("@producto", id_prod);
                        //    sql.Parameters.AddWithValue("@id_venta", lblVenta.Text);

                        //    sql.ExecuteNonQuery();

                        //    con.Close();

                            
                            
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message);
                        //}

                        try
                        {
                            detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);
                            detalleVenta.IdProducto = id_prod;

                            if (funcionDetalleVenta.BotonMenos(detalleVenta) == true)
                            {
                               
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                catch (Exception)
                {

                }
                MostrarDetalleVenta();
                SumatoriaVenta();
                ContaVenta();
            }

            try
            {
                lblCantidad.Text = gridVentas.SelectedCells[11].Value.ToString(); //mando stock
                lblProdChange.Text = gridVentas.SelectedCells[6].Value.ToString(); //mando idproducto a cambiar cantidad
            }
            catch (Exception)
            {

            }
        }

        private void lblVenta_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalVenta_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + "0";
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            txtCalculadora.Text = txtCalculadora.Text + ".";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtCalculadora.Clear();
        }

        private void btnCantidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCalculadora.Text == "0")
                {
                    MessageBox.Show("No se puede digitar cantidades nulas ", "Stock Nulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtCalculadora.Text == "")
                {
                    MessageBox.Show("Digite una cantidad numérica", "Stock Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(txtCalculadora.Text) > Convert.ToInt32(lblCantidad.Text))
                {
                    MessageBox.Show("La cantidad digitada sobrepasa el máximo de stock disponible", "Stock Excedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Convert.ToInt32(txtCalculadora.Text) <= Convert.ToInt32(lblCantidad.Text))
                {
                    //try
                    //{
                    //    SqlConnection con = new SqlConnection();
                    //    con.ConnectionString = CONEXION.Conexion.conectar;
                    //    con.Open();


                    //    SqlCommand sql = new SqlCommand();
                    //    sql = new SqlCommand("cantidad_producto", con);
                    //    sql.CommandType = CommandType.StoredProcedure;
                    //    sql.Parameters.AddWithValue("@cantidad", txtCalculadora.Text);
                    //    sql.Parameters.AddWithValue("@id_venta", lblVenta.Text);
                    //    sql.Parameters.AddWithValue("@producto", lblProdChange.Text);

                    //    sql.ExecuteNonQuery();

                    //    con.Close();

                    //    MostrarDetalleVenta();
                    //    SumatoriaVenta();
                    //    ContaVenta();
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}

                    try
                    {
                        detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);
                        detalleVenta.Cantidad = Convert.ToInt32(txtCalculadora.Text);
                        detalleVenta.IdProducto = Convert.ToInt32(lblProdChange.Text);

                        if (funcionDetalleVenta.CambiarCantidad(detalleVenta) == true)
                        {
                            MostrarDetalleVenta();
                            SumatoriaVenta();
                            ContaVenta();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Número incorrecto, digite bien", "Número Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtCalculadora.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("El número digitado es erróneo");
                txtCalculadora.Clear();
            }
            
        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {
            panel18.Visible = true;
            pnlDescuento.Visible = true;
            txtCalculadora.Clear();

        }

        private void btnPrecio_Click(object sender, EventArgs e)
        {
            DialogResult preguntaprec;
            preguntaprec = MessageBox.Show("¿Está seguro de cambiar el precio de este producto?", "Cambiar precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preguntaprec == DialogResult.Yes)
            {
                try
                {
                    if (txtCalculadora.Text == "0")
                    {
                        MessageBox.Show("No se puede digitar cantidades nulas ", "Precio Nulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtCalculadora.Text == "")
                    {
                        MessageBox.Show("Digite una cantidad numérica", "Precio Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //try
                        //{
                        //    SqlConnection con = new SqlConnection();
                        //    con.ConnectionString = CONEXION.Conexion.conectar;
                        //    con.Open();


                        //    SqlCommand sql = new SqlCommand();
                        //    sql = new SqlCommand("cambiar_precioventa", con);
                        //    sql.CommandType = CommandType.StoredProcedure;
                        //    sql.Parameters.AddWithValue("@precio_unit", txtCalculadora.Text);
                        //    sql.Parameters.AddWithValue("@id_venta", lblVenta.Text);
                        //    sql.Parameters.AddWithValue("@producto", lblProdChange.Text);

                        //    sql.ExecuteNonQuery();

                        //    con.Close();

                        //    MostrarDetalleVenta();
                        //    SumatoriaVenta();
                        //    ContaVenta();
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show("El número ingresado no es válido", "Número inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}

                        try
                        {
                            detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);
                            detalleVenta.PrecioUnitario = Convert.ToDouble(txtCalculadora.Text);
                            detalleVenta.IdProducto = Convert.ToInt32(lblProdChange.Text);

                            if (funcionDetalleVenta.CambiarPrecioVenta(detalleVenta) == true)
                            {
                                MostrarDetalleVenta();
                                SumatoriaVenta();
                                ContaVenta();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("El número ingresado no es válido", "Número inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("El número ingresado no es válido", "Número inválido", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }
            txtCalculadora.Clear();
        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRestaurarDesc_Click(object sender, EventArgs e)
        {
            txtNuevoTotal.Clear();
            pnlDescuento.Visible = false;
        }

        private void btnAplicarDesc_Click(object sender, EventArgs e)
        {
            try
            {
                decimal actual;
                decimal nuevo;

                decimal desc;

                decimal final;

                actual = Math.Round(Convert.ToDecimal(lblTotalActual.Text), 2);
                nuevo = Math.Round(Convert.ToDecimal(txtNuevoTotal.Text), 2);

                if (actual>nuevo)
                {
                    desc = Math.Round(actual - nuevo, 2);

                    final = Math.Round(actual - desc, 2);

                    lblDescuento.Text = desc.ToString();
                    lblTotalVenta.Text = final.ToString();

                    pnlDescuento.Visible = false;
                    panel18.Visible = false;
                }
                else
                {
                    MessageBox.Show("El valor del descuento debe ser menor al total actual", "Error al aplicar descuento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }
            catch (Exception)
            {
                MessageBox.Show("El número ingresado no es válido", "Número inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void EliminarVenta()
        {
            if (lblVenta.Text == "0" || lblVenta.Text == "$ven")
            {
                MessageBox.Show("No se puede eliminar una venta no aperturada", "Error al eliminar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    venta.IdVenta = Convert.ToInt32(lblVenta.Text);

                    if (funcionVenta.EliminarVenta(venta) == true)
                    {
                        lblVenta.Text = "0";
                        lblTotalVenta.Text = "0";
                        lblDetalle.Text = "$det";
                        gridVentas.DataSource = null; //Vaciar los datos del gridview
                        gridVentas.Refresh(); //Actualizo mi gridview

                        btnCobrar.Visible = false;
                        btnCrearVenta.Visible = true;
                        lblCondVenta.Text = "VENTAS";

                        pnlTeclado.Enabled = false;
                        txtBuscar.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnEliminarVenta_Click(object sender, EventArgs e)
        {
            EliminarVenta();
            pnlDescuento.Visible = false;
            ContadorVentaEspera();
        }

        private void txtNuevoTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            char signo_decimal = (char)46;

            if (e.KeyChar == signo_decimal)
            {
                if (txtNuevoTotal.Text.Length == 0 | txtNuevoTotal.Text.LastIndexOf(signo_decimal) >= 0)
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

        public void ListarClientes()
        {
            //try
            //{
            //    DataTable dt = new DataTable();
            //    SqlDataAdapter da;
            //    SqlConnection con = new SqlConnection();
            //    con.ConnectionString = CONEXION.Conexion.conectar;
            //    con.Open();

            //    da = new SqlDataAdapter("SELECT id_cli, CONCAT(prinom_cli,' ',app_cli) AS Cliente from t_clientes WHERE estado='ACTIVADO'", con);
            //    da.Fill(dt);

            //    cbxCliente.DisplayMember = "Cliente";
            //    cbxCliente.ValueMember = "id_cli";
            //    cbxCliente.DataSource = dt;

            //    con.Close();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("No hay roles listados");
            //}
        }

        private void btnTuerca_Click(object sender, EventArgs e)
        {
            
        }

        private void pbxCampana_Click(object sender, EventArgs e)
        {
            VISTAS.NOTIFICACIONES.formNotificaciones not = new VISTAS.NOTIFICACIONES.formNotificaciones();
            not.ShowDialog();
        }

        private void timerBuscadorBarras_Tick(object sender, EventArgs e)
        {
            timerBuscadorBarras.Stop();
            try
            {
                if (txtBuscar.Text == "")
                {
                    gridAutoBusqueda.Visible = false;
                    lblTipoBusqueda.Visible = true;
                    lblIdProd.Text = "";
                }
                if (txtBuscar.Text != "")
                {
                    gridAutoBusqueda.Visible = true;
                    lblTipoBusqueda.Visible = false;
                    //lblIdProd.Text = gridAutoBusqueda.SelectedCells[0].Value.ToString();
                    AutobusquedaProductos();
                }

                if (lblTipoBusqueda2.Text == "LECTORA")
                {
                    lblIdProd.Text = gridAutoBusqueda.SelectedCells[0].Value.ToString();
                    lblCodigo.Text = gridAutoBusqueda.SelectedCells[1].Value.ToString();
                    lblDescripcion.Text = gridAutoBusqueda.SelectedCells[2].Value.ToString();
                    lblCosto.Text = gridAutoBusqueda.SelectedCells[3].Value.ToString();
                    lblPrecioVenta.Text = gridAutoBusqueda.SelectedCells[4].Value.ToString();
                    lblStock.Text = gridAutoBusqueda.SelectedCells[5].Value.ToString();
                    lblTipo.Text = gridAutoBusqueda.SelectedCells[11].Value.ToString();
                    lblUsaInv.Text = gridAutoBusqueda.SelectedCells[12].Value.ToString();

                    gridAutoBusqueda.Visible = false;
                    ContadorDetalleVenta();
                    txtBuscar.Clear();
                    CondicionProducto();
                }
            }
            catch (Exception)
            {

            }
        }

        private void toggleTema_OnValueChange(object sender, EventArgs e)
        {
            if (toggleTema.Value == true)
            {
                panel16.BackColor = Color.SteelBlue;
                panel2.BackColor = Color.LightGoldenrodYellow;
                pnlModulos.BackColor = Color.White;
                gridVentas.BackgroundColor = Color.Azure;
                panel17.BackColor = Color.LightSalmon;
                pnlCalculadora.BackColor = Color.AliceBlue;
                lblTema.Text = "Tema\r\nClaro";
            }
            else
            {
                panel16.BackColor = Color.Black;
                panel2.BackColor = Color.Gray;
                pnlModulos.BackColor = Color.White;
                gridVentas.BackgroundColor = Color.Snow;
                panel17.BackColor = Color.Black;
                pnlCalculadora.BackColor = Color.DimGray;
                lblTema.Text = "Tema\r\nOscuro";
            }
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            DASHBOARD.frmDashboard dash = new DASHBOARD.frmDashboard();
            dash.ShowDialog();
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {

        }

        private void btnBoletas_Click(object sender, EventArgs e)
        {
            BOLETAS.formBoleta bol = new BOLETAS.formBoleta();
            bol.ShowDialog();
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            VISTAS.CATALOGO.formCatalogo cat = new VISTAS.CATALOGO.formCatalogo();
            cat.ShowDialog();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            //VISTAS.MENUPRINCIPAL.formMediosPago pag = new VISTAS.MENUPRINCIPAL.formMediosPago();
            //pag.ShowDialog();
        }

        private void btnVerVentas_Click(object sender, EventArgs e)
        {
            VISTAS.HISTORIAL_VENTAS.formHistorialVentas hst = new VISTAS.HISTORIAL_VENTAS.formHistorialVentas();
            hst.ShowDialog();
        }

        private void flowTools_Paint(object sender, PaintEventArgs e)
        {

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

        private void txtCalculadora_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarDecimales(txtCalculadora, e);
        }

        private void btnTarjetas_Click(object sender, EventArgs e)
        {
            VISTAS.TARJETAS.formTarjetas tar = new VISTAS.TARJETAS.formTarjetas();
            tar.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            VISTAS.COPIAS_SEGURIDAD.formCopiasSeguridad bak = new VISTAS.COPIAS_SEGURIDAD.formCopiasSeguridad();
            bak.ShowDialog();
        }

        private void btnRestaurarVentas_Click(object sender, EventArgs e)
        {
            VISTAS.VENTAS.formVentasEspera esp = new VISTAS.VENTAS.formVentasEspera();
            AddOwnedForm(esp);
            esp.ShowDialog();
        }

        private void btnVentaEspera_Click(object sender, EventArgs e)
        {
            ProcesarVentaEspera();
            ContadorVentaEspera();
        }

        private void ProcesarVentaEspera()
        {
            try
            {
                venta.IdVenta = Convert.ToInt32(lblVenta.Text);
                venta.FechaVenta = DateTime.Now;
                venta.NumeroDoc = "0001";
                venta.MontoTotal = Convert.ToDouble(lblTotalVenta.Text);
                venta.Subtotal = Convert.ToDouble(lblSubtotal.Text);
                venta.Descuento = Convert.ToDouble(lblDescuento.Text);
                venta.Estado = "VENTA EN ESPERA";
                venta.IdUsuario = Convert.ToInt32(LOGIN.formLogin.id_usuario);
                venta.Accion = "FALTA";

                if (funcionVenta.VentaEspera(venta) == true)
                {
                    ActualizarEsperaDetalle();
                    MessageBox.Show("Venta puesta en espera correctamente", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //lblVenta.Text = "0";
                    //lblTotalVenta.Text = "0";
                    //lblDetalle.Text = "$det";
                    //gridVentas.DataSource = null; //Vaciar los datos del gridview
                    //gridVentas.Refresh(); //Actualizo mi gridview

                    //btnCobrar.Visible = false;
                    //btnCrearVenta.Visible = true;
                    //lblCondVenta.Text = "VENTAS";

                    //pnlTeclado.Enabled = false;
                    //txtBuscar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ActualizarEsperaDetalle()
        {
            try
            {
                foreach (DataGridViewRow row in gridVentas.Rows)
                {
                    int det = Convert.ToInt32(row.Cells["id_detalleventa"].Value);
                    try
                    {
                        detalleVenta.IdVenta = Convert.ToInt32(lblVenta.Text);
                        detalleVenta.IdDetalleVenta = det;
                        detalleVenta.Estado = "VENTA EN ESPERA";

                        if (funcionDetalleVenta.ActualizarEstadoDetalle(detalleVenta) == true)
                        {
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                pnlDescuento.Visible = false;
                lblVenta.Text = "0";
                lblTotalVenta.Text = "0";
                lblDetalle.Text = "$det";
                gridVentas.DataSource = null; //Vaciar los datos del gridview
                gridVentas.Refresh(); //Actualizo mi gridview

                btnCobrar.Visible = false;
                btnCrearVenta.Visible = true;
                lblCondVenta.Text = "VENTAS";

                pnlTeclado.Enabled = false;
                txtBuscar.Enabled = false;
            }
            catch (Exception)
            {
            }

        }


        string contaespera;
        private void ContadorVentaEspera()
        {
            try
            {
                VentasDao.ContadorVentasEspera(ref contaespera);
                if (contaespera=="")
                {
                    pnlContaEspera.Visible = false;
                }
                else
                {
                    lblContaEspera.Text = "";
                    lblContaEspera.Text = contaespera;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede capturar el serial");
            }
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            VISTAS.CAJA.formGastosIngresos caj = new VISTAS.CAJA.formGastosIngresos();
            caj.ShowDialog();
        }

        private void btnMisProductos_Click(object sender, EventArgs e)
        {
            PRODUCTOS.formProductos prod = new PRODUCTOS.formProductos();
            prod.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            PRODUCTOS.formOpcionesProductos opc = new PRODUCTOS.formOpcionesProductos();
            opc.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            VISTAS.PROVEEDORES.formProveedores prov = new VISTAS.PROVEEDORES.formProveedores();
            prov.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            VISTAS.PROVEEDORES.formProveedores prov = new VISTAS.PROVEEDORES.formProveedores();
            prov.ShowDialog();
        }
    }
}
