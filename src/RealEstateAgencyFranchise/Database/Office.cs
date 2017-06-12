using Starcounter;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateAgencyFranchise.Database
{
    [Database]
    public class Office
    {
        public string Name { get; set; }

        public Corporation Corporation { get; set; }

        public Address Address { get; set; }

        public List<Home> SoldHomes =>
            Db.SQL<Home>(
                "select h from Home h where h.AgencyOffice = ?",
                this)
            .ToList();

        public long SoldHomesCount =>
            //Db.SQL<long>(
            //    "SELECT COUNT(*) FROM Home h WHERE h.AgencyOffice = ?",
            //    this)
            //.First; // why does not work?
            SoldHomes.Count;

        public double TotalComission =>
            Db.SQL<double>(
                "SELECT SUM(t.Commission) " +
                "FROM Home h " +
                "JOIN TransactionInfo t ON h.Transaction = t " +
                "WHERE h.AgencyOffice = ?",
                this)
            .First;

        public double AverageComission => TotalComission / AverageComission;

        public double Trend { get; set; }
    }
}
