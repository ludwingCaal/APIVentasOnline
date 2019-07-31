using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class Proveedor
	{
		public int CodigoProveedor { get; set; }
		public string Nit { get; set; }
		public string RazonSocial { get; set; }
		public string Direccion { get; set; }
		public string PaginaWeb { get; set; }
		public string ContactoPrincipal { get; set; }
		public List<EmailProveedor> EmailProveedores { get; set; }
		public List<TelefonoProveedor> TelefonosProveedores { get; set; }
		public List<Compra> Compras { get; set; }
	}
}
