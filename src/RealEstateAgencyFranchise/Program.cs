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
        private static CorporationListController _corporationListController = new CorporationListController();

        public static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            Handle.GET("/franchises", () =>
            {
                return _corporationListController.GetCorporationList();
            });

            Handle.GET("/franchises/{?}/details", (long corporationObjectNo) =>
            {
                return _corporationListController.GetCorporationDetails(corporationObjectNo);
            });
        }
    }
}
