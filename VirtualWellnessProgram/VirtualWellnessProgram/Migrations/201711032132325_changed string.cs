namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HealthInfoes", "Smoker", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HealthInfoes", "Smoker", c => c.Boolean(nullable: false));
        }
    }
}
