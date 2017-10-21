using Advantage.API.Demo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Advantage.API.Demo
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
            services.AddMvc();

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ApiContext>(
                    opt => opt.UseNpgsql(Configuration.GetConnectionString("AdvantageDb")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeed seed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Seed data with number of customers and number of orders
            var nCustomers = 20;
            var nOrders = 1000;
            seed.SeedData(nCustomers, nOrders);

            app.UseMvc();
        }
    }
}
