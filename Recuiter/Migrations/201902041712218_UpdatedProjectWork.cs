namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProjectWork : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ImagePath", c => c.String());
            DropColumn("dbo.Applicants", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Applicants", "ImagePath", c => c.String());
            DropColumn("dbo.Users", "ImagePath");
        }
    }
}
