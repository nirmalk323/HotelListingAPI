using HotelListing.API.Contracts;
using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repositories
{
    public class CountryRepository : GenericRepository<Country> , ICountryRepository
    {
        private HotelListingDbContext _context;

        public CountryRepository(HotelListingDbContext hotelListingDbContext) : base(hotelListingDbContext)
        {
            _context = hotelListingDbContext;
        }

        public async Task<Country> GetCountryDetails(int id)
        {
            return await _context.Countries.Include(x=>x.Hotel).FirstOrDefaultAsync(x=>x.Id == id) ;
        }
    }
}
