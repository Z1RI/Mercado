using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace MercadoDonTino
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmClosing(object sender, FormClosingEventArgs e) {

            txtId.Text = "";
            txtPassword.Text = "";

            this.Show();
        }

        public void button1_Click(object sender, EventArgs e)
        {


            List<Usuario> TEST = new CN_Usuario().listar();

            Usuario oUsuario = new CN_Usuario().listar().Where(u => u.nombre_Usuario == txtId.Text && u.clave == txtPassword.Text && u.estado == true).FirstOrDefault();

            if (oUsuario != null)
            {

                Inicio form = new Inicio(oUsuario);
                form.Show();
                this.Hide();
                form.FormClosing += frmClosing;
            }
            else
            {
                MessageBox.Show("No se encontro el usuario", "Mensaje", MessageBoxButtons.OK);
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            {
                this.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

    }
}
