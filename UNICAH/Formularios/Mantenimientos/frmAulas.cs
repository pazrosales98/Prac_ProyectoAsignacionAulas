/***************************************************************************************************************************************************
 * Formulario: frmAulas
 * Namespace : UNICAH.Formularios.Mantenimientos
 * Descripción: Formulario para la creación, edición de aulas.
 ***************************************************************************************************************************************************/
using System;
using System.Data;
using System.Linq;
using UNICAH.Modelo;
using System.Windows.Forms;
using UNICAH.Clases;

namespace UNICAH.Formularios.Mantenimientos
{
    public partial class frmAulas : Form
    {
        private bool editar = false; //varible para identificar cuando el usuario quiere editar un registro
        private int? idAula = null; //variable para almacenar el id del registro a editar o eliminar
        public frmAulas()
        {
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario
        private void frmAulas_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            refrescarGrid();
            txtNumero.Focus();
        }

        //Llena el datagrid con los datos
        private void refrescarGrid()
        {
            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var aulas = from a in db.Aulas
                                where a.Numero.Contains(txtBuscar.Text)
                                || a.Ubicacion.Contains(txtBuscar.Text)
                                orderby a.Id descending
                                select new
                                {
                                    ID = a.Id,
                                    Número = a.Numero,
                                    Ubicación = a.Ubicacion,
                                    Estado = (a.Estado == "ACT" ? "Activo" : "Inactivo")
                                };
                    dgvAulas.DataSource = aulas.ToList();
                }
            }
            catch (Exception ex)
            {
                string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Mensajes.Error("Algo ha salido mal \n" + mensaje);
                Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
            }
        }

        //Método que se ejecuta al presionar guardar.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text.Equals(string.Empty))
                Mensajes.Advertencia("Por favor ingrese el número.");
            else if (txtUbicacion.Text.Equals(string.Empty))
                Mensajes.Advertencia("Por favor ingrese la ubicación.");
            else
            {
                //Si eel usuario quiere editar entra aquí
                if (editar)
                {
                    try
                    {
                        using (UnicahEntities db = new UnicahEntities())
                        {
                            var aula2 = db.Aulas.FirstOrDefault(a => a.Id == idAula);
                            aula2.Numero = txtNumero.Text;
                            aula2.Ubicacion = txtUbicacion.Text;
                            aula2.Estado = (cmbEstado.Text == "Activo") ? "ACT" : "INA";

                            db.SaveChanges();
                        }

                        refrescarGrid();
                        limpiarCampos();
                        Mensajes.Exitoso("Aula editada exitosamente.");


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
                Aulas aula = new Aulas
                {
                    Numero = txtNumero.Text,
                    Ubicacion = txtUbicacion.Text,
                    Estado = (cmbEstado.Text == "Activo") ? "ACT" : "INA"
                };

                try
                {
                    using (UnicahEntities db = new UnicahEntities())
                    {
                        db.Aulas.Add(aula);
                        db.SaveChanges();
                    }
                    aula = null;
                    refrescarGrid();
                    limpiarCampos();
                    Mensajes.Exitoso("Aula creada exitosamente.");


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
            txtNumero.Clear();
            txtUbicacion.Clear();
            cmbEstado.SelectedIndex = 0;
            txtBuscar.Clear();
            editar = false;
            idAula = null;
        }

        //Método que se ejecuta al hacer doble click sobre un registro.
        private void dgvAulas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idAula = Convert.ToInt32(dgvAulas.CurrentRow.Cells[0].Value);

            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var aula = db.Aulas.FirstOrDefault(a => a.Id == idAula);

                    txtNumero.Text = aula.Numero;
                    txtUbicacion.Text = aula.Ubicacion;
                    cmbEstado.SelectedItem = (aula.Estado == "ACT") ? "Activo" : "Inactivo";
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
