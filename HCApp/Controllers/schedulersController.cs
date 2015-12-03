using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HCApp;
using HCApp.Models;

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
                var customerList = db.customers.ToList();
                var genieList = db.genies.ToList();

                var userToLogin = db.schedulers.Where(i => (i.email == s.email) && (i.password == s.password)).FirstOrDefault();

                if (userToLogin != null)
                {
                    List<CustomerViewModel> temp1 = new List<CustomerViewModel>();
                    List<GenieViewModel> temp2 = new List<GenieViewModel>();
                    foreach (var item in customerList)
                    {
                        var orderarray = db.orders.Where(i => i.customerid == item.customerid).ToList();
                        temp1.Add(new CustomerViewModel() { Customer = item, OrderList = orderarray });
                    }
                    foreach (var item1 in genieList)
                    {
                        var array = db.workrequests.Where(i => i.genieid == item1.genieid).ToList();
                        temp2.Add(new GenieViewModel() { Genie = item1, WorkRequestList = array});
                    }
                    actionAfterLogin = "LoginGood";
                    var finalview = new SchedulerViewModel() { CustomerViewModelList = temp1, GenieViewModelList = temp2};
                    vr = View(actionAfterLogin,finalview);
                }
            }

            return vr;
        }
        // GET: schedulers
        public ActionResult Index()
        {
            return View();
        }
        // GET: customers/Details/5
        public ActionResult Details1(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer customer = db.customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Details2(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order or = db.orders.Find(id);
            if (or == null)
            {
                return HttpNotFound();
            }
            return View(or);
        }
        public ActionResult GenieDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           genie gen = db.genies.Find(id);
            if (gen == null)
            {
                return HttpNotFound();
            }
            return View(gen);
        }

    }
}