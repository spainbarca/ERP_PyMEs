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
using BodegaMartinez.MENUPRINCIPAL;

using System.Drawing.Printing;
using Telerik.Reporting.Processing;
using Telerik.Reporting.Drawing;
using System.IO;
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;


namespace BodegaMartinez.VISTAS.MENUPRINCIPAL
{
    public partial class formMediosPago : Form
    {
        public formMediosPago()
        {
            InitializeComponent();
        }

        private PrintDocument DOCUMENTO;
        Venta venta = new Venta();
        VentasDao funcionVenta = new VentasDao();

        DetalleVenta detalleVenta = new DetalleVenta();
        DetalleVentasDao funcionDetalleVenta = new DetalleVentasDao();

        Cliente cliente = new Cliente();
        ClientesDao funcionCliente = new ClientesDao();

        private void formMediosPago_Load(object sender, EventArgs e)
        {
            lblTotal.Text = formMenuPrincipal.totalventa;
            lblCorrelativoconCeros.Text = formMenuPrincipal.serie;
            CargarImpresoras();
            MostrarProductosEnVenta();
        }

        formMenuPrincipal frmMenu = new formMenuPrincipal();

        decimal pagoparcial;

        private void ProcesarVenta()
        {
            if (lblRestante.Text=="0.00" || lblVuelto.Text=="DEUDA")
            {
                if (txtCliente.Text!="" || txtClienteCredito.Text!="")
                {
                    //try
                    //{
                    //    SqlConnection con = new SqlConnection();
                    //    con.ConnectionString = CONEXION.Conexion.conectar;
                    //    con.Open();

                    //    SqlCommand sql = new SqlCommand();
                    //    sql = new SqlCommand("procesar_venta", con);
                    //    sql.CommandType = CommandType.StoredProcedure;
                    //    sql.Parameters.AddWithValue("@id_venta", formMenuPrincipal.idventa);
                    //    sql.Parameters.AddWithValue("@cliente", lblCliente.Text);
                    //    sql.Parameters.AddWithValue("@fecha_venta", DateTime.Now);
                    //    sql.Parameters.AddWithValue("@num_doc", "0001");
                    //    sql.Parameters.AddWithValue("@monto_total", lblTotal.Text);
                    //    sql.Parameters.AddWithValue("@subtotal", formMenuPrincipal.subtotal);
                    //    sql.Parameters.AddWithValue("@descuento", formMenuPrincipal.descuento);
                    //    sql.Parameters.AddWithValue("@tipo_pago", lblMedioPago.Text);
                    //    sql.Parameters.AddWithValue("@estado", "VENTA FINALIZADA");
                    //    sql.Parameters.AddWithValue("@boleta", formMenuPrincipal.serie);
                    //    sql.Parameters.AddWithValue("@usuario", LOGIN.formLogin.id_usuario);
                    //    sql.Parameters.AddWithValue("@fecha_pago", DateTime.Now);
                    //    sql.Parameters.AddWithValue("@accion", "CORRECTO");

                    //    if (lblMedioPago.Text=="4")
                    //    {
                    //        pagoparcial= Math.Round(Convert.ToDecimal(txtCredito.Text), 2);
                    //    }
                    //    else
                    //    {
                    //        pagoparcial = Math.Round(Convert.ToDecimal(lblTotal.Text), 2);
                    //    }

                    //    sql.Parameters.AddWithValue("@pago_parcial", pagoparcial);
                    //    sql.Parameters.AddWithValue("@porc_igv", 18);
                    //    sql.Parameters.AddWithValue("@caja", 1);
                    //    sql.Parameters.AddWithValue("@referencia_card", 1);

                    //    if (txtEfectivo.Text=="")
                    //    {
                    //        sql.Parameters.AddWithValue("@efectivo", 0);
                    //    }
                    //    else
                    //    {
                    //        sql.Parameters.AddWithValue("@efectivo", txtEfectivo.Text);
                    //    }

                    //    if (txtTarjeta.Text == "")
                    //    {
                    //        sql.Parameters.AddWithValue("@tarjeta", 0);
                    //    }
                    //    else
                    //    {
                    //        sql.Parameters.AddWithValue("@tarjeta", txtTarjeta.Text);
                    //    }

                    //    if (txtCredito.Text=="")
                    //    {
                    //        sql.Parameters.AddWithValue("@credito", 0);
                    //    }
                    //    else
                    //    {
                    //        sql.Parameters.AddWithValue("@credito", txtCredito.Text);
                    //    }

                    //    sql.ExecuteNonQuery();

                    //    con.Close();

                    //    MessageBox.Show("Venta procesada correctamente");

                    //    ActualizarEstadoDetalle();
                    //    secuencia1 = true;
                    //    secuencia2 = true;
                    //    secuencia3 = true;
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.StackTrace);
                    //}

                    try
                    {
                        venta.IdVenta = Convert.ToInt32(formMenuPrincipal.idventa);
                        venta.IdCliente = Convert.ToInt32(lblCliente.Text);
                        venta.FechaVenta = DateTime.Now;
                        venta.NumeroDoc = "0001";
                        venta.MontoTotal = Convert.ToDouble(lblTotal.Text);
                        venta.Subtotal = Convert.ToDouble(formMenuPrincipal.subtotal);
                        venta.Descuento = Convert.ToDouble(formMenuPrincipal.descuento);
                        venta.TipoPago = Convert.ToInt32(lblMedioPago.Text);
                        venta.Estado = "VENTA FINALIZADA";
                        venta.Boleta = formMenuPrincipal.serie;
                        venta.IdUsuario = Convert.ToInt32(LOGIN.formLogin.id_usuario);
                        venta.FechaPago = txtFechaPago.Value;
                        venta.Accion = "CORRECTO";

                        if (lblMedioPago.Text == "4")
                        {
                            pagoparcial = Math.Round(Convert.ToDecimal(txtCredito.Text), 2);
                        }
                        else
                        {
                            pagoparcial = Math.Round(Convert.ToDecimal(lblTotal.Text), 2);
                        }

                        venta.PagoParcial = Convert.ToDouble(pagoparcial);
                        venta.PorcIgv = 18;
                        venta.IdCaja = 1;
                        venta.ReferenciaTarjeta = Convert.ToInt32(lblIdCard.Text);

                        if (txtEfectivo.Text == "")
                        {
                            venta.Efectivo = 0;
                        }
                        else
                        {
                            venta.Efectivo = Convert.ToDouble(txtEfectivo.Text);
                        }

                        if (txtTarjeta.Text == "")
                        {
                            venta.Tarjeta = 0;
                        }
                        else
                        {
                            venta.Tarjeta = Convert.ToDouble(txtTarjeta.Text);
                        }

                        if (txtCredito.Text == "")
                        {
                            venta.Credito = 0;
                        }
                        else
                        {
                            venta.Credito = Convert.ToDouble(txtCredito.Text);
                        }

                        if (funcionVenta.ProcesarVenta(venta) == true)
                        {
                            MessageBox.Show("Venta procesada correctamente");

                            ActualizarEstadoDetalle();
                            secuencia1 = true;
                            secuencia2 = true;
                            secuencia3 = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione el nombre del cliente");
                }
            }
            else
            {
                MessageBox.Show("Termine de completar el pago de la venta", "Venta incompleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarEstadoDetalle()
        {
            //try
            //{
            //    SqlConnection con = new SqlConnection();
            //    con.ConnectionString = CONEXION.Conexion.conectar;
            //    con.Open();


            //    SqlCommand sql = new SqlCommand();
            //    sql = new SqlCommand("terminar_detalleventa", con);
            //    sql.CommandType = CommandType.StoredProcedure;
            //    sql.Parameters.AddWithValue("@id_venta", formMenuPrincipal.idventa);
            //    sql.Parameters.AddWithValue("@id_detalleventa", formMenuPrincipal.idventa);
            //    sql.Parameters.AddWithValue("@estado", "VENTA FINALIZADA");

            //    sql.ExecuteNonQuery();

            //    con.Close();
            //    frmMenu.lblCondVenta.Text = "FINALIZADO";

            //    frmMenu.lblVenta.Text = "0";
            //    frmMenu.lblTotalVenta.Text = "0";
            //    frmMenu.lblDetalle.Text = "$det";
            //    frmMenu.gridVentas.DataSource = null; //Vaciar los datos del gridview
            //    frmMenu.gridVentas.Refresh(); //Actualizo mi gridview

            //    BOLETAS.formBoleta bol = new BOLETAS.formBoleta();
            //    bol.ShowDialog();
            //    this.Close();

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                foreach (DataGridViewRow row in gridVentas.Rows)
                {
                    int det = Convert.ToInt32(row.Cells["id_detalleventa"].Value);
                    try
                    {
                        detalleVenta.IdVenta = Convert.ToInt32(formMenuPrincipal.idventa);
                        detalleVenta.IdDetalleVenta = det;
                        detalleVenta.Estado = "VENTA FINALIZADA";

                        if (funcionDetalleVenta.ActualizarEstadoDetalle(detalleVenta) == true)
                        {

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                frmMenu.lblCondVenta.Text = "FINALIZADO";

                frmMenu.lblVenta.Text = "0";
                frmMenu.lblTotalVenta.Text = "0";
                frmMenu.lblDetalle.Text = "$det";
                frmMenu.gridVentas.DataSource = null; //Vaciar los datos del gridview
                frmMenu.gridVentas.Refresh(); //Actualizo mi gridview

                BOLETAS.formBoleta bol = new BOLETAS.formBoleta();
                bol.ShowDialog();
                this.Close();
            }
            catch (Exception)
            {
            }
            
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            CalculoRestante();
            if (lblRestante.Text=="0.00")
            {
                txtCredito.Enabled = false;
            }
            else
            {
                txtCredito.Enabled = true;
            }

        }

        private void txtTarjeta_TextChanged(object sender, EventArgs e)
        {
            CalculoRestante();
            
            if (lblRestante.Text == "0.00")
            {
                txtCredito.Enabled = false;
            }
            else
            {
                txtCredito.Enabled = true;
            }

        }

        private void txtCredito_TextChanged(object sender, EventArgs e)
        {
            if (txtCredito.Text!="")
            {
                pnlCredito.Visible = true;
                panelClienteFactura.Visible = false;
            }
            else
            {
                pnlCredito.Visible = false;
                panelClienteFactura.Visible = true;
            }
            CalculoRestante();
        }

        decimal efectivo;
        decimal tarjeta;
        decimal credito;
        decimal restante;
        decimal vuelto;
        private void CalculoRestante()
        {
            decimal total = Convert.ToDecimal(lblTotal.Text);

            if (txtEfectivo.Text=="")
            {
                efectivo = 0;
            }
            else
            {
                efectivo = Convert.ToDecimal(txtEfectivo.Text);
            }

            if (txtTarjeta.Text == "")
            {
                tarjeta = 0;
            }
            else
            {
                tarjeta = Convert.ToDecimal(txtTarjeta.Text);
            }

            if (txtCredito.Text == "")
            {
                credito = 0;
            }
            else
            {
                credito = Convert.ToDecimal(txtCredito.Text);
            }

            if (txtCredito.Text=="")
            {
                restante = Math.Round(total - (efectivo + tarjeta), 2);

                if (restante <= 0)
                {
                    lblRestante.Text = "0.00";
                    vuelto = Math.Round(restante * -1, 2);
                    lblVuelto.Text = vuelto.ToString();
                }
                else
                {
                    lblRestante.Text = restante.ToString();
                    lblVuelto.Text = "FALTA";
                }
            }
            else
            {
                txtEfectivo.Clear();
                txtTarjeta.Clear();

                restante = Math.Round(total - credito, 2);

                if (restante < 0)
                {
                    lblRestante.Text = "0.00";
                    vuelto = Math.Round(restante * -1, 2);
                    lblVuelto.Text = vuelto.ToString();
                }
                else
                {
                    lblRestante.Text = restante.ToString();
                    lblVuelto.Text = "DEUDA";
                }
            }
            
        }

        private void txtClienteCredito_TextChanged(object sender, EventArgs e)
        {
            if (txtClienteCredito.Text!="")
            {
                AutoBusquedaClientes();
                gridClienteCredito.Visible = true;
            }
            else
            {
                gridClienteCredito.Visible = false;
            }
        }

        private void AutoBusquedaClientes()
        {
            try
            {
                //DataTable dt = new DataTable();
                //SqlDataAdapter da;

                //SqlConnection con = new SqlConnection();
                //con.ConnectionString = CONEXION.Conexion.conectar;
                //con.Open();
                //da = new SqlDataAdapter("autobusqueda_clientes", con);
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;

                //da.SelectCommand.Parameters.AddWithValue("@multi", txtClienteCredito.Text);
                //da.Fill(dt);
                //gridClienteCredito.DataSource = dt;
                //con.Close();

                DataTable dt = new DataTable();
                ClientesDao.AutoBusquedaClientes(ref dt, txtClienteCredito.Text);
                gridClienteCredito.DataSource = dt;

                gridClienteCredito.Columns[0].Visible = false;
                gridClienteCredito.Columns[1].Visible = true;
                gridClienteCredito.Columns[2].Visible = false;
                gridClienteCredito.Columns[3].Visible = false;
                gridClienteCredito.Columns[4].Visible = false;
                gridClienteCredito.Columns[5].Visible = false;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridClienteCredito);
        }

        private void AutoBusquedaClientesNormal()
        {
            try
            {
                //DataTable dt = new DataTable();
                //SqlDataAdapter da;

                //SqlConnection con = new SqlConnection();
                //con.ConnectionString = CONEXION.Conexion.conectar;
                //con.Open();
                //da = new SqlDataAdapter("autobusqueda_clientes", con);
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;

                //da.SelectCommand.Parameters.AddWithValue("@multi", txtCliente.Text);
                //da.Fill(dt);
                //gridClientes.DataSource = dt;
                //con.Close();

                DataTable dt = new DataTable();
                ClientesDao.AutoBusquedaClientes(ref dt, txtCliente.Text);
                gridClientes.DataSource = dt;

                gridClientes.Columns[0].Visible = false;
                gridClientes.Columns[1].Visible = true;
                gridClientes.Columns[2].Visible = false;
                gridClientes.Columns[3].Visible = false;
                gridClientes.Columns[4].Visible = false;
                gridClientes.Columns[5].Visible = false;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridClientes);
        }

        private void gridClienteCredito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gridClienteCredito_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            lblCliente.Text = gridClienteCredito.SelectedCells[0].Value.ToString();
            txtClienteCredito.Text = gridClienteCredito.SelectedCells[1].Value.ToString();
            txtClienteCredito.ReadOnly = true;
            gridClienteCredito.Visible = false;
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtCliente.Text != "")
            {
                AutoBusquedaClientesNormal();
                gridClientes.Visible = true;
            }
            else
            {
                gridClientes.Visible = false;
            }
        }

        private void gridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblCliente.Text = gridClientes.SelectedCells[0].Value.ToString();
            txtCliente.Text = gridClientes.SelectedCells[1].Value.ToString();
            txtCliente.ReadOnly = true;
            gridClientes.Visible = false;
        }

        private void txtEfectivo_Click(object sender, EventArgs e)
        {
            indicador_foco = 1;
        }

        private void txtTarjeta_Click(object sender, EventArgs e)
        {
            indicador_foco = 2;
        }

        private void txtEfectivo_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void txtTarjeta_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void TGuardarSinImprimir_Click(object sender, EventArgs e)
        {
            ProcesarVenta();
            
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidarDecimales(txtEfectivo, e);
            new ValidacionCampos().ValidarSoloDecimales(txtEfectivo, e);
        }

        private void txtTarjeta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidarDecimales(txtTarjeta, e);
            new ValidacionCampos().ValidarSoloDecimales(txtTarjeta, e);
        }

        private void txtCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ValidarDecimales(txtCredito, e);
            new ValidacionCampos().ValidarSoloDecimales(txtCredito, e);
        }

        //private void ValidarDecimales(TextBox sCadena, KeyPressEventArgs e)
        //{
        //    char signo_decimal = (char)46;

        //    if (e.KeyChar == signo_decimal)
        //    {
        //        if (sCadena.Text.Length == 0 | sCadena.Text.LastIndexOf(signo_decimal) >= 0)
        //        {
        //            e.Handled = true; // Interceptamos la pulsación para que no permitirla.
        //        }
        //        else //Si hay caracteres continuamos las comprobaciones
        //        {
        //            //Cambiamos la pulsación al separador decimal definido por el sistema 
        //            e.KeyChar = Convert.ToChar(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator);
        //            e.Handled = false; // No hacemos nada y dejamos que el sistema controle la pulsación de tecla
        //        }
        //        return;
        //    }
        //    else if (Char.IsNumber(e.KeyChar))
        //    {
        //        e.Handled = false;
        //    }
        //    else if (Char.IsControl(e.KeyChar))
        //    {
        //        e.Handled = false;
        //    }
        //    else
        //    {
        //        e.Handled = true;
        //    }
        //}

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            
            lblMedioPago.Text = "1";
            txtEfectivo.Enabled = true;
            txtTarjeta.Enabled = false;
            txtCredito.Enabled = false;
            lblIdCard.Text = "1";
            txtTarjeta.Text = "";
            txtCredito.Text = "";
            txtEfectivo.Text = "";

            indicador_foco = 1;
            txtEfectivo.Focus();

            secuencia1 = true;
            secuencia2 = true;
            secuencia3 = true;
        }

