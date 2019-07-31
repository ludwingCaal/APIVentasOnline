using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inventario2019.Contexts;
using Inventario2019.Entities;
using Inventario2019.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Inventario2019
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(options =>
			{
				options.CreateMap<CategoriaCreacionDTO, Categoria>();
				options.CreateMap<TipoEmpaqueCreacionDTO, TipoEmpaque>();
				options.CreateMap<ProductoCreacionDTO, Producto>();
				options.CreateMap<ClienteCreacionDTO, Cliente>();
				options.CreateMap<DetalleCompraCreacionDTO, DetalleCompra>();
				options.CreateMap<CompraCreacionDTO, Compra>();
				options.CreateMap<ProveedorCreacionDTO, Proveedor>();
			});
			services.AddDbContext<InventarioDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
				.AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling
				= Newtonsoft.Json.ReferenceLoopHandling.Ignore);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
