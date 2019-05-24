namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Einor2405 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CardNumber", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CardNumber", c => c.Int(nullable: false));
        }
    }
}
