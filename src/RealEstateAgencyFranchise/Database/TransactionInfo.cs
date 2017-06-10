using Starcounter;
using System;

namespace RealEstateFranchiseAgency.Database
{
    [Database]
    public class TransactionInfo
    {
        public DateTime Date { get; set; }

        public double SalesPrice { get; set; }

        public double Commission { get; set; }
    }
}
