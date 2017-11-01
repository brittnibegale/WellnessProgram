namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedappuserforeignkey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Day = c.DateTime(nullable: false),
                        CurrentVigorousDuration = c.Double(),
                        VigorousNumberToAdd = c.Double(),
                        ExercisePending = c.Boolean(nullable: false),
                        CurrentModerateDuration = c.Double(),
                        ModerateNumberToAdd = c.Double(),
                        CalorieGoal = c.Double(),
                        CurrentCalorieCount = c.Double(),
                        CaloriesToAdd = c.Double(),
                        CalorieMonthlyPoints = c.Double(),
                        CalorieYearlyPoints = c.Double(),
                        CaloriesPending = c.Boolean(nullable: false),
                        ModerateDuration = c.Double(nullable: false),
                        VigorousDuration = c.Double(nullable: false),
                        Captain = c.Boolean(nullable: false),
                        HealthId = c.Int(),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.HealthInfoes", t => t.HealthId)
                .Index(t => t.HealthId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false),
                        GroupCaloriePoints = c.Double(nullable: false),
                        GroupExercisePoints = c.Double(nullable: false),
                        TotalPoints = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HealthInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UniqueCode = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Smoker = c.Boolean(nullable: false),
                        BodyFatAmt = c.Double(nullable: false),
                        Hdl = c.Double(nullable: false),
                        Ldl = c.Double(nullable: false),
                        CholesterolTotal = c.Double(nullable: false),
                        Triglycerides = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "HealthId", "dbo.HealthInfoes");
            DropForeignKey("dbo.Customers", "GroupId", "dbo.Groups");
            DropIndex("dbo.Customers", new[] { "GroupId" });
            DropIndex("dbo.Customers", new[] { "HealthId" });
            DropTable("dbo.HealthInfoes");
            DropTable("dbo.Groups");
            DropTable("dbo.Customers");
        }
    }
}
