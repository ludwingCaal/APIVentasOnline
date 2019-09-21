using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class ProductoCreacionDTO
	{
		[Required]
		public int CodigoCategoria { get; set; }
		[Required]
		public int CodigoEmpaque { get; set; }
		[Required]
		public string Descripcion { get; set; }
		[Required]
		public Decimal PrecioUnitario { get; set; }
		[Required]
		public Decimal PrecioPorDocena { get; set; }
		[Required]
		public Decimal PrecioPorMayor { get; set; }
		[Required]
		public int Exixtencia { get; set; }

	}
}
