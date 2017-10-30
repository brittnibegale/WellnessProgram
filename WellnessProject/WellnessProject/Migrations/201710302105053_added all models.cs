namespace WellnessProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedallmodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.AspNetUsers");
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModerateDuration = c.Double(nullable: false),
                        CurrentModerateDuration = c.Double(nullable: false),
                        ModerateNumberToAdd = c.Double(),
                        VigorousDuration = c.Double(nullable: false),
                        CurrentVigorousDuration = c.Double(nullable: false),
                        VigorousNumberToAdd = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false),
                        GroupCaloriePoints = c.Double(nullable: false),
                        GroupExercisePoints = c.Double(nullable: false),
                        TotalPoints = c.Double(nullable: false),
                        Person1_FirstName = c.String(maxLength: 128),
                        Person2_FirstName = c.String(maxLength: 128),
                        Person3_FirstName = c.String(maxLength: 128),
                        Person4_FirstName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Person1_FirstName)
                .ForeignKey("dbo.AspNetUsers", t => t.Person2_FirstName)
                .ForeignKey("dbo.AspNetUsers", t => t.Person3_FirstName)
                .ForeignKey("dbo.AspNetUsers", t => t.Person4_FirstName)
                .Index(t => t.Person1_FirstName)
                .Index(t => t.Person2_FirstName)
                .Index(t => t.Person3_FirstName)
                .Index(t => t.Person4_FirstName);
            
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
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Code", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "HealthId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "CalorieId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ExerciseId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "GroupId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "AchievementId", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String());
            AddPrimaryKey("dbo.AspNetUsers", "FirstName");
            CreateIndex("dbo.AspNetUsers", "HealthId");
            CreateIndex("dbo.AspNetUsers", "CalorieId");
            CreateIndex("dbo.AspNetUsers", "ExerciseId");
            CreateIndex("dbo.AspNetUsers", "GroupId");
            CreateIndex("dbo.AspNetUsers", "AchievementId");
            AddForeignKey("dbo.AspNetUsers", "AchievementId", "dbo.Achievements", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "CalorieId", "dbo.Calories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "ExerciseId", "dbo.Exercises", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", "HealthId", "dbo.HealthInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "FirstName", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "FirstName", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "FirstName", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "HealthId", "dbo.HealthInfoes");
            DropForeignKey("dbo.AspNetUsers", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Groups", "Person4_FirstName", "dbo.AspNetUsers");
            DropForeignKey("dbo.Groups", "Person3_FirstName", "dbo.AspNetUsers");
            DropForeignKey("dbo.Groups", "Person2_FirstName", "dbo.AspNetUsers");
            DropForeignKey("dbo.Groups", "Person1_FirstName", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ExerciseId", "dbo.Exercises");
            DropForeignKey("dbo.AspNetUsers", "CalorieId", "dbo.Calories");
            DropForeignKey("dbo.AspNetUsers", "AchievementId", "dbo.Achievements");
            DropIndex("dbo.Groups", new[] { "Person4_FirstName" });
            DropIndex("dbo.Groups", new[] { "Person3_FirstName" });
            DropIndex("dbo.Groups", new[] { "Person2_FirstName" });
            DropIndex("dbo.Groups", new[] { "Person1_FirstName" });
            DropIndex("dbo.AspNetUsers", new[] { "AchievementId" });
            DropIndex("dbo.AspNetUsers", new[] { "GroupId" });
            DropIndex("dbo.AspNetUsers", new[] { "ExerciseId" });
            DropIndex("dbo.AspNetUsers", new[] { "CalorieId" });
            DropIndex("dbo.AspNetUsers", new[] { "HealthId" });
            DropPrimaryKey("dbo.AspNetUsers");
            AlterColumn("dbo.AspNetUsers", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.AspNetUsers", "AchievementId");
            DropColumn("dbo.AspNetUsers", "GroupId");
            DropColumn("dbo.AspNetUsers", "ExerciseId");
            DropColumn("dbo.AspNetUsers", "CalorieId");
            DropColumn("dbo.AspNetUsers", "HealthId");
            DropColumn("dbo.AspNetUsers", "Code");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.HealthInfoes");
            DropTable("dbo.Groups");
            DropTable("dbo.Exercises");
            DropTable("dbo.Calories");
            DropTable("dbo.Achievements");
            AddPrimaryKey("dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
