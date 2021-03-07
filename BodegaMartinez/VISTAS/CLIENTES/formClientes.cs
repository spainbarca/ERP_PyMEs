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
//using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Capa_Soporte;
using Capa_Dominio;
using Capa_Persistencia;

namespace BodegaMartinez.CLIENTES
{
    public partial class formClientes : Form
    {
        public formClientes()
        {
            InitializeComponent();
        }

        Cliente cliente = new Cliente();
        ClientesDao funcionCliente = new ClientesDao();

        TipoCliente tipocliente = new TipoCliente();

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void pbxBoton_Click(object sender, EventArgs e)
        {
            pnlRegistroCliente.Visible = true;
            btnModificar.Visible = false;

            pnlTabulacion.Visible = false;
            gridClientes.Visible = false;
            pnlRegistroCliente.Visible = true;
            pnlRegistroCliente.Dock = DockStyle.Fill;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            
            pnlTabulacion.Visible = true;
            gridClientes.Visible = true;
            pnlRegistroCliente.Visible = false;
            gridClientes.Dock = DockStyle.Fill;
        }

        private void maskCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarMascara(e);
        }

        private void maskTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarMascara(e);
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarMascara(e);
        }

        private void LlamarFoto()
        {
            dlgFoto.InitialDirectory = "";
            dlgFoto.Filter = "Imagenes|*.jpg;*.png";
            dlgFoto.FilterIndex = 2;
            dlgFoto.Title = "Cargador de imagenes de usuario";
            if (dlgFoto.ShowDialog() == DialogResult.OK)
            {
                pbxFoto.BackgroundImage = null;
                pbxFoto.Image = new Bitmap(dlgFoto.FileName);
                pbxFoto.SizeMode = PictureBoxSizeMode.Zoom;
                nombreFoto.Text = Path.GetFileName(dlgFoto.FileName);
                lblEligeFoto.Visible = false;
            }
        }

        private void lblEligeFoto_Click(object sender, EventArgs e)
        {
            LlamarFoto();
        }

        private void pbxFoto_Click(object sender, EventArgs e)
        {
            LlamarFoto();
        }

        public void ListarTipo()
        {
            try
            {
                cbxTipo.DataSource = funcionCliente.ListarTipo();
                cbxTipo.DisplayMember = "nombre_tipo";
                cbxTipo.ValueMember = "id_tipo";

            }
            catch (Exception)
            {
                MessageBox.Show("No hay tipos listados", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CrearCliente()
        {
            if (txtFirstNombre.Text!="")
            {
                if (txtApp.Text!="")
                {
                    if (txtApm.Text!="")
                    {
                        if (cbxGenero.SelectedIndex!=0)
                        {
                            if (ValidarCorreo(txtCorreo.Text) == true)
                            {
                                if (txtDireccion.Text!="")
                                {
                                    if (lblEligeFoto.Visible==false)
                                    {
                                        if (maskCelular.MaskCompleted)
                                        {
                                            if (maskTelefono.MaskCompleted)
                                            {
                                                try
                                                {

                                                    MemoryStream ms = new MemoryStream();
                                                    pbxFoto.Image.Save(ms, pbxFoto.Image.RawFormat);
                                                    byte[] imagen = ms.GetBuffer();

                                                    cliente.PrimerNombre = txtFirstNombre.Text;
                                                    cliente.SegundoNombre = txtSecNombre.Text;
                                                    cliente.ApellidoPaterno = txtApp.Text;
                                                    cliente.ApellidoMaterno = txtApm.Text;
                                                    cliente.FechaNacimiento = dateFecha.Value;
                                                    cliente.Genero = cbxGenero.Text;
                                                    cliente.TipoCliente = Convert.ToInt32(cbxTipo.SelectedValue);
                                                    cliente.Correo = txtCorreo.Text;
                                                    cliente.Telefono = maskTelefono.Text;
                                                    cliente.Celular = maskCelular.Text;
                                                    cliente.Direccion = txtDireccion.Text;
                                                    cliente.Dni = maskDni.Text;
                                                    cliente.Alias = txtAlias.Text;
                                                    cliente.Foto = imagen;
                                                    cliente.NombreFoto = nombreFoto.Text;
                                                    cliente.Estado = "ACTIVADO";
                                                    cliente.FechaRegistro = DateTime.Now;

                                                    if (funcionCliente.InsertarCliente(cliente) == true)
                                                    {
                                                        MessageBox.Show("¡Registro exitoso!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        pnlRegistroCliente.Visible = false;
                                                        btnModificar.Visible = true;
                                                        MostrarClientes();
                                                        ColorearCeldas();
                                                        LimpiarCliente();
                                                        ContarClientesActivos();
                                                        ContarClientesEliminados();
                                                        ConteoDataTable();
                                                        ValidarPaginador();
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
                                                MessageBox.Show("Por favor, digite el teléfono correctamente");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Por favor, digite el celular correctamente");
                                        }
                                        
                                    }
                                    else
                                    {
                                        MessageBox.Show("Por favor, seleccione una foto");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por favor, digite su dirección");
                                    txtDireccion.Focus();
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
                            MessageBox.Show("Por favor, Seleccione su género");
                            cbxGenero.SelectedIndex=0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, digite su apellido materno");
                        txtApm.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, digite su apellido paterno");
                    txtApp.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor, digite su nombre");
                txtFirstNombre.Focus();
            }
        }

        private void MostrarClientes()
        {
            try
            {
                DataTable dt = new DataTable();
                ClientesDao.MostrarClientes(ref dt);

                gridClientes.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                gridClientes.Columns[0].Visible = true;
                gridClientes.Columns[1].Visible = true;
                gridClientes.Columns[2].Visible = false;
                gridClientes.Columns[3].Visible = true;
                gridClientes.Columns[4].Visible = false;
                gridClientes.Columns[5].Visible = false;
                gridClientes.Columns[6].Visible = false;
                gridClientes.Columns[7].Visible = false;
                gridClientes.Columns[8].Visible = false;
                gridClientes.Columns[9].Visible = false;
                gridClientes.Columns[10].Visible = true;
                gridClientes.Columns[11].Visible = true;
                gridClientes.Columns[12].Visible = true;
                gridClientes.Columns[13].Visible = true;
                gridClientes.Columns[14].Visible = false;
                gridClientes.Columns[15].Visible = false;
                gridClientes.Columns[16].Visible = false;
                gridClientes.Columns[17].Visible = false;
                gridClientes.Columns[18].Visible = false;
                gridClientes.Columns[19].Visible = true;
                ContarClientesActivos();
                ContarClientesEliminados();
                ConteoDataTable();
                ValidarPaginador();
                txtPagActual.Text = "1";
                btnAnterior.Enabled = false;
                btnSiguiente.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("No se muestran los datos", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Datatables_tamañoAuto.Multilinea(ref gridClientes);
            ColorearCeldas();
        }

        string contacliac;
        private void ContarClientesActivos()
        {
            try
            {
                ClientesDao.ContarClientes(ref contacliac, 1);

                lblclientesActivos.Text = "";
                lblclientesActivos.Text = contacliac;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las categorías");
            }

            ValidarPaginador();
        }

        string contacliel;
        private void ContarClientesEliminados()
        {
            try
            {
                ClientesDao.ContarClientes(ref contacliel, 2);

                lblclientesEliminados.Text = "";
                lblclientesEliminados.Text = contacliel;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las categorías");
            }

            ValidarPaginador();
        }

        private void EditarCliente()
        {
            if (txtFirstNombre.Text != "")
            {
                if (txtApp.Text != "")
                {
                    if (txtApm.Text != "")
                    {
                        if (cbxGenero.SelectedIndex != 0)
                        {
                            if (ValidarCorreo(txtCorreo.Text) == true)
                            {
                                if (txtDireccion.Text != "")
                                {
                                    if (lblEligeFoto.Visible == false)
                                    {
                                        if (maskCelular.MaskCompleted)
                                        {
                                            if (maskTelefono.MaskCompleted)
                                            {
                                                try
                                                {
                                                    MemoryStream ms = new MemoryStream();
                                                    pbxFoto.Image.Save(ms, pbxFoto.Image.RawFormat);
                                                    byte[] imagen = ms.GetBuffer();

                                                    cliente.PrimerNombre = txtFirstNombre.Text;
                                                    cliente.SegundoNombre = txtSecNombre.Text;
                                                    cliente.ApellidoPaterno = txtApp.Text;
                                                    cliente.ApellidoMaterno = txtApm.Text;
                                                    cliente.FechaNacimiento = dateFecha.Value;
                                                    cliente.Genero = cbxGenero.Text;
                                                    cliente.TipoCliente = Convert.ToInt32(cbxTipo.SelectedValue);
                                                    cliente.Correo = txtCorreo.Text;
                                                    cliente.Telefono = maskTelefono.Text;
                                                    cliente.Celular = maskCelular.Text;
                                                    cliente.Direccion = txtDireccion.Text;
                                                    cliente.Dni = maskDni.Text;
                                                    cliente.Alias = txtAlias.Text;
                                                    cliente.Foto = imagen;
                                                    cliente.NombreFoto = nombreFoto.Text;
                                                    cliente.IdCliente = Convert.ToInt32(lblIdCli.Text);

                                                    if (funcionCliente.EditarCliente(cliente) == true)
                                                    {
                                                        MessageBox.Show("¡Registro exitoso!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        pnlRegistroCliente.Visible = false;
                                                        btnModificar.Visible = true;
                                                        MostrarClientes();
                                                        ColorearCeldas();
                                                        LimpiarCliente();
                                                        ContarClientesActivos();
                                                        ContarClientesEliminados();
                                                        ConteoDataTable();
                                                        ValidarPaginador();
                                                    }
                                                }
                                                catch (Exception)
                                                {
                                                    MessageBox.Show("¡Error al Editar!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    //MessageBox.Show(ex.Message);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Por favor, digite el teléfono correctamente");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Por favor, digite el celular correctamente");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Por favor, seleccione una foto");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por favor, digite su dirección");
                                    txtDireccion.Focus();
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
                            MessageBox.Show("Por favor, Seleccione su género");
                            cbxGenero.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, digite su apellido materno");
                        txtApm.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, digite su apellido paterno");
                    txtApp.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor, digite su nombre");
                txtFirstNombre.Focus();
            }
        }

        private void formClientes_Load(object sender, EventArgs e)
        {
            ListarTipo();
            MostrarClientes();
            pnlTabulacion.Visible = true;
            gridClientes.Visible = true;
            gridClientes.Dock = DockStyle.Fill;
            ColorearCeldas();
        }

        public bool ValidarCorreo(String sCorreo) //alguien@dominio.com
        {
            return Regex.IsMatch(sCorreo, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CrearCliente();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            EditarCliente();
        }

        private void SeleccionarCliente()
        {
            gridClientes.Visible = false;
            pnlRegistroCliente.Visible = true;
            pnlTabulacion.Visible = false;
            pnlRegistroCliente.Dock = DockStyle.Fill;

            string estado;
            estado = gridClientes.SelectedCells[18].Value.ToString();

            if (estado=="ACTIVADO")
            {
                lblIdCli.Text = gridClientes.SelectedCells[2].Value.ToString();
                txtFirstNombre.Text = gridClientes.SelectedCells[4].Value.ToString();
                txtSecNombre.Text = gridClientes.SelectedCells[5].Value.ToString();
                txtApp.Text = gridClientes.SelectedCells[6].Value.ToString();
                txtApm.Text = gridClientes.SelectedCells[7].Value.ToString();
                dateFecha.Value = (DateTime)gridClientes.SelectedCells[8].Value;
                cbxGenero.Text = gridClientes.SelectedCells[9].Value.ToString();
                cbxTipo.Text = gridClientes.SelectedCells[10].Value.ToString();
                txtCorreo.Text = gridClientes.SelectedCells[11].Value.ToString();
                maskTelefono.Text = gridClientes.SelectedCells[12].Value.ToString();
                maskCelular.Text = gridClientes.SelectedCells[13].Value.ToString();
                txtDireccion.Text = gridClientes.SelectedCells[14].Value.ToString();
                maskDni.Text = gridClientes.SelectedCells[15].Value.ToString();
                txtAlias.Text = gridClientes.SelectedCells[19].Value.ToString();

                pbxFoto.BackgroundImage = null;
                byte[] b = (Byte[])gridClientes.SelectedCells[16].Value;
                MemoryStream ms = new MemoryStream(b);
                pbxFoto.Image = Image.FromStream(ms);
                lblEligeFoto.Visible = false;
                nombreFoto.Text = gridClientes.SelectedCells[17].Value.ToString();

                btnModificar.Visible = true;
                btnGuardar.Visible = false;

                pnlRegistroCliente.Visible = true;
            }
            else
            {
                RestaurarCliente();
            }
        }

        private void RestaurarCliente()
        {
            DialogResult preguntacli;
            preguntacli = MessageBox.Show("¿Está seguro de restaurar este cliente?", "Restaurar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preguntacli == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow filacli in gridClientes.SelectedRows)
                    {
                        int id = Convert.ToInt32(filacli.Cells["id_cli"].Value);

                        try
                        {
                            cliente.IdCliente = id;
                            if (funcionCliente.RestaurarCliente(cliente) == true)
                            {
                                MostrarClientes();
                                ColorearCeldas();
                                pnlRegistroCliente.Visible = false;
                                LimpiarCliente();
                                ContarClientesActivos();
                                ContarClientesEliminados();
                                ConteoDataTable();
                                ValidarPaginador();
                            }

                            MessageBox.Show("¡Restauración exitosa!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Error al eliminar el cliente");
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void EliminarCliente()
        {
            string estado;
            estado= gridClientes.SelectedCells[18].Value.ToString();

            if (estado=="ACTIVADO")
            {
                DialogResult preguntacli;
                preguntacli = MessageBox.Show("¿Está seguro de eliminar este cliente?", "Eliminar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preguntacli == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow filacli in gridClientes.SelectedRows)
                        {
                            int id = Convert.ToInt32(filacli.Cells["id_cli"].Value);

                            try
                            {
                                cliente.IdCliente = id;
                                if (funcionCliente.EliminarCliente(cliente) == true)
                                {
                                    MostrarClientes();
                                    ColorearCeldas();
                                    pnlRegistroCliente.Visible = false;
                                    LimpiarCliente();
                                    ContarClientesActivos();
                                    ContarClientesEliminados();
                                    ConteoDataTable();
                                    ValidarPaginador();
                                }

                                MessageBox.Show("¡Eliminación exitosa!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error al eliminar el cliente");
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            else
            {
                DialogResult preguntacli;
                preguntacli = MessageBox.Show("¿Está seguro de funar este cliente definitivamente?", "Eyectar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preguntacli == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow filacli in gridClientes.SelectedRows)
                        {
                            int id = Convert.ToInt32(filacli.Cells["id_cli"].Value);

                            try
                            {
                                cliente.IdCliente = id;
                                if (funcionCliente.FunarCliente(cliente) == true)
                                {
                                    MostrarClientes();
                                    ColorearCeldas();
                                    pnlRegistroCliente.Visible = false;
                                    LimpiarCliente();
                                    ContarClientesActivos();
                                    ContarClientesEliminados();
                                    ConteoDataTable();
                                    ValidarPaginador();
                                }

                                MessageBox.Show("¡Funación exitosa!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error al eliminar el cliente");
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void ColorearCeldas()
        {
            foreach (DataGridViewRow row in gridClientes.Rows)
            {
                if (row.Cells["estado"].Value.ToString() == "ELIMINADO")
                {
                    row.DefaultCellStyle.Font = new Font("Berlin Sans FB Demi",12,FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void gridClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.gridClientes.Columns["EdiCli"].Index)
            {
                SeleccionarCliente();
            }

            if (e.ColumnIndex == this.gridClientes.Columns["EliCli"].Index)
            {
                EliminarCliente();
            }
        }

        private void BuscarClientes()
        {
            if (txtBusqueda.Text!="")
            {
                try
                {
                    DataTable dt = new DataTable();
                    ClientesDao.BuscarClientes(ref dt, txtBusqueda.Text);
                    gridClientes.DataSource = dt;

                    gridClientes.Columns[0].Visible = true;
                    gridClientes.Columns[1].Visible = true;
                    gridClientes.Columns[2].Visible = false;
                    gridClientes.Columns[3].Visible = true;
                    gridClientes.Columns[4].Visible = false;
                    gridClientes.Columns[5].Visible = false;
                    gridClientes.Columns[6].Visible = false;
                    gridClientes.Columns[7].Visible = false;
                    gridClientes.Columns[8].Visible = false;
                    gridClientes.Columns[9].Visible = false;
                    gridClientes.Columns[10].Visible = true;
                    gridClientes.Columns[11].Visible = true;
                    gridClientes.Columns[12].Visible = true;
                    gridClientes.Columns[13].Visible = true;
                    gridClientes.Columns[14].Visible = false;
                    gridClientes.Columns[15].Visible = false;
                    gridClientes.Columns[16].Visible = false;
                    gridClientes.Columns[17].Visible = false;
                    gridClientes.Columns[18].Visible = false;
                    gridClientes.Columns[19].Visible = true;
                    ColorearCeldas();
                }
                catch (Exception)
                {
                }
                Datatables_tamañoAuto.Multilinea(ref gridClientes);

                pnlTabulacion.Enabled = false;
            }
            else
            {
                MostrarClientes();
                pnlTabulacion.Enabled = true;
            }
            
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            BuscarClientes();
        }

        private void txtFirstNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtApp_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtSecNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void txtApm_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloLetras(e);
        }

        private void LimpiarCliente()
        {
            txtFirstNombre.Clear();
            txtSecNombre.Clear();
            txtApp.Clear();
            txtApm.Clear();
            dateFecha.Value = DateTime.Now;
            cbxGenero.SelectedIndex = 0;
            cbxTipo.SelectedIndex = 0;
            txtCorreo.Clear();
            txtDireccion.Clear();
            maskCelular.Clear();
            maskTelefono.Clear();
            maskDni.Clear();
            pbxFoto.BackgroundImage = null;
            lblEligeFoto.Visible = true;
            txtFirstNombre.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCliente();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void PaginarClientes(int pagina)
        {
            try
            {
                DataTable dt = new DataTable();
                ClientesDao.TabularClientes(ref dt, pagina);

                gridClientes.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                gridClientes.Columns[0].Visible = true;
                gridClientes.Columns[1].Visible = true;
                gridClientes.Columns[2].Visible = false;
                gridClientes.Columns[3].Visible = true;
                gridClientes.Columns[4].Visible = false;
                gridClientes.Columns[5].Visible = false;
                gridClientes.Columns[6].Visible = false;
                gridClientes.Columns[7].Visible = false;
                gridClientes.Columns[8].Visible = false;
                gridClientes.Columns[9].Visible = false;
                gridClientes.Columns[10].Visible = true;
                gridClientes.Columns[11].Visible = true;
                gridClientes.Columns[12].Visible = true;
                gridClientes.Columns[13].Visible = true;
                gridClientes.Columns[14].Visible = false;
                gridClientes.Columns[15].Visible = false;
                gridClientes.Columns[16].Visible = false;
                gridClientes.Columns[17].Visible = false;
                gridClientes.Columns[18].Visible = false;
                gridClientes.Columns[19].Visible = true;
                ColorearCeldas();
            }
            catch (Exception)
            {
                MessageBox.Show("No se muestran los datos", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            MostrarClientes();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual - 2) * 15;

            PaginarClientes(pagina);

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

            PaginarClientes(pagina);

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

            PaginarClientes(pagina);

            txtPagActual.Text = lblTotalPag.Text;

            btnSiguiente.Enabled = false;
            btnAnterior.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaActual.Text = DateTime.Today.ToShortDateString();
            lblHoraActual.Text = DateTime.Now.ToLongTimeString();
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
            decimal acti;
            decimal elimi;
            acti = Convert.ToDecimal(lblclientesActivos.Text);
            elimi = Convert.ToDecimal(lblclientesEliminados.Text);
            totalpaginas = Math.Ceiling((acti + elimi) / 15);
            lblTotalPag.Text = totalpaginas.ToString();
        }

        private void txtAlias_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloAlfanumericos(e);
        }
    }
}
