namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Update_User_Entity1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ByBlockedFriend", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "ByBlockedFriend");
        }
    }
}
