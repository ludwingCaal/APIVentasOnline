﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class DetalleFacturaDTO
	{
		public int CodigoDetalle { get; set; }
		public int NumeroFactura { get; set; }
		public int CodigoProducto { get; set; } 
		public int Cantidad { get; set; }
		public decimal Precio { get; set; }
		public decimal Descuento { get; set; }
		public ProductoDTO Producto { get; set; }
		//public FacturaDTO Factura { get; set; }
	}
}
