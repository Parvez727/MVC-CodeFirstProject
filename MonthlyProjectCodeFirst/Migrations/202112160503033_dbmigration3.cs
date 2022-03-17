namespace MonthlyProjectCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmigration3 : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.student2");
        }
    }
}
