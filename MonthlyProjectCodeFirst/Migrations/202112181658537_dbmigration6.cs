namespace MonthlyProjectCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmigration6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PasswordLog1",
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PasswordLog1");
        }
    }
}
