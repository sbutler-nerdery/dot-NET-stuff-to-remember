using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Miniprofiler.CodeFirst.Data;
using StackExchange.Profiling;
using StackExchange.Profiling.SqlFormatters;

namespace Miniprofiler.CodeFirst
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //TODO: The first time you run this project, run in release mode
#if DEBUG
            MiniProfilerEF.Initialize();
            MiniProfiler.Settings.SqlFormatter = new SqlServerFormatter();
#endif
            Database.SetInitializer(new ExampleContextInitializer());

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}