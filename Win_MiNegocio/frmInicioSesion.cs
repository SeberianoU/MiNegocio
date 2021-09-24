using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL_MiNegocio;

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


        private BL_Usuarios _usuarios;

        private void frmInicioSesion_Load(object sender, EventArgs e)
        {
            _usuarios = new BL_Usuarios();
            listaUsuariosBindingSource.DataSource = _usuarios.ObtenerUsuarios();
        }

        private void textBoxUsuario_Validated(object sender, EventArgs e)
        {
            listaUsuariosBindingSource.DataSource = _usuarios.ObtenerUsuarios(textBoxUsuario.Text);
            var usuario = (Usuario)listaUsuariosBindingSource.Current;

            if (usuario != null)
            {
                if (textBoxUsuario.Text == usuario.NombreUsuario && usuario.Estado == true)
                {
                    //MessageBox.Show("Bienbenido: " + usuario.Nombre + " " + usuario.Apellido);
                    #region Imagen
                    if (usuario.Foto != null)
                    {                        
                        pictureBoxFoto.Image = Program.arrayByteToImagen(usuario.Foto);                        
                    }
                    //else
                    //{
                    //    pictureBoxFoto.Image = null;
                    //}
                    #endregion
                }
                else
                {
                    MessageBox.Show("NO encuentra el ususario o No tiene acceso.");
                    pictureBoxFoto.Image = Properties.Resources.Error;
                }
            }
            else
            {
                MessageBox.Show("NO encuentra el ususario o No tiene acceso.");
                pictureBoxFoto.Image = Properties.Resources.Error;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            listaUsuariosBindingSource.DataSource = _usuarios.ObtenerUsuarios(textBoxUsuario.Text);
            var usuario = (Usuario)listaUsuariosBindingSource.Current;

            if (usuario != null)
            {
                if (textBoxUsuario.Text == usuario.NombreUsuario && usuario.Estado == true && usuario.Contraseña == textBoxContraseña.Text)
                {
                    //Cargar datos a clase
                    ConfiguracionActual.NombreUsuario = textBoxUsuario.Text;
                    ConfiguracionActual.Nombre = usuario.Nombre;
                    ConfiguracionActual.Apellido = usuario.Apellido;
                    ConfiguracionActual.Empresa = "MiNegocio " + "Tecnologìas Informàticas";
                    ConfiguracionActual.Foto = usuario.Foto;


                    frmPrincipal formPrincipal;
                    formPrincipal = new frmPrincipal();                
                    formPrincipal.Show();
                    this.Visible = false;

                }
                else
                {
                    MessageBox.Show("Valores ingresadosn no concuerdan");
                }
                //
            }
        }
    }

}
