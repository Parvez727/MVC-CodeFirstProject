namespace MonthlyProjectCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmigration4 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Sale2",
                c => new
                    {
                        sale_id = c.String(nullable: false, maxLength: 128),
                        product_id = c.String(maxLength: 128),
                        Qty = c.Int(),
                        sales_price = c.Int(),
                        Total_price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.sale_id)
                .ForeignKey("dbo.Product2", t => t.product_id)
                .Index(t => t.product_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sale2", "product_id", "dbo.Product2");
            DropIndex("dbo.Sale2", new[] { "product_id" });
            DropTable("dbo.Sale2");
            DropTable("dbo.Product2");
        }
    }
}
