namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Folder_Entity2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Folders", "ColorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Folders", "ColorName");
        }
    }
}
