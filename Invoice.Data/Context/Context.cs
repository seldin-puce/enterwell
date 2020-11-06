using System.Data.Entity;
using Invoice.Data.Model;

namespace Invoice.Data.Context
{
    public class Context : DbContext
    {
        public Context() : base(nameof(Context))
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Model.Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
    }
}