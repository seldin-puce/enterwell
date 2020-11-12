using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Invoice.Data.DTO.Request;

namespace Invoice.Web.ViewModel
{
    public class CreateViewModel
    {
        public CreateViewModel()
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
        public string ApplicationUserId { get; set; }
        public List<InvoiceItem> InvoiceItems { get; set; }
        public List<SelectListItem> Taxes { get; set; }
        public string SelectedTax { get; set; }
    }
}