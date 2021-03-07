using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Alias { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public int TipoCliente { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public byte[] Foto { get; set; }
        public string NombreFoto { get; set; }
        public string Dni { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
