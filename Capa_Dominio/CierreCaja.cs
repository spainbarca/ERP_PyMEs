using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class CierreCaja
    {
        public int IdCierreCaja { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaCierre { get; set; }
        public double Ingresos { get; set; }
        public double Egresos { get; set; }
        public double Saldo { get; set; }
        public int IdUsuario { get; set; }
        public double TotalReal { get; set; }
        public string Estado { get; set; }
        public double Diferencia { get; set; }
        public int IdCaja { get; set; }
    }
}
