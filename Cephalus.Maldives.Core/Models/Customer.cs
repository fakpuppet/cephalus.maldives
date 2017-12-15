using System.Collections.Generic;

namespace Cephalus.Maldives.Core.Models
{
    public class Customer : Person  
    {
        public string CustomerNumber { get; set; }

        public IEnumerable<Tag> Tags { get; set; }
    }
}
