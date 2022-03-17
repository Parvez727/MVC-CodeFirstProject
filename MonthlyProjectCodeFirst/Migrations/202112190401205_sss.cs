namespace MonthlyProjectCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "studentid", "dbo.Students");
            DropForeignKey("dbo.Teachers", "departmentid", "dbo.Departments");
            DropForeignKey("dbo.Courses", "teacherid", "dbo.Teachers");
            DropForeignKey("dbo.details", "salesid", "dbo.masters");
            DropForeignKey("dbo.details", "itemcode", "dbo.products");
            DropForeignKey("dbo.Sale2", "product_id", "dbo.Product2");
            DropIndex("dbo.Courses", new[] { "studentid" });
            DropIndex("dbo.Courses", new[] { "teacherid" });
            DropIndex("dbo.Teachers", new[] { "departmentid" });
            DropIndex("dbo.details", new[] { "salesid" });
            DropIndex("dbo.details", new[] { "itemcode" });
            DropIndex("dbo.Sale2", new[] { "product_id" });
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            DropTable("dbo.Courses");
            DropTable("dbo.Students");
            DropTable("dbo.Teachers");
            DropTable("dbo.Departments");
            DropTable("dbo.details");
            DropTable("dbo.masters");
            DropTable("dbo.products");
            DropTable("dbo.PasswordLog1");
          //  DropTable("dbo.PasswordLogs");
            DropTable("dbo.Product2");
            DropTable("dbo.Sale2");
            DropTable("dbo.student2");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.student2",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        _class = c.String(name: "class"),
                        fee = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sale2",
                c => new
                    {
                        sale_id = c.String(nullable: false, maxLength: 128),
                        product_id = c.String(maxLength: 128),
                        Qty = c.Int(),
                        sales_price = c.Int(),
                        Total_price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.sale_id);
            
            CreateTable(
                "dbo.Product2",
                c => new
                    {
                        product_id = c.String(nullable: false, maxLength: 128),
                        product_name = c.String(),
                        purchase_price = c.Int(),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "dbo.PasswordLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Gender = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        Username = c.String(),
                        Passsword = c.String(),
                        Comfirm_password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PasswordLog1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Passsword = c.String(nullable: false),
                        Comfirm_password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        itemcode = c.String(nullable: false, maxLength: 128),
                        itemname = c.String(),
                        gname = c.String(),
                        cost = c.Decimal(precision: 18, scale: 2),
                        sell = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.itemcode);
            
            CreateTable(
                "dbo.masters",
                c => new
                    {
                        salesid = c.String(nullable: false, maxLength: 128),
                        date = c.DateTime(),
                        party = c.String(),
                        total = c.Decimal(precision: 18, scale: 2),
                        discount = c.Decimal(precision: 18, scale: 2),
                        gross = c.Decimal(precision: 18, scale: 2),
                        paid = c.Decimal(precision: 18, scale: 2),
                        due = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.salesid);
            
            CreateTable(
                "dbo.details",
                c => new
                    {
                        salesid = c.String(nullable: false, maxLength: 128),
                        slno = c.Int(nullable: false),
                        itemcode = c.String(maxLength: 128),
                        itemname = c.String(),
                        qty = c.Int(),
                        unitprice = c.Decimal(precision: 18, scale: 2),
                        totalprice = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.salesid, t.slno });
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Departmentid = c.Int(nullable: false, identity: true),
                        departmentname = c.String(nullable: false),
                        departmentLocation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Departmentid);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Teacherid = c.Int(nullable: false, identity: true),
                        teachername = c.String(nullable: false),
                        departmentid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Teacherid);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Studentid = c.Int(nullable: false, identity: true),
                        studentname = c.String(nullable: false),
                        _class = c.String(name: "class", nullable: false, maxLength: 40),
                        gender = c.String(nullable: false, maxLength: 50),
                        date = c.DateTime(nullable: false),
                        image_path = c.String(),
                    })
                .PrimaryKey(t => t.Studentid);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Courseid = c.Int(nullable: false, identity: true),
                        coursename = c.String(nullable: false),
                        studentid = c.Int(nullable: false),
                        teacherid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Courseid);
            
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            CreateIndex("dbo.Sale2", "product_id");
            CreateIndex("dbo.details", "itemcode");
            CreateIndex("dbo.details", "salesid");
            CreateIndex("dbo.Teachers", "departmentid");
            CreateIndex("dbo.Courses", "teacherid");
            CreateIndex("dbo.Courses", "studentid");
            AddForeignKey("dbo.Sale2", "product_id", "dbo.Product2", "product_id");
            AddForeignKey("dbo.details", "itemcode", "dbo.products", "itemcode");
            AddForeignKey("dbo.details", "salesid", "dbo.masters", "salesid", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "teacherid", "dbo.Teachers", "Teacherid", cascadeDelete: true);
            AddForeignKey("dbo.Teachers", "departmentid", "dbo.Departments", "Departmentid", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "studentid", "dbo.Students", "Studentid", cascadeDelete: true);
        }
    }
}
