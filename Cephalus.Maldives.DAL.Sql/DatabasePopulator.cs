using Cephalus.Maldives.DAL.Sql.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Cephalus.Maldives.DAL.Sql
{
    public static class DatabasePopulator
    {
        public static void CreateDummyData(DbContext context, bool execute = false)
        {
            if (!execute) return;

            using (context)
            {
                for (int i = 0; i < 8; i++)
                {
                    var country = new CountryDto()
                    {
                        Name = $"Sri Lanka {i}",
                    };
                    var ethnicity = new EthnicityDto()
                    {
                        Name = "Zoroastrian",
                    };
                    var watchBrand = new WatchBrandDto()
                    {
                        Name = "Panerai",
                    };

                    var hiking = new SpecificActivityDto() { Name = "Hiking" };
                    var cycling = new SpecificActivityDto() { Name = "Cycling" };
                    var jerking = new SpecificActivityDto() { Name = "Jerking" };

                    var activity = new ActivityDto()
                    {
                        Activities = new List<SpecificActivityDto>() { hiking, cycling, jerking, },
                    };
                    var customer = new CustomerDto()
                    {
                        BirthDate = DateTime.Now.AddYears(-54 + i),
                        CustomerNumber = $"HY398{i}K07K",
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
    }
}
