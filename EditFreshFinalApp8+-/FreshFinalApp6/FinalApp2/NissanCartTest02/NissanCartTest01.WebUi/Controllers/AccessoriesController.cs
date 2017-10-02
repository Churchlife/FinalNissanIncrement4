using NissanCartTest01.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace NissanCartTest01.WebUi.Controllers
{
    public class AccessoriesController : Controller
    {



        //THIS CONTROLLER IS FOR LOADING ACCESSORIES
        ApplicationDbContext storeDB = new ApplicationDbContext();
        // GET: Accessories
        public ActionResult Acc(int id)
        {
            //LOADS ACCESSORIES BASED ON VEHICLE ID
            VehCat vehc = storeDB.VehCats.Single(x=>x.VehicleId==id);
            Accessories accobj = storeDB.Accessories.FirstOrDefault(x => x.VehicleName == vehc.Name);
            var name = accobj.VehicleName;
            var v = "";
            switch (name)
            {

                case "Micra":
                    v = "Micra";
                    break;
                case "Almera":
                    v = "Almera";
                    break;
                case "Juke":
                    v = "Juke";
                    break;
                default:
                    v = "AccIndex";
                    break;
            }

            return RedirectToAction(v);
        }

        public ActionResult Micra()
        {
           
            List<Accessories> ml = storeDB.Accessories.ToList();
            List<Accessories> mlsearch = new List<Accessories>();
            foreach(var s in ml)
            {
                if(s.VehicleName=="Micra")
                {
                    mlsearch.Add(s);
                }
            }
            ViewBag.mlsearch = mlsearch;
            return View();
        }

        public ActionResult Almera()
        {
            return View();
        }

        public ActionResult Juke()
        {
            return View();
        }

        public ActionResult AccIndex()
        {
            var all = storeDB.Accessories.ToList();
            return View(all);
        }

        public ActionResult AddAccessories(int id)
        {//ADDS ACCESSORIES
         //List<Item> cart = new List<Item>();
         //cart.Add(new Item(db.Partst.Find(id), 1));
         //Session["cart"] = cart;

            if (Session["acccart"] == null)
            {
                List<AccItem> acccart = new List<AccItem>();
                acccart.Add(new AccItem(storeDB.Accessories.Find(id), 1));
                Session["acccart"] = acccart;
            }
            else
            {
                List<AccItem> acccart = (List<AccItem>)Session["acccart"];

                int index = isExisting(id);
                if (index == -1)
                    acccart.Add(new AccItem(storeDB.Accessories.Find(id), 1));
                else
                    acccart[index].Quantity++;


                Session["acccart"] = acccart;
            }
            return View("Chosen");
        }


       



        

        public ActionResult More()
        {
            List<AccItem> acco = Session["acccart"] as List<AccItem>;
           
            VehCat searchname=new VehCat();
            foreach (AccItem e in acco)
            {
                 searchname = storeDB.VehCats.FirstOrDefault(x=>x.Name==e.Accessories.VehicleName);
                
            }
            
           
           
            
            
            return RedirectToAction("Acc","Accessories", new { id = searchname.VehicleId });
        }

        public ActionResult save()
        {
            
                Cart cart = Session["cartdata"] as Cart;
                List<AccItem> aciolist = Session["acccart"] as List<AccItem>;
                StringBuilder sb = new StringBuilder();
                foreach(var e in aciolist)
                {
                    sb.Append(e.Accessories.Categories + "-" + e.Accessories.Name + ",");
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);
                cart.AccessoriesL = sb.ToString();
                Cart rem = storeDB.Carts.Single(x => x.RecordId == cart.RecordId);
                rem.AccessoriesL = sb.ToString();
                storeDB.SaveChanges();
                
            
            return RedirectToAction("Index","AccCart");
        }
























        //CartSHIT


       
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        private int isExisting(int id)
        {
            List<AccItem> acccart = (List<AccItem>)Session["acccart"];
            for (int i = 0; i < acccart.Count; i++)
                if (acccart[i].Accessories.Id == id)
                    return i;
            return -1;


        }

        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            List<AccItem> acccart = (List<AccItem>)Session["acccart"];
            acccart.RemoveAt(index);
            Session["acccart"] = acccart;
            return RedirectToAction("Chosen");

        }

   

        public ActionResult Update(FormCollection fc)
        {
            string[] quantities = fc.GetValues("quantity");
            List<AccItem> acccart = (List<AccItem>)Session["acccart"];
            for (int i = 0; i < acccart.Count; i++)
                acccart[i].Quantity = Convert.ToInt32(quantities[i]);
            Session["cart"] = acccart;
            return RedirectToAction("Chosen");
        }

    }
}