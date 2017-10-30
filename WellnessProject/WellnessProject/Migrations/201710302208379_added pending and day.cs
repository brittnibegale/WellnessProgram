namespace WellnessProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpendingandday : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groups", "Person1_FirstName", "dbo.AspNetUsers");
            DropForeignKey("dbo.Groups", "Person2_FirstName", "dbo.AspNetUsers");
            DropForeignKey("dbo.Groups", "Person3_FirstName", "dbo.AspNetUsers");
            DropForeignKey("dbo.Groups", "Person4_FirstName", "dbo.AspNetUsers");
            DropIndex("dbo.Groups", new[] { "Person1_FirstName" });
            DropIndex("dbo.Groups", new[] { "Person2_FirstName" });
            DropIndex("dbo.Groups", new[] { "Person3_FirstName" });
            DropIndex("dbo.Groups", new[] { "Person4_FirstName" });
            AddColumn("dbo.AspNetUsers", "Day", c => c.DateTime(nullable: false));
            AddColumn("dbo.Calories", "Pending", c => c.Boolean(nullable: false));
            AddColumn("dbo.Exercises", "Pending", c => c.Boolean(nullable: false));
            DropColumn("dbo.Groups", "Person1_FirstName");
            DropColumn("dbo.Groups", "Person2_FirstName");
            DropColumn("dbo.Groups", "Person3_FirstName");
            DropColumn("dbo.Groups", "Person4_FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "Person4_FirstName", c => c.String(maxLength: 128));
            AddColumn("dbo.Groups", "Person3_FirstName", c => c.String(maxLength: 128));
            AddColumn("dbo.Groups", "Person2_FirstName", c => c.String(maxLength: 128));
            AddColumn("dbo.Groups", "Person1_FirstName", c => c.String(maxLength: 128));
            DropColumn("dbo.Exercises", "Pending");
            DropColumn("dbo.Calories", "Pending");
            DropColumn("dbo.AspNetUsers", "Day");
            CreateIndex("dbo.Groups", "Person4_FirstName");
            CreateIndex("dbo.Groups", "Person3_FirstName");
            CreateIndex("dbo.Groups", "Person2_FirstName");
            CreateIndex("dbo.Groups", "Person1_FirstName");
            AddForeignKey("dbo.Groups", "Person4_FirstName", "dbo.AspNetUsers", "FirstName");
            AddForeignKey("dbo.Groups", "Person3_FirstName", "dbo.AspNetUsers", "FirstName");
            AddForeignKey("dbo.Groups", "Person2_FirstName", "dbo.AspNetUsers", "FirstName");
            AddForeignKey("dbo.Groups", "Person1_FirstName", "dbo.AspNetUsers", "FirstName");
        }
    }
}
