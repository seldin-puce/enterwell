using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Invoice.Service.AutoMapperConfiguration;
using Invoice.Service.IService;

namespace Invoice.Web.Controllers
{
    public class InvoiceController : BaseController<Model.Request.Invoice, Model.Response.Invoice, int>
    {
        private IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService, InvoiceAutoMapper invoiceAutoMapper) : base(invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public override async Task<ActionResult> Update(int id)
        {
            Model.Request.Invoice entityFromDb = null;
            try
            {
                entityFromDb = await _invoiceService.GetRequestTypeById(id);
                TempData["Success"] = "Record successfully updated";
            }
            catch
            {
                TempData["Error"] = "Error has happened.";
            }

            return View(nameof(Update), entityFromDb);
        }
    }
}