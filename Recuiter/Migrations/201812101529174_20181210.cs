namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20181210 : DbMigration
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
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                        LastModifiedById = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DepartmentId = c.Int(),
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
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
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
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.LastModifiedById, cascadeDelete: true)
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
                "dbo.ApplicantReviewAssessments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InterviewQuestionId = c.Int(nullable: false),
                        ApplicationReviewId = c.Int(nullable: false),
                        Response = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
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
                        UserId = c.Int(nullable: false),
                        ApplicationId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ApplicationId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicantId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        Status = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
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
                        JobDescription = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
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
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .Index(t => t.DepartmentId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicantReviewAssessments", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.ApplicantReviewAssessments", "InterviewQuestionId", "dbo.InterviewQuestions");
            DropForeignKey("dbo.InterviewQuestions", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.InterviewQuestions", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.InterviewQuestions", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ApplicantReviewAssessments", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ApplicationReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.ApplicantReviewAssessments", "ApplicationReviewId", "dbo.ApplicationReviews");
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
            DropForeignKey("dbo.ApplicantDocuments", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "UserId", "dbo.Users");
            DropForeignKey("dbo.ApplicantDocuments", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Applicants", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
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
            DropIndex("dbo.ApplicationReviews", new[] { "LastModifiedById" });
            DropIndex("dbo.ApplicationReviews", new[] { "CreatedById" });
            DropIndex("dbo.ApplicationReviews", new[] { "ApplicationId" });
            DropIndex("dbo.ApplicationReviews", new[] { "UserId" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "LastModifiedById" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "CreatedById" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "ApplicationReviewId" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "InterviewQuestionId" });
            DropIndex("dbo.Documents", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "LastModifiedById" });
            DropIndex("dbo.Roles", new[] { "CreatedById" });
            DropIndex("dbo.UserRoles", new[] { "User_Id" });
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
            DropIndex("dbo.ApplicantDocuments", new[] { "ApplicantId" });
            DropIndex("dbo.ApplicantDocuments", new[] { "DocumentId" });
            DropTable("dbo.InterviewQuestions");
            DropTable("dbo.Jobs");
            DropTable("dbo.Applications");
            DropTable("dbo.ApplicationReviews");
            DropTable("dbo.ApplicantReviewAssessments");
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
