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
    public class ClientesController : ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;
        public ClientesController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
        {
            var clientes = await contexto.Clientes.ToListAsync();
            var clientesDTO = mapper.Map<List<ClienteDTO>>(clientes);
            return clientesDTO;
        }

        [HttpGet("{nit}", Name = "GetClientes")]
        public async Task<ActionResult<ClienteDTO>> Get(string nit)
        {
            var cliente = await contexto.Clientes.FirstOrDefaultAsync(x => x.Nit.Equals(nit));
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteDTO = mapper.Map<ClienteDTO>(cliente);
            return clienteDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteCreacion)
        {
            var cliente = mapper.Map<Cliente>(clienteCreacion);
            contexto.Add(cliente);
            await contexto.SaveChangesAsync();
            var clienteDTO = mapper.Map<ClienteDTO>(cliente);
            return new CreatedAtRouteResult("GetClientes", new { nit = cliente.Nit, dpi = cliente.Dpi, nombre = cliente.Nombre, direccion = cliente.Direccion },
                clienteDTO);
        }

        [HttpPut("{nit}")]
        public async Task<ActionResult> Put(string nit, [FromBody] ClienteCreacionDTO clienteActualizacion)
        {
            var cliente = mapper.Map<Cliente>(clienteActualizacion);
            cliente.Nit= nit;
            //cliente.Dpi = dpi;
            //cliente.Nombre = nombre;
            //cliente.Direccion = direccion;
            contexto.Entry(cliente).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{nit}")]
        public async Task<ActionResult<ClienteDTO>> Delete(string nit)
        {
            var nitCliente = await contexto.Clientes.Select(x => x.Nit)
                .FirstOrDefaultAsync(x => x == nit);
            if (nitCliente == default(string))
            {
                return NotFound();
            }
            contexto.Remove(new Cliente { Nit = nit });
            await contexto.SaveChangesAsync();
            return NoContent();


        }
    }
}
