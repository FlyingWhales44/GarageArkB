using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassicGarageArkBar.DAL;
using ClassicGarageArkBar.Models;
using Microsoft.AspNet.Identity;

namespace ArkBarGarage.Controllers
{
    public class CarsModelsController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: CarsModels
        public ActionResult Index()
        {
            return View(db.Car.ToList());
        }

        public ActionResult MyIndex()
        {
            string usrID= User.Identity.GetUserId();
            var o=db.Owner.Single(x => x.UserID == usrID);
            return View(o.Cars.ToList());
        }

        // GET: CarsModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsModels carsModels = db.Car.Find(id);
            if (carsModels == null)
            {
                return HttpNotFound();
            }
            return View(carsModels);
        }

        // GET: CarsModels/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Owner, "ID", "Name");
            return View();
        }

        // POST: CarsModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Brand,Model,YearOfProduction,VIN,Series,PhotoURL,PuchaseDate,SaleDate,PuchasePrice,SellingPrice,OwnerId")] CarsModels carsModels)
        {
            //string fname = Path.GetFileNameWithoutExtension(carsModels.ImageFile.FileName);
            //string extension = Path.GetExtension(carsModels.ImageFile.FileName);
            //fname = fname + DateTime.Now.ToString("yymmssfff") + extension;
            //carsModels.PhotoURL = fname;

            if (ModelState.IsValid)
            {
                db.Car.Add(carsModels);
                string usrID = User.Identity.GetUserId();
                var o = db.Owner.Where(x => x.UserID == usrID).FirstOrDefault();
                o.Cars.Add(carsModels);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Owner, "ID", "Name", carsModels.OwnerId);
            return View(carsModels);
        }

        // GET: CarsModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsModels carsModels = db.Car.Find(id);
            if (carsModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Owner, "ID", "Name", carsModels.OwnerId);
            return View(carsModels);
        }

        // POST: CarsModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Brand,Model,YearOfProduction,VIN,Series,PhotoURL,PuchaseDate,SaleDate,PuchasePrice,SellingPrice,OwnerId")] CarsModels carsModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carsModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Owner, "ID", "Name", carsModels.OwnerId);
            return View(carsModels);
        }

        // GET: CarsModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarsModels carsModels = db.Car.Find(id);
            if (carsModels == null)
            {
                return HttpNotFound();
            }
            return View(carsModels);
        }

        // POST: CarsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarsModels carsModels = db.Car.Find(id);
            db.Car.Remove(carsModels);
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
