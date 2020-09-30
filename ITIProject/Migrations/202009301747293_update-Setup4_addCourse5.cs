namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSetup4_addCourse5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cources", "Course_Professor_ID", c => c.Int());
            CreateIndex("dbo.Cources", "Course_Professor_ID");
            AddForeignKey("dbo.Cources", "Course_Professor_ID", "dbo.Professors", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cources", "Course_Professor_ID", "dbo.Professors");
            DropIndex("dbo.Cources", new[] { "Course_Professor_ID" });
            DropColumn("dbo.Cources", "Course_Professor_ID");
        }
    }
}
