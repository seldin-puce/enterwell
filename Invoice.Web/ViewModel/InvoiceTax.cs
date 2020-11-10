using System.Collections.Generic;
using System.Web.Mvc;

namespace Invoice.Web.ViewModel
{
    public class InvoiceTax
    {
        public List<SelectListItem> Taxes { get; set; }
        public Data.DTO.Request.Invoice Invoice { get; set; }
        public decimal Value { get; set; }
        public string Message { get; set; }
        public string SelectedTaxValue { get; set; }
    }
}