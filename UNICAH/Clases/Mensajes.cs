/***************************************************************************************************************************************************
 * Clase: Mensajes
 * Namespace : UNICAH.Clases
 * Descripción: Clase estática para mostrar mensajes de validación a los usuarios
 ***************************************************************************************************************************************************/
using System.Windows.Forms;

namespace UNICAH.Clases
{
    static class Mensajes
    {
        //Método muestra un mensaje de operación exitosa
        public static void Exitoso(string mensaje)
        {
            MessageBox.Show(mensaje, "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Método muestra un mensaje de operación no válida
        public static void Advertencia(string mensaje)
        {
            MessageBox.Show(mensaje, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Método muestra un mensaje de error
        public static void Error(string mensaje)
        {
            MessageBox.Show(mensaje, "Error fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
