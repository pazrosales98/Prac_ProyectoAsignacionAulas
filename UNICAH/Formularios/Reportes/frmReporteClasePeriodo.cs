/***************************************************************************************************************************************************
 * Formulario: frmReporteClasePeriodo
 * Namespace : UNICAH.Formularios.Reportes
 * Descripción: Formulario para la generación del reporte de clases por periodo.
 ***************************************************************************************************************************************************/
using System;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Formularios.Administracion;

namespace UNICAH.Formularios.Reportes
{
    public partial class frmReporteClasePeriodo : Form
    {
        private int? idPeriodo = null; //Almacena el id del periodo
        public frmReporteClasePeriodo()
        {
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario.
        private void frmReporteClasePeriodo_Load(object sender, EventArgs e)
        {
            //Definimos los márgenes de la página en 0
            var setup = rpvClasesPorPeriodo.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            rpvClasesPorPeriodo.SetPageSettings(setup);
        }

        //Método que se ejecuta al presionar el botón de buscar periodo
        private void btnBuscarPeriodo_Click(object sender, EventArgs e)
        {
            frmBuscarPeriodo frm = new frmBuscarPeriodo();
            frm.ShowDialog();

            idPeriodo = frm.idPeriodo;
            txtPeriodo.Text = frm.nombrePeriodo;
        }

        //Método que se ejecuta al cambiarse el texto del periodo
        private void txtPeriodo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'DsReportes.ClasesPeriodos' table. You can move, or remove it, as needed.
                this.ClasesPeriodosTableAdapter.Fill(this.DsReportes.ClasesPeriodos, Convert.ToInt32(idPeriodo));

                this.rpvClasesPorPeriodo.RefreshReport();
            }
            catch(Exception ex)
            {
                string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Mensajes.Error("Algo ha salido mal \n" + mensaje);
                Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
            }
            
        }
    }
}
