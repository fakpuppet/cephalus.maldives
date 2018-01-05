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

        public Guid AddTag(Tag tag)
        {
            return _customerRepository.AddTag(tag);
        }

        public void Create(Customer customer)
        {
            _customerRepository.Create(customer);
        }

        public Customer Get(Guid id)
        {
            return _customerRepository.Get(id);
        }

        public IEnumerable<Customer> GetByAny(IEnumerable<TagType> tagTypes, string[] keyWords)
        {
            var tagTypeCollection = tagTypes?.Any() == true ? tagTypes : EnumExtensions.GetValues<TagType>();

            return _customerRepository.GetByAny(tagTypeCollection, keyWords);
        }

        public IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagTypes, string[] keyWords)
        {
            var tagTypeCollection = tagTypes?.Any() == true ? tagTypes : EnumExtensions.GetValues<TagType>();

            return _customerRepository.GetByTags(tagTypeCollection, keyWords);
        }

        public void Update(Customer customer)
        {
            _customerRepository.Update(customer);
        }
    }
}
