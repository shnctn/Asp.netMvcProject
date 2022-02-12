namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_ContentHeadingID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Contents", name: "Heading_HeadingId", newName: "HeadingId");
            RenameIndex(table: "dbo.Contents", name: "IX_Heading_HeadingId", newName: "IX_HeadingId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Contents", name: "IX_HeadingId", newName: "IX_Heading_HeadingId");
            RenameColumn(table: "dbo.Contents", name: "HeadingId", newName: "Heading_HeadingId");
        }
    }
}
