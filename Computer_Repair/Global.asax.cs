using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Computer_Repair.Models;
using System.Data.Entity;

namespace Computer_Repair
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            /*Database.SetInitializer<Computer_RepairContext>(new DropCreateDatabaseAlways<Computer_RepairContext>());
            Computer_RepairContext A = new Computer_RepairContext();
            A.Database.Initialize(true);*/
            //Database.SetInitializer<ApplicationDbContext>(new AppDbInitializer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
