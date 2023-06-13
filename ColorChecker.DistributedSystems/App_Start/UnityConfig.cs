using ColorChecker.Domain;
using ColorChecker.Infrastructure.DataAccess;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ColorChecker.DistributedSystems
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IPixelsRepository, PixelsRepository>();
            container.RegisterType<IPixelsServices, PixelsServices>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}