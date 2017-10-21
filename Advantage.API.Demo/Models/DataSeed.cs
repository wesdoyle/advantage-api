using Advantage.API.Demo.Models;
using System.Collections.Generic;
using System.Linq;

namespace Advantage.API.Demo
{
    public class DataSeed
    {
        private readonly ApiContext _ctx;

        public DataSeed(ApiContext ctx)
        {
            _ctx = ctx;
        }

        private static List<string> states = Helpers.states;

        public void SeedData(int nCustomers, int nOrders)
        {
            if (!_ctx.Customers.Any())
            {
                SeedCustomers(nCustomers);
                _ctx.SaveChanges();
            }

            if (!_ctx.Orders.Any())
            {
                SeedOrders(nOrders);
                _ctx.SaveChanges();
            }

            if (!_ctx.Servers.Any())
            {
                SeedServers();
                _ctx.SaveChanges();
            }
        }

        internal void SeedCustomers(int n)
        {
            var customers = BuildCustomerList(n);

            foreach (var customer in customers)
            {
                _ctx.Customers.Add(customer);
            }
        }

        internal void SeedOrders(int n)
        {
            var orders = BuildOrderList(n);

            foreach (var order in orders)
            {
                _ctx.Orders.Add(order);
            }
        }

        internal void SeedServers()
        {
            var servers = BuildServerList();

            foreach (var server in servers)
            {
                _ctx.Servers.Add(server);
            }
        }

        internal static List<Customer> BuildCustomerList(int n)
        {
            var customers = new List<Customer>();

            for (var i = 1; i <= n; i++)
            {
                var name = Helpers.MakeCustomerName();

                customers.Add(new Customer
                {
                    Id = i,
                    Name = name,
                    State = Helpers.GetRandom(states),
                    Email = Helpers.MakeEmail(name)
                });
            }

            return customers;
        }

        internal List<Order> BuildOrderList(int n)
        {
            var orders = new List<Order>();

            for (var i = 1; i <= n; i++)
            {
                var placed = Helpers.GetRandOrderPlaced();
                var completed = Helpers.GetRandOrderCompleted(placed);

                orders.Add(new Order
                {
                    Id = i,
                    Customer = Helpers.GetRandomCustomer(_ctx),
                    OrderTotal = Helpers.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = completed
                });
            }

            return orders;
        }

        internal static List<Server> BuildServerList()
        {
            return new List<Server>()
            {
                new Server
                {
                    Id = 1,
                    Name = "Dev-Web",
                    IsOnline = true
                },

                new Server
                {
                    Id = 2,
                    Name = "Dev-Analysis",
                    IsOnline = true
                },

                new Server
                {
                    Id = 3,
                    Name = "Dev-Mail",
                    IsOnline = true
                },

                new Server
                {
                    Id = 4,
                    Name = "QA-Web",
                    IsOnline = true
                },

                new Server
                {
                    Id = 5,
                    Name = "QA-Analysis",
                    IsOnline = true
                },

                new Server
                {
                    Id = 6,
                    Name = "QA-Mail",
                    IsOnline = true
                },

                new Server
                {
                    Id = 7,
                    Name = "Prod-Web",
                    IsOnline = true
                },

                new Server
                {
                    Id = 8,
                    Name = "Prod-Analysis",
                    IsOnline = true
                },

                new Server
                {
                    Id = 9,
                    Name = "Prod-Mail",
                    IsOnline = true
                },
            };
        }
    }
}
