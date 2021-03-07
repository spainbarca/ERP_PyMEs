using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Genero { get; set; }
        public int Rol { get; set; }
        public string Correo { get; set; }
        public byte[] Icono { get; set; }
        public string NombreIcono { get; set; }
        public string User { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }

        //public Usuario() { }
    }
}
