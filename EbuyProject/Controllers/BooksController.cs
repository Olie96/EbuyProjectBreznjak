using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ebuy.Model.Common;
using Ebuy.Service.Common;
using EbuyProject.ViewModels;
using System.Web.Routing;
using Ebuy.Repository.Config;

namespace EbuyProject.Controllers
{
    public class BooksController : Controller
    {
        public BooksController(IBookService service)
        {
            this.Service = service;
        }
        private readonly IBookService Service;
        // GET: Books
        public async Task<ActionResult> Index(string search, string sortBy, int page = 1)
        {
            ViewBag.sortNameParameter = string.IsNullOrEmpty(sortBy) ? SortingOperations.Descending : SortingOperations.Ascending;
            return View(AutoMapper.Mapper.Map<List<BookViewModel>>(await Service.GetAllAsync(search, page, sortBy)));
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost,ActionName("Add")]
        public async Task<ActionResult> Add([Bind(Include = ("BookName,BookAuthorName,BookAuthorSurname,BookISBN,BookGenre,BookDescription,BookPrice"))] BookViewModel book)
        {
            if (ModelState.IsValid)
            {
               await Service.AddAsync(AutoMapper.Mapper.Map<IBooks>(book));
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (await Service.GetAsync(id) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(AutoMapper.Mapper.Map<BookViewModel>(await Service.GetAsync(id)));
        }
        [HttpPost,ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
           await Service.RemoveAsync(await Service.GetAsync(id));
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            if (await Service.GetAsync(id) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(AutoMapper.Mapper.Map<BookViewModel>(await Service.GetAsync(id)));
        }
        [HttpPost, ActionName("Edit")]
        public async Task<ActionResult> Edit([Bind(Include = "BookId,BookName,BookAuthorName,BookAuthorSurname,BookISBN,BookGenre,BookDescription,BookPrice")] BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<IBooks>(book));
                return RedirectToAction("Index");
            }
            return View(book);
        }
        public async Task<ActionResult> Details(int id)
        {
            if (await Service.GetAsync(id) == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(AutoMapper.Mapper.Map<BookViewModel>(await Service.GetAsync(id)));
        }

    }
}