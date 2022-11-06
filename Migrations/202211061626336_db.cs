namespace SinglePageApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductGroups", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.ProductGroups", new[] { "Group_GroupId" });
            DropColumn("dbo.ProductGroups", "GroupsId");
            RenameColumn(table: "dbo.ProductGroups", name: "Group_GroupId", newName: "GroupsId");
            AlterColumn("dbo.ProductGroups", "GroupsId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductGroups", "GroupsId");
            AddForeignKey("dbo.ProductGroups", "GroupsId", "dbo.Groups", "GroupId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductGroups", "GroupsId", "dbo.Groups");
            DropIndex("dbo.ProductGroups", new[] { "GroupsId" });
            AlterColumn("dbo.ProductGroups", "GroupsId", c => c.Int());
            RenameColumn(table: "dbo.ProductGroups", name: "GroupsId", newName: "Group_GroupId");
            AddColumn("dbo.ProductGroups", "GroupsId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductGroups", "Group_GroupId");
            AddForeignKey("dbo.ProductGroups", "Group_GroupId", "dbo.Groups", "GroupId");
        }
    }
}
