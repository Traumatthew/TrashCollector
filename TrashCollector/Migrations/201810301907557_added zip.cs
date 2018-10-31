namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedzip : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Employees", new[] { "AddressId" });
            AddColumn("dbo.Employees", "ZipCode", c => c.String());
            DropColumn("dbo.Employees", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "AddressId", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "ZipCode");
            CreateIndex("dbo.Employees", "AddressId");
            AddForeignKey("dbo.Employees", "AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
        }
    }
}
