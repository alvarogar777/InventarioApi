using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class FacturaDTO
    {
        public string Nit { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public ClienteDTO Cliente { get; set; }
    }
}
