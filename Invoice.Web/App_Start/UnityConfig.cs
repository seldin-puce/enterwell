using System.Web.Mvc;
using AutoMapper;
using Invoice.Service.AutoMapperConfiguration;
using Invoice.Service.IService;
using Invoice.Service.Service;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Invoice.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IInvoiceService, InvoiceService>();
            container.RegisterType<IInvoiceAutoMapper, InvoiceAutoMapper>(new SingletonLifetimeManager());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    } 
}