using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class DetalleVenta
    {
        public int IdVenta { get; set; }
        public int IdDetalleVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public string Moneda { get; set; }
        public string UnidadMedida { get; set; }
        public int CantidadMostrada { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public int Stock { get; set; }
        public string Unidades { get; set; }
        public string UsaInventario { get; set; }
        public double Costo { get; set; }
        public double PrecioMayor { get; set; }
        public int CantidadMayor { get; set; }
        public double PrecioVenta { get; set; }
        public string Nivel { get; set; }
    }
}
