using System;
using System.Linq;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Modelo;

namespace UNICAH
{
    public partial class frmLogin : Form
    {
        public int usuarioId { get; set; }
        public string usuarioNombre { get; set; }
        public string usuario { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        //Evento que se ejecuta al presionar el botón de iniciar
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    //Se obtiene el usuario
                    var usuario = db.Usuarios.FirstOrDefault(u => u.Usuario == txtUsuario.Text);

                    if (usuario != null) //Si es diferente de null el usuario existe.
                    {
                        //Si el usuario está inactivo no puede hacer login
                        if (usuario.Estado != "ACT")
                            Mensajes.Advertencia("Su usuario ha sido deshabilitado.");

                        //Se verifica la contraseña
                        else if (usuario.Contrasenia == Hash256.obtenerHash256(txtContrasenia.Text))
                        {
                            //Si la contraseña es válida cierra este formulario
                            DialogResult = DialogResult.OK;
                            this.usuarioId = usuario.Id;
                            this.usuarioNombre = usuario.Nombre;
                            this.usuario = usuario.Usuario;
                            this.Close();
                        }

                        else //Caso contrario la contraseña es incorrecta.
                        {
                            Mensajes.Advertencia("Usuario o contraseña inválidos.");
                            txtContrasenia.Clear();
                        }    

                    }
                    else //Caso cotrario el usuario no existe.
                    {
                        Mensajes.Advertencia("Usuario o contraseña inválidos.");
                        txtContrasenia.Clear();
                    }
                }
            }
            catch(Exception ex)
            {
                string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Mensajes.Error("Algo ha salido mal \n" + mensaje);
                Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
                //Mensajes.Error("Algo ha salido mal. \n" + ex.InnerException.InnerException.Message);
            }
          
            
        }

        //Evento que se ejecuta al producirse cambios en el textbox de usuario
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            habilitarBotonIniciar();
        }

        //Método para habilitar o desabilitar el botón de inicio
        private void habilitarBotonIniciar()
        {
            if (txtUsuario.Text.Equals(string.Empty) || txtContrasenia.Text.Equals(string.Empty))
                btnIniciar.Enabled = false;
            else
                btnIniciar.Enabled = true;
        }

        //Evento que se ejecuta al iniciar el formulario
        private void frmLogin_Load(object sender, EventArgs e)
        {
            habilitarBotonIniciar();
        }

        //Evento que se ejecuta al producirse cambios en el textbox de usuario
        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            habilitarBotonIniciar();
        }
    }
}
