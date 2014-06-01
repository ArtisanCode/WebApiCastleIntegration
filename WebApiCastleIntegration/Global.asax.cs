using Castle.Windsor;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApiCastleIntegration.Infrastructure;

namespace WebApiCastleIntegration
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize Castle & install application components
            var container = new WindsorContainer();
            container.Install(new ApplicationCastleInstaller());

            // Configure WebApi to use a new CastleDependencyResolver as its dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new CastleDependencyResolver(container);

            // Configure WebApi to use the newly configured GlobalConfiguration complete with Castle dependency resolver
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}