using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorldMerchants.DAL;

namespace WorldMerchants.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        public ActionResult Index()
        {
            ViewBag.Heading = "Here is where you can view the world players, what items they have, what they are saying, and that type of thing.";
            return View();
        }

        public ActionResult ListPlayers()
        {
            WorldContext db = new WorldContext();

            var players = (from p in db.Players
                           select p).FirstOrDefault();

            return View(players);
        }
    }
}