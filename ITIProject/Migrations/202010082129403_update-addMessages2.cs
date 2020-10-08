namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateaddMessages2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Time", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Time");
        }
    }
}
