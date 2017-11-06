namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcurrent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExerciseAlerts", "currentVigorous", c => c.Double(nullable: false));
            AddColumn("dbo.ExerciseAlerts", "currentModerate", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExerciseAlerts", "currentModerate");
            DropColumn("dbo.ExerciseAlerts", "currentVigorous");
        }
    }
}
