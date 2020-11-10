using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Web.Mvc;

namespace Invoice.Web.App_Start
{
    public static class MefConfig
    {
        public static void RegisterMef()
        {
            var container = ConfigureContainer();

            ControllerBuilder.Current.SetControllerFactory(new MefControllerFactory(container));

            //var dependencyResolver = System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver;
            //DependencyResolver.SetResolver(new MefDependencyResolver(container));
        }

        private static CompositionContainer ConfigureContainer()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var businessRulesCatalog = new AssemblyCatalog(typeof(Invoice.Plugins.Tax.ITaxMetaData).Assembly);
            var catalogs = new AggregateCatalog(assemblyCatalog, businessRulesCatalog);
            var container = new CompositionContainer(catalogs);
            return container;
        }
    }
}