using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using damacana.Models;

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


        public ActionResult Index()
        {
            //Send product to the View Engine
            return View(products);
        }
        public ActionResult Cart()
        {
            
            return View(products);
        }
        public ActionResult siparisitamamla()
        {

            return View(products);
        }

         



        public ActionResult AddProduct()
        {
            //Create an Empty Product
            Product product = new Product()
            {
                Name = "",
                Price = (decimal)0
            };

            //Pass it to the View
            return View(product);
        }


        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {

            //Save to the list in Memory
            products.Add(product);

            return View(product);
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