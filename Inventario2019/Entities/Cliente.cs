using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class Cliente
	{
		public string Nit { get; set; }
		[Required]
		public string Dpi { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public string Direccion { get; set; }
		public List<EmailCliente> EmailClientes { get; set; }
		public List<TelefonoCliente> TelefonoClientes { get; set; }
		public List<Factura> Facturas { get; set; }
	}
}
