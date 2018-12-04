namespace Recuiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DocumentApplicants", "Document_Id", "dbo.Documents");
            DropForeignKey("dbo.DocumentApplicants", "Applicant_Id", "dbo.Applicants");
            DropIndex("dbo.DocumentApplicants", new[] { "Document_Id" });
            DropIndex("dbo.DocumentApplicants", new[] { "Applicant_Id" });
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            AddColumn("dbo.ApplicantReviewAssessments", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicantReviewAssessments", "LastModifiedById", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationReviews", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationReviews", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.ApplicationReviews", "LastModifiedById", c => c.Int(nullable: false));
            AddColumn("dbo.Applications", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Applications", "LastModifiedById", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Applicants", "LastModifiedById", c => c.Int(nullable: false));
            AddColumn("dbo.Documents", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Documents", "FilePath", c => c.String());
            AddColumn("dbo.Jobs", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Jobs", "LastModifiedById", c => c.Int(nullable: false));
            AddColumn("dbo.Departments", "HoDId", c => c.Int());
            AddColumn("dbo.Departments", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.Departments", "LastModifiedById", c => c.Int(nullable: false));
            AddColumn("dbo.InterviewQuestions", "CreatedById", c => c.Int(nullable: false));
            AddColumn("dbo.InterviewQuestions", "LastModifiedById", c => c.Int(nullable: false));
            CreateIndex("dbo.Applicants", "CreatedById");
            CreateIndex("dbo.Applicants", "LastModifiedById");
            CreateIndex("dbo.Departments", "HoDId");
            CreateIndex("dbo.Departments", "CreatedById");
            CreateIndex("dbo.Departments", "LastModifiedById");
            CreateIndex("dbo.Documents", "UserId");
            CreateIndex("dbo.ApplicantReviewAssessments", "CreatedById");
            CreateIndex("dbo.ApplicantReviewAssessments", "LastModifiedById");
            CreateIndex("dbo.ApplicationReviews", "UserId");
            CreateIndex("dbo.ApplicationReviews", "CreatedById");
            CreateIndex("dbo.ApplicationReviews", "LastModifiedById");
            CreateIndex("dbo.Applications", "CreatedById");
            CreateIndex("dbo.Applications", "LastModifiedById");
            CreateIndex("dbo.Jobs", "CreatedById");
            CreateIndex("dbo.Jobs", "LastModifiedById");
            CreateIndex("dbo.InterviewQuestions", "CreatedById");
            CreateIndex("dbo.InterviewQuestions", "LastModifiedById");
            AddForeignKey("dbo.Departments", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.Departments", "HoDId", "dbo.Users", "Id");
            AddForeignKey("dbo.Departments", "LastModifiedById", "dbo.Users", "Id");
            AddForeignKey("dbo.Applicants", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.Applicants", "LastModifiedById", "dbo.Users", "Id");
            AddForeignKey("dbo.Documents", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Applications", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.Jobs", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.Jobs", "LastModifiedById", "dbo.Users", "Id");
            AddForeignKey("dbo.Applications", "LastModifiedById", "dbo.Users", "Id");
            AddForeignKey("dbo.ApplicationReviews", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.ApplicationReviews", "LastModifiedById", "dbo.Users", "Id");
            AddForeignKey("dbo.ApplicationReviews", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.ApplicantReviewAssessments", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.InterviewQuestions", "CreatedById", "dbo.Users", "Id");
            AddForeignKey("dbo.InterviewQuestions", "LastModifiedById", "dbo.Users", "Id");
            AddForeignKey("dbo.ApplicantReviewAssessments", "LastModifiedById", "dbo.Users", "Id");
            DropColumn("dbo.Documents", "IsDeleted");
            DropTable("dbo.DocumentApplicants");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DocumentApplicants",
                c => new
                    {
                        Document_Id = c.Int(nullable: false),
                        Applicant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Document_Id, t.Applicant_Id });
            
            AddColumn("dbo.Documents", "IsDeleted", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ApplicantReviewAssessments", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.InterviewQuestions", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.InterviewQuestions", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ApplicantReviewAssessments", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ApplicationReviews", "UserId", "dbo.Users");
            DropForeignKey("dbo.ApplicationReviews", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.ApplicationReviews", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Applications", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Jobs", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Jobs", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Applications", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ApplicantDocuments", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "UserId", "dbo.Users");
            DropForeignKey("dbo.ApplicantDocuments", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.Applicants", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Applicants", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Departments", "HoDId", "dbo.Users");
            DropForeignKey("dbo.Departments", "CreatedById", "dbo.Users");
            DropIndex("dbo.InterviewQuestions", new[] { "LastModifiedById" });
            DropIndex("dbo.InterviewQuestions", new[] { "CreatedById" });
            DropIndex("dbo.Jobs", new[] { "LastModifiedById" });
            DropIndex("dbo.Jobs", new[] { "CreatedById" });
            DropIndex("dbo.Applications", new[] { "LastModifiedById" });
            DropIndex("dbo.Applications", new[] { "CreatedById" });
            DropIndex("dbo.ApplicationReviews", new[] { "LastModifiedById" });
            DropIndex("dbo.ApplicationReviews", new[] { "CreatedById" });
            DropIndex("dbo.ApplicationReviews", new[] { "UserId" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "LastModifiedById" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "CreatedById" });
            DropIndex("dbo.Documents", new[] { "UserId" });
            DropIndex("dbo.Departments", new[] { "LastModifiedById" });
            DropIndex("dbo.Departments", new[] { "CreatedById" });
            DropIndex("dbo.Departments", new[] { "HoDId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.Applicants", new[] { "LastModifiedById" });
            DropIndex("dbo.Applicants", new[] { "CreatedById" });
            DropIndex("dbo.ApplicantDocuments", new[] { "ApplicantId" });
            DropIndex("dbo.ApplicantDocuments", new[] { "DocumentId" });
            DropColumn("dbo.InterviewQuestions", "LastModifiedById");
            DropColumn("dbo.InterviewQuestions", "CreatedById");
            DropColumn("dbo.Departments", "LastModifiedById");
            DropColumn("dbo.Departments", "CreatedById");
            DropColumn("dbo.Departments", "HoDId");
            DropColumn("dbo.Jobs", "LastModifiedById");
            DropColumn("dbo.Jobs", "CreatedById");
            DropColumn("dbo.Documents", "FilePath");
            DropColumn("dbo.Documents", "UserId");
            DropColumn("dbo.Applicants", "LastModifiedById");
            DropColumn("dbo.Applicants", "CreatedById");
            DropColumn("dbo.Applications", "LastModifiedById");
            DropColumn("dbo.Applications", "CreatedById");
            DropColumn("dbo.ApplicationReviews", "LastModifiedById");
            DropColumn("dbo.ApplicationReviews", "CreatedById");
            DropColumn("dbo.ApplicationReviews", "UserId");
            DropColumn("dbo.ApplicantReviewAssessments", "LastModifiedById");
            DropColumn("dbo.ApplicantReviewAssessments", "CreatedById");
            DropTable("dbo.Users");
            DropTable("dbo.ApplicantDocuments");
            CreateIndex("dbo.DocumentApplicants", "Applicant_Id");
            CreateIndex("dbo.DocumentApplicants", "Document_Id");
            AddForeignKey("dbo.DocumentApplicants", "Applicant_Id", "dbo.Applicants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DocumentApplicants", "Document_Id", "dbo.Documents", "Id", cascadeDelete: true);
        }
    }
}