        private void btnTarjeta_Click(object sender, EventArgs e)
        {
            
            lblMedioPago.Text = "2";
            txtEfectivo.Enabled = false;
            txtTarjeta.Enabled = true;
            txtCredito.Enabled = false;

            txtTarjeta.Text = "";
            txtCredito.Text = "";
            txtEfectivo.Text = "";

            TARJETAS.formSeleccionarMedioPago tar = new TARJETAS.formSeleccionarMedioPago();
            AddOwnedForm(tar);
            tar.ShowDialog();

            indicador_foco = 2;
            txtTarjeta.Focus();

            secuencia1 = true;
            secuencia2 = true;
            secuencia3 = true;
        }

        private void btnMixto_Click(object sender, EventArgs e)
        {
            lblMedioPago.Text = "3";
            txtEfectivo.Enabled = true;
            txtTarjeta.Enabled = true;
            txtCredito.Enabled = false;
            TARJETAS.formSeleccionarMedioPago tar = new TARJETAS.formSeleccionarMedioPago();
            AddOwnedForm(tar);
            tar.ShowDialog();
            txtTarjeta.Text = "";
            txtCredito.Text = "";
            txtEfectivo.Text = "";

            indicador_foco = 1;
            txtEfectivo.Focus();

            secuencia1 = true;
            secuencia2 = true;
            secuencia3 = true;
        }

