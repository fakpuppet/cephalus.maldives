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
            // CreateDummyData();
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
                        Tags = new List<TagDto>() { ethnicity, country, watchBrand, activity }
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

        public void Create(Customer customer)
        {
            ExecuteOnContext(context => 
            {
                var dto = ConvertToDto(customer);

                context.Entry(dto).State = EntityState.Added;

                return context.SaveChanges();
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

        public IEnumerable<Customer> GetByTags(IEnumerable<TagType> tagTypes, string[] keyWords)
        {
            return ExecuteOnContext(context =>
            {
                var tagTypeDtos = tagTypes.Select(t => (int)t).ToArray();
                var customers = context.Customers
                    .Include(m => m.Tags)
                    .Where(c => tagTypeDtos.Intersect(c.Tags.Select(t => (int)t.TagType)).Any());

                return customers
                    .ToArray()
                    .Where(c => c.Tags.Where(t => tagTypeDtos.Contains((int)t.TagType)).Any(t => t.IsMatch(keyWords)))
                    .Select(c => ConvertFromDto(c));
            });
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

        private CustomerDto ConvertToDto(Customer customer)
        {
            return new CustomerDto
            {
                CustomerNumber = customer.CustomerNumber,
                BirthDate = customer.BirthDate,
                Tags = customer.Tags.Select(t => ConvertTagToTagDto(t)).ToArray()
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

        private TagTypeDto FromTagType(TagType tagType)
        {
            return (TagTypeDto)tagType;
        }

    }
}
