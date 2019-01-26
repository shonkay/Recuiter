namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fresh : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicantDocuments",
                c => new
                    {
                        DocumentId = c.Int(nullable: false),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DocumentId, t.ApplicantId })
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.DocumentId)
                .Index(t => t.ApplicantId);
            
            CreateTable(
                "dbo.Applicants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        YearsOfExperience = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        EducationLevel = c.Int(nullable: false),
                        Bio = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(),
                        LastModifiedById = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        Username = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DepartmentId = c.Int(),
                        ResetPasswordCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        HoDId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.HoDId)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .Index(t => t.HoDId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        Role_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById)
                .Index(t => t.Role_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        FilePath = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicantProfileViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicantId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        CompleteAddress = c.String(),
                        YearsOfExperience = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        EducationLevel = c.Int(nullable: false),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.ApplicantId)
                .Index(t => t.DocumentId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UserId = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicantReviewAssessments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterviewQuestionId = c.Int(nullable: false),
                        ApplicationReviewId = c.Int(nullable: false),
                        Response = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationReviews", t => t.ApplicationReviewId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.InterviewQuestions", t => t.InterviewQuestionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .Index(t => t.InterviewQuestionId)
                .Index(t => t.ApplicationReviewId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.ApplicationReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewerId = c.Int(nullable: false),
                        ApplicationId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .ForeignKey("dbo.Users", t => t.ReviewerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.ReviewerId)
                .Index(t => t.ApplicationId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicantId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .Index(t => t.ApplicantId)
                .Index(t => t.JobId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.Jobs",
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
                        IsApproved = c.Boolean(nullable: false),
                        IsPublished = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .Index(t => t.DepartmentId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.InterviewQuestions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(),
                        Question = c.String(),
                        IsGeneral = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .Index(t => t.DepartmentId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.DocumentApplicants",
                c => new
                    {
                        Document_Id = c.Int(nullable: false),
                        Applicant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Document_Id, t.Applicant_Id })
                .ForeignKey("dbo.Documents", t => t.Document_Id, cascadeDelete: true)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id, cascadeDelete: true)
                .Index(t => t.Document_Id)
                .Index(t => t.Applicant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicantReviewAssessments", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.ApplicantReviewAssessments", "InterviewQuestionId", "dbo.InterviewQuestions");
            DropForeignKey("dbo.InterviewQuestions", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.InterviewQuestions", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.InterviewQuestions", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ApplicantReviewAssessments", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ApplicationReviews", "User_Id", "dbo.Users");
            DropForeignKey("dbo.ApplicantReviewAssessments", "ApplicationReviewId", "dbo.ApplicationReviews");
            DropForeignKey("dbo.ApplicationReviews", "ReviewerId", "dbo.Users");
            DropForeignKey("dbo.ApplicationReviews", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.ApplicationReviews", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ApplicationReviews", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Applications", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Applications", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Jobs", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Jobs", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Applications", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Applications", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.ApplicantProfileViewModels", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Images", "UserId", "dbo.Users");
            DropForeignKey("dbo.ApplicantProfileViewModels", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.ApplicantProfileViewModels", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.ApplicantDocuments", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.ApplicantDocuments", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "UserId", "dbo.Users");
            DropForeignKey("dbo.Applicants", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Documents", "UserId", "dbo.Users");
            DropForeignKey("dbo.DocumentApplicants", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.DocumentApplicants", "Document_Id", "dbo.Documents");
            DropForeignKey("dbo.Applicants", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Roles", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Roles", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Users", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Departments", "HoDId", "dbo.Users");
            DropForeignKey("dbo.Departments", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Users", "CreatedById", "dbo.Users");
            DropIndex("dbo.DocumentApplicants", new[] { "Applicant_Id" });
            DropIndex("dbo.DocumentApplicants", new[] { "Document_Id" });
            DropIndex("dbo.InterviewQuestions", new[] { "LastModifiedById" });
            DropIndex("dbo.InterviewQuestions", new[] { "CreatedById" });
            DropIndex("dbo.InterviewQuestions", new[] { "DepartmentId" });
            DropIndex("dbo.Jobs", new[] { "LastModifiedById" });
            DropIndex("dbo.Jobs", new[] { "CreatedById" });
            DropIndex("dbo.Jobs", new[] { "DepartmentId" });
            DropIndex("dbo.Applications", new[] { "LastModifiedById" });
            DropIndex("dbo.Applications", new[] { "CreatedById" });
            DropIndex("dbo.Applications", new[] { "JobId" });
            DropIndex("dbo.Applications", new[] { "ApplicantId" });
            DropIndex("dbo.ApplicationReviews", new[] { "User_Id" });
            DropIndex("dbo.ApplicationReviews", new[] { "LastModifiedById" });
            DropIndex("dbo.ApplicationReviews", new[] { "CreatedById" });
            DropIndex("dbo.ApplicationReviews", new[] { "ApplicationId" });
            DropIndex("dbo.ApplicationReviews", new[] { "ReviewerId" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "LastModifiedById" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "CreatedById" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "ApplicationReviewId" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "InterviewQuestionId" });
            DropIndex("dbo.Images", new[] { "UserId" });
            DropIndex("dbo.ApplicantProfileViewModels", new[] { "ImageId" });
            DropIndex("dbo.ApplicantProfileViewModels", new[] { "DocumentId" });
            DropIndex("dbo.ApplicantProfileViewModels", new[] { "ApplicantId" });
            DropIndex("dbo.Documents", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "LastModifiedById" });
            DropIndex("dbo.Roles", new[] { "CreatedById" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
            DropIndex("dbo.UserRoles", new[] { "Role_Id" });
            DropIndex("dbo.UserRoles", new[] { "LastModifiedById" });
            DropIndex("dbo.UserRoles", new[] { "CreatedById" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Departments", new[] { "LastModifiedById" });
            DropIndex("dbo.Departments", new[] { "CreatedById" });
            DropIndex("dbo.Departments", new[] { "HoDId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.Users", new[] { "LastModifiedById" });
            DropIndex("dbo.Users", new[] { "CreatedById" });
            DropIndex("dbo.Applicants", new[] { "LastModifiedById" });
            DropIndex("dbo.Applicants", new[] { "CreatedById" });
            DropIndex("dbo.Applicants", new[] { "UserId" });
            DropIndex("dbo.ApplicantDocuments", new[] { "ApplicantId" });
            DropIndex("dbo.ApplicantDocuments", new[] { "DocumentId" });
            DropTable("dbo.DocumentApplicants");
            DropTable("dbo.InterviewQuestions");
            DropTable("dbo.Jobs");
            DropTable("dbo.Applications");
            DropTable("dbo.ApplicationReviews");
            DropTable("dbo.ApplicantReviewAssessments");
            DropTable("dbo.Images");
            DropTable("dbo.ApplicantProfileViewModels");
            DropTable("dbo.Documents");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Departments");
            DropTable("dbo.Users");
            DropTable("dbo.Applicants");
            DropTable("dbo.ApplicantDocuments");
        }
    }
}
