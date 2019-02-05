namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageModelDeleted : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Images", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Images", "UserId", "dbo.Users");
            DropIndex("dbo.Images", new[] { "UserId" });
            DropIndex("dbo.Images", new[] { "CreatedById" });
            DropIndex("dbo.Images", new[] { "LastModifiedById" });
            AddColumn("dbo.Applicants", "ImagePath", c => c.String());
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
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastModifiedDate = c.DateTime(),
                        CreatedById = c.Int(nullable: false),
                        LastModifiedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Applicants", "ImagePath");
            CreateIndex("dbo.Images", "LastModifiedById");
            CreateIndex("dbo.Images", "CreatedById");
            CreateIndex("dbo.Images", "UserId");
            AddForeignKey("dbo.Images", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Images", "LastModifiedById", "dbo.Users", "Id");
            AddForeignKey("dbo.Images", "CreatedById", "dbo.Users", "Id");
        }
    }
}
