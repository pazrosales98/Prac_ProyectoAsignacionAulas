/***************************************************************************************************************************************************
 * Formulario: frmUsuarios
 * Namespace : UNICAH.Formularios.Mantenimientos
 * Descripción: Formulario para la creación, edición y eliminación de usuarios, solo disponible para un usuario administrador.
 **************************************************************************************************************************************************/
using System;
using System.Data;
using System.Linq;
using UNICAH.Clases;
using UNICAH.Modelo;
using System.Windows.Forms;

namespace UNICAH.Formularios.Mantenimientos
{
    public partial class frmUsuarios : Form
    {
        private bool editar = false; //varible para identificar cuando el usuario quiere editar un registro
        private int? idUsuario = null; //variable para almacenar el id del registro a editar o eliminar

        private int idLoggedUser; //variable para almacenar el id del usuario que ha iniciado sesión
        public frmUsuarios(int idLoggedUser = 0)
        {
            this.idLoggedUser = idLoggedUser;
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            refrescarGrid();
            txtNombre.Focus();
        }

        //Llena el datagrid con los datos
        private void refrescarGrid()
        {
            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var usuarios = from u in db.Usuarios
                                   where u.Id != idLoggedUser
                                   && (u.Nombre.Contains(txtBuscar.Text)
                                        || u.Usuario.Contains(txtBuscar.Text))
                                   orderby u.Id descending
                                   select new
                                   {
                                       ID = u.Id,
                                       u.Nombre,
                                       u.Usuario,
                                       Administrador = u.EsAdmin,
                                       Estado = (u.Estado == "ACT" ? "Activo" : "Inactivo")
                                   };
                    dgvUsuarios.DataSource = usuarios.ToList();
                }
            }
            catch(Exception ex)
            {
                string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Mensajes.Error("Algo ha salido mal \n" + mensaje);
                Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
            }
        }

        //Método que se ejecuta al presionar guardar.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validaciones para evitar nulos.
            if (txtNombre.Text.Equals(string.Empty))
                Mensajes.Advertencia("Por favor ingrese el nombre.");
            else if(txtUsuario.Text.Equals(string.Empty))
                Mensajes.Advertencia("Por favor ingrese el usuario.");
            else if (txtContrasenia.Text.Equals(string.Empty))
                Mensajes.Advertencia("Por favor ingrese una contraseña.");
            else if (txtContrasenia.Text.Length < 8)
                Mensajes.Advertencia("La contraseña debe tener al menos 8 dígitos.");
            else
            {
                //Si eel usuario quiere editar entra aquí
                if (editar)
                {
                    try
                    {
                        using (UnicahEntities db = new UnicahEntities())
                        {
                            var usuario2 = db.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
                            usuario2.Nombre = txtNombre.Text;
                            usuario2.Usuario = txtUsuario.Text;
                            usuario2.Contrasenia = Hash256.obtenerHash256(txtContrasenia.Text); //encripta la contraseña
                            usuario2.EsAdmin = chkEsAdmin.Checked;
                            usuario2.Estado = (cmbEstado.Text == "Activo") ? "ACT" : "INA";

                            db.SaveChanges();
                        }
                       
                        refrescarGrid();
                        limpiarCampos();
                        Mensajes.Exitoso("Usuario editado exitosamente.");


                    }
                    catch (Exception ex)
                    {
                        string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                        Mensajes.Error("Algo ha salido mal \n" + mensaje);
                        Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);

                    }

                    return; //termina la ejecución de la función
                }

                //Si el usuario quiere realizar un registro nuevo salta hasta aquí

                Usuarios usuario = new Usuarios
                {
                    Nombre = txtNombre.Text,
                    Usuario = txtUsuario.Text,
                    Contrasenia = Hash256.obtenerHash256(txtContrasenia.Text),
                    EsAdmin = chkEsAdmin.Checked,
                    Estado = (cmbEstado.Text == "Activo") ? "ACT" : "INA"
                };

                try
                {
                    using (UnicahEntities db = new UnicahEntities())
                    {
                        db.Usuarios.Add(usuario);
                        db.SaveChanges();
                    }
                    usuario = null;
                    refrescarGrid();
                    limpiarCampos();
                    Mensajes.Exitoso("Usuario creado exitosamente.");

                }
                catch (Exception ex)
                {
                    string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                    Mensajes.Error("Algo ha salido mal \n" + mensaje);
                    Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);

                }

                
            }


        }

        //Método para limpiar los campos.
        private void limpiarCampos()
        {
            txtContrasenia.Clear();
            txtNombre.Clear();
            txtUsuario.Clear();
            chkEsAdmin.Checked = false;
            cmbEstado.SelectedIndex = 0;
            txtBuscar.Clear();
            editar = false;
            idUsuario = null;
        }

        //Método que se ejecuta al hacer doble click sobre un registro.
        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idUsuario = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells[0].Value);

            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var usuario = db.Usuarios.FirstOrDefault(u => u.Id == idUsuario);

                    //Si el usuario que se quiere editar es administrador, este no podrá ser editado.
                    if (!usuario.EsAdmin)
                    {
                        txtNombre.Text = usuario.Nombre;
                        txtUsuario.Text = usuario.Usuario;
                        chkEsAdmin.Checked = usuario.EsAdmin;
                        cmbEstado.SelectedItem = (usuario.Estado == "ACT") ? "Activo" : "Inactivo";
                        editar = true;
                    }
                    else
                    {
                        Mensajes.Advertencia("No puede editar este usuario porque es un administrador.");
                        idUsuario = null;

                    }



                }
            }
            catch(Exception ex)
            {
                string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Mensajes.Error("Algo ha salido mal \n" + mensaje);
                Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
            }
        }

        //Método que se ejecuta al presionar el botón de nuevo.
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        //Método que se ejecuta al presionar el botón de eliminar.
        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        //Método que se ejecuta al presionar el botón de buscar.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            refrescarGrid();
        }

        //Método que se ejecuta al presionar el botón de refrescar.
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();

            refrescarGrid();
        }

        //Método que captura el evento cuando el usuario presiona una tecla.
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            //Si es enter, ejecuta la búsqueda
            if (e.KeyData == Keys.Enter)
            {
                refrescarGrid();
            }
        }
    }
}
