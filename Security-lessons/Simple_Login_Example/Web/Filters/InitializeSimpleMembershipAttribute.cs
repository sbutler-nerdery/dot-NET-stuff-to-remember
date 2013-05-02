using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using Data;
using WebMatrix.WebData;

namespace Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                /*NOTE: this is here when you create a new project in VS, but we don't need it because
                we are initializing the database in app_start in global.ashx*/

                //Database.SetInitializer<ExampleContext>(null);

                try
                {
                    /*NOTE: this is here when you create a new project in VS, but we don't need it because
                                    we are initializing the database in app_start in global.ashx*/

                    //using (var context = new ExampleContext())
                    //{
                    //    if (!context.Database.Exists())
                    //    {
                    //        // Create the SimpleMembership database without Entity Framework migration schema
                    //        ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                    //    }
                    //}

                    //Tell WebSecurity what connection string and user table data to use...
                    WebSecurity.InitializeDatabaseConnection(SimpleLoginExampleContext.ConnectionString, 
                        SimpleLoginExampleContext.UserTableName, 
                        SimpleLoginExampleContext.UserIdProperty, 
                        SimpleLoginExampleContext.UserNameProperty, autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
