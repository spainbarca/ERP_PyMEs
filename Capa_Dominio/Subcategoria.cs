using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class Subcategoria
    {
        public int IdSubcategoria { get; set; }
        public int IdCategoria { get; set; }
        public string NombreSubcategoria { get; set; }
        public string DescripcionSubcategoria { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
