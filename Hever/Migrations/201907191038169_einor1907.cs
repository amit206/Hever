namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class einor1907 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurants", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Stores", "CityId", "dbo.Cities");
            DropIndex("dbo.Restaurants", new[] { "CityId" });
            DropIndex("dbo.Stores", new[] { "CityId" });
            AddColumn("dbo.Restaurants", "FullAddress", c => c.String());
            AddColumn("dbo.Restaurants", "Area", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "FullAddress", c => c.String());
            AddColumn("dbo.Stores", "Area", c => c.Int(nullable: false));
            DropColumn("dbo.Restaurants", "StreetAndNum");
            DropColumn("dbo.Restaurants", "CityId");
            DropColumn("dbo.Stores", "StreetAndNum");
            DropColumn("dbo.Stores", "CityId");
            DropColumn("dbo.Users", "CardNumber");
            DropColumn("dbo.Users", "CardExpirationDate");
            DropColumn("dbo.Users", "Cvs");
            DropTable("dbo.Cities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Area = c.Int(nullable: false),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Cvs", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CardExpirationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "CardNumber", c => c.Long(nullable: false));
            AddColumn("dbo.Stores", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Stores", "StreetAndNum", c => c.String());
            AddColumn("dbo.Restaurants", "CityId", c => c.Int(nullable: false));
            AddColumn("dbo.Restaurants", "StreetAndNum", c => c.String());
            DropColumn("dbo.Stores", "Area");
            DropColumn("dbo.Stores", "FullAddress");
            DropColumn("dbo.Restaurants", "Area");
            DropColumn("dbo.Restaurants", "FullAddress");
            CreateIndex("dbo.Stores", "CityId");
            CreateIndex("dbo.Restaurants", "CityId");
            AddForeignKey("dbo.Stores", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Restaurants", "CityId", "dbo.Cities", "Id", cascadeDelete: true);
        }
    }
}
