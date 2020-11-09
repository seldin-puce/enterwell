using System;
using System.Collections.Generic;

namespace Invoice.Model.Request
{
    public class Invoice
    {
        public Invoice()
        {
            DateCreated = null;
            DueDate = null;
            InvoiceItems = new List<InvoiceItem>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DueDate { get; set; }
        public double RawPrice { get; set; }
        public double PriceAfterTax { get; set; }
        public string InvoiceRecipient { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
