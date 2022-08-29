/***************************************************************************************************************************************************
 * Formulario: frmPeriodos
 * Namespace : UNICAH.Formularios.Mantenimientos
 * Descripción: Formulario para la creación, edición de periodos.
 ***************************************************************************************************************************************************/
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Modelo;

namespace UNICAH.Formularios
{
    public partial class frmPeriodos : Form
    {
        private bool editar = false; //varible para identificar cuando el usuario quiere editar un registro
        private int? idPeriodo = null; //variable para almacenar el id del registro a editar o eliminar
        public frmPeriodos()
        {
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario
        private void frmPeriodos_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            refrescarGrid();
            txtDescripcion.Focus();
        }

        //Llena el datagrid con los datos
        private void refrescarGrid()
        {
            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var periodos = from p in db.Periodos
                                   where p.Descripcion.Contains(txtBuscar.Text)
                                   orderby p.Id descending
                                   select new
                                   {
                                       ID = p.Id,
                                       Descipción = p.Descripcion,
                                       Inicio = p.FechaInicio,
                                       Fin = p.FechaFin,
                                       Estado = (p.Estado == "ACT" ? "Activo" : "Inactivo")
                                   };
                    dgvPeriodos.DataSource = periodos.ToList();
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
            if (txtDescripcion.Text.Equals(string.Empty))
                Mensajes.Advertencia("Por favor ingrese la Descripción.");
            else if(DateTime.Compare(dtpFechaInicio.Value,dtpFechaFinal.Value) == 1
                        || DateTime.Compare(dtpFechaInicio.Value, dtpFechaFinal.Value) == 0){
                Mensajes.Advertencia("La Fecha de inicio debe ser menor a la fecha de finalización.");
            }
            else
            {
                //Si eel usuario quiere editar entra aquí
                if (editar)
                {
                    try
                    {
                        using (UnicahEntities db = new UnicahEntities())
                        {
                            var periodo2 = db.Periodos.FirstOrDefault(a => a.Id == idPeriodo);
                            periodo2.Descripcion = txtDescripcion.Text;
                            periodo2.FechaInicio = dtpFechaInicio.Value;
                            periodo2.FechaFin = dtpFechaFinal.Value;
                            periodo2.Estado = (cmbEstado.Text == "Activo") ? "ACT" : "INA";

                            db.SaveChanges();
                        }

                        refrescarGrid();
                        limpiarCampos();
                        Mensajes.Exitoso("Periodo editado exitosamente.");


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

                Periodos periodo = new Periodos
                {
                    FechaInicio = dtpFechaInicio.Value,
                    Descripcion = txtDescripcion.Text,
                    FechaFin = dtpFechaFinal.Value,
                    Estado = (cmbEstado.Text == "Activo") ? "ACT" : "INA"
                };

                try
                {
                    using (UnicahEntities db = new UnicahEntities())
                    {
                        db.Periodos.Add(periodo);
                        db.SaveChanges();
                    }
                    periodo = null;
                    refrescarGrid();
                    limpiarCampos();
                    Mensajes.Exitoso("Periodo creado exitosamente.");


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
            txtDescripcion.Clear();

            cmbEstado.SelectedIndex = 0;
            txtBuscar.Clear();
            editar = false;
            idPeriodo = null;
        }

        //Método que se ejecuta al hacer doble click sobre un registro.
        private void dgvPeriodos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idPeriodo = Convert.ToInt32(dgvPeriodos.CurrentRow.Cells[0].Value);

            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var periodo = db.Periodos.FirstOrDefault(a => a.Id == idPeriodo);

                    txtDescripcion.Text = periodo.Descripcion;
                    dtpFechaInicio.Value = periodo.FechaInicio;
                    dtpFechaFinal.Value = periodo.FechaFin;
                    cmbEstado.SelectedItem = (periodo.Estado == "ACT") ? "Activo" : "Inactivo";
                    editar = true;
                }
            }
            catch (Exception ex)
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
