using RealEstateAgencyFranchise.Database;
using Starcounter;

namespace RealEstateAgencyFranchise
{
    partial class OfficeListJson : Json
    {
        static OfficeListJson()
        {
            DefaultTemplate.Offices.ElementType.InstanceType = typeof(OfficeListItemJson);
        }

        void Handle(Input.SaveTrigger action)
        {
            Transaction.Commit();
        }

        void Handle(Input.NewOfficeTrigger action)
        {
            new Office()
            {
                Corporation = this.Data as Corporation,
                Address = new Address(),
                Trend = 0,
                Name = this.NewOfficeName
            };

            this.NewOfficeName = "";

            Transaction.Commit();
        }
    }
}
