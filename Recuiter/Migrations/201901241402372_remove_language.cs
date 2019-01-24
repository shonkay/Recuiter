namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_language : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Educations", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.Languages", "ApplicantId", "dbo.Applicants");
            DropIndex("dbo.Educations", new[] { "Applicant_Id1" });
            DropIndex("dbo.Languages", new[] { "ApplicantId" });
            DropColumn("dbo.Educations", "Applicant_Id");
            RenameColumn(table: "dbo.Educations", name: "Applicant_Id1", newName: "Applicant_Id");
            AddColumn("dbo.Applicants", "Languages", c => c.String());
            DropTable("dbo.Languages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ApplicantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Applicants", "Languages");
            RenameColumn(table: "dbo.Educations", name: "Applicant_Id", newName: "Applicant_Id1");
            AddColumn("dbo.Educations", "Applicant_Id", c => c.Int());
            CreateIndex("dbo.Languages", "ApplicantId");
            CreateIndex("dbo.Educations", "Applicant_Id1");
            AddForeignKey("dbo.Languages", "ApplicantId", "dbo.Applicants", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Educations", "Applicant_Id", "dbo.Applicants", "Id");
        }
    }
}
