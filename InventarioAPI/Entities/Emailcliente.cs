using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class Emailcliente
    {
        public int CodigoEmail { get; set; }
        public string email { get; set; }
        public string Nit { get; set; }
        public Cliente Cliente { get; set; }
    }
}
