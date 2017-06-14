using Starcounter;

namespace RealEstateAgencyFranchise.Database
{
    [Database]
    public class Home
    {
        // task is simplified due to insufficient time - home does not have an address, only name
        //public Address Address { get; set; }
        public string Name { get; set; }

        public TransactionInfo Transaction { get; set; }

        public Office AgencyOffice { get; set; }
    }
}
