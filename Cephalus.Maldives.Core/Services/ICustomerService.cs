using Cephalus.Maldives.Core.Models;
using System;
using System.Collections.Generic;

namespace Cephalus.Maldives.Core.Services
{
    public interface ICustomerService
    {
        Customer Get(Guid id);

        IEnumerable<Customer> GetByTags(Guid[] tagIds);
    }
}
