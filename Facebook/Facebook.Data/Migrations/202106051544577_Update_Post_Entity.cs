namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Post_Entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Like", c => c.String());
            AddColumn("dbo.Posts", "Share", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Share");
            DropColumn("dbo.Posts", "Like");
        }
    }
}
