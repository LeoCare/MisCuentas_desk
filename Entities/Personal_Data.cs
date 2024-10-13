using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Entities
{
    public class Personal_Data
    {
        public int Id_Usuario {  get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get;  set; }
        public string Direccion {  get; set; }
        public string Pais {  get; set; }
        public string Telefono { get; set;}

        // Constructor sin parámetros
        public Personal_Data() { }

        // Constructor con parámetros
        public Personal_Data(int id_Usuario, string nombre, string apellidos, string direccion, string pais, string telefono)
        {
            Id_Usuario = id_Usuario;
            Nombre = nombre;
            Apellidos = apellidos;
            Direccion = direccion;
            Pais = pais;
            Telefono = telefono;
        }
    }

    
}
