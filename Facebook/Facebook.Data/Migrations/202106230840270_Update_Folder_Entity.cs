namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Folder_Entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Folders", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Folders", "UserID");
        }
    }
}
