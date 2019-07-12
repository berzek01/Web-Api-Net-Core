using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faro.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Faro.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options=>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddTransient<ICategoriaRepository, CategoriaRepository> ();
            services.AddTransient<ICategoriaService, CategoriaService> ();

            services.AddTransient<IClienteRepository, ClienteRepository> ();
            services.AddTransient<IClienteService, ClienteService> ();

            services.AddTransient<IEmpleadoRepository, EmpleadoRepository> ();
            services.AddTransient<IEmpleadoService, EmpleadoService> ();

            services.AddTransient<IPedidoRepository, PedidoRepository> ();
            services.AddTransient<IPedidoService, PedidoService> ();

            services.AddTransient<IProductoRepository, ProductoRepository> ();
            services.AddTransient<IProductoService, ProductoService> ();

            services.AddTransient<IReservaRepository, ReservaRepository> ();
            services.AddTransient<IReservaService, ReservaService> ();

            services.AddTransient<ITipoHabitacionRepository, TipoHabitacionRepository> ();
            services.AddTransient<ITipoHabitacionService, TipoHabitacionService> ();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger ();

            app.UseSwaggerUI (c => {
                c.SwaggerEndpoint (SwaggerConfiguration.EndpointUrl, SwaggerConfiguration.EndpointDescription);
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors ("Todos");
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
