/***************************************************************************************************************************************************
 * Formulario: frmMaestros
 * Namespace : UNICAH.Formularios.Mantenimientos
 * Descripción: Formulario para la creación, edición de maestros.
 ***************************************************************************************************************************************************/
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Modelo;

namespace UNICAH.Formularios.Mantenimientos
{
    public partial class frmMaestros : Form
    {
        private bool editar = false; //varible para identificar cuando el usuario quiere editar un registro
        private int? idMaestro= null; //variable para almacenar el id del registro a editar o eliminar
        public frmMaestros()
        {
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario
        private void frmMaestros_Load(object sender, EventArgs e)
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
                    var clases = from m in db.Maestros
                                 where m.Nombre.Contains(txtBuscar.Text)
                                || m.Identidad.Contains(txtBuscar.Text)
                                 orderby m.Id descending
                                 select new
                                 {
                                     ID = m.Id,
                                     m.Nombre,
                                     m.Identidad,
                                     Estado = (m.Estado == "ACT" ? "Activo" : "Inactivo")
                                 };
                    dgvMaestros.DataSource = clases.ToList();
                }
            }
            catch(Exception ex)
            {
                string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Mensajes.Error("Algo ha salido mal \n" + mensaje);
                Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Equals(string.Empty))
                Mensajes.Advertencia("Por favor ingrese el nombre.");
            else
            {
                //Si el usuario quiere editar entra aquí
                if (editar)
                {
                    try
                    {
                        using (UnicahEntities db = new UnicahEntities())
                        {
                            var maestro2 = db.Maestros.FirstOrDefault(m => m.Id == idMaestro);
                            maestro2.Nombre = txtNombre.Text;
                            maestro2.Nombre = txtNombre.Text;
                            maestro2.Estado = (cmbEstado.Text == "Activo") ? "ACT" : "INA";

                            db.SaveChanges();
                        }

                        refrescarGrid();
                        limpiarCampos();
                        Mensajes.Exitoso("Maestro editado exitosamente.");


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

                Maestros maestro = new Maestros()
                {
                    Nombre = txtNombre.Text,
                    Identidad = txtIdentidad.Text,
                    Estado = (cmbEstado.Text == "Activo") ? "ACT" : "INA"
                };

                try
                {
                    using (UnicahEntities db = new UnicahEntities())
                    {
                        db.Maestros.Add(maestro);
                        db.SaveChanges();
                    }
                    maestro = null;
                    refrescarGrid();
                    limpiarCampos();
                    Mensajes.Exitoso("Maestro creado exitosamente.");


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
            txtNombre.Clear();
            txtIdentidad.Clear();
            cmbEstado.SelectedIndex = 0;
            txtBuscar.Clear();
            editar = false;
            idMaestro = null;
        }

        //Método que se ejecuta al hacer doble click sobre un registro.
        private void dgvMaestros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idMaestro = Convert.ToInt32(dgvMaestros.CurrentRow.Cells[0].Value);

            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var clase = db.Maestros.FirstOrDefault(m => m.Id == idMaestro);

                    txtNombre.Text = clase.Nombre;
                    txtIdentidad.Text = clase.Identidad;
                    cmbEstado.SelectedItem = (clase.Estado == "ACT") ? "Activo" : "Inactivo";
                    editar = true;
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
