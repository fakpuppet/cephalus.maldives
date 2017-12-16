using System;

namespace Cephalus.Maldives.Core.Models
{
    public abstract class Tag
    {
        public int Id { get; set; }

        public Guid TagId { get; set; }

        public long CustomerId { get; set; }

        public string Name { get; set; }

        public abstract string Display();
    }
}
