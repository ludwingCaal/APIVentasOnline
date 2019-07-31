using AutoMapper;
using Inventario2019.Contexts;
using Inventario2019.Entities;
using Inventario2019.Models;
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
		[HttpGet("{id}", Name = "GetTipoEmpaque")]
		//Metodo que devulve un solo valor o solo una categoria.
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
			return new CreatedAtRouteResult("GetTipoEmpaque", new { id = tipoEmpaque.CodigoEmpaque }, tipoEmpaqueDTO);
		}
	}
}
