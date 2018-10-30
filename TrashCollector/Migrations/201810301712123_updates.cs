namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DatePickUpsStart", c => c.DateTime());
            AddColumn("dbo.Customers", "DatePickUpsEnd", c => c.DateTime());
            AddColumn("dbo.Customers", "WeekDay", c => c.DateTime());
            AddColumn("dbo.Customers", "ExtraPickUp", c => c.DateTime());
            AddColumn("dbo.Pickups", "ExtraPickUp", c => c.DateTime());
            AddColumn("dbo.Pickups", "PickUpCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Pickups", "StartDay");
            DropColumn("dbo.Pickups", "EndDay");
            DropColumn("dbo.Pickups", "BonusPickUp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pickups", "BonusPickUp", c => c.DateTime());
            AddColumn("dbo.Pickups", "EndDay", c => c.DateTime());
            AddColumn("dbo.Pickups", "StartDay", c => c.DateTime());
            DropColumn("dbo.Pickups", "PickUpCompleted");
            DropColumn("dbo.Pickups", "ExtraPickUp");
            DropColumn("dbo.Customers", "ExtraPickUp");
            DropColumn("dbo.Customers", "WeekDay");
            DropColumn("dbo.Customers", "DatePickUpsEnd");
            DropColumn("dbo.Customers", "DatePickUpsStart");
        }
    }
}
