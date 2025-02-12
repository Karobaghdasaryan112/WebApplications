
namespace S.P.WithCleanArchitecture.Domain.ValueObjects
{
    public class AddressValueObject
    {


        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public AddressValueObject(string street, string city, string postalCode, string country)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
            Country = country;

        }


    }
}
