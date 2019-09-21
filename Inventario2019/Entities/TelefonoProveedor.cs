﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class TelefonoProveedor
	{
		public int CodigoTelefono { get; set; }
		[Required]
		public string Numero { get; set; }
		[Required]
		public string Descripcion { get; set; }
		[Required]
		public int CodigoProveedor { get; set; }
		public Proveedor Proveedor { get; set; }
	}
}
