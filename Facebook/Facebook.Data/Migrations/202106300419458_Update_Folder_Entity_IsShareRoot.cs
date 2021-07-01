namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Folder_Entity_IsShareRoot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Folders", "IsShareRoot", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Folders", "IsShareRoot");
        }
    }
}
