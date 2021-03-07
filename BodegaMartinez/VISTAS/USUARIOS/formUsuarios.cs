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
using System.Text.RegularExpressions;
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;

namespace BodegaMartinez.USUARIOS
{
    public partial class formUsuarios : Form
    {
        public formUsuarios()
        {
            InitializeComponent();
        }

        private void LimpiarCampos()
        {
            txtFirstNombre.Text = "";
            txtSecNombre.Text = "";
            txtApp.Text = "";
            txtApm.Text = "";
            cbxGenero.SelectedIndex = 0;
            cbxRol.SelectedIndex = 0;
            txtCorreo.Text = "";
            txtUsuario.Text = "";
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
            pbxFoto.Image = null;
            label2.Visible = true;
            nombreFoto.Text = "";
        }

        Usuario usuario = new Usuario();
        UsuariosDao funcionUsuario = new UsuariosDao();
        RolesDao funcionRol = new RolesDao();

        private void CrearUsuario()
        {
            if (txtClave.Text==txtConfirmarClave.Text & txtClave.Text!="" & txtConfirmarClave.Text!="")
            {
                if (ValidarCorreo(txtCorreo.Text)==true)
                {
                    if (label2.Visible==false)
                    {
                        if (txtFirstNombre.Text!="")
                        {
                            if (txtApp.Text!="")
                            {
                                if (txtApm.Text != "")
                                {
                                    if (txtUsuario.Text!="")
                                    {
                                        if (cbxGenero.SelectedIndex==0)
                                        {
                                            MessageBox.Show("El género está vacío, ¡Seleccione!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            cbxGenero.Focus();
                                        }
                                        else
                                        {
                                            try
                                            {
                                               
                                                MemoryStream ms = new MemoryStream();
                                                pbxFoto.Image.Save(ms, pbxFoto.Image.RawFormat);
                                                byte[] imagen = ms.GetBuffer();

                                                usuario.PrimerNombre = txtFirstNombre.Text;
                                                usuario.SegundoNombre = txtSecNombre.Text;
                                                usuario.ApellidoPaterno = txtApp.Text;
                                                usuario.ApellidoMaterno = txtApm.Text;
                                                usuario.FechaNacimiento = dateFecha.Value;
                                                usuario.Genero = cbxGenero.Text;
                                                usuario.Rol = Convert.ToInt32(cbxRol.SelectedValue);
                                                usuario.Correo = txtCorreo.Text;
                                                usuario.User = txtUsuario.Text;
                                                usuario.Clave = txtClave.Text;
                                                usuario.Icono = imagen;
                                                usuario.NombreIcono = nombreFoto.Text;
                                                usuario.Estado = "ACTIVADO";

                                                if (funcionUsuario.InsertarUsuario(usuario) == true)
                                                {
                                                    MessageBox.Show("¡Registro exitoso!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    MostrarUsuarios();
                                                    LimpiarCampos();
                                                    pnlFormUsuario.Visible = false;
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                MessageBox.Show("¡Error al Registrar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                //MessageBox.Show(ex.Message);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El usuario está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtUsuario.Focus();
                                    }
                                    
                                }
                                else
                                {
                                    MessageBox.Show("El apellido materno está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtApm.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El apellido paterno está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtApp.Focus();
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("El primer nombre está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtFirstNombre.Focus();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("La imagen está vacía, ¡Insértela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                else
                {
                    MessageBox.Show("El correo no tiene el patrón correcto, ¡Modifíquelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    txtCorreo.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Las claves no coinciden, ¡Corríjalo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                txtClave.Text = "";
                txtConfirmarClave.Text = "";
            }
            
        }

        private void MostrarUsuarios()
        {
            try
            {
                DataTable dt = new DataTable();
                UsuariosDao.MostrarUsuarios(ref dt);

                datalistadoUsuarios.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                datalistadoUsuarios.Columns[0].Visible = true;
                datalistadoUsuarios.Columns[1].Visible = false;
                datalistadoUsuarios.Columns[2].Visible = true;
                datalistadoUsuarios.Columns[3].Visible = true;
                datalistadoUsuarios.Columns[4].Visible = true;
                datalistadoUsuarios.Columns[5].Visible = true;
                datalistadoUsuarios.Columns[6].Visible = true;
                datalistadoUsuarios.Columns[7].Visible = true;
                datalistadoUsuarios.Columns[8].Visible = false;
                datalistadoUsuarios.Columns[9].Visible = false;
                datalistadoUsuarios.Columns[10].Visible = true;
                datalistadoUsuarios.Columns[11].Visible = false;
                datalistadoUsuarios.Columns[12].Visible = false;
                datalistadoUsuarios.Columns[13].Visible = false;
                datalistadoUsuarios.Columns[14].Visible = false;

                txtPagActual.Text = "1";
                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = true;
                ContarUsuarios();
            }
            catch (Exception)
            {
                MessageBox.Show("No se muestran los datos", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoUsuarios);
            Datatables_tamañoAuto.Multilinea(ref datalistadoUsuarios);
        }

        private void EditarUsuario()
        {
            if (txtClave.Text == txtConfirmarClave.Text & txtClave.Text != "" & txtConfirmarClave.Text != "")
            {
                if (ValidarCorreo(txtCorreo.Text) == true)
                {
                    if (label2.Visible == false)
                    {
                        if (txtFirstNombre.Text != "")
                        {
                            if (txtApp.Text != "")
                            {
                                if (txtApm.Text != "")
                                {
                                    if (txtUsuario.Text != "")
                                    {
                                        if (cbxGenero.SelectedIndex == 0)
                                        {
                                            MessageBox.Show("El género está vacío, ¡Seleccione!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            cbxGenero.Focus();
                                        }
                                        else
                                        {
                                            try
                                            {
                                                
                                                MemoryStream ms = new MemoryStream();
                                                pbxFoto.Image.Save(ms, pbxFoto.Image.RawFormat);
                                                byte[] imagen = ms.GetBuffer();

                                                usuario.IdUsuario = Convert.ToInt32(lblIdUsu.Text);
                                                usuario.PrimerNombre = txtFirstNombre.Text;
                                                usuario.SegundoNombre = txtSecNombre.Text;
                                                usuario.ApellidoPaterno = txtApp.Text;
                                                usuario.ApellidoMaterno = txtApm.Text;
                                                usuario.FechaNacimiento = dateFecha.Value;
                                                usuario.Genero = cbxGenero.Text;
                                                usuario.Rol = Convert.ToInt32(cbxRol.SelectedValue);
                                                usuario.Correo = txtCorreo.Text;
                                                usuario.User = txtUsuario.Text;
                                                usuario.Clave = txtClave.Text;
                                                usuario.Icono = imagen;
                                                usuario.NombreIcono = nombreFoto.Text;
                                                usuario.Estado = "ACTIVADO";

                                                if (funcionUsuario.EditarUsuario(usuario) == true)
                                                {
                                                    MessageBox.Show("¡Edición exitosa!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    MostrarUsuarios();
                                                    LimpiarCampos();
                                                    pnlFormUsuario.Visible = false;
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                MessageBox.Show("¡Error al Editar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                //MessageBox.Show(ex.Message);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El usuario está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtUsuario.Focus();
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("El apellido materno está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtApm.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El apellido paterno está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtApp.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("El primer nombre está vacío, ¡Digítelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtFirstNombre.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("La imagen está vacía, ¡Insértela!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("El correo no tiene el patrón correcto, ¡Modifíquelo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    txtCorreo.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Las claves no coinciden, ¡Corríjalo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                txtClave.Text = "";
                txtConfirmarClave.Text = "";
            }
        }

        private void BuscarUsuarios()
        {
            try
            {
                DataTable dt = new DataTable();
                UsuariosDao.BuscarUsuarios(ref dt, txtBusqueda.Text);
                datalistadoUsuarios.DataSource = dt;

                datalistadoUsuarios.Columns[0].Visible = true;
                datalistadoUsuarios.Columns[1].Visible = false;
                datalistadoUsuarios.Columns[2].Visible = true;
                datalistadoUsuarios.Columns[3].Visible = true;
                datalistadoUsuarios.Columns[4].Visible = true;
                datalistadoUsuarios.Columns[5].Visible = true;
                datalistadoUsuarios.Columns[6].Visible = true;
                datalistadoUsuarios.Columns[7].Visible = true;
                datalistadoUsuarios.Columns[8].Visible = false;
                datalistadoUsuarios.Columns[9].Visible = false;
                datalistadoUsuarios.Columns[10].Visible = true;
                datalistadoUsuarios.Columns[11].Visible = false;
                datalistadoUsuarios.Columns[12].Visible = false;
                datalistadoUsuarios.Columns[13].Visible = false;
                datalistadoUsuarios.Columns[14].Visible = false;
            }
            catch (Exception)
            {
            }
            Datatables_tamañoAuto.Multilinea(ref datalistadoUsuarios);
        }

        private void EliminarUsuario()
        {
            DialogResult preguntaEliminar;
            preguntaEliminar = MessageBox.Show("¿Desea Ud. eliminar este usuario?", "Bodega Martinez", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (preguntaEliminar == DialogResult.OK)
            {
                try
                {
                    foreach (DataGridViewRow filausuario in datalistadoUsuarios.SelectedRows)
                    {
                        int id = Convert.ToInt32(filausuario.Cells["id_usu"].Value);
                        string user = (string)filausuario.Cells["Usuario"].Value;

                        try
                        {
                            usuario.IdUsuario = id;
                            if (funcionUsuario.EliminarUsuario(usuario) == true)
                            {
                                MostrarUsuarios();

                            }

                            MessageBox.Show("¡Eliminación exitosa!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al eliminar el usuario");
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("¡Error al Eliminar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        
        public bool ValidarCorreo(String sCorreo) //alguien@dominio.com
        {
            return Regex.IsMatch(sCorreo, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }

        public void ListarRoles()
        {
            try 
            {
                cbxRol.DataSource = funcionRol.ListarRoles();
                cbxRol.DisplayMember = "nombre_rol";
                cbxRol.ValueMember = "id_rol";

            }
            catch (Exception)
            {
                MessageBox.Show("No hay roles listados", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbxBoton_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            pnlFormUsuario.Visible = true;
            btnModificar.Visible = false;
            btnGuardar.Visible = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlFormUsuario.Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void pnlCerrarUsuario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CrearUsuario();

            ContarUsuarios();
            ConteoDataTable();
            ValidarPaginador();
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
            BuscarUsuarios();
            ListarRoles();
            pnlTabulacion.Visible = true;
            ContarUsuarios();
            ConteoDataTable();
            ValidarPaginador();
            
        }

        private void datalistadoUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            dlgUsuarios.InitialDirectory = "";
            dlgUsuarios.Filter = "Imagenes|*.jpg;*.png";
            dlgUsuarios.FilterIndex = 2;
            dlgUsuarios.Title = "Cargador de imagenes de usuario";
            if (dlgUsuarios.ShowDialog() == DialogResult.OK)
            {
                pbxFoto.BackgroundImage = null;
                pbxFoto.Image = new Bitmap(dlgUsuarios.FileName);
                pbxFoto.SizeMode = PictureBoxSizeMode.Zoom;
                nombreFoto.Text = Path.GetFileName(dlgUsuarios.FileName);
                label2.Visible = false;
            }
        }

        private void datalistadoUsuarios2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void datalistadoUsuarios2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            EditarUsuario();

            ContarUsuarios();
            ConteoDataTable();
            ValidarPaginador();
        }

        private void datalistadoUsuarios_Click(object sender, EventArgs e)
        {
        }

        private void datalistadoUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistadoUsuarios.Columns["EliUsu"].Index)
            {
                EliminarUsuario();
                ContarUsuarios();
                ConteoDataTable();
                ValidarPaginador();
            }
        }

        private void datalistadoUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String stringfecha = Convert.ToString(dateFecha.Value);

            //variable.Text = nombretabla.SelectedCells[n].Value.ToString();
            lblIdUsu.Text = datalistadoUsuarios.SelectedCells[1].Value.ToString();
            txtFirstNombre.Text = datalistadoUsuarios.SelectedCells[2].Value.ToString();
            txtSecNombre.Text = datalistadoUsuarios.SelectedCells[3].Value.ToString();
            txtApp.Text = datalistadoUsuarios.SelectedCells[4].Value.ToString();
            txtApm.Text = datalistadoUsuarios.SelectedCells[5].Value.ToString();
            stringfecha = datalistadoUsuarios.SelectedCells[6].Value.ToString();
            cbxGenero.Text = datalistadoUsuarios.SelectedCells[8].Value.ToString();
            cbxRol.Text = datalistadoUsuarios.SelectedCells[9].Value.ToString();
            txtCorreo.Text = datalistadoUsuarios.SelectedCells[10].Value.ToString();
            txtClave.Text = datalistadoUsuarios.SelectedCells[13].Value.ToString();
            txtUsuario.Text = datalistadoUsuarios.SelectedCells[7].Value.ToString();

            pbxFoto.BackgroundImage = null;
            byte[] b = (Byte[])datalistadoUsuarios.SelectedCells[11].Value;
            MemoryStream ms = new MemoryStream(b);
            pbxFoto.Image = Image.FromStream(ms);
            label2.Visible = false;
            nombreFoto.Text = datalistadoUsuarios.SelectedCells[12].Value.ToString();

            pnlFormUsuario.Visible = true;
            btnModificar.Visible = true;
            btnGuardar.Visible = false;
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloNumeros(e);
        }

        private void txtConfirmarClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloNumeros(e);
        }

        private void txtFirstNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtSecNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtApm_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloAlfanumericos(e);
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text!="")
            {
                BuscarUsuarios();
            }
            else
            {
                MostrarUsuarios();
            }
        }

        private void txtFirstNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaActual.Text = DateTime.Today.ToShortDateString();
            lblHoraActual.Text = DateTime.Now.ToLongTimeString();
        }

        private void PaginarUsuarios(int pagina)
        {
            try
            {
                DataTable dt = new DataTable();
                UsuariosDao.TabularUsuarios(ref dt, pagina);

                datalistadoUsuarios.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                datalistadoUsuarios.Columns[0].Visible = true;
                datalistadoUsuarios.Columns[1].Visible = false;
                datalistadoUsuarios.Columns[2].Visible = true;
                datalistadoUsuarios.Columns[3].Visible = true;
                datalistadoUsuarios.Columns[4].Visible = true;
                datalistadoUsuarios.Columns[5].Visible = true;
                datalistadoUsuarios.Columns[6].Visible = true;
                datalistadoUsuarios.Columns[7].Visible = true;
                datalistadoUsuarios.Columns[8].Visible = false;
                datalistadoUsuarios.Columns[9].Visible = false;
                datalistadoUsuarios.Columns[10].Visible = true;
                datalistadoUsuarios.Columns[11].Visible = false;
                datalistadoUsuarios.Columns[12].Visible = false;
                datalistadoUsuarios.Columns[13].Visible = false;
                datalistadoUsuarios.Columns[14].Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("No se muestran los datos", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            MostrarUsuarios();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual - 2) * 15;

            PaginarUsuarios(pagina);

            txtPagActual.Text = Convert.ToString(paginaactual - 1);

            if (txtPagActual.Text == "1")
            {
                btnAnterior.Enabled = false;
            }
            btnSiguiente.Enabled = true;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual) * 15;

            PaginarUsuarios(pagina);

            txtPagActual.Text = Convert.ToString(paginaactual + 1);

            if (txtPagActual.Text == lblTotalPag.Text)
            {
                btnSiguiente.Enabled = false;
            }
            btnAnterior.Enabled = true;
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(lblTotalPag.Text);
            int pagina = (paginaactual - 1) * 15;

            PaginarUsuarios(pagina);

            txtPagActual.Text = lblTotalPag.Text;

            btnSiguiente.Enabled = false;
            btnAnterior.Enabled = true;
        }

        string contausu;
        private void ContarUsuarios()
        {
            try
            {
                UsuariosDao.ContarUsuarios(ref contausu);

                lblTotalCatNombre.Text = "Total de Usuarios:";
                lblTotalCatNumero.Text = "";
                lblTotalCatNumero.Text = contausu;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las categorías");
            }

            ValidarPaginador();
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

        decimal totalpaginas;
        private void ConteoDataTable()
        {
            totalpaginas = Math.Ceiling(Convert.ToDecimal(lblTotalCatNumero.Text) / 15);
            lblTotalPag.Text = totalpaginas.ToString();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
