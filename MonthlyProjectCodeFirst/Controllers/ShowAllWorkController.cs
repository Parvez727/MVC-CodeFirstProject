using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyProjectCodeFirst.Controllers
{
    public class ShowAllWorkController : Controller
    {
        // GET: ShowAllWork
        public ActionResult Index()
        {
            return View();
        }
    }
}