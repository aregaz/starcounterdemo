using Starcounter;

namespace RealEstateFranchiseAgency.Database
{
    [Database]
    public class Address
    {
        public string Street { get; set; }

        public string Number { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string FullAddress => $"{Street} {Number}, {ZipCode} {City}, {Country}";
    }
}
