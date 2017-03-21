using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ebuy.Model.Common;
using Ebuy.Repository.Config;
using Ebuy.Service.Common;
using EbuyProject.ViewModels;

namespace EbuyProject.Controllers
{
    public class SportController : Controller
    {
        public SportController(ISportService service)
        {
            this.Service = service;
        }
        private readonly ISportService Service;
        // GET: Sport
        public async Task<ActionResult> Index(string search, string sortBy, int page = 1)
        {
            ViewBag.sortNameParameter = string.IsNullOrEmpty(sortBy) ? SortingOperations.Descending : SortingOperations.Ascending;
            return View(AutoMapper.Mapper.Map<IList<SportViewModel>>(await Service.GetAllAsync(search, page, sortBy)));
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Include = "SportItemName,SportItemDescription,SportItemPrice")] SportViewModel sport)
        {
            if (ModelState.IsValid)
            {
                await Service.AddAsync(AutoMapper.Mapper.Map<ISport>(sport));
                return RedirectToAction("Index");
            }
            return View(sport);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (await Service.GetAsync(id) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(AutoMapper.Mapper.Map<SportViewModel>(await Service.GetAsync(id)));
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await Service.RemoveAsync(await Service.GetAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            if (await Service.GetAsync(id) == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<SportViewModel>(await Service.GetAsync(id)));
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (await Service.GetAsync(id) == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<SportViewModel>(await Service.GetAsync(id)));
        }

        [HttpPost, ActionName("Edit")]
        public async Task<ActionResult> Edit([Bind(Include = "SportPartId,SportItemName,SportItemPrice,SportItemDescription")] SportViewModel sport)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<ISport>(sport));
                return RedirectToAction("Index");
            }
            return View(sport);
        }
    }
}