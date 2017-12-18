using System;
using System.Collections.Generic;
using System.Linq;
using Cephalus.Maldives.Core.Models;
using Cephalus.Maldives.Core.Services;
using Cephalus.Maldives.DAL.Contracts;

namespace Cephalus.Maldives.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer Get(Guid id)
        {
            return _customerRepository.Get(id);
        }

        public IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagType)
        {
            var tagTypeCollection = tagType?.Any() == true ? tagType : Enumerable.Empty<TagType>();

            return _customerRepository.GetByTags(tagType);
        }
    }
}
