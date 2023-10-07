using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Nombre_Empresa { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set;}
        public string CorreoElectronico { get; set; }
    }
}
