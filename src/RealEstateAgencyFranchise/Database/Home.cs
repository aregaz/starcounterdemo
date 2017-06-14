using Starcounter;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateAgencyFranchise.Database
{
    [Database]
    public class Home
    {
        // task is simplified due to insufficient time - home does not have an address, only name
        //public Address Address { get; set; }
        public string Name { get; set; }

        public ulong HomeId =>
            Db.SQL<ulong>(
                "select h.ObjectNo from Home h where h = ?",
                this)
            .First;

        public List<TransactionInfo> TransactionsInfo =>
            Db.SQL<TransactionInfo>(
                "select t from TransactionInfo t where t.AssociatedHome = ?",
                this)
            .ToList();

        public Office AgencyOffice { get; set; }

        public ulong AgencyOfficeId =>
            Db.SQL<ulong>(
                "select o.ObjectNo from Office o where o = ?",
                this.AgencyOffice)
            .First;
    }
}
