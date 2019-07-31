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
	public class DetalleComprasController:ControllerBase
	{
		private readonly InventarioDBContext inventarioDBContext;
		private readonly IMapper mapper;
		public DetalleComprasController(InventarioDBContext inventarioDBContext, IMapper mapper)
		{
			this.inventarioDBContext = inventarioDBContext;
			this.mapper = mapper;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DetalleCompraDTO>>> Get()
		{
			var detalleCompras = await this.inventarioDBContext.DetalleCompras.ToListAsync();
			var detalleComprasDTO = this.mapper.Map<List<DetalleCompraDTO>>(detalleCompras);
			return detalleComprasDTO;
		}
		[HttpGet("{id}", Name = "GetDetalleCompra")]
		public async Task<ActionResult<DetalleCompraDTO>> Get(int id)
		{
			var detalleCompra = await this.inventarioDBContext.DetalleCompras.FirstOrDefaultAsync(x => x.IdDetalle == id);
			if (detalleCompra == null)
			{
				return NotFound();
			}
			var detalleCompraDTO = this.mapper.Map<DetalleCompraDTO>(detalleCompra);
			return detalleCompraDTO;
		}
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] DetalleCompraCreacionDTO detalleCompraCreacionDTO)
		{
			var detalleCompra = this.mapper.Map<Entities.DetalleCompra>(detalleCompraCreacionDTO);
			this.inventarioDBContext.Add(detalleCompra);
			await this.inventarioDBContext.SaveChangesAsync();
			var detalleCompraDTO = this.mapper.Map<DetalleCompraDTO>(detalleCompra);
			return new CreatedAtRouteResult("GetDetalleCompra", new { id = detalleCompra.IdDetalle }, detalleCompraDTO);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] DetalleCompraCreacionDTO detalleCompraCreacionDTO)
		{
			var detalleCompra = this.mapper.Map<DetalleCompra>(detalleCompraCreacionDTO);
			detalleCompra.IdDetalle = id;
			this.inventarioDBContext.Entry(detalleCompra).State = EntityState.Modified;
			await this.inventarioDBContext.SaveChangesAsync();
			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<DetalleCompraDTO>> Delete(int id)
		{
			var codigo = this.inventarioDBContext.DetalleCompras.Select(x => x.IdDetalle)
				.FirstOrDefaultAsync(x => x == id);
			if (codigo.Equals(default(int)))
			{
				return NotFound();
			}
			this.inventarioDBContext.Remove(new DetalleCompra { IdDetalle = id });
			await this.inventarioDBContext.SaveChangesAsync();
			return NoContent();
		}
	}
}
