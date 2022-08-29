/***************************************************************************************************************************************************
 * Formulario: frmAsignarAula
 * Namespace : UNICAH.Formularios.Administracion
 * Descripción: Formulario para asignar una clase a una aula, maestro y periodo.
 ***************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using UNICAH.Clases;
using UNICAH.Modelo;

namespace UNICAH.Formularios.Administracion
{
    public partial class frmAsignarClases : Form
    {
        private int? idClase = null; //Almacena el id de la clase
        private int? idPeriodo = null; //Almacena el id del periodo
        private int? idMaestro = null; //Almacena el id del maestro
        private int? idAula = null; //Almacena el id del aula

        public frmAsignarClases()
        {
            InitializeComponent();
        }

        //Método que se ejecuta al iniciar el formulario
        private void frmAsignarClases_Load(object sender, EventArgs e)
        {
            //Seteamos los DateTimePicker a formato solo de hora
            DateTime hora = DateTime.Now.Date.Add(new TimeSpan(7, 00, 0));
            dtpHoraInicio.Format = DateTimePickerFormat.Custom;
            dtpHoraInicio.CustomFormat = "HH:mm";
            dtpHoraInicio.Value = hora;

            dtpHoraFin.Format = DateTimePickerFormat.Custom;
            dtpHoraFin.CustomFormat = "HH:mm";
            dtpHoraFin.Value = hora;

            refrescarGrid();
        }

        //Método que se ejecuta al presionar el botón de buscar clase
        private void btnBuscarClase_Click(object sender, EventArgs e)
        {
            frmBuscarClase frm = new frmBuscarClase("ACT");
            frm.ShowDialog();

            txtClase.Text = frm.nombreClase;
            idClase = frm.idclase;
        }

        //Método que se ejecuta al presionar el botón de buscar periodo
        private void btnBuscarPeriodo_Click(object sender, EventArgs e)
        {
            frmBuscarPeriodo frm = new frmBuscarPeriodo("ACT");
            frm.ShowDialog();

            txtPeriodo.Text = frm.nombrePeriodo;
            idPeriodo = frm.idPeriodo;
        }

        //Método que se ejecuta al presionar el botón de buscar maestro
        private void btnBuscarMaestro_Click(object sender, EventArgs e)
        {
            frmBuscarMaestro frm = new frmBuscarMaestro("ACT");
            frm.ShowDialog();

            txtMaestro.Text = frm.nombreMaestro;
            idMaestro = frm.idMaestro;
        }

        //Método que se ejecuta al presionar el botón de buscar aula
        private void btnBuscarAula_Click(object sender, EventArgs e)
        {
            frmBuscarAula frm = new frmBuscarAula("ACT");
            frm.ShowDialog();

            txtAula.Text = frm.codigoAula;
            idAula = frm.idAula;
        }

        //Método que se ejecuta al presionar el botón de guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<int> dias = diasSeleccionados();

            if (idPeriodo == null)
                Mensajes.Advertencia("Por favor seleccione un periodo.");
            else if (idClase == null)
                Mensajes.Advertencia("Por favor seleccione una clase.");
            else if (idMaestro == null)
                Mensajes.Advertencia("Por favor seleccione un maestro.");
            else if (idAula == null)
                Mensajes.Advertencia("Por favor seleccione una aula.");
            else if(dtpHoraInicio.Value.TimeOfDay >= dtpHoraFin.Value.TimeOfDay)
                Mensajes.Advertencia("La hora de inicio debe ser menor a la hora final.");
            else if (dias.Count == 0)
                Mensajes.Advertencia("Debe seleccionar al menos un día.");
            else
            {
                try
                {
                    using (UnicahEntities db = new UnicahEntities())
                    {
                        //Verificar disponibilidad del aula
                        var query = from a in db.Aulas
                                    join cp in db.ClasePeriodo on a.Id equals cp.FkAulaId
                                    join m in db.Maestros on cp.FKMaestroId equals m.Id
                                    join c in db.Clases on cp.FKClaseId equals c.Id
                                    join cd in db.ClaseDia on cp.Id equals cd.FkClasePeriodoId
                                    join d in db.Dias on cd.FkDiaId equals d.Id
                                    where cp.FKPeriodoId == idPeriodo //filtro resultados por periodo
                                         && a.Id == idAula //filtro resultados por aula
                                    select new
                                    {
                                        cp.HoraInicio,
                                        cp.HoraFin,
                                        ClaseCodigo = c.Codigo,
                                        ClaseNombre = c.Nombre,
                                        DiaId = d.Id,
                                        Maestro = m.Nombre,
                                        MaestroId = m.Id,
                                        Aula = a.Numero,
                                        cp.Dias,
                                        d.Dia
                                    };

                        foreach (var dia in dias)
                        {
                            foreach (var item in query)
                            {
                                if (dia == item.DiaId)
                                {
                                    //Si las horas ingresadas estan en rango o interfieren con las horas ocupadas, entra en una excepción controlada.
                                    if (horaEstaEnRango(item.HoraInicio, item.HoraFin, dtpHoraInicio.Value.TimeOfDay)
                                            || horaEstaEnRango(item.HoraInicio, item.HoraFin, dtpHoraFin.Value.TimeOfDay)
                                                || dtpHoraInicio.Value.TimeOfDay <= item.HoraInicio && dtpHoraFin.Value.TimeOfDay >= item.HoraFin)
                                    {
                                        string mensaje = $"El aula esta ocupada por la clase de {item.ClaseNombre} {item.ClaseCodigo} el día " +
                                        $"{item.Dia}, en horario de {item.HoraInicio} a {item.HoraFin}, impartida por {item.Maestro}" +
                                        $"\nDías de clase: {item.Dias}";

                                        throw new InvalidOperationException(mensaje);

                                    }
                                }
                            }
                        }

                        //Verificar disponibilidad del maestro
                        var query2 = from m in db.Maestros
                                    join cp in db.ClasePeriodo on m.Id equals cp.FKMaestroId
                                    join cd in db.ClaseDia on cp.Id equals cd.FkClasePeriodoId
                                    join d in db.Dias on cd.FkDiaId equals d.Id
                                    join c in db.Clases on cp.FKClaseId equals c.Id
                                    join a in db.Aulas on cp.FkAulaId equals a.Id
                                    where cp.FKPeriodoId == idPeriodo //filtro resultados por periodo
                                        && m.Id == idMaestro //filtro resultados por maestro
                                    select new
                                    {
                                        cp.HoraInicio,
                                        cp.HoraFin,
                                        ClaseCodigo = c.Codigo,
                                        ClaseNombre = c.Nombre,
                                        DiaId = d.Id,
                                        Aula = a.Numero,
                                        d.Dia,
                                        cp.Dias,
                                        Maestro = m.Nombre,
                                        MaestroId = m.Id
                                    };

                        foreach (var dia in dias)
                        {
                            foreach (var item in query2)
                            {
                                if (item.DiaId == dia)
                                {
                                    //Si las horas ingresadas estan en rango o interfieren con las horas ocupadas, cae en una excepción controlada.
                                    if (horaEstaEnRango(item.HoraInicio, item.HoraFin, dtpHoraInicio.Value.TimeOfDay)
                                            || horaEstaEnRango(item.HoraInicio, item.HoraFin, dtpHoraFin.Value.TimeOfDay)
                                                || dtpHoraInicio.Value.TimeOfDay <= item.HoraInicio && dtpHoraFin.Value.TimeOfDay >= item.HoraFin)
                                    {
                                        string mensaje = $"El aula esta ocupada por la clase de {item.ClaseNombre} {item.ClaseCodigo} el día " +
                                        $"{item.Dia}, en horario de {item.HoraInicio} a {item.HoraFin}, impartida por {item.Maestro}" +
                                        $"\nDías de clase: {item.Dias}";

                                        throw new InvalidOperationException(mensaje);

                                    }
                                }
                            }
                        }

                        //Aqui pasa todas las validaciones
                        ClasePeriodo clasePeriodo = new ClasePeriodo
                        {
                            HoraInicio = dtpHoraInicio.Value.TimeOfDay,
                            HoraFin = dtpHoraFin.Value.TimeOfDay,
                            FKClaseId = Convert.ToInt32(idClase),
                            FKMaestroId = Convert.ToInt16(idMaestro),
                            FKPeriodoId = Convert.ToInt32(idPeriodo),
                            FkAulaId = Convert.ToInt16(idAula),
                            Dias = obtenerNombreDiasSeleccionados()
                        };


                        db.ClasePeriodo.Add(clasePeriodo);
                        db.SaveChanges();

                        foreach(var dia in dias)
                        {
                            ClaseDia claseDia = new ClaseDia
                            {
                                FkClasePeriodoId = clasePeriodo.Id,
                                FkDiaId = Convert.ToByte(dia)
                            };

                            db.ClaseDia.Add(claseDia);
                            db.SaveChanges();
                        }

                        limpiarCampos();
                        refrescarGrid();
                        Mensajes.Exitoso("Se ha asignado la clase exitosamente.");



                    }
                }catch(Exception ex)
                {
                    if (ex is InvalidOperationException)
                    {
                        Mensajes.Advertencia(ex.Message);
                        return;
                    }

                    string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                    Mensajes.Error("Algo ha salido mal \n" + mensaje);
                    Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
                    logs = null;
                }
            }
        }

        //Método para obtener los registros de la db y llenar el grid
        private void refrescarGrid()
        {
            try
            {
                using (UnicahEntities db = new UnicahEntities())
                {
                    var query = from cp in db.ClasePeriodo
                                join c in db.Clases on cp.FKClaseId equals c.Id
                                join m in db.Maestros on cp.FKMaestroId equals m.Id
                                join p in db.Periodos on cp.FKPeriodoId equals p.Id
                                join a in db.Aulas on cp.FkAulaId equals a.Id
                                where (
                                    c.Nombre.Contains(txtBuscar.Text)
                                        || c.Codigo.Contains(txtBuscar.Text)
                                            ||p.Descripcion.Contains(txtBuscar.Text)
                                                ||m.Nombre.Contains(txtBuscar.Text)
                                                    ||a.Numero.Contains(txtBuscar.Text)
                                )
                                orderby cp.Id descending
                                select new
                                {
                                    ID = cp.Id,
                                    Aula = a.Numero,
                                    Código = c.Codigo,
                                    Clase = c.Nombre,
                                    Maestro = m.Nombre,
                                    Días = cp.Dias,
                                    Inicio = cp.HoraInicio,
                                    Final = cp.HoraFin,
                                    Período = p.Descripcion
                                };

                    dgvClases.DataSource = query.ToList();
                }

            }
            catch(Exception ex)
            {
                string mensaje = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                Mensajes.Error("Algo ha salido mal \n" + mensaje);
                Utilidades.Logs logs = new Utilidades.Logs(mensaje + "\n" + ex.StackTrace);
                logs = null;
            }
        }

        //Método para obtener los ids de los dias seleccionados
        private List<int> diasSeleccionados()
        {
            List<int> dias = new List<int>();
            if (chbLunes.Checked)
            {
                dias.Add(1);
            }
            if (chbMartes.Checked)
            {
                dias.Add(2);
            }
            if (chbMiercoles.Checked)
            {
                dias.Add(3);
            }
            if (chbJueves.Checked)
            {
                dias.Add(4);
            }
            if (chbViernes.Checked)
            {
                dias.Add(5);
            }
            if (chbSabado.Checked)
            {
                dias.Add(6);
            }

            return dias;

        }

        //Método para obtener los nombres de los dias seleccionados
        private string obtenerNombreDiasSeleccionados()
        {
            string dias = "";
            if (chbLunes.Checked)
            {
                dias += "Lun ";
            }
            if (chbMartes.Checked)
            {
                dias += "Mar ";
            }
            if (chbMiercoles.Checked)
            {
                dias += "Mie ";
            }
            if (chbJueves.Checked)
            {
                dias += "Jue ";
            }
            if (chbViernes.Checked)
            {
                dias += "Vie ";
            }
            if (chbSabado.Checked)
            {
                dias += "Sab ";
            }

            return dias;
        }

        //Método para limpiar los campos
        private void limpiarCampos()
        {
            txtAula.Clear();
            idAula = null;
            txtClase.Clear();
            idClase = null;
            txtMaestro.Clear();
            idMaestro = null;
            txtPeriodo.Clear();
            idPeriodo = null;

            chbLunes.Checked = false;
            chbMartes.Checked = false;
            chbMiercoles.Checked = false;
            chbJueves.Checked = false;
            chbViernes.Checked = false;
            chbSabado.Checked = false;
        }

        //Método para verificar si una dos horas interfieren en un rango
        private bool horaEstaEnRango(TimeSpan inicio, TimeSpan final, TimeSpan valor)
        {
            return (valor >= inicio) && (valor <= final);
        }

        //Método que se ejecuta al presionar el botón de buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            refrescarGrid();
        }

        //Método que se ejecuta al presionar el botón de restaurar
        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            refrescarGrid();
        }

        //Método que se ejecuta al hacer doble click en una fila del data grid
        private void dgvClases_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idClase = Convert.ToInt32(dgvClases.CurrentRow.Cells[0].Value);
            string aula = dgvClases.CurrentRow.Cells[1].Value.ToString();
            string codigoClase = dgvClases.CurrentRow.Cells[2].Value.ToString();
            string nombreClase = dgvClases.CurrentRow.Cells[3].Value.ToString();
            string maestro = dgvClases.CurrentRow.Cells[4].Value.ToString();
            string dias = (dgvClases.CurrentRow.Cells[5].Value == null) ? "" : dgvClases.CurrentRow.Cells[5].Value.ToString();
            TimeSpan horaInicio = (TimeSpan)dgvClases.CurrentRow.Cells[6].Value;
            TimeSpan horaFinal = (TimeSpan)dgvClases.CurrentRow.Cells[7].Value;
            string periodo = dgvClases.CurrentRow.Cells[8].Value.ToString();

            string mensaje = $"Detalles de la clase\nAula: {aula}\nClase: " +
                $"{codigoClase} {nombreClase}\nMaestro: {maestro}\nDías: {dias}\nHorario: " +
                $"{horaInicio} - {horaFinal}\nPeríodo: {periodo}";

            DialogResult dialogoConfirmacion = MessageBox.Show(mensaje,"Está seguro que desea eliminar esta clase?", MessageBoxButtons.YesNo);

            if (dialogoConfirmacion == DialogResult.Yes)
            {
                try
                {
                    using (UnicahEntities db = new UnicahEntities())
                    {
                        var clase = db.ClasePeriodo.FirstOrDefault(a => a.Id == idClase);

                        db.ClasePeriodo.Remove(clase);
                        db.SaveChanges();
                        refrescarGrid();
                        Mensajes.Exitoso("Clase eliminada exitosamente.");
                    }
                }
                catch(Exception ex)
                {
                    string mensaje2 = (ex.InnerException != null) ? ex.InnerException.Message : ex.Message;
                    Mensajes.Error("Algo ha salido mal \n" + mensaje2);
                    Utilidades.Logs logs = new Utilidades.Logs(mensaje2 + "\n" + ex.StackTrace);
                }
            }
        }
    }
}
