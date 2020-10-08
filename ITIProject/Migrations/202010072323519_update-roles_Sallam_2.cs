namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateroles_Sallam_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Professors", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Professors", "Email");
        }
    }
}
