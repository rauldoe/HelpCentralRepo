using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "HelpCentral Application";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact the Software Team at CPSC 362";

            return View();
        }
    }
}