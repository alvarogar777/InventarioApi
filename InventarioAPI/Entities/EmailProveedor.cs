using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class EmailProveedor
    {
        public int CodigoEmail { get; set; }
        public string Email { get; set; }
        public int CodigoProveedor { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
