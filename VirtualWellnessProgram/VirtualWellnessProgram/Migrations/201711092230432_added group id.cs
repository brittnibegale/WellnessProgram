namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgroupid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalorieAlerts", "Group", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalorieAlerts", "Group");
        }
    }
}
