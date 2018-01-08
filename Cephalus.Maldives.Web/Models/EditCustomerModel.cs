using System;
using System.ComponentModel.DataAnnotations;
using Cephalus.Maldives.Core.Models;

namespace Cephalus.Maldives.Web.Models
{
    public class EditCustomerModel : AddCustomerModel
    {
        [Required]
        public long Id { get; set; }

        public Guid CustomerId { get; set; }

        public override Customer ToCustomer()
        {
            var customer = base.ToCustomer();

            customer.Id = Id;
            customer.CustomerId = CustomerId;

            return customer;
        }
    }
}