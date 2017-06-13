using RealEstateAgencyFranchise.Database;
using Starcounter;

namespace RealEstateAgencyFranchise
{
    partial class AgencyOfficeListJson : Json
    {
        static AgencyOfficeListJson()
        {
            DefaultTemplate.Offices.ElementType.InstanceType = typeof(AgencyOfficeJson);
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
        }
    }
}
