using System;
using System.Collections.Generic;

namespace Cephalus.Maldives.Core.Models
{
    public class Customer : Person  
    {
        public Guid CustomerId { get; set; }

        public string CustomerNumber { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
