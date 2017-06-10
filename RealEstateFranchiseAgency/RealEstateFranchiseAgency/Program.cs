using Starcounter;
using RealEstateFranchiseAgency.Database;

namespace RealEstateFranchiseAgency
{
    public class Program
    {
        public static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            Handle.GET("/RealEstateFranchiseAgency", () =>
            {
                var corporation = Db.SQL<Corporation>("select c from Corporation").First;

                var json = new CorporationJson
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
