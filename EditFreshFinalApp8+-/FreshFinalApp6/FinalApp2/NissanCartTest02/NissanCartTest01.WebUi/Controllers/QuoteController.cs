using NissanCartTest01.WebUi.Models;
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
using System.Net.Mail;

namespace NissanCartTest01.WebUi.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {

            return View();
        }



        public ActionResult GenerateQuote(/*int id*/)
        {

            Tuple<Payment, IEnumerable<VehCat>, VehicleForSale,Customer,Order, IEnumerable<OrderDetail>, IEnumerable<Cart>, IEnumerable<Genre>> QuoteObj = null;
            var cartobjs = Session["CartOrder"];
            
            int id = 2;
            var payobj = db.Payments
                .FirstOrDefault(x => x.PaymentID == id);
            var saleobj = db.VehicleForSales
               .FirstOrDefault(x => x.SaleID == payobj.SaleID);
            var orderobj=db.Orders
                .FirstOrDefault(x => x.OrderId == saleobj.OrderId);

            var ordersobj = db.OrderDetails
                .Where(x => x.OrderId == orderobj.OrderId);

             var vechobj= new List<VehCat>();
            foreach (var v in ordersobj)
            {
                vechobj= db.VehCats
                        .Where(x => x.VehicleId == v.VehicleId).ToList();
            }

            var cartobj = new List<Cart>();
            foreach(var acc in vechobj)
            {
                cartobj = db.Carts
                    .Where(x => x.VehicleId == acc.VehicleId).ToList();
            }

            var gvech = new List<Genre>();
            foreach(var g in vechobj)
            {
                gvech = db.Genres
                    .Where(x => x.GenreId == g.GenreId).ToList();
            }
           
            var cust = db.Customers
                .FirstOrDefault(x => x.ID_Number == payobj.ID_Number);

            Session["PayID"] = payobj.PaymentID;

            QuoteObj = new Tuple<Payment, IEnumerable<VehCat>, VehicleForSale, Customer, Order, IEnumerable<OrderDetail>, IEnumerable<Cart>, IEnumerable<Genre>>(payobj, vechobj, saleobj, cust,orderobj,ordersobj,cartobj,gvech);
            Session["Quote"] = QuoteObj;

            return View(QuoteObj);
        }

        public ActionResult SendMail(int id)
        {
            Tuple<Payment, IEnumerable<VehCat>, VehicleForSale, Customer, Order, IEnumerable<OrderDetail>, Cart, Genre> QuoteObj = null;

            var payobj = db.Payments
                .FirstOrDefault(x => x.PaymentID == id);
            var saleobj = db.VehicleForSales
               .FirstOrDefault(x => x.SaleID == payobj.SaleID);
            var orderobj = db.Orders
                .FirstOrDefault(x => x.OrderId == saleobj.OrderId);
            var ordersobj = db.OrderDetails.Where(x => x.OrderId == orderobj.OrderId);

            //var vechobj = List<VehCat>();
            //foreach (var v in ordersobj)
            //{
            //    vechobj = db.VehCats
            //            .Where(x => x.VehicleId == v.VehicleId).ToList();
            //}

            var cust = db.Customers
                .FirstOrDefault(x => x.ID_Number == payobj.ID_Number);

            Session["PayID"] = payobj.PaymentID;

            //QuoteObj = new Tuple<Payment, IEnumerable<VehCat>, VehicleForSale, Customer, Order, IEnumerable<OrderDetail>, Cart, Genre>(payobj, vechobj, saleobj, cust);


            if (saleobj != null)
            {
                saleobj.status = "FactoryOrder";
                db.SaveChanges();
            }


            string custname = cust.Name + "&nbsp;" + cust.Surname;
            string custcontact = "";
            string custID_Number = "";
            string custName = "";
            string custSurname = "";
            string custEmailAddress = cust.EmailAddress;
            string custContactNumber = "";
            string custPhysical_Address = "";
            string custPostal_Address = "";

            //string vechRegNumber = Convert.ToString(vechobj.RegNumber);
            //string vechVINNumber = Convert.ToString(vechobj.VINNumber);
            //string vechMake = vechobj.Make;
            //string vechModel = vechobj.Model;
            //string vechPrice = Convert.ToString(vechobj.Price);
            //string vechCurrentMileage = Convert.ToString(vechobj.CurrentMileage);
            //string vechYearMade = Convert.ToString(vechobj.YearMade);
            //string vechTransmission = vechobj.Transmission;
            //string vechFeatures = vechobj.Features;

            string salePaymentPlan = saleobj.PaymentPlan;

            string saleMonthlyPayment = Convert.ToString(saleobj.MonthlyPayment);

            string saleMonthlyPaymentDate = Convert.ToString(saleobj.MonthlyPaymentDate);

            string saleRegristrationYear = saleobj.RegristrationYear;

            string salestatus = saleobj.status;

            string payFinanceApproval = payobj.FinanceApproval;
            string payFinanceCompany = payobj.FinanceCompany;
            string payFinanceStatus = payobj.FinanceStatus;



            //string vechinfo = vechobj.VCategory.Type + "&nbsp;" + vechobj.YearMade + "&nbsp;" + vechobj.Make + "&nbsp;" + vechobj.Model + "&nbsp;" + vechobj.VINNumber;
            //string saleinfo = saleobj.MonthlyPayment + "&nbsp;" + saleobj.MonthlyPaymentDate + "&nbsp;" + saleobj.PaymentPlan;
            //string payinfo = payobj.FinanceCompany + "&nbsp;" + payobj.FinanceApproval + "&nbsp;" + payobj.FinanceStatus;



            try
            {

                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("no-reply@nissancarttest01.com", "Nissan Sales Team");
                var subject = "Quote Test";
                var to = new EmailAddress(custEmailAddress, "Example User");
                //var plainTextContent = custname + vechinfo + saleinfo + payinfo;
                //var htmlContent = "<html><div>< h2> Order Details of :" + custname + "</h2><table class='table table-bordered table-condensed table-striped'><tr><td><table class='table table-bordered table-condensed table-striped'><tr><td colspan = '2' > Vehicle Details</td></tr><tr><td>Make </td><td>" + vechMake + "</td></tr><tr><td>Model</td><td>" + vechModel + "</td></tr><tr><td>Year</td><td>" + vechYearMade + "</td></tr><tr><td>Transmission</td><td>" + vechTransmission + "</td></tr><tr><td>Extra Features</td><td>" + vechFeatures + "</td></tr>< tr >< td > Price </ td >< td >" + vechPrice + "</ td ></ tr ></table><table class='table table-bordered table - condensed table - striped'>< tr >< td colspan = '2' > Payments Details </ td > </ tr >< tr >< td > Payments Plan </ td >< td > " + salePaymentPlan + "</ td > </ tr > < tr >< td > Monthly Payments </ td >< td > " + saleMonthlyPayment + "</ td ></ tr >< tr >< td > Monthly Payments Date </ td >< td > " + saleMonthlyPaymentDate + "</ td ></ tr >< tr >< td > Regristration Year </ td >< td >" + saleRegristrationYear + "</ td ></ tr >< tr >< td > status </td><td>" + salestatus + "</td>< /tr></table><table class='table table-bordered table - condensed table - striped'>< tr >< td >< table class='table table-bordered table-condensed table-striped'><tr><td colspan = '2' > Financial Details</td></tr><tr><td>Finance Approval</td><td>" + payFinanceApproval + "</td></tr><tr><td>Finance Comapny</td><td>" + payFinanceCompany + "</td></tr><tr><td>Finance Status</td><td>" + payFinanceStatus + "</td></tr></table></td></tr></table></div></html>";
                //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                //var response = client.SendEmailAsync(msg);
            }
            catch
            {
                Content("Email not sending");
            }

            return RedirectToAction("Orders", "VehicleOrders");
        }
    }
}