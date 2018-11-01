using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neptuno.Data;
using Neptuno.Data.Repositories;
using Neptuno.Domain.Entities;
using Neptuno.ServiceLayer;
using Neptuno.ServiceLayer.Interfaces;

namespace Neptuno.API
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
            services.AddScoped<NeptunoContext>();
            services.AddScoped<IDbContext>(s => s.GetService<NeptunoContext>());
            services.AddScoped<IUnitOfWork>(s => s.GetService<NeptunoContext>());
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRepository<Producto>, RepositoryGeneric<Producto>>();
            services.AddAutoMapper();
            services.AddMvc();
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
                app.UseExceptionHandler(appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("Hubo un error inesperado. Contacto con el Administrador del Sistema.");
                    });
                });
            }

            app.UseMvc();
        }
    }
}
