using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APITest.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace APITest
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
            services.AddDbContext<TipoCambioContext>(opt => opt.UseInMemoryDatabase());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<TipoCambioContext>();
            AddTestData(context);

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void AddTestData(TipoCambioContext context)
        {
            var testTipoCambio1 = new TipoCambio
            {
                ID = new Guid(),
                MonedaOrigen = "DOLARES",
                MonedaDestino = "SOLES",
                MTipoCambio = 3.80
            };

            context.ListaTipoCambio.Add(testTipoCambio1);

            testTipoCambio1 = new TipoCambio
            {
                ID = new Guid(),
                MonedaOrigen = "EUROS",
                MonedaDestino = "SOLES",
                MTipoCambio = 4.09
            };
            context.ListaTipoCambio.Add(testTipoCambio1);

            testTipoCambio1 = new TipoCambio
            {
                ID = new Guid(),
                MonedaOrigen = "SOLES",
                MonedaDestino = "DOLARES",
                MTipoCambio = 0.27
            };
            context.ListaTipoCambio.Add(testTipoCambio1);

            context.SaveChanges();
        }
    }
}
