using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassicGarageArkBar.DAL;
using ClassicGarageArkBar.Models;

namespace ArkBarGarage.Controllers
{
    public class PartsModelsController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: PartsModels
        public ActionResult Index()
        {
            return View(db.PartsModels.ToList());
        }

        // GET: PartsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsModels partsModels = db.PartsModels.Find(id);
            if (partsModels == null)
            {
                return HttpNotFound();
            }
            return View(partsModels);
        }

        // GET: PartsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdCar,Name,CatalogNr,PurchasePrice,SellingPrice,PurchaseDate,SellingDate")] PartsModels partsModels)
        {
            if (ModelState.IsValid)
            {
                db.PartsModels.Add(partsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partsModels);
        }

        // GET: PartsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsModels partsModels = db.PartsModels.Find(id);
            if (partsModels == null)
            {
                return HttpNotFound();
            }
            return View(partsModels);
        }

        // POST: PartsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdCar,Name,CatalogNr,PurchasePrice,SellingPrice,PurchaseDate,SellingDate")] PartsModels partsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partsModels);
        }

        // GET: PartsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsModels partsModels = db.PartsModels.Find(id);
            if (partsModels == null)
            {
                return HttpNotFound();
            }
            return View(partsModels);
        }

        // POST: PartsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartsModels partsModels = db.PartsModels.Find(id);
            db.PartsModels.Remove(partsModels);
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
