namespace Hever.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20190819_Amit_Annotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "FullAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "StoreType", c => c.String(nullable: false));
            AlterColumn("dbo.Stores", "Area", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Stores", "Area", c => c.String());
            AlterColumn("dbo.Stores", "StoreType", c => c.String());
            AlterColumn("dbo.Stores", "FullAddress", c => c.String());
            AlterColumn("dbo.Stores", "Name", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
        }
    }
}
