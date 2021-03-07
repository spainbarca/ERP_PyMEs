using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capa_Dominio
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public byte[] Logo { get; set; }
        public string Impuesto { get; set; }
        public double PorcImpuesto { get; set; }
        public string Moneda { get; set; }
        public string Trabaja { get; set; }
        public string ModoBusqueda { get; set; }
        public string CarpetaBackup { get; set; }
        public string CorreoReportes { get; set; }
        public DateTime UltimaFecha { get; set; }
        public int Frecuencia { get; set; }
        public string Estado { get; set; }
        public string TipoEmpresa { get; set; }
        public string Pais { get; set; }
        public string Redondeo { get; set; }
    }
}
