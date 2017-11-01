namespace VirtualWellnessProgram.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcodetoidentity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Code", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Code");
        }
    }
}
