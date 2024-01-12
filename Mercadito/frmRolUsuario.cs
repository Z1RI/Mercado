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
    public partial class frmRolUsuario : Form
    {
        public frmRolUsuario()
        {
            InitializeComponent();
        }

        private void frmRolUsuario_Load(object sender, EventArgs e)
        {

            List<Rol> listaRol = new CN_Rol().listar();

            foreach (Rol item in listaRol)
            {
                dgvDataRol.Rows.Add(new object[] {"", item.Id_Rol,item.descripcion_rol

            });

            }

        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            String Mensaje = String.Empty;


            Rol objRol = new Rol()
            {
                Id_Rol = Convert.ToInt32(txtIdRol.Text),
                descripcion_rol = txtRolUsuario.Text
            };



            if (objRol.Id_Rol == 0)
            {
                int idRolGenerado = new CN_Rol().Registrar(objRol, out Mensaje);
                if (idRolGenerado != 0)
                {
                    dgvDataRol.Rows.Add(new object[] { "", idRolGenerado, txtRolUsuario.Text, });

                }
                else
                {
                    MessageBox.Show(Mensaje);
                }

                foreach (string s in clbMenus.CheckedItems)
                {

                    string c = "";
                    if (s == "Usuario")
                    {
                         c = "menuUsuario";

                    }
                    else if (s == "Mantenedor")
                    {
                         c = "menuMantenedor";

                    }
                    else if (s == "Ventas")
                    {
                        c = "menuVentas";

                    }
                    else if (s == "Compras")
                    {
                        c = "menuCompras";

                    }
                    else if (s == "Clientes")
                    {
                        c = "menuClientes";

                    }
                    else if (s == "Proveedores")
                    {
                        c = "menuProveedores";

                    }
                    else if (s == "Reportes")
                    {
                        c = "menuReportes";

                    }
                    else
                    {
                        c = "menuInfo";
                    }

                     Permiso objPermiso = new Permiso()
                    {
                        oRol = new Rol() { Id_Rol = idRolGenerado, descripcion_rol = txtRolUsuario.Text },
                        nombreMenu = c
                     };

                    int idPermisoGenerado = new CN_Permiso().Registrar(objPermiso, out Mensaje);

                }
            }
            else
            {

                bool resultadoRol = new CN_Rol().Editar(objRol, out Mensaje);
                if (resultadoRol)
                {
                    DataGridViewRow row = dgvDataRol.Rows[Convert.ToInt32(txtIndiceRol.Text)];
                    row.Cells["RolId"].Value = txtIdRol.Text;
                    row.Cells["DescriptionRol"].Value = txtRolUsuario.Text;

                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
        }

        private void dgvDataRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDataRol.Columns[e.ColumnIndex].Name == "btnSeleccionarRol")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtIndiceRol.Text = indice.ToString();
                    txtIdRol.Text = dgvDataRol.Rows[indice].Cells["RolId"].Value.ToString();
                    txtRolUsuario.Text = dgvDataRol.Rows[indice].Cells["DescriptionRol"].Value.ToString();

                }

            }
        }
    }
}
