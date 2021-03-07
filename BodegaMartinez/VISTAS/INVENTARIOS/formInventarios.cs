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
using System.Collections;
using System.IO;
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;

namespace BodegaMartinez.INVENTARIOS
{
    public partial class formInventarios : Form
    {
        public formInventarios()
        {
            InitializeComponent();
        }

        DashboardsDao funcionDashboard = new DashboardsDao();

        Inventario inventario = new Inventario();
        InventariosDao funcionInventario = new InventariosDao();

        Producto producto = new Producto();
        ProductosDao funcionProducto = new ProductosDao();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MENUPRINCIPAL.formMenuPrincipal men = new MENUPRINCIPAL.formMenuPrincipal();
            men.ShowDialog();
        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            pnlKardex.Visible = true;
            pnlMovimientos.Visible = false;
            pnlBajos.Visible = false;
            pnlReporte.Visible = false;
            pnlVencimiento.Visible = false;

            barKardex.Visible = true;
            barMovimientos.Visible = false;
            barBajos.Visible = false;
            barReporte.Visible = false;
            barVencimientos.Visible = false;

            pnlKardex.Dock = DockStyle.Fill;
            ListarAño();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOcultarFiltro_Click(object sender, EventArgs e)
        {
            pnlFiltroAvMov.Visible = false;
            pnlSimpleMov.Visible = true;
            gridMovimientos.Dock = DockStyle.Fill;
            pnlAcumulado.Visible = false;
        }

        private void btnFiltroAv_Click(object sender, EventArgs e)
        {
            pnlFiltroAvMov.Visible = true;
            pnlFiltroAvMov.Dock = DockStyle.Fill;
            gridMovimientos.Dock = DockStyle.Left;
            pnlAcumulado.Visible = true;
            ListarUsuarios();
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            pnlKardex.Visible = false;
            pnlMovimientos.Visible = true;
            pnlBajos.Visible = false;
            pnlReporte.Visible = false;
            pnlVencimiento.Visible = false;

            barKardex.Visible = false;
            barMovimientos.Visible = true;
            barBajos.Visible = false;
            barReporte.Visible = false;
            barVencimientos.Visible = false;

            pnlMovimientos.Dock = DockStyle.Fill;
            gridMovimientos.Dock = DockStyle.Fill;
        }

        private void formKardex_Load(object sender, EventArgs e)
        {
            pnlKardex.Dock = DockStyle.Fill;
            VaciarListaDetalle();
            ListarAño();
        }

