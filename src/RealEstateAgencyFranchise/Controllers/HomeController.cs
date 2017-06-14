using RealEstateAgencyFranchise.Database;
using RealEstateAgencyFranchise.ViewModels.HomeDetails;
using Starcounter;
using System.Linq;

namespace RealEstateAgencyFranchise.Controllers
{
    internal class HomeController
    {
        public Json Get(ulong homeObjectNo)
        {
            return Db.Scope(() =>
            {
                var homes = Db.SQL<Home>(
                    "select h from Home h where h.ObjectNo = ?",
                    homeObjectNo);
                if (homes == null || !homes.Any())
                {
                    return new Response()
                    {
                        StatusCode = 404,
                        StatusDescription = "Office not found"
                    };
                }

                var home = homes.First;

                var json = new HomeDetailsJson
                {
                    Data = home
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
