using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Entities
{
    public class Usuario
    {
        private static Usuario instancia = null;

        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public string Perfil { get; set; }

        public Personal_Data Personal_Data { get; set; }

        // Constructor sin parámetros
        public Usuario() { }

        // Constructor con parámetros
        public Usuario(string nombre, string correo, string contrasenna, string perfil ) 
        { 
            Nombre = nombre;
            Correo = correo;
            Contrasenna = contrasenna;
            Perfil = perfil;
        }

        // Método estático para obtener la instancia
        public static Usuario ObtenerInstancia(Usuario usuario)
        {
            if (instancia == null)
            {
                instancia = usuario;
            }
            return instancia;
        }
    }


}
