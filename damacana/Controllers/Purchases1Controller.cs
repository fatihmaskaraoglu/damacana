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
        private PurchaseDBContext db = new PurchaseDBContext();

        public static List<Product> CartProduct = Damacana.Controllers.ProductsController.CartProducts;
        public ActionResult PurchaseDone()
        {
            Purchase purchase = new Purchase();
            int i = 1;
            purchase.Id = i;
            purchase.UserId = 1;
            purchase.CreatedOn = DateTime.Now;
          decimal totalprice = 0;
            purchase.PurchaseList = CartProduct;
            foreach (Product p in CartProduct)
            {
                
                totalprice = p.Price + totalprice;
            }
            purchase.TotalPrice = totalprice;

           
            db.Purchases.Add(purchase);
          
            i++;
            
           // db.SaveChanges();
            return View(purchase);
        }
     
        public ActionResult PurchaseHistory()
        {
            
            db.SaveChanges();
            return View(db.Purchases.ToList());

        }

        // GET: Purchases1
        public async Task<ActionResult> Index()
        {
            var purchases = db.Purchases.Include(p => p.User);
            return View(await purchases.ToListAsync());
        }

        // GET: Purchases1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchases1/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: Purchases1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,CreatedOn,TotalPrice")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Purchases.Add(purchase);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", purchase.UserId);
            return View(purchase);
        }

        // GET: Purchases1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", purchase.UserId);
            return View(purchase);
        }

        // POST: Purchases1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,CreatedOn,TotalPrice")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", purchase.UserId);
            return View(purchase);
        }

        // GET: Purchases1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchases1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Purchase purchase = await db.Purchases.FindAsync(id);
            db.Purchases.Remove(purchase);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
