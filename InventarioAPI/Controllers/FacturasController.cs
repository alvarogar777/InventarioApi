using AutoMapper;
using InventarioAPI.Contexts;
using InventarioAPI.Entities;
using InventarioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventarioAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public FacturasController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturaDTO>>> Get()
        {
            var facturas = await contexto.Facturas.ToListAsync();
            var facturasDTO = mapper.Map<List<FacturaDTO>>(facturas);
            return facturasDTO;
        }

        [HttpGet("{id}", Name = "GetFactura")]
        public async Task<ActionResult<FacturaDTO>> Get(int id)
        {
            var factura = await contexto.Facturas.FirstOrDefaultAsync(x => x.Numerofactura.Equals(id));
            if (factura == null)
            {
                return NotFound();
            }
            var facturaDTO = mapper.Map<FacturaDTO>(factura);
            return facturaDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FacturaCreacionDTO facturaCreacion)
        {
            var factura = mapper.Map<Factura>(facturaCreacion);
            contexto.Add(factura);
            await contexto.SaveChangesAsync();
            var facturaDTO = mapper.Map<FacturaDTO>(factura);
            return new CreatedAtRouteResult("GetFactura", new { id = factura.Numerofactura },
                facturaDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FacturaCreacionDTO facturaActualizacion)
        {
            var factura = mapper.Map<Factura>(facturaActualizacion);
            factura.Numerofactura = id;
            contexto.Entry(factura).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FacturaDTO>> Delete(int id)
        {
            var numeroFactura = await contexto.Facturas.Select(x => x.Numerofactura)
                .FirstOrDefaultAsync(x => x == id);
            if (numeroFactura == default(int))
            {
                return NotFound();
            }
            contexto.Remove(new Factura { Numerofactura = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
