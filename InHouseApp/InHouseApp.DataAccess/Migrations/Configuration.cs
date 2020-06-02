namespace InHouseApp.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using InHouseApp.DataAccess;
    using InHouseApp.EntityModel.BusinessEntity;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductsDBContext context)
        {
            var products = new List<Product>
            {
                new Product { ProductName = "Voltas AC", ProductType="Home Appliances", ProductDesc = "Voltas 1 Ton 3 Star Split AC(Copper SAC_123_DZX White)", 
                                SKUNumber = "VO123CYA", UnitPrice = 46000.00m, Stock = 12, StarRating = 4,
                                ImageUrl = "https://www.myvoltas.com/pub/media/catalog/category/air-conditioner-banner.jpg",
                                CreatedBy = "System", CreatedOn = DateTime.UtcNow, ModifiedBy = "System", ModifiedOn = DateTime.UtcNow},
                new Product { ProductName = "Chine Coffee Mug", ProductType = "Home Appliances", ProductDesc = "Godrej Cartini Creative Stainless Steel Kitchen Knife Set, 3 - Pieces, Teal", 
                                SKUNumber = "CH595CMF", UnitPrice = 489.00m, Stock = 78, CreatedBy = "System", StarRating = 3,
                                ImageUrl = "https://m.media-amazon.com/images/I/81u4MdCFaUL._AC_UL320_.jpg",
                                CreatedOn = DateTime.UtcNow, ModifiedBy = "System", ModifiedOn = DateTime.UtcNow },
                new Product { ProductName = "Hands-On Azure for Developers: e-book", ProductType = "Book", ProductDesc = "Hands-On Azure for Developers: Implement rich Azure PaaS ecosystems", 
                                SKUNumber = "B07GDGCX29", UnitPrice = 543.95m, Stock = 15, StarRating = 3,
                                ImageUrl = "https://m.media-amazon.com/images/I/71IBmfmKPSL._AC_UL320_.jpg",
                                CreatedBy = "System", CreatedOn = DateTime.UtcNow, ModifiedBy = "System", ModifiedOn = DateTime.UtcNow},
                new Product { ProductName = "OnePlus 7T Pro", ProductType = "Mobile", ProductDesc = "OnePlus 7T Pro (Haze Blue, 8GB RAM, Fluid AMOLED Display, 256GB Storage, 4085mAH Battery)", 
                                SKUNumber = "B0842KM575", UnitPrice = 43900.0m, Stock = 20, StarRating = 5,
                                ImageUrl = "https://m.media-amazon.com/images/I/61FRLa8IFTL._AC_UL320_.jpg",
                                CreatedBy = "System", CreatedOn = DateTime.UtcNow, ModifiedBy = "System", ModifiedOn = DateTime.UtcNow},
                new Product { ProductName = "JBL Bluetooth Speaker", ProductType = "Speaker", ProductDesc = "JBL Flip 3 Stealth Waterproof Portable Bluetooth Speaker with Rich Deep Bass (Black), Without Mic", 
                                SKUNumber = "B07HHHMWQG", UnitPrice = 0.0m, Stock = 34, StarRating = 3,
                                ImageUrl = "https://m.media-amazon.com/images/I/81DRhqE04BL._AC_UL320_.jpg",
                                CreatedBy = "System", CreatedOn = DateTime.UtcNow, ModifiedBy = "System", ModifiedOn = DateTime.UtcNow}

             };

            products.ForEach(s => context.Products.AddOrUpdate(p => p.ProductName, s));
            context.SaveChanges();
        }
    }
}
