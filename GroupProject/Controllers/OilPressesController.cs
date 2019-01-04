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
    public class OilPressesController : Controller
    {
        private OilProjectDbContext db = new OilProjectDbContext();

        // GET: OilPresses
        public ActionResult Index()
        {
            return View(db.OilPresses.ToList());
        }

        // GET: OilPresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilPress oilPress = db.OilPresses.Find(id);
            if (oilPress == null)
            {
                return HttpNotFound();
            }
            return View(oilPress);
        }

        // GET: OilPresses/Create
        public ActionResult Create()
        {
            PopulateOilPressesDropDownList();
            PopulateFactoriesDropDownList();
            return View();
        }

        // POST: OilPresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OilPressID,OilPressName,OliveType,OlivesWeight,OilOutput,ProductionDate,UserId,FactoryID")] OilPress oilPress)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.OilPresses.Add(oilPress);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            catch (Exception)
            {
                ModelState.AddModelError(" ", "Unable to save changes");
            }

            PopulateOilPressesDropDownList();
            PopulateFactoriesDropDownList();
            return View(oilPress);
        }

        //Method that returns the Productions under a DropDownList 
        private void PopulateOilPressesDropDownList(object selectedOilPress = null)
        {

            var oilPressesQuery = from d in db.UsersAccounts
                                   orderby d.LastName
                                   select d;
            ViewBag.UserId = new SelectList(oilPressesQuery, "UserId", "LastName", selectedOilPress);
        }

        //Method that returns the Factories under a DropDownList 
        private void PopulateFactoriesDropDownList(object selectedFactory = null)
        {

            var factoriesQuery = from d in db.Factories
                                  orderby d.FactoryName
                                  select d;
            ViewBag.FactoryID = new SelectList(factoriesQuery, "FactoryID", "FactoryName", selectedFactory);
        }



        // GET: OilPresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilPress oilPress = db.OilPresses.Find(id);
            if (oilPress == null)
            {
                return HttpNotFound();
            }

            PopulateOilPressesDropDownList(oilPress.UserId);
            PopulateFactoriesDropDownList(oilPress.FactoryID);
            return View(oilPress);
        }

        // POST: OilPresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OilPressID,OilPressName,OliveType,OlivesWeight,OilOutput,ProductionDate,UserId,FactoryID")] OilPress oilPress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oilPress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(oilPressesQuery, "UserId", "LastName", selectedOilPress);

            return View(oilPress);
        }

        // GET: OilPresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilPress oilPress = db.OilPresses.Find(id);
            if (oilPress == null)
            {
                return HttpNotFound();
            }
            return View(oilPress);
        }

        // POST: OilPresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OilPress oilPress = db.OilPresses.Find(id);
            db.OilPresses.Remove(oilPress);
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
