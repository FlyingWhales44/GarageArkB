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
using Microsoft.AspNet.Identity;

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

        [Authorize]
        public ActionResult MyIndex()
        {
            string usrID = User.Identity.GetUserId();
            var o = db.Owner.SingleOrDefault(x => x.UserID == usrID);
            if (o != null)
                return View(o.Repairs.ToList());
            else
                return View();
        }

        // GET: RepairsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairsModels repairsModels = db.RepairsModels.Find(id);
            var CarInfo = db.Car.FirstOrDefault(x => x.IdCar == repairsModels.IdCar);

            ViewBag.CarModel = CarInfo.Model;
            ViewBag.CarVIN = CarInfo.VIN;
            ViewBag.CarSeries = CarInfo.Series;
            ViewBag.CarBrand = CarInfo.Brand;

            if (repairsModels == null)
            {
                return HttpNotFound();
            }
            return View(repairsModels);
        }

        // GET: RepairsModels/Create
        [Authorize]
        public ActionResult Create()
        {
            List<CarsModels> carList = db.Car.ToList();
            ViewBag.Cars = new SelectList(carList, "IdCar", "VIN");
            return View();
        }

        // POST: RepairsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdCar,Name,Description,RepairPrice")] RepairsModels repairsModels)
        {
            if (ModelState.IsValid)
            {
                string usrID = User.Identity.GetUserId();
                var o = db.Owner.Where(x => x.UserID == usrID).FirstOrDefault();
                o.Repairs.Add(repairsModels);
                db.RepairsModels.Add(repairsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repairsModels);
        }

        // GET: RepairsModels/Edit/5
        [Authorize]
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
            List<CarsModels> carList = db.Car.ToList();
            ViewBag.Cars = new SelectList(carList, "IdCar", "VIN");
            return View(repairsModels);
        }

        // POST: RepairsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
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
