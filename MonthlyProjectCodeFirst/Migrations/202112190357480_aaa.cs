namespace MonthlyProjectCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PasswordLog1", "Firstname", c => c.String(nullable: false));
            AlterColumn("dbo.PasswordLog1", "Lastname", c => c.String(nullable: false));
            AlterColumn("dbo.PasswordLog1", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.PasswordLog1", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.PasswordLog1", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.PasswordLog1", "Passsword", c => c.String(nullable: false));
            AlterColumn("dbo.PasswordLog1", "Comfirm_password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PasswordLog1", "Comfirm_password", c => c.String());
            AlterColumn("dbo.PasswordLog1", "Passsword", c => c.String());
            AlterColumn("dbo.PasswordLog1", "Username", c => c.String());
            AlterColumn("dbo.PasswordLog1", "Email", c => c.String());
            AlterColumn("dbo.PasswordLog1", "Gender", c => c.String());
            AlterColumn("dbo.PasswordLog1", "Lastname", c => c.String());
            AlterColumn("dbo.PasswordLog1", "Firstname", c => c.String());
        }
    }
}
