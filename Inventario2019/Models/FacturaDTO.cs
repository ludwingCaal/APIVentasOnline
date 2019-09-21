using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class FacturaDTO
	{
		public int NumeroFactura { get; set; }
		[Required]
		public string Nit { get; set; }
		[Required]
		public DateTime Fecha { get; set; }
		[Required]
		public decimal Total { get; set; }
		public ClienteDTO Cliente { get; set; }
		public List<DetalleFacturaDTO> DetalleFacturas { get; set; }
	}
}
