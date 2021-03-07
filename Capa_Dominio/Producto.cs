using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public byte[] ImagenProducto { get; set; }
        public string NombreImagen { get; set; }
        public int IdCategoria { get; set; }
        public int IdSubcategoria { get; set; }
        public int IdMarca { get; set; }
        public string UsaInventario { get; set; }
        public int Stock { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public string FechaVencimiento { get; set; }
        public string Codigo { get; set; }
        public double PrecioMayor { get; set; }
        public int CantidadMayor { get; set; }
        public double Impuesto { get; set; }
        public int StockMinimo { get; set; }
        public string TipoProducto { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double Total { get; set; }
    }
}
