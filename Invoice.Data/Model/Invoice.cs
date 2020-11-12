using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Invoice.Data.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Invoice.Data.Model
{
    public class Invoice : BaseModel<int>
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

        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
