using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public int IdFabrica { get; set; }
        public string NombreMarca { get; set; }
        public byte[] LogoMarca { get; set; }
        public string NombreLogo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
