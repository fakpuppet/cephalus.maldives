using Cephalus.Maldives.Core.Models;
using Cephalus.Maldives.DAL.Contracts;
using System;
using System.Collections.Generic;

namespace Cephalus.Maldives.DAL.Txt
{
    public class ContactRepository : ICustomerRepository
    {
        public ContactRepository()
        {
        }

        public Guid AddTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public void Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Customer Get(string customerNumber)
        {
            throw new NotImplementedException();
        }

        public Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetByAny(IEnumerable<TagType> tagTypes, string[] keyWords)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetByTags(IEnumerable<Tag> tags)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetByTags(IEnumerable<Guid> tagIds)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagTypes, string[] keyWords)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
