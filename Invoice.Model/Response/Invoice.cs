using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Model.Response
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public double RawPrice { get; set; }
        public double PriceAfterTax { get; set; }
        public string InvoiceRecipient { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
