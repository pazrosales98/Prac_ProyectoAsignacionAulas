/***************************************************************************************************************************************************
 * Formulario: frmBuscarAula
 * Namespace : UNICAH.Formularios.Administracion
 * Descripción: Formulario para buscar y seleccionar una aula.
 ***************************************************************************************************************************************************/
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Modelo;

namespace UNICAH.Formularios.Administracion
{
    public partial class frmBuscarAula : Form
    {
        private int? _idAula = null; //Propiedad que almacena el id del aula seleccionada.
        private string _codigoAula = null; //Propiedad que almacena el código del aula seleccionada.

        private string _estado; //Propiedad para filtrar los datos por estado

        //getter para obtener el id del aula seleccionada
        public int? idAula
        {
            get { return _idAula; }
        }

        //getter para obtener el código del aula seleccionada
        public string codigoAula
        {
            get { return _codigoAula; }
        }

        public frmBuscarAula(string estado = null)
        {
            this._estado = estado;
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario
        private void frmBuscarAula_Load(object sender, EventArgs e)
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
                    var aulas = from a in db.Aulas
                                where ( //filtros del campo de búsqueda
                                   a.Numero.Contains(txtBuscar.Text)
                                       || a.Ubicacion.Contains(txtBuscar.Text)
                                )
                                select new
                                {
                                    ID = a.Id,
                                    Número = a.Numero,
                                    Ubicación = a.Ubicacion,
                                    a.Estado
                                };


                    if (!string.IsNullOrEmpty(_estado))
                        aulas = aulas.Where(a => a.Estado == _estado);

                    dgvAulas.DataSource = aulas.ToList();
                    dgvAulas.Columns[3].Visible = false;
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
        private void dgvAulas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _idAula = Convert.ToInt32(dgvAulas.CurrentRow.Cells[0].Value);
            _codigoAula = dgvAulas.CurrentRow.Cells[1].Value.ToString();
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
