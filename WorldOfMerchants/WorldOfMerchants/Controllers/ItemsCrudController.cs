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

namespace WorldMerchants.Controllers
{
    public class ItemsCrudController : Controller
    {
        private IUnitOfWork unit;

        public ItemsCrudController()
        {
            unit = new UnitOfWork();
        }

        public ItemsCrudController(FakeUnitOfWork f)
        {
            unit = f;
        }

        // GET: ItemsCrud
        public ActionResult Index()
        {
            var items = (from i in unit.ItemRepo.Get()
                         where i.MerchantID != null
                         select i).ToList();

            return View(items);
        }

        // GET: ItemsCrud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = unit.ItemRepo.GetByID(id);
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
            var types = new List<string> { "Gemstone", "Wooden", "Metal", "Mineral", "Combination", "Other" };

            var merchants = new List<string>();

            var merchs = unit.MerchantRepo.Get();
            foreach (Merchant m in merchs)
            {
                merchants.Add(m.Name);
            }

            ViewBag.RarityList = new SelectList(rarities);
            ViewBag.TypeList = new SelectList(types);
            ViewBag.MerchantList = new SelectList(merchants);

            return View();
        }

        // POST: ItemsCrud/Create***************
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Value,Points")] ItemCreateViewModel itemCvm, string rareness, string aMerchant, string type)
        {
            if (ModelState.IsValid)
            {
                Item item = new Item
                {
                    Name = itemCvm.Name,
                    Rarity = rareness,
                    Type = type,
                    Value = itemCvm.Value,
                    Points = itemCvm.Points,
                };
                var merchant = (from m in unit.MerchantRepo.Get()
                                where m.Name == aMerchant
                                select m).FirstOrDefault<Merchant>();
                item.MerchantID = merchant.ID;

                unit.ItemRepo.Insert(item);
                unit.Save();
                return RedirectToAction("Index");
            }

            return View(itemCvm);
        }

        // GET: ItemsCrud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = unit.ItemRepo.GetByID(id);
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
            Item item = unit.ItemRepo.GetByID(id);
            unit.ItemRepo.Delete(item);
            unit.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: MerchantsCrud/ItemsByMerchant/5
        public ActionResult ItemsByMerchant(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Merchant merchant = unit.MerchantRepo.GetByID(id);
            if (merchant == null)
            {
                return HttpNotFound();
            }

            int itemCount = merchant.Items.Count;

            ViewBag.ItemCount = itemCount;
            return View(merchant);
        }

        //// GET: ItemsCrud/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Item item = unit.ItemRepo.GetByID(id);
        //    if (item == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(item);
        //}

        //// POST: ItemsCrud/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,MerchantID,PlayerID,PictureID,Name,Rarity,Type,Value,Points,Magic")] Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        unit.ItemRepo.Update(item);
        //        unit.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(item);
        //}
    }
}
