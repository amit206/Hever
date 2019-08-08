namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20190819_Amit_Annotations2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "FullAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "RestaurantType", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Area", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Area", c => c.String());
            AlterColumn("dbo.Restaurants", "RestaurantType", c => c.String());
            AlterColumn("dbo.Restaurants", "FullAddress", c => c.String());
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
        }
    }
}
