using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Entities
{
	public class TelefonoCliente
	{
		public int CodigoTelefono { get; set; }
		public string Numero { get; set; }
		public string Descripcion { get; set; }
		public string Nit { get; set; }
		public Cliente Cliente { get; set; }
	}
}
