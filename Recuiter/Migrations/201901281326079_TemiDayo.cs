namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TemiDayo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.JobViewModels", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ReviewResults", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.ReviewResults", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ReviewResults", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.ReviewResults", "ReviewerId", "dbo.Users");
            DropIndex("dbo.JobViewModels", new[] { "DepartmentId" });
            DropIndex("dbo.ReviewResults", new[] { "ReviewerId" });
            DropIndex("dbo.ReviewResults", new[] { "ApplicantId" });
            DropIndex("dbo.ReviewResults", new[] { "CreatedById" });
            DropIndex("dbo.ReviewResults", new[] { "LastModifiedById" });
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(),
                        Details = c.String(),
                        Title = c.String(),
                        DetailsURL = c.String(),
                        SentTo = c.String(),
                        Date = c.DateTime(),
                        IsRead = c.Boolean(),
                        IsDeleted = c.Boolean(),
                        IsReminder = c.Boolean(),
                        Code = c.String(),
                        NotificationType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Applicants", "JobTitle");
            DropColumn("dbo.Applicants", "Specialization");
            DropTable("dbo.JobViewModels");
            DropTable("dbo.ReviewResults");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReviewResults",
                c => new
                    {
                        ReviewerId = c.Int(nullable: false),
                        ApplicantId = c.Int(nullable: false),
                        Appearance = c.Int(nullable: false),
                        Disposition = c.Int(nullable: false),
                        Communication = c.Int(nullable: false),
                        EducationalQualification = c.Int(nullable: false),
                        RelevantExperience = c.Int(nullable: false),
                        RelevantTechnicalExperience = c.Int(nullable: false),
                        AnalyticalReasoningAbility = c.Int(nullable: false),
                        GeneralKnowledge = c.Int(nullable: false),
                        EstimateOfIntelligence = c.Int(nullable: false),
                        GeneralRemark = c.String(),
                        Recommendation = c.String(),
                        TotalScore = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                    })
                .PrimaryKey(t => new { t.ReviewerId, t.ApplicantId });
            
            CreateTable(
                "dbo.JobViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Summary = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Responsibility = c.String(nullable: false),
                        GeneralRequirement = c.String(nullable: false),
                        SkillSet = c.String(nullable: false),
                        MinimumQualification = c.Int(nullable: false),
                        ExperienceLevel = c.Int(nullable: false),
                        ExperienceLength = c.Int(nullable: false),
                        ContractClass = c.Int(nullable: false),
                        ContractLength = c.String(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Applicants", "Specialization", c => c.String());
            AddColumn("dbo.Applicants", "JobTitle", c => c.String());
            DropTable("dbo.Notifications");
            CreateIndex("dbo.ReviewResults", "LastModifiedById");
            CreateIndex("dbo.ReviewResults", "CreatedById");
            CreateIndex("dbo.ReviewResults", "ApplicantId");
            CreateIndex("dbo.ReviewResults", "ReviewerId");
            CreateIndex("dbo.JobViewModels", "DepartmentId");
            AddForeignKey("dbo.ReviewResults", "ReviewerId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReviewResults", "LastModifiedById", "dbo.Users", "Id");
            AddForeignKey("dbo.ReviewResults", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.ReviewResults", "ApplicantId", "dbo.Applicants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.JobViewModels", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
