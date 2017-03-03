using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EbuyProject.Config;

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

        public ActionResult Login(string Name)
        {
            if (Name.Equals(KeyWords.AdminKeyWord))
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (Name.Equals(KeyWords.UserKeyWord))
            {
                return RedirectToAction("Index", "Cart");
            }
            return RedirectToAction("Index");
        }
    }
}