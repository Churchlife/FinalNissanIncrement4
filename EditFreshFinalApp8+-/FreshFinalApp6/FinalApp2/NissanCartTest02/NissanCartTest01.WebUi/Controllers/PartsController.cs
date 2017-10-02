using System;
using System.Linq;
using System.Web.Mvc;
using NissanCartTest01.WebUi.Models;

namespace NissanCartTest01.WebUi.Controllers
{
    public class PartsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Parts
        public ActionResult Index()
        {
            int jds = Convert.ToInt32(Session["JobCardses"]);

            var serv = db.Services
                .FirstOrDefault(x => x.JobCardId == jds);

            string servicetype =  serv.type.ToString();

            if (servicetype.Equals("Standard"))
            {
                return RedirectToAction("GetJobCardDetails", "JobCard", new { id = serv.JobCardId });
            }
            else
            {
                ViewBag.listParts = db.Partst.ToList();
                return View();
            }
        }

        public ActionResult UnderBonnet()
        {
            int jds = Convert.ToInt32(Session["JobCardses"]);

            var serv = db.Services
                .FirstOrDefault(x => x.JobCardId == jds);

            string servicetype = serv.type.ToString();

            if (servicetype.Equals("Standard"))
            {
                return RedirectToAction("GetJobCardDetails", "JobCard", new { id = serv.JobCardId });
            }
            else
            {
                ViewBag.listcat1 = db.Partst.ToList();
                return View();
            }
            
        }

        public ActionResult Chassis()
        {
            int jds = Convert.ToInt32(Session["JobCardses"]);

            var serv = db.Services
                  .FirstOrDefault(x => x.JobCardId == jds);

            string servicetype = serv.type.ToString();

            if (servicetype.Equals("Standard"))
            {
                return RedirectToAction("GetJobCardDetails", "JobCard", new { id = serv.JobCardId });
            }
            else
            {
                ViewBag.listcat2 = db.Partst.ToList();
                return View();
            }

           
        }
        public ActionResult Wheels()
        {

            int jds = Convert.ToInt32(Session["JobCardses"]);

            var serv = db.Services
                 .FirstOrDefault(x => x.JobCardId == jds);

            string servicetype = serv.type.ToString();

            if (servicetype.Equals("Standard"))
            {
                return RedirectToAction("GetJobCardDetails", "JobCard", new { id = serv.JobCardId });
            }
            else
            {
                ViewBag.listcat3 = db.Partst.ToList();
                return View();
            }
           
        }

        public ActionResult Electrical()
        {
            int jds = Convert.ToInt32(Session["JobCardses"]);

            var serv = db.Services
                .FirstOrDefault(x => x.JobCardId == jds);

            string servicetype = serv.type.ToString();

            if (servicetype.Equals("Standard"))
            {
                return RedirectToAction("GetJobCardDetails", "JobCard", new { id = serv.JobCardId });
            }
            else
            {
                ViewBag.listcat4 = db.Partst.ToList();
                return View();
            }

            
        }

        public ActionResult Internal()
        {
            int jds = Convert.ToInt32(Session["JobCardses"]);

            var serv = db.Services
                 .FirstOrDefault(x => x.JobCardId == jds);

            string servicetype = serv.type.ToString();

            if (servicetype.Equals("Standard"))
            {
                return RedirectToAction("GetJobCardDetails", "JobCard", new { id = serv.JobCardId });
            }
            else
            {
                ViewBag.listcat5 = db.Partst.ToList();
                return View();
            }

            
        }

        public ActionResult External()
        {
            int jds = Convert.ToInt32(Session["JobCardses"]);

            var serv = db.Services
                 .FirstOrDefault(x => x.JobCardId == jds);

            string servicetype = serv.type.ToString();

            if (servicetype.Equals("Standard"))
            {
                return RedirectToAction("GetJobCardDetails", "JobCard", new { id = serv.JobCardId });
            }
            else
            {
                ViewBag.listcat6 = db.Partst.ToList();
                return View();
            }

           
        }



    }
}