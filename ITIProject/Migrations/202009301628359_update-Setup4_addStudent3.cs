namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSetup4_addStudent3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Student_Professor_supervisior_ID", c => c.Int());
            CreateIndex("dbo.Students", "Student_Professor_supervisior_ID");
            AddForeignKey("dbo.Students", "Student_Professor_supervisior_ID", "dbo.Professors", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Student_Professor_supervisior_ID", "dbo.Professors");
            DropIndex("dbo.Students", new[] { "Student_Professor_supervisior_ID" });
            DropColumn("dbo.Students", "Student_Professor_supervisior_ID");
        }
    }
}
