/***************************************************************************************************************************************************
 * Formulario: frmReporteClaseMaestro
 * Namespace : UNICAH.Formularios.Reportes
 * Descripción: Formulario para la generación del reporte de clases por maestro.
 ***************************************************************************************************************************************************/
using System;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Formularios.Administracion;

namespace UNICAH.Formularios.Reportes
{
    public partial class frmReporteClasesMaestros : Form
    {
        private int? idPeriodo = null; //variable para almacenar el id el periodo
        private short? idMaestro = null;//variable para almacenar el id del maestro
        public frmReporteClasesMaestros()
        {
            InitializeComponent();
        }

        //Método que se ejecuta al cargar el formulario.
        private void frmReporteClasesMaestros_Load(object sender, EventArgs e)
        {
            //Definimos los márgenes de la página en 0
            var setup = rptClasesMaestros.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            rptClasesMaestros.SetPageSettings(setup);
            
        }

        //Método para llenar el reporte
        private void llenarReporte()
        {
            if (idPeriodo != null && idMaestro != null)
            {
                try
                {
                    // TODO: This line of code loads data into the 'DsReportes.ClasesPeriodos' table. You can move, or remove it, as needed.
                    this.ClasesMaestroTableAdapter.Fill(this.DsReportes.ClasesMaestro, Convert.ToInt32(idPeriodo), Convert.ToInt16(idMaestro));

                    this.rptClasesMaestros.RefreshReport();
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
            frmBuscarMaestro frm = new frmBuscarMaestro();
            frm.ShowDialog();

            idMaestro = Convert.ToInt16(frm.idMaestro);
            txtMaestro.Text = frm.nombreMaestro;
        }

        //Método que se ejecuta al cambiarse el texto del periodo
        private void txtPeriodo_TextChanged(object sender, EventArgs e)
        {
            llenarReporte();
        }
        //Método que se ejecuta al cambiarse el texto del maestro
        private void txtMaestro_TextChanged(object sender, EventArgs e)
        {
            llenarReporte();
        }
    }
}
