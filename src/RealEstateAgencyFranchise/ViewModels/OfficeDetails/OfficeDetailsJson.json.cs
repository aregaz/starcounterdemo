using RealEstateAgencyFranchise.Database;
using RealEstateAgencyFranchise.ViewModels.OfficeDetails;
using Starcounter;

namespace RealEstateAgencyFranchise.ViewModels
{
    partial class OfficeDetailsJson : Json
    {
        static OfficeDetailsJson()
        {
            DefaultTemplate.Address.InstanceType = typeof(OfficeAddressJson);
            DefaultTemplate.Homes.ElementType.InstanceType = typeof(HomeListItemJson);
        }

        void Handle(Input.AddNewHomeTrigger action)
        {
            var newHome = new Home()
            {
                AgencyOffice = this.Data as Office,
                Name = this.NewHomeName
            };

            this.Homes.Add(new HomeListItemJson()
            {
                Data = newHome
            });

            this.NewHomeName = "";
            Transaction.Commit();
        }
    }
}
