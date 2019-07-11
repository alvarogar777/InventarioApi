using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class EmailClienteDTO
    {
        public int CodigoEmail { get; set; }
        public string email { get; set; }
        public string Nit { get; set; }
        public ClienteDTO Cliente { get; set; }
    }
}
