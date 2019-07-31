using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class DetalleCompra
	{
		public int IdDetalle { get; set; }
		public int IdCompra { get; set; }
		public int CodigoProducto { get; set; }
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public Compra Compra { get; set; }
		public Producto Producto { get; set; }
	}
}
