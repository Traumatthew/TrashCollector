namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelpickupsagainagainagain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pickups", "PickUpDay", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pickups", "PickUpDay", c => c.DateTime(nullable: false));
        }
    }
}
