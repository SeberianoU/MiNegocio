using BL_MiNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_MiNegocio
{
    public partial class frmUsuarios : Form
    {
        BL_Usuarios _usuarios;
        CancelarCambios _cancelarCambios;

        public object Resourse { get; private set; }

        public frmUsuarios()
        {
            InitializeComponent();

            _cancelarCambios = new CancelarCambios();

            _usuarios = new BL_Usuarios();
            listaUsuariosBindingSource.DataSource = _usuarios.ObtenerUsuarios();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _usuarios.AgregarUsuario();
            listaUsuariosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
            nombreUsuarioTextBox.Focus();
        }

        private void DeshabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("¿Desea Eliminar el Usuario?", "Eliminar Usuario", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void Eliminar(int id)
        {
            var resultado = _usuarios.EliminarUsuario(id);
            if (resultado == true)
            {
                listaUsuariosBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Error al eliminar Usuario");
            }
        }

        private void listaUsuariosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaUsuariosBindingSource.EndEdit();
            var usuario = (Usuario)listaUsuariosBindingSource.Current;

            ////Cargar Imagen como byte
            if (fotoPictureBox.Image != null)
            {
                usuario.Foto = Program.imagenToByteArray(fotoPictureBox.Image);
            }
            else
            {
                usuario.Foto = Program.imagenToByteArray(Properties.Resources.perfil_de_cliente);
            }
            ///

            var resultado = _usuarios.GuardarUsuario(usuario);

            if (resultado.Correcto == true)
            {
                listaUsuariosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Usuario guardado Exitosamente");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);

            _usuarios.CancelarCambios();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var usuario = (Usuario)listaUsuariosBindingSource.Current;

            if (usuario != null)
            {
                openFileDialogImagen.ShowDialog();
                var archivo = openFileDialogImagen.FileName;
                if (archivo != "")
                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();

                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }
            }
            else
            {
                MessageBox.Show("Cree un Usuario antes de agregar la imagen");
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }
    }
}
