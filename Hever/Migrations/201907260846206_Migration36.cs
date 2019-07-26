namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stores", "Users_Id", c => c.Int());
            CreateIndex("dbo.Stores", "Users_Id");
            AddForeignKey("dbo.Stores", "Users_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stores", "Users_Id", "dbo.Users");
            DropIndex("dbo.Stores", new[] { "Users_Id" });
            DropColumn("dbo.Stores", "Users_Id");
        }
    }
}
