namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewResult1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReviewResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.ApplicantId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .ForeignKey("dbo.Users", t => t.ReviewerId, cascadeDelete: true)
                .Index(t => t.ReviewerId)
                .Index(t => t.ApplicantId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewResults", "ReviewerId", "dbo.Users");
            DropForeignKey("dbo.ReviewResults", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.ReviewResults", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.ReviewResults", "ApplicantId", "dbo.Applicants");
            DropIndex("dbo.ReviewResults", new[] { "LastModifiedById" });
            DropIndex("dbo.ReviewResults", new[] { "CreatedById" });
            DropIndex("dbo.ReviewResults", new[] { "ApplicantId" });
            DropIndex("dbo.ReviewResults", new[] { "ReviewerId" });
            DropTable("dbo.ReviewResults");
        }
    }
}
