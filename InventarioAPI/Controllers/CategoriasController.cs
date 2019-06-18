﻿using AutoMapper;
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
    public class CategoriasController : ControllerBase
    {
        private readonly InventarioDBContext contexto;
        private readonly IMapper mapper;

        public CategoriasController(InventarioDBContext contexto, IMapper mapper)
        {
            this.contexto = contexto;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await contexto.Categorias.ToListAsync();
            var categoriasDTO = mapper.Map<List<CategoriaDTO>>(categorias);
            return categoriasDTO;
        }

        [HttpGet("{id}", Name ="GetCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoria = await contexto.Categorias.FirstOrDefaultAsync(x => x.CodigoCategoria == id);
            if (categoria == null)
            {
               return NotFound();
            }
            var categoriaDTO = mapper.Map<CategoriaDTO>(categoria);
            return categoriaDTO;

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaCreacionDTO categoriaCreacion)
        {
            var categoria = mapper.Map<Categoria>(categoriaCreacion);
            contexto.Add(categoria);
            await contexto.SaveChangesAsync();
            var categoriaDTO = mapper.Map<CategoriaDTO>(categoria);
            return new CreatedAtRouteResult("GetCategoria", new { id = categoria.CodigoCategoria },
                categoriaDTO);
        }
    }
}













