using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldOfMerchants.DAL;
using WorldOfMerchants.Models;

namespace WorldOfMerchants.Controllers
{
    public class ItemBuyController : Controller
    {
        private WorldContext db = new WorldContext();

        // GET: ItemBuy
        public ActionResult Index()
        {
            var items = (from i in db.Items
                         where i.MerchantID != null
                         select i).ToList();
            
            return View(items);
        }

        //********************

        // GET: ItemBuy/BuyItem/5
        public ActionResult BuyItem(int? id)
        {
            if (Session["LOGIN"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Item item = db.Items.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item); 
            }
            else
            {
                return Redirect("NotLoggedIn");
            }
        }

        // POST: BuyItem/BuyItem/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuyItem([Bind(Include = "ID,MerchantID,PlayerID,PictureID,Name,Rarity,Type,Value,Points")] Item item)
        {
            if (Session["LOGIN"] != null)
            {
                string login = (string)Session["LOGIN"];

                var thisItem = (from i in db.Items
                                where i.ID == item.ID
                                select i).FirstOrDefault();

                var player = (from p in db.Players
                              where p.Email == login
                              select p).FirstOrDefault();

                thisItem.MerchantID = null;
                thisItem.PlayerID = player.ID;
                player.Credits -= thisItem.Value;
                player.Score += thisItem.Points;

                if (ModelState.IsValid)
                {
                    db.Entry(thisItem);
                    db.Entry(player);
                    db.SaveChanges();
                    return RedirectToAction("MyItems");
                }
                return View(item); 
            }
            else
            {
                return Redirect("NotLoggedIn");
            }
        }

        // GET: ItemBuy/SellItem/5
        public ActionResult SellItem(int? id)
        {
            var merchants = new List<string>();
            var merchs = db.Merchants;

            foreach (Merchant m in merchs)
            {
                merchants.Add(m.Name);
            }

            ViewBag.MerchantList = new SelectList(merchants);

            if (Session["LOGIN"] != null)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Item item = db.Items.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item);
            }
            else
            {
                return Redirect("NotLoggedIn");
            }
        }

        // POST: BuyItem/SellItem/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SellItem([Bind(Include = "ID,MerchantID,PlayerID,PictureID,Name,Rarity,Type,Value,Points")] Item item, string aMerchant)
        {
                string login = (string)Session["LOGIN"];

                var thisItem = (from i in db.Items
                                where i.ID == item.ID
                                select i).FirstOrDefault();

                var player = (from p in db.Players
                              where p.Email == login
                              select p).FirstOrDefault();

                var merchant = (from m in db.Merchants
                                where m.Name == aMerchant
                                select m).FirstOrDefault();

                thisItem.MerchantID = merchant.ID;
                thisItem.PlayerID = null;
                player.Credits += thisItem.Value;
                player.Score -= thisItem.Points;

                if (ModelState.IsValid)
                {
                    db.Entry(thisItem);
                    db.Entry(player);
                    db.SaveChanges();
                    return RedirectToAction("MyItems");
                }
                return View(item);
        }

        public ActionResult MyItems()
        {
            if (Session["LOGIN"] != null)
            {
                string login = (string)Session["LOGIN"];

                var player = (from p in db.Players
                                  where p.Email == login
                                  select p).FirstOrDefault();

                var items = (from i in db.Items
                             where i.PlayerID == player.ID
                             select i).ToList();

                int credits = player.Credits;
                int score = player.Score;
                ViewBag.Credits = credits;
                ViewBag.Score = score;

                return View(items);                
            }
            else
            {
                return Redirect("NotLoggedIn");
            }
        }

        public ActionResult NotLoggedIn()
        {
            ViewBag.LoginStatus = "You must be logged in to complete this action!";

            return View();
        }


        //********************

        //// GET: ItemBuy/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Item item = db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(item);
        //}

        //// GET: ItemBuy/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ItemBuy/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,MerchantID,PlayerID,PictureID,Name,Rarity,Type,Value,Points")] Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Items.Add(item);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(item);
        //}

        //// GET: ItemBuy/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Item item = db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(item);
        //}

        //// POST: ItemBuy/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,MerchantID,PlayerID,PictureID,Name,Rarity,Type,Value,Points")] Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(item).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(item);
        //}

        //// GET: ItemBuy/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Item item = db.Items.Find(id);
        //    if (item == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(item);
        //}

        //// POST: ItemBuy/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Item item = db.Items.Find(id);
        //    db.Items.Remove(item);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
