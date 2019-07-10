using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using InventarioAPI.Contexts;
using InventarioAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventarioAPI.Models;


namespace InventarioAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TipoEmpaquesController : ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public TipoEmpaquesController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEmpaqueDTO>>> Get()
        {
            var tipoEmpaques = await contexto.TipoEmpaques.ToListAsync();
            var tipoEmpaquesDTO = mapper.Map<List<TipoEmpaqueDTO>>(tipoEmpaques);
            return tipoEmpaquesDTO;
        }

        [HttpGet("{id}", Name = "GetTipoEmpaques")]
        public async Task<ActionResult<TipoEmpaqueDTO>> Get(int id)
        {
            var tipoEmpaque = await contexto.TipoEmpaques.FirstOrDefaultAsync(x => x.CodigoEmpaque == id);
            if (tipoEmpaque == null)
            {
                return NotFound();
            }
            var tipoEmpaqueDTO = mapper.Map<TipoEmpaqueDTO>(tipoEmpaque);
            return tipoEmpaqueDTO;

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoEmpaqueCreacionDTO tipoEmpaqueCreacion)
        {
            var tipoEmpaque = mapper.Map<TipoEmpaque>(tipoEmpaqueCreacion);
            contexto.Add(tipoEmpaque);
            await contexto.SaveChangesAsync();
            var tipoEmpaqueDTO = mapper.Map<TipoEmpaqueDTO>(tipoEmpaque);
            return new CreatedAtRouteResult("GetTipoEmpaques", new { id = tipoEmpaque.CodigoEmpaque },
                tipoEmpaqueDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoEmpaqueCreacionDTO tipoEmpaqueActualizacion)
        {
            var tipoEmpaque = mapper.Map<TipoEmpaque>(tipoEmpaqueActualizacion);
            tipoEmpaque.CodigoEmpaque = id;
            contexto.Entry(tipoEmpaque).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TipoEmpaqueDTO>> Delete(int id)
        {
            var codigoEmpaque = await contexto.TipoEmpaques.Select(x => x.CodigoEmpaque)
                .FirstOrDefaultAsync(x => x == id);
            if (codigoEmpaque == default(int))
            {
                return NotFound();
            }
            contexto.Remove(new TipoEmpaque { CodigoEmpaque = id });
            await contexto.SaveChangesAsync();
            return NoContent();
        }
    }
}
