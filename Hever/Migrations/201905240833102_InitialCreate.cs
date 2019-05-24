namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreetAndNum = c.String(),
                        IsAccessible = c.Boolean(nullable: false),
                        IsKosher = c.Boolean(nullable: false),
                        RestaurantType = c.Int(nullable: false),
                        FacebookLink = c.String(),
                        CityId = c.Int(nullable: false),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.CityId)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StreetAndNum = c.String(),
                        IsAccessible = c.Boolean(nullable: false),
                        StoreType = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.Int(nullable: false),
                        IsAdmine = c.Boolean(nullable: false),
                        CardNumber = c.Int(nullable: false),
                        CardExpirationDate = c.DateTime(nullable: false),
                        Cvs = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.Stores", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Restaurants", "CityId", "dbo.Cities");
            DropIndex("dbo.Stores", new[] { "CityId" });
            DropIndex("dbo.Restaurants", new[] { "Users_Id" });
            DropIndex("dbo.Restaurants", new[] { "CityId" });
            DropTable("dbo.Users");
            DropTable("dbo.Stores");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Cities");
        }
    }
}
