using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Endpoint.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion_Producto { get; set; }
        public DateTime Expiracion { get; set; }
        public int Id_Categoria { get; set; }
        public int Id_Marca { get; set; }
        public int Id_UnidadMedida { get; set; }

    }
}
