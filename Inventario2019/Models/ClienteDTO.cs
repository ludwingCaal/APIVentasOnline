﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class ClienteDTO
	{
		public string Nit { get; set; }
		[Required]
		public string Dpi { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public string Direccion { get; set; }
		public List<FacturaDTO> Factura { get; set; }
		public List<EmailClienteDTO> EmailClientes { get; set; }
		public List<TelefonoClienteDTO> TelefonoClientes { get; set; }
	}
}
