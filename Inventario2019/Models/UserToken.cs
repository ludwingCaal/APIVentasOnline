﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Models
{
	public class UserToken
	{
		public string Token { get; set; }
		public DateTime Expiration { get; set; }
	}
}
