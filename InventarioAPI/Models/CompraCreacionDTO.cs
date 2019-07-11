using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Models
{
    public class CompraCreacionDTO
    {
        public int NumeroDocumento { get; set; }
        public int CodigoProveedor { get; set; }
        public DateTime dateTime { get; set; }
        public decimal Total { get; set; }

    }
}
