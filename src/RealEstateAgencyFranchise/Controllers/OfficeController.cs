using RealEstateAgencyFranchise.Database;
using RealEstateAgencyFranchise.ViewModels;
using Starcounter;
using System.Linq;

namespace RealEstateAgencyFranchise.Controllers
{
    internal class OfficeController
    {
        public Json Get(ulong officeObjectNo)
        {
            return Db.Scope(() =>
            {
                var offices = Db.SQL<Office>(
                    "select o from Office o where o.ObjectNo = ?",
                    officeObjectNo);
                if (offices == null || !offices.Any())
                {
                    return new Response()
                    {
                        StatusCode = 404,
                        StatusDescription = "Office not found"
                    };
                }

                var office = offices.First;

                var json = new OfficeDetailsJson
                {
                    Data = office
                };

                if (Session.Current == null)
                {
                    Session.Current = new Session(SessionOptions.PatchVersioning);
                }

                json.Session = Session.Current;
                return json;
            });
        }
    }
}
