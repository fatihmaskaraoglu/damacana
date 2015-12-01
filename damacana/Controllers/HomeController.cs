
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Damacana.Models;

namespace Damacana.Controllers
{
    public class HomeController : Controller
    {
        //List of products in the Memory

        public static List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Erikli 19L",
                Price = (decimal) 4.90
            },
            new Product()
            {
                Id = 2,
                Name = "Pinar 19L",
                Price = (decimal)5.90
            }
        };
        static List<Cart> carts = new List<Cart>();

        Cart cart1 = new Cart()
        {
            Id = 1,
            UserId = 1,
            Products = products
        };
        static List<Purchase> purchases = new List<Purchase>();

        Purchase purchase1 = new Purchase()
        {
            Id = 1,
            UserId = 1,
            TotalPrice = 0,
            Products = products
        };
       

        public ActionResult Index()
        {
            purchases.Add(purchase1);
           // products.Add(product);
            carts.Add(cart1);
            return View(products); 
            
        }
        public ActionResult ProductList()
        {
            return View(products);
        }
        public ActionResult AddProduct()
        {
            //create an empty product
            Product product = new Product();
            //products.Add(product);
            return View(product);

        }

        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {

            products.Add(product);
            return View(product);
        }

        public ActionResult CartList()
        {
            return View(carts);
        }
        public ActionResult AddCart()
        {
            //create an empty cart
            Cart cart = new Cart();

            return View(cart);

        }
        [HttpPost]
        public ActionResult SaveCart(Cart cart)
        {

            carts.Add(cart);
            return View(cart);
        }
        public ActionResult EditCart(int id)
        {
            //   products.Add(product);
            ViewBag.Message = "Your application description page.";
            Cart cart = new Cart();

            foreach (var find in carts)
            {

                if (find.Id == id)
                {


                    cart.UserId = find.UserId;

                    cart.Id = find.Id;


                    carts.Remove(find);
                    break;
                }

            }
            return View(cart);
        }
        [HttpGet]
        public ActionResult DeleteCart(int id)
        {
            ViewBag.Message = "Your application description page.";
            foreach (var find in carts)
            {

                if (find.Id == id)
                {
                    carts.Remove(find);
                    break;
                }

            }
            return View(carts);
        }
        public ActionResult AddtoCart(string name)
        {
            //   products.Add(product);
            ViewBag.Message = "Your application description page.";
            Product product = new Product();

            foreach (var find in products)
            {

                if (find.Name == name)
                {


                    product.Name = find.Name;
                    product.Price = find.Price;
                    product.Id = find.Id;
                    product.CartId = 1;

                    products.Remove(find);
                    break;
                }

            }
            return View(product);
        }


        [HttpGet]
        public ActionResult DeleteProductfromCart(string name)
        {
            ViewBag.Message = "Your application description page.";
            foreach (var find in products)
            {

                if (find.Name == name)
                {
                    find.CartId = 0;
                    break;
                }

            }
            return View(products);
        }

        public ActionResult ProductListofEachCart(int id)
        {
            List<Product> productsofeachcart = new List<Product>();
            Product product = new Product();
            foreach (var find in products)
            {

                if (find.CartId == id)
                {


                    product.Name = find.Name;
                    product.Price = find.Price;
                    product.Id = find.Id;


                    productsofeachcart.Add(product);

                }

            }
            return View(productsofeachcart);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult EditProduct(string name)
        {
            //   products.Add(product);
            ViewBag.Message = "Your application description page.";
            Product product = new Product();

            foreach (var find in products)
            {

                if (find.Name == name)
                {


                    product.Name = find.Name;
                    product.Price = find.Price;
                    product.Id = find.Id;


                    products.Remove(find);
                    break;
                }

            }
            return View(product);
        }
        [HttpGet]
        public ActionResult DeleteProduct(string name)
        {
            ViewBag.Message = "Your application description page.";
            foreach (var find in products)
            {

                if (find.Name == name)
                {
                    products.Remove(find);
                    break;
                }

            }
            return View(products);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PurchaseList()
        {
            return View(purchases);
        }

        public ActionResult AddPurchase(int id)
        {
            //create an empty cart
            Purchase purchase = new Purchase();
            ViewBag.Message = "Your application description page.";
            decimal k = 0;

            foreach (var find in products)
            {

                if (find.CartId == id)
                {

                    k = k + find.Price;

                }

            }
            purchase.TotalPrice = k;
            return View(purchase);



        }
        [HttpPost]
        public ActionResult SavePurchase(Purchase purchase)
        {

            purchases.Add(purchase);
            return View(purchase);
        }

    }
}