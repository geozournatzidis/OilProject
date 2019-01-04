namespace GroupProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bottling",
                c => new
                    {
                        BottlingID = c.Int(nullable: false, identity: true),
                        BottlingDate = c.DateTime(nullable: false),
                        ProductCode = c.String(),
                        BottlingLotNumber = c.Int(nullable: false),
                        tank = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        FactoryID = c.Int(),
                        PackageType_ID = c.Int(),
                        ProductType_ID = c.Int(),
                    })
                .PrimaryKey(t => t.BottlingID)
                .ForeignKey("dbo.Factory", t => t.FactoryID)
                .ForeignKey("dbo.Package", t => t.PackageType_ID)
                .ForeignKey("dbo.Product", t => t.ProductType_ID)
                .Index(t => t.FactoryID)
                .Index(t => t.PackageType_ID)
                .Index(t => t.ProductType_ID);
            
            CreateTable(
                "dbo.Factory",
                c => new
                    {
                        FactoryID = c.Int(nullable: false, identity: true),
                        FactoryName = c.String(),
                        FactoryAdress = c.String(),
                        FactoryPhoneNumber = c.String(),
                        Owner = c.String(),
                    })
                .PrimaryKey(t => t.FactoryID);
            
            CreateTable(
                "dbo.OilPress",
                c => new
                    {
                        OilPressID = c.Int(nullable: false, identity: true),
                        OilPressName = c.String(),
                        OliveType = c.String(),
                        OlivesWeight = c.Double(nullable: false),
                        OilOutput = c.Double(nullable: false),
                        ProductionDate = c.DateTime(nullable: false),
                        FactoryID = c.Int(),
                        UserId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        RawMaterialStock_ID = c.Int(),
                    })
                .PrimaryKey(t => t.OilPressID)
                .ForeignKey("dbo.Factory", t => t.FactoryID)
                .ForeignKey("dbo.RawMaterialStock", t => t.RawMaterialStock_ID)
                .ForeignKey("dbo.UsersAccount", t => t.UserId)
                .Index(t => t.FactoryID)
                .Index(t => t.UserId)
                .Index(t => t.RawMaterialStock_ID);
            
            CreateTable(
                "dbo.RawMaterialStock",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        RawMaterialID = c.Int(nullable: false),
                        SectorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RawMaterial", t => t.RawMaterialID, cascadeDelete: true)
                .ForeignKey("dbo.Sector", t => t.SectorID, cascadeDelete: true)
                .Index(t => t.RawMaterialID, unique: true)
                .Index(t => t.SectorID);
            
            CreateTable(
                "dbo.RawMaterial",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Oil",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RawMaterialID = c.Int(nullable: false),
                        OilCategoryID = c.Int(nullable: false),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Category", t => t.Category_CategoryID)
                .ForeignKey("dbo.RawMaterial", t => t.RawMaterialID, cascadeDelete: true)
                .Index(t => t.RawMaterialID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Thumbnail = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Featured = c.Boolean(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Thumbnail = c.String(nullable: false),
                        BarCode = c.String(nullable: false),
                        ProductNumber = c.String(),
                        PackageID = c.Int(),
                        OilID = c.Int(nullable: false),
                        Category_CategoryID = c.Int(),
                        Shop_ShopID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Oil", t => t.OilID, cascadeDelete: true)
                .ForeignKey("dbo.Package", t => t.PackageID)
                .ForeignKey("dbo.Category", t => t.Category_CategoryID)
                .ForeignKey("dbo.Shop", t => t.Shop_ShopID)
                .Index(t => t.PackageID)
                .Index(t => t.OilID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.Shop_ShopID);
            
            CreateTable(
                "dbo.Lot",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductionDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Product", t => t.ProductID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Material = c.Int(nullable: false),
                        Size = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        Length = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sector",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StoredType = c.String(),
                        WarehouseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Warehouse", t => t.WarehouseID, cascadeDelete: true)
                .Index(t => t.WarehouseID);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UsersAccount",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.PackageStock",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        PackageID = c.Int(nullable: false),
                        SectorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Package", t => t.PackageID, cascadeDelete: true)
                .ForeignKey("dbo.Sector", t => t.SectorID, cascadeDelete: true)
                .Index(t => t.PackageID, unique: true)
                .Index(t => t.SectorID);
            
            CreateTable(
                "dbo.Shop",
                c => new
                    {
                        ShopID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Country = c.String(nullable: false, maxLength: 25),
                        City = c.String(nullable: false, maxLength: 25),
                        Address = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false),
                        PostalCode = c.Int(nullable: false),
                        Email = c.String(nullable: false),
                        ShopStockAvailable = c.Int(nullable: false),
                        ExpiredProduct = c.Int(nullable: false),
                        SoldProduct = c.Int(nullable: false),
                        ProductStockID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShopID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "Shop_ShopID", "dbo.Shop");
            DropForeignKey("dbo.PackageStock", "SectorID", "dbo.Sector");
            DropForeignKey("dbo.PackageStock", "PackageID", "dbo.Package");
            DropForeignKey("dbo.Bottling", "ProductType_ID", "dbo.Product");
            DropForeignKey("dbo.Bottling", "PackageType_ID", "dbo.Package");
            DropForeignKey("dbo.OilPress", "UserId", "dbo.UsersAccount");
            DropForeignKey("dbo.RawMaterialStock", "SectorID", "dbo.Sector");
            DropForeignKey("dbo.Sector", "WarehouseID", "dbo.Warehouse");
            DropForeignKey("dbo.RawMaterialStock", "RawMaterialID", "dbo.RawMaterial");
            DropForeignKey("dbo.Oil", "RawMaterialID", "dbo.RawMaterial");
            DropForeignKey("dbo.Oil", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.Product", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.Product", "PackageID", "dbo.Package");
            DropForeignKey("dbo.Product", "OilID", "dbo.Oil");
            DropForeignKey("dbo.Lot", "ProductID", "dbo.Product");
            DropForeignKey("dbo.OilPress", "RawMaterialStock_ID", "dbo.RawMaterialStock");
            DropForeignKey("dbo.OilPress", "FactoryID", "dbo.Factory");
            DropForeignKey("dbo.Bottling", "FactoryID", "dbo.Factory");
            DropIndex("dbo.PackageStock", new[] { "SectorID" });
            DropIndex("dbo.PackageStock", new[] { "PackageID" });
            DropIndex("dbo.Sector", new[] { "WarehouseID" });
            DropIndex("dbo.Lot", new[] { "ProductID" });
            DropIndex("dbo.Product", new[] { "Shop_ShopID" });
            DropIndex("dbo.Product", new[] { "Category_CategoryID" });
            DropIndex("dbo.Product", new[] { "OilID" });
            DropIndex("dbo.Product", new[] { "PackageID" });
            DropIndex("dbo.Oil", new[] { "Category_CategoryID" });
            DropIndex("dbo.Oil", new[] { "RawMaterialID" });
            DropIndex("dbo.RawMaterialStock", new[] { "SectorID" });
            DropIndex("dbo.RawMaterialStock", new[] { "RawMaterialID" });
            DropIndex("dbo.OilPress", new[] { "RawMaterialStock_ID" });
            DropIndex("dbo.OilPress", new[] { "UserId" });
            DropIndex("dbo.OilPress", new[] { "FactoryID" });
            DropIndex("dbo.Bottling", new[] { "ProductType_ID" });
            DropIndex("dbo.Bottling", new[] { "PackageType_ID" });
            DropIndex("dbo.Bottling", new[] { "FactoryID" });
            DropTable("dbo.Shop");
            DropTable("dbo.PackageStock");
            DropTable("dbo.UsersAccount");
            DropTable("dbo.Warehouse");
            DropTable("dbo.Sector");
            DropTable("dbo.Package");
            DropTable("dbo.Lot");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
            DropTable("dbo.Oil");
            DropTable("dbo.RawMaterial");
            DropTable("dbo.RawMaterialStock");
            DropTable("dbo.OilPress");
            DropTable("dbo.Factory");
            DropTable("dbo.Bottling");
        }
    }
}