        public void ListarAño()
        {
            try
            {
                cbxAño.DataSource = funcionDashboard.ListarAño();
                cbxAño.DisplayMember = "Año";
                cbxAño.ValueMember = "Año";
            }
            catch (Exception)
            {
                MessageBox.Show("No hay roles listados", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ListarMes()
        {
            try
            {
                cbxMes.DataSource = funcionDashboard.ListarMes(cbxAño.Text);
                cbxMes.DisplayMember = "Mes";
                cbxMes.ValueMember = "id";
            }
            catch (Exception)
            {
                //MessageBox.Show("No hay roles listados", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        string cantinv;
        private void CantidadInventario()
        {
            try
            {
                InventariosDao.CantidadInventario(ref cantinv);

                lblCantidadProd.Text = "";
                lblCantidadProd.Text = cantinv;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los productos");
            }
        }

        string costoinv;
        private void CostoInventario()
        {
            try
            {
                InventariosDao.CostoInventario(ref costoinv);

                lblCostoProd.Text = "";
                lblCostoProd.Text = costoinv;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan los inventarios");
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            pnlKardex.Visible = false;
            pnlMovimientos.Visible = false;
            pnlBajos.Visible = false;
            pnlReporte.Visible = true;
            pnlVencimiento.Visible = false;

            barKardex.Visible = false;
            barMovimientos.Visible = false;
            barBajos.Visible = false;
            barReporte.Visible = true;
            barVencimientos.Visible = false;

            pnlReporte.Dock = DockStyle.Fill;

            CantidadInventario();
            CostoInventario();
        }

        private void InventariosBajos()
        {
            try
            {
                DataTable dt = new DataTable();
                InventariosDao.MostrarInventariosBajos(ref dt);

                gridBajos.DataSource = dt;

                gridBajos.Columns[0].Visible = true;
                gridBajos.Columns[1].Visible = true;
                gridBajos.Columns[2].Visible = true;
                gridBajos.Columns[3].Visible = true;
                gridBajos.Columns[4].Visible = true;
                gridBajos.Columns[5].Visible = true;
                gridBajos.Columns[6].Visible = true;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridBajos);
        }

        private void btnBajos_Click(object sender, EventArgs e)
        {
            pnlKardex.Visible = false;
            pnlMovimientos.Visible = false;
            pnlBajos.Visible = true;
            pnlReporte.Visible = false;
            pnlVencimiento.Visible = false;

            barKardex.Visible = false;
            barMovimientos.Visible = false;
            barBajos.Visible = true;
            barReporte.Visible = false;
            barVencimientos.Visible = false;

            pnlBajos.Dock = DockStyle.Fill;

            InventariosBajos();
        }

        private void ColorearCeldas()
        {
            foreach (DataGridViewRow row in gridVencimientos.Rows)
            {
                int umbral = Convert.ToInt32(row.Cells["Días"].Value.ToString());

                if (umbral>30)
                {
                    row.DefaultCellStyle.Font = new Font("Berlin Sans FB Demi", 12, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.ForestGreen;
                    row.DefaultCellStyle.SelectionForeColor = Color.ForestGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.Honeydew;
                }
                else if (umbral >0 && umbral<=30)
                {
                    row.DefaultCellStyle.Font = new Font("Berlin Sans FB Demi", 12, FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    row.DefaultCellStyle.SelectionForeColor = Color.DarkOrange;
                    row.DefaultCellStyle.SelectionBackColor = Color.OldLace;
                }
                else
                {
                    row.DefaultCellStyle.Font = new Font("Berlin Sans FB Demi", 12, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    row.DefaultCellStyle.SelectionForeColor = Color.DarkRed;
                    row.DefaultCellStyle.SelectionBackColor = Color.LavenderBlush;
                }
            }
        }

        private void btnVencimiento_Click(object sender, EventArgs e)
        {
            pnlKardex.Visible = false;
            pnlMovimientos.Visible = false;
            pnlBajos.Visible = false;
            pnlReporte.Visible = false;
            pnlVencimiento.Visible = true;

            barKardex.Visible = false;
            barMovimientos.Visible = false;
            barBajos.Visible = false;
            barReporte.Visible = false;
            barVencimientos.Visible = true;

            pnlVencimiento.Dock = DockStyle.Fill;
        }

        private void BuscarKardex()
        {
            try
            {
                DataTable dt = new DataTable();
                InventariosDao.BuscarKardex(ref dt, txtBuscarKardex.Text);
                gridKardex.DataSource = dt;

                gridKardex.Columns[0].Visible = false;
                gridKardex.Columns[1].Visible = true;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridKardex);
        }

        private void txtBuscarKardex_TextChanged(object sender, EventArgs e)
        {
            BuscarKardex();

            if (txtBuscarKardex.Text!="")
            {
                gridKardex.Visible = true;
            }
            else
            {
                gridKardex.Visible = false;
            }
        }

        private void BuscarMovimientos()
        {
            try
            {
                DataTable dt = new DataTable();
                InventariosDao.BuscarMovimientos(ref dt, txtBuscarMov.Text);
                gridMovimientos.DataSource = dt;

                gridMovimientos.Columns[0].Visible = false;
                gridMovimientos.Columns[1].Visible = true;
                gridMovimientos.Columns[2].Visible = true;
                gridMovimientos.Columns[3].Visible = true;
                gridMovimientos.Columns[4].Visible = true;
                gridMovimientos.Columns[5].Visible = true;
                gridMovimientos.Columns[6].Visible = true;
                gridMovimientos.Columns[7].Visible = true;
                gridMovimientos.Columns[8].Visible = true;
                gridMovimientos.Columns[9].Visible = true;
                gridMovimientos.Columns[10].Visible = true;
            }
            catch (Exception)
            {
            }
            Datatables_tamañoAuto.Multilinea(ref gridMovimientos);
        }

        private void txtBuscarMov_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarMov.Text!="")
            {
                BuscarMovimientos();
            }
        }

        private void ListarUsuarios()
        {
            try
            {
                cbxUsuarios.DataSource = funcionInventario.ListarUsuarios();
                cbxUsuarios.DisplayMember = "Usuario";
                cbxUsuarios.ValueMember = "id_usu";
            }
            catch (Exception)
            {
                MessageBox.Show("Categoria no invocada");
            }
        }

        private void FiltroAvanzadoKardex()
        {
            try
            {
                inventario.Fecha = dateDia.Value;
                inventario.Tipo = cbxTipoMov.Text;
                inventario.IdUsuario = Convert.ToInt32(cbxUsuarios.SelectedValue);

                DataTable dt = new DataTable();
                InventariosDao.FiltroAvanzadoKardex(ref dt, inventario);
                gridMovimientos.DataSource = dt;

                gridMovimientos.Columns[0].Visible = false;
                gridMovimientos.Columns[1].Visible = true;
                gridMovimientos.Columns[2].Visible = true;
                gridMovimientos.Columns[3].Visible = true;
                gridMovimientos.Columns[4].Visible = true;
                gridMovimientos.Columns[5].Visible = true;
                gridMovimientos.Columns[6].Visible = true;
                gridMovimientos.Columns[7].Visible = true;
                gridMovimientos.Columns[8].Visible = true;
                gridMovimientos.Columns[9].Visible = true;
                gridMovimientos.Columns[10].Visible = true;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridMovimientos);
        }

        private void cbxUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlFiltroAvMov.Visible==true)
            {
                FiltroAvanzadoKardex();
                FiltroAcumuladoKardex();
            }
        }

        private void FiltroAcumuladoKardex()
        {
            try
            {
                inventario.Fecha = dateDia.Value;
                inventario.Tipo = cbxTipoMov.Text;
                inventario.IdUsuario = Convert.ToInt32(cbxUsuarios.SelectedValue);

                DataTable dt = new DataTable();
                InventariosDao.FiltroAcumuladoKardex(ref dt, inventario);
                gridAcumulado.DataSource = dt;

                gridAcumulado.Columns[0].Visible = true;
                gridAcumulado.Columns[1].Visible = true;
                gridAcumulado.Columns[2].Visible = true;
                gridAcumulado.Columns[3].Visible = true;
            }
            catch (Exception)
            {
            }
            Datatables_tamañoAuto.Multilinea(ref gridAcumulado);
        }

        private void cbxTipoMov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pnlFiltroAvMov.Visible == true)
            {
                FiltroAvanzadoKardex();
                FiltroAcumuladoKardex();
            }
        }

        private void dateDia_ValueChanged(object sender, EventArgs e)
        {
            if (pnlFiltroAvMov.Visible == true)
            {
                FiltroAvanzadoKardex();
                FiltroAcumuladoKardex();
            }
        }

        private void MostrarProductosReporte()
        {
            try
            {
                DataTable dt = new DataTable();
                InventariosDao.MostrarProductosReporte(ref dt);

                gridReporte.DataSource = dt;

                //hay un boton creado previamente
                gridReporte.Columns[0].Visible = false;
                gridReporte.Columns[1].Visible = false;
                gridReporte.Columns[2].Visible = true;
                gridReporte.Columns[3].Visible = true;
                gridReporte.Columns[4].Visible = true;
                gridReporte.Columns[5].Visible = true;
                gridReporte.Columns[6].Visible = true;
                gridReporte.Columns[7].Visible = true;
                gridReporte.Columns[8].Visible = true;
                gridReporte.Columns[9].Visible = true;
                gridReporte.Columns[10].Visible = true;
                gridReporte.Columns[11].Visible = true;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridReporte);
        }

        private void VaciarListaDetalle()
        {
            try
            {
                if (funcionInventario.VaciarListaDetalle() == true)
                {
                    //MessageBox.Show("¡Reporte Vaciado!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al eliminar el producto");
            }
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            MostrarProductosReporte();
            VaciarListaDetalle();
            lblCond.Text = "T";
        }

        private void AutobusquedaProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                InventariosDao.AutobusquedaProductos(ref dt, txtBuscarRep.Text);
                gridAutoRep.DataSource = dt;

                gridAutoRep.Columns[0].Visible = false;
                gridAutoRep.Columns[1].Visible = false;
                gridAutoRep.Columns[2].Visible = true;
                gridAutoRep.Columns[3].Visible = false;
                gridAutoRep.Columns[4].Visible = false;
                gridAutoRep.Columns[5].Visible = false;
                gridAutoRep.Columns[6].Visible = false;
                gridAutoRep.Columns[7].Visible = false;
                gridAutoRep.Columns[8].Visible = false;
                gridAutoRep.Columns[9].Visible = false;
                gridAutoRep.Columns[10].Visible = false;
            }
            catch (Exception)
            {
            }
            Datatables_tamañoAuto.Multilinea(ref gridAutoRep);
        }

        private void txtBuscarRep_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarRep.Text != "")
            {
                gridAutoRep.Visible = true;
                AutobusquedaProductos();
            }
        }

