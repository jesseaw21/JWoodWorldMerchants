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
    public class PlayersCrudController : Controller
    {
        //private WorldContext db = new WorldContext();
        private IPlayerRepository pr;

        public PlayersCrudController()
        {
            this.pr = new PlayerRepository(new WorldContext());
        }

        // GET: PlayersCrud
        public ActionResult Index()
        {
            return View(pr.GetPlayers().ToList());
        }

        // GET: PlayersCrud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = pr.GetPlayerByID((int)id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: PlayersCrud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayersCrud/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,DateStarted,Credits,Score")] Player player)
        {
            player.DateStarted = DateTime.Now;
            player.Credits = 100;
            player.Score = 0;

            if (ModelState.IsValid)
            {
                pr.InsertPlayer(player);
                pr.Save();
                return RedirectToAction("Index");
            }

            return View(player);
        }        

        // GET: PlayersCrud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = pr.GetPlayerByID((int)id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: PlayersCrud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = pr.GetPlayerByID(id);
            pr.DeletePlayer(id);
            pr.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pr.Dispose();
            }
            base.Dispose(disposing);
        }

        //// GET: PlayersCrud/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Player player = pr.GetPlayerByID((int)id);
        //    if (player == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(player);
        //}

        //// POST: PlayersCrud/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,Name,DateStarted,Score")] Player player)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        pr.UpdatePlayer(player);
        //        pr.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View(player);
        //}
    }
}
