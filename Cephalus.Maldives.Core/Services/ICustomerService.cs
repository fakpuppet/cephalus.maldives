using Cephalus.Maldives.Core.Models;
using System;
using System.Collections.Generic;

namespace Cephalus.Maldives.Core.Services
{
    public interface ICustomerService
    {
        void Create(Customer customer);

        void Update(Customer customer);

        Customer Get(Guid id);

        IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagType, string[] keyWords);
    }
}
