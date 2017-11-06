namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcaloriealert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalorieAlerts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CalorieGoal = c.Double(nullable: false),
                        CaloriesConsumed = c.Double(nullable: false),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        Read = c.Boolean(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            DropColumn("dbo.Customers", "CaloriesToAdd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CaloriesToAdd", c => c.Double());
            DropForeignKey("dbo.CalorieAlerts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CalorieAlerts", new[] { "CustomerId" });
            DropTable("dbo.CalorieAlerts");
        }
    }
}
