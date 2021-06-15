namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_M_MQ_Entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageQueues",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SenderID = c.Int(nullable: false),
                        ReceiverID = c.Int(nullable: false),
                        isRead = c.Boolean(nullable: false),
                        MessageID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Messages", t => t.MessageID, cascadeDelete: true)
                .Index(t => t.MessageID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SenderID = c.Int(nullable: false),
                        ReceiverID = c.Int(nullable: false),
                        Description = c.String(),
                        Image = c.String(),
                        File = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageQueues", "MessageID", "dbo.Messages");
            DropIndex("dbo.MessageQueues", new[] { "MessageID" });
            DropTable("dbo.Messages");
            DropTable("dbo.MessageQueues");
        }
    }
}
