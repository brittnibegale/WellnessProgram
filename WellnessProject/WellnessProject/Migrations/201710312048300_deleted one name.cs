namespace WellnessProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedonename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Captain", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Captain");
        }
    }
}
