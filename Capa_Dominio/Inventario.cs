using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class Inventario
    {
        public int IdKardex { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
        public string Tipo { get; set; }
        public string Estado { get; set; }
        public double CostoUnitario { get; set; }
        public int Habia { get; set; }
        public int Hay { get; set; }
        public int IdCaja { get; set; }
    }
}
