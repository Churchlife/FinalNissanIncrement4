﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NissanCartTest01.WebUi.Models;

namespace NissanCartTest01.WebUi.Controllers
{
    [Authorize(Roles = "admin,advice")]
    public class VehiclesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        //GET: Service/Plan
        public ActionResult VehicleCheckIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VehicleCheckIn(string button)
        {

            if (button == "Existing")
            {
                this.Session["VType"] = "Existing";
            }
            else if (button == "New")
            {
                this.Session["VType"] = "New";
            }

            return RedirectToAction("ServicePlan", "Vehicles");
        }

        //GET: Service/Plan
        public ActionResult ServicePlan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ServicePlan(string button)
        {

            string Vechtype = (string)Session["VType"];

            if (Vechtype.ToUpper() == "NEW")
            {
                if (button == "Standard")
                {
                    this.Session["servicetype"] = "Standard";
                }
                else if (button == "Custom")
                {
                    this.Session["servicetype"] = "Custom";
                }
                return RedirectToAction("Create", "Vehicles");

            }
            else if (Vechtype.ToUpper() == "EXISTING" && button == "Standard")
            {
                this.Session["servicetype"] = "Standard";
                return RedirectToAction("CreateForStandard", "JobCard");
            }
            else
            {
                this.Session["servicetype"] = "Custom";
                return RedirectToAction("Create", "JobCard");
            }
            //return View("Create", "Vehicles");
        }


        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.ID_Number = new SelectList(db.Customers, "ID_Number", "ID_Number");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VinNumber,RegId,Make,Model,Type,Year,Colour,Mileage,ID_Number")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                var servtype = (string)Session["servicetype"];
                if (servtype == "Standard")
                {
                    return RedirectToAction("CreateForStandard", "JobCard");
                    //return View("CreateForStandard", "JobCard");
                }
                else
                {
                    return RedirectToAction("Create", "JobCard");
                }

            }
            ViewBag.ID_Number = new SelectList(db.Customers, "ID_Number", "ID_Number"/*, customer.ID_Number*/);

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VinNumber,RegId,Make,Model,Type,Year,Colour,Mileage,ID_Number")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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