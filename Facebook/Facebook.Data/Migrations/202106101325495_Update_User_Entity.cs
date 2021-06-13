namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_User_Entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Friend", c => c.String());
            AddColumn("dbo.Users", "RequestedFriend", c => c.String());
            AddColumn("dbo.Users", "BlockedFriend", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "BlockedFriend");
            DropColumn("dbo.Users", "RequestedFriend");
            DropColumn("dbo.Users", "Friend");
        }
    }
}
