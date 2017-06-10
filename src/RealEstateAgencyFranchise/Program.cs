using Starcounter;
using RealEstateAgencyFranchise.Database;
using System.Linq;

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
                return Db.Scope(() =>
                {
                    Corporation corporation;

                    var corporations = Db.SQL<Corporation>("select c from Corporation c");
                    if (corporations == null || !corporations.Any())
                    {
                        corporation = new Corporation()
                        {
                            Name = "REA Corporation #1"
                        };

                        new Office()
                        {
                            Corporation = corporation,
                            Name = "REA #1 - Office 1",
                            Address = new Address()
                            {
                                City = "Cairo",
                                Country = "Egypt",
                                Number = "42",
                                Street = "Slah Salem str.",
                                ZipCode = "01011"
                            }
                        };

                        new Office()
                        {
                            Corporation = corporation,
                            Name = "REA #1 - Office 2",
                            Address = new Address()
                            {
                                City = "Buenos Aires",
                                Country = "Argentina",
                                Number = "42",
                                Street = "Av. Osvaldo Cruz",
                                ZipCode = "00110"
                            }
                        };
                    }
                    else
                    {
                        corporation = corporations.First;
                    }

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
            });
        }
    }
}
