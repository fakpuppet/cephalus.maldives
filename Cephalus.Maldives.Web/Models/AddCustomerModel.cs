using Cephalus.Maldives.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cephalus.Maldives.Web.Models
{
    public class AddCustomerModel : AlertingModelBase
    {
        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        [Display(Name = "Customer number")]
        public string CustomerNumber { get; set; }

        [Display(Name = "Date of birth")]
        [Required]
        public DateTime? BirthDate { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public Customer ToCustomer()
        {
            return new Customer
            {
                CustomerNumber = CustomerNumber,
                BirthDate = BirthDate,
                Tags = new List<Tag>() { new WatchBrand() { Name = "Darwil" } }
            };
        }
    }
}