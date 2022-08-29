using System;
using System.Windows.Forms;
using UNICAH.Formularios;
using UNICAH.Formularios.Mantenimientos;
using UNICAH.Formularios.Administracion;
using UNICAH.Formularios.Reportes;

namespace UNICAH
{
    public partial class Form1 : Form
    {
        private Usuario usuario = new Usuario();
        private Form formularioActivo = null;

        private int idLoggedUser;
        public Form1(int id, string nombre, string nusuario)
        {
            idLoggedUser = id;
            InitializeComponent();
            personalizarDisenio();
            usuario.Id = id;
            usuario.Nombre = nombre;
            usuario.NombreUsuario = nusuario;
       
        }

        //Oculta los submenús del panel
        private void personalizarDisenio()
        {
            pnlSubMenuMnt.Visible = false;
            pnlReportes.Visible = false;
            panel1.Visible = false;

        }

        //Oculta el submenú anterior al abrir otro
        private void ocultarSubMenus()
        {
            if (pnlSubMenuMnt.Visible)
                pnlSubMenuMnt.Visible = false;
            if(pnlReportes.Visible)
                pnlReportes.Visible = false;
            if (panel1.Visible)
                panel1.Visible = false;

        }

        private void mostrarSubmenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                ocultarSubMenus();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnMantenimientos_Click(object sender, EventArgs e)
        {
            mostrarSubmenu(pnlSubMenuMnt);
        }

        private void Aulas_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmAulas());
            ocultarSubMenus();
        }

        private void abrirFormularioHijo(Form formularioHijo)
        {
            if (formularioActivo != null)
                formularioActivo.Close();
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            pnlContenedorPrincipal.Controls.Add(formularioHijo);
            pnlContenedorPrincipal.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();

        }

        private void btnClases_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmClases());
            ocultarSubMenus();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmUsuarios(idLoggedUser));
            ocultarSubMenus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = usuario.NombreUsuario;
            pnlMenuLateral.AutoScroll = false;
            pnlMenuLateral.HorizontalScroll.Enabled = false;
            pnlMenuLateral.HorizontalScroll.Visible = false;
            pnlMenuLateral.HorizontalScroll.Maximum = 0;
            pnlMenuLateral.AutoScroll = true;
        }

        private void btnMaestros_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmMaestros());
            ocultarSubMenus();
        }

        private void btnPeriodos_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmPeriodos());
            ocultarSubMenus();
        }

        private void btnAsignarClases_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmAsignarClases());
            ocultarSubMenus();
        }

        private void btnReporteClasesPeriodo_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmReporteClasePeriodo());
            ocultarSubMenus();
        }

        private void btnReporteClaseAula_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmReporteClaseAula());
            ocultarSubMenus();
        }

        private void btnReporteClaseMaestro_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmReporteClasesMaestros());
            ocultarSubMenus();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnAdministración_Click(object sender, EventArgs e)
        {
            mostrarSubmenu(panel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrarSubmenu(pnlReportes);
        }

        private void btnMiCuenta_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new frmMiCuenta(idLoggedUser));
            ocultarSubMenus();
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
    }
}
