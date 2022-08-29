/***************************************************************************************************************************************************
 * Formulario: Clases
 * Namespace : UNICAH.Clases
 * Descripción: Clase para la encriptación de la contraseña.
 ***************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UNICAH.Clases
{
    static class Hash256
    {
        //Generar una cadena encriptada Hash256
        public static string obtenerHash256(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashString = new SHA256Managed();

            byte[] hash = hashString.ComputeHash(bytes);
            string hashStr = string.Empty;

            foreach (byte x in hash)
            {
                hashStr += String.Format("{0:x2}", x);
            }

            return hashStr;

        }
    }
}
