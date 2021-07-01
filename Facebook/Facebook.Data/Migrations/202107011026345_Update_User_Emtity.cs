namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_User_Emtity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "BlockDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "BlockDate");
        }
    }
}
