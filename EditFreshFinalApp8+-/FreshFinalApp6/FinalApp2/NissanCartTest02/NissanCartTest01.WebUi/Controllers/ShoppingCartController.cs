using NissanCartTest01.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace NissanCartTest01.WebUi.Controllers
{
    public class ShoppingCartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ShoppingCart
      
        public ActionResult Index()
        {
            return View();
        }

        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Parts.PartID == id)
                    return i;
            return -1;


        }

        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return View("Cart");

        }

        public ActionResult OrderNow(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item(db.Partst.Find(id), 1));
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];

                int index = isExisting(id);
                if (index == -1)
                    cart.Add(new Item(db.Partst.Find(id), 1));
                else
                    cart[index].Quantity++;


                Session["cart"] = cart;
            }
            return View("Cart");
        }

        public ActionResult Update(FormCollection fc)
        {
            string[] quantities = fc.GetValues("quantity");
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                cart[i].Quantity = Convert.ToInt32(quantities[i]);
            Session["cart"] = cart;
            return View("Cart");
        }
        public ActionResult Done()
        {
            //List<Orders> carts = (List <Orders>)Session["cart"];
            var products = Session["cart"] as List<Item>;

            var jobid = Convert.ToInt32(Session["JobCardses"]);

            foreach (var c in products)
            {
                var order = new Orders
                {
                    JobCardId = Convert.ToInt32(jobid),
                    status = "Awaiting",
                    partID = c.Parts.PartID,
                    price = c.Parts.price,
                    quantity = c.Quantity
                    

                };
                db.Orderst.Add(order);
                db.SaveChanges();

                
            }

            return RedirectToAction("GetJobCardDetails", "JobCard", new { @id = jobid });
        }
    }
}