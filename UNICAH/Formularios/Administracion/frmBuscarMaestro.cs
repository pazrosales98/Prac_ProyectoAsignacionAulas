/***************************************************************************************************************************************************
 * Formulario: frmBuscarPeriodo
 * Namespace : UNICAH.Formularios.Administracion
 * Descripción: Formulario para buscar y seleccionar un periodo.
 ***************************************************************************************************************************************************/
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Modelo;

namespace UNICAH.Formularios.Administracion
{
    public partial class frmBuscarMaestro : Form
    {
        private int? _idMaestro = null; //Propiedad que almacena el id del maestro seleccionado.
        private string _nombreMaestro = null; //Propiedad que almacena el nombre del maestro seleccionado.

        private string _estado; //Propiedad para filtrar los datos por estado

        //getter para obtener el id de la clase seleccionada desde el formulario frmAsignarClase.
        public int? idMaestro
        {
            get { return _idMaestro; }
        }

        //getter para obtener el nombre clase seleccionada desde el formulario frmAsignarClase.
        public string nombreMaestro
        {
            get { return _nombreMaestro; }
        }
        public frmBuscarMaestro(string estado = null)
        {
            this._estado = estado;
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario
        private void frmBuscarMaestro_Load(object sender, EventArgs e)
        {
            refrescarGrid();
            txtBuscar.Focus();
        }

        //Llena el datagrid con los datos, filtra si el campo de busqueda no está vacío.
        private void refrescarGrid()
        {
            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var maestros = from m in db.Maestros
                                   where ( //filtros del campo de búsqueda
                                      m.Nombre.Contains(txtBuscar.Text)
                                          || m.Identidad.Contains(txtBuscar.Text)
                                   )
                                   select new
                                   {
                                       ID = m.Id,
                                       Nombre = m.Nombre,
                                       m.Identidad,
                                       m.Estado
                                   };

                    if (!string.IsNullOrEmpty(_estado))
                        maestros = maestros.Where(m => m.Estado == _estado);

                    dgvMaestros.DataSource = maestros.ToList();
                    dgvMaestros.Columns[3].Visible = false;
                }
            }
            catch(Exception ex)
            {
                string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Mensajes.Error("Algo ha salido mal \n" + mensaje);
                Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
            }
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

        //Método que se ejecuta al hacer doble click sobre un registro.
        private void dgvMaestros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _idMaestro = Convert.ToInt32(dgvMaestros.CurrentRow.Cells[0].Value);
            _nombreMaestro = dgvMaestros.CurrentRow.Cells[1].Value.ToString();
            this.Close();

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
