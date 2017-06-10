using Starcounter;

namespace RealEstateAgencyFranchise
{
    partial class CorporationJson : Json
    {
        static CorporationJson()
        {
            DefaultTemplate.Offices.ElementType.InstanceType = typeof(AgencyOfficeJson);
        }

        void Handle(Input.SaveTrigger action)
        {
            Transaction.Commit();
        }
    }
}
