using Starcounter;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateAgencyFranchise.Database
{
    [Database]
    public class Office
    {
        public string Name { get; set; }

        public ulong OfficeId =>
            Db.SQL<ulong>(
                "select o.ObjectNo from Office o where o = ?",
                this)
            .First;

        public Corporation Corporation { get; set; }

        public ulong CorporationId =>
            Db.SQL<ulong>(
                "select c.ObjectNo from Corporation c where c = ?",
                this.Corporation)
            .First;

        public Address Address { get; set; }

        public List<Home> SoldHomes =>
            Db.SQL<Home>(
                "SELECT h FROM Home h WHERE h.AgencyOffice = ?",
                this)
            .ToList();

        public long SoldHomesCount =>
            Db.SQL<long>(
                "SELECT COUNT(h) FROM Home h WHERE h.AgencyOffice = ?",
                this)
            .First;

        public double TotalComission =>
            Db.SQL<double>(
                "SELECT SUM(t.Commission) " +
                "FROM Home h " +
                "JOIN TransactionInfo t ON h.Transaction = t " +
                "WHERE h.AgencyOffice = ?",
                this)
            .FirstOrDefault();

        public double AverageCommission =>
            SoldHomesCount == 0
                ? 0
                : TotalComission / SoldHomesCount;

        public double Trend { get; set; }
    }
}
