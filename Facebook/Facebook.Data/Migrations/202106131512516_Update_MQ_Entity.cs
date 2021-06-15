namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_MQ_Entity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MessageQueues", "OwnID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MessageQueues", "OwnID");
        }
    }
}
