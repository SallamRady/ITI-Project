namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSetup4_addCourse4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cources", "Course_Department_ID", c => c.Int());
            CreateIndex("dbo.Cources", "Course_Department_ID");
            AddForeignKey("dbo.Cources", "Course_Department_ID", "dbo.Departments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cources", "Course_Department_ID", "dbo.Departments");
            DropIndex("dbo.Cources", new[] { "Course_Department_ID" });
            DropColumn("dbo.Cources", "Course_Department_ID");
        }
    }
}
