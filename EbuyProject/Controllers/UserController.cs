using Ebuy.Model.Common;
using Ebuy.Service.Common;
using EbuyProject.Config;
using EbuyProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EbuyProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly ICartService _cartService;
        public UserController(IUserService service, ICartService cartService)
        {
            this._cartService = cartService;
            this._service = service;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> LogIn(string email, string password)
        {
            if (email == KeyWords.AdminKeyWord && password == KeyWords.AdminKeyWord)
            {
               return RedirectToAction("index", "Admin");
            }
            else
            {
                var exist = await _service.GetUser(email, password);
                if (exist != null)
                {
                    Session["userSession"] = AutoMapper.Mapper.Map<UserViewModel>(await _service.GetUser(email, password));
                    return RedirectToAction("Index", "Cart");
                }
            }
            return RedirectToAction("index");
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAccount([Bind(Include = "FirstName,LastName,Adress,Email,Password")] UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.AddNewUserAsync(AutoMapper.Mapper.Map<IUser>(viewModel));
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public async Task<ActionResult> RegisteredUsers()
        {
            return View(AutoMapper.Mapper.Map<List<UserViewModel>>(await _service.GetUsersAsync()));
        }
    }
}