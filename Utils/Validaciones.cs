using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MisCuentas_desk.Utils
{
    public static class Validaciones
    {
        /// <summary>
        /// Metodo que valida la sintaxis del Email, gracias al uso de expresiones regulares
        /// </summary>
        /// <param name="strEmail">email introducido por el usuario</param>
        /// <returns>true -> es correcto o false en caso contrario</returns>
        public static bool ValidaEmail(string strEmail)
        {
            try
            {
                /* Uso una expresion regular para verificar la sintaxis:
                 * Requisitos:
                 * Cualquier valor que no contenga un simbolo ni espacio en blanco.
                 * Luego debe contener un @
                 * Posteriormete a este, se usa la misma expresion que en el inicio.
                 * Seguido de un punto.
                 * Y por ultimo, nuevamente la expresion inicial. 
                 */
                Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
                return regex.IsMatch(strEmail);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        /// <summary>
        /// Metodo que valida la contraseña. Este es un metodo mas robusto.
        /// </summary>
        /// <param name="strPass">contraseña introducida por el usuario</param>
        /// <returns>true -> si cumple los requisitos o false en caso contrario</returns>
        public static bool ValidaPass(string strPass)
        {

            /* Expresión regular para validar la contraseña:
            * Requisitos:
            * Mínimo 6 caracteres, máximo 15
            * Al menos una letra mayúscula
            * Al menos una letra minúscula
            * Al menos un número
            */
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,15}$";

            try
            {
                Regex regex = new Regex(pattern);
                return regex.IsMatch(strPass);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
