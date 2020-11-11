using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Invoice.Web.ViewModel
{
    public class UpdateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd.MM.yyyy")]
        public DateTime? DueDate { get; set; }

        public double RawPrice { get; set; }

        public double PriceAfterTax { get; set; }

        public string InvoiceRecipient { get; set; }

        public List<Data.DTO.Request.InvoiceItem> InvoiceItems { get; set; }

        public List<SelectListItem> Taxes { get; set; }
        public string SelectedTax { get; set; }
    }
}