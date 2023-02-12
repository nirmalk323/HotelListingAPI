using HotelListing.API.Model.Country;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Model.Hotel
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; }
    }
}
