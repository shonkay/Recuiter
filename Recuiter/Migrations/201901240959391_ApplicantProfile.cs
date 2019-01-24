namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicantProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Educations", "Applicant_Id", "dbo.Applicants");
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        City = c.String(),
                        Code = c.String(),
                        Applicant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .Index(t => t.Applicant_Id);
            
            AddColumn("dbo.Educations", "Applicant_Id1", c => c.Int());
            CreateIndex("dbo.Educations", "Applicant_Id1");
            AddForeignKey("dbo.Educations", "Applicant_Id", "dbo.Applicants", "Id");
            AddForeignKey("dbo.Educations", "Applicant_Id1", "dbo.Applicants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "Applicant_Id1", "dbo.Applicants");
            DropForeignKey("dbo.Institutions", "Applicant_Id", "dbo.Applicants");
            DropForeignKey("dbo.Educations", "Applicant_Id", "dbo.Applicants");
            DropIndex("dbo.Institutions", new[] { "Applicant_Id" });
            DropIndex("dbo.Educations", new[] { "Applicant_Id1" });
            DropColumn("dbo.Educations", "Applicant_Id1");
            DropTable("dbo.Institutions");
            AddForeignKey("dbo.Educations", "Applicant_Id", "dbo.Applicants", "Id");
        }
    }
}
