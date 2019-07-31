using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class TelefonoProveedor
	{
		public int CodigoTelefono { get; set; }
		public string Numero { get; set; }
		public string Descripcion { get; set; }
		public int CodigoProveedor { get; set; }
		public Proveedor Proveedor { get; set; }
	}
}
