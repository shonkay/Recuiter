namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reviewResult2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ReviewResults");
            AlterColumn("dbo.ReviewResults", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ReviewResults", new[] { "ReviewerId", "ApplicantId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ReviewResults");
            AlterColumn("dbo.ReviewResults", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ReviewResults", "Id");
        }
    }
}
