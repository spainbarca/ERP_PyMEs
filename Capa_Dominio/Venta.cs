using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public string NumeroDoc { get; set; }
        public double Subtotal { get; set; }
        public double Descuento { get; set; }
        public double MontoTotal { get; set; }
        public int TipoPago { get; set; }
        public string Estado { get; set; }
        public string Boleta { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaPago { get; set; }
        public string Accion { get; set; }
        public double PagoParcial { get; set; }
        public double PorcIgv { get; set; }
        public int IdCaja { get; set; }
        public int ReferenciaTarjeta { get; set; }
        public double Efectivo { get; set; }
        public double Credito { get; set; }
        public double Tarjeta { get; set; }
    }
}
