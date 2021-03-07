using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public byte[] Logo { get; set; }
        public string NombreLogo { get; set; }
        public string Direccion { get; set; }
        public string Anexo { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Rubro { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Ruc { get; set; }
        public string Vendedor { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
