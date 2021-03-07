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
using System.Drawing.Printing;
using Telerik.Reporting.Processing;

namespace BodegaMartinez.VISTAS.HISTORIAL_VENTAS
{
    public partial class formHistorialVentas : Form
    {
        public formHistorialVentas()
        {
            InitializeComponent();
        }

        Venta venta = new Venta();
        VentasDao funcionVenta = new VentasDao();

        DetalleVenta detalleVenta = new DetalleVenta();
        DetalleVentasDao funcionDetalleVenta = new DetalleVentasDao();

        //invocar la maquetacion
        REPORTES.Reporte_Ventas.repHistorialVentas rephis = new REPORTES.Reporte_Ventas.repHistorialVentas();

        private PrintDocument DOCUMENTO;

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dateHasta.Value<dateDesde.Value)
            {
                MessageBox.Show("¡El valor del Fecha Hasta no debe ser menor al de Fecha Desde!","Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateHasta.Value = DateTime.Now;
            }
            else
            {
                MostrarVentasRango();
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
                MostrarVentasRango();
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            MostrarVentas();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void MostrarVentasRango()
        {
            try
            {
                //DataTable dt = new DataTable();
                //SqlDataAdapter da;

                //SqlConnection con = new SqlConnection();
                //con.ConnectionString = CONEXION.Conexion.conectar;
                //con.Open();
                //da = new SqlDataAdapter("mostrar_ventasrango", con);
                //da.SelectCommand.Parameters.AddWithValue("@id_venta", lblVenta.Text);
                //da.SelectCommand.Parameters.AddWithValue("@fechadesde", dateDesde.Value);
                //da.SelectCommand.Parameters.AddWithValue("@fechahasta", dateHasta.Value);
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;

                //da.Fill(dt);
                //gridVentas.DataSource = dt;
                //con.Close();
                venta.FechaVenta = dateDesde.Value;
                venta.FechaPago = dateHasta.Value;

                DataTable dt = new DataTable();
                VentasDao.MostrarVentasRango(ref dt, venta);

                gridHistorialVentas.DataSource = dt;

                gridHistorialVentas.Columns[0].Visible = true;
                gridHistorialVentas.Columns[1].Visible = false;
                gridHistorialVentas.Columns[2].Visible = true;
                gridHistorialVentas.Columns[3].Visible = true;
                gridHistorialVentas.Columns[4].Visible = true;
                gridHistorialVentas.Columns[5].Visible = false;
                gridHistorialVentas.Columns[6].Visible = true;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridHistorialVentas);
        }

        private void MostrarVentas()
        {
            try
            {
                venta.FechaVenta = dateDesde.Value;
                venta.FechaPago = dateHasta.Value;

                DataTable dt = new DataTable();
                VentasDao.MostrarVentasTodas(ref dt);

                gridHistorialVentas.DataSource = dt;

                gridHistorialVentas.Columns[0].Visible = true;
                gridHistorialVentas.Columns[1].Visible = false;
                gridHistorialVentas.Columns[2].Visible = true;
                gridHistorialVentas.Columns[3].Visible = true;
                gridHistorialVentas.Columns[4].Visible = true;
                gridHistorialVentas.Columns[5].Visible = false;
                gridHistorialVentas.Columns[6].Visible = true;
            }
            catch (Exception)
            {

            }
            Datatables_tamañoAuto.Multilinea(ref gridHistorialVentas);
        }

        private void gridHistorialVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.gridHistorialVentas.Columns["Boleta"].Index)
            {
                VerHistorial();
            }
        }

        private void gridHistorialVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VerHistorial();
        }

        private void VerHistorial()
        {
            foreach (DataGridViewRow filacli in gridHistorialVentas.SelectedRows)
            {
                int id = Convert.ToInt32(filacli.Cells["id_venta"].Value);

                venta.IdVenta = id;

                DataTable dt = new DataTable();
                VentasDao.VerHistorial(ref dt, venta);

                rephis = new REPORTES.Reporte_Ventas.repHistorialVentas();
                rephis.DataSource = dt;
                rephis.tablaHist.DataSource = dt;

                rptHistorial.Report = rephis;
                rptHistorial.RefreshReport();
                rptHistorial.ZoomMode = Telerik.ReportViewer.WinForms.ZoomMode.PageWidth;
            }
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

        private void formHistorialVentas_Load(object sender, EventArgs e)
        {
            CargarImpresoras();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (cbxImpresora.Text != "Ninguna")
            {
                //editar_eleccion_de_impresora();
                //indicador = "DIRECTO";
                //identificar_el_tipo_de_pago();
                ImprimirDirecto();
            }
            else
            {
                MessageBox.Show("Seleccione una Impresora", "Impresora Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ImprimirDirecto()
        {
            try
            {
                DOCUMENTO = new PrintDocument();
                DOCUMENTO.PrinterSettings.PrinterName = cbxImpresora.Text;
                if (DOCUMENTO.PrinterSettings.IsValid)
                {
                    PrinterSettings printerSettings = new PrinterSettings();
                    printerSettings.PrinterName = cbxImpresora.Text;
                    ReportProcessor reportProcessor = new ReportProcessor();
                    reportProcessor.PrintReport(rptHistorial.ReportSource, printerSettings);
                }
                Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
