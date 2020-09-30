namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSetup4_addCourse2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cources",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Free = c.Boolean(nullable: false),
                        Cost = c.Double(nullable: false),
                        Hours = c.Int(nullable: false),
                        Degree = c.Int(nullable: false),
                        MinDegree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cources");
        }
    }
}
