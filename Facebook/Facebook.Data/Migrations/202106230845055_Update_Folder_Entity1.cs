namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Folder_Entity1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Folders", "ParentID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Folders", "ParentID", c => c.Int(nullable: false));
        }
    }
}
