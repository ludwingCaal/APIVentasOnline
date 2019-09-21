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
	public class FacturaController:ControllerBase
	{
		private readonly InventarioDBContext contexto;
		private readonly IMapper mapper;

		public FacturaController(InventarioDBContext contexto, IMapper mapper)
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
		//Metodo que devulve un solo valor o solo una categoria.
		public async Task<ActionResult<FacturaDTO>> Get(int id)
		{
			var factura = await contexto.Facturas.FirstOrDefaultAsync(x => x.NumeroFactura == id);
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
			return new CreatedAtRouteResult("GetFactura", new { id = factura.NumeroFactura }, facturaDTO);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] FacturaCreacionDTO facturaCreacionDTO)
		{
			var factura = this.mapper.Map<Factura>(facturaCreacionDTO);
			factura.NumeroFactura = id;
			this.contexto.Entry(factura).State = EntityState.Modified;
			await this.contexto.SaveChangesAsync();
			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<FacturaDTO>> Delete(int id)
		{
			var codigo = this.contexto.Facturas.Select(x => x.NumeroFactura)
				.FirstOrDefaultAsync(x => x == id);
			if (codigo.Equals(default(int)))
			{
				return NotFound();
			}
			this.contexto.Remove(new Factura { NumeroFactura = id });
			await this.contexto.SaveChangesAsync();
			return NoContent();
		}
	}
}
