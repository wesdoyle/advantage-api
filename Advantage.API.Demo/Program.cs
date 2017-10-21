using Advantage.API.Demo.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Advantage.API.Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            var options = new DbContextOptions<ApiContext>();
            var ctx = new ApiContext(options);
            var seeder = new DataSeed(ctx);

            var nCustomers = 20;
            var nOrders = 1000;

            seeder.SeedData(nCustomers, nOrders);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
