using Starcounter;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateAgencyFranchise.Database
{
    [Database]
    public class Corporation
    {
        public string Name { get; set; }

        public List<Office> Offices => Db.SQL<Office>("select o from Office o").ToList();

        public ulong CorporationId =>
            Db.SQL<ulong>(
                "select c.ObjectNo from Corporation c where c = ?",
                this)
            .FirstOrDefault();
    }
}
