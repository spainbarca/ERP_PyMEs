using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class Fabrica
    {
        public int IdFabrica { get; set; }
        public string NombreFabrica { get; set; }
        public string DescripcionFabrica { get; set; }
        public byte[] LogoFabrica { get; set; }
        public string NombreLogo { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
