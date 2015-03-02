using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldOfMerchants.DAL;
using WorldOfMerchants.Models;

namespace WorldMerchants.Controllers
{
    public class MerchantViewController : Controller
    {
        private WorldContext db = new WorldContext();

        // GET: MerchantView
        public ActionResult Index()
        {
            WorldContext db = new WorldContext();

            var merchants = db.Merchants.Include("Items"); // Grab Merchants from database

            List<MerchantView> merchList = new List<MerchantView>(); // New list of MerchantView models

            foreach (Merchant m in merchants) // Transfer properties from Merchant to MerchantView and add to collection
            {
                merchList.Add(new MerchantView()
                {
                    Name = m.Name,
                    Location = m.Location,
                    Type = m.Type,
                    ItemCount = new ItemCount { itemCount = m.Items.Count }
                });
            }

            return View(merchList);
        }

        public ActionResult WorldItems()
        {
            WorldContext db = new WorldContext();

            var items = db.Items;
            int numItems = 0;
            foreach (Item i in items)
                numItems++;

            ViewBag.NumItems = numItems;
            ViewBag.Header = "Items in the World";

            return View(items);
        }

        public ActionResult ItemsByMerchant(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Merchant merchant = db.Merchants.Find(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }
    }
}