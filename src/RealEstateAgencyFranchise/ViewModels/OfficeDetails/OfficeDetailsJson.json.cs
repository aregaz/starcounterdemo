using Starcounter;

namespace RealEstateAgencyFranchise.ViewModels
{
    partial class OfficeDetailsJson : Json
    {
        static OfficeDetailsJson()
        {
            DefaultTemplate.Address.InstanceType = typeof(OfficeAddressJson);
        }
    }
}
