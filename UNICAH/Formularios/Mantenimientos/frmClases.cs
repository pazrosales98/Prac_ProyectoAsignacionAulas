
/***************************************************************************************************************************************************
 * Formulario: frmClases
 * Namespace : UNICAH.Formularios.Mantenimientos
 * Descripción: Formulario para la creación, edición de clases.
 ***************************************************************************************************************************************************/
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Modelo;

namespace UNICAH.Formularios.Mantenimientos
{
    public partial class frmClases : Form
    {
        private bool editar = false; //varible para identificar cuando el usuario quiere editar un registro
        private int? idClase = null; //variable para almacenar el id del registro a editar o eliminar
        public frmClases()
        {
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario
        private void frmClases_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            refrescarGrid();
            txtCodigo.Focus();
        }

        //Llena el datagrid con los datos
        private void refrescarGrid()
        {
            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var clases = from c in db.Clases
                                 where c.Codigo.Contains(txtBuscar.Text)
                               || c.Nombre.Contains(txtBuscar.Text)
                                 orderby c.Id descending
                                 select new
                                 {
                                     ID = c.Id,
                                     Código = c.Codigo,
                                     c.Nombre,
                                     Estado = (c.Estado == "ACT" ? "Activo" : "Inactivo")
                                 };
                    dgvClases.DataSource = clases.ToList();
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
            if (txtCodigo.Text.Equals(string.Empty))
                Mensajes.Advertencia("Por favor ingrese el código.");
            else if (txtNombre.Text.Equals(string.Empty))
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
                            var clase2 = db.Clases.FirstOrDefault(c => c.Id == idClase);
                            clase2.Codigo = txtCodigo.Text;
                            clase2.Nombre = txtNombre.Text;
                            clase2.Estado = (cmbEstado.Text == "Activo") ? "ACT" : "INA";

                            db.SaveChanges();
                        }

                        refrescarGrid();
                        limpiarCampos();
                        Mensajes.Exitoso("Clase editada exitosamente.");


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

                UNICAH.Modelo.Clases clase = new UNICAH.Modelo.Clases()
                {
                    Codigo = txtCodigo.Text,
                    Nombre = txtNombre.Text,
                    Estado = (cmbEstado.Text == "Activo") ? "ACT" : "INA"
                };

                try
                {
                    using (UnicahEntities db = new UnicahEntities())
                    {
                        db.Clases.Add(clase);
                        db.SaveChanges();
                    }
                    clase = null;
                    refrescarGrid();
                    limpiarCampos();
                    Mensajes.Exitoso("Clase creada exitosamente.");


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
            txtCodigo.Clear();
            cmbEstado.SelectedIndex = 0;
            txtBuscar.Clear();
            editar = false;
            idClase = null;
        }

        //Método que se ejecuta al hacer doble click sobre un registro.
        private void dgvClases_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idClase = Convert.ToInt32(dgvClases.CurrentRow.Cells[0].Value);

            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var clase = db.Clases.FirstOrDefault(c => c.Id == idClase);

                    txtCodigo.Text = clase.Codigo;
                    txtNombre.Text = clase.Nombre;
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
