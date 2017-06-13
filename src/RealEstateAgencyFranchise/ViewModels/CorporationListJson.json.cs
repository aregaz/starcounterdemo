using RealEstateAgencyFranchise.Database;
using Starcounter;

namespace RealEstateAgencyFranchise
{
    partial class CorporationListJson : Json
    {
        static CorporationListJson()
        {
            DefaultTemplate.Corporations.ElementType.InstanceType = typeof(CorporationJson);
        }

        void Handle(Input.AddNewCorporationTrigger action)
        {
            var corporation = new Corporation()
            {
                Name = this.NewCorporationName
            };

            this.Corporations.Add(new CorporationJson() { Name = this.NewCorporationName });

            this.NewCorporationName = "";
        }
    }
}
