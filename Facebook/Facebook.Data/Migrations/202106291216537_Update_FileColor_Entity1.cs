namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_FileColor_Entity1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FileColors", "UserID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FileColors", "UserID");
        }
    }
}
