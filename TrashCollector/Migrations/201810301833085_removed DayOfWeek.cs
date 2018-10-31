namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedDayOfWeek : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "WeekDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "WeekDay", c => c.DateTime());
        }
    }
}
