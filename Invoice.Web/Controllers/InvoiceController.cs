using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invoice.Service.IService;

namespace Invoice.Web.Controllers
{
    public class InvoiceController : BaseController<Model.Request.Invoice, Model.Response.Invoice, int>
    {
        public InvoiceController(IInvoiceService baseService) : base(baseService)
        {
        }

    }
}