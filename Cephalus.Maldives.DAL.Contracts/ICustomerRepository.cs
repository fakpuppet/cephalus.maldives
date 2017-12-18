using Cephalus.Maldives.Core.Models;
using System;
using System.Collections.Generic;

namespace Cephalus.Maldives.DAL.Contracts
{
    public interface ICustomerRepository
    {
        Customer Get(string customerNumber);

        Customer Get(Guid id);

        //IEnumerable<Customer> GetByTags(IEnumerable<Tag> tags);

        //IEnumerable<Customer> GetByTags(IEnumerable<Guid> tagIds);

        IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagTypes);
    }
}
