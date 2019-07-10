using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class ClienteCreacionDTO
    {
        public string Nit { get; set; }
        public string Dpi { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}
