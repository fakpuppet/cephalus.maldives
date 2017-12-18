using Cephalus.Maldives.Core.Models;
using Cephalus.Maldives.DAL.Contracts;
using Cephalus.Maldives.DAL.Sql.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Cephalus.Maldives.DAL.Sql
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
            CreateDummyData();
        }

        public void CreateDummyData()
        {
            using (var context = new MaldivesContext(_connectionString))
            {
                for (int i = 0; i < 8; i++)
                {
                    var country = new CountryDto()
                    {
                        Name = $"Sri Lanka {i}",
                        TagId = Guid.NewGuid()
                    };
                    var ethnicity = new EthnicityDto()
                    {
                        Name = "Zoroastrian",
                        TagId = Guid.NewGuid()
                    };
                    var watchBrand = new WatchBrandDto()
                    {
                        Name = "Panerai",
                        TagId = Guid.NewGuid()
                    };

                    var hiking = new SpecificActivityDto() { Name = "Hiking" };
                    var cycling = new SpecificActivityDto() { Name = "Cycling" };
                    var jerking = new SpecificActivityDto() { Name = "Jerking" };

                    var activity = new ActivityDto()
                    {
                        Activities = new List<SpecificActivityDto>() { hiking, cycling, jerking, },
                        TagId = Guid.NewGuid()
                    };
                    var customer = new CustomerDto()
                    {
                        BirthDate = DateTime.Now.AddYears(-54 + i),
                        CustomerId = Guid.NewGuid(),
                        CustomerNumber = $"HY398{i}FKK07",
                        Tags = new List<TagDto>() { ethnicity, country, watchBrand, /*activity*/ }
                    };

                    context.Entry(ethnicity).State = EntityState.Added;
                    context.Entry(country).State = EntityState.Added;

                    context.Entry(activity).State = EntityState.Added;

                    context.Entry(hiking).State = EntityState.Added;
                    context.Entry(cycling).State = EntityState.Added;
                    context.Entry(jerking).State = EntityState.Added;

                    context.Entry(watchBrand).State = EntityState.Added;
                    context.Entry(customer).State = EntityState.Added;
                }
                context.SaveChanges();
            }
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

        public IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagTypes)
        {
            return ExecuteOnContext(context =>
            {
                var tagTypeDtos = tagTypes.Select(t => (int)t);
                var customers = context.Customers
                    .Where(c => true);

                return customers.ToArray().Select(c => ConvertFromDto(c));
            });
        }

        public IEnumerable<Customer> GetByTagType(Type tagType)
        {
            return ExecuteOnContext(context =>
            {
                return context.Customers.Where(c => true).Select(c => ConvertFromDto(c));
            });
        }

        private T ExecuteOnContext<T>(Func<MaldivesContext, T> function)
        {
            using (var context = new MaldivesContext(_connectionString))
            {
                context.Configuration.ProxyCreationEnabled = false;
                context.Configuration.LazyLoadingEnabled = false;

                return function(context);
            }
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

        private Customer ConvertFromDto(CustomerDto dto)
        {
            return new Customer()
            {
                CustomerNumber = dto.CustomerNumber,
                BirthDate = dto.BirthDate,
                Tags = dto.Tags?.Select(t => ConvertTagFromDto(t))
            };
        }

        private Tag ConvertTagFromDto(TagDto dto)
        {
            return TagFactory.TagFromDto(dto);
        }

        private TagTypeDto FromTagType(TagType tagType)
        {
            return (TagTypeDto)tagType;
        }
    }
}
