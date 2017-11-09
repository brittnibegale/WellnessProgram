namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class audit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        AuditId = c.Guid(nullable: false),
                        UserName = c.String(),
                        IpAddress = c.String(),
                        AreaAccessed = c.String(),
                        Timestamp = c.String(),
                    })
                .PrimaryKey(t => t.AuditId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Audits");
        }
    }
}
