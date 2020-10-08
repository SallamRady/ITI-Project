namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateroles_Sallam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Students", "Roles", c => c.String(nullable: false));
            AddColumn("dbo.Professors", "Roles", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professors", "Roles");
            DropColumn("dbo.Students", "Roles");
            DropColumn("dbo.Students", "Email");
        }
    }
}
