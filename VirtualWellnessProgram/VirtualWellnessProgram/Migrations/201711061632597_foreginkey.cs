namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreginkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Alerts", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Alerts", "CustomerId");
            AddForeignKey("dbo.Alerts", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alerts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Alerts", new[] { "CustomerId" });
            DropColumn("dbo.Alerts", "CustomerId");
        }
    }
}
