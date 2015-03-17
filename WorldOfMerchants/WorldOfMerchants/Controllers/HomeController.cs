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
                //ViewBag.Message = "You are currently logged in as " + (string)Session["LOGIN"] + ". Check out the merchants and items available.";
                ViewBag.Message = "You are currently logged in as ";
                ViewBag.Message2 = (string)Session["LOGIN"];
                ViewBag.Message3 = ". Check out the merchants and items available.";
            }
            else
            {
                ViewBag.Message = "Create an account and log in so that you can get started on your journey of items hoarding.";
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