﻿using Inventario2019.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class DetalleCompraDTO
	{
		public int IdDetalle { get; set; }
		[Required]
		public int IdCompra { get; set; }
		[Required]
		public int CodigoProducto { get; set; }
		[Required]
		public int Cantidad { get; set; }
		[Required]
		public decimal Precio { get; set; }
		public CompraDTO Compra { get; set; }
		public ProductoDTO Producto { get; set; }
	}
}
