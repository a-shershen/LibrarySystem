[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LibrarySestem.WEB.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(LibrarySestem.WEB.App_Start.NinjectWebCommon), "Stop")]

namespace LibrarySestem.WEB.App_Start
{
    using System;
    using System.Collections.Generic;
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
            string connectionName;

#if DEBUG
            connectionName = "LocalConnection";
#else

            connectionName = "WebConnection";
#endif

            string connectionString = System.Web.Configuration.WebConfigurationManager
                .ConnectionStrings[connectionName].ToString();

            Ninject.Modules.INinjectModule[] modules = new Ninject.Modules.INinjectModule[]
            {
                new BLL.NInjectModules.NInjModule(connectionString)
            };


            var kernel = new StandardKernel(modules);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new CustomResolver(kernel));
        }
    }

    class CustomResolver : System.Web.Mvc.IDependencyResolver
    {
        private Ninject.IKernel kernel;

        public CustomResolver(Ninject.IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel
                .Bind<BLL.Interfaces.IAccountService>()
                .To<BLL.Services.AccountService>();

            kernel
                .Bind<BLL.Interfaces.IBookService>()
                .To<BLL.Services.BookService>();

            kernel
                .Bind<BLL.Interfaces.ILibraryService>()
                .To<BLL.Services.LibraryService>();

            kernel
                .Bind<BLL.Interfaces.IReaderService>()
                .To<BLL.Services.ReaderService>();

            kernel
                .Bind<BLL.Interfaces.ISearchService>()
                .To<BLL.Services.SearchService>();
        }
    }
}
