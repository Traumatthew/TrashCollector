namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelpickups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pickups", "PickUpSuspensionBegins", c => c.DateTime());
            AddColumn("dbo.Pickups", "PickUpSuspensionEnds", c => c.DateTime());
            AddColumn("dbo.Pickups", "PickUpDay", c => c.DateTime(nullable: false));
            DropColumn("dbo.Pickups", "PickUpDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pickups", "PickUpDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Pickups", "PickUpDay");
            DropColumn("dbo.Pickups", "PickUpSuspensionEnds");
            DropColumn("dbo.Pickups", "PickUpSuspensionBegins");
        }
    }
}
