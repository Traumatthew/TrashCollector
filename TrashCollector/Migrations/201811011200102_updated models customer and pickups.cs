namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodelscustomerandpickups : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Pickups", "EmployeeId", c => c.Int());
            AddColumn("dbo.Pickups", "Charge", c => c.Double(nullable: false));
            AddColumn("dbo.Pickups", "PickUpDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Pickups", "EmployeeId");
            AddForeignKey("dbo.Pickups", "EmployeeId", "dbo.Employees", "EmployeeId");
            DropColumn("dbo.Pickups", "DatePickUpsStart");
            DropColumn("dbo.Pickups", "DatePickUpsEnd");
            DropColumn("dbo.Pickups", "WeekDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pickups", "WeekDay", c => c.String());
            AddColumn("dbo.Pickups", "DatePickUpsEnd", c => c.DateTime());
            AddColumn("dbo.Pickups", "DatePickUpsStart", c => c.DateTime());
            DropForeignKey("dbo.Pickups", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Pickups", new[] { "EmployeeId" });
            DropColumn("dbo.Pickups", "PickUpDate");
            DropColumn("dbo.Pickups", "Charge");
            DropColumn("dbo.Pickups", "EmployeeId");
            DropColumn("dbo.Addresses", "CustomerId");
        }
    }
}
