using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class Inventario
	{
		public int CodigoInventario { get; set; }
		public int CodigoProducto { get; set; }
		public Producto Producto { get; set; }
		public DateTime Fecha { get; set; }
		public string TipoRegistro { get; set; }
		public decimal Precio { get; set; }
		public int Entradas { get; set; }
		public int Salidas { get; set; }
	}
}
