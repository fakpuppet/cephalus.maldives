using Cephalus.Maldives.DAL.Sql.Dto;
using System.Data.Entity;
using System.Linq;

namespace Cephalus.Maldives.DAL.Sql
{
    public class MaldivesContext : DbContext
    {
        public DbSet<CustomerDto> Customers { get; set; }

        public DbSet<TagDto> Tags { get; set; }

        public DbSet<SpecificActivityDto> SpecificActivities { get; set; }

        static MaldivesContext()
        {
            // Database.SetInitializer(new DropCreateDatabaseAlways<MaldivesContext>());
        }

        public MaldivesContext(string connectionString) 
            : base(connectionString)
        {
            Customers.Include(c => c.Tags).Load();
            Tags.OfType<ActivityDto>().Include(t => t.Activities).Load();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDto>()
                .ToTable("Customer")
                .HasKey(e => e.Id)
                .HasMany(e => e.Tags);

            modelBuilder.Entity<TagDto>()
                .ToTable("Tag")
                .HasKey(t => t.Id);

            modelBuilder.Entity<EthnicityDto>()
                .ToTable("Ethnicity");

            modelBuilder.Entity<CountryDto>()
                .ToTable("Country");

            modelBuilder.Entity<WatchBrandDto>()
                .ToTable("WatchBrand");

            modelBuilder.Entity<ActivityDto>()
                .ToTable("Activity")
                .HasMany(e => e.Activities);

            modelBuilder.Entity<SpecificActivityDto>()
                .ToTable("SpecificActivity")
                .HasRequired(s => s.Activity)
                .WithMany(s => s.Activities);
        }
    }
}
