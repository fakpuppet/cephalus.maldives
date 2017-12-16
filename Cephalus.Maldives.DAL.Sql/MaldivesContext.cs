using Cephalus.Maldives.DAL.Sql.Dto;
using System.Data.Entity;

namespace Cephalus.Maldives.DAL.Sql
{
    public class MaldivesContext : DbContext
    {
        public DbSet<CustomerDto> Customers { get; set; }

        public DbSet<TagDto> Tags { get; set; }

        static MaldivesContext()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<MaldivesContext>());
        }

        public MaldivesContext(string connectionString) 
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDto>()
                .ToTable("Customer")
                .HasKey(e => e.Id)
                .HasMany(e => e.Tags);

            modelBuilder.Entity<EthnicityDto>()
                .ToTable("Ethnicity");

            modelBuilder.Entity<CountryDto>()
                .ToTable("Country");

            modelBuilder.Entity<WatchBrandDto>()
                .ToTable("WatchBrand");

            modelBuilder.Entity<ActivityDto>()
                .ToTable("Activity");
        }
    }
}
