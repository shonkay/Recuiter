namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedById : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Applicants", new[] { "CreatedById" });
            DropIndex("dbo.Applications", new[] { "CreatedById" });
            DropIndex("dbo.Jobs", new[] { "CreatedById" });
            AlterColumn("dbo.Applicants", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Applications", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "CreatedById", c => c.Int(nullable: false));
            CreateIndex("dbo.Applicants", "CreatedById");
            CreateIndex("dbo.Applications", "CreatedById");
            CreateIndex("dbo.Jobs", "CreatedById");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Jobs", new[] { "CreatedById" });
            DropIndex("dbo.Applications", new[] { "CreatedById" });
            DropIndex("dbo.Applicants", new[] { "CreatedById" });
            AlterColumn("dbo.Jobs", "CreatedById", c => c.Int());
            AlterColumn("dbo.Applications", "CreatedById", c => c.Int());
            AlterColumn("dbo.Applicants", "CreatedById", c => c.Int());
            CreateIndex("dbo.Jobs", "CreatedById");
            CreateIndex("dbo.Applications", "CreatedById");
            CreateIndex("dbo.Applicants", "CreatedById");
        }
    }
}
