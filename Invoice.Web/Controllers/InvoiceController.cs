using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Invoice.Plugins.Tax;
using Invoice.Service.AutoMapperConfiguration;
using Invoice.Service.IService;
using Invoice.Web.ViewModel;

namespace Invoice.Web.Controllers
{
    public class InvoiceController : BaseController<Data.DTO.Request.Invoice, Data.DTO.Response.Invoice, int>
    {
        private IInvoiceService _invoiceService;
        [ImportMany]
        public IEnumerable<Lazy<ITax, ITaxMetaData>> Taxes { get; private set; }
        public InvoiceController(IInvoiceService invoiceService, InvoiceAutoMapper invoiceAutoMapper) : base(invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public override async Task<ActionResult> Update(int? id)
        {
            try
            {
                var model = new InvoiceTax()
                {
                    Invoice = await _invoiceService.GetRequestTypeById(id.Value),
                    Taxes = Taxes.Select(x => new SelectListItem()
                    {
                        Value = x.Metadata.TaxValue,
                        Text = x.Metadata.TaxValue
                    }).ToList()
                };
                TempData["Success"] = "Record successfully updated";
                return View(nameof(Update), model);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Error has happened.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}