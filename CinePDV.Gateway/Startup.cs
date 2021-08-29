using System;
using CinePDV.Gateway.BackgroundServices;
using CinePDV.Gateway.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CinePDV.Gateway
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
            services.AddHttpClient<IProductCatalogService, ProductCatalogService>(c => c.BaseAddress = new Uri("http://localhost:33977/"));
            services.AddHttpClient<IMovieCatalogService, MovieCatalogService>(c => c.BaseAddress = new Uri("http://localhost:52977/"));
            services.AddHttpClient<IShoppingBasketService, ShoppingBasketService>(c => c.BaseAddress = new Uri("http://localhost:47508/"));
            services.AddHostedService<PaymentService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
