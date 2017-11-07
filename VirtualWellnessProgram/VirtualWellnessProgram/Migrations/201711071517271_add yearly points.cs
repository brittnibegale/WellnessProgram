namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addyearlypoints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ExerciseMonthlyPoints", c => c.Double());
            AddColumn("dbo.Customers", "ExerciseYearlyPoints", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "ExerciseYearlyPoints");
            DropColumn("dbo.Customers", "ExerciseMonthlyPoints");
        }
    }
}
