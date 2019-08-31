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
	public class ProveedoresController:ControllerBase
	{
		private readonly InventarioDBContext inventarioDBContext;
		private readonly IMapper mapper;
		public ProveedoresController(InventarioDBContext inventarioDBContext, IMapper mapper)
		{
			this.inventarioDBContext = inventarioDBContext;
			this.mapper = mapper;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProveedorDTO>>> Get()
		{
			var proveedores = await this.inventarioDBContext.Proveedores.ToListAsync();
			var proveedoresDTO = this.mapper.Map<List<ProveedorDTO>>(proveedores);
			return proveedoresDTO;
		}
		[HttpGet("{id}", Name = "GetProveedor")]
		public async Task<ActionResult<ProveedorDTO>> Get(int id)
		{
			var proveedor = await this.inventarioDBContext.Proveedores.FirstOrDefaultAsync(x => x.CodigoProveedor == id);
			if (proveedor == null)
			{
				return NotFound();
			}
			var proveedorDTO = this.mapper.Map<ProveedorDTO>(proveedor);
			return proveedorDTO;
		}
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] ProveedorCreacionDTO proveedorCreacionDTO)
		{
			var proveedor = this.mapper.Map<Entities.Proveedor>(proveedorCreacionDTO);
			this.inventarioDBContext.Add(proveedor);
			await this.inventarioDBContext.SaveChangesAsync();
			var proveedorDTO = this.mapper.Map<ProveedorDTO>(proveedor);
			return new CreatedAtRouteResult("GetProveedor", new { id = proveedor.CodigoProveedor }, proveedorDTO);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] ProveedorCreacionDTO proveedorCreacionDTO)
		{
			var proveedor = this.mapper.Map<Proveedor>(proveedorCreacionDTO);
			proveedor.CodigoProveedor = id;
			this.inventarioDBContext.Entry(proveedor).State = EntityState.Modified;
			await this.inventarioDBContext.SaveChangesAsync();
			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<ProveedorDTO>> Delete(int id)
		{
			var codigo = this.inventarioDBContext.Proveedores.Select(x => x.CodigoProveedor)
				.FirstOrDefaultAsync(x => x == id);
			if (codigo.Equals(default(int)))
			{
				return NotFound();
			}
			this.inventarioDBContext.Remove(new Proveedor { CodigoProveedor = id });
			await this.inventarioDBContext.SaveChangesAsync();
			return NoContent();
		}
	}
}
