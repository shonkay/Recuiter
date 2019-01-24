namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remveedcatn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Educations", "Applicant_Id", "dbo.Applicants");
            DropIndex("dbo.Educations", new[] { "Applicant_Id" });
            DropTable("dbo.Educations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Educations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qualification = c.String(),
                        FromDate = c.Int(nullable: false),
                        ToDate = c.Int(nullable: false),
                        Institution = c.String(),
                        CourseStudied = c.String(),
                        Applicant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Educations", "Applicant_Id");
            AddForeignKey("dbo.Educations", "Applicant_Id", "dbo.Applicants", "Id");
        }
    }
}
