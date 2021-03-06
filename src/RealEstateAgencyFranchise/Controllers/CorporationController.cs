﻿using RealEstateAgencyFranchise.Database;
using Starcounter;
using System.Linq;

namespace RealEstateAgencyFranchise.Controllers
{
    internal class CorporationController
    {
        public Json GetAll()
        {
            return Db.Scope(() =>
            {
                var corporations = Db.SQL<Corporation>("select c from Corporation c");
                if (corporations == null || !corporations.Any())
                {
                    // add seed corporation
                    var corporation = new Corporation()
                    {
                        Name = "REA Corporation #1"
                    };
                    corporations = Db.SQL<Corporation>("select c from Corporation c");
                }

                var json = new CorporationListJson
                {
                    Corporations = corporations
                };

                if (Session.Current == null)
                {
                    Session.Current = new Session(SessionOptions.PatchVersioning);
                }

                json.Session = Session.Current;
                return json;
            });
        }

        public Json Get(ulong corporationObjectNo)
        {
            return Db.Scope(() =>
            {
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

                var corporation = corporations.First;

                var json = new OfficeListJson
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
