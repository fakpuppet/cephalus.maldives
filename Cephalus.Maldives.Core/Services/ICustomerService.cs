﻿using Cephalus.Maldives.Core.Models;
using System;
using System.Collections.Generic;

namespace Cephalus.Maldives.Core.Services
{
    public interface ICustomerService
    {
        Guid AddTag(Tag tag);

        void Create(Customer customer);

        Customer Get(Guid id);

        IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagTypes, string[] keyWords);

        IEnumerable<Customer> GetByAny(IEnumerable<TagType> tagTypes, string[] keyWords);

        void Update(Customer customer);
    }
}
