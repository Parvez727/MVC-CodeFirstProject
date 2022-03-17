namespace MonthlyProjectCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbmigration2 : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => new { t.salesid, t.slno })
                .ForeignKey("dbo.masters", t => t.salesid, cascadeDelete: true)
                .ForeignKey("dbo.products", t => t.itemcode)
                .Index(t => t.salesid)
                .Index(t => t.itemcode);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.details", "itemcode", "dbo.products");
            DropForeignKey("dbo.details", "salesid", "dbo.masters");
            DropIndex("dbo.details", new[] { "itemcode" });
            DropIndex("dbo.details", new[] { "salesid" });
            DropTable("dbo.products");
            DropTable("dbo.masters");
            DropTable("dbo.details");
        }
    }
}
