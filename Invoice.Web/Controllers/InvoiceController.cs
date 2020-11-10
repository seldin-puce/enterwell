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
    public class InvoiceController : BaseController<Data.DTO.Request.Invoice, Data.DTO.Response.Invoice, int>
    {
        private IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService, InvoiceAutoMapper invoiceAutoMapper) : base(invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public override async Task<ActionResult> Update(int id)
        {
            Data.DTO.Request.Invoice reqEntity = null;
            try
            {
                reqEntity = await _invoiceService.GetRequestTypeById(id);
                TempData["Success"] = "Record successfully updated";
            }
            catch
            {
                TempData["Error"] = "Error has happened.";
            }

            return View(nameof(Update), reqEntity);
        }
    }
}