namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_education : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicants", t => t.Applicant_Id)
                .Index(t => t.Applicant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Educations", "Applicant_Id", "dbo.Applicants");
            DropIndex("dbo.Educations", new[] { "Applicant_Id" });
            DropTable("dbo.Educations");
        }
    }
}
