using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Data;
using System.Data.Entity;
using System.Net;
using NissanCartTest01.WebUi.Models;
using System.Net.Mail;

namespace NissanCartTest01.WebUi.Controllers
{
    public class VehicleOrdersController : Controller
    {
        // GET: VehicleOrders
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: VehicleOrders
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Orders()
        {

            var payobj = db.Payments
                .Include(x => x.VehicleForSale)
                .Where(x => x.FinanceStatus.ToUpper() == "Approved" && x.VehicleForSale.status.ToUpper() == "FactoryOrder").ToList();


            return View(payobj);

        }

        public ActionResult FactoryOrderMail(int id)
        {
            //var ordersl = db.Payments
            //    .Include(x => x.VehicleForSale)
            //    .Include(x => x.VehicleForSale.VehicleSale)
            //    .Include(x => x.VehicleForSale.VehicleSale.VCategory)
            //    .FirstOrDefault(x => x.VehicleForSale.RegNumber == id);

            //if (ordersl != null)
            //{
            //    ordersl.VehicleForSale.status = "FactoryBuild";
            //    db.SaveChanges();
            //}

            //string factoryinfo = ordersl.VehicleForSale.VehicleSale.VCategory.Type + "&nbsp;" + ordersl.VehicleForSale.VehicleSale.YearMade + "&nbsp;" + ordersl.VehicleForSale.VehicleSale.Make + "&nbsp;" + ordersl.VehicleForSale.VehicleSale.Model + "&nbsp;" + ordersl.VehicleForSale.VehicleSale.VINNumber;


            //string vechRegNumber = Convert.ToString(ordersl.VehicleForSale.RegNumber);
            //string vechVINNumber = Convert.ToString(ordersl.VehicleForSale.VehicleSale.VINNumber);
            //string vechMake = ordersl.VehicleForSale.VehicleSale.Make;
            //string vechModel = ordersl.VehicleForSale.VehicleSale.Model;
            //string vechPrice = Convert.ToString(ordersl.VehicleForSale.VehicleSale.Price);
            //string vechCurrentMileage = Convert.ToString(ordersl.VehicleForSale.VehicleSale.CurrentMileage);
            //string vechYearMade = Convert.ToString(ordersl.VehicleForSale.VehicleSale.YearMade);
            //string vechTransmission = ordersl.VehicleForSale.VehicleSale.Transmission;
            //string vechFeatures = ordersl.VehicleForSale.VehicleSale.Features;


            //try
            //{

            //    var apiKey = "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";
            //    var client = new SendGridClient(apiKey);
            //    var from = new EmailAddress("no-reply@nissancarttest01.com", "Nissan Sales Team");
            //    var subject = "Factory Order Test";
            //    var to = new EmailAddress("thembajali@gmail.com", "Example User");
            //    var plainTextContent = factoryinfo;
            //    var htmlContent = "<html><div>< h2> Factory Order Details of :" + vechModel + "&nbsp;" + vechVINNumber + "</h2><table class='table table-bordered table-condensed table-striped'><tr><td><table class='table table-bordered table-condensed table-striped'><tr><td colspan = '2' > Vehicle Details</td></tr><tr><td>Make </td><td>" + vechMake + "</td></tr><tr><td>Model</td><td>" + vechModel + "</td></tr><tr><td>Year</td><td>" + vechYearMade + "</td></tr><tr><td>Transmission</td><td>" + vechTransmission + "</td></tr><tr><td>Extra Features</td><td>" + vechFeatures + "</td></tr>< tr >< td > Price </ td >< td >" + vechPrice + "</ td ></ td ></ tr ></table></ td ></ tr ></table></div></html>";
            //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //    var response = client.SendEmailAsync(msg);
            //}
            //catch
            //{
            //    Content("Email not sending");
            //}

            return RedirectToAction("Orders");


        }

        public ActionResult FactoryDelivery()
        {
            var payobj = db.Payments
               .Include(x => x.VehicleForSale)
               .Where(x => x.VehicleForSale.status.ToUpper() == "FactoryDelivery").ToList();


            return View(payobj);
        }

        public ActionResult FactoryDeliveryMail(int id)
        {
            //var ordersl = db.Payments
            //    .Include(x => x.VehicleForSale)
            //    .Include(x => x.VehicleForSale.VehicleSale)
            //    .Include(x => x.VehicleForSale.VehicleSale.VCategory)
            //    .FirstOrDefault(x => x.VehicleForSale.RegNumber == id);

            //if (ordersl != null)
            //{
            //    ordersl.VehicleForSale.status = "FactoryDelivery";
            //    db.SaveChanges();
            //}

            //string factoryinfo = ordersl.VehicleForSale.VehicleSale.VCategory.Type + "&nbsp;" + ordersl.VehicleForSale.VehicleSale.YearMade + "&nbsp;" + ordersl.VehicleForSale.VehicleSale.Make + "&nbsp;" + ordersl.VehicleForSale.VehicleSale.Model + "&nbsp;" + ordersl.VehicleForSale.VehicleSale.VINNumber;

            //string vechRegNumber = Convert.ToString(ordersl.VehicleForSale.RegNumber);
            //string vechVINNumber = Convert.ToString(ordersl.VehicleForSale.VehicleSale.VINNumber);
            //string vechMake = ordersl.VehicleForSale.VehicleSale.Make;
            //string vechModel = ordersl.VehicleForSale.VehicleSale.Model;
            //string vechPrice = Convert.ToString(ordersl.VehicleForSale.VehicleSale.Price);
            //string vechCurrentMileage = Convert.ToString(ordersl.VehicleForSale.VehicleSale.CurrentMileage);
            //string vechYearMade = Convert.ToString(ordersl.VehicleForSale.VehicleSale.YearMade);
            //string vechTransmission = ordersl.VehicleForSale.VehicleSale.Transmission;
            //string vechFeatures = ordersl.VehicleForSale.VehicleSale.Features;


            //try
            //{

            //    var apiKey = "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";
            //    var client = new SendGridClient(apiKey);
            //    var from = new EmailAddress("no-reply@nissancarttest01.com", "Nissan Sales Team");
            //    var subject = "Factory Delivery Test";
            //    var to = new EmailAddress("thembajali@gmail.com", "Example User");
            //    var plainTextContent = factoryinfo;
            //    var htmlContent = "<html><div>< h2> Factory Delivery Details of :" + vechModel + "&nbsp;" + vechVINNumber + "</h2><table class='table table-bordered table-condensed table-striped'><tr><td><table class='table table-bordered table-condensed table-striped'><tr><td colspan = '2' > Vehicle Details</td></tr><tr><td>Make </td><td>" + vechMake + "</td></tr><tr><td>Model</td><td>" + vechModel + "</td></tr><tr><td>Year</td><td>" + vechYearMade + "</td></tr><tr><td>Transmission</td><td>" + vechTransmission + "</td></tr><tr><td>Extra Features</td><td>" + vechFeatures + "</td></tr>< tr >< td > Price </ td >< td >" + vechPrice + "</ td ></ td ></ tr ></table></ td ></ tr ></table></div></html>";
            //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //    var response = client.SendEmailAsync(msg);
            //}
            //catch
            //{
            //    Content("Email not sending");
            //}

            return RedirectToAction("FactoryDelivery");


        }


    }
}