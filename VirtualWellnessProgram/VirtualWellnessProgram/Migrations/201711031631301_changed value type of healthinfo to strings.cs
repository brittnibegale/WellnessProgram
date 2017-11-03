namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedvaluetypeofhealthinfotostrings : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HealthInfoes", "Age", c => c.String(nullable: false));
            AlterColumn("dbo.HealthInfoes", "Height", c => c.String(nullable: false));
            AlterColumn("dbo.HealthInfoes", "Weight", c => c.String(nullable: false));
            AlterColumn("dbo.HealthInfoes", "BodyFatAmt", c => c.String(nullable: false));
            AlterColumn("dbo.HealthInfoes", "Hdl", c => c.String(nullable: false));
            AlterColumn("dbo.HealthInfoes", "Ldl", c => c.String(nullable: false));
            AlterColumn("dbo.HealthInfoes", "CholesterolTotal", c => c.String(nullable: false));
            AlterColumn("dbo.HealthInfoes", "Triglycerides", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HealthInfoes", "Triglycerides", c => c.Double(nullable: false));
            AlterColumn("dbo.HealthInfoes", "CholesterolTotal", c => c.Double(nullable: false));
            AlterColumn("dbo.HealthInfoes", "Ldl", c => c.Double(nullable: false));
            AlterColumn("dbo.HealthInfoes", "Hdl", c => c.Double(nullable: false));
            AlterColumn("dbo.HealthInfoes", "BodyFatAmt", c => c.Double(nullable: false));
            AlterColumn("dbo.HealthInfoes", "Weight", c => c.Double(nullable: false));
            AlterColumn("dbo.HealthInfoes", "Height", c => c.Double(nullable: false));
            AlterColumn("dbo.HealthInfoes", "Age", c => c.Int(nullable: false));
        }
    }
}
