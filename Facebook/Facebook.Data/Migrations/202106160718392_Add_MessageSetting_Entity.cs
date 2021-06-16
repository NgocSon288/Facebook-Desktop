namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_MessageSetting_Entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageSettings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ThemeColor = c.String(),
                        UpdatedAt = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(),
                        User1_ID = c.Int(),
                        User2_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User1_ID)
                .ForeignKey("dbo.Users", t => t.User2_ID)
                .Index(t => t.User1_ID)
                .Index(t => t.User2_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageSettings", "User2_ID", "dbo.Users");
            DropForeignKey("dbo.MessageSettings", "User1_ID", "dbo.Users");
            DropIndex("dbo.MessageSettings", new[] { "User2_ID" });
            DropIndex("dbo.MessageSettings", new[] { "User1_ID" });
            DropTable("dbo.MessageSettings");
        }
    }
}
