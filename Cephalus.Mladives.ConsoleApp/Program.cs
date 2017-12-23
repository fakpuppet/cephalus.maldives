using Cephalus.Maldives.Core.Models;
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
            var customers = customerService.GetByTags(new[] { TagType.Country }, "");

            foreach (var cust in customers)
            {
                Console.WriteLine(string.Join(",", cust.Tags?.Select(t => t.Display()) ?? new[] { "Nothing" }));
            }

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
