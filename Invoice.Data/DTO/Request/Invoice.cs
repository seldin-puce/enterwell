using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Data.DTO.Request
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceItems = new List<InvoiceItem>();
        }

        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public DateTime? DateCreated { get; set; }
        [Required]
        public DateTime? DueDate { get; set; }
        public double RawPrice { get; set; }
        public double PriceAfterTax { get; set; }
        public string InvoiceRecipient { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
    }
}
