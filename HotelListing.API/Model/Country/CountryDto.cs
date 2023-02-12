using HotelListing.API.Model.Hotel;

namespace HotelListing.API.Model.Country
{
    public class CountryDto : BaseCountryDto
    {
        public int Id { get; set; }
        public virtual IList<HotelDto> Hotel { get; set; }
    }
}
