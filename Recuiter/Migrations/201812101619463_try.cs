namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _try : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "LastModifiedById", "dbo.Users");
            DropIndex("dbo.Applicants", new[] { "CreatedById" });
            DropIndex("dbo.Applicants", new[] { "LastModifiedById" });
            DropIndex("dbo.Departments", new[] { "LastModifiedById" });
            DropIndex("dbo.Roles", new[] { "LastModifiedById" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "LastModifiedById" });
            DropIndex("dbo.ApplicationReviews", new[] { "LastModifiedById" });
            DropIndex("dbo.Applications", new[] { "CreatedById" });
            DropIndex("dbo.Applications", new[] { "LastModifiedById" });
            DropIndex("dbo.Jobs", new[] { "CreatedById" });
            DropIndex("dbo.Jobs", new[] { "LastModifiedById" });
            DropIndex("dbo.InterviewQuestions", new[] { "LastModifiedById" });
            AlterColumn("dbo.Applicants", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Applicants", "LastModifiedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Departments", "LastModifiedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Roles", "LastModifiedById", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicantReviewAssessments", "LastModifiedById", c => c.Int(nullable: false));
            AlterColumn("dbo.ApplicationReviews", "LastModifiedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Applications", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Applications", "LastModifiedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "CreatedById", c => c.Int(nullable: false));
            AlterColumn("dbo.Jobs", "LastModifiedById", c => c.Int(nullable: false));
            AlterColumn("dbo.InterviewQuestions", "LastModifiedById", c => c.Int(nullable: false));
            CreateIndex("dbo.Applicants", "CreatedById");
            CreateIndex("dbo.Applicants", "LastModifiedById");
            CreateIndex("dbo.Departments", "LastModifiedById");
            CreateIndex("dbo.Roles", "LastModifiedById");
            CreateIndex("dbo.ApplicantReviewAssessments", "LastModifiedById");
            CreateIndex("dbo.ApplicationReviews", "LastModifiedById");
            CreateIndex("dbo.Applications", "CreatedById");
            CreateIndex("dbo.Applications", "LastModifiedById");
            CreateIndex("dbo.Jobs", "CreatedById");
            CreateIndex("dbo.Jobs", "LastModifiedById");
            CreateIndex("dbo.InterviewQuestions", "LastModifiedById");
            AddForeignKey("dbo.Roles", "LastModifiedById", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Roles", "LastModifiedById", "dbo.Users");
            DropIndex("dbo.InterviewQuestions", new[] { "LastModifiedById" });
            DropIndex("dbo.Jobs", new[] { "LastModifiedById" });
            DropIndex("dbo.Jobs", new[] { "CreatedById" });
            DropIndex("dbo.Applications", new[] { "LastModifiedById" });
            DropIndex("dbo.Applications", new[] { "CreatedById" });
            DropIndex("dbo.ApplicationReviews", new[] { "LastModifiedById" });
            DropIndex("dbo.ApplicantReviewAssessments", new[] { "LastModifiedById" });
            DropIndex("dbo.Roles", new[] { "LastModifiedById" });
            DropIndex("dbo.Departments", new[] { "LastModifiedById" });
            DropIndex("dbo.Applicants", new[] { "LastModifiedById" });
            DropIndex("dbo.Applicants", new[] { "CreatedById" });
            AlterColumn("dbo.InterviewQuestions", "LastModifiedById", c => c.Int());
            AlterColumn("dbo.Jobs", "LastModifiedById", c => c.Int());
            AlterColumn("dbo.Jobs", "CreatedById", c => c.Int());
            AlterColumn("dbo.Applications", "LastModifiedById", c => c.Int());
            AlterColumn("dbo.Applications", "CreatedById", c => c.Int());
            AlterColumn("dbo.ApplicationReviews", "LastModifiedById", c => c.Int());
            AlterColumn("dbo.ApplicantReviewAssessments", "LastModifiedById", c => c.Int());
            AlterColumn("dbo.Roles", "LastModifiedById", c => c.Int());
            AlterColumn("dbo.Departments", "LastModifiedById", c => c.Int());
            AlterColumn("dbo.Applicants", "LastModifiedById", c => c.Int());
            AlterColumn("dbo.Applicants", "CreatedById", c => c.Int());
            CreateIndex("dbo.InterviewQuestions", "LastModifiedById");
            CreateIndex("dbo.Jobs", "LastModifiedById");
            CreateIndex("dbo.Jobs", "CreatedById");
            CreateIndex("dbo.Applications", "LastModifiedById");
            CreateIndex("dbo.Applications", "CreatedById");
            CreateIndex("dbo.ApplicationReviews", "LastModifiedById");
            CreateIndex("dbo.ApplicantReviewAssessments", "LastModifiedById");
            CreateIndex("dbo.Roles", "LastModifiedById");
            CreateIndex("dbo.Departments", "LastModifiedById");
            CreateIndex("dbo.Applicants", "LastModifiedById");
            CreateIndex("dbo.Applicants", "CreatedById");
            AddForeignKey("dbo.Roles", "LastModifiedById", "dbo.Users", "Id");
        }
    }
}
