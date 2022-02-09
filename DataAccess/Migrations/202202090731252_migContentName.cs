namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migContentName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "ContentName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contents", "ContentName");
        }
    }
}
