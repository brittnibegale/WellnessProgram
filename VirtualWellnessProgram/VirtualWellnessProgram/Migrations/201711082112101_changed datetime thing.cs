namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeddatetimething : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "VigorousNumberToAdd", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "ModerateNumberToAdd", c => c.Double(nullable: false));
            AddColumn("dbo.Groups", "UpdatedDate", c => c.String());
            AlterColumn("dbo.Customers", "Day", c => c.String());
            AlterColumn("dbo.Customers", "CurrentCalorieCount", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "CalorieMonthlyPoints", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "CalorieYearlyPoints", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "ExerciseMonthlyPoints", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "ExerciseYearlyPoints", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ExerciseYearlyPoints", c => c.Double());
            AlterColumn("dbo.Customers", "ExerciseMonthlyPoints", c => c.Double());
            AlterColumn("dbo.Customers", "CalorieYearlyPoints", c => c.Double());
            AlterColumn("dbo.Customers", "CalorieMonthlyPoints", c => c.Double());
            AlterColumn("dbo.Customers", "CurrentCalorieCount", c => c.Double());
            AlterColumn("dbo.Customers", "Day", c => c.DateTime(nullable: false));
            DropColumn("dbo.Groups", "UpdatedDate");
            DropColumn("dbo.Customers", "ModerateNumberToAdd");
            DropColumn("dbo.Customers", "VigorousNumberToAdd");
        }
    }
}
