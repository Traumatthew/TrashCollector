namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelpickupsagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pickups", "ZipCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pickups", "ZipCode");
        }
    }
}
