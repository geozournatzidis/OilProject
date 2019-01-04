using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroupProject.DAL;
using GroupProject.Models;

namespace GroupProject.Controllers
{
    public class BottlingsController : Controller
    {
        private OilProjectDbContext db = new OilProjectDbContext();

        // GET: Bottlings
        public ActionResult Index()
        {

            return View(db.Bottlings.ToList());
        }

        // GET: Bottlings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottling bottling = db.Bottlings.Find(id);
            if (bottling == null)
            {
                return HttpNotFound();
            }
            return View(bottling);
        }

        // GET: Bottlings/Create
        public ActionResult Create()
        {

            PopulateFactoriesDropDownList();
            return View();
        }

        // POST: Bottlings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BottlingID,BottlingDate,ProductCode,BottlingLotNumber,tank,Quantity,FactoryID")] Bottling bottling)
        {
            if (ModelState.IsValid)
            {
                db.Bottlings.Add(bottling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateFactoriesDropDownList();
            return View(bottling);
        }

        private void PopulateFactoriesDropDownList(object selectedFactory = null)
        {

            var factoriesQuery = from d in db.Factories
                                 orderby d.FactoryName
                                 select d;
            ViewBag.FactoryID = new SelectList(factoriesQuery, "FactoryID", "FactoryName", selectedFactory);
        }

        // GET: Bottlings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottling bottling = db.Bottlings.Find(id);
            if (bottling == null)
            {
                return HttpNotFound();
            }
            PopulateFactoriesDropDownList(bottling.FactoryID);
            return View(bottling);
        }

        // POST: Bottlings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BottlingID,BottlingDate,ProductCode,BottlingLotNumber,tank,Quantity,FactoryID")] Bottling bottling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bottling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bottling);
        }

        // GET: Bottlings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bottling bottling = db.Bottlings.Find(id);
            if (bottling == null)
            {
                return HttpNotFound();
            }
            return View(bottling);
        }

        // POST: Bottlings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bottling bottling = db.Bottlings.Find(id);
            db.Bottlings.Remove(bottling);
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
