using Cephalus.Maldives.Core.Models;
using System;
using System.Collections.Generic;

namespace Cephalus.Maldives.Web.Models
{
    public class AddCustomerModel : AlertingModelBase
    {
        public string CustomerNumber { get; set; }

        public DateTime? BirthDate { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public Customer ToCustomer()
        {
            return new Customer
            {
                CustomerNumber = CustomerNumber,
                BirthDate = BirthDate,
                Tags = Tags
            };
        }
    }
}