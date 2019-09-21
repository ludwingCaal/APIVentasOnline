using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class EmailCliente
	{
		public int CodigoEmail { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Nit { get; set; }
		public Cliente Cliente { get; set; }
	}
}
