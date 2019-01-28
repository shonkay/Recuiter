namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Summary = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Responsibility = c.String(nullable: false),
                        GeneralRequirement = c.String(nullable: false),
                        SkillSet = c.String(nullable: false),
                        MinimumQualification = c.Int(nullable: false),
                        ExperienceLevel = c.Int(nullable: false),
                        ExperienceLength = c.Int(nullable: false),
                        ContractClass = c.Int(nullable: false),
                        ContractLength = c.String(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        CreatedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobViewModels", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.JobViewModels", new[] { "DepartmentId" });
            DropTable("dbo.JobViewModels");
        }
    }
}
