using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WorldMerchants.DAL;
using WorldMerchants.Models;

namespace WorldMerchants.Controllers
{
    public class ItemsCrudController : Controller
    {
        private WorldContext db = new WorldContext();

        // GET: ItemsCrud
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }

        // GET: ItemsCrud/Details/5
        public ActionResult Details(int? id)
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

        // GET: ItemsCrud/Create
        public ActionResult Create()
        {
            var rarities = new List<string> { "Common", "Uncommon", "Rare" };

            var merchants = new List<string>();
            var merchQuery = from m in db.Merchants
                             orderby m.Name
                             select m.Name;

            merchants.AddRange(merchQuery);

            ViewBag.RarityList = new SelectList(rarities);
            ViewBag.MerchantList = new SelectList(merchants);

            return View();
        }

        // POST: ItemsCrud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Type,Value,Points")] ItemCreateViewModel itemCvm, string rareness, string aMerchant)
        {
            if (ModelState.IsValid)
            {
                Item item = new Item
                {
                    Name = itemCvm.Name,
                    Rarity = rareness,
                    Type = itemCvm.Type,
                    Value = itemCvm.Value,
                    Points = itemCvm.Points,
                };
                var merchant = (from m in db.Merchants
                                where m.Name == aMerchant
                                select m).FirstOrDefault<Merchant>();
                item.MerchantID = merchant.ID;

                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemCvm);
        }

        // GET: ItemsCrud/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: ItemsCrud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MerchantID,PlayerID,PictureID,Name,Rarity,Type,Value,Points,Magic")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: ItemsCrud/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: ItemsCrud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
