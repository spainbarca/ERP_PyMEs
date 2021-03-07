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
using System.Text.RegularExpressions;

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
                                            MessageBox.Show("El género es inválido, seleccione bien");
                                            cbxGenero.Focus();
                                        }
                                        else
                                        {
                                            try
                                            {
                                                SqlConnection con = new SqlConnection();
                                                con.ConnectionString = CONEXION.Conexion.conectar;
                                                con.Open();

                                                SqlCommand sql = new SqlCommand();
                                                sql = new SqlCommand("crear_usuario", con);
                                                sql.CommandType = CommandType.StoredProcedure;
                                                sql.Parameters.AddWithValue("@prinom_usu", txtFirstNombre.Text);
                                                sql.Parameters.AddWithValue("@segnom_usu", txtSecNombre.Text);
                                                sql.Parameters.AddWithValue("@app_usu", txtApp.Text);
                                                sql.Parameters.AddWithValue("@apm_usu", txtApm.Text);
                                                sql.Parameters.AddWithValue("@fecha_nac", dateFecha.Value);
                                                sql.Parameters.AddWithValue("@genero", cbxGenero.Text);
                                                sql.Parameters.AddWithValue("@rol_usu", cbxRol.SelectedValue);
                                                sql.Parameters.AddWithValue("@correo", txtCorreo.Text);
                                                sql.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                                                sql.Parameters.AddWithValue("@clave", txtClave.Text);

                                                MemoryStream ms = new MemoryStream();
                                                pbxFoto.Image.Save(ms, pbxFoto.Image.RawFormat);

                                                sql.Parameters.AddWithValue("@icono", ms.GetBuffer());
                                                sql.Parameters.AddWithValue("@nom_icono", nombreFoto.Text);
                                                sql.Parameters.AddWithValue("@estado", "ACTIVADO");

                                                sql.ExecuteNonQuery();
                                                con.Close();
                                                MessageBox.Show("Usuario agregado correctamente");
                                                MostrarUsuarios();
                                                LimpiarCampos();
                                                pnlFormUsuario.Visible = false;
                                            }
                                            catch (Exception e)
                                            {
                                                MessageBox.Show(e.Message);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El usuario está vacío, digitelo");
                                        txtUsuario.Focus();
                                    }
                                    
                                }
                                else
                                {
                                    MessageBox.Show("El segundo apellido está vacío, digitelo");
                                    txtApm.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El primer apellido está vacío, digitelo");
                                txtApp.Focus();
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("El primer nombre está vacío, digitelo");
                            txtFirstNombre.Focus();
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("No hay imagen, inserta una foto");
                    }
                    
                }
                else
                {
                    MessageBox.Show("El correo no cumple con el patrón alguien@dominio.com");
                    txtCorreo.Focus();
                    txtCorreo.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Clave incorrecta, digite bien las claves", "Claves incorrectas");
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
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);

                datalistadoUsuarios.DataSource = dt;
                con.Close();
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
                datalistadoUsuarios.Columns[10].Visible = false;
                datalistadoUsuarios.Columns[11].Visible = false;
                datalistadoUsuarios.Columns[12].Visible = false;
                datalistadoUsuarios.Columns[13].Visible = false;
                datalistadoUsuarios.Columns[14].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar usuarios");
            }
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
                                            MessageBox.Show("El género es inválido, seleccione bien");
                                            cbxGenero.Focus();
                                        }
                                        else
                                        {
                                            try
                                            {
                                                SqlConnection con = new SqlConnection();
                                                con.ConnectionString = CONEXION.Conexion.conectar;
                                                con.Open();

                                                SqlCommand sql = new SqlCommand();
                                                sql = new SqlCommand("actualizar_usuario", con);
                                                sql.CommandType = CommandType.StoredProcedure;

                                                sql.Parameters.AddWithValue("@id_usu", lblIdUsu.Text);
                                                sql.Parameters.AddWithValue("@prinom_usu", txtFirstNombre.Text);
                                                sql.Parameters.AddWithValue("@segnom_usu", txtSecNombre.Text);
                                                sql.Parameters.AddWithValue("@app_usu", txtApp.Text);
                                                sql.Parameters.AddWithValue("@apm_usu", txtApm.Text);
                                                sql.Parameters.AddWithValue("@fecha_nac", dateFecha.Value);
                                                sql.Parameters.AddWithValue("@genero", cbxGenero.Text);
                                                sql.Parameters.AddWithValue("@rol_usu", cbxRol.SelectedValue);
                                                sql.Parameters.AddWithValue("@correo", txtCorreo.Text);
                                                sql.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                                                sql.Parameters.AddWithValue("@clave", txtClave.Text);

                                                MemoryStream ms = new MemoryStream();
                                                pbxFoto.Image.Save(ms, pbxFoto.Image.RawFormat);

                                                sql.Parameters.AddWithValue("@icono", ms.GetBuffer());
                                                sql.Parameters.AddWithValue("@nom_icono", nombreFoto.Text);
                                                sql.Parameters.AddWithValue("@estado", "ACTIVADO");

                                                sql.ExecuteNonQuery();
                                                con.Close();

                                                MessageBox.Show("Usuario actualizado correctamente");
                                                MostrarUsuarios();
                                                LimpiarCampos();
                                                pnlFormUsuario.Visible = false;
                                                btnModificar.Visible = false;
                                                btnGuardar.Visible = true;
                                            }
                                            catch (Exception e)
                                            {
                                                MessageBox.Show(e.Message);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("El usuario está vacío, digitelo");
                                        txtUsuario.Focus();
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("El segundo apellido está vacío, digitelo");
                                    txtApm.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El primer apellido está vacío, digitelo");
                                txtApp.Focus();
                            }

                        }
                        else
                        {
                            MessageBox.Show("El primer nombre está vacío, digitelo");
                            txtFirstNombre.Focus();
                        }

                    }
                    else
                    {
                        MessageBox.Show("No hay imagen, inserta una foto");
                    }

                }
                else
                {
                    MessageBox.Show("El correo no cumple con el patrón alguien@dominio.com");
                    txtCorreo.Focus();
                    txtCorreo.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Clave incorrecta, digite bien las claves", "Claves incorrectas");
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
                SqlDataAdapter da;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("buscar_usuarios", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.SelectCommand.Parameters.AddWithValue("@multi", txtBusqueda.Text);
                da.Fill(dt);
                datalistadoUsuarios.DataSource = dt;
                con.Close();

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
                datalistadoUsuarios.Columns[10].Visible = false;
                datalistadoUsuarios.Columns[11].Visible = false;
                datalistadoUsuarios.Columns[12].Visible = false;
                datalistadoUsuarios.Columns[13].Visible = false;
                datalistadoUsuarios.Columns[14].Visible = false;
            }
            catch (Exception)
            {
            }
            CONEXION.Datatables_tamañoAuto.Multilinea(ref datalistadoUsuarios);
        }
        
        
        public bool ValidarCorreo(String sCorreo) //alguien@dominio.com
        {
            return Regex.IsMatch(sCorreo, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }


        public void ValidarTexto(TextBox sCadena, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
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

        public void ListarRoles()
        {
            try 
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();

                da = new SqlDataAdapter("SELECT id_rol, nombre_rol from t_rol", con);
                da.Fill(dt);

                cbxRol.DisplayMember="nombre_rol";
                cbxRol.ValueMember = "id_rol";
                cbxRol.DataSource = dt;

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No hay roles listados");
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

        private void label3_Click(object sender, EventArgs e)
        {

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
            
        }

        private void formUsuarios_Load(object sender, EventArgs e)
        {
            MostrarUsuarios();
            BuscarUsuarios();
            ListarRoles();
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
        }

        private void datalistadoUsuarios_Click(object sender, EventArgs e)
        {
        }

        private void datalistadoUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistadoUsuarios.Columns["EliUsu"].Index)
            {
                DialogResult preguntaEliminar;
                preguntaEliminar = MessageBox.Show("¿Desea Ud. eliminar este usuario?", "Eliminando usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (preguntaEliminar == DialogResult.OK)
                {
                    SqlCommand sql;

                    try
                    {
                        foreach (DataGridViewRow filausuario in datalistadoUsuarios.SelectedRows)
                        {
                            int id = Convert.ToInt32(filausuario.Cells["id_usu"].Value);
                            string user = (string)filausuario.Cells["Usuario"].Value;

                            try
                            {
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = CONEXION.Conexion.conectar;
                                con.Open();

                                sql = new SqlCommand("eliminar_usuario", con);
                                sql.CommandType = CommandType.StoredProcedure;
                                sql.Parameters.AddWithValue("@id_usu", id);

                                sql.ExecuteNonQuery();

                                con.Close();

                                MessageBox.Show("El usuario ha sido borrado exitosamente");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al eliminar el usuario");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al mostrar usuarios");
                    }
                }
                MostrarUsuarios();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
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

        private void txtConfirmarClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
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

        private void txtFirstNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTexto(txtFirstNombre, e);
        }

        private void txtSecNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTexto(txtSecNombre, e);
        }

        private void txtApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTexto(txtApp, e);
        }

        private void txtApm_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarTexto(txtApm, e);
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            BuscarUsuarios();
        }
    }
}
