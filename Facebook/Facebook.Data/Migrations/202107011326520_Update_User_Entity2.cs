namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_User_Entity2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ImageUpdatedTime", c => c.DateTime());
            AddColumn("dbo.Users", "AvatarUpdatedTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "AvatarUpdatedTime");
            DropColumn("dbo.Users", "ImageUpdatedTime");
        }
    }
}
