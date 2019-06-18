using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class Factura
    {
        public int Numerofactura { get; set; }
        public string Nit { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public List<DetalleFactura> DetalleFacturas { get; set; }

        public Cliente Cliente { get; set; }
    }
}
