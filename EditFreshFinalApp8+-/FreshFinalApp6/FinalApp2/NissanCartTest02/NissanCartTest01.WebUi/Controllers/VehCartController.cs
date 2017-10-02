using NissanCartTest01.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NissanCartTest01.WebUi.Controllers
{
    public class VehCartController : Controller
    {
        ApplicationDbContext storeDB = new ApplicationDbContext();

        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            // Return the view
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5

        public ActionResult AddToCart(int id)
        {

            // Retrieve the album from the database
            var addedvehicle = storeDB.VehCats.Single(veh => veh.VehicleId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            //addedvehicle.Name
            cart.AddToCart(addedvehicle);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            string vehName = storeDB.Carts
                .Single(item => item.RecordId == id).VehCat.Name;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(vehName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }

        //public ActionResult Acc(string name)
        //{
        //    var v="";
        //    switch (name)
        //    {

        //        case "Micra":
        //            v="Micra";
        //            break;
        //        case "Almera":
        //            v = "Almera";
        //            break;
        //        case "Juke":
        //            v = "Juke";
        //            break;
        //        default:
        //            v = "AccIndex";
        //            break;
        //    }

        //    return RedirectToAction(v);
        //}

        //public ActionResult Micra()
        //{
        //    return View();
        //}

        //public ActionResult Almera()
        //{
        //    return View();
        //}

        //public ActionResult Juke()
        //{
        //    return View();
        //}

        //public ActionResult AccIndex()
        //{
        //    var all = storeDB.Accessories.ToList();
        //    return View(all);
        //}
    }
}