namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedJobModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jobs", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.JobViewModels", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Jobs", new[] { "DepartmentId" });
            DropIndex("dbo.JobViewModels", new[] { "DepartmentId" });
            AddColumn("dbo.Jobs", "Characteristics", c => c.String(nullable: false));
            AddColumn("dbo.JobViewModels", "Characteristics", c => c.String(nullable: false));
            DropColumn("dbo.Jobs", "JobId");
            DropColumn("dbo.Jobs", "DepartmentId");
            DropColumn("dbo.Jobs", "Summary");
            DropColumn("dbo.Jobs", "GeneralRequirement");
            DropColumn("dbo.JobViewModels", "JobId");
            DropColumn("dbo.JobViewModels", "Summary");
            DropColumn("dbo.JobViewModels", "GeneralRequirement");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobViewModels", "GeneralRequirement", c => c.String(nullable: false));
            AddColumn("dbo.JobViewModels", "Summary", c => c.String(nullable: false));
            AddColumn("dbo.JobViewModels", "JobId", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "GeneralRequirement", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "Summary", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "JobId", c => c.Int(nullable: false));
            DropColumn("dbo.JobViewModels", "Characteristics");
            DropColumn("dbo.Jobs", "Characteristics");
            CreateIndex("dbo.JobViewModels", "DepartmentId");
            CreateIndex("dbo.Jobs", "DepartmentId");
            AddForeignKey("dbo.JobViewModels", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Jobs", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
