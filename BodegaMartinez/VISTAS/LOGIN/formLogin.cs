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
using System.Net;
using System.Net.Mail;
using System.Management;
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;

namespace BodegaMartinez.LOGIN
{
    public partial class formLogin : Form
    {
        public static string serial;
        public static string id_usuario;
        public static string usuarioingresa;

        public formLogin()
        {
            InitializeComponent();
        }

        Usuario usuario = new Usuario();
        UsuariosDao funcionUsuario = new UsuariosDao();

        Caja caja = new Caja();
        CajasDao funcionCaja = new CajasDao();

        CierreCaja cierrecaja = new CierreCaja();
        CierreCajasDao funcionCierreCaja = new CierreCajasDao();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void formLogin_Load(object sender, EventArgs e)
        {
            ContarUsuarios();
            DibujarUsuarios();
            timer1.Start();
        }

        int contausu;
        private void ContarUsuarios()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("contar_usuarios", con);
                sql.CommandType = CommandType.StoredProcedure;

                contausu = Convert.ToInt32(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("El correo no existe en la bd");
            }
        }

        public void DibujarUsuarios()
        {
            if (contausu==0)
            {
                Dispose();
                VISTAS.EMPRESA.formEmpresa emp = new VISTAS.EMPRESA.formEmpresa();
                emp.ShowDialog();
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;
                con.Open();
                SqlCommand sql = new SqlCommand();
                sql = new SqlCommand("SELECT * from t_usuarios WHERE estado='ACTIVADO'", con);
                SqlDataReader rdr = sql.ExecuteReader();

                while (rdr.Read())
                {
                    //objeto + nombre = new objeto()

                    PictureBox pbxMifoto = new PictureBox();
                    Label lblMiusuario = new Label();
                    Panel pnlMilogin = new Panel();

                    string nombre = null;
                    nombre = "Mifoto" + rdr["id_usu"].ToString();

                    pbxMifoto.Size = new Size(193, 153);
                    pbxMifoto.Name = nombre;
                    pbxMifoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbxMifoto.Dock = DockStyle.Top;
                    pbxMifoto.BackgroundImage = null;
                    byte[] bi = (byte[])rdr["icono"];
                    MemoryStream ms = new MemoryStream(bi);
                    pbxMifoto.Image = Image.FromStream(ms);
                    pbxMifoto.Tag = rdr["usuario"].ToString();
                    pbxMifoto.Cursor = Cursors.Hand;

                    lblMiusuario.Size = new Size(193, 31);
                    lblMiusuario.Name = rdr["id_usu"].ToString();
                    lblMiusuario.Dock = DockStyle.Bottom;
                    lblMiusuario.Font = new Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    lblMiusuario.ForeColor = Color.White;
                    lblMiusuario.TextAlign = ContentAlignment.MiddleCenter;
                    lblMiusuario.BackColor = Color.Transparent;
                    lblMiusuario.Cursor = Cursors.Hand;
                    lblMiusuario.Text = rdr["usuario"].ToString();
                    lblMiusuario.Tag = rdr["usuario"].ToString();

                    pnlMilogin.Size = new Size(193, 184);
                    pnlMilogin.BackColor = Color.Transparent;
                    pnlMilogin.BorderStyle = BorderStyle.Fixed3D;
                    pnlMilogin.Name = "Mipanel" + rdr["id_usu"].ToString();

                    pnlMilogin.Controls.Add(pbxMifoto);
                    pnlMilogin.Controls.Add(lblMiusuario);
                    pnlMilogin.BringToFront();

                    flowUsuarios.Controls.Add(pnlMilogin);

                    pbxMifoto.Click += new EventHandler(pbxMifoto_Click);
                    lblMiusuario.Click += new EventHandler(lblMiLabel_Click);
                }
                con.Close();
            }
        }

