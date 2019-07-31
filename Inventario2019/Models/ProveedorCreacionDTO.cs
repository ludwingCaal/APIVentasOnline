﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class ProveedorCreacionDTO
	{
		[Required]
		public string Nit { get; set; }
		[Required]
		public string RazonSocial { get; set; }
		[Required]
		public string Direccion { get; set; }
		[Required]
		public string PaginaWeb { get; set; }
		[Required]
		public string ContactoPrincipal { get; set; }
	}
}
