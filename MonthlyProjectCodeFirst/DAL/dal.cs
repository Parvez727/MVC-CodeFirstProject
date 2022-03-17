using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MonthlyProjectCodeFirst.DAL
{
    //4 CRUD Table with image in one to many relationship

    public partial class Student
    {
      
        public int Studentid { get; set; }

        [Required(ErrorMessage = "Please enter Your Student Name")]
        [Display(Name = "Student Name")]
        public string studentname { get; set; }

        [Required(ErrorMessage = "Please enter Class")]
        [StringLength(40)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "Class")]
        public string @class { get; set; }

        [Required(ErrorMessage = "Please enter Your Gender")]
        [Display(Name = "Gender")]
        [MaxLength(50)]
        public string gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime date { get; set; }

        [Display(Name = "Student Image")]
        public string image_path { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }

    public partial class Department
    {

        public int Departmentid { get; set; }

        [Required(ErrorMessage = "Please enter Your Department Name")]
        [Display(Name = "Department Name")]
        public string departmentname { get; set; }

        [Required(ErrorMessage = "Please enter Your Department Location")]
        [Display(Name = "Department Location")]
        public string departmentLocation { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
    }

    public partial class Teacher
    {
        
        public int Teacherid { get; set; }

        [Required(ErrorMessage = "Please enter Your Teacher Name")]
        [Display(Name = "Teacher Name")]
        public string teachername { get; set; }

        [Required(ErrorMessage = "Please enter Your Department Name")]
        [Display(Name = "Department Name")]
        [ForeignKey("Department")]
        public Nullable<int> departmentid { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual Department Department { get; set; }
    }

    public partial class Course
    {
        public int Courseid { get; set; }

        [Required(ErrorMessage = "Please enter Your Course Name")]
        [Display(Name = "Course Name")]
        public string coursename { get; set; }

        [ForeignKey("Student")]
        [Required(ErrorMessage = "Please enter Your Student Name")]
        [Display(Name = "Student Name")]
        public Nullable<int> studentid { get; set; }

        [ForeignKey("Teacher")]
        [Required(ErrorMessage = "Please enter Your Teacher Name")]
        [Display(Name = "Teacher Name")]
        public Nullable<int> teacherid { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }


    //Master Details tables

    public class products
    {
        [Key]
        public string itemcode { get; set; }
        public string itemname { get; set; }
        public string gname { get; set; }
        public Nullable<decimal> cost { get; set; }
        public Nullable<decimal> sell { get; set; }
        public virtual ICollection<details> detail { get; set; }
    }
    public partial class details
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("master")]
        public string salesid { get; set; }
        [Key]
        [Column(Order = 1)]
        public int slno { get; set; }
        [ForeignKey("product")]
        public string itemcode { get; set; }
        public string itemname { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<decimal> unitprice { get; set; }
        public Nullable<decimal> totalprice { get; set; }
        public virtual products product { get; set; }
        public virtual master master { get; set; }
    }
    public partial class master
    {
        [Key]
        public string salesid { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string party { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<decimal> gross { get; set; }
        public Nullable<decimal> paid { get; set; }
        public Nullable<decimal> due { get; set; }
        public virtual ICollection<details> detail { get; set; }
    }


    //Ajax table

    public partial class student2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string @class { get; set; }
        public Nullable<decimal> fee { get; set; }
       
    }


    //Two table CRUD at a time

    public partial class Product2
    {
        [Key]
        public string product_id { get; set; }
        public string product_name { get; set; }
        public Nullable<int> purchase_price { get; set; }

        public virtual ICollection<Sale2> Sales { get; set; }
    }

    public partial class Sale2
    {
        [Key]
        public string sale_id { get; set; }
        [ForeignKey("Product")]
        public string product_id { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<int> sales_price { get; set; }
        public Nullable<decimal> Total_price { get; set; }

        public virtual Product2 Product { get; set; }
    }

    public class Product_Sales
    {
        public string product_id { get; set; }
        public string product_name { get; set; }
        public Nullable<int> purchase_price { get; set; }
        public string sale_id { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<int> sales_price { get; set; }
        public Nullable<decimal> Total_price { get; set; }

    }

    //public class User
    //{
    //    public int id { get; set; }
    //    public string firstname { get; set; }
    //    public string lastname { get; set; }
    //    public string gender { get; set; }
    //    public int age { get; set; }
    //    public string email { get; set; }
    //    public string username { get; set; }
    //    public string passsword { get; set; }

    //    public string comfirm_password { get; set; }
    //}

    public class PasswordLog
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Passsword { get; set; }

        public string Comfirm_password { get; set; }

    }

    public class PasswordLog1
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("FirstName")]
        [Required(ErrorMessage = "First Name is a required field")]
        public string Firstname { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is a required field")]
        public string Lastname { get; set; }
        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is a required field")]
        public string Gender { get; set; }
        [DisplayName("Age")]
        [Required(ErrorMessage = "Age is a required field")]
        public int Age { get; set; }
        [DisplayName("Email Address")]
        //[RegularExpression("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z\\.)+[a-zA-Z]{2,9})$", ErrorMessage ="Invalid Email")]
        [Required(ErrorMessage = "Email address is a required field")]
        public string Email { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name is a required field")]
        public string Username { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is a required field")]
        [DataType(DataType.Password)]
        public string Passsword { get; set; }
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Passsword",ErrorMessage ="Password is not identical")]
        [Required(ErrorMessage = "Confirm Password is a required field")]
        public string Comfirm_password { get; set; }

    }
}