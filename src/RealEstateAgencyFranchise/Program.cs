using Starcounter;
using RealEstateAgencyFranchise.Database;
using System.Linq;
using System.Collections.Generic;
using System;

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

                        var office1 = new Office()
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

                        new Home()
                        {
                            AgencyOffice = office1,
                            Address = new Address()
                            {
                                Country = "Country1",
                                ZipCode = "123123",
                                City = "City1",
                                Street = "Street1",
                                Number = "1"
                            },
                            Transaction = new TransactionInfo()
                            {
                                Date = DateTime.Parse("21-02-2016"),
                                Price = 1200000,
                                Commission = 20000
                            }
                        };
                        new Home()
                        {
                            AgencyOffice = office1,
                            Address = new Address()
                            {
                                Country = "Country2",
                                ZipCode = "123123",
                                City = "City2",
                                Street = "Stret2",
                                Number = "2"
                            },
                            Transaction = new TransactionInfo()
                            {
                                Date = DateTime.Parse("22-03-2017"),
                                Price = 1000000,
                                Commission = 12000
                            }
                        };

                        var office2 = new Office()
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

                        new Home()
                        {
                            AgencyOffice = office2,
                            Address = new Address()
                            {
                                Country = "Country3",
                                ZipCode = "123123",
                                City = "City3",
                                Street = "Street3",
                                Number = "3"
                            },
                            Transaction = new TransactionInfo()
                            {
                                Date = DateTime.Parse("01-01-2017"),
                                Price = 900000,
                                Commission = 30000
                            }
                        };
                        new Home()
                        {
                            AgencyOffice = office2,
                            Address = new Address()
                            {
                                Country = "Country4",
                                ZipCode = "123123",
                                City = "City4",
                                Street = "Street4",
                                Number = "4"
                            },
                            Transaction = new TransactionInfo()
                            {
                                Date = DateTime.Parse("13-02-2017"),
                                Price = 968000,
                                Commission = 7200
                            }
                        };
                        new Home()
                        {
                            AgencyOffice = office2,
                            Address = new Address()
                            {
                                Country = "Country5",
                                ZipCode = "123123",
                                City = "City5",
                                Street = "Street5",
                                Number = "5"
                            },
                            Transaction = new TransactionInfo()
                            {
                                Date = DateTime.Parse("25-06-2017"),
                                Price = 1420000,
                                Commission = 43000
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
