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
            DefaultTemplate.SoldHomes.ElementType.InstanceType = typeof(HomeListItemJson);
        }

        void Handle(Input.AddNewHomeTrigger action)
        {
            var newHome = new Home()
            {
                AgencyOffice = this.Data as Office,
                Name = this.NewHomeName
            };

            this.SoldHomes.Add(new HomeListItemJson()
            {
                Data = newHome
            });

            this.NewHomeName = "";

            Transaction.Commit();
        }

        void Handle(Input.SaveOfficeTrigger action)
        {
            Transaction.Commit();
        }
    }
}
