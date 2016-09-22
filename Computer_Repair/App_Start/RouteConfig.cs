using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Computer_Repair
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Accessories",
                url: "{Accessories}",
                defaults: new { controller = "Accessories", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Customers",
                url: "{Customers}",
                defaults: new { controller = "Customers", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "KindsOfAccessories",
                url: "{KindsOfAccessories}",
                defaults: new { controller = "KindsOfAccessories", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Workers",
                url: "{Workers}",
                defaults: new { controller = "Workers", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Orders",
                url: "{Orders}",
                defaults: new { controller = "Orders", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
