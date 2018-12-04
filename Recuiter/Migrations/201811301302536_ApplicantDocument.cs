namespace Recuiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicantDocument : DbMigration
    {
        public override void Up()
        {
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
            DropForeignKey("dbo.DocumentApplicants", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.DocumentApplicants", "Document_Id", "dbo.Documents");
            DropIndex("dbo.DocumentApplicants", new[] { "Applicant_Id" });
            DropIndex("dbo.DocumentApplicants", new[] { "Document_Id" });
            DropTable("dbo.DocumentApplicants");
        }
    }
}
