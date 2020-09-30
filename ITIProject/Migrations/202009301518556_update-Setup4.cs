namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSetup4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Professors", name: "Department_ID", newName: "Professor_Department_ID");
            RenameIndex(table: "dbo.Professors", name: "IX_Department_ID", newName: "IX_Professor_Department_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Professors", name: "IX_Professor_Department_ID", newName: "IX_Department_ID");
            RenameColumn(table: "dbo.Professors", name: "Professor_Department_ID", newName: "Department_ID");
        }
    }
}
