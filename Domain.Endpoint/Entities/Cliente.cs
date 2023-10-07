using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Primer_Nombre { get; set; }
        public string  Segundo_Nombre { get; set; }
        public string Primer_Apellido { get; set; }
        public string Segundo_Apellido { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
    }
}
