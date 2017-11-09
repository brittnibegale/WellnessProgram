namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class there : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExerciseAlerts", "Group", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ExerciseAlerts", "Group");
        }
    }
}
