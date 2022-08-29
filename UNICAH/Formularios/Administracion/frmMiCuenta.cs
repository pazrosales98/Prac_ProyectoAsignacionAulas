/***************************************************************************************************************************************************
 * Formulario: frmMiCuenta
 * Namespace : UNICAH.Formularios.Administracion
 * Descripción: Formulario para administrar los datos de la cuenta del usuario loggeado.
 ***************************************************************************************************************************************************/
using System;
using System.Linq;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Modelo;

namespace UNICAH.Formularios.Administracion
{
    public partial class frmMiCuenta : Form
    {
        private int idLoggedUser; //Variable para almacenar el id del usuario loggeado
        public frmMiCuenta(int id)
        {
            idLoggedUser = id;
            InitializeComponent();
        }

        //Método que se ejecuta al iniciar el formulario
        private void frmMiCuenta_Load(object sender, EventArgs e)
        {
            refrescarDatos();
        }

        //Método para obtener los datos del usuario
        private void refrescarDatos()
        {
            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var miCuenta = db.Usuarios.FirstOrDefault(u => u.Id == idLoggedUser);

                    if (miCuenta != null)
                    {
                        txtNombre.Text = miCuenta.Nombre;
                        txtUsuario.Text = miCuenta.Usuario;
                        chkEsAdmin.Checked = miCuenta.EsAdmin;
                        return;
                    }

                    Mensajes.Advertencia("Algo salió mal al obtener los datos de su cuenta.");
                }
            }
            catch(Exception ex)
            {
                string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Mensajes.Error("Algo ha salido mal \n" + mensaje);
                Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
            }
            
        }

        //Método que se ejecuta al hacer click sobre el botón guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validaciones para evitar nulos.
            if (txtNombre.Text.Equals(string.Empty))
                Mensajes.Advertencia("Por favor ingrese el nombre.");
            else if (txtContrasenia.Text.Equals(string.Empty))
                Mensajes.Advertencia("Por favor ingrese una contraseña.");
            else if (txtContrasenia.Text.Length < 8)
                Mensajes.Advertencia("La contraseña debe tener al menos 8 dígitos.");
            else
            {
                try
                {
                    using (UnicahEntities db = new UnicahEntities())
                    {
                        var usuario = db.Usuarios.FirstOrDefault(u => u.Id == idLoggedUser);
                        usuario.Nombre = txtNombre.Text;
                        usuario.Contrasenia = Hash256.obtenerHash256(txtContrasenia.Text); //encripta la contraseña

                        db.SaveChanges();
                        txtContrasenia.Clear();
                    }

                    refrescarDatos();
                    Mensajes.Exitoso("Su cuenta ha sido actualizada exitosamente.");


                }
                catch (Exception ex)
                {
                    string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                    Mensajes.Error("Algo ha salido mal \n" + mensaje);
                    Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);

                }
            }
        }
    }
}
