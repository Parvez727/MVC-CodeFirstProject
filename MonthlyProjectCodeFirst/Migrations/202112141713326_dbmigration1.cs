namespace MonthlyProjectCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmigration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Courseid = c.Int(nullable: false, identity: true),
                        coursename = c.String(nullable: false),
                        studentid = c.Int(nullable: false),
                        teacherid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Courseid)
                .ForeignKey("dbo.Students", t => t.studentid, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.teacherid, cascadeDelete: true)
                .Index(t => t.studentid)
                .Index(t => t.teacherid);
            
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
                "dbo.Teachers",
                c => new
                    {
                        Teacherid = c.Int(nullable: false, identity: true),
                        teachername = c.String(nullable: false),
                        departmentid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Teacherid)
                .ForeignKey("dbo.Departments", t => t.departmentid, cascadeDelete: true)
                .Index(t => t.departmentid);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Departmentid = c.Int(nullable: false, identity: true),
                        departmentname = c.String(nullable: false),
                        departmentLocation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Departmentid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "teacherid", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "departmentid", "dbo.Departments");
            DropForeignKey("dbo.Courses", "studentid", "dbo.Students");
            DropIndex("dbo.Teachers", new[] { "departmentid" });
            DropIndex("dbo.Courses", new[] { "teacherid" });
            DropIndex("dbo.Courses", new[] { "studentid" });
            DropTable("dbo.Departments");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
        }
    }
}
