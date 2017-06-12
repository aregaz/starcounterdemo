using Starcounter;

namespace RealEstateAgencyFranchise.Database
{
    [Database]
    public class Home
    {
        public Address Address { get; set; }

        public TransactionInfo Transaction { get; set; }

        public Office AgencyOffice { get; set; }
    }
}
