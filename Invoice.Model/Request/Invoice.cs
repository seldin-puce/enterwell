using System;
using System.Collections.Generic;

namespace Invoice.Model.Request
{
    public class Invoice
    {
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public double RawPrice { get; set; }
        public double PriceAfterTax { get; set; }
        public string InvoiceRecipient { get; set; }
        public ICollection<Item> InvoiceItems { get; set; }
    }
}
