namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmitUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Users", "IsAdmine");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsAdmine", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "IsAdmin");
        }
    }
}
