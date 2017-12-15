using Cephalus.Maldives.Core.Models;
using System;
using System.Collections.Generic;

namespace Cephalus.Maldives.Web.Models
{
    public class CustomersModel
    {
        public Guid[] TagIds { get; set; }


        public IEnumerable<Customer> Customers { get; set; }
    }
}