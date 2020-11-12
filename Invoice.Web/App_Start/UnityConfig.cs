using Invoice.Data.Context;
using Invoice.Service.AutoMapperConfiguration;
using Invoice.Service.IService;
using Invoice.Service.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
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
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    } 
}