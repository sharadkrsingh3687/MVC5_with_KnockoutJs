namespace InHouseApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StarRatingchange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "StarRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "StarRating");
        }
    }
}
