using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace avisFormations.WebUi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "contact",
               url: "Contactez_nous",
               defaults: new { controller = "contact", action = "Index" }
               );

            routes.MapRoute(
               name: "Toute_Les_Formations",
               url: "Toute_Les_Formations",
               defaults: new { controller = "Formation", action = "ToutesLesFormations" }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
           
        }
    }
}
