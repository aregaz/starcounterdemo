using Starcounter;
using RealEstateAgencyFranchise.Database;

namespace RealEstateAgencyFranchise
{
    public class Program
    {
        public static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            Handle.GET("/RealEstateAgencyFranchise", () =>
            {
                var corporation = Db.SQL<Corporation>("select c from Corporation c").First;

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
