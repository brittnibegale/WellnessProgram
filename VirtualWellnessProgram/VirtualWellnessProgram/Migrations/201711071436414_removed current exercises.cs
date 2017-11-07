namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedcurrentexercises : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "CurrentVigorousDuration");
            DropColumn("dbo.Customers", "CurrentModerateDuration");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CurrentModerateDuration", c => c.Double());
            AddColumn("dbo.Customers", "CurrentVigorousDuration", c => c.Double());
        }
    }
}
