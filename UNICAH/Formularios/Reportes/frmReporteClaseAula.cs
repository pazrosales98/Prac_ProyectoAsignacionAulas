/***************************************************************************************************************************************************
 * Formulario: frmReporteClaseAula
 * Namespace : UNICAH.Formularios.Reportes
 * Descripción: Formulario para la generación del reporte de clases por aula.
 ***************************************************************************************************************************************************/
using System;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Formularios.Administracion;

namespace UNICAH.Formularios.Reportes
{
    public partial class frmReporteClaseAula : Form
    {
        private int? idPeriodo = null; //variable para almacenar el id el periodo
        private short? idAula = null; // variable para almacenar el id del aula
        public frmReporteClaseAula()
        {
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario.
        private void frmReporteClaseAula_Load(object sender, EventArgs e)
        {
            //Definimos los márgenes de la página en 0
            var setup = rpvClasesPorAula.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            rpvClasesPorAula.SetPageSettings(setup);

        }

        //Método para llenar reporte
        private void llenarReporte()
        {
            if (idPeriodo != null && idAula != null)
            {
                // TODO: This line of code loads data into the 'DsReportes.ClasesAulas' table. You can move, or remove it, as needed.
                try
                {
                    this.ClasesAulasTableAdapter.Fill(this.DsReportes.ClasesAulas, Convert.ToInt32(idPeriodo), Convert.ToInt16(idAula));
                    this.rpvClasesPorAula.RefreshReport();
                }
                catch(Exception ex)
                {
                    string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                    Mensajes.Error("Algo ha salido mal \n" + mensaje);
                    Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
                }
               
            }
        }

        //Método que se ejecuta al presionar el botón de buscar periodo
        private void btnBuscarPeriodo_Click(object sender, EventArgs e)
        {
            frmBuscarPeriodo frm = new frmBuscarPeriodo();
            frm.ShowDialog();

            idPeriodo = frm.idPeriodo;
            txtPeriodo.Text = frm.nombrePeriodo;
        }

        //Método que se ejecuta al presionar el botón de buscar aula
        private void btnBuscarAula_Click(object sender, EventArgs e)
        {
            frmBuscarAula frm = new frmBuscarAula();
            frm.ShowDialog();

            idAula = Convert.ToInt16(frm.idAula);
            txtAula.Text = frm.codigoAula;

        }

        //Método que se ejecuta al cambiarse el texto del periodo
        private void txtPeriodo_TextChanged(object sender, EventArgs e)
        {
            llenarReporte();
        }

        //Método que se ejecuta al cambiarse el texto del aula
        private void txtAula_TextChanged(object sender, EventArgs e)
        {
            llenarReporte();
        }
    }
}
