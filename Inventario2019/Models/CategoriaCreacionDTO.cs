using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class CategoriaCreacionDTO
	{ 
		[Required]
		public string Descripcion { get; set; }
	}
}