        private void InsertarDetalleReporte()
        {
            try
            {
                producto.IdProducto = Convert.ToInt32(lblIdProd.Text);
                producto.Codigo = lblCodigo.Text;
                producto.NombreProducto = lblProducto.Text;
                producto.PrecioCompra = Convert.ToDouble(lblCosto.Text);
                producto.PrecioVenta = Convert.ToDouble(lblPrecio.Text);
                producto.Stock = Convert.ToInt32(lblStock.Text);
                producto.StockMinimo = Convert.ToInt32(lblMinimo.Text);
                producto.Total = Convert.ToDouble(lblImporte.Text);

                if (funcionProducto.InsertarDetalleReporte(producto) == true)
                {
                    MostrarDetalleProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MostrarDetalleProductos()
        {
            try
            {
                DataTable dt = new DataTable();
                ProductosDao.MostrarDetalleProductos(ref dt);

                gridReporte.DataSource = dt;

                gridReporte.Columns[0].Visible = true;
                gridReporte.Columns[1].Visible = false;
                gridReporte.Columns[2].Visible = true;
                gridReporte.Columns[3].Visible = true;
                gridReporte.Columns[4].Visible = true;
                gridReporte.Columns[5].Visible = true;
                gridReporte.Columns[6].Visible = true;
                gridReporte.Columns[7].Visible = true;
                gridReporte.Columns[8].Visible = true;
            }
            catch (Exception)
            {
            }
            Datatables_tamañoAuto.Multilinea(ref gridReporte);
        }

        private void gridAutoRep_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdProd.Text = gridAutoRep.SelectedCells[0].Value.ToString();
            lblCodigo.Text = gridAutoRep.SelectedCells[1].Value.ToString();
            lblProducto.Text = gridAutoRep.SelectedCells[2].Value.ToString();
            lblCosto.Text = gridAutoRep.SelectedCells[3].Value.ToString();
            lblPrecio.Text = gridAutoRep.SelectedCells[4].Value.ToString();
            lblStock.Text = gridAutoRep.SelectedCells[5].Value.ToString();
            lblMinimo.Text = gridAutoRep.SelectedCells[6].Value.ToString();
            lblImporte.Text = gridAutoRep.SelectedCells[10].Value.ToString();

            gridAutoRep.Visible = false;
            txtBuscarRep.Clear();

            lblCond.Text = "F";

            InsertarDetalleReporte();
        }

        private void radVencido_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                InventariosDao.MostrarProductosVencidos(ref dt);

                gridVencimientos.DataSource = dt;

                gridVencimientos.Columns[0].Visible = false;
                gridVencimientos.Columns[1].Visible = true;
                gridVencimientos.Columns[2].Visible = true;
                gridVencimientos.Columns[3].Visible = true;
                gridVencimientos.Columns[4].Visible = true;
                gridVencimientos.Columns[5].Visible = true;
                gridVencimientos.Columns[5].HeaderText = "Dias vencidos";
            }
            catch (Exception)
            {
            }
            Datatables_tamañoAuto.Multilinea(ref gridVencimientos);
        }

