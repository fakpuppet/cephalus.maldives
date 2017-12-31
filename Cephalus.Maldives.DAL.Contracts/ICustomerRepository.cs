using Cephalus.Maldives.Core.Models;
using System;
using System.Collections.Generic;

namespace Cephalus.Maldives.DAL.Contracts
{
    public interface ICustomerRepository
    {
        Guid AddTag(Tag tag);

        void Create(Customer customer);

        Customer Get(string customerNumber);

        Customer Get(Guid id);

        Customer Get(long id);

        IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagTypes, string[] keyWords);

        void Update(Customer customer);
    }
}
