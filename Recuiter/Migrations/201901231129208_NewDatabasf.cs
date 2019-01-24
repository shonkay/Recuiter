namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDatabasf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicantProfileViewModels", "ApplicantId", "dbo.Applicants");
            DropForeignKey("dbo.ApplicantDocumentViewModels", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels");
            DropForeignKey("dbo.Images", "UserId", "dbo.Users");
            DropForeignKey("dbo.ApplicantProfileViewModels", "ImageId", "dbo.Images");
            DropIndex("dbo.ApplicantProfileViewModels", new[] { "ApplicantId" });
            DropIndex("dbo.ApplicantProfileViewModels", new[] { "ImageId" });
            DropIndex("dbo.ApplicantDocumentViewModels", new[] { "ApplicantProfileViewModels_Id" });
            DropIndex("dbo.Images", new[] { "UserId" });
            DropTable("dbo.ApplicantProfileViewModels");
            DropTable("dbo.ApplicantDocumentViewModels");
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        UserId = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicantDocumentViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FilePath = c.String(),
                        Type = c.Int(nullable: false),
                        ApplicantProfileViewModels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicantProfileViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicantId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        CompleteAddress = c.String(),
                        YearsOfExperience = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        EducationLevel = c.Int(nullable: false),
                        Bio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Images", "UserId");
            CreateIndex("dbo.ApplicantDocumentViewModels", "ApplicantProfileViewModels_Id");
            CreateIndex("dbo.ApplicantProfileViewModels", "ImageId");
            CreateIndex("dbo.ApplicantProfileViewModels", "ApplicantId");
            AddForeignKey("dbo.ApplicantProfileViewModels", "ImageId", "dbo.Images", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Images", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicantDocumentViewModels", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels", "Id");
            AddForeignKey("dbo.ApplicantProfileViewModels", "ApplicantId", "dbo.Applicants", "Id", cascadeDelete: true);
        }
    }
}
