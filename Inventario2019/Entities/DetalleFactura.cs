using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class DetalleFactura
	{
		public int CodigoDetalle { get; set; }
		public int NumeroFactura { get; set; }
		public int CodigoFactura { get; set; }
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Descuento { get; set; }
		public Factura Factura { get; set; }
		public Producto Producto { get; set; }
	}
}
