using Inventario2019.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario2019.Contexts
{
	public class InventarioIdentityContext:IdentityDbContext<ApplicationUser>
	{
		public InventarioIdentityContext(DbContextOptions<InventarioIdentityContext>options)
			: base(options)
		{

		}
	}
}
