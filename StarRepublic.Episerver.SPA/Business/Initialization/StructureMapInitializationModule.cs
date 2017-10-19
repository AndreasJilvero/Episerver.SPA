using System.Web.Mvc;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using StarRepublic.Episerver.SPA.Business.IoC;

namespace StarRepublic.Episerver.SPA.Business.Initialization
{
    [ModuleDependency(typeof(FrameworkInitialization))]
    public class StructureMapInitializationModule : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(context.StructureMap()));
        }
    }
}