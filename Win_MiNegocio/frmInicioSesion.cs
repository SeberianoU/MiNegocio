using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_MiNegocio
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }

        #region Configuración
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxUsuario_Enter(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text == "USUARIO")
            {
                textBoxUsuario.Text = "";
            }
        }

        private void textBoxUsuario_Leave(object sender, EventArgs e)
        {
            if (textBoxUsuario.Text == "")
            {
                textBoxUsuario.Text = "USUARIO";
            }
        }

        private void textBoxContraseña_Enter(object sender, EventArgs e)
        {
            if (textBoxContraseña.Text == "CONTRASEÑA")
            {
                textBoxContraseña.UseSystemPasswordChar = true;
                textBoxContraseña.Text = "";
            }
        }

        private void textBoxContraseña_Leave(object sender, EventArgs e)
        {
            if (textBoxContraseña.Text == "")
            { 
                textBoxContraseña.UseSystemPasswordChar = false;
                 textBoxContraseña.Text = "CONTRASEÑA";
            }
        }

        #endregion


        private void frmInicioSesion_Load(object sender, EventArgs e)
        {

        }
    }
}
