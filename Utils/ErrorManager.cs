using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Utils
{
    public class ErrorManager
    {
        public Exception ManejarExcepcionMySql(MySqlException ex)
        {
            switch (ex.Number)
            {
                case 1045:
                    return new Exception("Acceso denegado a la base de datos. Verifica las credenciales de acceso.", ex);
                case 1049:
                    return new Exception("Base de datos desconocida. Verifica el nombre de la base de datos.", ex);
                case 1051:
                    return new Exception("La tabla especificada no existe en la base de datos.", ex);
                case 1054:
                    return new Exception("Columna desconocida en la tabla. Verifica los nombres de las columnas.", ex);
                case 1062:
                    return new Exception("El registro ya existe en la base de datos. Violación de la clave única.", ex);
                case 1064:
                    return new Exception("Error de sintaxis en la consulta SQL. Verifica la sintaxis de la consulta.", ex);
                case 1136:
                    return new Exception("La cantidad de columnas no coincide con los valores proporcionados.", ex);
                case 1142:
                    return new Exception("Permisos insuficientes para ejecutar la consulta. Verifica los privilegios del usuario.", ex);
                case 1146:
                    return new Exception("La tabla especificada no existe en la base de datos.", ex);
                case 1149:
                    return new Exception("Sintaxis incorrecta en la consulta SQL.", ex);
                case 1216:
                    return new Exception("Error de clave foránea. Asegúrate de que las claves foráneas sean correctas.", ex);
                case 1217:
                    return new Exception("Error de eliminación de clave foránea. No se puede eliminar o actualizar una fila padre.", ex);
                case 1292:
                    return new Exception("Valor no válido para un campo. Verifica los valores que se están insertando.", ex);
                case 1364:
                    return new Exception("El campo no tiene un valor predeterminado. Proporcione un valor para el campo.", ex);
                case 1366:
                    return new Exception("Valor de campo incorrecto. El valor proporcionado no es compatible con el tipo de datos.", ex);
                case 1451:
                    return new Exception("Restricción de clave foránea falló en eliminación. No se puede eliminar una fila que está referenciada.", ex);
                case 1452:
                    return new Exception("Restricción de clave foránea falló en inserción. El valor de la clave foránea no coincide con ninguna fila en la tabla de referencia.", ex);
                case 1040:
                    return new Exception("Límite de conexiones a la base de datos alcanzado. No se pueden establecer más conexiones en este momento.", ex);
                case 1042:
                    return new Exception("No se puede conectar a la base de datos. Verifique el servidor o el nombre de host.", ex);
                default:
                    return new Exception("Ocurrió un error en la base de datos. Código de error: " + ex.Number + ". Mensaje: " + ex.Message, ex);
            }

        }
    }
}
