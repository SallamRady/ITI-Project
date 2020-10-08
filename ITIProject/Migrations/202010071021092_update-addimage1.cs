namespace ITIProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateaddimage1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Image");
        }
    }
}
