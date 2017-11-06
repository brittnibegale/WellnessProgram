namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedexercisealert : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExerciseAlerts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VigorousGoal = c.Double(nullable: false),
                        ModerateGoal = c.Double(nullable: false),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        Read = c.Boolean(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            AlterColumn("dbo.Customers", "CalorieGoal", c => c.Double(nullable: false));
            DropColumn("dbo.Customers", "VigorousNumberToAdd");
            DropColumn("dbo.Customers", "ModerateNumberToAdd");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ModerateNumberToAdd", c => c.Double());
            AddColumn("dbo.Customers", "VigorousNumberToAdd", c => c.Double());
            DropForeignKey("dbo.ExerciseAlerts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ExerciseAlerts", new[] { "CustomerId" });
            AlterColumn("dbo.Customers", "CalorieGoal", c => c.Double());
            DropTable("dbo.ExerciseAlerts");
        }
    }
}
