using Starcounter;
using RealEstateAgencyFranchise.Database;
using System.Linq;
using System.Collections.Generic;
using System;
using RealEstateAgencyFranchise.Controllers;

namespace RealEstateAgencyFranchise
{
    public class Program
    {
        private static CorporationController _corporationListController = new CorporationController();

        public static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            Handle.GET("/franchises", () =>
            {
                return _corporationListController.GetAll();
            });

            Handle.GET("/franchises/{?}/details", (ulong corporationObjectNo) =>
            {
                return _corporationListController.Get(corporationObjectNo);
            });
        }
    }
}
