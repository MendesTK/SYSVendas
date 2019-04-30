using SYSVendas.Application;
using SYSVendas.Application.Interface;
using SYSVendas.Domain.Interfaces.Repositories;
using SYSVendas.Domain.Interfaces.Services;
using SYSVendas.Domain.Services;
using SYSVendas.Infra.Data.Repositories;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SYSVendas.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SYSVendas.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace SYSVendas.MVC.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IVendaAppService>().To<VendaAppService>();
            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<IDetalheVendaAppService>().To<DetalheVendaAppService>();
            kernel.Bind<IClienteAppService>().To<ClienteAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IVendaService>().To<VendaService>();
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<IDetalheVendaService>().To<DetalheVendaService>();
            kernel.Bind<IClienteService>().To<ClienteService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IVendaRepository>().To<VendaRepository>();
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<IDetalheVendaRepository>().To<DetalheVendaRepository>();
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
        }
    }
}