        private void btnCrédito_Click(object sender, EventArgs e)
        {
            lblMedioPago.Text = "4";
            txtEfectivo.Enabled = false;
            txtTarjeta.Enabled = false;
            txtCredito.Enabled = true;

            txtTarjeta.Text = "";
            txtCredito.Text = "";
            txtEfectivo.Text = "";

            indicador_foco = 3;
            txtCredito.Focus();

            secuencia1 = true;
            secuencia2 = true;
            secuencia3 = true;
        }

        private void btnGuardarImprimirdirecto_Click(object sender, EventArgs e)
        {
            if (lblRestante.Text == "0.00" || lblVuelto.Text == "DEUDA")
            {
                if (cbxImpresora.Text != "Ninguna")
                {
                    //editar_eleccion_de_impresora();
                    //indicador = "DIRECTO";
                    //identificar_el_tipo_de_pago();
                    ImprimirDirecto();
                }else
                {
                    MessageBox.Show("Seleccione una Impresora", "Impresora Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Termine de completar el pago de la venta", "Venta incompleta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void ImprimirDirecto()
        {
            //mostrar_Ticket_lleno();
            try
            {
                DOCUMENTO = new PrintDocument();
                DOCUMENTO.PrinterSettings.PrinterName = cbxImpresora.Text;
                if (DOCUMENTO.PrinterSettings.IsValid)
                {
                    PrinterSettings printerSettings = new PrinterSettings();
                    printerSettings.PrinterName = cbxImpresora.Text;
                    ReportProcessor reportProcessor = new ReportProcessor();
                    //reportProcessor.PrintReport(reportViewer2.ReportSource, printerSettings);
                }
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        int indicador_foco=1;
        private void btn1_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Text = txtEfectivo.Text + "1";
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Text = txtTarjeta.Text + "1";
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Text = txtCredito.Text + "1";
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Text = txtEfectivo.Text + "2";
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Text = txtTarjeta.Text + "2";
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Text = txtCredito.Text + "2";
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Text = txtEfectivo.Text + "3";
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Text = txtTarjeta.Text + "3";
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Text = txtCredito.Text + "3";
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Text = txtEfectivo.Text + "4";
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Text = txtTarjeta.Text + "4";
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Text = txtCredito.Text + "4";
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Text = txtEfectivo.Text + "5";
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Text = txtTarjeta.Text + "5";
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Text = txtCredito.Text + "5";
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Text = txtEfectivo.Text + "6";
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Text = txtTarjeta.Text + "6";
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Text = txtCredito.Text + "6";
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Text = txtEfectivo.Text + "7";
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Text = txtTarjeta.Text + "7";
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Text = txtCredito.Text + "7";
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Text = txtEfectivo.Text + "8";
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Text = txtTarjeta.Text + "8";
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Text = txtCredito.Text + "8";
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Text = txtEfectivo.Text + "9";
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Text = txtTarjeta.Text + "9";
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Text = txtCredito.Text + "9";
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Text = txtEfectivo.Text + "0";
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Text = txtTarjeta.Text + "0";
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Text = txtCredito.Text + "0";
            }
        }

        bool secuencia1 = true;
        bool secuencia2 = true;
        bool secuencia3 = true;

        private void btnpunto_Click(object sender, EventArgs e)
        {

            try
            {
                if (indicador_foco == 1)
                {
                    if (secuencia1 == true)
                    {
                        txtEfectivo.Text = txtEfectivo.Text + ".";
                        secuencia1 = false;
                    }

                    else
                    {
                        return;
                    }

                }
                else if (indicador_foco == 2)
                {
                    if (secuencia2 == true)
                    {
                        txtTarjeta.Text = txtTarjeta.Text + ".";
                        secuencia2 = false;
                    }

                    else
                    {
                        return;
                    }

                }
                else if (indicador_foco == 3)
                {
                    if (secuencia3 == true)
                    {
                        txtCredito.Text = txtCredito.Text + ".";
                        secuencia3 = false;
                    }

                    else
                    {
                        return;
                    }

                }
            }
            catch (Exception)
            {

            }
            
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            if (indicador_foco == 1)
            {
                txtEfectivo.Clear();
                secuencia1 = true;
            }
            else if (indicador_foco == 2)
            {
                txtTarjeta.Clear();
                secuencia2 = true;
            }
            else if (indicador_foco == 3)
            {
                txtCredito.Clear();
                secuencia3 = true;
            }

        }

        private void txtCredito_Click(object sender, EventArgs e)
        {
            indicador_foco = 3;
        }

        void CargarImpresoras()
        {
            cbxImpresora.Items.Clear();
            for (var I = 0; I < PrinterSettings.InstalledPrinters.Count; I++)
            {
                cbxImpresora.Items.Add(PrinterSettings.InstalledPrinters[I]);
            }
            cbxImpresora.Items.Add("Ninguna");
        }

        void MostrarProductosEnVenta()
        {
            detalleVenta.IdVenta = Convert.ToInt32(formMenuPrincipal.idventa);

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
    }
}
