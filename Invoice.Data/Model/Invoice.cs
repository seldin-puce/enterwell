using System;
using System.Collections.Generic;

namespace Invoice.Data.Model
{
    public class Invoice : BaseModel<int>
    {
        public string Number { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DueDate { get; set; }
        public double RawPrice { get; set; }
        public double PriceAfterTax { get; set; }
        public string InvoiceRecipient { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
