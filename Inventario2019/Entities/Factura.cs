using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class Factura
	{
		public int NumeroFactura { get; set; }
		public string Nit { get; set; }
		public DateTime Fecha { get; set; }
		public decimal Total { get; set; }
		public Cliente Cliente { get; set; }
		public List<DetalleFactura> DetalleFacturas { get; set; }
	}
}
