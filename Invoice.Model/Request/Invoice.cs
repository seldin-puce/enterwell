using System;
using System.Collections.Generic;

namespace Invoice.Model.Request
{
    public class Invoice
    {
        public Invoice()
        {
            DateCreated = DateTime.Now;
            InvoiceItems = new List<InvoiceItem>();
        }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public double RawPrice { get; set; }
        public double PriceAfterTax { get; set; }
        public string InvoiceRecipient { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
