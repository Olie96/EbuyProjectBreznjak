using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ebuy.DAL;
using Ebuy.Model;
using Ebuy.Model.Common;
using Ebuy.Repository.Config;
using Ebuy.Service.Common;
using EbuyProject.ViewModels;

namespace EbuyProject.Controllers
{
    public class CarController : Controller 
    {
        public CarController(ICarService service)
        {
            this.Service = service;
        }
        private readonly ICarService Service;

        public async Task<ActionResult> Index(string search, string sortBy, int page = 1)
        {
            ViewBag.sortNameParameter = string.IsNullOrEmpty(sortBy) ? SortingOperations.Descending : SortingOperations.Ascending;
            return View(AutoMapper.Mapper.Map<IList<CarViewModel>>(await Service.GetAllAsync(search, page, sortBy)));
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(Include = "CarId,CarModel,CarMaker,CarYearOfProduction,CarKilometers,CarPrice,CarDescription")] CarViewModel viewModel)
        {       
            if (ModelState.IsValid)
            {
                await Service.AddAsync(AutoMapper.Mapper.Map<ICars>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(AutoMapper.Mapper.Map<CarViewModel>(await Service.GetAsync(id)));
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
            return View(AutoMapper.Mapper.Map<CarViewModel>(await Service.GetAsync(id)));
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (await Service.GetAsync(id) == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<CarViewModel>(await Service.GetAsync(id)));
        }

        [HttpPost, ActionName("Edit")]
        public async Task<ActionResult> Edit([Bind(Include = "Model,CarMaker,CarKilometers,CarDescription,CarPrice,CarYearOfProduction")] CarViewModel car)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<ICars>(car));
                return RedirectToAction("Index");
            }
            return View(car);
        }

    }
}
