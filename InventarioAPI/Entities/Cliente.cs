using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class Cliente
    {
        public int Nit { get; set; }
        public string Dpi { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public List<Factura> Facturas { get; set; }
        public List<Emailcliente> Emailclientes { get; set; }
        public List<TelefonoCliente> TelefonoClientes { get; set; }
    }
}
