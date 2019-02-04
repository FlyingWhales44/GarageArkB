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
    public class PartsModelsController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: PartsModels
        public ActionResult Index()
        {
            return View(db.PartsModels.ToList());
        }

        [Authorize]
        public ActionResult MyIndex()
        {
            string usrID = User.Identity.GetUserId();
            var o = db.Owner.SingleOrDefault(x => x.UserID == usrID);
            if (o != null)
                return View(o.Parts.ToList());
            else
                return View();
        }

        // GET: PartsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsModels partsModels = db.PartsModels.Find(id);

            var CarInfo = db.Car.FirstOrDefault(x => x.ID == partsModels.IdCar);

            ViewBag.CarModel = CarInfo.Model;
            ViewBag.CarVIN = CarInfo.VIN;
            ViewBag.CarSeries = CarInfo.Series;
            ViewBag.CarBrand = CarInfo.Brand;
            ViewBag.PhotoURL = CarInfo.PhotoURL;

            if (partsModels == null)
            {
                return HttpNotFound();
            }
            return View(partsModels);
        }

        // GET: PartsModels/Create
        [Authorize]
        public ActionResult Create()
        {
            List<CarsModels> carList = db.Car.ToList();
            ViewBag.Cars = new SelectList(carList, "ID", "VIN");
            return View();
        }

        // POST: PartsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IdCar,Name,CatalogNr,SellingPrice,data,description")] PartsModels partsModels)
        {
            if (ModelState.IsValid)
            {
                string usrID = User.Identity.GetUserId();
                var o = db.Owner.Where(x => x.UserID == usrID).FirstOrDefault();
                o.Parts.Add(partsModels);
                db.PartsModels.Add(partsModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partsModels);
        }

        // GET: PartsModels/Edit/5
        [Authorize]
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
            List<CarsModels> carList = db.Car.ToList();
            ViewBag.Cars = new SelectList(carList, "ID", "VIN");
            return View(partsModels);
        }

        // POST: PartsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IdCar,Name,CatalogNr,SellingPrice,data,description")] PartsModels partsModels)
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
        [Authorize]
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
        [Authorize]
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
