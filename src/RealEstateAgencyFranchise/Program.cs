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
        private static CorporationController _corporationController = new CorporationController();
        private static OfficeController _officeController = new OfficeController();
        private static HomeController _homeController = new HomeController();

        public static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            RegisterRoutes();
        }

        private static void RegisterRoutes()
        {
            Handle.GET("/franchises", () =>
            {
                return _corporationController.GetAll();
            });

            Handle.GET("/franchises/{?}/details", (ulong corporationObjectNo) =>
            {
                return _corporationController.Get(corporationObjectNo);
            });

            Handle.GET("/franchises/offices/{?}/details", (ulong officeObjectNo) =>
            {
                return _officeController.Get(officeObjectNo);
            });

            Handle.GET("/franchises/homes/{?}/details", (ulong homeObjectNo) =>
            {
                return _homeController.Get(homeObjectNo);
            });
        }
    }
}
