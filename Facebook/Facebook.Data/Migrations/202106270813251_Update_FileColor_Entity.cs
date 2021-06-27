namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_FileColor_Entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileColors", "ExtensionName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FileColors", "ExtensionName");
        }
    }
}
