using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCApp.Controllers
{
    public class schedulersController : Controller
    {
        private helpcentraldbEntities db = new helpcentraldbEntities();

        [HttpPost]
        public ActionResult Login(scheduler s)
        {
            string actionAfterLogin = "LoginBad";
            ViewResult vr = View(actionAfterLogin);

            if (ModelState.IsValid)
            {
                var schedulerList = db.schedulers.ToList();

                var userToLogin = db.schedulers.Where(i => (i.email == s.email) && (i.password == s.password)).FirstOrDefault();

                if (userToLogin != null)
                {
                    actionAfterLogin = "LoginGood";
                    vr = View(actionAfterLogin);
                }
            }

            return vr;
        }
        // GET: schedulers
        public ActionResult Index()
        {
            return View();
        }
    }
}