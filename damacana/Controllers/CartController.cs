using Damacana.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Damacana.Controllers
{
    public class CartController : Controller
    {
        public static Cart cart = new Cart()
        {
            id = 1,
            userId = 1,
            totalAmount = (decimal)0.0,
            items = new List<KeyValuePair<Product, int>>()
        };

        public static List<Purchase> purchases = new List<Purchase>();


        // GET: Cart
        public ActionResult Index()
        {
            this.CalculateTotalAmount();
            return View(cart);
        }

        public ActionResult AddToCart(int id)
        {

            foreach (Product p in HomeController.products)
                if (p.id == id)
                {
                    //first search the cart if there is another one of the same product
                    foreach (KeyValuePair<Product, int> itemInCart in cart.items)
                    {
                        if (itemInCart.Key.id == id) // found a match!!
                        {
                            cart.items.Remove(itemInCart); //remove existing item from list
                            KeyValuePair<Product, int> newItem = //create a new item with increased amount
                                new KeyValuePair<Product, int>(itemInCart.Key, itemInCart.Value + 1);
                            cart.items.Add(newItem); //re-add the item
                            this.CalculateTotalAmount();
                            return View("Index", cart);
                        }
                    }

                    //if no match is found, add it
                    KeyValuePair<Product, int> item = new KeyValuePair<Product, int>(p, 1);
                    cart.items.Add(item);
                    this.CalculateTotalAmount();
                    return View("Index", cart);
                }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult RemoveItem(int id)
        {
            foreach (KeyValuePair<Product, int> itemInCart in cart.items)
            {
                if (itemInCart.Key.id == id) // found a match!!
                {
                    cart.items.Remove(itemInCart); //remove existing item from list   
                    this.CalculateTotalAmount();
                    return View("Index", cart);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public ActionResult Clear(int id)
        {
            if (cart.id != id)
            {
                // this should never occur
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            cart.items.Clear();
            this.CalculateTotalAmount();
            return View("Index", cart);
        }

        public ActionResult Purchase(int id)
        {
            if (cart.id != id)
            {
                // this should never occur
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //create the purchase object
            Purchase purchase = new Purchase();
            purchase.createdOn = DateTime.Now;
            //purchase.items = new List<KeyValuePair<Product, int>>();
            purchase.items = cart.items.ToList(); // creates a elementwise copy of the list
            purchase.totalPrice = cart.totalAmount;
            purchase.userId = cart.userId;
            //purchase.id = TODO;  FIXME

            //add it to the purchases list
            purchases.Add(purchase);

            //clear the cart object
            cart.items.Clear();
            this.CalculateTotalAmount();

            return View("PurchaseCompleted", purchase);

        }

        public ActionResult PurchaseList()
        {
            return View(purchases);
        }

        public ActionResult PurchaseDetails(Purchase purchase)
        {
            return View("PurchaseCompleted", purchase);
        }

        protected void CalculateTotalAmount()
        {
            cart.totalAmount = (decimal)0.0; //reset
            foreach (KeyValuePair<Product, int> itemInCart in cart.items)
            {
                cart.totalAmount += itemInCart.Key.price * itemInCart.Value;
            }
        }
    }
}