using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class CompraDTO
	{
		public int IdCompra { get; set; }
		[Required]
		public int NumeroDocumento { get; set; }
		[Required]
		public int CodigoProveedor { get; set; }
		[Required]
		public DateTime Fecha { get; set; }
		[Required]
		public decimal Total { get; set; }
		public ProveedorDTO Proveedor { get; set; }
		public List<DetalleCompraDTO> DetalleCompras { get; set; }
	}
}
