using MonthlyProjectCodeFirst.DAL;
using MonthlyProjectCodeFirst.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyProjectCodeFirst.Controllers
{
    public class MyLoginController : Controller
    {
        private DBContext db = new DBContext();
        // GET: MyLogin
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Index(PasswordLog1 u)
        //{
        //    var user = db.PasswordLog1.Where(model => model.Username == u.Username && model.Passsword == u.Passsword).FirstOrDefault();
        //    if (user != null)
        //    {
        //        Session["UserId"] = u.Id.ToString();
        //        Session["Username"] = u.Username.ToString();
        //        TempData["LoginSuccessMessage"] = "<script>alert('Login  Successfull !!')</script>";
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.ErrorMessage = "<script>alert('User Name and Password Incorrect !!')</script>";
        //        return View();
        //    }
            
        //}

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(PasswordLog1 u)
        {
            if (ModelState.IsValid == true)
            {
                db.PasswordLog1.Add(u);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully !!')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registeration Failed')</script>";
                }
            }
            return View();
        }
    }
}