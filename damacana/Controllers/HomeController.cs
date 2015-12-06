using Damacana.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Damacana.Controllers
{
    public class HomeController : Controller
    {
        
        public static List<Product>products = new List<Product>()
        {

            new Product
            {
                id = 1,
                name = "Pinar 19L",
                price = (decimal) 10.0
            },
            new Product
            {
                id = 2,
                name = "Erikli 19L",
                price = (decimal) 12.5
            },
            new Product
            {
                id = 3,
                name = "Erikli 5L",
                price = (decimal) 12.5
            }
        };

        public ActionResult Index()
        {
            return View(products);
        }

        public ActionResult NewProduct()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {
            //Save the product
            products.Add(product);
            return View(product);
        }

        public ActionResult ProductDetails(int id)
        {
            if (id < 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // This search will be far less ugly when we'll have a db
            foreach (Product product in HomeController.products)
                if (product.id == id)
                    return View(product);

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // GET
        public ActionResult EditProduct(int id)
        {
            if (id < 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            // This search will be far less ugly when we'll have a db
            foreach (Product product in HomeController.products)
                if (product.id == id)
                    return View(product);

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        // POST
        [HttpPost]
        public ActionResult SaveModifiedProduct(Product product)
        {
            // This search will be far less ugly when we'll have a db
            foreach (Product p in HomeController.products)
                if (p.id == product.id)
                {
                    p.name = product.name;
                    p.price = product.price;
                    return View("SaveProduct", p);
                }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}