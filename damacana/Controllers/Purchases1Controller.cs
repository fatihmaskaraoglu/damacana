using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Damacana.Models;


namespace damacana.Controllers
{
    public class Purchases1Controller : Controller
    {
        public User user1 = new User();
        public PurchaseDBContext db = new PurchaseDBContext();
        public static List<Purchase> PurchasesTem = new List<Purchase>
        {

        };

        public int purchaseid = 0;
        public int i = 0;
        public ActionResult Purchase()
        {
            
            Purchase siparis = new Purchase();
            decimal totalprice = 0;
            siparis.PurchaseList = new List<Product>();
            foreach (Product p in (List<Product>)TempData["Cartlist"])
            {
                siparis.PurchaseList.Add(p);
                totalprice = p.Price + totalprice;
            }
            siparis.Id = purchaseid;
            purchaseid = purchaseid + 1;
            siparis.TotalPrice = totalprice;
            TempData["Siparis"] = siparis;
            i++;
            return View(siparis);

        }

        public ActionResult PurchaseDone()
        {
            using (db)
            {
                Purchase siparis = (Purchase)TempData["Siparis"];
                siparis.User = user1;
                siparis.CreatedOn = DateTime.Now;
                siparis.UserId = i;
                i = i + 1;
               db.Purchases.Add(siparis);
                PurchasesTem.Add(siparis);
                db.SaveChanges();
                return View(siparis);

            }

        }
        public ActionResult PurchaseHistory()
        {
            /*
            foreach (Purchase p in PurchasesTem)
            {
                db.Purchases.Add(p);
                

            }
            db.SaveChanges();
             */
            return View(db.Purchases);

        }
        /*
        public static List<Product> CartProduct = Damacana.Controllers.ProductsController.CartProducts;

        public static List<Purchase> PurchasesTem = new List<Purchase>
        {

        };
   

        public ActionResult PurchaseDone()
        {
            Purchase purchase = new Purchase();
            int i = 1;
            purchase.Id = i;
            purchase.UserId = i;
            purchase.CreatedOn = DateTime.Now;
          decimal totalprice = 0;
            purchase.PurchaseList = CartProduct;
            foreach (Product p in CartProduct)
            {
                
                totalprice = p.Price + totalprice;
            }
            purchase.TotalPrice = totalprice;

           
            db.Purchases.Add(purchase);
            PurchasesTem.Add(purchase);
            i++;
            
            
           // db.SaveChanges();
            return View(purchase);
        }
     
        public ActionResult PurchaseHistory()
        {
            foreach (Purchase p in PurchasesTem)
            {
                db.SaveChanges();
               
            }
           
            
            //return View(PurchasesTem);
            return View(db.Purchases.ToList());
        }
        */
    }
}