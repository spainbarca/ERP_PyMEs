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

namespace BodegaMartinez.MENUPRINCIPAL
{
    public partial class formMenuPrincipal : Form
    {
        public formMenuPrincipal()
        {
            InitializeComponent();
        }

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
        }

        private void MostrarFotoPerfil()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("mostrar_fotoperfil", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@usuario", lblUsuarioIngresa.Text);

                pbxUser.BackgroundImage = null;
                byte[] b = (Byte[])sql.ExecuteScalar();

                MemoryStream ms = new MemoryStream(b);
                pbxUser.Image = Image.FromStream(ms);

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Este usuario no tiene foto de perfil");
            }
        }

        private void InvocarRol()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("invocar_rol_usuario", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@usuario", lblUsuarioIngresa.Text);

                lblRol.Text = "";
                lblRol.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
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
                pnlCredito.Enabled = false;
                pnlClientes.Enabled = false;
                pnlCobrarCred.Enabled = false;
                pnlJefe.Enabled = false;
                pnlPrestamos.Enabled = false;
                pnlUsuarios.Enabled = false;

                btnCaja.BackColor = Color.Gray;
                btnPagos.BackColor = Color.Gray;
                btnCobros.BackColor = Color.Gray;
                btnCredito.BackColor = Color.Gray;
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
        }

        private void btnLectora_Click(object sender, EventArgs e)
        {
            lblTipoBusqueda.Text = "Búsqueda por lectora";
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
            Application.Exit();
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
            INVENTARIOS.formKardex kdx = new INVENTARIOS.formKardex();
            kdx.ShowDialog();
        }

        private void lblInventario_Click(object sender, EventArgs e)
        {
            INVENTARIOS.formKardex kdx = new INVENTARIOS.formKardex();
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
    }
}
