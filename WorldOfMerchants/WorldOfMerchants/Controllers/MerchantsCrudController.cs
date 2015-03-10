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
    public class MerchantsCrudController : Controller
    {
        private IUnitOfWork unit;

        public MerchantsCrudController()
        {
            unit = new UnitOfWork();
        }

        public MerchantsCrudController(FakeUnitOfWork f)
        {
            unit = f;
        }

        // GET: MerchantsCrud
        public ActionResult Index()
        {
            var merchants = unit.MerchantRepo.Get();
            var mList = new List<Merchant>();

            foreach (Merchant m in merchants)
            {
                mList.Add(m);
            }
            return View(mList);
        }

        // GET: MerchantsCrud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Merchant merchant = unit.MerchantRepo.GetByID((int)id);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }

        // GET: MerchantsCrud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MerchantsCrud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Location,Type")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                //db.Merchants.Add(merchant);
                //db.SaveChanges();
                unit.MerchantRepo.Insert(merchant);
                unit.Save();
                return RedirectToAction("Index");
            }

            return View(merchant);
        }

        // GET: MerchantsCrud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Merchant merchant = db.Merchants.Find(id);
            Merchant merchant = unit.MerchantRepo.GetByID((int)id);

            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }

        // POST: MerchantsCrud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Location,Type")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(merchant).State = EntityState.Modified;
                //db.SaveChanges();
                unit.MerchantRepo.Update(merchant);
                unit.Save();
                return RedirectToAction("Index");
            }
            return View(merchant);
        }

        // GET: MerchantsCrud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Merchant merchant = db.Merchants.Find(id);
            Merchant merchant = unit.MerchantRepo.GetByID((int)id);
            if (merchant == null)
            {
                return HttpNotFound();
            }
            return View(merchant);
        }

        // POST: MerchantsCrud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Merchant merchant = db.Merchants.Find(id);
            //db.Merchants.Remove(merchant);
            //db.SaveChanges();
            Merchant merchant = unit.MerchantRepo.GetByID(id);
            unit.MerchantRepo.Delete(merchant);
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
            //Merchant merchant = db.Merchants.Find(id);
            Merchant merchant = unit.MerchantRepo.GetByID((int)id);
            if (merchant == null)
            {
                return HttpNotFound();
            }

            int itemCount = merchant.Items.Count;

            ViewBag.ItemCount = itemCount;
            return View(merchant);
        }
    }
}
