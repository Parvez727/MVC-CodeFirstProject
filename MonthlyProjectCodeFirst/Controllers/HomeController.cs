using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyProjectCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Title = "Home Page";

            //if (Session["UserId"] == null)
            //{
            //    return RedirectToAction("Index", "MyLogin");
            //}
            //else
            //{
            //    return View();
            //}
            return View();

        }

        //public ActionResult Logout()
        //{
        //    Session.Abandon();
        //    return RedirectToAction("Index", "MyLogin");
        //}
    }
}
