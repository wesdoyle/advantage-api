using Advantage.API.Demo.Models;
using System;
using System.Collections.Generic;

namespace Advantage.API.Demo
{
    public class DataSeed
    {
        private static List<string> states = Helpers.states;

        internal static void SeedCustomers(ApiContext ctx)
        {
            var customers = BuildCustomerList(20);

            foreach(var customer in customers)
            {
                ctx.Customers.Add(customer);
            }
        }

        internal static void SeedOrders(ApiContext ctx)
        {
            var orders = BuildOrderList(1000);

            foreach(var order in orders)
            {
                ctx.Orders.Add(order);
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

        internal static List<Order> BuildOrderList(int n)
        {
            var orders = new List<Order>();

            for (var i = 1; i <= n; i++)
            {
                var placed = Helpers.GetRandOrderPlaced();
                var completed = Helpers.GetRandOrderCompleted(placed);

                orders.Add(new Order 
                {
                    Id = i,
                    Customer = Helpers.GetRandomCustomer(),
                    OrderTotal = Helpers.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = completed.Value
                });
            }

            return orders;
        }
    }
}
