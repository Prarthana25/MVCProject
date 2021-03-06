[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(OnlineStore.UI.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(OnlineStore.UI.App_Start.NinjectWebCommon), "Stop")]

namespace OnlineStore.UI.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Moq;
    using Ninject;
    using Ninject.Web.Common;
    using OnlineStore.Domain.View;
    using OnlineStore.Domain.Model;
    using OnlineStore.Domain.Concrete;

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
            kernel.Bind<IProduct>().To<EFProductRepository>();
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>();
            //Mock<IProduct> mock = new Mock<IProduct>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product {Name="FootBall",Price=230},
            //    new Product {Name="Running Shoes",Price=123},
            //    new Product {Name="Badminton",Price=100 }
            //});
            //kernel.Bind<IProduct>().ToConstant(mock.Object);
        }        
    }
}
