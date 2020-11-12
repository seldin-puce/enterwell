using System.Data.Entity;
using Invoice.Data.IdentityModels;
using Invoice.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Invoice.Data.Context
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public Context() : base(nameof(Context))
        {

        }

        public DbSet<Model.Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }


        public static Context Create()
        {
            return new Context();
        }
    }
}