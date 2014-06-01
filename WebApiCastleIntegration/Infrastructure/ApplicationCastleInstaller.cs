using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Http;
using WebApiCastleIntegration.Controllers;
using WebApiCastleIntegration.Dependencies;

namespace WebApiCastleIntegration.Infrastructure
{
    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            // Register working dependencies
            container.Register(Component.For<IMessageSource>().ImplementedBy<HelloWorldMessageSource>().LifestyleScoped());

            // Register all the WebApi controllers within this assembly
            container.Register(Classes.FromAssembly(typeof(ValuesController).Assembly)
                                      .BasedOn<ApiController>()
                                      .LifestyleScoped());
        }
    }
}