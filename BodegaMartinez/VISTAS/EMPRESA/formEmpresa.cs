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

namespace BodegaMartinez.VISTAS.EMPRESA
{
    public partial class formEmpresa : Form
    {
        public formEmpresa()
        {
            InitializeComponent();
        }

        Empresa empresa = new Empresa();
        EmpresaDao funcionEmpresa = new EmpresaDao();

        Usuario usuario = new Usuario();
        UsuariosDao funcionUsuario = new UsuariosDao();
        RolesDao funcionRol = new RolesDao();

        string cond;
        string check;
        private void CrearEmpresa()
        {
            if (txtEmpresa.Text != "")
            {
                if (cbxPais.SelectedIndex!=0)
                {
                    if (txtRuta.Text != "")
                    {
                        if (ValidarCorreo(txtCorreo.Text) == true)
                        {
                            try
                            {

                                MemoryStream ms = new MemoryStream();
                                pbxEmpresa.Image.Save(ms, pbxEmpresa.Image.RawFormat);
                                byte[] imagen = ms.GetBuffer();

                                if (radSi.Checked)
                                {
                                    cond = "SI";
                                }
                                else
                                {
                                    cond = "NO";
                                }

                                if (checkTeclado.Checked)
                                {
                                    check = "TECLADO";
                                }
                                else if (checkLectora.Checked)
                                {
                                    check = "LECTORA";
                                }

                                empresa.Nombre = txtEmpresa.Text;
                                empresa.Logo = imagen;
                                empresa.Impuesto = cbxTipoImpuesto.Text;
                                empresa.PorcImpuesto = Convert.ToDouble(cbxPorcentaje.Text);
                                empresa.Moneda = cbxMoneda.Text;
                                empresa.Trabaja = cond;
                                empresa.ModoBusqueda = check;
                                empresa.CarpetaBackup = txtRuta.Text;
                                empresa.CorreoReportes = txtCorreo.Text;
                                empresa.UltimaFecha = dateFecha.Value;
                                empresa.Frecuencia = 1;
                                empresa.Estado = "ACTIVADO";
                                empresa.TipoEmpresa = "PyMEs";
                                empresa.Pais = cbxPais.Text;
                                empresa.Redondeo = "1";

                                if (funcionEmpresa.InsertarEmpresa(empresa) == true)
                                {
                                    MessageBox.Show("¡Registro exitoso!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //Application.Exit();
                                    panel3.Visible = true;
                                    panel3.Dock = DockStyle.Fill;
                                    panel9.Visible = true;
                                    panel9.Dock = DockStyle.Fill;
                                    btnCerrar.Visible = false;
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("¡Error al Registrar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No cumple con la estructura de un correo, digite de nuevo");
                            txtCorreo.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, seleccione una ruta de destino");
                        txtRuta.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un país");
                    cbxPais.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor, digite el nombre de la empresa");
                txtEmpresa.Focus();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public bool ValidarCorreo(String sCorreo) //alguien@dominio.com
        {
            return Regex.IsMatch(sCorreo, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }

        private void LlamarImagen()
        {
            dlgEmpresa.InitialDirectory = "";
            dlgEmpresa.Filter = "Imagenes|*.jpg;*.png";
            dlgEmpresa.FilterIndex = 2;
            dlgEmpresa.Title = "Bodega Martínez";
            if (dlgEmpresa.ShowDialog() == DialogResult.OK)
            {
                pbxEmpresa.BackgroundImage = null;
                pbxEmpresa.Image = new Bitmap(dlgEmpresa.FileName);
                pbxEmpresa.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void LlamarAdmin()
        {
            dlgAdmin.InitialDirectory = "";
            dlgAdmin.Filter = "Imagenes|*.jpg;*.png";
            dlgAdmin.FilterIndex = 2;
            dlgAdmin.Title = "Bodega Martínez";
            if (dlgAdmin.ShowDialog() == DialogResult.OK)
            {
                pbxAdmin.BackgroundImage = null;
                pbxAdmin.Image = new Bitmap(dlgAdmin.FileName);
                pbxAdmin.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void ObtenerRuta()
        {
            if (fldEmpresa.ShowDialog() == DialogResult.OK)
            {

                string ruta = fldEmpresa.SelectedPath;
                if (ruta.Contains(@"C:\"))
                {
                    MessageBox.Show("Seleccione un disco diferente al C", "Ruta Invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    txtRuta.Text = fldEmpresa.SelectedPath;
                }
            }
        }

        string contaemp;
        private void ContarEmpresa()
        {
            try
            {
                EmpresaDao.ContarEmpresa(ref contaemp);

                lblContaEmp.Text = "";
                lblContaEmp.Text = contaemp;

                if (lblContaEmp.Text=="0")
                {
                    menuStrip3.Visible = false;
                    menuStrip4.Visible = true;
                }
                else
                {
                    menuStrip3.Visible = true;
                    menuStrip4.Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las categorías");
            }
        }

        private void CrearUsuario()
        {
            if (txtClave.Text == txtConfClave.Text & txtClave.Text != "" & txtConfClave.Text != "")
            {
                if (checkExtras.Checked==true)
                {
                    if (ValidarCorreo(txtCorreo.Text) == true)
                    {
                        
                            if (txtFirstNombre.Text != "")
                            {
                                if (txtApp.Text != "")
                                {
                                    if (txtApm.Text != "")
                                    {
                                        if (txtAdmin.Text != "")
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
                                                    pbxAdmin.Image.Save(ms, pbxAdmin.Image.RawFormat);
                                                    byte[] imagen = ms.GetBuffer();

                                                    usuario.PrimerNombre = txtFirstNombre.Text;
                                                    usuario.SegundoNombre = txtSecNombre.Text;
                                                    usuario.ApellidoPaterno = txtApp.Text;
                                                    usuario.ApellidoMaterno = txtApm.Text;
                                                    usuario.FechaNacimiento = dateFecha.Value;
                                                    usuario.Genero = cbxGenero.Text;
                                                    usuario.Rol = 1;
                                                    usuario.Correo = txtCorreo.Text;
                                                    usuario.User = txtAdmin.Text;
                                                    usuario.Clave = txtClave.Text;
                                                    usuario.Icono = imagen;
                                                    usuario.NombreIcono = dlgAdmin.FileName;
                                                    usuario.Estado = "ACTIVADO";

                                                    if (funcionUsuario.InsertarUsuario(usuario) == true)
                                                    {
                                                        MessageBox.Show("!LISTO! RECUERDA que para Iniciar Sesión tu Usuario es: " + txtAdmin.Text + " y tu Contraseña es: " + txtClave.Text, "Registro Exitoso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                                        //Application.Exit();
                                                        Dispose();
                                                        LOGIN.formLogin log = new LOGIN.formLogin();
                                                        log.ShowDialog();
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
                                            txtAdmin.Focus();
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
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pbxAdmin.Image.Save(ms, pbxAdmin.Image.RawFormat);
                        byte[] imagen = ms.GetBuffer();

                        usuario.PrimerNombre = "";
                        usuario.SegundoNombre = "";
                        usuario.ApellidoPaterno = "";
                        usuario.ApellidoMaterno = "";
                        usuario.FechaNacimiento = DateTime.Now;
                        usuario.Genero = "Prefiero no decirlo";
                        usuario.Rol = 1;
                        usuario.Correo = "";
                        usuario.User = txtAdmin.Text;
                        usuario.Clave = txtClave.Text;
                        usuario.Icono = imagen;
                        usuario.NombreIcono = dlgAdmin.FileName;
                        usuario.Estado = "ACTIVADO";

                        if (funcionUsuario.InsertarUsuario(usuario) == true)
                        {
                            MessageBox.Show("!LISTO! RECUERDA que para Iniciar Sesión tu Usuario es: " + txtAdmin.Text + " y tu Contraseña es: " + txtClave.Text, "Registro Exitoso", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            Dispose();
                            LOGIN.formLogin log = new LOGIN.formLogin();
                            log.ShowDialog();
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
                MessageBox.Show("Las claves no coinciden, ¡Corríjalo!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                txtClave.Text = "";
                txtConfClave.Text = "";
            }

        }

        private void checkLectora_CheckedChanged(object sender, EventArgs e)
        {
            if (checkLectora.Checked == true)
            {
                checkTeclado.Checked = false;
            }
            else
            {
                checkTeclado.Checked = true;
            }

        }

        private void checkTeclado_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTeclado.Checked == true)
            {
                checkLectora.Checked = false;
            }
            else
            {
                checkLectora.Checked = true;
            }
        }

        private void radSi_CheckedChanged(object sender, EventArgs e)
        {
            if (radSi.Checked)
            {
                pnlCubreImpuesto.Visible = false;
            }
            else
            {
                pnlCubreImpuesto.Visible = true;
            }
        }

        private void radNo_CheckedChanged(object sender, EventArgs e)
        {
            if (radSi.Checked)
            {
                pnlCubreImpuesto.Visible = false;
            }
            else
            {
                pnlCubreImpuesto.Visible = true;
            }
        }

        private void lblCambiarLogo_Click(object sender, EventArgs e)
        {
            LlamarImagen();
        }

        private void btnCarpeta_Click(object sender, EventArgs e)
        {
            ObtenerRuta();
        }

        private void formEmpresa_Load(object sender, EventArgs e)
        {
            ContarEmpresa();
        }

        private void pbxEmpresa_Click(object sender, EventArgs e)
        {
            LlamarImagen();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CrearEmpresa();
        }

        private void lblFotoAdmin_Click(object sender, EventArgs e)
        {
            LlamarAdmin();
        }

        private void checkExtras_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkExtras_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkExtras.Checked == true)
            {
                pnlExtras.Visible = true;
            }
            else
            {
                pnlExtras.Visible = false;
            }
        }

        private void btnRegistrarAdmin_Click(object sender, EventArgs e)
        {
            //CrearUsuario();
        }

        private void txtConfClave_TextChanged(object sender, EventArgs e)
        {
            if (txtClave.Text == txtConfClave.Text)
            {
                txtClave.ForeColor = Color.Green;
                txtConfClave.ForeColor = Color.Green;
            }
            else
            {
                txtClave.ForeColor = SystemColors.HotTrack;
                txtConfClave.ForeColor = Color.Red;
            }
        }

        private void btnRegistrarAdmin_Click_1(object sender, EventArgs e)
        {
            CrearUsuario();
        }
    }
}
