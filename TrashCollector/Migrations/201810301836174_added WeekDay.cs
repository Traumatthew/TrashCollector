namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedWeekDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "WeekDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "WeekDay");
        }
    }
}
