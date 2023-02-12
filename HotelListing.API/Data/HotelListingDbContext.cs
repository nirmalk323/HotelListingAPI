using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Adayar Anantha Bhavan",
                    Address = "Downtown",
                    CountryId= 4,
                    Rating= 4.3,
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Anjappar",
                    Address = "Texas",
                    CountryId = 1,
                    Rating = 4.5,
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Saravana Bhavan",
                    Address = "Bangalore",
                    CountryId = 3,
                    Rating = 4,
                },
                new Hotel
                {
                    Id = 4,
                    Name = "Junior Kuppanna",
                    Address = "Coimbatore",
                    CountryId = 3,
                    Rating = 3,
                });

            modelBuilder.Entity<Country>().HasData(
               new Country
               {
                   Id= 1,
                   Name="United States",
                   ShortName="US"
               },
               new Country
               {
                   Id = 2,
                   Name = "Australia",
                   ShortName = "AUS"
               },
               new Country
               {
                   Id = 3,
                   Name = "India",
                   ShortName = "IND"
               },
               new Country
               {
                   Id = 4,
                   Name = "Cannada",
                   ShortName = "CAN"
               });
        }
    }
}
