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
    public class TelefonoProveedoresController : ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;
        public TelefonoProveedoresController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelefonoProveedorDTO>>> Get()
        {
            var telefonoProveedor = await contexto.TelefonoProveedores.ToListAsync();
            var telefonoProveedoresDTO = mapper.Map<List<TelefonoProveedorDTO>>(telefonoProveedor);
            return telefonoProveedoresDTO;
        }

        [HttpGet("{id}", Name = "GetTelefonoProveedor")]
        public async Task<ActionResult<TelefonoProveedorDTO>> Get(int id)
        {
            var telefonoProveedor = await contexto.TelefonoProveedores.FirstOrDefaultAsync(x => x.CodigoTelefono.Equals(id));
            if (telefonoProveedor == null)
            {
                return NotFound();
            }
            var telefonoProveedorDTO = mapper.Map<TelefonoProveedorDTO>(telefonoProveedor);
            return telefonoProveedorDTO;
        }
    }
}
