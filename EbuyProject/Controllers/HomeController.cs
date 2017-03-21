using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EbuyProject.Config;
using Ebuy.Service.Common;

namespace EbuyProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        //public ActionResult Login(string name, string surname)
        //{
        //    return RedirectToAction("Index");
        //}

        //public ActionResult CreateAccount()
        //{
        //    return View();
        //}
    }
}