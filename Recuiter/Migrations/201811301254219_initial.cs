namespace Recuiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationReviews", t => t.ApplicationReviewId, cascadeDelete: true)
                .ForeignKey("dbo.InterviewQuestions", t => t.InterviewQuestionId, cascadeDelete: true)
                .Index(t => t.InterviewQuestionId)
                .Index(t => t.ApplicationReviewId);
            
            CreateTable(
                "dbo.ApplicationReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .Index(t => t.ApplicationId);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .Index(t => t.ApplicantId)
                .Index(t => t.JobId);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicantReviewAssessments", "InterviewQuestionId", "dbo.InterviewQuestions");
            DropForeignKey("dbo.InterviewQuestions", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.ApplicantReviewAssessments", "ApplicationReviewId", "dbo.ApplicationReviews");
            DropForeignKey("dbo.ApplicationReviews", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Applications", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Applications", "ApplicantId", "dbo.Applicants");
            DropIndex("dbo.InterviewQuestions", new[] { "DepartmentId" });
            DropIndex("dbo.Jobs", new[] { "DepartmentId" });
            DropIndex("dbo.Applications", new[] { "JobId" });
            DropIndex("dbo.Applications", new[] { "ApplicantId" });
            DropIndex("dbo.ApplicationReviews", new[] { "ApplicationId" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "ApplicationReviewId" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "InterviewQuestionId" });
            DropTable("dbo.Documents");
            DropTable("dbo.InterviewQuestions");
            DropTable("dbo.Departments");
            DropTable("dbo.Jobs");
            DropTable("dbo.Applicants");
            DropTable("dbo.Applications");
            DropTable("dbo.ApplicationReviews");
            DropTable("dbo.ApplicantReviewAssessments");
        }
    }
}
