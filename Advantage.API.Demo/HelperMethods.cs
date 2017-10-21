using System;
using System.Collections.Generic;

namespace Advantage.API.Demo
{
    public class HelperMethods
    {
        private static Random _rand = new Random();

        internal static string GetRandomItemFrom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }

        private static string GetRandomCustomerName()
        {
            var prefix = GetRandomItemFrom(bizPrefix);
            var suffix = GetRandomItemFrom(bizSuffix);

            return prefix + suffix;
        }

        private static string GenerateEmail(string name)
        {
            return $"contact@{name.ToLower()}_{DateTime.Now:fff}.com";
        }

        private static readonly List<string> states = new List<string>()
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
    }
}
