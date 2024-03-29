﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class Inventario
	{
		public int CodigoInventario { get; set; }
		public int CodigoProducto { get; set; }
		public Producto Producto { get; set; }
		public DateTime Fecha { get; set; }
		[Required]
		public string TipoRegistro { get; set; }
		[Required]
		public decimal Precio { get; set; }
		[Required]
		public int Entradas { get; set; }
		[Required]
		public int Salidas { get; set; }
	}
}
