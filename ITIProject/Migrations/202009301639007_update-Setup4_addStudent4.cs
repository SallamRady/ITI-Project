namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSetup4_addStudent4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students_Cources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Student_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students_Cources", "Student_ID", "dbo.Students");
            DropIndex("dbo.Students_Cources", new[] { "Student_ID" });
            DropTable("dbo.Students_Cources");
        }
    }
}
