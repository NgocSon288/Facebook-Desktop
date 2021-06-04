namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Add_C_CF_P_PS_Entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentFeedbacks",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    Like = c.String(),
                    CreatedAt = c.DateTime(nullable: false),
                    CommentID = c.Int(nullable: false),
                    User_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.CommentID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.CommentID)
                .Index(t => t.User_ID);

            CreateTable(
                "dbo.Comments",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    CreatedAt = c.DateTime(nullable: false),
                    Like = c.String(),
                    PostID = c.Int(nullable: false),
                    User_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.PostID)
                .Index(t => t.User_ID);

            CreateTable(
                "dbo.Posts",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    Image = c.String(),
                    CreatedAt = c.DateTime(nullable: false),
                    PostShared = c.Int(),
                    PostStatusID = c.Int(nullable: false),
                    User_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PostStatuses", t => t.PostStatusID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.PostStatusID)
                .Index(t => t.User_ID);

            CreateTable(
                "dbo.PostStatuses",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.CommentFeedbacks", "User_ID", "dbo.Users");
            DropForeignKey("dbo.CommentFeedbacks", "CommentID", "dbo.Comments");
            DropForeignKey("dbo.Comments", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Posts", "PostStatusID", "dbo.PostStatuses");
            DropIndex("dbo.Posts", new[] { "User_ID" });
            DropIndex("dbo.Posts", new[] { "PostStatusID" });
            DropIndex("dbo.Comments", new[] { "User_ID" });
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.CommentFeedbacks", new[] { "User_ID" });
            DropIndex("dbo.CommentFeedbacks", new[] { "CommentID" });
            DropTable("dbo.PostStatuses");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.CommentFeedbacks");
        }
    }
}
