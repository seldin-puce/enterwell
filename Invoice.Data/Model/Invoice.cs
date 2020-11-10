using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Data.Model
{
    public class Invoice : BaseModel<int>, IDisposable
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public DateTime? DateCreated { get; set; }
        [Required]
        public DateTime? DueDate { get; set; }
        [Required]
        public double RawPrice { get; set; }
        public double PriceAfterTax { get; set; }
        public string InvoiceRecipient { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }
        public void Dispose()
        {
            DateCreated = null;
            DueDate = null;
            InvoiceItems = null;
        }
    }
}
