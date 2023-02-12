using HotelListing.API.Contracts;
using HotelListing.API.Data;

namespace HotelListing.API.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(HotelListingDbContext hotelListingDbContext) : base(hotelListingDbContext)
        {
        }
    }
}
