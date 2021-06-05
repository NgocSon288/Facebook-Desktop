namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_PostStatus_Entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostStatuses", "Name", c => c.String());
            AddColumn("dbo.PostStatuses", "DisplayName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostStatuses", "DisplayName");
            DropColumn("dbo.PostStatuses", "Name");
        }
    }
}