        private void rad30dias_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                InventariosDao.MostrarProductos30Dias(ref dt);

                gridVencimientos.DataSource = dt;

                gridVencimientos.Columns[0].Visible = false;
                gridVencimientos.Columns[1].Visible = true;
                gridVencimientos.Columns[2].Visible = true;
                gridVencimientos.Columns[3].Visible = true;
                gridVencimientos.Columns[4].Visible = true;
                gridVencimientos.Columns[5].Visible = true;
                gridVencimientos.Columns[5].HeaderText = "Dias por vencer";
            }
            catch (Exception)
            {
            }
            Datatables_tamañoAuto.Multilinea(ref gridVencimientos);
        }

        int dias;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            rad30dias.Checked = false;
            radVencido.Checked = false;
            txtBuscarProdVenc.Clear();

            if (vencDinamic.Value>0)
            {
                try
                {
                    dias = Convert.ToInt32(vencDinamic.Value);

                    DataTable dt = new DataTable();
                    InventariosDao.VencimientoDinamico(ref dt, dias);
                    gridVencimientos.DataSource = dt;

                    gridVencimientos.Columns[0].Visible = false;
                    gridVencimientos.Columns[1].Visible = true;
                    gridVencimientos.Columns[2].Visible = true;
                    gridVencimientos.Columns[3].Visible = true;
                    gridVencimientos.Columns[4].Visible = true;
                    gridVencimientos.Columns[5].Visible = true;
                    gridVencimientos.Columns[5].HeaderText = "Dias por vencer";
                }
                catch (Exception)
                {
                }
                Datatables_tamañoAuto.Multilinea(ref gridVencimientos);
            }
        }

        private void BuscarProductoVencido()
        {
            try
            {
                DataTable dt = new DataTable();
                InventariosDao.BuscarProductoVencido(ref dt, txtBuscarProdVenc.Text);
                gridVencimientos.DataSource = dt;

                gridVencimientos.Columns[0].Visible = false;
                gridVencimientos.Columns[1].Visible = true;
                gridVencimientos.Columns[2].Visible = true;
                gridVencimientos.Columns[3].Visible = true;
                gridVencimientos.Columns[4].Visible = true;
                gridVencimientos.Columns[5].Visible = true;
                gridVencimientos.Columns[5].HeaderText = "Margen de días";
            }
            catch (Exception)
            {
            }
            Datatables_tamañoAuto.Multilinea(ref gridVencimientos);
            ColorearCeldas();
        }

        private void txtBuscarProdVenc_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarProdVenc.Text!="")
            {
                rad30dias.Checked = false;
                radVencido.Checked = false;
                vencDinamic.Value = 0;
                BuscarProductoVencido();
            }
        }

        private void btnImprimirBajos_Click(object sender, EventArgs e)
        {
            REPORTES.Reporte_Inventarios.formInventariosBajos baj = new REPORTES.Reporte_Inventarios.formInventariosBajos();
            baj.ShowDialog();
        }

        public static string multi;
        public static string cond;
        public static int dia;

        private void btnImprimirVenc_Click(object sender, EventArgs e)
        {
            if (txtBuscarProdVenc.Text!="")
            {
                cond = "producto";
                multi = txtBuscarProdVenc.Text;
                REPORTES.Reporte_Inventarios.formVencimientoProd venc = new REPORTES.Reporte_Inventarios.formVencimientoProd();
                venc.ShowDialog();
            }
            else if (rad30dias.Checked)
            {
                cond = "30dias";
                REPORTES.Reporte_Inventarios.formVencimientoProd venc = new REPORTES.Reporte_Inventarios.formVencimientoProd();
                venc.ShowDialog();
            }
            else if (radVencido.Checked)
            {
                cond = "vencido";
                REPORTES.Reporte_Inventarios.formVencimientoProd venc = new REPORTES.Reporte_Inventarios.formVencimientoProd();
                venc.ShowDialog();
            }
            else if (vencDinamic.Value>0)
            {
                cond = "dinamico";
                dia = Convert.ToInt32(vencDinamic.Value);
                REPORTES.Reporte_Inventarios.formVencimientoProd venc = new REPORTES.Reporte_Inventarios.formVencimientoProd();
                venc.ShowDialog();
            }
        }

        private void rad30dias_Click(object sender, EventArgs e)
        {
            txtBuscarProdVenc.Clear();
            vencDinamic.Value = 0;
        }

        private void radVencido_Click(object sender, EventArgs e)
        {
            txtBuscarProdVenc.Clear();
            vencDinamic.Value = 0;
        }

        public static string totalinv;
        public static string condrep;
        private void btnImprimirReporte_Click(object sender, EventArgs e)
        {
            condrep = lblCond.Text;
            totalinv = lblCostoProd.Text;
            REPORTES.Reporte_Inventarios.formProductosInv rep = new REPORTES.Reporte_Inventarios.formProductosInv();
            rep.ShowDialog();
        }


        private void btnImprimirMovimientos_Click(object sender, EventArgs e)
        {
            cond = "simple";
            multi = txtBuscarMov.Text;

            REPORTES.Reporte_Inventarios.formMovimientos mov = new REPORTES.Reporte_Inventarios.formMovimientos();
            mov.ShowDialog();
        }

        public static DateTime fecha;
        public static string tipo;
        public static int usuario;
        public static string encargado;

        private void btnImprimirAvanzado_Click(object sender, EventArgs e)
        {
            cond = "avanzado";

            fecha = dateDia.Value;
            tipo = cbxTipoMov.Text;
            usuario = (int)cbxUsuarios.SelectedValue;

            REPORTES.Reporte_Inventarios.formMovimientos mov = new REPORTES.Reporte_Inventarios.formMovimientos();
            mov.ShowDialog();
        }

        private void btnImprimirAcum_Click(object sender, EventArgs e)
        {
            fecha = dateDia.Value;
            tipo = cbxTipoMov.Text;
            usuario = (int)cbxUsuarios.SelectedValue;
            encargado = cbxUsuarios.Text;

            REPORTES.Reporte_Inventarios.formAcumulado acum = new REPORTES.Reporte_Inventarios.formAcumulado();
            acum.ShowDialog();
        }

        //invocar la maquetacion
        REPORTES.Reporte_Inventarios.repKardex repkdx = new REPORTES.Reporte_Inventarios.repKardex();

        private void RealizarKardex()
        {
            try
            {
                DataTable dt = new DataTable();
                InventariosDao.RealizarKardex(ref dt, lblIdKardex.Text);
                //gridVencimientos.DataSource = dt;


                repkdx = new REPORTES.Reporte_Inventarios.repKardex();
                repkdx.DataSource = dt;
                repkdx.tablaKardex.DataSource = dt;

                mireporteKardex.Report = repkdx;
                mireporteKardex.RefreshReport();
                mireporteKardex.ZoomMode= Telerik.ReportViewer.WinForms.ZoomMode.PageWidth;
            }
            catch (Exception)
            {
            }
        }

        int mes;
        int year;
        private void RealizarKardexFiltro()
        {
            try
            {
                mes = Convert.ToInt32(cbxMes.SelectedValue);
                year = Convert.ToInt32(cbxAño.Text);
                DataTable dt = new DataTable();
                InventariosDao.RealizarKardexFiltro(ref dt, lblIdKardex.Text, mes,year);
                //gridVencimientos.DataSource = dt;


                repkdx = new REPORTES.Reporte_Inventarios.repKardex();
                repkdx.DataSource = dt;
                repkdx.tablaKardex.DataSource = dt;

                mireporteKardex.Report = repkdx;
                mireporteKardex.RefreshReport();
                mireporteKardex.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth;
            }
            catch (Exception)
            {
            }
        }

        private void gridKardex_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIdKardex.Text = gridKardex.SelectedCells[0].Value.ToString();
            gridKardex.Visible = false;
            txtBuscarKardex.Clear();

            RealizarKardex();
            pnlFiltroKardex.Enabled = true;
        }

        private void EliminarDetalle()
        {
            try
            {
                foreach (DataGridViewRow filacli in gridReporte.SelectedRows)
                {
                    int id = Convert.ToInt32(filacli.Cells["idprod_rep"].Value);

                    try
                    {
                        producto.IdProducto = id;
                        if (funcionInventario.EliminarDetalle(producto) == true)
                        {
                            MostrarDetalleProductos();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        

        private void gridReporte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.gridReporte.Columns["EliRep"].Index)
            {
                EliminarDetalle();
            }
        }

        private void menuStrip8_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void gridAutoRep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            formEntrada ent = new formEntrada();
            ent.ShowDialog();
        }

        private void btnSalida_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            formSalida sal = new formSalida();
            sal.ShowDialog();
        }

        private void btnAlmacen_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            PRODUCTOS.formAlmacen alm = new PRODUCTOS.formAlmacen();
            alm.ShowDialog();
        }

        private void btnEntrada_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }

        private void checkMes_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void cbxAño_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarMes();
        }

        private void menuStrip8_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //if (cbxAño.SelectedIndex==0)
            //{
            //    MessageBox.Show("Seleccione un año", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    if (cbxMes.SelectedIndex==0)
            //    {
            //        MessageBox.Show("Seleccione un mes", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //    {
            //        RealizarKardex();
            //    }
            //}
            RealizarKardexFiltro();
        }

        private void btnMesActual_Click(object sender, EventArgs e)
        {
            RealizarKardex();
        }
    }
}
