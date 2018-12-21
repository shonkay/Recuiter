namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VacancyModule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Title", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "Summary", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "Responsibility", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "GeneralRequirement", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "SkillSet", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "MinimumQualification", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "ExperienceLevel", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "ExperienceLength", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "ContractClass", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "ContractLength", c => c.String(nullable: false));
            AddColumn("dbo.Jobs", "ExpiryDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Jobs", "IsApproved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Jobs", "IsPublished", c => c.Boolean(nullable: false));
            DropColumn("dbo.Jobs", "JobDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "JobDescription", c => c.String());
            DropColumn("dbo.Jobs", "IsPublished");
            DropColumn("dbo.Jobs", "IsApproved");
            DropColumn("dbo.Jobs", "ExpiryDate");
            DropColumn("dbo.Jobs", "ContractLength");
            DropColumn("dbo.Jobs", "ContractClass");
            DropColumn("dbo.Jobs", "ExperienceLength");
            DropColumn("dbo.Jobs", "ExperienceLevel");
            DropColumn("dbo.Jobs", "MinimumQualification");
            DropColumn("dbo.Jobs", "SkillSet");
            DropColumn("dbo.Jobs", "GeneralRequirement");
            DropColumn("dbo.Jobs", "Responsibility");
            DropColumn("dbo.Jobs", "Description");
            DropColumn("dbo.Jobs", "Summary");
            DropColumn("dbo.Jobs", "Title");
        }
    }
}
