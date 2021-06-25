namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Folder_Entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentID = c.Int(nullable: false),
                        ChildrenID = c.String(),
                        Files = c.String(),
                        ShareList = c.String(),
                        IsPublic = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Folders");
        }
    }
}
