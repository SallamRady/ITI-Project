namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefile105 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Departments", "Manager_ID", "dbo.Professors");
            DropIndex("dbo.Departments", new[] { "Manager_ID" });
            AlterColumn("dbo.Departments", "Manager_ID", c => c.Int());
            CreateIndex("dbo.Departments", "Manager_ID");
            AddForeignKey("dbo.Departments", "Manager_ID", "dbo.Professors", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Departments", "Manager_ID", "dbo.Professors");
            DropIndex("dbo.Departments", new[] { "Manager_ID" });
            AlterColumn("dbo.Departments", "Manager_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Departments", "Manager_ID");
            AddForeignKey("dbo.Departments", "Manager_ID", "dbo.Professors", "ID", cascadeDelete: true);
        }
    }
}