        private void IniciarSesion()
        {
            ValidarUsuario();

            try
            {
                lblIdUsu.Text = "";
                lblNombreUsu.Text = "";
                lblAppUsu.Text = "";

                lblIdUsu.Text = gridUsuario.SelectedCells[0].Value.ToString();
                lblNombreUsu.Text = gridUsuario.SelectedCells[1].Value.ToString();
                lblAppUsu.Text = gridUsuario.SelectedCells[2].Value.ToString();
                lblRol.Text = gridUsuario.SelectedCells[3].Value.ToString();

                id_usuario = lblIdUsu.Text;

                if (lblIdUsu.Text != "")
                {
                    //MENUPRINCIPAL.formMenuPrincipal frmMenu = new MENUPRINCIPAL.formMenuPrincipal();
                    //frmMenu.ShowDialog();

                    timer2.Start();
                }
                else
                {
                    //MessageBox.Show("Credenciales incorrectas, verifique bien", "ERROR AL INICIAR SESIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Credenciales incorrectas, verifique bien", "ERROR AL INICIAR SESIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarUsuario()
        {
            try
            {
                DataTable dt = new DataTable();

                usuario.User = textBox1.Text;
                usuario.Clave = txtClaveNum.Text;

                UsuariosDao.ValidarUsuario(ref dt, usuario);
                gridUsuario.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }

        private void MostrarCajaSerial()
        {
            //DataTable dt = new DataTable();
            //SqlDataAdapter da;
            //SqlConnection con = new SqlConnection();
            //con.ConnectionString = CONEXION.Conexion.conectar;
            //con.Open();

            //con.Close();
        }



        public void LlamarCorreos()
        {
            try
            {
                cbxCorreo.DataSource = funcionUsuario.ListarCorreos();
                cbxCorreo.DisplayMember = "correo";
                cbxCorreo.ValueMember = "id_usu";

            }
            catch (Exception)
            {
                MessageBox.Show("No hay correos listados", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbxMifoto_Click(object sender, EventArgs e)
        {
            pnlTeclado.Visible = true;
            flowUsuarios.Visible = false;
            textBox1.Text = ((PictureBox)sender).Tag.ToString();
            usuarioingresa = textBox1.Text;
        }

        private void lblMiLabel_Click(object sender, EventArgs e)
        {
            pnlTeclado.Visible = true;
            flowUsuarios.Visible = false;
            textBox1.Text = ((Label)sender).Tag.ToString();
            usuarioingresa = textBox1.Text;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //System.exit(0);
        }

        private void btnManejaPerfil_Click(object sender, EventArgs e)
        {
            pbxLoading.Visible = true;
            barLoading.Value = 100;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clave y/o usuario incorrecto, revise bien!!");
        }

        private void btnCambiar_Click(object sender, EventArgs e)
        {
            pnlTeclado.Visible = false;
            flowUsuarios.Visible = true;
            txtClaveNum.Clear();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtClaveNum.Text = txtClaveNum.Text + "1";
        }


        private void btn2_Click(object sender, EventArgs e)
        {
            txtClaveNum.Text = txtClaveNum.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtClaveNum.Text = txtClaveNum.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtClaveNum.Text = txtClaveNum.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtClaveNum.Text = txtClaveNum.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtClaveNum.Text = txtClaveNum.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtClaveNum.Text = txtClaveNum.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtClaveNum.Text = txtClaveNum.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtClaveNum.Text = txtClaveNum.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtClaveNum.Text = txtClaveNum.Text + "0";
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtClaveNum.Clear();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            btnVer.Visible = false;
            btnNoVer.Visible = true;

            txtClaveNum.PasswordChar = '\0';
        }

        private void btnNoVer_Click(object sender, EventArgs e)
        {
            btnNoVer.Visible = false;
            btnVer.Visible = true;

            txtClaveNum.PasswordChar = '*';
        }

        private void btnSuprimir_Click(object sender, EventArgs e)
        {
            int cifras = txtClaveNum.Text.Length;

            if (cifras >= 1)
            {
                txtClaveNum.Text = txtClaveNum.Text.Remove(txtClaveNum.Text.Trim().Length - 1);
            }
            else
            {
                MessageBox.Show("No se puede borrar campos vacios");
            }

        }

        //10040

        private static string Posicion(string numero, int index, int cifras)
        {
            string res = numero.Substring(index, cifras);
            return res;
        }

        private void txtClaveNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloNumeros(e);
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            pnlRecuperarClave.Visible = true;
            LlamarCorreos();
        }

        private void btnCerrarRecu_Click(object sender, EventArgs e)
        {
            pnlRecuperarClave.Visible = false;
        }

        string clave;
        private void MostrarClave()
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.Conexion.conectar;

                con.Open();

                SqlCommand sql = new SqlCommand("mostrar_clave_correo", con);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@correo", cbxCorreo.Text);

                lblClave.Text = "";
                lblClave.Text = Convert.ToString(sql.ExecuteScalar());

                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("El correo no existe en la bd");
            }
        }

        string user;
        private void MostrarCorreodeUsuarioClick()
        {
            try
            {
                usuario.User = textBox1.Text;
                UsuariosDao.MostrarClave(ref user, usuario);

                lblCorreo.Text = "";
                lblCorreo.Text = user;
            }
            catch (Exception)
            {
                MessageBox.Show("El usuario no existe en la bd");
            }
        }


        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            MostrarCorreodeUsuarioClick();
            MostrarClave();

            if (lblCorreo.Text == cbxCorreo.Text)
            {
                richTextBox1.Text = richTextBox1.Text.Replace("@MICLAVE", lblClave.Text);
                //EnviarCorreo(correo_emisor, password, mensaje, asunto, correo_receptor, ruta)
                EnviarCorreo("spain.barcelona.1999@gmail.com", "theproxD2020", richTextBox1.Text, "Recuperar Clave", cbxCorreo.Text, "");
            }
            else
            {
                MessageBox.Show("Este no es su correo, seleccione bien", "ELECCION DE CORREO ELECTRONICO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        internal void EnviarCorreo(string emisor, string clave, string mensaje, string asunto, string correo, string ruta)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient envio = new SmtpClient();

                mail.To.Clear();  //vaciar contenidos
                mail.Body = "";
                mail.Subject = "";
                mail.Body = mensaje; //Mi clave recuperada es: 12345
                mail.Subject = asunto;//Recuperar clave
                mail.IsBodyHtml = true; //lo q envie se transforme en HTML
                mail.To.Add(correo); //correo del destinatario
                mail.From = new MailAddress(emisor); //correo del que envia mensaje

                envio.Credentials = new NetworkCredential(emisor, clave); //el sistema entra a mi cuenta

                envio.Host = "smtp.gmail.com"; //direccion del servidor correo
                envio.Port = 25;
                envio.EnableSsl = true;

                envio.Send(mail); //envio del correo electronico

                lblConfirmacionCorreo.Text = "Correo enviado correctamente";
                MessageBox.Show("Mensaje enviado, revisa tu bandeja de entrada", "Recuperar clave por Gmail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlRecuperarClave.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Mensaje no enviado, revisar conexion", "Error en recuperar clave por Gmail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPruebaLogin_Click(object sender, EventArgs e)
        {
            //IniciarSesion();
        }

        private void txtClaveNum_TextChanged(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (barLoading.Value < 100)
            {
                pbxLoading.Visible = true;
                pbxLoading.BringToFront();
                barLoading.BackColor = Color.Yellow;

                barLoading.Value += 10;
                barLoading.Visible = true;
            }
            else
            {
                barLoading.Value = 0;
                timer2.Stop();
                pbxLoading.Visible = false;

                if (lblRol.Text == "1")
                {
                    this.Hide();
                    DASHBOARD.frmDashboard frmDash = new DASHBOARD.frmDashboard();
                    frmDash.ShowDialog();
                }
                else if (lblRol.Text == "2")
                {
                    this.Hide();
                    MENUPRINCIPAL.formMenuPrincipal frmenu = new MENUPRINCIPAL.formMenuPrincipal();
                    frmenu.ShowDialog();
                }
                else if (lblRol.Text == "3")
                {
                    this.Hide();
                    MENUPRINCIPAL.formMenuPrincipal frmenu = new MENUPRINCIPAL.formMenuPrincipal();
                    frmenu.ShowDialog();
                }
                else if (lblRol.Text == "4")
                {
                    EstadoCaja();
                    AperturarCaja();


                    if (lblEstadoCaja.Text=="")
                    {
                        this.Hide();

                        CAJA.formCaja frmcaja = new CAJA.formCaja();
                        frmcaja.ShowDialog();

                    }
                    else
                    {
                        this.Hide();
                        MENUPRINCIPAL.formMenuPrincipal frmenu = new MENUPRINCIPAL.formMenuPrincipal();
                        frmenu.ShowDialog();

                    }
                }
                else
                {
                    MessageBox.Show("ROL DE USUARIO NO ASIGNADO, SOLICITE UN PERMISO");
                }

                txtClaveNum.Text = "";
                pnlTeclado.Visible = false;
                flowUsuarios.Visible = true;
                barLoading.Visible = false;
            }
        }

        string capser;
        private void CapturarSerial()
        {
            try
            {
                caja.SerialPc = lblSerial.Text;

                CajasDao.CapturarSerial(ref capser, caja);

                lblSi.Text = "";
                lblSi.Text = capser;


                if (lblSi.Text != "")
                {
                    Mostrar_IdCaja_Serial();
                }
                else
                {
                    AgregarSerial();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede capturar la serial");
            }
        }

        private void AgregarSerial()
        {
            try
            {
                //SqlConnection con = new SqlConnection();
                //con.ConnectionString = CONEXION.Conexion.conectar;

                //con.Open();

                //SqlCommand sql = new SqlCommand("agregar_serial", con);
                //sql.CommandType = CommandType.StoredProcedure;
                //sql.Parameters.AddWithValue("@descripcion", "raul");
                //sql.Parameters.AddWithValue("@tema", "cyan");
                //sql.Parameters.AddWithValue("@serial_pc", lblSerial.Text);
                //sql.Parameters.AddWithValue("@impresora_ticket", "epson");
                //sql.Parameters.AddWithValue("@impresora_a4", "ulala");

                caja.Descripcion = "raul";
                caja.Tema = "cyan";
                caja.SerialPc = lblSerial.Text;
                caja.ImpresoraTicket = "epson";
                caja.ImpresoraA4 = "ulala";

                if (funcionCaja.AgregarCaja(caja) == true)
                {
                    MessageBox.Show("¡Registro exitoso!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarCajaSerial();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo guardar el serial");
            }
        }

        private void Mostrar_IdCaja_Serial()
        {
            try
            {
                DataTable dt = new DataTable();

                caja.SerialPc = lblSerial.Text;

                CajasDao.MostrarIdCajaSerial(ref dt, caja);
                gridCajas.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }

        string estcaja;
        private void EstadoCaja()
        {
            try
            {
                caja.IdCaja = Convert.ToInt32(lblIdCaja.Text);

                CajasDao.EstadoCaja(ref estcaja, caja);

                lblEstadoCaja.Text = "";
                lblEstadoCaja.Text = estcaja;
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede capturar el serial");
            }
        }

        private void AperturarCaja()
        {
            try
            {
                cierrecaja.FechaInicio = DateTime.Now;
                cierrecaja.FechaFin = DateTime.Now;
                cierrecaja.FechaCierre = DateTime.Now;
                cierrecaja.Ingresos = 0;
                cierrecaja.Egresos = 0;
                cierrecaja.Saldo = 0;
                cierrecaja.IdUsuario = Convert.ToInt32(lblIdUsu.Text);
                cierrecaja.TotalReal = 0;
                cierrecaja.Estado = "CAJA APERTURADA";
                cierrecaja.Diferencia = 0;
                cierrecaja.IdCaja = Convert.ToInt32(lblIdCaja.Text);

                if (funcionCierreCaja.AperturarCaja(cierrecaja) == true)
                {
                    MessageBox.Show("¡Caja Aperturada!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo aperturar la caja");
            }

        }

        private void barLoading_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            
            try
            {
                ManagementObject MOS = new ManagementObject(@"Win32_PhysicalMedia='\\.\PHYSICALDRIVE0'");
                lblSerial.Text = MOS.Properties["SerialNumber"].Value.ToString();
                lblSerial.Text = lblSerial.Text.Trim();
                serial = lblSerial.Text;

                //CapturarSerial();
                Mostrar_IdCaja_Serial();

                lblIdCaja.Text = gridCajas.SelectedCells[0].Value.ToString();
            }
            catch (Exception)
            {
                //MessageBox.Show("No se puede ver el numero de serie");
                //pnlRegistroCaja.Visible = true;
                DialogResult preguntalogin;
                preguntalogin = MessageBox.Show("¿Va a registrar esta PC en el sistema?", "Registrar PC", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preguntalogin == DialogResult.Yes)
                {
                    Dispose();
                    VISTAS.INSTALACION_SERVIDOR.formServidor ser = new VISTAS.INSTALACION_SERVIDOR.formServidor();
                    ser.ShowDialog();
                }
                else
                {
                    MessageBox.Show("PC no autorizada al sistema","Bodega Martinez",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Application.Exit();
                }   
            }

        }
    }
}
