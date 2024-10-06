using System.Text.RegularExpressions;


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

        /// <summary>
        /// Metodo que valida el importe introducido con dos decimales maximo.
        /// </summary>
        /// <param name="texto">Importe introducido</param>
        /// <returns>true si es correcto o false en caso contrario</returns>
        public static bool EsNumeroConDosDecimales(string texto)
        {
            // Intentar convertir el texto a un número decimal
            decimal numero;
            if (decimal.TryParse(texto, out numero))
            {
                // Obtener la parte decimal del número
                int[] bits = decimal.GetBits(numero);
                int exponent = (bits[3] >> 16) & 31;

                // Verificar si el número de decimales es menor o igual a 2
                if (exponent <= 2)
                {
                    return true; 
                }
            }
            return false; 
        }
    }
}
