namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LastModifiedDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Applicants", "LastModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Departments", "LastModifiedDate", c => c.DateTime());
            AlterColumn("dbo.UserRoles", "LastModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Roles", "LastModifiedDate", c => c.DateTime());
            AlterColumn("dbo.ApplicantReviewAssessments", "LastModifiedDate", c => c.DateTime());
            AlterColumn("dbo.ApplicationReviews", "LastModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Applications", "LastModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Jobs", "LastModifiedDate", c => c.DateTime());
            AlterColumn("dbo.InterviewQuestions", "LastModifiedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InterviewQuestions", "LastModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "LastModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Applications", "LastModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ApplicationReviews", "LastModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ApplicantReviewAssessments", "LastModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Roles", "LastModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserRoles", "LastModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "LastModifiedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Applicants", "LastModifiedDate", c => c.DateTime(nullable: false));
        }
    }
}
