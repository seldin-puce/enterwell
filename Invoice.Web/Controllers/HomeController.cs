using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Invoice.Service.IService;

namespace Invoice.Web.Controllers
{
    public class HomeController : Controller
    {
        private IInvoiceService _invoiceService;

        public HomeController(IInvoiceService invoiceService)
        {
            this._invoiceService = invoiceService;
        }
        public async Task<ActionResult> Index()
        {
            var a = await  _invoiceService.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}