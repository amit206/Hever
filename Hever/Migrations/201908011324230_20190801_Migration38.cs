namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20190801_Migration38 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UsersStores", newName: "StoreUsers");
            DropForeignKey("dbo.Restaurants", "Users_Id", "dbo.Users");
            DropIndex("dbo.Restaurants", new[] { "Users_Id" });
            DropPrimaryKey("dbo.StoreUsers");
            CreateTable(
                "dbo.UsersRestaurants",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Restaurant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Restaurant_Id })
                .ForeignKey("dbo.Users", t => t.Users_Id, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_Id, cascadeDelete: true)
                .Index(t => t.Users_Id)
                .Index(t => t.Restaurant_Id);
            
            AddPrimaryKey("dbo.StoreUsers", new[] { "Store_Id", "Users_Id" });
            DropColumn("dbo.Restaurants", "Users_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Users_Id", c => c.Int());
            DropForeignKey("dbo.UsersRestaurants", "Restaurant_Id", "dbo.Restaurants");
            DropForeignKey("dbo.UsersRestaurants", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersRestaurants", new[] { "Restaurant_Id" });
            DropIndex("dbo.UsersRestaurants", new[] { "Users_Id" });
            DropPrimaryKey("dbo.StoreUsers");
            DropTable("dbo.UsersRestaurants");
            AddPrimaryKey("dbo.StoreUsers", new[] { "Users_Id", "Store_Id" });
            CreateIndex("dbo.Restaurants", "Users_Id");
            AddForeignKey("dbo.Restaurants", "Users_Id", "dbo.Users", "Id");
            RenameTable(name: "dbo.StoreUsers", newName: "UsersStores");
        }
    }
}
