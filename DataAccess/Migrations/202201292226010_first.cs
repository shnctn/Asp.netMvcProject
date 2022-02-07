namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Headings", "HeadingStatuses");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Headings", "HeadingStatuses", c => c.Boolean(nullable: false));
        }
    }
}
