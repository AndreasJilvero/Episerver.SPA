using System.Web.Http;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StarRepublic.Episerver.SPA.Business.IoC;

namespace StarRepublic.Episerver.SPA.Business.Initialization
{
    [ModuleDependency(typeof(FrameworkInitialization))]
    public class WebApiInitializationModule : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            GlobalConfiguration.Configure(x =>
            {
                x.MapHttpAttributeRoutes();

                x.DependencyResolver = new StructureMapDependencyResolver(context.StructureMap());

                var xmlFormatter = x.Formatters.XmlFormatter;
                x.Formatters.Remove(xmlFormatter);

                var serializerSettings = x.Formatters.JsonFormatter.SerializerSettings;
                serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                serializerSettings.ContractResolver = new Json.ContractResolver();
            });
        }
    }
}