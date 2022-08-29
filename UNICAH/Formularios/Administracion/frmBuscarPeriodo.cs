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
    public partial class frmBuscarPeriodo : Form
    {
        private int? _idPeriodo = null; //Propiedad que almacena el id del periodo seleccionado.
        private string _descripcionPeriodo = null; //Propiedad que almacena el nombre del periodo seleccionado.

        private string _estado; //Propiedad para filtrar los datos por estado


        //getter para obtener el id de la clase seleccionada 
        public int? idPeriodo
        {
            get { return _idPeriodo; }
        }

        //getter para obtener el nombre clase seleccionada
        public string nombrePeriodo
        {
            get { return _descripcionPeriodo; }
        }
        public frmBuscarPeriodo(string estado = null)
        {
            this._estado = estado;
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario
        private void frmBuscarPeriodo_Load(object sender, EventArgs e)
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
                    var periodos = from p in db.Periodos
                                   where p.Descripcion.Contains(txtBuscar.Text) //filtros del campo de búsqueda
                                   orderby p.Id descending
                                   select new
                                   {
                                       ID = p.Id,
                                       Descripción = p.Descripcion,
                                       p.Estado
                                   };

                    if (!string.IsNullOrEmpty(_estado))
                        periodos = periodos.Where(p => p.Estado == _estado);


                    dgvPeriodos.DataSource = periodos.ToList();
                    dgvPeriodos.Columns[2].Visible = false;
                }
            }
            catch (Exception ex)
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
        private void dgvPeriodos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _idPeriodo = Convert.ToInt32(dgvPeriodos.CurrentRow.Cells[0].Value);
            _descripcionPeriodo = dgvPeriodos.CurrentRow.Cells[1].Value.ToString();
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
