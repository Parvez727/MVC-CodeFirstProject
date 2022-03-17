using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MonthlyProjectCodeFirst.DAL;


namespace MonthlyProjectCodeFirst.Data
{
    public class DBContext : DbContext
    {
        public DBContext() : base("name=Model1")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }


        public DbSet<products> products { get; set; }
        public DbSet<details> details { get; set; }
        public DbSet<master> master { get; set; }


        public virtual DbSet<student2> student2 { get; set; }


        public virtual DbSet<Product2> Product2 { get; set; }
        public virtual DbSet<Sale2> Sales { get; set; }

        //public virtual DbSet<Product_Sales> Product_Sales { get; set; }

        //public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<PasswordLog> PasswordLogs { get; set; }

        public virtual DbSet<PasswordLog1> PasswordLog1 { get; set; }

    }
}