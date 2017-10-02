using System;
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
    //[Authorize(Roles = "admin,advice,customer")]
    public class ServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Services
        public ActionResult Index()
        {
            var services = db.Services.
                Include(s => s.JobCard).ToList();

            return View(services);
        }


        [HttpPost]
        public ActionResult Index(string txtTechname)
        {
            var staff = db.Staffs
                    .FirstOrDefault(x => x.Name == txtTechname);

            var servicex = db.Services
                .Include(s => s.JobCard)
                .Include(x => x.JobCard.Vehicle)
                .Where(x => x.StaffID == staff.StaffId).ToList();

          
            return View(servicex);
        }
        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            ViewBag.JobCardId = new SelectList(db.JobCards, "JobCardId", "Techfaults");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceID,StartTime,EndTime,Pass,Reason,StaffID,JobCardId")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobCardId = new SelectList(db.JobCards, "JobCardId", "Techfaults", service.JobCardId);
            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobCardId = new SelectList(db.JobCards, "JobCardId", "Techfaults", service.JobCardId);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServiceID,StartTime,EndTime,Pass,Reason,StaffID,JobCardId")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobCardId = new SelectList(db.JobCards, "JobCardId", "Techfaults", service.JobCardId);
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
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

        // GET: Services
        public ActionResult CustomerFind()
        {
            //var services = db.Services.Include(s => s.JobCard);
            return View(/*services.ToList()*/);
        }

        [HttpPost]
        public ActionResult CustomerFind(string txtRegNum)
        {
            try
            {
                var vechi = db.Vehicles
                     .FirstOrDefault(x => x.RegId == txtRegNum);

                var job = db.JobCards
                    .FirstOrDefault(x => x.RegId == vechi.RegId);

                int jvalue = job.JobCardId;

                Session["ID"] = jvalue;

                return RedirectToAction("CustomerRecords");

            }
            catch
            {
                return Content("Vehicle Not Found");
            }

            

        }

        public ActionResult CustomerRecords()
        {
            int id = (int)Session["ID"];
            var servicex = db.Services
                .Include(s => s.JobCard)
                .Include(x => x.JobCard.Vehicle)
                .Where(x => x.JobCardId == id).ToList();


            return View(servicex);

        }

        public ActionResult ServiceRating(int id)
        {
            var servicer = db.Services
                 .FirstOrDefault(x => x.ServiceID == id);

            return View(servicer);

        }

        public ActionResult EnterRating(int id)
        {
            var servicer = db.Services
                 .FirstOrDefault(x => x.ServiceID == id);

           

            if (Request.Form["one"] != null)
            {
                
                int rate = 1;

                servicer.rating = rate;
                servicer.commission += 2;
                
                db.SaveChanges();
               
            }
            else if (Request.Form["two"] != null)
            {
               
                int rate = 2;
                
                servicer.rating = rate;
                servicer.commission += 3;
                
                db.SaveChanges();
               
            }
            else if (Request.Form["three"] != null)
            {
                
                int rate = 3;
                
                servicer.rating = rate;
                servicer.commission += 4;
              
                db.SaveChanges();
                
            }
            else if (Request.Form["four"] != null)
            {
                
                int rate = 4;
                
                servicer.rating = rate;
                servicer.commission += 5;
                
                db.SaveChanges();
              
            }
            else if (Request.Form["five"] != null)
            {
                
                int rate = 5;
                
                servicer.rating = rate;
                servicer.commission += 7;
                
                db.SaveChanges();
                
            }

            return RedirectToAction("CustomerRecords");

        }


        public ActionResult GetJobCardsSA()
        {
            var JobCards = db.JobCards
                .Include(x => x.Vehicle)
                .Where(x => x.Progress.ToUpper() == "AWAITING" || x.Progress.ToUpper() == "In-Service").ToList();

            return View(JobCards);
        }

        public ActionResult Orders(int id)
        {
            var OrderList = db.Orderst
                .Where(x => x.JobCardId == id && x.status.ToUpper() == "AWAITING").ToList();
            return View(OrderList);
        }

        public ActionResult OrdersPending(int id)
        {
            var OrderList = db.Orderst
                .Where(x => x.JobCardId == id && x.status.ToUpper() == "PENDING").ToList();
            return View(OrderList);
        }

        public void OrderApproval(int id)
        {
            var ordersl = db.Orderst
                .FirstOrDefault(x => x.JobCardId == id);
            if (ordersl != null)
            {
                ordersl.status = "Pending";
                db.SaveChanges();
            }

        }




    }
}








