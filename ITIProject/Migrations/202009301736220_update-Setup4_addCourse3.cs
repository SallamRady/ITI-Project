namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSetup4_addCourse3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students_Cources", "Course_ID", c => c.Int());
            CreateIndex("dbo.Students_Cources", "Course_ID");
            AddForeignKey("dbo.Students_Cources", "Course_ID", "dbo.Cources", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students_Cources", "Course_ID", "dbo.Cources");
            DropIndex("dbo.Students_Cources", new[] { "Course_ID" });
            DropColumn("dbo.Students_Cources", "Course_ID");
        }
    }
}
