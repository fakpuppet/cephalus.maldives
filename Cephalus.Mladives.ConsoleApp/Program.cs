using Cephalus.Maldives.DAL.Sql;
using Cephalus.Maldives.Services;
using System;
using System.Linq;

namespace Cephalus.Mladives.ConsoleApp
{
    class Program
    {
        private const string Connection = @"Server=.\;Database=cephalus.maldives;User Id=sa;Password=1;MultipleActiveResultSets=true";

        static void Main(string[] args)
        {
            var customerService = new CustomerService(new CustomerRepository(Connection));
            var customers = customerService.GetByTags(new[] { Guid.Parse("0421FA89-4C4C-4385-856B-7F3155C9BE3C") }).ToArray();

            foreach (var c in customers)
            {
                Console.WriteLine($"{c.CustomerNumber}-{c.BirthDate?.ToString("dd.MM.yyyy")} With tags {string.Join(", ", c.Tags.Select(t => t.TagId))}");
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
