using MonthlyProjectCodeFirst.DAL;
using MonthlyProjectCodeFirst.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyProjectCodeFirst.Controllers
{
    public class TestIndexViewModel
    {
        public List<Student> Test1 { get; set; }
        public List<Department> Test2 { get; set; }
        public List<Teacher> Test3 { get; set; }
        public List<Course> Test4 { get; set; }

        //public List<Product_Sales> Test5 { get; set; }
    }
    public class Renderaction1Controller : Controller
    {
        private DBContext db = new DBContext();
        // GET: Renderaction1
        public ActionResult Index()
        {
            List<Student> a = new List<Student>();
            a = db.Students.ToList();
          //  return PartialView(a);

            List<Course> b = new List<Course>();
            b = db.Courses.ToList();

            List<Department> c = new List<Department>();
            c = db.Departments.ToList();


            List<Teacher> d = new List<Teacher>();
            d = db.Teachers.ToList();
            // return PartialView(b);

            //List<Product_Sales> e = new List<Product_Sales>();
            //e = db.Product_Sales.ToList();

            var model = new TestIndexViewModel
            {
                Test1 = a,
                Test4 = b,
                Test2 = c,
                Test3 = d,
            };


            return View(model);
        }


    }
}