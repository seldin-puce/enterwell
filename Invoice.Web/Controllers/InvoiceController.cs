using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Invoice.Plugins.Tax;
using Invoice.Service.IService;
using Invoice.Web.ViewModel;
using Microsoft.AspNet.Identity;

namespace Invoice.Web.Controllers
{
    [Authorize]
    public class InvoiceController : BaseController<Data.DTO.Request.Invoice, Data.DTO.Response.Invoice, int>
    {
        private readonly IInvoiceService _invoiceService;

        [ImportMany]
        public IEnumerable<Lazy<ITax, ITaxMetaData>> Taxes { get; private set; }
        public InvoiceController(IInvoiceService invoiceService) : base(invoiceService)
        {
            _invoiceService = invoiceService;
        }


        public override async Task<ActionResult> Index()
        {
            var entities = await _invoiceService.GetAllByUserId(User.Identity.GetUserId());
            return View(entities);
        }

        [HttpGet]
        public override async Task<ActionResult> Update(int? id)
        {
            try
            {
                var invoice = await _invoiceService.GetRequestTypeById(id.Value);
                var model = new UpdateViewModel
                {
                    Id = invoice.Id,
                    DateCreated = invoice.DateCreated,
                    DueDate = invoice.DueDate,
                    InvoiceRecipient = invoice.InvoiceRecipient,
                    Number = invoice.Number,
                    PriceAfterTax = invoice.PriceAfterTax,
                    RawPrice = invoice.RawPrice,
                    InvoiceItems = invoice.InvoiceItems,
                    Taxes = Taxes.Select(x => new SelectListItem
                    {
                        Value = x.Metadata.TaxValue,
                        Text = x.Metadata.TaxValue
                    }).ToList()
                };

                TempData["Success"] = "Record successfully updated";
                return View(model);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Error has happened.";
                return RedirectToAction(nameof(Index));
            }
        }

        public override async Task<ActionResult> Update(Data.DTO.Request.Invoice model, int id)
        {
            try
            {
                model.ApplicationUserId = User.Identity.GetUserId();
                var taxService = Taxes.FirstOrDefault(x => x.Metadata.TaxValue == model.SelectedTax);
                await _invoiceService.UpdateWithTax(id, model, taxService.Value);
                TempData["Success"] = "Record updated successfully";
            }
            catch (Exception e)
            {
                TempData["Error"] = "Error has happened";
            }

            return RedirectToAction("Index");
        }

        public override ActionResult Create()
        {
            var model = new CreateViewModel
            {
                Taxes = Taxes.Select(x => new SelectListItem
                {
                    Value = x.Metadata.TaxValue,
                    Text = x.Metadata.TaxValue
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public override async Task<ActionResult> Create(Data.DTO.Request.Invoice model)
        {
            if (!ModelState.IsValid)
            {
                var createViewModel = new CreateViewModel()
                {
                    Taxes = Taxes.Select(x => new SelectListItem
                    {
                        Value = x.Metadata.TaxValue,
                        Text = x.Metadata.TaxValue
                    }).ToList(),
                    DateCreated = model.DateCreated,
                    DueDate = model.DueDate,
                    Number = model.Number,
                    InvoiceRecipient = model.InvoiceRecipient,
                    SelectedTax = model.SelectedTax,
                    InvoiceItems = model.InvoiceItems
                };
                return View(createViewModel);
            }
            try
            {
                model.ApplicationUserId = (User.Identity.GetUserId());
                var taxService = Taxes.FirstOrDefault(x => x.Metadata.TaxValue == model.SelectedTax);
                await _invoiceService.CreateWithTax(model, taxService.Value);
                TempData["Success"] = "Record created successfully.";
            }
            catch (Exception e)
            {
                TempData["Error"] = "Error has happened.";

            }
            return RedirectToAction(nameof(Index));
        }
    }
}