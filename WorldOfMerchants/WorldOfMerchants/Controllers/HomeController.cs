using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorldOfMerchants.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["LOGIN"] != null)
            {
                ViewBag.LoginName = (string)Session["LOGIN"];
            }

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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string loginName)
        {
            Session["LOGIN"] = loginName;

            return RedirectToAction("Index");
        }
    }
}