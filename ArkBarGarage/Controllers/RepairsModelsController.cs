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
    public class RepairsModelsController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: RepairsModels
        public ActionResult Index()
        {
            return View(db.RepairsModels.ToList());
        }

        // GET: RepairsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairsModels repairsModels = db.RepairsModels.Find(id);
            if (repairsModels == null)
            {
                return HttpNotFound();
            }
            return View(repairsModels);
        }

        // GET: RepairsModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepairsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdCar,Name,Description,RepairPrice")] RepairsModels repairsModels)
        {
            if (ModelState.IsValid)
            {
                db.RepairsModels.Add(repairsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairsModels);
        }

        // GET: RepairsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairsModels repairsModels = db.RepairsModels.Find(id);
            if (repairsModels == null)
            {
                return HttpNotFound();
            }
            return View(repairsModels);
        }

        // POST: RepairsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdCar,Name,Description,RepairPrice")] RepairsModels repairsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repairsModels);
        }

        // GET: RepairsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairsModels repairsModels = db.RepairsModels.Find(id);
            if (repairsModels == null)
            {
                return HttpNotFound();
            }
            return View(repairsModels);
        }

        // POST: RepairsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairsModels repairsModels = db.RepairsModels.Find(id);
            db.RepairsModels.Remove(repairsModels);
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
