using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MonthlyProjectCodeFirst.DAL;
using MonthlyProjectCodeFirst.Data;

namespace MonthlyProjectCodeFirst.Controllers
{
    public class productsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: products
        public ActionResult Index()
        {
            return View(db.products.ToList());
        }

        //AngularJs Pratice in Mid Monthly examination

        public JsonResult JsonIndex()
        {
            return Json(db.products,JsonRequestBehavior.AllowGet);
        }

        public ActionResult client()
        {
            return View();
        }

        // GET: products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "itemcode,itemname,gname,cost,sell")] products products)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        // GET: products/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemcode,itemname,gname,cost,sell")] products products)
        {
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products products = db.products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            products products = db.products.Find(id);
            db.products.Remove(products);
            db.SaveChanges();
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

        public JsonResult GetItem(string id)
        {
            var student = (from p in db.products where p.itemcode == id select new { p.itemname, p.gname, p.sell }).FirstOrDefault();
            return Json(student, JsonRequestBehavior.AllowGet);
        }

    }
}
