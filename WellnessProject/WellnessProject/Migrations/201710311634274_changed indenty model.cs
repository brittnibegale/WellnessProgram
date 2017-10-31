namespace WellnessProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedindentymodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "AchievementId", "dbo.Achievements");
            DropForeignKey("dbo.AspNetUsers", "CalorieId", "dbo.Calories");
            DropForeignKey("dbo.AspNetUsers", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.AspNetUsers", "HealthId", "dbo.HealthInfoes");
            DropIndex("dbo.AspNetUsers", new[] { "HealthId" });
            DropIndex("dbo.AspNetUsers", new[] { "CalorieId" });
            DropIndex("dbo.AspNetUsers", new[] { "ExerciseId" });
            DropIndex("dbo.AspNetUsers", new[] { "AchievementId" });
            AddColumn("dbo.AspNetUsers", "CurrentVigorousDuration", c => c.Double());
            AddColumn("dbo.AspNetUsers", "VigorousNumberToAdd", c => c.Double());
            AddColumn("dbo.AspNetUsers", "ExercisePending", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "CurrentModerateDuration", c => c.Double());
            AddColumn("dbo.AspNetUsers", "ModerateNumberToAdd", c => c.Double());
            AddColumn("dbo.AspNetUsers", "CalorieGoal", c => c.Double());
            AddColumn("dbo.AspNetUsers", "CurrentCalorieCount", c => c.Double());
            AddColumn("dbo.AspNetUsers", "CaloriesToAdd", c => c.Double());
            AddColumn("dbo.AspNetUsers", "CalorieMonthlyPoints", c => c.Double());
            AddColumn("dbo.AspNetUsers", "CalorieYearlyPoints", c => c.Double());
            AddColumn("dbo.AspNetUsers", "CaloriesPending", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "ModerateDuration", c => c.Double(nullable: false));
            AddColumn("dbo.AspNetUsers", "VigorousDuration", c => c.Double(nullable: false));
            AlterColumn("dbo.AspNetUsers", "HealthId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "HealthId");
            AddForeignKey("dbo.AspNetUsers", "HealthId", "dbo.HealthInfoes", "Id");
            DropColumn("dbo.Exercises", "CurrentModerateDuration");
            DropColumn("dbo.Exercises", "ModerateNumberToAdd");
            DropColumn("dbo.Exercises", "CurrentVigorousDuration");
            DropColumn("dbo.Exercises", "VigorousNumberToAdd");
            DropColumn("dbo.Exercises", "Pending");
            DropColumn("dbo.AspNetUsers", "CalorieId");
            DropColumn("dbo.AspNetUsers", "ExerciseId");
            DropColumn("dbo.AspNetUsers", "AchievementId");
            DropTable("dbo.Calories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Calories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Goal = c.Double(nullable: false),
                        CurrentCalorieCount = c.Double(nullable: false),
                        CaloriesToAdd = c.Double(),
                        MonthlyPoints = c.Double(nullable: false),
                        YearlyPoints = c.Double(nullable: false),
                        Pending = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "AchievementId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ExerciseId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "CalorieId", c => c.Int(nullable: false));
            AddColumn("dbo.Exercises", "Pending", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exercises", "VigorousNumberToAdd", c => c.Double());
            AddColumn("dbo.Exercises", "CurrentVigorousDuration", c => c.Double(nullable: false));
            AddColumn("dbo.Exercises", "ModerateNumberToAdd", c => c.Double());
            AddColumn("dbo.Exercises", "CurrentModerateDuration", c => c.Double(nullable: false));
            DropForeignKey("dbo.AspNetUsers", "HealthId", "dbo.HealthInfoes");
            DropIndex("dbo.AspNetUsers", new[] { "HealthId" });
            AlterColumn("dbo.AspNetUsers", "HealthId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "VigorousDuration");
            DropColumn("dbo.AspNetUsers", "ModerateDuration");
            DropColumn("dbo.AspNetUsers", "CaloriesPending");
            DropColumn("dbo.AspNetUsers", "CalorieYearlyPoints");
            DropColumn("dbo.AspNetUsers", "CalorieMonthlyPoints");
            DropColumn("dbo.AspNetUsers", "CaloriesToAdd");
            DropColumn("dbo.AspNetUsers", "CurrentCalorieCount");
            DropColumn("dbo.AspNetUsers", "CalorieGoal");
            DropColumn("dbo.AspNetUsers", "ModerateNumberToAdd");
            DropColumn("dbo.AspNetUsers", "CurrentModerateDuration");
            DropColumn("dbo.AspNetUsers", "ExercisePending");
            DropColumn("dbo.AspNetUsers", "VigorousNumberToAdd");
            DropColumn("dbo.AspNetUsers", "CurrentVigorousDuration");
            CreateIndex("dbo.AspNetUsers", "AchievementId");
            CreateIndex("dbo.AspNetUsers", "ExerciseId");
            CreateIndex("dbo.AspNetUsers", "CalorieId");
            CreateIndex("dbo.AspNetUsers", "HealthId");
            AddForeignKey("dbo.AspNetUsers", "HealthId", "dbo.HealthInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "ExerciseId", "dbo.Exercises", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "CalorieId", "dbo.Calories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "AchievementId", "dbo.Achievements", "Id", cascadeDelete: true);
        }
    }
}
