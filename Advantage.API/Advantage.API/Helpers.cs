using System;
using System.Collections.Generic;
using System.Linq;
using Advantage.API.Models;

namespace Advantage.API
{
    public class Helpers
    {
        private static Random _rand = new Random();
        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];
        }

        internal static string MakeCustomerName(List<string> names)
        {
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSuffix);
            if(names.Contains(prefix+suffix)) MakeCustomerName(names);

            return prefix + suffix;
        }

        private static readonly List<string> bizPrefix = new List<string>()
        {
            "ABC","XYZ","Acme","MainSt","Ready","Magic","Fluent","Peak","Forward","Enterprise","Sales"
        };

        private static readonly List<string> bizSuffix = new List<string>()
        {
            "Co","Corp","Holdings","Corporation","Movers", "Cleaners","Bakery","Apparel","Rentals","Storage","Transit", "Logistics"
        };


        internal static string MakeCustomerEmail(string customerName)
        {
            return $"contact@{customerName.ToLower()}.com";
        }

        internal static string GetRandomState() => GetRandom(states);
        internal static readonly List<string> states = new List<string>()
        {
            "AK", "AL","AZ",  "AR", "CA", "CO", "CT", "DE", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
            "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
            "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
            "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
        };


         public static Customer GetRandomCustomer(ApiContext ctx)
        {
            var randomId = _rand.Next(1, ctx.Customers.Count())-1;
            return ctx.Customers.First(c => c.Id == randomId);
        }
        internal static DateTime GetRandOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);

            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes), 0);

            return start + newSpan;
        }

        public static DateTime? GetRandOrderCompleted(DateTime placed)
        {
            var now = DateTime.Now;
            var minLeadTime = TimeSpan.FromDays(7);
            var timePassed = now - placed;

            if (timePassed < minLeadTime)
            {
                return null;
            }

            return placed.AddHours(_rand.Next(10, 90));
        }

       

        public static decimal GetRandomOrderTotal()
        {
            return _rand.Next(25, 1000);
        }

    }
}