using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Model
{
    public class Hotel
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(CountryId))]
        public int CountryId { get; set; }
        public double Rating { get; set; }
        public string Address { get; set; }
        public Country Country { get; set; }
    }
}
