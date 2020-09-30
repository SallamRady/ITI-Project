namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSetup4_addStudent2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Student_Department_ID", c => c.Int());
            CreateIndex("dbo.Students", "Student_Department_ID");
            AddForeignKey("dbo.Students", "Student_Department_ID", "dbo.Departments", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Student_Department_ID", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Student_Department_ID" });
            DropColumn("dbo.Students", "Student_Department_ID");
        }
    }
}
