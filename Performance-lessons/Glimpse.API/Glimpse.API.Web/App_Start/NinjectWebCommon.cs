using System.Data.Entity;
using System.Web.Http;
using Glimpse.API.Web.Data;
using Glimpse.API.Web.Models;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Glimpse.API.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(Glimpse.API.Web.App_Start.NinjectWebCommon), "Stop")]

namespace Glimpse.API.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);

            //This article saved my butt!
            //Had to create a new ninject resolver and ninject scope objects...
            //http://www.strathweb.com/2012/05/using-ninject-with-the-latest-asp-net-web-api-source/
            GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IRepository<Person>>().To<EntityFrameworkRepository<Person>>().InRequestScope();
            kernel.Bind<IRepository<Gadget>>().To<EntityFrameworkRepository<Gadget>>().InRequestScope();
            kernel.Bind<DbContext>().To<ExampleContext>().InRequestScope();
        }        
    }
}
