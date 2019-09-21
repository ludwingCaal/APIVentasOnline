using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class EmailClienteDTO
	{
		public int CodigoEmail { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Nit { get; set; }
		public ClienteDTO Cliente { get; set; }
	}
}
