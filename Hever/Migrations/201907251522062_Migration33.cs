namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration33 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurants", "FacebookLink");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "FacebookLink", c => c.String());
        }
    }
}
