namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class work : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Audits", "IpAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Audits", "IpAddress", c => c.String());
        }
    }
}
