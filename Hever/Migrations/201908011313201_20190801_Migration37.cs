namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20190801_Migration37 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stores", "Users_Id", "dbo.Users");
            DropIndex("dbo.Stores", new[] { "Users_Id" });
            CreateTable(
                "dbo.UsersStores",
                c => new
                    {
                        Users_Id = c.Int(nullable: false),
                        Store_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Users_Id, t.Store_Id })
                .ForeignKey("dbo.Users", t => t.Users_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.Store_Id, cascadeDelete: true)
                .Index(t => t.Users_Id)
                .Index(t => t.Store_Id);
            
            DropColumn("dbo.Stores", "Users_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stores", "Users_Id", c => c.Int());
            DropForeignKey("dbo.UsersStores", "Store_Id", "dbo.Stores");
            DropForeignKey("dbo.UsersStores", "Users_Id", "dbo.Users");
            DropIndex("dbo.UsersStores", new[] { "Store_Id" });
            DropIndex("dbo.UsersStores", new[] { "Users_Id" });
            DropTable("dbo.UsersStores");
            CreateIndex("dbo.Stores", "Users_Id");
            AddForeignKey("dbo.Stores", "Users_Id", "dbo.Users", "Id");
        }
    }
}
