namespace Facebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_FileColor_Entity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileColors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Extension = c.String(),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileColors");
        }
    }
}
