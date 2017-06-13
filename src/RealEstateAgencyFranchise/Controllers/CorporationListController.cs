using RealEstateAgencyFranchise.Database;
using Starcounter;
using System.Linq;

namespace RealEstateAgencyFranchise.Controllers
{
    internal class CorporationListController
    {
        public Json GetCorporationList()
        {
            return Db.Scope(() =>
            {
                Corporation corporation;

                var corporations = Db.SQL<Corporation>("select c from Corporation c");
                if (corporations == null || !corporations.Any())
                {
                    // add seed corporation
                    corporation = new Corporation()
                    {
                        Name = "REA Corporation #1"
                    };
                }
                else
                {
                    corporation = corporations.First;
                }

                var json = new CorporationListJson
                {
                    Data = corporation
                };

                if (Session.Current == null)
                {
                    Session.Current = new Session(SessionOptions.PatchVersioning);
                }

                json.Session = Session.Current;
                return json;
            });
        }

        public Json GetCorporationDetails(long corporationObjectNo)
        {
            return Db.Scope(() =>
            {
                Corporation corporation;

                var corporations = Db.SQL<Corporation>(
                    "select c from Corporation c where c.ObjectNo = ?",
                    corporationObjectNo);
                if (corporations == null || !corporations.Any())
                {
                    return new Response()
                    {
                        StatusCode = 404,
                        StatusDescription = "Corporation not found"
                    };
                }
                else
                {
                    corporation = corporations.First;
                }

                var json = new AgencyOfficeListJson
                {
                    Data = corporation
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
