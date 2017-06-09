using Starcounter;

namespace RealEstateFranchiseAgency.Database
{
    [Database]
    public class Home
    {
        public Address Address { get; set; }

        public TransactionInfo Transaction { get; set; }
    }
}
