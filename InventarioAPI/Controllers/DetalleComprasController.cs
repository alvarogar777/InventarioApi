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
    public class DetalleComprasController : ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public DetalleComprasController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleCompraDTO>>> Get()
        {
            var detalleCompra = await contexto.DetalleCompras.ToListAsync();
            var detalleCompraDTO = mapper.Map<List<DetalleCompraDTO>>(detalleCompra);
            return detalleCompraDTO;
        }

        [HttpGet("{id}", Name = "GetDetalleProducto")]
        public async Task<ActionResult<DetalleCompraDTO>> Get(int id)
        {
            var detalleCompra = await contexto.DetalleCompras.FirstOrDefaultAsync(x => x.IdDetalle.Equals(id));
            if (detalleCompra == null)
            {
                return NotFound();
            }
            var detalleCompraDTO = mapper.Map<DetalleCompraDTO>(detalleCompra);
            return detalleCompraDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetalleCompraCreacionDTO detalleCompraCreacion)
        {
            var detalleCompra = mapper.Map<DetalleCompra>(detalleCompraCreacion);
            contexto.Add(detalleCompra);
            await contexto.SaveChangesAsync();
            var detalleCompraDTO = mapper.Map<DetalleCompraDTO>(detalleCompra);
            return new CreatedAtRouteResult("GetDetalleProducto", new { id = detalleCompra.IdDetalle},
                detalleCompraDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetalleCompraCreacionDTO detalleCompraActualizacion)
        {
            var detalleCompra = mapper.Map<DetalleCompra>(detalleCompraActualizacion);
            detalleCompra.IdDetalle = id;
            contexto.Entry(detalleCompra).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DetalleCompraDTO>> Delete(int id)
        {
            var idDetalle = await contexto.DetalleCompras.Select(x => x.IdDetalle)
                .FirstOrDefaultAsync(x => x == id);
            if (idDetalle == default(int))
            {
                return NotFound();
            }
            contexto.Remove(new DetalleCompra { IdDetalle = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
