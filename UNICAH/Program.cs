using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNICAH
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new UNICAH.Formularios.Mantenimientos.frmUsuarios());
            //Application.Run(new Form1(1,"Orlando", "orlando"));
            //Application.Run(new frmLogin());

            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();

            if (loginForm.DialogResult == DialogResult.OK)
                Application.Run(new Form1(loginForm.usuarioId, loginForm.usuarioNombre, loginForm.usuario));
            else
                Application.Exit();

        }
    }
}
