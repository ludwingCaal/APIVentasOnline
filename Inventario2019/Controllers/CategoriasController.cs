using AutoMapper;
using Inventario2019.Contexts;
using Inventario2019.Entities;
using Inventario2019.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
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
			var categorias = await contexto.Categorias.Include("Productos").ToListAsync();
			var categoriasDTO = mapper.Map<List<CategoriaDTO>>(categorias);
			return categoriasDTO;
		}
		[HttpGet("{id}", Name = "GetCategoria")]
		//Metodo que devulve un solo valor o solo una categoria.
		public async Task<ActionResult<CategoriaDTO>> Get(int id)
		{
			var categoria = await contexto.Categorias.Include("Producto").Include("TipoEmpaque").FirstOrDefaultAsync(x => x.CodigoCategoria == id);
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
			return new CreatedAtRouteResult("GetCategoria", new { id = categoria.CodigoCategoria }, categoriaDTO);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] CategoriaCreacionDTO categoriaCreacionDTO){
			var categoria = this.mapper.Map<Categoria>(categoriaCreacionDTO);
			categoria.CodigoCategoria = id;
			this.contexto.Entry(categoria).State = EntityState.Modified;
			await this.contexto.SaveChangesAsync();
			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<CategoriaDTO>> Delete(int id)
		{
			var codigo = this.contexto.Categorias.Select(x => x.CodigoCategoria)
				.FirstOrDefaultAsync(x => x == id);
			if (codigo.Equals(default(int)))
			{
				return NotFound();
			}
			this.contexto.Remove(new Categoria { CodigoCategoria = id });
			await this.contexto.SaveChangesAsync();
			return NoContent();
		}
	}
}
