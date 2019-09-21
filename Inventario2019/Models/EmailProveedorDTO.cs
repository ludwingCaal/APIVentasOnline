﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class EmailProveedorDTO
	{
		public int CodigoEmail { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public int CodigoProveedor { get; set; }
		public ProveedorDTO Proveedor { get; set; }
	}
}
