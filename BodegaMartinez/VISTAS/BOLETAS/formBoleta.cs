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

namespace BodegaMartinez.BOLETAS
{
    public partial class formBoleta : Form
    {
        public formBoleta()
        {
            InitializeComponent();
        }

        repBoleta repbol = new repBoleta(); //llamo a mi maquetacion de reporte

        private void ImprimirBoleta()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                da = new SqlDataAdapter("imprimir_boleta", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@id_venta", MENUPRINCIPAL.formMenuPrincipal.idventa);

                da.Fill(dt);
                con.Close();

                repbol = new repBoleta(); //llamo al reves
                repbol.DataSource = dt; //llenando los datos en mi objeto de maquetacion
                repbol.tablaBol.DataSource = dt; //mandando los datos capturados a mi tabla de maquetacion ---recomendacion: la tabla debe ser publica
                repbol.txtTotalMonto.Value = MENUPRINCIPAL.formMenuPrincipal.totalventa; //mandando un parametro a mi reporte (tiene q ser publico)
                repbol.txtSubTotal.Value = MENUPRINCIPAL.formMenuPrincipal.subtotal;
                repbol.txtDescuento.Value = MENUPRINCIPAL.formMenuPrincipal.descuento;
                repbol.txtSerie.Value = MENUPRINCIPAL.formMenuPrincipal.serie;

                miBoleta.Report = repbol; //adhiriendo mi maquetacion con mi interfaz de reporte
                miBoleta.RefreshReport(); //actualizo los datos al iniciar reporte
            }
            catch (Exception)
            {

            }
        }

        private void formBoleta_Load(object sender, EventArgs e)
        {
            
        }

        private void miBoleta_Load(object sender, EventArgs e)
        {
            ImprimirBoleta();
        }
    }
}
