﻿using System;
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

        public IEnumerable<Customer> GetByTags(Guid[] tagIds)
        {
            var tagCollection = tagIds?.Any() == true ? tagIds : Enumerable.Empty<Guid>();

            return _customerRepository.GetByTags(tagCollection);
        }
    }
}
