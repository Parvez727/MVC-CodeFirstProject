using MonthlyProjectCodeFirst.DAL;
using MonthlyProjectCodeFirst.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyProjectCodeFirst.Controllers
{
    public class MasterDetailsController : Controller
    {
        private DBContext db = new DBContext();
        List<details> sdt = new List<details>();
        List<master> mst = new List<master>();

        public ActionResult Index()
        {
            int t = 0;
            Session["sdt"] = TempData["sdt"];

            ViewBag.records = Session["sdt"];
            if (ViewBag.records != null)
            {
                foreach (var k in ViewBag.records)
                {
                    t += k.totalprice;
                }
            }
            ViewBag.t = t;
            TempData["sdt"] = Session["sdt"];
            ViewBag.sid = GenerateCode();
            string dt = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            ViewBag.date = dt;
            return View();
        }
        public List<details> AllDetails()
        {
            ViewBag.sid = GenerateCode();
            return db.details.ToList();
        }
        [HttpAction1]
        [HttpPost]
        public ActionResult AddDetails(details d, master m)
        {
            // int sl = (from d1 in sdt select d1).DefaultIfEmpty().Max(x=>x.slno);
            sdt = TempData["sdt"] as List<details>;
            int sl = 0;
            if (sdt != null)
                sl = sdt.Select(f => f.slno).DefaultIfEmpty(0).Max();
            else
                sdt = new List<details>();
            sl++;
            sdt.Add(new details() { salesid = d.salesid, slno = sl, itemcode = d.itemcode, itemname = d.itemname, qty = d.qty, unitprice = d.unitprice, totalprice = d.qty * d.unitprice });
            TempData["sdt"] = sdt;
            //return Json("OK", JsonRequestBehavior.AllowGet);
            ViewBag.sid = GenerateCode();
            return RedirectToAction("Index");
        }

        [HttpAction1]
        [HttpPost]
        public ActionResult Save(master m2)
        {
            ViewBag.sid = GenerateCode();
            master m = new master() { date = DateTime.Parse("2021-12-13"), salesid = m2.salesid, party = m2.party, total = m2.total, discount = m2.discount, gross = m2.gross, paid = 0, due = 0 };
            db.master.Add(m);
            db.SaveChanges();
            sdt = TempData["sdt"] as List<details>;
            foreach (details a in sdt)
            {
                db.details.Add(a);
                db.SaveChanges();
            }

            TempData["sdt"] = "";
            return RedirectToAction("list");
        }
        public JsonResult GetDetails()
        {
            sdt = TempData["sdt"] as List<details>;
            TempData["sdt"] = sdt;
            return Json(sdt, JsonRequestBehavior.AllowGet);
        }
        public string GenerateCode()
        {
            string a1 = "";
            string b1 = "";

            try
            {
                var a = (from det in db.details select det.salesid.Substring(3)).Max();
                int b = int.Parse(a.ToString()) + 1;
                if (b < 10)
                {
                    b1 = "000" + b.ToString();
                }
                else if (b < 100)
                {
                    b1 = "00" + b.ToString();
                }
                else if (b < 1000)
                {
                    b1 = "0" + b.ToString();
                }
                else
                {
                    b1 = b.ToString();
                }
                a1 = "AC-" + b1.ToString();
            }
            catch (Exception ex)
            {
                a1 = "AC-0001";
            }
            return a1;
        }


        public ActionResult Edit(string salesid, string mode)
        {
            int t = 0;
            if (mode == null)
                Session["sdt"] = (from d in db.details where d.salesid == salesid select d).ToList();
            else
                Session["sdt"] = TempData["sdt"];
            ViewBag.records = Session["sdt"];
            if (ViewBag.records != null)
            {
                foreach (var k in ViewBag.records)
                {
                    t += k.totalprice;
                }
            }
            ViewBag.t = t;
            TempData["sdt"] = Session["sdt"];
            ViewBag.sid = GenerateCode();
            string dt = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
            ViewBag.date = dt;
            master m2 = db.master.Find(salesid);
            return View(m2);
        }
        [HttpAction1]
        [HttpPost]
        public ActionResult Update(master m2, string salesid)
        {
            db.Database.ExecuteSqlCommand($"delete details where salesid='{salesid}'");
            db.Database.ExecuteSqlCommand($"delete masters where salesid='{salesid}'");
            db.SaveChanges();
            master m = new master() { date = DateTime.Parse(m2.date.ToString()), salesid = m2.salesid, party = m2.party, total = m2.total, discount = m2.discount, gross = m2.gross, paid = 0, due = 0 };
            db.master.Add(m);
            db.SaveChanges();
            sdt = TempData["sdt"] as List<details>;
            foreach (details a in sdt)
            {
                //db.details.Add(a);
                db.Database.ExecuteSqlCommand($"insert into details values ('{a.salesid}',{a.slno},'{a.itemcode}','{a.itemname}',{a.qty},{a.unitprice},{a.totalprice})");
                db.SaveChanges();
            }

            TempData["sdt"] = "";
            return RedirectToAction("list");
        }
        [HttpAction1]
        [HttpPost]
        public ActionResult EditDetails(details d, master m, string salesid, string mode)
        {
            // int sl = (from d1 in sdt select d1).DefaultIfEmpty().Max(x=>x.slno);
            sdt = TempData["sdt"] as List<details>;
            int sl = 0;
            if (sdt != null)
                sl = sdt.Select(f => f.slno).DefaultIfEmpty(0).Max();
            else
                sdt = new List<details>();
            sl++;
            sdt.Add(new details() { salesid = d.salesid, slno = sl, itemcode = d.itemcode, itemname = d.itemname, qty = d.qty, unitprice = d.unitprice, totalprice = d.qty * d.unitprice });
            TempData["sdt"] = sdt;
            //return Json("OK", JsonRequestBehavior.AllowGet);
            //ViewBag.sid = GenerateCode();
            return RedirectToAction("edit", new { salesid = salesid, mode = "edit" });
        }
        [HttpAction1]
        [HttpPost]
        public ActionResult Delete(string salesid)
        {
            db.Database.ExecuteSqlCommand($"delete details where salesid='{salesid}'");
            db.Database.ExecuteSqlCommand($"delete masters where salesid='{salesid}'");
            db.SaveChanges();
            return RedirectToAction("list");
        }
        public ActionResult List()
        {
            TempData["sdt"] = "";
            var a = db.master.ToList();
            return View(a);
        }
    }



}
