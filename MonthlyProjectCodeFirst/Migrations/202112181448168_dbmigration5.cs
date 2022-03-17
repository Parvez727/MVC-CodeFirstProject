namespace MonthlyProjectCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmigration5 : DbMigration
    {
        public override void Up()
        {
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

            //DropTable("dbo.PasswordLogs");
        }
        
        public override void Down()
        {
           
            
            DropTable("dbo.PasswordLogs");
        }
    }
}
