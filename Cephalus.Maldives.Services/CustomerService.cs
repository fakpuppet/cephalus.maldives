using System;
using System.Collections.Generic;
using System.Linq;
using Cephalus.Maldives.Common.Extensions;
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

        public void Create(Customer customer)
        {
            _customerRepository.Create(customer);
        }

        public Customer Get(Guid id)
        {
            return _customerRepository.Get(id);
        }

        public IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagType, string[] keyWords)
        {
            var tagTypeCollection = tagType?.Any() == true ? tagType : EnumExtensions.GetValues<TagType>();

            return _customerRepository.GetByTags(tagTypeCollection, keyWords);
        }
    }
}
