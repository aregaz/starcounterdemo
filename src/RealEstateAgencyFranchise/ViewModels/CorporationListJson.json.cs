using RealEstateAgencyFranchise.Database;
using Starcounter;

namespace RealEstateAgencyFranchise
{
    partial class CorporationListJson : Json
    {
        static CorporationListJson()
        {
            DefaultTemplate.Corporations.ElementType.InstanceType = typeof(CorporationListItemJson);
        }

        void Handle(Input.AddNewCorporationTrigger action)
        {
            var corporation = new Corporation()
            {
                Name = this.NewCorporationName
            };

            this.Corporations.Add(new CorporationListItemJson()
            {
                Data = corporation
            });

            this.NewCorporationName = "";

            Transaction.Commit();
        }
    }
}
