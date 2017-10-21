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

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
