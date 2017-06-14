using Starcounter;

namespace RealEstateAgencyFranchise.ViewModels
{
    partial class OfficeAddressJson : Json
    {
        void Handle(Input.SaveAddressTrigger action)
        {
            Transaction.Commit();
        }
    }
}
