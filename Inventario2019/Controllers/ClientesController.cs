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
	[Route("Api/v1/[controller]")]
	[ApiController]
	public class ClientesController : ControllerBase
	{
		private readonly InventarioDBContext inventarioDBContext;
		private readonly IMapper mapper;

		public ClientesController(InventarioDBContext inventarioDBContext, IMapper mapper)
		{
			this.inventarioDBContext = inventarioDBContext;
			this.mapper = mapper;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get()
		{
			var clientes = await inventarioDBContext.Clientes.ToListAsync();
			var clientesDTO = mapper.Map<List<ClienteDTO>>(clientes);
			return clientesDTO;
		}
		[HttpGet("{id}", Name = "GetCliente")]
		public async Task<ActionResult<ClienteDTO>> Get(int id)
		{
			var cliente = await inventarioDBContext.Clientes.FirstOrDefaultAsync(x => x.Nit.Equals(id));
			if (cliente == null)
			{
				return NotFound();
			}
			var clienteDTO = mapper.Map<ClienteDTO>(cliente);
			return clienteDTO;
		}
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteCreacionDTO)
		{
			var cliente = mapper.Map<Cliente>(clienteCreacionDTO);
			inventarioDBContext.Add(cliente);
			await inventarioDBContext.SaveChangesAsync();
			var clienteDTO = mapper.Map<ClienteDTO>(cliente);
			return new CreatedAtRouteResult("GetCliente", new { id = cliente.Nit }, clienteDTO);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(string id, [FromBody] ClienteCreacionDTO clienteCreacionDTO)
		{
			var cliente = this.mapper.Map<Cliente>(clienteCreacionDTO);
			cliente.Equals(id);
			this.inventarioDBContext.Entry(cliente).State = EntityState.Modified;
			await this.inventarioDBContext.SaveChangesAsync();
			return NoContent();
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<ClienteDTO>> Delete(string id)
		{
			var codigo = this.inventarioDBContext.Clientes.Select(x => x.Nit)
				.FirstOrDefaultAsync(x => x.Equals(id));
			if (codigo.Equals(default(string)))
			{
				return NotFound();
			}
			this.inventarioDBContext.Remove(new Cliente { Nit = id });
			await this.inventarioDBContext.SaveChangesAsync();
			return NoContent();
		}
	}
}
