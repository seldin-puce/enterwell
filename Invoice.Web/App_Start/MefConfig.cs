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
        }

        private static CompositionContainer ConfigureContainer()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var businessRulesCatalog = new AssemblyCatalog(typeof(Plugins.Tax.ITaxMetaData).Assembly);
            var catalogs = new AggregateCatalog(assemblyCatalog, businessRulesCatalog);
            var container = new CompositionContainer(catalogs);
            return container;
        }
    }
}