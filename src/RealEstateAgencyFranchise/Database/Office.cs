using Starcounter;

namespace RealEstateFranchiseAgency.Database
{
    [Database]
    public class Office
    {
        public string Name { get; set; }

        public Corporation Corporation { get; set; }

        public Address Address { get; set; }
    }
}
