using Cephalus.Maldives.Core.Models;
using Cephalus.Maldives.DAL.Contracts;
using Cephalus.Maldives.DAL.Sql.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Cephalus.Maldives.DAL.Sql
{
    public class CustomerRepository : RepositoryBase, ICustomerRepository
    {
        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;

            DatabasePopulator.CreateDummyData(new MaldivesContext(_connectionString));
        }

        public Guid AddTag(Tag tag)
        {
            return ExecuteOnContext(context =>
            {
                context.Entry(tag).State = EntityState.Added;

                context.SaveChanges();

                return tag.TagId;
            });
        }

        public void Create(Customer customer)
        {
            ExecuteOnContext(context =>
            {
                var dto = ConvertToDto(customer);

                foreach (var tag in dto.Tags)
                {
                    context.Entry(tag).State = EntityState.Added;
                }

                context.Entry(dto).State = EntityState.Added;

                return context.SaveChanges();
            });
        }

        public Customer Get(long id)
        {
            return ExecuteOnContext(context =>
            {
                var customer = context.Customers
                    .FirstOrDefault(c => c.Id == id);

                return ConvertFromDto(customer);
            });
        }

        public Customer Get(Guid id)
        {
            return ExecuteOnContext(context =>
            {
                var customer = context.Customers
                    .FirstOrDefault(c => c.CustomerId == id);

                return ConvertFromDto(customer);
            });
        }

        public Customer Get(string customerNumber)
        {
            return ExecuteOnContext(context =>
            {
                return context.Customers
                    .Where(c => c.CustomerNumber == customerNumber)
                    .Select(c => ConvertFromDto(c))
                    .FirstOrDefault();
            });
        }

        public IEnumerable<Customer> GetByAny(IEnumerable<TagType> tagTypes, string[] keyWords)
        {
            return ExecuteOnContext(context =>
            {
                var comparer = new EqualityComparer();

                return (context.Customers
                    .Where(c => keyWords.Any(k => c.CustomerNumber.Contains(k)))
                    .ToArray()
                    .Select(c => ConvertFromDto(c))
                    .Union(GetByTags(tagTypes, keyWords)))
                    .Distinct(comparer);
            });
        }

        public IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagTypes, string[] keyWords)
        {
            return ExecuteOnContext(context =>
            {
                var tagTypeDtos = tagTypes.Select(t => (int)t).ToArray();
                var customers = context.Customers
                    .Where(c => tagTypeDtos.Intersect(c.Tags.Select(t => (int)t.TagType)).Any());

                return customers
                    .ToArray()
                    .Where(c => c.Tags.Any(t => t.IsMatch(keyWords)))
                    .Select(c => ConvertFromDto(c));
            });
        }

        public void Update(Customer customer)
        {
            ExecuteOnContext<object>(context =>
            {
                var dto = ConvertToDto(customer);
                var entity = context.Customers.SingleOrDefault(e => e.Id == customer.Id);

                context.Entry(entity).CurrentValues.SetValues(dto);

                return context.SaveChanges();
            });
        }

        private Customer ConvertFromDto(CustomerDto dto)
        {
            return new Customer()
            {
                Id = dto.Id,
                CustomerId = dto.CustomerId,
                CustomerNumber = dto.CustomerNumber,
                BirthDate = dto.BirthDate,
                Tags = dto.Tags?.Select(t => ConvertTagFromDto(t))
            };
        }

        private Tag ConvertTagFromDto(TagDto dto)
        {
            return TagFactory.TagFromDto(dto);
        }

        private TagDto ConvertTagToTagDto(Tag tag)
        {
            return TagDtoFactory.TagDtoFromTag(tag);
        }

        private CustomerDto ConvertToDto(Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                CustomerNumber = customer.CustomerNumber,
                CustomerId = customer.CustomerId,
                BirthDate = customer.BirthDate,
                Tags = customer.Tags?.Select(t => ConvertTagToTagDto(t)).ToArray()
            };
        }

        private TagTypeDto FromTagType(TagType tagType)
        {
            return (TagTypeDto)tagType;
        }

        private Customer Get(Expression<Func<CustomerDto, bool>> predicate)
        {
            return ExecuteOnContext(context =>
            {
                var customer = context.Customers
                    .FirstOrDefault(predicate);

                return ConvertFromDto(customer);
            });
        }

        private class EqualityComparer : IEqualityComparer<Customer>
        {
            public bool Equals(Customer x, Customer y)
            {
                if (x == null || y == null)
                {
                    return false;
                }

                return x.CustomerId == y.CustomerId;
            }

            public int GetHashCode(Customer obj)
            {
                return obj.CustomerId.GetHashCode();
            }
        }
    }
}
