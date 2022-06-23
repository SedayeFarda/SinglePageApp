namespace SinglePageApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GalleryProducts", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GalleryProducts", "Title");
        }
    }
}
