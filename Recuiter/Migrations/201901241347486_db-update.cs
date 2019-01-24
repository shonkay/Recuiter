namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicantDocuments", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels");
            DropForeignKey("dbo.ApplicantProfileViewModels", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels");
            DropForeignKey("dbo.Educations", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels");
            DropForeignKey("dbo.Institutions", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels");
            DropForeignKey("dbo.Languages", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels");
            DropForeignKey("dbo.Educations", "ApplicantProfileViewModels_Id1", "dbo.ApplicantProfileViewModels");
            DropForeignKey("dbo.Skills", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels");
            DropForeignKey("dbo.Experiences", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels");
            DropIndex("dbo.ApplicantDocuments", new[] { "ApplicantProfileViewModels_Id" });
            DropIndex("dbo.Educations", new[] { "ApplicantProfileViewModels_Id" });
            DropIndex("dbo.Educations", new[] { "ApplicantProfileViewModels_Id1" });
            DropIndex("dbo.Institutions", new[] { "ApplicantProfileViewModels_Id" });
            DropIndex("dbo.Skills", new[] { "ApplicantProfileViewModels_Id" });
            DropIndex("dbo.Experiences", new[] { "ApplicantProfileViewModels_Id" });
            DropIndex("dbo.ApplicantProfileViewModels", new[] { "ApplicantProfileViewModels_Id" });
            DropIndex("dbo.Languages", new[] { "ApplicantProfileViewModels_Id" });
            DropColumn("dbo.ApplicantDocuments", "ApplicantProfileViewModels_Id");
            DropColumn("dbo.Educations", "ApplicantProfileViewModels_Id");
            DropColumn("dbo.Educations", "ApplicantProfileViewModels_Id1");
            DropColumn("dbo.Institutions", "ApplicantProfileViewModels_Id");
            DropColumn("dbo.Skills", "ApplicantProfileViewModels_Id");
            DropColumn("dbo.Experiences", "ApplicantProfileViewModels_Id");
            DropColumn("dbo.Languages", "ApplicantProfileViewModels_Id");
            DropTable("dbo.ApplicantProfileViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicantProfileViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        CompleteAddress = c.String(),
                        YearsOfExperience = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        EducationLevel = c.Int(nullable: false),
                        Bio = c.String(),
                        Title = c.String(),
                        ImagePath = c.String(),
                        Achievement = c.String(),
                        FilePath = c.String(),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        ApplicantProfileViewModels_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Languages", "ApplicantProfileViewModels_Id", c => c.Int());
            AddColumn("dbo.Experiences", "ApplicantProfileViewModels_Id", c => c.Int());
            AddColumn("dbo.Skills", "ApplicantProfileViewModels_Id", c => c.Int());
            AddColumn("dbo.Institutions", "ApplicantProfileViewModels_Id", c => c.Int());
            AddColumn("dbo.Educations", "ApplicantProfileViewModels_Id1", c => c.Int());
            AddColumn("dbo.Educations", "ApplicantProfileViewModels_Id", c => c.Int());
            AddColumn("dbo.ApplicantDocuments", "ApplicantProfileViewModels_Id", c => c.Int());
            CreateIndex("dbo.Languages", "ApplicantProfileViewModels_Id");
            CreateIndex("dbo.ApplicantProfileViewModels", "ApplicantProfileViewModels_Id");
            CreateIndex("dbo.Experiences", "ApplicantProfileViewModels_Id");
            CreateIndex("dbo.Skills", "ApplicantProfileViewModels_Id");
            CreateIndex("dbo.Institutions", "ApplicantProfileViewModels_Id");
            CreateIndex("dbo.Educations", "ApplicantProfileViewModels_Id1");
            CreateIndex("dbo.Educations", "ApplicantProfileViewModels_Id");
            CreateIndex("dbo.ApplicantDocuments", "ApplicantProfileViewModels_Id");
            AddForeignKey("dbo.Experiences", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels", "Id");
            AddForeignKey("dbo.Skills", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels", "Id");
            AddForeignKey("dbo.Educations", "ApplicantProfileViewModels_Id1", "dbo.ApplicantProfileViewModels", "Id");
            AddForeignKey("dbo.Languages", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels", "Id");
            AddForeignKey("dbo.Institutions", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels", "Id");
            AddForeignKey("dbo.Educations", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels", "Id");
            AddForeignKey("dbo.ApplicantProfileViewModels", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels", "Id");
            AddForeignKey("dbo.ApplicantDocuments", "ApplicantProfileViewModels_Id", "dbo.ApplicantProfileViewModels", "Id");
        }
    }
}
