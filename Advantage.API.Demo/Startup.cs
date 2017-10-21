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
                    opt => opt.UseNpgsql(Configuration.GetConnectionString("AdvantageDemo")));

            services.AddTransient<DataSeed>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeed seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var nCustomers = 20;
            var nOrders = 1000;
            seeder.SeedData(nCustomers, nOrders);

            app.UseMvc();
        }
    }
}
