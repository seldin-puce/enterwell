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
    public abstract class BaseController<TRequest, TResponse, TKey> : Controller where TRequest : class, new()
    {
        private readonly IBaseService<TRequest, TResponse, TKey> _baseService;

        public BaseController(IBaseService<TRequest, TResponse, TKey> baseService)
        {
            _baseService = baseService;
        }

        // GET: BaseRead
        public virtual async Task<ActionResult> Index()
        {
            var entities = await _baseService.GetAll();
            return View(entities);
        }

        [HttpGet]
        public virtual ActionResult Create()
        {
            return View(new TRequest());
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(TRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                await _baseService.Create(model);
            }
            catch (Exception e)
            {
                TempData["Error"] = "Error has happened.";

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public virtual async Task<ActionResult> Update(TKey id)
        {
            TRequest uResponse = null;
            try
            {
                uResponse = await _baseService.GetRequestTypeById(id);
            }
            catch
            {
                TempData["Error"] = "Error has happened.";
            }
            return View(uResponse);
        }

        [HttpPost]
        public virtual ActionResult Update(TRequest model, TKey id)
        {
            var response = _baseService.Update(model, id);
            return RedirectToAction(nameof(Index));
        }

        public virtual ActionResult Delete(TKey id)
        {
            try
            {
                var response = _baseService.Delete(id);
                TempData["Success"] = "Record deleted successfully";
            }
            catch
            {
                TempData["Error"] = "Error has happened.";
            }
            return RedirectToAction(nameof(Index));
        }

    }
}