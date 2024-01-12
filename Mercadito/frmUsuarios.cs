using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Utilidades;
using CapaEntidad;
using CapaNegocio;

namespace MercadoDonTino
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cboEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            cboEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "No Activo" });
            cboEstado.DisplayMember = "Texto";
            cboEstado.ValueMember = "Valor";
            cboEstado.SelectedIndex = 0;

           // Generar el combo box Rol
            
            List<Rol> ListaRol = new CN_Rol().listar();

            foreach (Rol item in ListaRol)
            {
                cboRol.Items.Add(new OpcionCombo() { Valor = item.Id_Rol, Texto = item.descripcion_rol });

            }
            cboRol.DisplayMember = "Texto";
            cboRol.ValueMember = "Valor";
            cboRol.SelectedIndex = 0;

            //Generar el combobox Cargo

            List<Cargo> listaCargo = new CN_Cargo().listar();

            foreach (Cargo item in listaCargo )
            {
                cboCargo.Items.Add(new OpcionCombo() { Valor = item.Id_Cargo, Texto = item.nombre_Cargo });

            }
            cboCargo.DisplayMember = "Texto";
            cboCargo.ValueMember = "Valor";
            cboCargo.SelectedIndex = 0;

            // Mostrar Todos los Usuarios

            List<Usuario> ListaUsuario = new CN_Usuario().listar();

            foreach (Usuario item in ListaUsuario)
            {
                dgvData.Rows.Add(new object[] {"", item.Id_Usuario, item.oEmpleado.Id_empleado, item.oEmpleado.oPersona.nombre, item.oEmpleado.oPersona.apellido,
                    item.oEmpleado.oPersona.correo,
                    item.oEmpleado.oPersona.Telefono,
                    item.oEmpleado.oPersona.ciudad_Origen,
                    item.oEmpleado.sucursal_no,
                    item.oEmpleado.oCargo.nombre_Cargo,
                    item.oEmpleado.oCargo.Id_Cargo,
                    item.nombre_Usuario,
                    item.clave,
                    item.oRol.descripcion_rol,
                    item.estado == true ? "Activo" : "No Activo",
                    item.estado == true ? 1 : 0,
                    item.oRol.Id_Rol

            });

            }
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {

            String Mensaje = String.Empty;

            /*da error*/




            if (txtFrmUsuariosPassword.Text == txtFrmUsuariosConfirmPassword.Text)
                {

                Persona objPersona = new Persona()
                {
                    Id_Persona = (Convert.ToInt32(txtNumeroDocumento.Text)),
                    nombre = txtNombre.Text,
                    apellido = txtApellido.Text,
                    correo = txtCorreo.Text,
                    Telefono = txtTelefono.Text,
                    ciudad_Origen = txtCiudadOrigen.Text,

                };

                Empleado objEmpleado = new Empleado()
                {
                    Id_empleado = (Convert.ToInt32(txtNumeroDocumento.Text)),
                    oPersona = new Persona() { Id_Persona = Convert.ToInt32(txtNumeroDocumento.Text), nombre = txtNombre.Text, apellido = txtApellido.Text, correo = txtCorreo.Text, Telefono = txtTelefono.Text, ciudad_Origen = txtCiudadOrigen.Text },
                    oCargo = new Cargo() { Id_Cargo = Convert.ToInt32(((OpcionCombo)cboCargo.SelectedItem).Valor) },
                    sucursal_no = Convert.ToInt32(txtNumeroSucursal.Text)


                };

                Usuario objUsuario = new Usuario()
                {
                    Id_Usuario = Convert.ToInt32(txtId.Text),
                    oRol = new Rol() { Id_Rol = Convert.ToInt32(((OpcionCombo)cboRol.SelectedItem).Valor) },
                    oEmpleado = new Empleado() { Id_empleado = Convert.ToInt32(txtNumeroDocumento.Text) },
                    nombre_Usuario = txtNombreUsuario.Text,
                    clave = txtFrmUsuariosPassword.Text,
                    estado = Convert.ToInt32(((OpcionCombo)cboEstado.SelectedItem).Valor) == 1 ? true : false
                };



                if (objUsuario.Id_Usuario == 0)
                {

                    int idUsuarioGenerado = new CN_Usuario().Registrar(objUsuario, objEmpleado, objPersona, out Mensaje);

                    if (idUsuarioGenerado != 0)
                    {

                        dgvData.Rows.Add(new object[] {"",txtNumeroDocumento.Text,idUsuarioGenerado,txtNombre.Text,txtApellido.Text,txtCorreo.Text,txtTelefono.Text,txtCiudadOrigen.Text,
                        txtNumeroSucursal.Text,
                        ((OpcionCombo)cboCargo.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cboCargo.SelectedItem).Valor.ToString(),
                        txtNombreUsuario.Text,
                        txtFrmUsuariosPassword.Text,
                        ((OpcionCombo)cboRol.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString(),
                        ((OpcionCombo)cboRol.SelectedItem).Valor.ToString()
                        });

                        Limpiar();

                    }
                    else
                    {
                        MessageBox.Show(Mensaje);
                    }

                }
                else
                {
                    bool resultado = new CN_Usuario().Editar(objUsuario, objEmpleado, objPersona, out Mensaje);

                    if (resultado)
                    {
                        DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                        row.Cells["Id_Usuario"].Value = txtId.Text;
                        row.Cells["Documento"].Value = txtNumeroDocumento.Text;
                        row.Cells["Nombre"].Value = txtNombre.Text;
                        row.Cells["Apellido"].Value = txtApellido.Text;
                        row.Cells["Correo"].Value = txtCorreo.Text;
                        row.Cells["Telefono"].Value = txtTelefono.Text;
                        row.Cells["CiudadOrigen"].Value = txtCiudadOrigen.Text;
                        row.Cells["NumeroSucursal"].Value = txtNumeroSucursal.Text;
                        row.Cells["Cargo"].Value = ((OpcionCombo)cboCargo.SelectedItem).Texto.ToString();
                        row.Cells["nombre_Usuario"].Value = txtNombreUsuario.Text;
                        row.Cells["clave"].Value = txtFrmUsuariosPassword.Text;
                        row.Cells["IdRol"].Value = ((OpcionCombo)cboRol.SelectedItem).Valor.ToString();
                        row.Cells["rol_Id"].Value = ((OpcionCombo)cboRol.SelectedItem).Texto.ToString();
                        row.Cells["EstadoValor"].Value = ((OpcionCombo)cboEstado.SelectedItem).Valor.ToString();
                        row.Cells["estado"].Value = ((OpcionCombo)cboEstado.SelectedItem).Texto.ToString();

                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show(Mensaje);
                    }

                }

            }
            else 
                {
                    MessageBox.Show("La contraseña no coincide porfavor intentelo de nuevo", "Mensaje", MessageBoxButtons.OK);
                    txtFrmUsuariosPassword.Text = "";
                    txtFrmUsuariosConfirmPassword.Text = "";
                }

        }

        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtNumeroDocumento.Text = "";
            txtId.Text = "0";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtNumeroSucursal.Text = "";
            txtCiudadOrigen.Text = "";
            cboCargo.SelectedIndex = 0;
            txtNombreUsuario.Text = "";
            txtFrmUsuariosPassword.Text = "";
            txtFrmUsuariosConfirmPassword.Text = "";
            cboRol.SelectedIndex = 0;
            cboEstado.SelectedIndex = 0;

            txtNumeroDocumento.Select();

        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvData.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {

                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtId.Text = dgvData.Rows[indice].Cells["Id_Usuario"].Value.ToString();
                    txtNumeroDocumento.Text = dgvData.Rows[indice].Cells["Documento"].Value.ToString();
                    txtNombre.Text = dgvData.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtApellido.Text = dgvData.Rows[indice].Cells["Apellido"].Value.ToString();
                    txtCorreo.Text = dgvData.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgvData.Rows[indice].Cells["Telefono"].Value.ToString();
                    txtCiudadOrigen.Text = dgvData.Rows[indice].Cells["CiudadOrigen"].Value.ToString();
                    txtNumeroSucursal.Text = dgvData.Rows[indice].Cells["NumeroSucursal"].Value.ToString();
                    txtNombreUsuario.Text = dgvData.Rows[indice].Cells["nombre_Usuario"].Value.ToString();
                    txtFrmUsuariosPassword.Text = dgvData.Rows[indice].Cells["clave"].Value.ToString();
                    txtFrmUsuariosConfirmPassword.Text = dgvData.Rows[indice].Cells["clave"].Value.ToString();

                    foreach (OpcionCombo oc in cboRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["IdRol"].Value))
                        {
                            int indice_combo = cboRol.Items.IndexOf(oc);
                            cboRol.SelectedIndex = indice_combo;
                            break;
                        }
                    }


                    foreach (OpcionCombo oc in cboEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboEstado.Items.IndexOf(oc);
                            cboEstado.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in cboCargo.Items) 
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvData.Rows[indice].Cells["cargoValor"].Value))
                        {
                            int indice_combo = cboCargo.Items.IndexOf(oc);
                            cboCargo.SelectedIndex = indice_combo;
                            break;
                        }

                    }


                }


            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String Mensaje = String.Empty;

            Persona objPersona = new Persona()
            {
                Id_Persona = (Convert.ToInt32(txtNumeroDocumento.Text)),
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                ciudad_Origen = txtCiudadOrigen.Text,
            };

            Empleado objEmpleado = new Empleado()
            {
                Id_empleado = (Convert.ToInt32(txtNumeroDocumento.Text)),
                oPersona = new Persona() { Id_Persona = Convert.ToInt32(txtNumeroDocumento.Text), nombre = txtNombre.Text, apellido = txtApellido.Text, correo = txtCorreo.Text, Telefono = txtTelefono.Text, ciudad_Origen = txtCiudadOrigen.Text },
                oCargo = new Cargo() { Id_Cargo = Convert.ToInt32(((OpcionCombo)cboCargo.SelectedItem).Valor) },
                sucursal_no = Convert.ToInt32(txtNumeroSucursal.Text)

            };

            Usuario objUsuario = new Usuario()
            {
                Id_Usuario = Convert.ToInt32(txtId.Text),
                oRol = new Rol() { Id_Rol = Convert.ToInt32(((OpcionCombo)cboRol.SelectedItem).Valor) },
                oEmpleado = new Empleado() { Id_empleado = Convert.ToInt32(txtNumeroDocumento.Text) },
                nombre_Usuario = txtNombreUsuario.Text,
                clave = txtFrmUsuariosPassword.Text,
                estado = false

            };





            if (objUsuario.Id_Usuario != 0)
            {
                bool resultado = new CN_Usuario().Editar(objUsuario, objEmpleado, objPersona, out Mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgvData.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id_Usuario"].Value = txtId.Text;
                    row.Cells["Documento"].Value = txtNumeroDocumento.Text;
                    row.Cells["Nombre"].Value = txtNombre.Text;
                    row.Cells["Apellido"].Value = txtApellido.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
                    row.Cells["CiudadOrigen"].Value = txtCiudadOrigen.Text;
                    row.Cells["NumeroSucursal"].Value = txtNumeroSucursal.Text;
                    row.Cells["Cargo"].Value = ((OpcionCombo)cboCargo.SelectedItem).Texto.ToString();
                    row.Cells["nombre_Usuario"].Value = txtNombreUsuario.Text;
                    row.Cells["clave"].Value = txtFrmUsuariosPassword.Text;
                    row.Cells["IdRol"].Value = ((OpcionCombo)cboRol.SelectedItem).Valor.ToString();
                    row.Cells["rol_Id"].Value = ((OpcionCombo)cboRol.SelectedItem).Texto.ToString();
                    row.Cells["EstadoValor"].Value = 0;
                    row.Cells["estado"].Value = "No Activo";
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Seleccione un usuario para Eliminarlo", "Mensaje", MessageBoxButtons.OK);
                }

            }
        }


    }
}
