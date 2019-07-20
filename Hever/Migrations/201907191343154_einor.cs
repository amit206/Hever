namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class einor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "RestaurantType", c => c.String());
            AlterColumn("dbo.Restaurants", "Area", c => c.String());
            AlterColumn("dbo.Stores", "StoreType", c => c.String());
            AlterColumn("dbo.Stores", "Area", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Area", c => c.Int(nullable: false));
            AlterColumn("dbo.Stores", "StoreType", c => c.Int(nullable: false));
            AlterColumn("dbo.Restaurants", "Area", c => c.Int(nullable: false));
            AlterColumn("dbo.Restaurants", "RestaurantType", c => c.Int(nullable: false));
        }
    }
}
