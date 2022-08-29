/***************************************************************************************************************************************************
 * Formulario: frmBuscarClase
 * Namespace : UNICAH.Formularios.Administracion
 * Descripción: Formulario para buscar y seleccionar una clase.
 ***************************************************************************************************************************************************/
using System;
using System.Data;
using System.Linq;
using UNICAH.Modelo;
using System.Windows.Forms;
using UNICAH.Clases;

namespace UNICAH.Formularios.Administracion
{
    public partial class frmBuscarClase : Form
    {
        private int? _idClase = null; //Propiedad que almacena el id de la clase seleccionada.
        private string _nombreClase = null; //Propiedad que almacena el nombre de la clase seleccionada.

        private string _estado; //Propiedad para filtrar los datos por estado

        //getter para obtener el id de la clase seleccionada desde el formulario frmAsignarClase.
        public int? idclase
        {    
            get { return _idClase; }
        }

        //getter para obtener el nombre clase seleccionada desde el formulario frmAsignarClase.
        public string nombreClase
        {
            get { return _nombreClase; }
        }

        public frmBuscarClase(string estado = null)
        {
            this._estado = estado;
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario
        private void frmBuscarClase_Load(object sender, EventArgs e)
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
                    var clases = from c in db.Clases
                                 where ( //filtros del campo de búsqueda
                                    c.Nombre.Contains(txtBuscar.Text)
                                        || c.Codigo.Contains(txtBuscar.Text)
                                 )
                                 select new
                                 {
                                     ID = c.Id,
                                     Código = c.Codigo,
                                     c.Nombre,
                                     c.Estado
                                 };


                    if (!string.IsNullOrEmpty(_estado))
                        clases = clases.Where(c => c.Estado == _estado);

                    dgvClases.DataSource = clases.ToList();
                    dgvClases.Columns[3].Visible = false;

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
        private void dgvClases_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _idClase = Convert.ToInt32(dgvClases.CurrentRow.Cells[0].Value);
            _nombreClase = dgvClases.CurrentRow.Cells[2].Value.ToString();
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
