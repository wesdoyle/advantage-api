using System;
using System.Collections.Generic;
using Advantage.API.Demo.Models;

namespace Advantage.API.Demo
{
    public class Helpers
    {
        private static Random _rand = new Random();

        internal static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }

        internal static string MakeCustomerName()
        {
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);

            return prefix + suffix;
        }

        internal static string MakeEmail(string name)
        {
            return $"contact@{name.ToLower()}_{DateTime.Now:fff}.com";
        }

        internal static readonly List<string> states = new List<string>()
        {
            "AK", "AL","AZ",  "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
        };

        private static readonly List<string> bizPrefix = new List<string>()
        {
            "ABC",
            "XYZ",
            "Acme",
            "MainSt",
            "Ready",
            "Magic",
            "Fluent",
            "Peak",
            "Forward",
            "Enterprise",
            "Sales"
        };

        internal static DateTime GetRandOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);

            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes), 0);

            return start + newSpan;
        }

        private static readonly List<string> bizSuffix = new List<string>()
        {
            "Co",
            "Corp",
            "Holdings",
            "Corporation",
            "Movers",
            "Cleaners",
            "Bakery",
            "Apparel",
            "Rentals",
            "Storage",
            "Transit",
            "Logistics"
        };

        public static DateTime? GetRandOrderCompleted(DateTime placed)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - placed;

            if(timePassed < minLeadTime)
            {
                return null;
            }

            return placed.AddHours(_rand.Next(10, 90));
        }

        internal static Customer GetRandomCustomer()
        {
            throw new NotImplementedException();
        }

        internal static decimal GetRandomOrderTotal()
        {
            throw new NotImplementedException();
        }
    }
}
