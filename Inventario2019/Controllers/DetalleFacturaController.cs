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
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class DetalleFacturaController : ControllerBase
	{
		private readonly InventarioDBContext contexto;
		private readonly IMapper mapper;

		public DetalleFacturaController(InventarioDBContext contexto, IMapper mapper)
		{
			this.contexto = contexto;
			this.mapper = mapper;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DetalleFacturaDTO>>> Get()
		{
			var detalleFactura = await contexto.DetalleFacturas.ToListAsync();
			var detalleFacturaDTO = mapper.Map<List<DetalleFacturaDTO>>(detalleFactura);
			return detalleFacturaDTO;
		}
		[HttpGet("{id}", Name = "GetDetalleFactura")]
		//Metodo que devulve un solo valor o solo una categoria.
		public async Task<ActionResult<DetalleFacturaDTO>> Get(int id)
		{
			var detalleFactura = await contexto.DetalleFacturas.FirstOrDefaultAsync(x => x.CodigoDetalle == id);
			if (detalleFactura == null)
			{
				return NotFound();
			}
			var detalleFacturaDTO = this.mapper.Map<DetalleFacturaDTO>(detalleFactura);
			return detalleFacturaDTO;
		}
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] DetalleFacturaCreacionDTO detalleFacturaCreacion)
		{
			var detalleFactura = mapper.Map<DetalleFactura>(detalleFacturaCreacion);
			contexto.Add(detalleFactura);
			await contexto.SaveChangesAsync();
			var detalleFacturaDTO = mapper.Map<DetalleFacturaDTO>(detalleFactura);
			return new CreatedAtRouteResult("GetDetalleFactura", new { id = detalleFactura.CodigoDetalle }, detalleFacturaDTO);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] DetalleFacturaCreacionDTO detalleFacturaCreacionDTO)
		{
			var detalleFactura = this.mapper.Map<DetalleFactura>(detalleFacturaCreacionDTO);
			detalleFactura.CodigoDetalle = id;
			this.contexto.Entry(detalleFactura).State = EntityState.Modified;
			await this.contexto.SaveChangesAsync();
			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<DetalleFacturaDTO>> Delete(int id)
		{
			var codigo = this.contexto.DetalleFacturas.Select(x => x.CodigoDetalle)
				.FirstOrDefaultAsync(x => x == id);
			if (codigo.Equals(default(int)))
			{
				return NotFound();
			}
			this.contexto.Remove(new DetalleFactura { CodigoDetalle = id });
			await this.contexto.SaveChangesAsync();
			return NoContent();
		}

	}
}


