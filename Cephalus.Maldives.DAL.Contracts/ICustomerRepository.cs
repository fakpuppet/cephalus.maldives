using Cephalus.Maldives.Core.Models;
using System;
using System.Collections.Generic;

namespace Cephalus.Maldives.DAL.Contracts
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);

        Customer Get(string customerNumber);

        Customer Get(Guid id);

        IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagTypes, string keyWord);
    }
}
