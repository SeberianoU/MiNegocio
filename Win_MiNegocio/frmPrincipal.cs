using BL_MiNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_MiNegocio
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            
        }

        #region Configuración

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelFecha.Text = DateTime.Now.ToString();
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.Red;
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.CadetBlue;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            CerrarAplicacion();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CerrarAplicacion();
        }

        private void CerrarAplicacion()
        {
            var respuesta = MessageBox.Show("¿Desea Salir del Sistema?", "MiNegocio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void AbrirFormulario<frmForm>() where frmForm : Form, new()
        {
            frmForm formPrincipal;
            formPrincipal = new frmForm();
            formPrincipal.MdiParent = this;
            formPrincipal.Show();
            formPrincipal.BringToFront();

            //Form formHijo;
            //formHijo = panelCentro.Controls.OfType<frmForm>().FirstOrDefault();
            //if (formHijo == null)
            //{
            //    formHijo = new frmForm();
            //    formHijo.TopLevel = false;
            //    formHijo.FormBorderStyle = FormBorderStyle.None;
            //    formHijo.Dock = DockStyle.Fill;
            //    panelCentro.Controls.Add(formHijo);
            //    panelCentro.Tag = formHijo;
            //    formHijo.Show();
            //    formHijo.BringToFront();

            //}
            //else
            //{
            //    formHijo.BringToFront();
            //}
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btnRestaurar.Visible = true;
            btnMaximizar.Visible = false;
        }
        private void btnMinimizar_MouseEnter(object sender, EventArgs e)
        {
            btnMaximizar.BackColor = Color.Red;
        }

        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMaximizar.BackColor = Color.CadetBlue;
        }

        private void btnRestaurar_MouseEnter(object sender, EventArgs e)
        {
            btnRestaurar.BackColor = Color.Red;
        }

        private void btnRestaurar_MouseLeave(object sender, EventArgs e)
        {
            btnRestaurar.BackColor = Color.CadetBlue;
        }

        private void btnMinimizar_MouseEnter_1(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.Red;
        }

        private void btnMinimizar_MouseLeave_1(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.CadetBlue;
        }
        #endregion

        private void mantenimientoDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmUsuarios>();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblNombreUsuario.Text = ConfiguracionActual.Nombre;
            lblNUsuario.Text = ConfiguracionActual.NombreUsuario;
            lblEmpresa.Text = ConfiguracionActual.Empresa;
            pictureBoxFotoUsuario.Image = Program.arrayByteToImagen(ConfiguracionActual.Foto);
        }


    }
}
