﻿using MonthlyProjectCodeFirst.DAL;
using MonthlyProjectCodeFirst.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MonthlyProjectCodeFirst.Controllers
{
    [Authorize]
   //[Authorize]
    public class StudentTBController : Controller
    {
        DBContext db = new DBContext();
        // GET: StudentTB
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Student e)
        {
            if (ModelState.IsValid == true)
            {
                string fileName = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                string extension = Path.GetExtension(e.ImageFile.FileName);
                HttpPostedFileBase postedFile = e.ImageFile;
                int length = postedFile.ContentLength;

                if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                {
                    if (length <= 1000000)
                    {
                        fileName = fileName + extension;
                        e.image_path = "~/Photo/" + fileName;
                        fileName = Path.Combine(Server.MapPath("~/Photo/"), fileName);
                        e.ImageFile.SaveAs(fileName);
                        db.Students.Add(e);
                        int a = db.SaveChanges();
                        if (a > 0)
                        {
                            TempData["CreateMessage"] = "<script>alert('Data Inserted Successfully')</script>";
                            ModelState.Clear();
                            return RedirectToAction("Index", "StudentTB");

                        }
                        else
                        {
                            TempData["CreateMessage"] = "<script>alert('Data Not Inserted ')</script>";
                        }
                    }
                    else
                    {
                        TempData["SizeMessage"] = "<script>alert('Image Size should be less than 1 MB')</script>";

                    }
                }
                else
                {
                    TempData["ExtensionMessage"] = "<script>alert('Format Not Supported')</script>";
                }

            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            var EmployeeRow = db.Students.Where(model => model.Studentid == id).FirstOrDefault();
            Session["Image"] = EmployeeRow.image_path;

            return View(EmployeeRow);
        }

        [HttpPost]
        public ActionResult Edit(Student e)
        {
            if (ModelState.IsValid == true)
            {
                if (e.ImageFile != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(e.ImageFile.FileName);
                    string extension = Path.GetExtension(e.ImageFile.FileName);
                    HttpPostedFileBase postedFile = e.ImageFile;
                    int length = postedFile.ContentLength;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (length <= 1000000)
                        {
                            fileName = fileName + extension;
                            e.image_path = "~/Photo/" + fileName;
                            fileName = Path.Combine(Server.MapPath("~/Photo/"), fileName);
                            e.ImageFile.SaveAs(fileName);
                            db.Entry(e).State = EntityState.Modified;
                            int a = db.SaveChanges();
                            if (a > 0)
                            {
                                string ImagePath = Request.MapPath(Session["Image"].ToString());
                                if (System.IO.File.Exists(ImagePath))
                                {
                                    System.IO.File.Delete(ImagePath);

                                }
                                TempData["UpdatedMessage"] = "<script>alert('Data Updated Successfully')</script>";
                                ModelState.Clear();
                                return RedirectToAction("Index", "StudentTB");

                            }
                            else
                            {
                                TempData["UpdatedMessage"] = "<script>alert('Data Not Updated ')</script>";
                            }
                        }
                        else
                        {
                            TempData["SizeMessage"] = "<script>alert('Image Size should be less than 1 MB')</script>";

                        }
                    }
                    else
                    {
                        TempData["ExtensionMessage"] = "<script>alert('Format Not Supported')</script>";
                    }
                }
                else
                {
                    e.image_path = Session["Image"].ToString();
                    db.Entry(e).State = EntityState.Modified;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["UpdatedMessage"] = "<script>alert('Data Updated Successfully')</script>";
                        ModelState.Clear();
                        return RedirectToAction("Index", "StudentTB");

                    }
                    else
                    {
                        TempData["UpdatedMessage"] = "<script>alert('Data Not Updated ')</script>";
                    }
                }
            }

            return View();
        }


        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var EmployeeRow = db.Students.Where(model => model.Studentid == id).FirstOrDefault();
                if (EmployeeRow != null)
                {
                    db.Entry(EmployeeRow).State = EntityState.Deleted;
                    int a = db.SaveChanges();
                    if (a > 0)
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Deleted Successfully')</script>";
                        string ImagePath = Request.MapPath(EmployeeRow.image_path.ToString());
                        if (System.IO.File.Exists(ImagePath))
                        {
                            System.IO.File.Delete(ImagePath);

                        }

                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data not Deleted')</script>";

                    }
                }
            }

            return RedirectToAction("Index", "StudentTB");
        }


        public ActionResult Details(int id)
        {
            var EmployeeRow = db.Students.Where(model => model.Studentid == id).FirstOrDefault();
            Session["Image2"] = EmployeeRow.image_path.ToString();

            return View(EmployeeRow);
        }
    }
}