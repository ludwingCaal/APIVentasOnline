﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class Factura
	{
		public int NumeroFactura { get; set; }
		[Required]
		public string Nit { get; set; }
		[Required]
		public DateTime Fecha { get; set; }
		[Required]
		public decimal Total { get; set; }
		public Cliente Cliente { get; set; }
		public List<DetalleFactura> DetalleFacturas { get; set; }
	}
}
