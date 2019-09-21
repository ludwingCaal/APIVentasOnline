using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class DetalleFacturaDTO
	{
		public int CodigoDetalle { get; set; }
		public int NumeroFactura { get; set; }
		[Required]
		public int CodigoProducto { get; set; }
		[Required]
		public int Cantidad { get; set; }
		[Required]
		public decimal Precio { get; set; }
		[Required]
		public decimal Descuento { get; set; }
		public ProductoDTO Producto { get; set; }
		public FacturaDTO Factura { get; set; }
	}
}
