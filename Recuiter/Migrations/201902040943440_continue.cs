namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _continue : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.LastModifiedById)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CreatedById)
                .Index(t => t.LastModifiedById);
            
            AddColumn("dbo.Users", "ProfilePictureUrl", c => c.String());
            DropColumn("dbo.Applicants", "ProfilePicPath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicants", "ProfilePicPath", c => c.String());
            DropForeignKey("dbo.Images", "UserId", "dbo.Users");
            DropForeignKey("dbo.Images", "LastModifiedById", "dbo.Users");
            DropForeignKey("dbo.Images", "CreatedById", "dbo.Users");
            DropIndex("dbo.Images", new[] { "LastModifiedById" });
            DropIndex("dbo.Images", new[] { "CreatedById" });
            DropIndex("dbo.Images", new[] { "UserId" });
            DropColumn("dbo.Users", "ProfilePictureUrl");
            DropTable("dbo.Images");
        }
    }
}
