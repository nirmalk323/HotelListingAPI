namespace HotelListing.API.Model.Country
{
    public class CreateCountryDto : BaseCountryDto
    {
        public new string Name { get; set; }
        public new string ShortName { get; set; }
    }
}
