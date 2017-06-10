using Starcounter;
using System.Collections.Generic;
using System.Linq;

namespace RealEstateFranchiseAgency.Database
{
    [Database]
    public class Corporation
    {
        public string Name { get; set; }

        public List<Office> Offices => Db.SQL<Office>("select o from Office o").ToList();
    }
}
