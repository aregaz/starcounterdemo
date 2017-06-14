using Starcounter;
using System;

namespace RealEstateAgencyFranchise.Database
{
    [Database]
    public class TransactionInfo
    {
        public DateTime Date { get; set; }

        public double Price { get; set; }

        public double Commission { get; set; }

        public Home AssociatedHome { get; set; }
    }
}
