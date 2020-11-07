using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Invoice.Service.IService;

namespace Invoice.Web.Controllers
{
    public abstract class BaseController<TRequest, TResponse, TKey> : Controller where TRequest : class, new()
    {
        private IBaseService<TRequest, TResponse, TKey> _baseService;
        public BaseController(IBaseService<TRequest, TResponse, TKey> baseService)
        {
            this._baseService = baseService;
        }

        // GET: BaseRead
        public async Task<ActionResult> Index()
        {
            var entities = await _baseService.GetAll();
            return View(entities);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new TRequest());
        }

        [HttpPost]
        public ActionResult Create(TRequest model)
        {
            try
            {
                var response = _baseService.Create(model);
            }
            catch
            {
                TempData["Error"] = "Error has happened.";

            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Update(TKey id)
        {
            try
            {
                var entityFromDb = _baseService.GetById(id);

            }
            catch
            {
                TempData["Error"] = "Error has happened.";
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Update(TRequest model, TKey id)
        {
            var response = _baseService.Update(id, model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View(new TRequest());
        }

        [HttpPost]
        public ActionResult Delete(TKey id)
        {
            try
            {
                var response = _baseService.Delete(id);

            }
            catch
            {
                TempData["Error"] = "Error has happened.";

            }
            return RedirectToAction(nameof(Index));
        }

    }
}