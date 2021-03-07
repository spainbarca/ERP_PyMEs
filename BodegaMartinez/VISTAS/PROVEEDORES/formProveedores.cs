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

namespace BodegaMartinez.VISTAS.PROVEEDORES
{
    public partial class formProveedores : Form
    {
        public formProveedores()
        {
            InitializeComponent();
        }

        Proveedor proveedor = new Proveedor();
        ProveedoresDao funcionProveedor = new ProveedoresDao();

        private void CrearProveedor()
        {
            if (txtDistribuidora.Text!="")
            {
                if (txtDireccion.Text!="")
                {
                    if (txtAnexo.Text!="")
                    {
                        if (cbxDepartamento.SelectedIndex!=0)
                        {
                            if (cbxProvincia.SelectedIndex!=0)
                            {
                                if (cbxDistrito.SelectedIndex!=0)
                                {
                                    if (cbxRubro.SelectedIndex!=0)
                                    {
                                        if (maskCelular.MaskCompleted)
                                        {
                                            if (maskTelefono.MaskCompleted)
                                            {
                                                if (maskRuc.MaskCompleted)
                                                {
                                                    try
                                                    {
                                                        MemoryStream ms = new MemoryStream();
                                                        pbxProv.Image.Save(ms, pbxProv.Image.RawFormat);
                                                        byte[] imagen = ms.GetBuffer();

                                                        proveedor.NombreProveedor = txtDistribuidora.Text;
                                                        proveedor.Logo = imagen;
                                                        proveedor.NombreLogo = dlgProveedor.FileName;
                                                        proveedor.Direccion = txtDireccion.Text;
                                                        proveedor.Anexo = txtAnexo.Text;
                                                        proveedor.Departamento = cbxDepartamento.SelectedValue.ToString();
                                                        proveedor.Provincia = cbxProvincia.SelectedValue.ToString();
                                                        proveedor.Distrito = cbxDistrito.SelectedValue.ToString();
                                                        proveedor.Rubro = cbxRubro.Text;
                                                        proveedor.Celular = maskCelular.Text;
                                                        proveedor.Telefono = maskTelefono.Text;
                                                        proveedor.Ruc = maskRuc.Text;
                                                        proveedor.Vendedor = txtVendedor.Text;
                                                        proveedor.Estado = "ACTIVADO";
                                                        proveedor.FechaRegistro = DateTime.Now;

                                                        if (funcionProveedor.InsertarProveedor(proveedor) == true)
                                                        {
                                                            MessageBox.Show("¡Registro exitoso!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            pnlRegistroProveedor.Visible = false;
                                                            btnModificar.Visible = true;
                                                            gridProveedores.Visible = true;
                                                            gridProveedores.Dock = DockStyle.Fill;
                                                            MostrarProveedores();
                                                            ColorearCeldas();
                                                            LimpiarProveedor();
                                                            ContarProveedoresActivos();
                                                            ContarProveedoresEliminados();
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
                                                    MessageBox.Show("El número de RUC está erróneo, ¡Complete los datos", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    maskRuc.Focus();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("El teléfono está erróneo, ¡Complete los datos", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                maskTelefono.Focus();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El celular está erróneo, ¡Complete los datos", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            maskCelular.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione un rubro", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        cbxRubro.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Seleccione un distrito", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    cbxDistrito.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione una provincia", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cbxProvincia.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un departamento", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cbxDepartamento.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El anexo está vacío, ¡Digítelo", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAnexo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("La dirección está vacía, ¡Digítela", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccion.Focus();
                }
            }
            else
            {
                MessageBox.Show("El nombre está vacío, ¡Digítelo", "Bodega Martínez",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtDistribuidora.Focus();
            }
        }

        private void MostrarProveedores()
        {
            try
            {
                DataTable dt = new DataTable();
                ProveedoresDao.MostrarProveedores(ref dt);

                gridProveedores.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                //gridProveedores.Columns[0].Visible = true;
                //gridProveedores.Columns[1].Visible = true;
                gridProveedores.Columns[2].Visible = false;
                gridProveedores.Columns[3].Visible = true;
                gridProveedores.Columns[4].Visible = false;
                gridProveedores.Columns[5].Visible = false;
                gridProveedores.Columns[6].Visible = true;
                gridProveedores.Columns[7].Visible = false;
                gridProveedores.Columns[8].Visible = false;
                gridProveedores.Columns[9].Visible = false;
                gridProveedores.Columns[10].Visible = false;
                gridProveedores.Columns[11].Visible = true;
                gridProveedores.Columns[12].Visible = true;
                gridProveedores.Columns[13].Visible = true;
                gridProveedores.Columns[14].Visible = true;
                gridProveedores.Columns[15].Visible = false;
                gridProveedores.Columns[16].Visible = false;
                gridProveedores.Columns[17].Visible = false;
                ContarProveedoresActivos();
                ContarProveedoresEliminados();
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
            Datatables_tamañoAuto.Multilinea(ref gridProveedores);
            ColorearCeldas();
        }

        private void EditarProveedor()
        {
            if (txtDistribuidora.Text != "")
            {
                if (txtDireccion.Text != "")
                {
                    if (txtAnexo.Text != "")
                    {
                        if (cbxDepartamento.SelectedIndex != 0)
                        {
                            if (cbxProvincia.SelectedIndex != 0)
                            {
                                if (cbxDistrito.SelectedIndex != 0)
                                {
                                    if (cbxRubro.SelectedIndex != 0)
                                    {
                                        if (maskCelular.MaskCompleted)
                                        {
                                            if (maskTelefono.MaskCompleted)
                                            {
                                                if (maskRuc.MaskCompleted)
                                                {
                                                    try
                                                    {
                                                        MemoryStream ms = new MemoryStream();
                                                        pbxProv.Image.Save(ms, pbxProv.Image.RawFormat);
                                                        byte[] imagen = ms.GetBuffer();

                                                        proveedor.NombreProveedor = txtDistribuidora.Text;
                                                        proveedor.Logo = imagen;
                                                        proveedor.NombreLogo = dlgProveedor.FileName;
                                                        proveedor.Direccion = txtDireccion.Text;
                                                        proveedor.Anexo = txtAnexo.Text;
                                                        proveedor.Departamento = cbxDepartamento.SelectedValue.ToString();
                                                        proveedor.Provincia = cbxProvincia.SelectedValue.ToString();
                                                        proveedor.Distrito = cbxDistrito.SelectedValue.ToString();
                                                        proveedor.Rubro = cbxRubro.Text;
                                                        proveedor.Celular = maskCelular.Text;
                                                        proveedor.Telefono = maskTelefono.Text;
                                                        proveedor.Ruc = maskRuc.Text;
                                                        proveedor.Vendedor = txtVendedor.Text;
                                                        proveedor.IdProveedor = Convert.ToInt32(lblIdProv.Text);

                                                        if (funcionProveedor.EditarProveedor(proveedor) == true)
                                                        {
                                                            MessageBox.Show("¡Edición exitosa!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                            pnlRegistroProveedor.Visible = false;
                                                            btnModificar.Visible = true;
                                                            MostrarProveedores();
                                                            ColorearCeldas();
                                                            LimpiarProveedor();
                                                            ContarProveedoresActivos();
                                                            ContarProveedoresEliminados();
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
                                                    MessageBox.Show("El número de RUC está erróneo, ¡Complete los datos", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    maskRuc.Focus();
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("El teléfono está erróneo, ¡Complete los datos", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                maskTelefono.Focus();
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("El celular está erróneo, ¡Complete los datos", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            maskCelular.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Seleccione un rubro", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        cbxRubro.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Seleccione un distrito", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    cbxDistrito.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Seleccione una provincia", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                cbxProvincia.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un departamento", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cbxDepartamento.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("El anexo está vacío, ¡Digítelo", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAnexo.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("La dirección está vacía, ¡Digítela", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccion.Focus();
                }
            }
            else
            {
                MessageBox.Show("El nombre está vacío, ¡Digítelo", "Bodega Martínez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDistribuidora.Focus();
            }
        }

        private void SeleccionarProveedor()
        {
            gridProveedores.Visible = false;
            pnlRegistroProveedor.Visible = true;
            pnlTabulacion.Visible = false;
            pnlRegistroProveedor.Dock = DockStyle.Fill;

            string estado;
            estado = gridProveedores.SelectedCells[17].Value.ToString();

            if (estado == "ACTIVADO")
            {
                lblIdProv.Text = gridProveedores.SelectedCells[2].Value.ToString();
                txtDistribuidora.Text = gridProveedores.SelectedCells[3].Value.ToString();
                txtDireccion.Text = gridProveedores.SelectedCells[6].Value.ToString();
                txtAnexo.Text = gridProveedores.SelectedCells[7].Value.ToString();
                cbxDepartamento.Text = gridProveedores.SelectedCells[8].Value.ToString();
                cbxProvincia.Text = gridProveedores.SelectedCells[9].Value.ToString();
                cbxDistrito.Text = gridProveedores.SelectedCells[10].Value.ToString();
                cbxRubro.Text = gridProveedores.SelectedCells[12].Value.ToString();
                maskCelular.Text = gridProveedores.SelectedCells[13].Value.ToString();
                maskTelefono.Text = gridProveedores.SelectedCells[14].Value.ToString();
                maskRuc.Text = gridProveedores.SelectedCells[15].Value.ToString();
                txtVendedor.Text = gridProveedores.SelectedCells[16].Value.ToString();

                pbxProv.BackgroundImage = null;
                byte[] b = (Byte[])gridProveedores.SelectedCells[4].Value;
                MemoryStream ms = new MemoryStream(b);
                pbxProv.Image = Image.FromStream(ms);
                nombreFoto.Text = gridProveedores.SelectedCells[5].Value.ToString();

                btnModificar.Visible = true;
                btnGuardar.Visible = false;

                pnlRegistroProveedor.Visible = true;
            }
            else
            {
                RestaurarProveedor();
            }
        }

        private void RestaurarProveedor()
        {
            DialogResult preguntaprov;
            preguntaprov = MessageBox.Show("¿Está seguro de restaurar este proveedor?", "Bodega Martínez", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (preguntaprov == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow filaprov in gridProveedores.SelectedRows)
                    {
                        int id = Convert.ToInt32(filaprov.Cells["Id"].Value);

                        try
                        {
                            proveedor.IdProveedor = id;
                            if (funcionProveedor.RestaurarProveedor(proveedor) == true)
                            {
                                MostrarProveedores();
                                ColorearCeldas();
                                pnlRegistroProveedor.Visible = false;
                                LimpiarProveedor();
                                ContarProveedoresActivos();
                                ContarProveedoresEliminados();
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

        private void EliminarProveedor()
        {
            string estado;
            estado = gridProveedores.SelectedCells[17].Value.ToString();

            if (estado == "ACTIVADO")
            {
                DialogResult preguntaprov;
                preguntaprov = MessageBox.Show("¿Está seguro de eliminar este proveedor?", "Bodega Martínez", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (preguntaprov == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow filaprov in gridProveedores.SelectedRows)
                        {
                            int id = Convert.ToInt32(filaprov.Cells["Id"].Value);

                            try
                            {
                                proveedor.IdProveedor = id;
                                if (funcionProveedor.EliminarProveedor(proveedor) == true)
                                {
                                    MostrarProveedores();
                                    ColorearCeldas();
                                    pnlRegistroProveedor.Visible = false;
                                    LimpiarProveedor();
                                    ContarProveedoresActivos();
                                    ContarProveedoresEliminados();
                                    ConteoDataTable();
                                    ValidarPaginador();
                                }

                                MessageBox.Show("¡Eliminación exitosa!", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error al eliminar el proveedor");
                            }
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        string contaprovac;
        private void ContarProveedoresActivos()
        {
            try
            {
                ProveedoresDao.ContarProveedores(ref contaprovac, 1);

                lblclientesActivos.Text = "";
                lblclientesActivos.Text = contaprovac;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las categorías");
            }

            ValidarPaginador();
        }

        string contaprovel;
        private void ContarProveedoresEliminados()
        {
            try
            {
                ProveedoresDao.ContarProveedores(ref contaprovel, 2);

                lblclientesEliminados.Text = "";
                lblclientesEliminados.Text = contaprovel;
            }
            catch (Exception)
            {
                MessageBox.Show("No se cuentan las categorías");
            }

            ValidarPaginador();
        }

        private void ColorearCeldas()
        {
            foreach (DataGridViewRow row in gridProveedores.Rows)
            {
                if (row.Cells["estado"].Value.ToString() == "ELIMINADO")
                {
                    row.DefaultCellStyle.Font = new Font("Berlin Sans FB Demi", 12, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }

        private void LlamarLogo()
        {
            dlgProveedor.InitialDirectory = "";
            dlgProveedor.Filter = "Imagenes|*.jpg;*.png";
            dlgProveedor.FilterIndex = 2;
            dlgProveedor.Title = "Bodega Martínez";
            if (dlgProveedor.ShowDialog() == DialogResult.OK)
            {
                pbxProv.BackgroundImage = null;
                pbxProv.Image = new Bitmap(dlgProveedor.FileName);
                pbxProv.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }


        public void ListarDepartamentos()
        {
            try
            {
                cbxDepartamento.DisplayMember = "nombre_departamento";
                cbxDepartamento.ValueMember = "id_departamento";
                cbxDepartamento.DataSource = funcionProveedor.ListarDepartamentos();
            }
            catch (Exception)
            {
                MessageBox.Show("No hay departamentos listados", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        string id_dep;
        public void ListarProvincias()
        {
            id_dep = cbxDepartamento.SelectedValue.ToString();

            try
            {
                cbxProvincia.DataSource = funcionProveedor.ListarProvincias(id_dep);
                cbxProvincia.DisplayMember = "nombre_provincia";
                cbxProvincia.ValueMember = "id_provincia";
            }
            catch (Exception)
            {
                MessageBox.Show("No hay provincias listadas", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        string id_prov;
        public void ListarDistritos()
        {
            id_prov = cbxProvincia.SelectedValue.ToString();

            try
            {
                cbxDistrito.DataSource = funcionProveedor.ListarDistritos(id_dep, id_prov);
                cbxDistrito.DisplayMember = "nombre_distrito";
                cbxDistrito.ValueMember = "id_distrito";
            }
            catch (Exception)
            {
                MessageBox.Show("No hay provincias listadas", "Bodega Martinez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void BuscarProveedores()
        {
            if (txtBusqueda.Text!="")
            {
                try
                {
                    DataTable dt = new DataTable();
                    ProveedoresDao.BuscarProveedores(ref dt, txtBusqueda.Text);
                    gridProveedores.DataSource = dt;

                    //Nombretabla+Columns[n]+.Visible=true/false
                    //gridProveedores.Columns[0].Visible = true;
                    //gridProveedores.Columns[1].Visible = true;
                    gridProveedores.Columns[2].Visible = false;
                    gridProveedores.Columns[3].Visible = true;
                    gridProveedores.Columns[4].Visible = false;
                    gridProveedores.Columns[5].Visible = false;
                    gridProveedores.Columns[6].Visible = true;
                    gridProveedores.Columns[7].Visible = false;
                    gridProveedores.Columns[8].Visible = false;
                    gridProveedores.Columns[9].Visible = false;
                    gridProveedores.Columns[10].Visible = false;
                    gridProveedores.Columns[11].Visible = true;
                    gridProveedores.Columns[12].Visible = true;
                    gridProveedores.Columns[13].Visible = true;
                    gridProveedores.Columns[14].Visible = true;
                    gridProveedores.Columns[15].Visible = false;
                    gridProveedores.Columns[16].Visible = false;
                    gridProveedores.Columns[17].Visible = false;
                    ColorearCeldas();
                }
                catch (Exception)
                {
                }
                Datatables_tamañoAuto.Multilinea(ref gridProveedores);
                pnlTabulacion.Enabled = false;
            }
            else
            {
                MostrarProveedores();
                pnlTabulacion.Enabled = true;
            }
        }

        private void LimpiarProveedor()
        {
            txtDistribuidora.Clear();
            txtDireccion.Clear();
            txtAnexo.Clear();
            cbxDepartamento.SelectedIndex = 0;
            cbxProvincia.SelectedIndex = 0;
            cbxDistrito.SelectedIndex = 0;
            cbxRubro.SelectedIndex = 0;
            txtVendedor.Text = "";
            maskCelular.Clear();
            maskTelefono.Clear();
            maskRuc.Clear();
            txtDistribuidora.Focus();
        }

        private void PaginarProveedores(int pagina)
        {
            try
            {
                DataTable dt = new DataTable();
                ProveedoresDao.TabularProveedores(ref dt, pagina);
                gridProveedores.DataSource = dt;

                //Nombretabla+Columns[n]+.Visible=true/false
                //gridProveedores.Columns[0].Visible = true;
                //gridProveedores.Columns[1].Visible = true;
                gridProveedores.Columns[2].Visible = false;
                gridProveedores.Columns[3].Visible = true;
                gridProveedores.Columns[4].Visible = false;
                gridProveedores.Columns[5].Visible = false;
                gridProveedores.Columns[6].Visible = true;
                gridProveedores.Columns[7].Visible = false;
                gridProveedores.Columns[8].Visible = false;
                gridProveedores.Columns[9].Visible = false;
                gridProveedores.Columns[10].Visible = false;
                gridProveedores.Columns[11].Visible = true;
                gridProveedores.Columns[12].Visible = true;
                gridProveedores.Columns[13].Visible = true;
                gridProveedores.Columns[14].Visible = true;
                gridProveedores.Columns[15].Visible = false;
                gridProveedores.Columns[16].Visible = false;
                gridProveedores.Columns[17].Visible = false;
                ColorearCeldas();
            }
            catch (Exception)
            {
            }
            Datatables_tamañoAuto.Multilinea(ref gridProveedores);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void maskCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarMascara(e);
        }

        private void maskTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarMascara(e);
        }

        private void maskRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarMascara(e);
        }

        private void lblProv_Click(object sender, EventArgs e)
        {
            LlamarLogo();
        }

        private void uI_ButtonMaterial2_Click(object sender, EventArgs e)
        {

        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            MostrarProveedores();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            int paginaactual = Convert.ToInt32(txtPagActual.Text);
            int pagina = (paginaactual - 2) * 15;

            PaginarProveedores(pagina);

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

            PaginarProveedores(pagina);

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

            PaginarProveedores(pagina);

            txtPagActual.Text = lblTotalPag.Text;

            btnSiguiente.Enabled = false;
            btnAnterior.Enabled = true;
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

        private void formProveedores_Load(object sender, EventArgs e)
        {
            ListarDepartamentos();
            MostrarProveedores();
            pnlTabulacion.Visible = true;
            gridProveedores.Visible = true;
            gridProveedores.Dock = DockStyle.Fill;
            ColorearCeldas();
            pnlRegistroProveedor.Visible = false;
        }

        private void cbxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxDepartamento.SelectedIndex != 0)
            {
                ListarProvincias();
                cbxProvincia.Enabled = true;
            }
            else
            {
                cbxProvincia.Enabled = false;
                cbxDistrito.Enabled = false;
            }
        }

        private void cbxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProvincia.SelectedIndex != 0)
            {
                ListarDistritos();
                cbxDistrito.Enabled = true;
            }
            else
            {
                cbxDistrito.Enabled = false;
            }
        }

        private void gridProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.gridProveedores.Columns["EdiProv"].Index)
            {
                SeleccionarProveedor();
            }

            if (e.ColumnIndex == this.gridProveedores.Columns["EliProv"].Index)
            {
                EliminarProveedor();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblFechaActual.Text = DateTime.Today.ToShortDateString();
            lblHoraActual.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnNuevoProv_Click(object sender, EventArgs e)
        {
            pnlRegistroProveedor.Visible = true;
            btnModificar.Visible = false;

            pnlTabulacion.Visible = false;
            gridProveedores.Visible = false;
            pnlRegistroProveedor.Visible = true;
            pnlRegistroProveedor.Dock = DockStyle.Fill;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlTabulacion.Visible = true;
            gridProveedores.Visible = true;
            pnlRegistroProveedor.Visible = false;
            gridProveedores.Dock = DockStyle.Fill;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarProveedor();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            EditarProveedor();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            CrearProveedor();
        }

        private void txtVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            new ValidacionCampos().ValidarSoloAlfanumericos(e);
        }
    }
}
