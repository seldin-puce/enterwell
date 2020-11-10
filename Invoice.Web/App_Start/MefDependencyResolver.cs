using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Invoice.Web.App_Start
{
    public class MefDependencyResolver : System.Web.Mvc.IDependencyResolver, IDisposable
    {
        private readonly CompositionContainer _container;

        public MefDependencyResolver(CompositionContainer container)
        {
            _container = container;

        }
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            var name = AttributedModelServices.GetContractName(serviceType);
            var export = _container.GetExportedValueOrDefault<object>(name);
            return export;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            var exports = _container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
            return exports;
        }

        public void Dispose()
        {
            _container.Dispose();
        }
    }
}