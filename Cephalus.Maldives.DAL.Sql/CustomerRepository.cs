using Cephalus.Maldives.Core.Models;
using Cephalus.Maldives.DAL.Contracts;
using Cephalus.Maldives.DAL.Sql.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cephalus.Maldives.DAL.Sql
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
            // CreateDummyData();
        }

        public void CreateDummyData()
        {
            using (var context = new MaldivesContext(_connectionString))
            {
                var country = new CountryDto()
                {
                     Name = "Sri Lanka",
                     TagId = Guid.NewGuid()
                };
                var ethnicity = new EthnicityDto()
                {
                    Name = "Zoroastrian",
                    TagId = Guid.NewGuid()
                };
                var customrer = new CustomerDto()
                {
                    BirthDate = DateTime.Now.AddYears(-54),
                    CustomerId = Guid.NewGuid(),
                    CustomerNumber = "HY398YFKK07",
                    Tags = new List<TagDto>() { ethnicity, country }
                };

                context.Entry(ethnicity).State = System.Data.Entity.EntityState.Added;
                context.Entry(country).State = System.Data.Entity.EntityState.Added;
                context.Entry(customrer).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        public Customer Get(string customerNumber)
        {
            using (var context = new MaldivesContext(_connectionString))
            {
                return context.Customers
                    .Where(c => c.CustomerNumber == customerNumber)
                    .Select(c => ConvertToCustomer(c))
                    .FirstOrDefault();
            }
        }

        public Customer Get(Guid id)
        {
            using (var context = new MaldivesContext(_connectionString))
            {
                var customer = context.Customers
                    .FirstOrDefault(c => c.CustomerId == id);

                return ConvertToCustomer(customer);
            }
        }

        public IEnumerable<Customer> GetByTags(IEnumerable<Tag> tags)
        {
            using (var context = new MaldivesContext(_connectionString))
            {
                Func<CustomerDto, bool> whereSelector;

                if (!tags.Any())
                {
                    whereSelector = c => true;
                }
                else
                {
                    whereSelector = c => c.Tags?.Select(t => t.TagId).Intersect(tags.Select(t => t.TagId)).Any() == true;
                }

                var customers = context.Customers
                    .Where(whereSelector).ToArray();

                return customers.Select(c => ConvertToCustomer(c));
            }
        }

        public IEnumerable<Customer> GetByTags(IEnumerable<Guid> tagIds)
        {
            using (var context = new MaldivesContext(_connectionString))
            {
                Func<CustomerDto, bool> whereSelector;

                if (!tagIds.Any())
                {
                    whereSelector = c => true;
                }
                else
                {
                    whereSelector = c => c.Tags?.Select(t => t.TagId).Intersect(tagIds).Any() == true;
                }

                var customers = context.Customers
                    .Where(whereSelector).ToArray();

                return customers.Select(c => ConvertToCustomer(c)).ToArray();
            }
        }

        public void AddSomeShit()
        {
            using (var context = new MaldivesContext(_connectionString))
            {

                EthnicityDto ethnicityDto = new EthnicityDto() { Name = "Somali", TagId = Guid.NewGuid() };

                var customer = new CustomerDto()
                {
                    BirthDate = DateTime.Now.AddYears(-49),
                    CustomerId = Guid.NewGuid(),
                    CustomerNumber = "JJEI395NG77",
                    Tags = new List<TagDto>() { ethnicityDto }
                };

                context.Entry(ethnicityDto).State = System.Data.Entity.EntityState.Added;
                context.Entry(customer).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();
            }
        }

        private Customer Get(Expression<Func<CustomerDto, bool>> predicate)
        {
            using (var context = new MaldivesContext(_connectionString))
            {
                var customer = context.Customers
                    .FirstOrDefault(predicate);

                return ConvertToCustomer(customer);
            }
        }

        private Customer ConvertToCustomer(CustomerDto dto)
        {
            return new Customer()
            {
                CustomerNumber = dto.CustomerNumber,
                BirthDate = dto.BirthDate,
                Tags = dto.Tags.Select(t => ConvertTagFromDto(t))
            };
        }

        private Tag ConvertTagFromDto(TagDto dto)
        {
            return TagFactory.TagFromDto(dto);

            throw new ArgumentException("cannot have this type mapped");
        }
    }
}
