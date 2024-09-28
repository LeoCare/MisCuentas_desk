using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Model
{
    public class Pais
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }


        private Pais(string codigo, string descripcion)
        {
            Codigo = codigo;
            Descripcion = descripcion;
        }

        public static readonly Pais Espana = new Pais("ES", "España");
        public static readonly Pais Estados_Unidos = new Pais("US", "Estados Unidos");
        public static readonly Pais Mexico = new Pais("MX", "México");
        public static readonly Pais Canada = new Pais("CA", "Canadá");
        public static readonly Pais Argentina = new Pais("AR", "Argentina");
        public static readonly Pais Brasil = new Pais("BR", "Brasil");
        public static readonly Pais Reino_Unido = new Pais("GB", "Reino Unido");
        public static readonly Pais Francia = new Pais("FR", "Francia");
        public static readonly Pais Alemania = new Pais("DE", "Alemania");
        public static readonly Pais Italia = new Pais("IT", "Italia");
        public static readonly Pais Japon = new Pais("JP", "Japón");
        public static readonly Pais China = new Pais("CN", "China");
        public static readonly Pais Australia = new Pais("AU", "Australia");
        public static readonly Pais India = new Pais("IN", "India");
        public static readonly Pais Rusia = new Pais("RU", "Rusia");
        public static readonly Pais Colombia = new Pais("CO", "Colombia");
        public static readonly Pais Peru = new Pais("PE", "Perú");
        public static readonly Pais Chile = new Pais("CL", "Chile");
        public static readonly Pais Ecuador = new Pais("EC", "Ecuador");
        public static readonly Pais Venezuela = new Pais("VE", "Venezuela");
        public static readonly Pais Uruguay = new Pais("UY", "Uruguay");
        public static readonly Pais Paraguay = new Pais("PY", "Paraguay");
        public static readonly Pais Bolivia = new Pais("BO", "Bolivia");
        public static readonly Pais Costa_Rica = new Pais("CR", "Costa Rica");
        public static readonly Pais Panama = new Pais("PA", "Panamá");
        public static readonly Pais Puerto_Rico = new Pais("PR", "Puerto Rico");
        public static readonly Pais Republica_Dominicana = new Pais("DO", "República Dominicana");
        public static readonly Pais Guatemala = new Pais("GT", "Guatemala");
        public static readonly Pais Honduras = new Pais("HN", "Honduras");
        public static readonly Pais El_Salvador = new Pais("SV", "El Salvador");
        public static readonly Pais Nicaragua = new Pais("NI", "Nicaragua");
        public static readonly Pais Suecia = new Pais("SE", "Suecia");
        public static readonly Pais Noruega = new Pais("NO", "Noruega");
        public static readonly Pais Suiza = new Pais("CH", "Suiza");
        public static readonly Pais Portugal = new Pais("PT", "Portugal");
        public static readonly Pais Belgica = new Pais("BE", "Bélgica");
        public static readonly Pais Paises_Bajos = new Pais("NL", "Países Bajos");
        public static readonly Pais Irlanda = new Pais("IE", "Irlanda");
        public static readonly Pais Nueva_Zelanda = new Pais("NZ", "Nueva Zelanda");
        public static readonly Pais Sudafrica = new Pais("ZA", "Sudáfrica");

        public static readonly IReadOnlyList<Pais> Todos = new List<Pais>
        {
            Espana,
            Estados_Unidos,
            Mexico,
            Canada,
            Argentina,
            Brasil,
            Reino_Unido,
            Francia,
            Alemania,
            Italia,
            Japon,
            China,
            Australia,
            India,
            Rusia,
            Colombia,
            Peru,
            Chile,
            Ecuador,
            Venezuela,
            Uruguay,
            Paraguay,
            Bolivia,
            Costa_Rica,
            Panama,
            Puerto_Rico,
            Republica_Dominicana,
            Guatemala,
            Honduras,
            El_Salvador,
            Nicaragua,
            Suecia,
            Noruega,
            Suiza,
            Portugal,
            Belgica,
            Paises_Bajos,
            Irlanda,
            Nueva_Zelanda,
            Sudafrica
        };

        public override string ToString()
        {
            return Descripcion.ToString();
        }
    }
}
