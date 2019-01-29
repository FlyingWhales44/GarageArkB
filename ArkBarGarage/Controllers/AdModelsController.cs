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
    public class AdModelsController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: AdModels
        public ActionResult Index()
        {
            return View(db.AdModels.ToList());
        }

        // GET: AdModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdModel adModel = db.AdModels.Find(id);
            if (adModel == null)
            {
                return HttpNotFound();
            }
            return View(adModel);
        }

        // GET: AdModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdCar,IsActive")] AdModel adModel)
        {
            if (ModelState.IsValid)
            {
                db.AdModels.Add(adModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adModel);
        }

        // GET: AdModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdModel adModel = db.AdModels.Find(id);
            if (adModel == null)
            {
                return HttpNotFound();
            }
            return View(adModel);
        }

        // POST: AdModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdCar,IsActive")] AdModel adModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adModel);
        }

        // GET: AdModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdModel adModel = db.AdModels.Find(id);
            if (adModel == null)
            {
                return HttpNotFound();
            }
            return View(adModel);
        }

        // POST: AdModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdModel adModel = db.AdModels.Find(id);
            db.AdModels.Remove(adModel);
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
