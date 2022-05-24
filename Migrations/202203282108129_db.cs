namespace SinglePageApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NameUser = c.String(nullable: false, maxLength: 50),
                        EmailUser = c.String(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 100),
                        Message = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Descriptions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Text = c.String(nullable: false),
                        ImagePath = c.String(maxLength: 50),
                        Tags = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(nullable: false, maxLength: 50),
                        GroupGallery_id = c.Int(nullable: false),
                        Tags = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.GroupGalleries", t => t.GroupGallery_id, cascadeDelete: true)
                .Index(t => t.GroupGallery_id);
            
            CreateTable(
                "dbo.GroupGalleries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.logoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sliders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Galleries", "GroupGallery_id", "dbo.GroupGalleries");
            DropIndex("dbo.Galleries", new[] { "GroupGallery_id" });
            DropTable("dbo.Sliders");
            DropTable("dbo.logoes");
            DropTable("dbo.GroupGalleries");
            DropTable("dbo.Galleries");
            DropTable("dbo.Descriptions");
            DropTable("dbo.Contacts");
        }
    }
}
