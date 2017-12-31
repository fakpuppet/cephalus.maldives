using System;

namespace Cephalus.Maldives.Core.Models
{
    public class Tag : ITag
    {
        public long Id { get; set; }

        public Guid TagId { get; set; }

        public long CustomerId { get; set; }

        public Guid CustomerGuid { get; set; }

        public string Name { get; set; }

        public virtual string Display()
        {
            return Name;
        }
    }
}
