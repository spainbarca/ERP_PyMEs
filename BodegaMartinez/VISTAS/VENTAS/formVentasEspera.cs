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
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;

namespace BodegaMartinez.VISTAS.VENTAS
{
    public partial class formVentasEspera : Form
    {
        public formVentasEspera()
        {
            InitializeComponent();
        }

        Venta venta = new Venta();
        VentasDao funcionVenta = new VentasDao();

        DetalleVenta detalleVenta = new DetalleVenta();
        DetalleVentasDao funcionDetalleVenta = new DetalleVentasDao();

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dateDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dateHasta.Value < dateDesde.Value)
            {
                MessageBox.Show("¡El valor del Fecha Hasta no debe ser menor al de Fecha Desde!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateHasta.Value = DateTime.Now;
            }
            else
            {
                MostrarVentasEspera();
            }
        }

        private void dateHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dateHasta.Value < dateDesde.Value)
            {
                MessageBox.Show("¡El valor del Fecha Hasta no debe ser menor al de Fecha Desde!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateHasta.Value = DateTime.Now;
            }
            else
            {
                MostrarVentasEspera();
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            MostrarTodasVentasEspera();
        }

        private void MostrarVentasEspera()
        {
            try
            {
                venta.FechaVenta = dateDesde.Value;
                venta.FechaPago = dateHasta.Value;

                DataTable dt = new DataTable();
                VentasDao.MostrarVentasEspera(ref dt, venta);

                gridVentaEspera.DataSource = dt;

                gridVentaEspera.Columns[0].Visible = false;
                gridVentaEspera.Columns[1].Visible = true;
                gridVentaEspera.Columns[2].Visible = true;
                gridVentaEspera.Columns[3].Visible = false;
                gridVentaEspera.Columns[4].Visible = true;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridVentaEspera);
        }

        private void MostrarTodasVentasEspera()
        {
            try
            {
                DataTable dt = new DataTable();
                VentasDao.MostrarVentasEsperaTodas(ref dt);

                gridVentaEspera.DataSource = dt;

                gridVentaEspera.Columns[0].Visible = false;
                gridVentaEspera.Columns[1].Visible = true;
                gridVentaEspera.Columns[2].Visible = true;
                gridVentaEspera.Columns[3].Visible = false;
                gridVentaEspera.Columns[4].Visible = true;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridVentaEspera);
        }

        private void formVentasEspera_Load(object sender, EventArgs e)
        {
            MostrarTodasVentasEspera();
        }

        private void gridVentaEspera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            VerDetalleEspera();
        }

        private void VerDetalleEspera()
        {
            try
            {
                foreach (DataGridViewRow filacli in gridVentaEspera.SelectedRows)
                {
                    int id = Convert.ToInt32(filacli.Cells["id_venta"].Value);
                    lblIdVenta.Text = id.ToString();

                    string fecha = Convert.ToString(filacli.Cells["Fecha"].Value);
                    lblfechadeventa.Text = fecha;

                    venta.IdVenta = id;

                    DataTable dt = new DataTable();
                    VentasDao.MostrarDetalleVentaEspera(ref dt, venta);

                    gridDetalleRestaurar.DataSource = dt;

                    gridDetalleRestaurar.Columns[0].Visible = false;
                    gridDetalleRestaurar.Columns[1].Visible = false;
                    gridDetalleRestaurar.Columns[2].Visible = false;
                    gridDetalleRestaurar.Columns[3].Visible = true;
                    gridDetalleRestaurar.Columns[4].Visible = false;
                    gridDetalleRestaurar.Columns[5].Visible = true;
                    gridDetalleRestaurar.Columns[6].Visible = true;
                    gridDetalleRestaurar.Columns[7].Visible = true;
                    gridDetalleRestaurar.Columns[8].Visible = true;
                    gridDetalleRestaurar.Columns[9].Visible = true;
                }
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridDetalleRestaurar);
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            EliminarVentaEspera();
        }

        private void EliminarVentaEspera()
        {
            if (lblIdVenta.Text == "label3")
            {
                MessageBox.Show("Seleccione una venta para eliminar", "Error al eliminar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    venta.IdVenta = Convert.ToInt32(lblIdVenta.Text);

                    if (funcionVenta.EliminarVentaEspera(venta) == true)
                    {
                        lblIdVenta.Text = "0";
                        gridDetalleRestaurar.DataSource = null; //Vaciar los datos del gridview
                        gridDetalleRestaurar.Refresh(); //Actualizo mi gridview

                        MostrarTodasVentasEspera();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            BodegaMartinez.MENUPRINCIPAL.formMenuPrincipal pri = Owner as BodegaMartinez.MENUPRINCIPAL.formMenuPrincipal;
            pri.gridVentas.DataSource = null; //Vaciar los datos del gridview
            pri.gridVentas.Refresh(); //Actualizo mi gridview

            pri.txtBuscar.Enabled = true;
            pri.pnlModulos.Visible = false;

            pri.lblVenta.Text = lblIdVenta.Text;
            pri.lblDetalle.Text = "100";
            pri.lblDescuento.Text = "0.00";
            pri.lblSubtotal.Text = "0.00";
            pri.lblCondVenta.Text = "PROCESO";
            pri.btnCobrar.Visible = true;
            int nuevo = Convert.ToInt32(pri.lblContaEspera.Text);
            pri.lblContaEspera.Text = (nuevo - 1).ToString();

            pri.GenerarSerie();

            pri.btnEliminarVenta.Visible = true;

            pri.btnCrearVenta.Visible = false;
            //ListarClientes();

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
                detalleVenta.IdVenta = Convert.ToInt32(lblIdVenta.Text);

                DataTable dt = new DataTable();
                DetalleVentasDao.MostrarDetalleVenta(ref dt, detalleVenta);

                pri.gridVentas.DataSource = dt;

                pri.gridVentas.Columns[0].Visible = true;
                pri.gridVentas.Columns[1].Visible = true;
                pri.gridVentas.Columns[2].Visible = true;
                pri.gridVentas.Columns[3].Visible = false;
                pri.gridVentas.Columns[4].Visible = false;
                pri.gridVentas.Columns[5].Visible = true;
                pri.gridVentas.Columns[6].Visible = false;
                pri.gridVentas.Columns[7].Visible = true;
                pri.gridVentas.Columns[8].Visible = true;
                pri.gridVentas.Columns[9].Visible = true;
                pri.gridVentas.Columns[10].Visible = true;
                pri.gridVentas.Columns[11].Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Dispose();
        }

    }
}
