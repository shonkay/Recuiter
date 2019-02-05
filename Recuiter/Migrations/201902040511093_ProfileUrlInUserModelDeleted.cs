namespace Recruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileUrlInUserModelDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ProfilePictureUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ProfilePictureUrl", c => c.String());
        }
    }
}
