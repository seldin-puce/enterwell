﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Data.Model
{
    public class InvoiceItem : BaseModel<int>
    {
        [Required]
        public string Description { get; set; }
        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public double TotalUnitRawPrice { get; set; }
    }
}
