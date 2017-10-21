using Advantage.API.Demo.Models;
using System;
using System.Collections.Generic;

namespace Advantage.API.Demo
{
    public class DataSeed
    {
        internal static void SeedSampleCustomers(ApiContext ctx)
        {
            var customers = new List<Customer>();

            for (var i = 1; i <= 20; i++)
            {
                customers.Add(new Customer
                {
                    Id = i,
                    Name = GetRandom(),
                    State = GetRandomItemFrom(states)
                });
            }

            foreach (var customer in customers)
            {
                customer.Email = GenerateEmail(customer.Name);
            }
        }
        internal static void SeedSampleOrders(ApiContext ctx)
        {
            for (var i = 1; i <= 1000; i++)
            {
                ctx.Orders.Add(new Order
                {
                    Id = i,
                    Customer = GetRandomCustomer(),
                    OrderTotal = _rand.Next(50, 1000),
                    Placed = DateTime.Now.AddDays(_rand.Next(-100, 0))
                });
            }
        }

    }
}
