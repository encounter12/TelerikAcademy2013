namespace ToysStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgeRanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinimumAge = c.Int(),
                        MaximumAge = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Toys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Type = c.String(maxLength: 20),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        AgeRangeId = c.Int(nullable: false),
                        Color = c.String(),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .ForeignKey("dbo.AgeRanges", t => t.AgeRangeId, cascadeDelete: true)
                .Index(t => t.AgeRangeId)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Country = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryToys",
                c => new
                    {
                        Category_Id = c.Int(nullable: false),
                        Toy_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_Id, t.Toy_Id })
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Toys", t => t.Toy_Id, cascadeDelete: true)
                .Index(t => t.Category_Id)
                .Index(t => t.Toy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Toys", "AgeRangeId", "dbo.AgeRanges");
            DropForeignKey("dbo.Toys", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.CategoryToys", "Toy_Id", "dbo.Toys");
            DropForeignKey("dbo.CategoryToys", "Category_Id", "dbo.Categories");
            DropIndex("dbo.CategoryToys", new[] { "Toy_Id" });
            DropIndex("dbo.CategoryToys", new[] { "Category_Id" });
            DropIndex("dbo.Toys", new[] { "ManufacturerId" });
            DropIndex("dbo.Toys", new[] { "AgeRangeId" });
            DropTable("dbo.CategoryToys");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
            DropTable("dbo.Toys");
            DropTable("dbo.AgeRanges");
        }
    }
}
