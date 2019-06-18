using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Entities
{
    public class Producto
    {
        public int CodigoProducto { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodigoEmpaque { get; set; }
        public Categoria Categoria { get; set; }
        public TipoEmpaque TipoEmpaque { get; set; }
        public List<Inventario> Inventarios { get; set; }
        public List<DetalleCompra> DetalleCompras { get; set; }
        public List<DetalleFactura> DetalleFacturas { get; set; }
        public string Descripcion { get; set; }

    }
}
