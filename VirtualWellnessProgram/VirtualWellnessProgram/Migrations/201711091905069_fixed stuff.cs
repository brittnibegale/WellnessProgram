namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedstuff : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Audits");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Audits",
                c => new
                    {
                        AuditId = c.Guid(nullable: false),
                        UserName = c.String(),
                        AreaAccessed = c.String(),
                        Timestamp = c.String(),
                    })
                .PrimaryKey(t => t.AuditId);
            
        }
    }
}
